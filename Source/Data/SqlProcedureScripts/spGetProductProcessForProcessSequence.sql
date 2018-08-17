CREATE  Procedure Web.spGetProductProcessForProcessSequence (@ProcessSequenceHeaderId INT)
AS 
SELECT V1.ProcessId, Min(V1.Sequence) AS Sr
FROM (
	SELECT L.ProcessId, L.Sequence
	FROM Web.ProcessSequenceLines L
	WHERE ProcessSequenceHeaderId = @ProcessSequenceHeaderId
) AS V1
GROUP BY V1.ProcessId

