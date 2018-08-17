CREATE  Procedure Web.sp_PostProdOrderCancelAtBranch @JobOrderCancelHeaderId INT  AS 
BEGIN

DECLARE @DocCategoryName NVARCHAR(50)
DECLARE @SisterConcernSiteId INT 
DECLARE @SisterConcernGodownId INT 
DECLARE @DocDate SMALLDATETIME
DECLARE @ProdOrderDocTypeId INT
DECLARE @DivisionId INT
DECLARE @ProdOrderDocNo NVARCHAR(20)



SET @ProdOrderDocTypeId = 274

SELECT @DocCategoryName = DC.DocumentCategoryName , 
@DocDate = H.DocDate, @SisterConcernSiteId = S.SiteId, @DivisionId = H.DivisionId, @SisterConcernGodownId = S.DefaultGodownId
FROM Web.JobOrderHeaders H WITH (NoLock)
LEFT JOIN Web.DocumentTypes D WITH (NoLock) ON H.DocTypeId = D.DocumentTypeId
LEFT JOIN web.DocumentCategories DC WITH (NoLock) ON DC.DocumentCategoryId = D.DocumentCategoryId
LEFT JOIN Web.People P WITH (NoLock) ON H.JobWorkerId = P.PersonID
LEFT JOIN Web.Sites S WITH (NoLock) ON P.PersonID = S.PersonId
WHERE H.JobOrderHeaderId = @JobOrderCancelHeaderId;


DECLARE @TempTable TABLE ( ProdOrderCancelHeaderId INT );


INSERT INTO @TempTable(ProdOrderCancelHeaderId)
SELECT Ph.ProdOrderCancelHeaderId
FROM Web.JobOrderCancelHeaders H WITH (NoLock)
LEFT JOIN Web.DocumentTypes D WITH (NoLock) ON H.DocTypeId = D.DocumentTypeId
LEFT JOIN Web.People P WITH (NoLock) ON H.JobWorkerId = P.PersonID
LEFT JOIN Web.Sites S WITH (NoLock) ON P.PersonID = S.PersonId
LEFT JOIN Web.ProdOrderCancelHeaders Ph WITH (NoLock) ON H.JobOrderCancelHeaderId = Ph.ReferenceDocId	AND H.DocTypeId = Ph.ReferenceDocTypeId
WHERE H.JobOrderCancelHeaderId = @JobOrderCancelHeaderId


BEGIN TRY
BEGIN TRANSACTION



IF (SELECT Count(*) 
	FROM web.JobOrderCancelLines L
	LEFT JOIN web.JobOrderLines JL ON JL.JobOrderLineId = L.JobOrderLineId
	LEFT JOIN Web.JobOrderHeaders JH ON JH.JobOrderHeaderId = JL.JobOrderHeaderId
	LEFT JOIN Web.ProdOrderLines Pol ON JH.DocTypeId = Pol.ReferenceDocTypeId AND POL.ReferenceDocLineId = JL.JobOrderLineId
	LEFT JOIN Web.JobOrderLines Jol ON Pol.ProdOrderLineId = Jol.ProdOrderLineId
	WHERE Jol.JobOrderLineId IS NOT NULL AND L.JobOrderCancelHeaderId =6126) > 0
BEGIN
	---THROW 51000, 'Weaving order is already issued in branch for this order.You can''t change it.', 1;
	
	RETURN
END 


IF (@SisterConcernSiteId IS NOT NULL AND (@DocCategoryName = 'Weaving Order'))
BEGIN
	IF (SELECT Count(*) FROM @TempTable ) > 0 
	BEGIN
		
	  	
		DELETE FROM Web.ProdOrderCancelLines WHERE ProdOrderCancelHeaderId IN  (SELECT ProdOrderCancelHeaderId FROM @TempTable)
		DELETE FROM Web.ProdOrderCancelHeaders WHERE ProdOrderCancelHeaderId IN  (SELECT ProdOrderCancelHeaderId FROM @TempTable)
	END 


INSERT INTO Web.ProdOrderCancelHeaders (DocTypeId, DocDate, DocNo, DivisionId, SiteId, ReferenceDocTypeId, ReferenceDocId, Remark, Status, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate, LockReason)
SELECT 274 DocTypeId, DocDate, DocNo, DivisionId, SiteId, H.DocTypeId AS  ReferenceDocTypeId, H.JobOrderCancelHeaderId, Remark, Status, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate, 'Prod Order Cancel is generated for weaving order issued from main branch.'
FROM Web.JobOrderCancelHeaders H
WHERE H.JobOrderCancelHeaderId = @JobOrderCancelHeaderId


INSERT INTO Web.ProdOrderCancelLines (ProdOrderCancelHeaderId, ProdOrderLineId, Qty, ReferenceDocTypeId, ReferenceDocLineId, LockReason, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate)
SELECT PC.ProdOrderCancelHeaderId, PL.ProdOrderLineId, L.Qty, H.DocTypeId AS ReferenceDocTypeId, L.JobOrderCancelLineId AS  ReferenceDocLineId, 'Prod Order is generated for weaving order issued from main branch.'  AS LockReason, L.CreatedBy, L.ModifiedBy, L.CreatedDate, L.ModifiedDate
FROM Web.JobOrderCancelHeaders H
LEFT JOIN web.ProdOrderCancelHeaders PC ON PC.ReferenceDocTypeId = H.DocTypeId AND  PC.ReferenceDocId = H.JobOrderCancelHeaderId
LEFT JOIN web.JobOrderCancelLines L ON L.JobOrderCancelHeaderId = H.JobOrderCancelHeaderId 
LEFT JOIN web.JobOrderLines JL ON JL.JobOrderLineId =L.JobOrderLineId 
LEFT JOIN web.JobOrderHeaders JH ON JH.JobOrderHeaderId = JL.JobOrderHeaderId 
LEFT JOIN web.ProdOrderLines Pl ON Pl.ReferenceDocTypeId = JH.DocTypeId  AND  Pl.ReferenceDocLineId = JL.JobOrderLineId  
WHERE H.JobOrderCancelHeaderId = @JobOrderCancelHeaderId
	
	
	
	
	UPDATE Web.ProductUids
	SET Web.ProductUids.CurrenctGodownId = @SisterConcernGodownId
	FROM (	
		SELECT Pu.ProductUIDId
		FROM Web.JobOrderLines L WITH (NoLock) 
		LEFT JOIN Web.ProductUids Pu WITH (NoLock) ON L.ProductUidHeaderId = Pu.ProductUidHeaderId
		WHERE L.JobOrderHeaderId = @JobOrderCancelHeaderId
	) AS V1 WHERE Web.ProductUids.ProductUidId = V1.ProductUidId
	
	
	

END 

COMMIT TRANSACTION

END TRY
BEGIN CATCH
 	ROLLBACK TRANSACTION;
 	DECLARE @Msg NVARCHAR(Max);
 	SELECT @Msg = ERROR_MESSAGE();
 	THROW 51000, @Msg, 1;
END CATCH
END

