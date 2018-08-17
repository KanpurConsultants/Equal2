CREATE VIEW Web.ViewSaleOrderBalanceForCancellation AS  
SELECT VSaleOrder.SaleOrderLineId, 
IsNull(Sum(VSaleOrder.Qty),0) AS BalanceQty, IsNull(Sum(VSaleOrder.Rate),0) AS Rate, 
IsNull(Sum(VSaleOrder.Qty),0) * IsNull(Sum(VSaleOrder.Rate),0) AS BalanceAmount, 
Max(VSaleOrder.SaleOrderHeaderId) AS SaleOrderHeaderId, Max(VSaleOrder.SaleOrderNo) AS SaleOrderNo,  
Max(VSaleOrder.ProductId) AS ProductId, 
Max(VSaleOrder.Dimension1Id) AS Dimension1Id, 
Max(VSaleOrder.Dimension2Id) AS Dimension2Id, 
Max(VSaleOrder.Dimension3Id) AS Dimension3Id, 
Max(VSaleOrder.Dimension4Id) AS Dimension4Id, 
Max(VSaleOrder.BuyerId) AS BuyerId, Max(VSaleOrder.DocDate) AS OrderDate ,
Max(VSaleOrder.DueDate) AS DueDate, Max(VSaleOrder.Priority) AS Priority
FROM  
( 
SELECT L.SaleOrderLineId, L.OrderQty - L.CancelQty AS Qty , L.RatePerQty AS Rate , H.SaleOrderHeaderId, H.DocNo AS SaleOrderNo, L.ProductId, L.Dimension1Id, L.Dimension2Id, L.Dimension3Id, L.Dimension4Id, H.SaleToBuyerId AS BuyerId, H.DocDate, H.DueDate, H.Priority 
FROM Web.ViewSaleOrderLine L 
LEFT JOIN Web.SaleOrderHeaders H ON L.SaleOrderHeaderId = H.SaleOrderHeaderId 
UNION ALL 
SELECT Pl.SaleOrderLineId,  - Pl.Qty, 0 AS Rate ,NULL AS SaleOrderHeaderId, NULL AS SaleOrderNo, NULL AS ProductId, NULL AS Dimension1Id, NULL AS Dimension2Id, NULL AS Dimension3Id, NULL AS Dimension4Id, NULL AS BuyerId, NULL AS DocDate  , NULL AS DueDate, NULL AS Priority
FROM  Web.PackingLines Pl ) AS VSaleOrder 
GROUP BY VSaleOrder.SaleOrderLineId
HAVING IsNull(Sum(VSaleOrder.Qty),0) > 0