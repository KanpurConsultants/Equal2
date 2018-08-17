CREATE Procedure  [Web].[ProcWeavingOrderPrint1]
(@Id INT)  As  
BEGIN  
DECLARE @JobOrderArea FLOAT  

SET @JobOrderArea = 
(
SELECT Sum(V.ProductArea)   AS OrderArea
FROM
(
SELECT isnull(L.DealQty,0)  AS ProductArea
FROM web.JobOrderLines L WITH (Nolock)
LEFT JOIN web.JobOrderLineStatus JOLS  WITH (Nolock) ON JOLS.JobOrderLineId = L.JobOrderLineId 
WHERE JobOrderHeaderId = @Id
) V
)

SELECT A.JobOrderHeaderId, A.ProductId, A.Dimension1Id, Max(P.ProductName) AS ProductName, Max(P.UnitId) AS Unit, Max(PG.ProductGroupName) AS ProductGroupName, 
max(D1.Dimension1Name) AS Dimension1Name,  @JobOrderArea AS OrderArea,
sum(A.ReqQty) AS ReqQty, sum(A.CancelQty) AS CancelQty,sum(A.ReqQty) - sum(A.CancelQty) AS NetReqQty,
'ProcWeavingOrderPrint3 ' + convert(NVARCHAR,A.JobOrderHeaderId) AS SubReportProcList, 
Max(A.SiteId) AS SiteId, Max(A.DivisionId) AS DivisionId, 'WeavingOrder_Print1_Column.rdl' AS ReportName ,  'Weaving Order' AS ReportTitle  
FROM
(
SELECT Max(JOH.SiteId) AS SiteId, Max(JOH.DivisionId) AS DivisionId, H.JobOrderHeaderId, H.ProductId, H.Dimension1Id,  sum(H.Qty) AS ReqQty , 0 AS  CancelQty
FROM web.JobOrderBoms H WITH (Nolock)
LEFT JOIN web.JobOrderHeaders JOH WITH (Nolock) ON JOH.JobOrderHeaderId = H.JobOrderHeaderId 
WHERE H.JobOrderHeaderId = @Id
GROUP BY H.JobOrderHeaderId, H.ProductId,H.Dimension1Id  
UNION ALL
SELECT Max(JOH.SiteId) AS SiteId, Max(JOH.DivisionId) AS DivisionId, H.JobOrderHeaderId, H.ProductId, H.Dimension1Id, 0 AS ReqQty, sum(H.Qty) AS CancelQty  
FROM web.JobOrderCancelBoms H WITH (Nolock)
LEFT JOIN web.JobOrderHeaders JOH WITH (Nolock) ON JOH.JobOrderHeaderId = H.JobOrderHeaderId 
WHERE H.JobOrderHeaderId = @Id
GROUP BY H.JobOrderHeaderId, H.ProductId, H.Dimension1Id  
) A
LEFT JOIN web.Products P WITH (Nolock) ON P.ProductId = A.ProductId 
LEFT JOIN web.Dimension1 D1 WITH (Nolock) ON D1.Dimension1Id = A.Dimension1Id 
LEFT JOIN web.ProductGroups PG WITH (Nolock) ON PG.ProductGroupId = P.ProductGroupId 
GROUP BY A.JobOrderHeaderId, A.ProductId, A.Dimension1Id 
ORDER BY Max(P.ProductName),max(D1.Dimension1Name)

 End


