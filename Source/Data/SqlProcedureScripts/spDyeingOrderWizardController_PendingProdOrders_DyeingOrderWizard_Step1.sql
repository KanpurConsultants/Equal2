Create Procedure [Web].[spDyeingOrderWizardController_PendingProdOrders_DyeingOrderWizard_Step1]     
	@SiteId INT, @DivisionId INT, @DocumentCategoryId INT
AS
BEGIN

DECLARE @TempTable TABLE
(
	ProdOrderNo NVARCHAR(20),
 	ProdOrderHeaderId INT , 
 	ProdOrderDate SMALLDATETIME , 
 	ProdOrderLineId INT , 
 	BuyerCode NVARCHAR(50),
 	ProductId INT , 
 	Dimension1Id INT , 
 	Dimension2Id INT , 
 	BalanceQty DECIMAL(18,4)	
)


INSERT INTO @TempTable(ProdOrderNo, ProdOrderHeaderId, ProdOrderDate, ProdOrderLineId, BuyerCode, ProductId, Dimension1Id, Dimension2Id, BalanceQty)
SELECT L.ProdOrderNo , L.ProdOrderHeaderId, H.DocDate, L.ProdOrderLineId, P.Code AS BuyerCode, L.ProductId, L.Dimension1Id, L.Dimension2Id, L.BalanceQty
FROM Web.ViewProdOrderBalance L 
LEFT JOIN Web.ProdOrderHeaders H ON L.ProdOrderHeaderId = H.ProdOrderHeaderId
LEFT JOIN Web.DocumentTypes D ON H.DocTypeId = D.DocumentTypeId
LEFT JOIN Web.People P ON L.BuyerId = P.PersonID
WHERE H.SiteId = @SiteId AND H.DivisionId = @DivisionId --AND D.DocumentCategoryId = @DocumentCategoryId
AND L.Dimension2Id IS NOT NULL



SELECT L.ProdOrderHeaderId, Max(L.ProdOrderNo) AS ProdOrderNo, Convert(NVARCHAR,FORMAT(Max(L.ProdOrderDate), 'dd/MMM/yyyy')) AS ProdOrderDate, 
Max(L.BuyerCode) AS BuyerCode, 
Max(D2.Dimension2Name) AS Dimension2Name, 
	max(Convert(NVARCHAR,P.ProductName))  AS ProductList,
	(SELECT DISTINCT Convert(NVARCHAR,D1.Dimension1Name) + ', ' 
	FROM @TempTable H 
	LEFT JOIN Web.Dimension1 D1 WITH (NoLock) ON H.Dimension1Id = D1.Dimension1Id
	Where H.ProdOrderHeaderId = L.ProdOrderHeaderId AND H.Dimension2Id = L.Dimension2Id AND H.ProductId = L.ProductId
	FOR XML Path ('')) AS Dimension1List,
	(SELECT Convert(NVARCHAR,H.ProdOrderLineId) + ', ' 
	FROM @TempTable H 
	Where H.ProdOrderHeaderId = L.ProdOrderHeaderId AND H.Dimension2Id = L.Dimension2Id AND H.ProductId = L.ProductId
	FOR XML Path ('')) AS ProdOrderLineIdList,
IsNull(Sum(L.BalanceQty),0) AS Qty
FROM @TempTable L
LEFT JOIN Web.Dimension2 D2 ON L.Dimension2Id = D2.Dimension2Id
LEFT JOIN Web.Products P ON L.ProductId = P.ProductId
GROUP BY L.ProdOrderHeaderId, L.Dimension2Id, L.ProductId
ORDER BY Max(L.ProdOrderDate) DESC 
End


