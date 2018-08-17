CREATE VIEW Web.ViewStockInBalance
                                AS 
                                SELECT L.StockId AS StockInId, H.DocNo AS StockInNo, H.DocDate AS StockInDate, 
                                H.PersonId, L.ProductId, L.Dimension1Id, L.Dimension2Id, L.Dimension3Id, L.Dimension4Id, L.LotNo, 
                                IsNull(L.Qty_Rec,0) - IsNull(VStockAdj.Qty,0) AS BalanceQty,
                                H.DivisionId, H.SiteId
                                FROM Web.Stocks L WITH (NoLock)
                                LEFT JOIN Web.StockHeaders H WITH (NoLock) ON L.StockHeaderId = H.StockHeaderId
                                LEFT JOIN (
	                                SELECT L.StockInId, Sum(L.AdjustedQty) AS Qty
	                                FROM Web.StockAdjs L WITH (NoLock)
	                                GROUP BY L.StockInId
                                ) AS VStockAdj ON L.StockId = VStockAdj.StockInId
                                WHERE 1=1
                                AND IsNull(L.Qty_Rec,0) > 0
                                AND IsNull(L.Qty_Rec,0) - IsNull(VStockAdj.Qty,0) > 0