Create Procedure [Web].[spDyeingOrderWizardController_SelectedProdOrderList_DyeingOrderWizard_Step2]     
	@ProdOrderLineIdList VARCHAR(Max)
AS
BEGIN

DECLARE @TempTable TABLE
(
 	ProdOrderHeaderId INT , 
 	ProdOrderLineId INT ,
 	ProductId INT , 
 	Dimension1Id INT , 
 	Dimension2Id INT , 
 	BalanceQty DECIMAL(18,4)	
)


INSERT INTO @TempTable(ProdOrderHeaderId, ProdOrderLineId, ProductId, Dimension1Id, Dimension2Id, BalanceQty)
--SELECT L.ProdOrderHeaderId, L.ProdOrderLineId, L.ProductId, L.Dimension1Id, L.Dimension2Id, L.BalanceQty
--FROM (
--	SELECT L.Dimension2Id
--	FROM (
--		SELECT B.Dimension1Id
--		FROM Web.ViewProdOrderBalance B
--		WHERE B.ProdOrderLineId IN (SELECT Items FROM [dbo].[Split] (@ProdOrderLineIdList, ','))
--	) AS VDimension1 
--	LEFT JOIN Web.ViewProdOrderBalance L ON L.Dimension1Id = VDimension1.Dimension1Id
--) AS VDimension2
--LEFT JOIN Web.ViewProdOrderBalance L ON L.Dimension2Id = VDimension2.Dimension2Id
SELECT L.ProdOrderHeaderId, L.ProdOrderLineId, L.ProductId, L.Dimension1Id, L.Dimension2Id, L.BalanceQty
FROM (
	SELECT B.Dimension1Id
	FROM Web.ViewProdOrderBalance B
	WHERE B.ProdOrderLineId IN (SELECT Items FROM [Web].[Split] (@ProdOrderLineIdList, ','))
	GROUP BY B.Dimension1Id
) AS VDimension1 
LEFT JOIN Web.ViewProdOrderBalance L ON L.Dimension1Id = VDimension1.Dimension1Id


SELECT VMain.ProdOrderHeaderId, Max(H.DocNo) AS ProdOrderNo, Max(P.Code) AS BuyerCode, Convert(NVARCHAR,FORMAT(Max(H.DocDate), 'dd/MMM/yyyy')) AS ProdOrderDate, 
Max(D2.Dimension2Name) AS Dimension2Name, 
	(SELECT DISTINCT Convert(NVARCHAR,P.ProductName) + ', ' 
	FROM @TempTable H 
	LEFT JOIN Web.Products P WITH (NoLock) ON H.ProductId = P.ProductId
	Where H.ProdOrderHeaderId = VMain.ProdOrderHeaderId AND H.Dimension2Id = VMain.Dimension2Id 
	FOR XML Path ('')) AS ProductList,
	(SELECT DISTINCT Convert(NVARCHAR,D1.Dimension1Name) + ', ' 
	FROM @TempTable H 
	LEFT JOIN Web.Dimension1 D1 WITH (NoLock) ON H.Dimension1Id = D1.Dimension1Id
	Where H.ProdOrderHeaderId = VMain.ProdOrderHeaderId AND H.Dimension2Id = VMain.Dimension2Id 
	FOR XML Path ('')) AS Dimension1List,
	(SELECT Convert(NVARCHAR,H.ProdOrderLineId) + ', ' 
	FROM @TempTable H 
	Where H.ProdOrderHeaderId = VMain.ProdOrderHeaderId AND H.Dimension2Id = VMain.Dimension2Id 
	FOR XML Path ('')) AS ProdOrderLineIdList,
	IsNull(Sum(VMain.BalanceQty),0) AS Qty
	FROM @TempTable AS VMain
LEFT JOIN Web.Dimension2 D2 ON VMain.Dimension2Id = D2.Dimension2Id
LEFT JOIN Web.ProdOrderHeaders H ON VMain.ProdOrderHeaderId = H.ProdOrderHeaderId
LEFT JOIN Web.People P ON H.BuyerId = P.PersonID
GROUP BY VMain.ProdOrderHeaderId, VMain.Dimension2Id
ORDER BY Max(H.DocDate) DESC 
END


