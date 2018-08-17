CREATE PROCEDURE Web.spGetHelpListProcessWithChildProcess (@ProcessId INT = NULL)
AS 
WITH LAG_CTE AS 
(
	SELECT L.ProcessId, IsNull(L.ParentProcessId,L.ProcessId) AS ParentProcessId, L.ProcessName, 1 AS [level]
	FROM Web.Processes L
	WHERE ( @ProcessId IS NULL OR @ProcessId = 0 OR L.ProcessId = @ProcessId ) 
	UNION ALL
	SELECT L1.ProcessId, L1.ParentProcessId , L1.ProcessName, lcte.level + 1
	FROM Web.Processes L1
	INNER JOIN LAG_CTE lcte ON lcte.ProcessId = L1.ParentProcessId AND lcte.ProcessId <> L1.ProcessId
)
SELECT L.ProcessId AS Id, L.ProcessName AS [PropFirst] 
FROM LAG_CTE L 
GROUP BY L.ProcessId, L.ProcessName
ORDER BY L.ProcessName

