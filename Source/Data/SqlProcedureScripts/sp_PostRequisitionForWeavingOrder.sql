
CREATE Procedure Web.sp_PostRequisitionForWeavingOrder
(
	@JobOrderHeaderId INT
)
AS

DECLARE @RequisitionHeaderId NVARCHAR(Max)
DECLARE @RequisitionDocNo NVARCHAR(20)
DECLARE @RequisitionDocTypeId INT 
DECLARE @DocDate SMALLDATETIME
DECLARE @SiteId INT 
DECLARE @DivisionId INT 


SET @RequisitionDocTypeId = 187

SELECT @DocDate = H.DocDate, 
@SiteId = H.SiteId, @DivisionId = H.DivisionId
FROM Web.JobOrderHeaders H 
WHERE JobOrderHeaderId = @JobOrderHeaderId;


EXEC Web.FGetDocNo  @DocDate,  @RequisitionDocTypeId, @SiteId ,@DivisionId,'Web.RequisitionHeaders', @RequisitionDocNo OUTPUT


DECLARE @TempTable AS TABLE ( RequisitionHeaderId INT )

INSERT INTO @TempTable(RequisitionHeaderId)
SELECT Rh.RequisitionHeaderId 
FROM Web.JobOrderHeaders H 
LEFT JOIN Web.RequisitionHeaders Rh ON H.JobOrderHeaderId = Rh.ReferenceDocId
	AND H.DocTypeId = Rh.ReferenceDocTypeId
WHERE JobOrderHeaderId = @JobOrderHeaderId;



--IF (SELECT Count(Sl.StockLineId) AS Cnt
--	FROM Web.RequisitionLines L 
--	LEFT JOIN Web.StockLines Sl ON L.RequisitionLineId = Sl.RequisitionLineId
--	WHERE l.RequisitionHeaderId IN (SELECT RequisitionHeaderId FROM @TempTable)
--	AND Sl.StockLineId IS NOT NULL) > 0
--BEGIN
--	RETURN
--END 


EXEC Web.sp_UpdateSaleOrderLine_inProductUid_FromWeavingOrder @JobOrderHeaderId

BEGIN TRY
BEGIN TRANSACTION






IF (SELECT COUNT(*) FROM @TempTable) <> 0
BEGIN
	DELETE Web.RequisitionLineStatus
	FROM (
		SELECT L.RequisitionLineId
		FROM Web.RequisitionLines L 
		WHERE l.RequisitionHeaderId IN (SELECT RequisitionHeaderId FROM @TempTable)
	) AS V1 WHERE Web.RequisitionLineStatus.RequisitionLineId = V1.RequisitionLineId
	
	DELETE FROM Web.RequisitionLines WHERE RequisitionHeaderId IN (SELECT RequisitionHeaderId FROM @TempTable)
	DELETE FROM Web.RequisitionHeaders WHERE RequisitionHeaderId IN (SELECT RequisitionHeaderId FROM @TempTable)
END 

INSERT INTO Web.RequisitionHeaders (DocTypeId, DocDate, DocNo, DivisionId, SiteId, Remark, Status, 
CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, PersonId, CostCenterId, 
ReferenceDocId, ReferenceDocTypeId, ReasonId)
SELECT @RequisitionDocTypeId AS DocTypeId, H.DocDate, @RequisitionDocNo AS DocNo, H.DivisionId, H.SiteId, H.Remark, H.Status, 
H.CreatedBy, H.CreatedDate, H.ModifiedBy, H.ModifiedDate, H.JobWorkerId AS PersonId, H.CostCenterId,
H.JobOrderHeaderId AS ReferenceDocId, H.DocTypeId AS ReferenceDocTypeId, 4 AS ReasonId
FROM Web.JobOrderHeaders H 
WHERE H.JobOrderHeaderId = @JobOrderHeaderId	


INSERT INTO Web.RequisitionLines (RequisitionHeaderId, ProductId, Qty, Dimension1Id, Dimension2Id, ProcessId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate)
SELECT Max(Rh.RequisitionHeaderId) AS RequisitionHeaderId, L.ProductId, 
--IsNull(Sum(L.Qty),0) AS Qty, 
Web.RoundToNearestHundredDecimals(Sum(L.Qty)) AS Qty,
L.Dimension1Id, L.Dimension2Id, Max(H.ProcessId) AS ProcessId,
Max(L.CreatedBy) AS CreatedBy, Max(L.ModifiedBy) AS ModifiedBy, Max(L.CreatedDate) AS CreatedDate, 
Max(L.ModifiedDate) AS ModifiedDate
FROM Web.JobOrderBoms L WITH (NoLock)
LEFT JOIN Web.JobOrderHeaders H WITH (NoLock) ON L.JobOrderHeaderId = H.JobOrderHeaderId
LEFT JOIN Web.RequisitionHeaders Rh ON H.JobOrderHeaderId = Rh.ReferenceDocId
	AND H.DocTypeId = Rh.ReferenceDocTypeId
WHERE L.JobOrderHeaderId = @JobOrderHeaderId
GROUP BY L.ProductId, L.Dimension1Id, L.Dimension2Id
ORDER BY L.ProductId, L.Dimension1Id, L.Dimension2Id


INSERT INTO Web.RequisitionLineStatus (RequisitionLineId)
SELECT Rl.RequisitionLineId
FROM Web.JobOrderHeaders H WITH (NoLock) 
LEFT JOIN Web.RequisitionHeaders Rh WITH (NoLock) ON H.JobOrderHeaderId = Rh.ReferenceDocId
	AND H.DocTypeId = Rh.ReferenceDocTypeId
LEFT JOIN Web.RequisitionLines Rl WITH (NoLock) ON Rh.RequisitionHeaderId = Rl.RequisitionHeaderId
WHERE H.JobOrderHeaderId = @JobOrderHeaderId
AND Rl.RequisitionLineId IS NOT NULL


COMMIT TRANSACTION

END TRY
BEGIN CATCH
 	ROLLBACK TRANSACTION;
 	DECLARE @Msg NVARCHAR(Max);
 	SELECT @Msg = ERROR_MESSAGE();
 	THROW 51000, @Msg, 1;
END CATCH

