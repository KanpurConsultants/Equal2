CREATE Procedure [Web].spPackingLineService_FGetPendingDeliveryOrderListForPacking_GetPendingDeliveryOrderListForPacking 
(@ProductId INT, @BuyerId INT, @PackingLineId INT)
AS 
BEGIN
SELECT L.SaleDeliveryOrderLineId, Max(H.DocNo) AS SaleDeliveryOrderNo, 
Max(H.Priority) AS OrderPriority, Max(H.DueDate) AS DueDate, Max(H.ShipMethodId) AS ShipMethodId,

(SELECT Count(WSdol.SaleDeliveryOrderLineId) AS Cnt
	FROM Web.ViewSaleDeliveryOrderBalanceForPacking WSdol
	LEFT JOIN Web.SaleDeliveryOrderHeaders WSdoh ON WSdol.SaleDeliveryOrderHeaderId = WSdoh.SaleDeliveryOrderHeaderId
	WHERE WSdol.ProductId = @ProductId
	AND WSdol.BuyerId = @BuyerId
	AND (WSdoh.DueDate < Max(H.DueDate) OR IsNull(WSdoh.Priority,0) > IsNull(Max(H.Priority),0))
) AS OtherBuyerDeliveryOrders

FROM Web.ViewSaleDeliveryOrderLine L 
LEFT JOIN Web.SaleDeliveryOrderHeaders H ON L.SaleDeliveryOrderHeaderId = H.SaleDeliveryOrderHeaderId
LEFT JOIN Web.SaleOrderLines Sol ON L.SaleOrderLineId = Sol.SaleOrderLineId
LEFT JOIN (
	SELECT L.SaleDeliveryOrderLineId, Sum(L.Qty) AS PackedQty
	FROM Web.PackingLines L 
	WHERE L.ProductId = @ProductId
	AND L.PackingLineId <> @PackingLineId
	GROUP BY L.SaleDeliveryOrderLineId 
) AS VPacked ON L.SaleDeliveryOrderLineId = VPacked.SaleDeliveryOrderLineId
WHERE H.BuyerId = @BuyerId
AND Sol.ProductId = @ProductId
GROUP BY L.SaleDeliveryOrderLineId
HAVING IsnULL(Sum(L.Qty),0) - IsNull(Max(VPacked.PackedQty),0) > 0
ORDER BY OrderPriority DESC , DueDate
END

