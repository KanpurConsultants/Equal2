CREATE PROCEDURE [Web].spPackingLineService_FGetPendingOrderListForPacking_GetPendingOrderListForPacking 
(@ProductId INT, @BuyerId INT, @PackingLineId INT)
AS 
BEGIN
SELECT L.SaleOrderLineId, Max(H.BuyerOrderNo) AS SaleOrderNo, 
Max(H.Priority) AS OrderPriority, Max(H.DueDate) AS DueDate
FROM Web.ViewSaleOrderLine L 
LEFT JOIN Web.SaleOrderHeaders H ON L.SaleOrderHeaderId = H.SaleOrderHeaderId
LEFT JOIN (
	SELECT L.SaleOrderLineId, Sum(L.Qty) AS PackedQty
	FROM Web.PackingLines L 
	WHERE L.ProductId = @ProductId
	AND L.PackingLineId <> @PackingLineId
	GROUP BY L.SaleOrderLineId 
) AS VPacked ON L.SaleOrderLineId = VPacked.SaleOrderLineId
WHERE H.SaleToBuyerId = @BuyerId
AND L.ProductId = @ProductId
AND H.Status NOT IN (0,8)
GROUP BY L.SaleOrderLineId
HAVING IsnULL(Sum(L.OrderQty),0) - IsnULL(Sum(L.CancelQty),0) - IsNull(Max(VPacked.PackedQty),0) > 0
ORDER BY OrderPriority DESC , DueDate
END


