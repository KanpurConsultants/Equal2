CREATE FUNCTION [Web].FGetExcessStock (@ProductId INTEGER, @DocumentTypeId INTEGER )
Returns Float AS
BEGIN 
DECLARE @ExcessStockQty Float 
DECLARE @ProductTypeId INTEGER 

SET @ProductTypeId = 
(
SELECT PG.ProductTypeId  
FROM Web.Products P
LEFT JOIN Web.ProductGroups PG ON PG.ProductGroupId = P.ProductGroupId 
WHERE P.ProductId = @ProductId
)


IF ( @ProductTypeId = 1 )
BEGIN 

SET @ExcessStockQty = 
(SELECT isnull(sum(V.StockQty),0)+isnull(sum(V.PendingPurchaseOrderQty),0)+isnull(sum(V.PendingProdOrderQty),0)+isnull( sum(V.PendingWeavingOrderQty),0) - isnull( sum(V.PendingSaleOrderQty),0) AS ExcessStockQty 
FROM
(
SELECT H.ProductId, sum(H.Qty)  AS StockQty, 0 AS PendingPurchaseOrderQty , 0  AS PendingProdOrderQty, 0  AS PendingWeavingOrderQty,  0 AS PendingSaleOrderQty
FROM Web.StockBalances H WITH (Nolock)
LEFT JOIN Web.MaterialPlanSettings MPS ON MPS.DocTypeId = @DocumentTypeId
WHERE H.ProductId = @ProductId AND (MPS.GodownId IS NULL OR MPS.GodownId = H.GodownId )
GROUP BY H.ProductId 
/*UNION ALL
SELECT H.ProductId, 0  AS StockQty, sum(H.BalanceQty)  AS PendingPurchaseOrderQty , 0 AS PendingProdOrderQty, 0  AS PendingWeavingOrderQty,  0 AS PendingSaleOrderQty
FROM Web.ViewPurchaseOrderBalance H WITH (Nolock)
WHERE H.ProductId = @ProductId
GROUP BY H.ProductId 
*/
UNION ALL
SELECT H.ProductId, 0  AS StockQty, 0  AS PendingPurchaseOrderQty , sum(H.BalanceQty)  AS PendingProdOrderQty, 0  AS PendingWeavingOrderQty,  0 AS PendingSaleOrderQty
FROM Web.ViewProdOrderBalance H WITH (Nolock)
WHERE H.ProductId = @ProductId
GROUP BY H.ProductId 
UNION ALL
SELECT H.ProductId, 0  AS StockQty, 0  AS PendingPurchaseOrderQty , 0  AS PendingProdOrderQty , sum(H.BalanceQty)  AS PendingWeavingOrderQty, 0 AS PendingSaleOrderQty
FROM Web.ViewJobOrderBalance H WITH (Nolock)
LEFT JOIN Web.JobOrderLines JOL ON JOL.JobOrderLineId = H.JobOrderLineId 
LEFT JOIN Web.JobOrderHeaders JOH ON JOH.JobOrderHeaderId = JOL.JobOrderHeaderId 
WHERE H.ProductId = @ProductId AND JOH.ProcessId = 41
GROUP BY H.ProductId 
UNION ALL
SELECT H.ProductId, 0  AS StockQty, 0  AS PendingPurchaseOrderQty , 0  AS PendingProdOrderQty, 0  AS PendingWeavingOrderQty, sum(H.BalanceQty)  AS PendingSaleOrderQty
FROM Web.ViewSaleOrderBalanceForPlanning H WITH (Nolock)
WHERE H.ProductId = @ProductId
GROUP BY H.ProductId 
) V
GROUP BY V.ProductId)

IF @ExcessStockQty < 0 SET @ExcessStockQty = 0
END
RETURN @ExcessStockQty;
END


