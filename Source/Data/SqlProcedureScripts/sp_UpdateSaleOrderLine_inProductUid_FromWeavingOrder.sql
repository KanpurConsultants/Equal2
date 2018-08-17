CREATE   Procedure Web.sp_UpdateSaleOrderLine_inProductUid_FromWeavingOrder @JobOrderHeaderId INT  AS 
BEGIN


UPDATE web.ProductUids  SET web.ProductUids.SaleOrderLineId =A.SaleOrderLineId
FROM 
(
SELECT MPS.SaleOrderLineId, P.ProductUIDId 
FROM web.ProductUids P WITH (Nolock)
LEFT JOIN web.JobOrderHeaders JOH WITH (Nolock) ON JOH.JobOrderHeaderId = P.GenDocId 
LEFT JOIN web.JobOrderLines JOL WITH (Nolock) ON JOL.JobOrderLineId =P.GenLineId 
LEFT JOIN web.ProdOrderLines POL WITH (Nolock) ON POL.ProdOrderLineId = JOL.ProdOrderLineId 
LEFT JOIN web.MaterialPlanForSaleOrders MPS WITH (Nolock) ON MPS.MaterialPlanLineId = POL.MaterialPlanLineId 
WHERE P.GenDocTypeId IN(455,458,637,638,2005) 
AND JOH.SiteId =1 AND MPS.SaleOrderLineId IS NOT NULL 
AND P.GenDocId=@JobOrderHeaderId

) A WHERE  web.ProductUids.ProductUIDId =A.ProductUIDId


END