CREATE Procedure Web.spGatePassRugFinishingOrder
@Id INT 
AS 
Begin

SELECT VRS.FinishingSizeName  AS ProductName, NULL Specification, sum(L.Qty) AS Qty, Max(P.UnitId) AS UnitId     
FROM web.JobOrderHeaders H WITH (Nolock)
LEFT JOIN web.JobOrderLines L WITH (Nolock) ON L.JobOrderHeaderId = H.JobOrderHeaderId 
LEFT JOIN WEB.Products P WITH (Nolock) ON L.ProductId = P.ProductId
LEFT JOIN web.ViewProductSize VRS WITH (Nolock) ON VRS.ProductId  = P.ProductId 
WHERE H.JobOrderHeaderId  = @Id 
GROUP BY VRS.FinishingSizeName, L.Specification

End


