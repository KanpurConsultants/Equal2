CREATE  Procedure  Web.sp_PostRequisitionCancelForWeavingOrderCancel @JobOrderCancelHeaderId INT AS 



DECLARE @RequisitionCancelHeaderId NVARCHAR(Max)
DECLARE @RequisitionCancelDocNo NVARCHAR(20)
DECLARE @RequisitionCancelDocTypeId INT 
DECLARE @DocDate SMALLDATETIME
DECLARE @SiteId INT 
DECLARE @DivisionId INT 



SET @RequisitionCancelDocTypeId = 633


SELECT @DocDate = H.DocDate, 
@SiteId = H.SiteId, @DivisionId = H.DivisionId
FROM Web.JobOrderCancelHeaders H 
WHERE JobOrderCancelHeaderId = @JobOrderCancelHeaderId;


EXEC Web.spDocumentTypeService_FGetNewDocNo_GetNewDocNo  @DocDate,  @RequisitionCancelDocTypeId, @SiteId ,@DivisionId,'Web.RequisitionCancelHeaders', @RequisitionCancelDocNo OUTPUT




DECLARE @TempTable AS TABLE ( RequisitionCancelHeaderId INT )

INSERT INTO @TempTable(RequisitionCancelHeaderId)
SELECT Rh.RequisitionCancelHeaderId 
FROM Web.JobOrderCancelHeaders H 
LEFT JOIN Web.RequisitionCancelHeaders Rh ON H.JobOrderCancelHeaderId = Rh.ReferenceDocId
	AND H.DocTypeId = Rh.ReferenceDocTypeId
WHERE JobOrderCancelHeaderId = @JobOrderCancelHeaderId;


BEGIN TRY
BEGIN TRANSACTION


IF (SELECT COUNT(*) FROM @TempTable) <> 0
BEGIN
	DELETE FROM Web.RequisitionCancelLines WHERE RequisitionCancelHeaderId IN (SELECT RequisitionCancelHeaderId FROM @TempTable)
	DELETE FROM Web.RequisitionCancelHeaders WHERE RequisitionCancelHeaderId IN (SELECT RequisitionCancelHeaderId FROM @TempTable)
END 



INSERT INTO Web.RequisitionCancelHeaders (DocTypeId, DocDate, DocNo, DivisionId, SiteId, 
PersonId, ReasonId, ReferenceDocTypeId, ReferenceDocId, Remark, Status, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate)
SELECT @RequisitionCancelDocTypeId AS DocTypeId, H.DocDate, @RequisitionCancelDocNo AS DocNo, H.DivisionId, H.SiteId, 
H.JobWorkerId AS PersonId, 13 AS ReasonId, H.DocTypeId AS ReferenceDocTypeId, H.JobOrderCancelHeaderId AS ReferenceDocId,
H.Remark, H.Status, H.CreatedBy, H.CreatedDate, H.ModifiedBy, H.ModifiedDate
FROM Web.JobOrderCancelHeaders H 
WHERE H.JobOrderCancelHeaderId = @JobOrderCancelHeaderId



INSERT INTO Web.RequisitionCancelLines (RequisitionCancelHeaderId, RequisitionLineId, Qty, Remark, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate)
SELECT Max(Rch.RequisitionCancelHeaderId) AS RequisitionCancelHeaderId, Rl.RequisitionLineId, 
IsNull(Sum(L.Qty),0) AS Qty, NULL AS Remark,
Max(L.CreatedBy) AS CreatedBy, Max(L.ModifiedBy) AS ModifiedBy, 
Max(L.CreatedDate) AS CreatedDate, Max(L.ModifiedDate) AS ModifiedDate
FROM Web.JobOrderCancelBoms L 
LEFT JOIN Web.JobOrderCancelHeaders H ON L.JobOrderCancelHeaderId = H.JobOrderCancelHeaderId
LEFT JOIN Web.JobOrderHeaders Joh ON L.JobOrderHeaderId = Joh.JobOrderHeaderId
LEFT JOIN Web.RequisitionHeaders Rh ON Joh.JobOrderHeaderId = Rh.ReferenceDocId
	AND Joh.DocTypeId = Rh.ReferenceDocTypeId
LEFT JOIN Web.RequisitionLines Rl ON Rh.RequisitionHeaderId = Rl.RequisitionHeaderId
	AND L.ProductId = Rl.ProductId 
	AND IsNull(L.Dimension1Id,'') = IsNull(Rl.Dimension1Id,'')
	AND IsNull(L.Dimension2Id,'') = IsNull(Rl.Dimension2Id,'')
LEFT JOIN Web.RequisitionCancelHeaders Rch ON H.JobOrderCancelHeaderId = Rch.ReferenceDocId
	AND H.DocTypeId = Rch.ReferenceDocTypeId
WHERE L.JobOrderCancelHeaderId = @JobOrderCancelHeaderId
AND Rl.RequisitionLineId IS NOT NULL
GROUP BY Rl.RequisitionLineId, L.ProductId, L.Dimension1Id, L.Dimension2Id


COMMIT TRANSACTION

END TRY


BEGIN CATCH
 	ROLLBACK TRANSACTION;
 	DECLARE @Msg NVARCHAR(Max);
 	SELECT @Msg = ERROR_MESSAGE();
 	THROW 51000, @Msg, 1;
END CATCH


