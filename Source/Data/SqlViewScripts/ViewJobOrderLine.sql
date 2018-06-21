CREATE VIEW [Web].[ViewJobOrderLine] AS  
SELECT VJobOrder.JobOrderLineId, Max(VJobOrder.JobOrderHeaderId) AS JobOrderHeaderId,  
IsNull(Sum(VJobOrder.Qty),0) AS OrderQty, IsNull(Sum(VJobOrder.CancelQty),0) AS CancelQty, 
IsNull(Sum(VJobOrder.Rate),0) AS Rate, Round(IsNull(Sum(VJobOrder.Qty),0) * IsNull(Sum(VJobOrder.Rate),0),2) AS OrderAmount, 
Round(IsNull(Sum(VJobOrder.CancelQty),0)* IsNull(Sum(VJobOrder.Rate),0),2) AS CancelAmount,  
Max(VJobOrder.ProductId) AS ProductId, Max(VJobOrder.DueDate) AS DueDate, Max(VJobOrder.Specification) AS Specification, 
Max(VJobOrder.DealUnitId) AS DeliveryUnitId, Max(VJobOrder.Remark) AS Remark  
FROM  
(   
SELECT L.JobOrderLineId, L.Qty,  0 AS CancelQty, L.DueDate, L.Rate, L.JobOrderHeaderId, L.ProductId, L.Specification, L.DealUnitId, L.Remark  
FROM  Web.JobOrderLines L    
UNION ALL   
SELECT L.JobOrderLineId, 0 AS Qty, sum(L.Qty) AS CancelQty, NULL AS DueDate, 0 AS Rate, NULL AS JobOrderHeaderId, 
NULL AS ProductId, NULL AS Specification, NULL AS DeliveryUnitId, NULL AS Remark   
FROM  Web.JobOrderCancelLines L    
GROUP BY L.JobOrderLineId   
UNION   ALL 
SELECT L.JobOrderLineId, sum(L.Qty) AS Qty, 0 AS CancelQty, NULL AS DueDate,  0 AS Rate , NULL AS JobOrderHeaderId, NULL AS ProductId, NULL AS Specification, 
NULL AS DeliveryUnitId, NULL AS Remark  
FROM  Web.JobOrderQtyAmendmentLines L    
GROUP BY L.JobOrderLineId   
UNION ALL   
SELECT L.JobOrderLineId, 0 AS Qty,0 AS CancelQty, NULL AS DueDate, Sum(L.Rate) AS Rate , NULL AS JobOrderHeaderId, NULL AS ProductId, 
NULL AS Specification, NULL AS DeliveryUnitId, NULL AS Remark   
FROM  Web.JobOrderRateAmendmentLines L    
GROUP BY L.JobOrderLineId   
) AS VJobOrder 
GROUP BY VJobOrder.JobOrderLineId