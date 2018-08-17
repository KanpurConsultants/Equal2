Create Procedure Web.spGatePassStockIssue
@Id INT 
AS 
Begin

SELECT PG.ProductGroupName AS ProductName, L.Specification, sum(L.Qty) AS Qty, Max(P.UnitId) AS UnitId     
FROM web.StockHeaders H WITH (Nolock)
LEFT JOIN web.StockLines L WITH (Nolock) ON L.StockHeaderId = H.StockHeaderId 
LEFT JOIN WEB.Products P WITH (Nolock) ON L.ProductId = P.ProductId
LEFT JOIN web.ProductGroups PG WITH (Nolock) ON PG.ProductGroupId = P.ProductGroupId 
WHERE H.StockHeaderId = @Id AND IsNull(L.DocNature,'I') = 'I'
GROUP BY PG.ProductGroupName, L.Specification
End

