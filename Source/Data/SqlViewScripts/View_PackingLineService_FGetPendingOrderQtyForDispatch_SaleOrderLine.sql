IF OBJECT_ID ('Web.View_PackingLineService_FGetPendingOrderQtyForDispatch_SaleOrderLine') IS NOT NULL
	DROP VIEW [Web].[View_PackingLineService_FGetPendingOrderQtyForDispatch_SaleOrderLine]
GO

CREATE VIEW [Web].[View_PackingLineService_FGetPendingOrderQtyForDispatch_SaleOrderLine] AS  
SELECT VSaleOrder.SaleOrderLineId, Max(VSaleOrder.SaleOrderHeaderId) AS SaleOrderHeaderId,  
IsNull(Sum(VSaleOrder.Qty),0) AS OrderQty, IsNull(Sum(VSaleOrder.CancelQty),0) AS CancelQty, 
IsNull(Sum(VSaleOrder.RatePerQty),0) AS RatePerQty, Round(IsNull(Sum(VSaleOrder.Qty),0) * IsNull(Sum(VSaleOrder.RatePerQty),0),2) AS OrderAmount, 
Round(IsNull(Sum(VSaleOrder.CancelQty),0)* IsNull(Sum(VSaleOrder.RatePerQty),0),2) AS CancelAmount,  
Max(VSaleOrder.ProductId) AS ProductId, Max(VSaleOrder.DueDate) AS DueDate, Max(VSaleOrder.Specification) AS Specification, 
Max(VSaleOrder.DealUnitId) AS DeliveryUnitId, Max(VSaleOrder.Remark) AS Remark, NULL AS Dimension1Id, NULL AS Dimension2Id  ,NULL AS Dimension3Id, NULL AS Dimension4Id
FROM  (   
SELECT L.SaleOrderLineId, L.Qty, 0 AS CancelQty, L.DueDate, (CASE WHEN isnull(L.Qty,0) = 0 THEN L.Rate ELSE L.Amount / isnull(L.Qty,0) END ) AS RatePerQty, L.SaleOrderHeaderId, L.ProductId, L.Specification, L.DealUnitId, L.Remark  
FROM  Web.SaleOrderLines L WITH (Nolock)   
--WHERE L.Qty <>0
--WHERE L.SaleOrderLineId = 75994
UNION ALL   
SELECT L.SaleOrderLineId, 0 AS Qty, sum(L.Qty) AS CancelQty, NULL AS DueDate, 0 AS RatePerQty, NULL AS SaleOrderHeaderId, 
NULL AS ProductId, NULL AS Specification, NULL AS DeliveryUnitId, NULL AS Remark   
FROM  Web.SaleOrderCancelLines L  WITH (Nolock) 
--WHERE L.SaleOrderLineId = 75994 
GROUP BY L.SaleOrderLineId   
UNION   ALL 
SELECT L.SaleOrderLineId,  sum(L.Qty) AS Qty, 0 AS CancelQty, NULL AS DueDate,  0 AS RatePerQty , NULL AS SaleOrderHeaderId, NULL AS ProductId, NULL AS Specification, 
NULL AS DeliveryUnitId, NULL AS Remark  
FROM 
(
SELECT L.SaleOrderLineId,  L.Qty AS Qty,  SOL.Amount/SOL.Qty AS RatePerQty 
FROM  Web.SaleOrderQtyAmendmentLines L WITH (Nolock)   
LEFT JOIN web.SaleOrderLines SOL WITH (Nolock) ON SOL.SaleOrderLineId = L.SaleOrderLineId  
--WHERE L.SaleOrderLineId = 75994
) L
GROUP BY L.SaleOrderLineId 
UNION ALL   
SELECT L.SaleOrderLineId, 0 AS Qty,0 AS CancelQty, NULL AS DueDate, sum(L.Rate) AS RatePerQty , NULL AS SaleOrderHeaderId, NULL AS ProductId, 
NULL AS Specification, NULL AS DeliveryUnitId, NULL AS Remark   
FROM  Web.SaleOrderRateAmendmentLines L WITH (Nolock)   
--WHERE L.SaleOrderLineId = 75994
GROUP BY L.SaleOrderLineId   
) AS VSaleOrder 
GROUP BY VSaleOrder.SaleOrderLineId
GO

