CREATE Procedure Web.sp_UpdateProductUidValuesForJobOrder (@JobOrderHeaderId INT) AS 

DECLARE @SisterConcernPersonId INT 
DECLARE @SisterConcernGodownId INT 

SELECT @SisterConcernPersonId = S.PersonId, @SisterConcernGodownId = S.DefaultGodownId
FROM Web.JobOrderHeaders H WITH (NoLock) 
LEFT JOIN Web.Sites S WITH (NoLock) ON H.SiteId = S.SiteId
WHERE H.JobOrderHeaderId = @JobOrderHeaderId

IF (@SisterConcernPersonId IS NOT NULL)
BEGIN
	UPDATE Web.ProductUids
	SET Web.ProductUids.CurrenctGodownId = @SisterConcernGodownId
	FROM (	
		SELECT L.ProductUidId
		FROM Web.JobOrderLines L WITH (NoLock) 
		WHERE L.JobOrderHeaderId = @JobOrderHeaderId
	) AS V1 WHERE Web.ProductUids.ProductUidId = V1.ProductUidId
END


