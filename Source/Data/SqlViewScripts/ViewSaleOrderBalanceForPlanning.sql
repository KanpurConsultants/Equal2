CREATE VIEW web.ViewSaleOrderBalanceForPlanning AS  
SELECT VSaleOrder.SaleOrderLineId, IsNull(Sum(VSaleOrder.Qty),0) AS BalanceQty, IsNull(Sum(VSaleOrder.Rate),0) AS Rate, IsNull(Sum(VSaleOrder.Qty),0) * IsNull(Sum(VSaleOrder.Rate),0) AS BalanceAmount, Max(VSaleOrder.SaleOrderHeaderId) AS SaleOrderHeaderId, Max(VSaleOrder.SaleOrderNo) AS SaleOrderNo,  Max(VSaleOrder.ProductId) AS ProductId, Max(VSaleOrder.BuyerId) AS BuyerId, Max(VSaleOrder.DocDate) AS OrderDate 
FROM 
( 
SELECT L.SaleOrderLineId, L.Qty , L.Rate , H.SaleOrderHeaderId, H.DocNo AS SaleOrderNo, L.ProductId, H.SaleToBuyerId AS BuyerId, H.DocDate 
FROM web.SaleOrderLines L  
LEFT JOIN web.SaleOrderHeaders H ON L.SaleOrderHeaderId = H.SaleOrderHeaderId 
UNION ALL 
SELECT L.SaleOrderLineId, - L.Qty, 0 AS Rate, NULL AS SaleOrderHeaderId, NULL AS SaleOrderNo, NULL AS ProductId, NULL AS BuyerId, NULL AS DocDate 
FROM web.SaleOrderCancelLines L  
UNION 
ALL SELECT L.SaleOrderLineId, L.Qty, 0 AS Rate , NULL AS SaleOrderHeaderId, NULL AS SaleOrderNo, NULL AS ProductId, NULL AS BuyerId, NULL AS DocDate 
FROM web.SaleOrderQtyAmendmentLines L  
UNION ALL 
SELECT L.SaleOrderLineId, 0 AS Qty, L.Rate , NULL AS SaleOrderHeaderId, NULL AS SaleOrderNo, NULL AS ProductId, NULL AS BuyerId, NULL AS DocDate 
FROM web.SaleOrderRateAmendmentLines L  
UNION ALL 
SELECT l.SaleOrderLineId,  - L.Qty, 0 AS Rate ,NULL AS SaleOrderHeaderId, NULL AS SaleOrderNo, NULL AS ProductId, NULL AS BuyerId, NULL AS DocDate  
FROM web.MaterialPlanForSaleOrders  L  
) AS VSaleOrder 
GROUP BY VSaleOrder.SaleOrderLineId
HAVING IsNull(Sum(VSaleOrder.Qty),0) > 0


