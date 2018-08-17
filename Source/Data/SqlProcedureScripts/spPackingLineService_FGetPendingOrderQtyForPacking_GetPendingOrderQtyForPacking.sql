CREATE PROCEDURE [Web].spPackingLineService_FGetPendingOrderQtyForPacking_GetPendingOrderQtyForPacking
(@SaleOrderLineId INT, @PackingLineId INT)
AS 
BEGIN
SELECT IsnULL(Sum(L.OrderQty),0) - IsnULL(Sum(L.CancelQty),0) - IsNull(Max(VPacked.PackedQty),0) AS Qty
FROM Web.ViewSaleOrderLine L 
LEFT JOIN (
	SELECT L.SaleOrderLineId, Sum(L.Qty) AS PackedQty
	FROM Web.PackingLines L 
	WHERE L.SaleOrderLineId = @SaleOrderLineId
	AND L.PackingLineId <> @PackingLineId
	GROUP BY L.SaleOrderLineId 
) AS VPacked ON L.SaleOrderLineId = VPacked.SaleOrderLineId
LEFT JOIN Web.SaleOrderHeaders H ON L.SaleOrderHeaderId = H.SaleOrderHeaderId
WHERE L.SaleOrderLineId = @SaleOrderLineId
AND H.Status NOT IN (0,8)
GROUP BY L.SaleOrderLineId
END


