CREATE Procedure Web.sp_GetPrevProcess (@ProductId INT, @GodownId INT, @DocTypeId INT) 
AS 

DECLARE @ProcessId INT 
SET @ProcessId = NULL;

DECLARE @TempTable AS TABLE (ProcessId INT , StockQty DECIMAL (18,4))

INSERT INTO @TempTable(ProcessId, StockQty)
SELECT L.ProcessId, IsNull(Sum(L.Qty_Rec),0) - IsNull(Sum(L.Qty_Iss),0) AS Qty
FROM Web.Stocks L 
WHERE L.ProductId = @ProductId
AND L.GodownId = @GodownId
GROUP BY  L.ProcessId
HAVING IsNull(Sum(L.Qty_Rec),0) - IsNull(Sum(L.Qty_Iss),0) > 0


IF (SELECT Count(*) FROM @TempTable) = 1
BEGIN
	SELECT @ProcessId = ProcessId  FROM @TempTable
END 
ELSE IF (SELECT Count(*) FROM @TempTable) > 1
BEGIN
	SELECT TOP 1 @ProcessId = L.ProcessId
	FROM Web.Stocks L 
	LEFT JOIN Web.StockHeaders H ON L.StockHeaderId = H.StockHeaderId
	WHERE L.ProductId = @ProductId
	AND L.GodownId = @GodownId
	AND H.DocTypeId =  @DocTypeId
	AND IsNull(L.Qty_Iss,0) > 0
	AND L.ProcessId IN (SELECT ProcessId  FROM @TempTable)
	GROUP BY  L.ProcessId
	ORDER BY Count(*) DESC	
END
ELSE
BEGIN 
	SELECT TOP 1 @ProcessId = L.ProcessId 
	FROM Web.Stocks L 
	WHERE L.ProductId = @ProductId
	AND L.ProcessId <> 20
	GROUP BY  L.ProcessId
	HAVING IsNull(Sum(L.Qty_Rec),0) - IsNull(Sum(L.Qty_Iss),0) > 0
END 


SELECT @ProcessId AS ProcessId


