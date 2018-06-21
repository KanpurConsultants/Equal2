CREATE VIEW [Web].[ViewPackingLineService_FGetPendingOrderQtyForDispatch_SaleOrderBalance] AS  
SELECT VSaleOrder.SaleOrderLineId, 
IsNull(Sum(VSaleOrder.Qty),0) AS BalanceQty, IsNull(Sum(VSaleOrder.Rate),0) AS Rate, 
IsNull(Sum(VSaleOrder.Qty),0) * IsNull(Sum(VSaleOrder.Rate),0) AS BalanceAmount, 
Max(VSaleOrder.CurrencyId) AS CurrencyId, Max(VSaleOrder.SiteId) AS SiteId,
Max(VSaleOrder.SaleOrderHeaderId) AS SaleOrderHeaderId, Max(VSaleOrder.SaleOrderNo) AS SaleOrderNo,  
Max(VSaleOrder.ProductId) AS ProductId, Max(VSaleOrder.BuyerId) AS BuyerId, Max(VSaleOrder.DocDate) AS OrderDate, Max(VSaleOrder.DueDate) AS DueDate,
Max(VSaleOrder.Priority) AS Priority,Max(VSaleOrder.Dimension1Id)  Dimension1Id, Max(VSaleOrder.Dimension2Id)  Dimension2Id,
Max(VSaleOrder.Dimension3Id)  Dimension3Id, Max(VSaleOrder.Dimension4Id)  Dimension4Id, Max(VSaleOrder.DivisionId)  DivisionId
FROM  
( 
SELECT H.SiteId, L.SaleOrderLineId, L.OrderQty - L.CancelQty AS Qty , L.RatePerQty AS Rate , H.CurrencyId, H.SaleOrderHeaderId, H.DocNo AS SaleOrderNo, L.ProductId, H.SaleToBuyerId AS BuyerId, H.DocDate, H.DueDate, H.Priority, L.Dimension1Id, L.Dimension2Id, L.Dimension3Id, L.Dimension4Id,H.DivisionId   
FROM Web.ViewSaleOrderLine L WITH (Nolock)
LEFT JOIN Web.SaleOrderHeaders H WITH (Nolock) ON L.SaleOrderHeaderId = H.SaleOrderHeaderId 
UNION ALL 
SELECT NULL AS SiteId, Pl.SaleOrderLineId,  - Pl.Qty, 0 AS Rate ,NULL AS CurrencyId, NULL AS SaleOrderHeaderId, NULL AS SaleOrderNo, NULL AS ProductId, NULL AS BuyerId, NULL AS DocDate  , NULL AS DueDate, NULL AS Priority , NULL AS Dimension1Id, NULL AS Dimension2Id, NULL AS Dimension3Id, NULL AS Dimension4Id, NULL As DivisionId
FROM  Web.SaleDispatchLines L  WITH (Nolock)
LEFT JOIN Web.PackingLines Pl WITH (Nolock) ON L.PackingLineId = Pl.PackingLineId  
) AS VSaleOrder 
GROUP BY VSaleOrder.SaleOrderLineId
HAVING IsNull(Sum(VSaleOrder.Qty),0) > 0

