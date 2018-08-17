CREATE Procedure Web.sp_PostBomForWeavingOrder
(
	@JobOrderHeaderId INT
)
AS

DECLARE @CreatedBy NVARCHAR(Max)
DECLARE @ModifiedBy NVARCHAR(Max)
DECLARE @SiteId INT 
DECLARE @ProcessId INT 

SELECT @CreatedBy = H.CreatedBy, @ModifiedBy = H.ModifiedBy,@ProcessId= H.ProcessId, @SiteId= H.SiteId 
FROM Web.JobOrderHeaders H 
WHERE JobOrderHeaderId = @JobOrderHeaderId;


DELETE FROM Web.JobOrderBoms WHERE JobOrderHeaderId = @JobOrderHeaderId;

WITH CTBom AS  
(    
	SELECT row_number() OVER (PARTITION BY B.BaseProductId ORDER BY B.BaseProductId, B.ProductId) AS Sr, 
	T.JobOrderLineId,
	B.BaseProductId, B.ProductId, 
	(B.Qty/B.BatchQty) * T.Qty * (CASE WHEN T.DocTypeId = 637 THEN Vrs.ManufaturingSizeArea ELSE  (SELECT * FROM Web.funcConvertSqFeetToSqYard(CASE WHEN T.DocTypeId = 2005 THEN Vrs.StandardSizeArea ELSE Vrs.ManufaturingSizeArea END)) END ) AS ToPQty , 
	B.ProcessId, B.Dimension1Id, B.Dimension2Id, 1 AS LEVEL  
	FROM (SELECT L.ProductId, L.JobOrderLineId,L.Dimension1Id, L.Dimension2Id, H.ProcessId, Max(H.DocTypeId) AS DocTypeId, IsNull(Sum(L.Qty),0) AS Qty
			FROM Web.JobOrderHeaders H 
			LEFT JOIN Web.JobOrderLines L ON H.JobOrderHeaderId = L.JobOrderHeaderId
			WHERE H.JobOrderHeaderId = @JobOrderHeaderId
			GROUP BY L.JobOrderLineId, L.ProductId, L.Dimension1Id, L.Dimension2Id, H.ProcessId
	) T  
	INNER JOIN Web.BomDetails B On B.BaseProductId = T.ProductId --AND b.BaseProcessId = @ProcessId
	LEFT JOIN Web.ViewRugSize Vrs ON B.BaseProductId = Vrs.ProductId
	UNION ALL      
	SELECT row_number() OVER (PARTITION BY B.BaseProductId ORDER BY B.BaseProductId, B.ProductId) AS Sr,
	CTBom.JobOrderLineId,
	B.BaseProductId, B.ProductId, (B.Qty/B.BatchQty)  * CTBom.ToPQty AS ToPQty ,  
	B.ProcessId,  B.Dimension1Id, B.Dimension2Id, LEVEL + 1  
	FROM Web.BomDetails B     
	INNER JOIN Web.Processes on b.ProcessId = Web.Processes.ProcessId
	INNER JOIN CTBom on b.BaseProductId = CTBom.ProductId   AND b.BaseProcessId = @ProcessId 
)      
INSERT INTO Web.JobOrderBoms (JobOrderHeaderId, JobOrderLineId, ProductId, Dimension1Id, Dimension2Id, Qty, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate)
SELECT @JobOrderHeaderId AS JobOrderHeaderId, CTBom.JobOrderLineId AS JobOrderLineId, CTBom.ProductId, CASE WHEN @SiteId=1 THEN CTBom.Dimension1Id ELSE NULL END  Dimension1Id, CASE WHEN @SiteId=1 THEN CTBom.Dimension2Id ELSE NULL END AS Dimension2Id, Round(Sum(CTBom.ToPQty),3) AS Qty,
@CreatedBy AS CreatedBy, @ModifiedBy AS ModifiedBy, GetDate() AS CreatedDate, GetDate() AS ModifiedDate
FROM CTBom     
WHERE CTBom.Level = (SELECT Max(Level) FROM CTBom)
GROUP BY CTBom.JobOrderLineId,CTBom.ProductId, CTBom.ProcessId, CASE WHEN @SiteId=1 THEN CTBom.Dimension1Id ELSE NULL END , CASE WHEN @SiteId=1 THEN CTBom.Dimension2Id ELSE NULL END
ORDER BY max(CTBom.Level)



UPDATE Web.CostCenterStatusExtendeds
SET Web.CostCenterStatusExtendeds.BOMQty = V1.BOMQty
FROM (
	SELECT H.CostCenterId, Sum(L.Qty) AS BomQty
	FROM (SELECT * FROM Web.JobOrderHeaders WHERE JobOrderHeaderId = @JobOrderHeaderId) AS  H 
	LEFT JOIN Web.JobOrderBoms L ON H.JobOrderHeaderId = L.JobOrderHeaderId
	GROUP BY H.CostCenterId
) AS V1 WHERE Web.CostCenterStatusExtendeds.CostCenterId = V1.CostCenterId


