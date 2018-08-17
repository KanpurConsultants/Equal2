CREATE FUNCTION [Web].FGetExcessStock_WithDimension (@ProductId INTEGER, @DocumentTypeId INTEGER,@DimensionId INTEGER )
Returns Float AS
BEGIN 
DECLARE @ExcessStockQty Float 




SET @ExcessStockQty = 
(SELECT isnull(sum(V.StockQty),0)+isnull(sum(V.PendingPurchaseOrderQty),0)+isnull(sum(V.PendingProdOrderQty),0)+isnull( sum(V.PendingWeavingOrderQty),0) - isnull( sum(V.PendingSaleOrderQty),0) AS ExcessStockQty 
FROM
(
SELECT H.ProductId, sum(H.Qty)  AS StockQty, 0 AS PendingPurchaseOrderQty , 0  AS PendingProdOrderQty, 0  AS PendingWeavingOrderQty,  0 AS PendingSaleOrderQty
FROM Web.StockBalances H WITH (Nolock)
LEFT JOIN Web.MaterialPlanSettings MPS ON MPS.DocTypeId = @DocumentTypeId
WHERE H.ProductId = @ProductId AND H.Dimension1Id =@DimensionId  AND (MPS.GodownId IS NULL OR MPS.GodownId = H.GodownId )
GROUP BY H.ProductId 

UNION ALL
SELECT H.ProductId, 0  AS StockQty, 0  AS PendingPurchaseOrderQty , sum(H.BalanceQty)  AS PendingProdOrderQty, 0  AS PendingWeavingOrderQty,  0 AS PendingSaleOrderQty
FROM Web.ViewProdOrderBalance H WITH (Nolock)
WHERE H.ProductId = @ProductId AND H.DivisionId = @DimensionId
GROUP BY H.ProductId 
UNION ALL
SELECT H.ProductId, 0  AS StockQty, 0  AS PendingPurchaseOrderQty , 0  AS PendingProdOrderQty , sum(H.BalanceQty)  AS PendingWeavingOrderQty, 0 AS PendingSaleOrderQty
FROM Web.ViewJobOrderBalance H WITH (Nolock)
LEFT JOIN Web.JobOrderLines JOL ON JOL.JobOrderLineId = H.JobOrderLineId 
LEFT JOIN Web.JobOrderHeaders JOH ON JOH.JobOrderHeaderId = JOL.JobOrderHeaderId 
WHERE H.ProductId = @ProductId AND H.DivisionId = @DimensionId
GROUP BY H.ProductId 

) V
GROUP BY V.ProductId)

IF @ExcessStockQty < 0 SET @ExcessStockQty = 0

RETURN @ExcessStockQty;
END


