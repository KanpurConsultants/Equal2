CREATE VIEW [Web].[ViewSaleDeliveryOrderBalanceForPacking] AS  
SELECT VSaleDeliveryOrder.SaleDeliveryOrderLineId, 
IsNull(Sum(VSaleDeliveryOrder.Qty),0) AS BalanceQty, 
Max(VSaleDeliveryOrder.SaleDeliveryOrderHeaderId) AS SaleDeliveryOrderHeaderId, 
Max(VSaleDeliveryOrder.SaleDeliveryOrderNo) AS SaleDeliveryOrderNo,  
Max(VSaleDeliveryOrder.ProductId) AS ProductId, 
Max(VSaleDeliveryOrder.BuyerId) AS BuyerId, 
Max(VSaleDeliveryOrder.DocDate) AS OrderDate 
FROM  
( 
SELECT L.SaleDeliveryOrderLineId, L.Qty AS Qty , H.SaleDeliveryOrderHeaderId, H.DocNo AS SaleDeliveryOrderNo, 
Sol.ProductId, H.BuyerId AS BuyerId, H.DocDate 
FROM Web.ViewSaleDeliveryOrderLine L 
LEFT JOIN Web.SaleOrderLines Sol ON L.SaleOrderLineId = Sol.SaleOrderLineId
LEFT JOIN Web.SaleDeliveryOrderHeaders H ON L.SaleDeliveryOrderHeaderId = H.SaleDeliveryOrderHeaderId 
UNION ALL 
SELECT Pl.SaleDeliveryOrderLineId,  - Pl.Qty, NULL AS SaleDeliveryOrderHeaderId, NULL AS SaleDeliveryOrderNo, 
NULL AS ProductId, NULL AS BuyerId, NULL AS DocDate  
FROM  Web.PackingLines Pl 
) AS VSaleDeliveryOrder 
GROUP BY VSaleDeliveryOrder.SaleDeliveryOrderLineId
HAVING IsNull(Sum(VSaleDeliveryOrder.Qty),0) > 0
