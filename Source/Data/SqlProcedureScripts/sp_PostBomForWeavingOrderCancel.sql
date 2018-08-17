
CREATE Procedure Web.sp_PostBomForWeavingOrderCancel
(
	@JobOrderCancelHeaderId INT
)
AS

DECLARE @CreatedBy NVARCHAR(Max)
DECLARE @ModifiedBy NVARCHAR(Max)
DECLARE @SiteId INT 
DECLARE @ProcessId INT 

SELECT @CreatedBy = H.CreatedBy, @ModifiedBy = H.ModifiedBy,@ProcessId= H.ProcessId, @SiteId= H.SiteId 
FROM Web.JobOrderCancelHeaders H 
WHERE JobOrderCancelHeaderId = @JobOrderCancelHeaderId;


DELETE FROM Web.JobOrderCancelBoms WHERE JobOrderCancelHeaderId  = @JobOrderCancelHeaderId;


WITH CTBom AS  
(    
	SELECT row_number() OVER (PARTITION BY B.BaseProductId ORDER BY B.BaseProductId, B.ProductId) AS Sr, 
	T.JobOrderCancelLineId,
	B.BaseProductId, B.ProductId, 
	(B.Qty/B.BatchQty) * T.Qty * (CASE WHEN T.DocTypeId = 637 THEN Vrs.ManufaturingSizeArea ELSE  (SELECT * FROM Web.funcConvertSqFeetToSqYard(CASE WHEN T.DocTypeId = 2005 THEN Vrs.StandardSizeArea ELSE Vrs.ManufaturingSizeArea END)) END ) AS ToPQty , 
	B.ProcessId, B.Dimension1Id, B.Dimension2Id, 1 AS LEVEL  
	FROM (SELECT JOL.ProductId, L.JobOrderCancelLineId,JOL.Dimension1Id, JOL.Dimension2Id, H.ProcessId, Max(JOH.DocTypeId) AS DocTypeId, IsNull(Sum(L.Qty),0) AS Qty
			FROM Web.JobOrdercancelHeaders H WITH (Nolock)
			LEFT JOIN Web.JobOrderCancelLines L WITH (Nolock) ON H.JobOrderCancelHeaderId = L.JobOrderCancelHeaderId
			LEFT JOIN web.JobOrderLines JOL WITH (Nolock) ON JOL.JobOrderLineId = L.JobOrderLineId
			LEFT JOIN web.JobOrderHeaders JOH WITH (Nolock) ON JOH.JobOrderheaderId = JOL.JobOrderheaderId
			WHERE H.JobOrderCancelHeaderId = @JobOrderCancelHeaderId
			GROUP BY L.JobOrderCancelLineId, JOL.ProductId, JOL.Dimension1Id, JOL.Dimension2Id, H.ProcessId
	) T  
	INNER JOIN Web.BomDetails B WITH (Nolock) On B.BaseProductId = T.ProductId --AND b.BaseProcessId = @ProcessId
	LEFT JOIN Web.ViewRugSize Vrs WITH (Nolock) ON B.BaseProductId = Vrs.ProductId
	UNION ALL      
	SELECT row_number() OVER (PARTITION BY B.BaseProductId ORDER BY B.BaseProductId, B.ProductId) AS Sr,
	CTBom.JobOrderCancelLineId,
	B.BaseProductId, B.ProductId, (B.Qty/B.BatchQty)  * CTBom.ToPQty AS ToPQty ,  
	B.ProcessId,  B.Dimension1Id, B.Dimension2Id, LEVEL + 1  
	FROM Web.BomDetails B     
	INNER JOIN Web.Processes on b.ProcessId = Web.Processes.ProcessId
	INNER JOIN CTBom on b.BaseProductId = CTBom.ProductId   AND b.BaseProcessId = @ProcessId 
)      
INSERT INTO Web.JobOrderCancelBoms (JobOrderCancelHeaderId, JobOrderCancelLineId, ProductId, Qty, Dimension1Id, Dimension2Id, JobOrderHeaderId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate)
SELECT @JobOrderCancelHeaderId AS JobOrderCancelHeaderId, CTBom.JobOrderCancelLineId AS JobOrderCancelLineId, CTBom.ProductId, Round(Sum(CTBom.ToPQty),3) AS Qty, CASE WHEN @SiteId=1 THEN CTBom.Dimension1Id ELSE NULL END  Dimension1Id, CASE WHEN @SiteId=1 THEN CTBom.Dimension2Id ELSE NULL END AS Dimension2Id,  Max(JOL.JobOrderHeaderId) AS JobOrderHeaderId, 
@CreatedBy AS CreatedBy, @ModifiedBy AS ModifiedBy, GetDate() AS CreatedDate, GetDate() AS ModifiedDate
FROM CTBom     
LEFT JOIN web.JobOrderCancelLines JOC WITH (Nolock) ON JOC.JobOrderCancelLineId =CTBom.JobOrderCancelLineId
LEFT JOIN web.JobOrderLines JOL WITH (Nolock) ON JOL.JobOrderLineId = JOC.JobOrderLineId
WHERE CTBom.Level = (SELECT Max(Level) FROM CTBom)
GROUP BY CTBom.JobOrderCancelLineId,CTBom.ProductId, CTBom.ProcessId, CASE WHEN @SiteId=1 THEN CTBom.Dimension1Id ELSE NULL END , CASE WHEN @SiteId=1 THEN CTBom.Dimension2Id ELSE NULL END
ORDER BY max(CTBom.Level)


UPDATE Web.CostCenterStatusExtendeds
SET Web.CostCenterStatusExtendeds.BomCancelQty = isnull(Web.CostCenterStatusExtendeds.BomCancelQty,0) + V1.BomCancelQty
FROM (
SELECT J.CostCenterId,  Sum(L.Qty) AS BomCancelQty
FROM Web.JobOrderCancelBoms L WITH (Nolock)
LEFT JOIN web.JobOrderHeaders J WITH (Nolock) ON J.JobOrderHeaderId = L.JobOrderHeaderId 
WHERE JobOrderCancelHeaderId = @JobOrderCancelHeaderId
GROUP BY J.CostCenterId 
) AS V1 WHERE Web.CostCenterStatusExtendeds.CostCenterId = V1.CostCenterId


