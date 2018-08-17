CREATE Procedure Web.ProcGetStockForPacking
(@ProductId INT, @SiteId INT, @GodownId INT)
AS 
BEGIN
	DECLARE @mPackedPendingToSaleChallan FLOAT ;
	DECLARE @bStockInHand FLOAT ;
		
	SET @mPackedPendingToSaleChallan = 0;
	SET @bStockInHand = 0;
		
	
	SELECT @mPackedPendingToSaleChallan = IsNull(Sum(L.Qty),0)
	FROM Web.PackingLines L 
	LEFT JOIN Web.SaleDispatchLines Sdl ON L.PackingLineId = Sdl.PackingLineId
	WHERE L.ProductId = @ProductId
	AND Sdl.SaleDispatchLineId IS NULL
	
	
	
	SELECT @bStockInHand = IsNull(Sum(L.Qty_Rec),0) - IsNull(Sum(L.Qty_Iss),0) 
	FROM (
		SELECT ProductId, Qty_Rec, Qty_Iss
		FROM Web.Stocks L WITH (NoLock)
		LEFT JOIN Web.Godowns G WITH (NoLock) ON L.GodownId = G.GodownId
		WHERE L.ProductId = @ProductId
		AND G.SiteId = @SiteId
		UNION ALL
		SELECT ProductId, Qty_Rec, Qty_Iss
		FROM Web.StockProcesses L WITH (NoLock)
		LEFT JOIN Web.StockHeaders H WITH (NoLock) ON L.StockHeaderId = H.StockHeaderId
		WHERE L.ProductId = @ProductId
		AND H.SiteId = @SiteId
	) AS L
	GROUP BY L.ProductId
	
	
	SELECT Convert(DECIMAL,(@bStockInHand - @mPackedPendingToSaleChallan)) AS Qty
END;


