CREATE Procedure Web.sp_PostProdOrderAtBranch @JobOrderHeaderId INT  AS 
BEGIN

DECLARE @DocCategoryName NVARCHAR(50)
DECLARE @SisterConcernSiteId INT 
DECLARE @SisterConcernGodownId INT 
DECLARE @DocDate SMALLDATETIME
DECLARE @ProdOrderDocTypeId INT
DECLARE @DivisionId INT
DECLARE @ProdOrderDocNo NVARCHAR(20)



SET @ProdOrderDocTypeId = 273

SELECT @DocCategoryName = DC.DocumentCategoryName , 
@DocDate = H.DocDate, @SisterConcernSiteId = S.SiteId, @DivisionId = H.DivisionId, @SisterConcernGodownId = S.DefaultGodownId
FROM Web.JobOrderHeaders H WITH (NoLock)
LEFT JOIN Web.DocumentTypes D WITH (NoLock) ON H.DocTypeId = D.DocumentTypeId
LEFT JOIN web.DocumentCategories DC WITH (NoLock) ON DC.DocumentCategoryId = D.DocumentCategoryId
LEFT JOIN Web.People P WITH (NoLock) ON H.JobWorkerId = P.PersonID
LEFT JOIN Web.Sites S WITH (NoLock) ON P.PersonID = S.PersonId
WHERE H.JobOrderHeaderId = @JobOrderHeaderId;


DECLARE @TempTable TABLE ( ProdOrderHeaderId INT );


INSERT INTO @TempTable(ProdOrderHeaderId)
SELECT Ph.ProdOrderHeaderId
FROM Web.JobOrderHeaders H WITH (NoLock)
LEFT JOIN Web.DocumentTypes D WITH (NoLock) ON H.DocTypeId = D.DocumentTypeId
LEFT JOIN Web.People P WITH (NoLock) ON H.JobWorkerId = P.PersonID
LEFT JOIN Web.Sites S WITH (NoLock) ON P.PersonID = S.PersonId
LEFT JOIN Web.ProdOrderHeaders Ph WITH (NoLock) ON H.JobOrderHeaderId = Ph.ReferenceDocId
	AND H.DocTypeId = Ph.ReferenceDocTypeId
WHERE H.JobOrderHeaderId = @JobOrderHeaderId


BEGIN TRY
BEGIN TRANSACTION



IF (SELECT Count(*) 
	FROM @TempTable H 
	LEFT JOIN Web.ProdOrderHeaders Poh ON H.ProdOrderHeaderId = Poh.ProdOrderHeaderId
	LEFT JOIN Web.ProdOrderLines Pol ON Poh.ProdOrderHeaderId = Pol.ProdOrderHeaderId
	LEFT JOIN Web.JobOrderLines Jol ON Pol.ProdOrderLineId = Jol.ProdOrderLineId
	WHERE Jol.JobOrderLineId IS NOT NULL) > 0
BEGIN
	--THROW 51000, 'Weaving order is already issued in branch for this order.You can''t change it.', 1;
	
	RETURN
END 


