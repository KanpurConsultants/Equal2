CREATE FUNCTION Web.FStockBalance (
	@ProductId INT, 
	@Dimension1Id INT = NULL, 
	@Dimension2Id INT = NULL, 
	@ProcessId INT = NULL,
	@LotNo NVARCHAR(100) = NULL,
	@SiteId INT = NULL,
	@AsOnDate SMALLDATETIME = NULL,
	@GodownId INT = NULL
) 
RETURNS DECIMAL
AS BEGIN 

	DECLARE @StockBalance DECIMAL
	
	SELECT @StockBalance = IsNull(Sum(L.Qty_Rec),0) - IsNull(Sum(L.Qty_Iss),0)
	FROM Web.Stocks L WITH (NoLock)
	LEFT JOIN Web.Godowns G WITH (NoLock) ON L.GodownId = G.GodownId
	WHERE L.ProductId = @ProductId
	AND L.DocDate <= IsNull(@AsOnDate,GetDate())
	AND (@Dimension1Id IS NULL OR L.Dimension1Id = @Dimension1Id) 
	AND (@Dimension2Id IS NULL OR L.Dimension2Id = @Dimension2Id) 
	AND (@ProcessId IS NULL OR L.ProcessId = @ProcessId) 
	AND (@SiteId IS NULL OR G.SiteId = @SiteId) 
	AND (@LotNo IS NULL OR L.LotNo = @LotNo) 
	AND (@GodownId IS NULL OR L.GodownId  = @GodownId) 
	GROUP BY L.ProductId

	RETURN IsNull(@StockBalance,0)
END


