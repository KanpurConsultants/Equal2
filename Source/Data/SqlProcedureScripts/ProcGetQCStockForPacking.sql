CREATE Procedure Web.ProcGetQCStockForPacking
(@ProductId INT, @SiteId INT, @StockInHand DECIMAL)
AS 
BEGIN
	DECLARE @StockBalanceInQC DECIMAL ;
	
	SELECT @StockBalanceInQC = IsNull(Sum(L.Qty_Iss),0) - IsNull(Sum(L.Qty_Rec),0) 
	FROM Web.StockHeaders H
	LEFT JOIN Web.StockProcesses L ON H.StockHeaderId = L.StockHeaderId
	WHERE L.ProductId = @ProductId AND H.SiteId = @SiteId
	AND L.ProcessId = 47
	
			
	SELECT Convert(DECIMAL,(@StockInHand - @StockBalanceInQC)) AS Qty
END;