IF (@SisterConcernSiteId IS NOT NULL AND (@DocCategoryName = 'Weaving Order'))
BEGIN
	IF (SELECT Count(*) FROM @TempTable ) > 0 
	BEGIN
		
		DELETE Web.ProdOrderLineStatus
		FROM (
			SELECT L.ProdOrderLineId
			FROM @TempTable H 
			LEFT JOIN Web.ProdOrderLines L ON H.ProdOrderHeaderId = L.ProdOrderHeaderId
		) AS V1 WHERE Web.ProdOrderLineStatus.ProdOrderLineId = V1.ProdOrderLineId
	  	
		DELETE FROM Web.ProdOrderLines WHERE ProdOrderHeaderId IN  (SELECT ProdOrderHeaderId FROM @TempTable)
		DELETE FROM Web.ProdOrderHeaders WHERE ProdOrderHeaderId IN  (SELECT ProdOrderHeaderId FROM @TempTable)
	END 

	INSERT INTO Web.ProdOrderHeaders (DocTypeId, DocDate, DocNo, DivisionId, SiteId, DueDate, Status, 
	ReferenceDocId, ReferenceDocTypeId, Remark, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, LockReason)
	SELECT 273 AS DocTypeId, Max(H.DocDate), Max(H.DocNo) + '-' + IsNull(Max(Poh.DocNo),''), Max(H.DivisionId), @SisterConcernSiteId AS SiteId, 
	Max(H.DueDate), Max(H.Status), 
	Max(H.JobOrderHeaderId) AS ReferenceDocId, Max(H.DocTypeId) AS ReferenceDocTypeId, Max(H.Remark),
	Max(H.CreatedBy), Max(H.CreatedDate), Max(H.ModifiedBy), Max(H.ModifiedDate), 'Prod Order is generated for weaving order issued from main branch.'
	FROM Web.JobOrderHeaders H WITH (NoLock)
	LEFT JOIN Web.JObOrderLines L ON H.JobOrderHeaderId = L.JobOrderHeaderId
	LEFT JOIN Web.ProdOrderLines Pol ON L.ProdOrderLineId = Pol.ProdOrderLineId
	LEFT JOIN Web.ProdOrderHeaders Poh ON Pol.ProdOrderHeaderId = Poh.ProdOrderHeaderId
	WHERE H.JobOrderHeaderId = @JobOrderHeaderId
	GROUP BY L.JobOrderHeaderId, Pol.ProdOrderHeaderId
	
	
	INSERT INTO Web.ProdOrderLines (ProdOrderHeaderId, ProductId, Qty, Remark, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate, 
	ProcessId, Specification, Dimension1Id, Dimension2Id, ReferenceDocTypeId, ReferenceDocLineId, LockReason)
	SELECT Ph.ProdOrderHeaderId AS ProdOrderHeaderId, L.ProductId, L.Qty, L.Remark, L.CreatedBy, L.ModifiedBy, L.CreatedDate, L.ModifiedDate,
	H.ProcessId, L.Specification, L.Dimension1Id, L.Dimension2Id, H.DocTypeId, L.JobOrderLineId, 'Prod Order is generated for weaving order issued from main branch.' 
	FROM Web.JobOrderLines L WITH (NoLock) 
	LEFT JOIN Web.JobOrderHeaders H WITH (NoLock) ON L.JobOrderHeaderId = H.JobOrderHeaderId
	LEFT JOIN Web.ProdOrderLines Pol ON L.ProdOrderLineId = Pol.ProdOrderLineId
	LEFT JOIN Web.ProdOrderHeaders Poh ON Pol.ProdOrderHeaderId = Poh.ProdOrderHeaderId
	LEFT JOIN Web.ProdOrderHeaders Ph WITH (NoLock) ON H.JobOrderHeaderId = Ph.ReferenceDocId
		AND H.DocTypeId = Ph.ReferenceDocTypeId AND H.DocNo + '-' + IsNull(Poh.DocNo,'') = Ph.DocNo
	WHERE L.JobOrderHeaderId = @JobOrderHeaderId
	
	
	
	INSERT INTO Web.ProdOrderLineStatus(ProdOrderLineId)
	SELECT L.ProdOrderLineId
	FROM Web.ProdOrderHeaders H 
	LEFT JOIN Web.ProdOrderLines L ON H.ProdOrderHeaderId = L.ProdOrderHeaderId
	WHERE H.ReferenceDocId = @JobOrderHeaderId
	
	
	UPDATE Web.ProductUids
	SET Web.ProductUids.CurrenctGodownId = @SisterConcernGodownId
	FROM (	
		SELECT Pu.ProductUIDId
		FROM Web.JobOrderLines L WITH (NoLock) 
		LEFT JOIN Web.ProductUids Pu WITH (NoLock) ON L.ProductUidHeaderId = Pu.ProductUidHeaderId
		WHERE L.JobOrderHeaderId = @JobOrderHeaderId
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

