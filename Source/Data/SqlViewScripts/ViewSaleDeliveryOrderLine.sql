CREATE VIEW [Web].[ViewSaleDeliveryOrderLine] AS  
SELECT VSaleDeliveryOrder.SaleDeliveryOrderLineId, 
Max(VSaleDeliveryOrder.SaleDeliveryOrderHeaderId) AS SaleDeliveryOrderHeaderId,  
IsNull(Sum(VSaleDeliveryOrder.Qty),0) AS Qty, 
Max(VSaleDeliveryOrder.ProductId) AS ProductId, 
Max(VSaleDeliveryOrder.SaleOrderLineId) AS SaleOrderLineId, 
Max(VSaleDeliveryOrder.DueDate) AS DueDate,
Max(VSaleDeliveryOrder.DocDate) AS DocDate
FROM  (   
	SELECT L.SaleDeliveryOrderLineId, L.Qty, L.SaleDeliveryOrderHeaderId, Sol.ProductId, L.SaleOrderLineId, 
	IsNull(L.DueDate,H.DueDate) AS DueDate, H.DocDate
	FROM  Web.SaleDeliveryOrderLines L WITH (Nolock)   
	LEFT JOIN Web.SaleDeliveryOrderHeaders H ON L.SaleDeliveryOrderHeaderId = H.SaleDeliveryOrderHeaderId
	LEFT JOIN Web.SaleOrderLines SoL WITH (Nolock) ON L.SaleOrderLineId = Sol.SaleOrderLineId
) AS VSaleDeliveryOrder 
GROUP BY VSaleDeliveryOrder.SaleDeliveryOrderLineId