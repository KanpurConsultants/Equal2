CREATE PROCEDURE [Web].spPackingLinrService_FGetPendingOrderListForPackingForProductUid_GetPendingOrderListForPackingForProductUid (@ProductUidId INT, @BuyerId INT) AS 

DECLARE @TempTableCount INT 
CREATE TABLE #TempSaleOrder (  
   	SaleOrderLineId INT,
   	SaleOrderNo NVARCHAR(100)
)


INSERT INTO #TempSaleOrder(SaleOrderLineId,SaleOrderNo)
SELECT Sol.SaleOrderLineId, Soh.BuyerOrderNo AS SaleOrderNo 
FROM web.JobReceiveHeaders H 
LEFT JOIN web.JobReceiveLines L ON L.JobReceiveHeaderId = H.JobReceiveHeaderId 
LEFT JOIN web.ProductUids PU ON PU.ProductUIDId = L.ProductUidId 
LEFT JOIN web.JobOrderLines JOL ON JOl.JobOrderLineId = L.JobOrderLineId 
LEFT JOIN web.ProdOrderLines POL ON POL.ProdOrderLineId = JOL.ProdOrderLineId 
LEFT JOIN web.JobOrderLines JOL1 ON JOL1.JobOrderLineId = POL.ReferenceDocLineId 
LEFT JOIN web.ProdOrderLines POL1 ON POL1.ProdOrderLineId = JOL1.ProdOrderLineId 
LEFT JOIN Web.MaterialPlanLines Mpl ON isnull(POL.MaterialPlanLineId,POL1.MaterialPlanLineId) = Mpl.MaterialPlanLineId
LEFT JOIN Web.MaterialPlanForSaleOrders Mpfs ON Mpl.MaterialPlanLineId = Mpfs.MaterialPlanLineId
LEFT JOIN Web.SaleOrderLines Sol ON Mpfs.SaleOrderLineId = Sol.SaleOrderLineId
LEFT JOIN Web.SaleOrderHeaders Soh ON Sol.SaleOrderHeaderId = Soh.SaleOrderHeaderId
LEFT JOIN web.People P ON P.PersonID = SOH.SaleToBuyerId 
WHERE H.DocTypeId = 448 AND PU.GenDocId =H.JobReceiveHeaderId
AND PU.ProductUIDId =@ProductUidId AND P.PersonID =@BuyerId


SET @TempTableCount = (SELECT COUNT(*) FROM #TempSaleOrder)

--SELECT @TempTableCount
IF @TempTableCount=0
BEGIN
INSERT INTO #TempSaleOrder(SaleOrderLineId,SaleOrderNo)
SELECT Sol.SaleOrderLineId, Soh.BuyerOrderNo AS SaleOrderNo 
FROM web.ProductUids PU 
LEFT JOIN web.SaleOrderLines SOL ON SOL.ProductId =PU.ProductId
LEFT JOIN 
(
SELECT PL.SaleOrderLineId, sum(PL.Qty) AS Qty  FROM web.PackingLines PL GROUP BY PL.SaleOrderLineId 
) PL ON PL.SaleOrderLineId =SOL.SaleOrderLineId
LEFT JOIN web.SaleOrderHeaders  SOH ON SOH.SaleOrderHeaderId= SOL.SaleOrderHeaderId
WHERE PU.ProductUIDId=@ProductUidId AND SOH.SaleToBuyerId =@BuyerId
AND isnull(SOL.Qty,0)-isnull(PL.Qty,0) >0
ORDER BY SOH.DocDate DESC 
END 

SELECT * FROM #TempSaleOrder

