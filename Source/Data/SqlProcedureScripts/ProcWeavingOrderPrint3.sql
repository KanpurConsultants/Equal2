CREATE Procedure  [Web].[ProcWeavingOrderPrint3]
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





SELECT A.RequisitionLineId, A.JobOrderHeaderId, A.ProductId, A.Dimension1Id, P.UnitId AS Unit, PG.ProductGroupName AS ProductGroupName, 
--CASE WHEN isnull(D1.Dimension1Name,'') <> '' THEN P.ProductName+'/'+ isnull(D1.Dimension1Name,'') ELSE P.ProductName END AS ProductName, 
isnull(D1.Dimension1Name,P.ProductName) AS ProductName, 
D1.Dimension1Name AS Dimension1Name,  A.ReqQty AS ReqQty, A.CancelQty AS CancelQty,A.ReqQty - isnull(A.CancelQty,0) AS NetReqQty,
A.OrderNo AS OrderNo, A.DocDate AS DocDate, C.CostCenterName AS CostCenterName, JW.Name AS JobWorkerName, CPG.ProductGroupName AS Design,
@JobOrderArea AS OrderArea, 'ProcWeavingOrderPrint4 ' + convert(NVARCHAR,A.JobOrderHeaderId) AS SubReportProcList, A.SiteId AS SiteId, A.DivisionId AS DivisionId, 'WeavingOrder_Print3.rdl'  AS ReportName ,
--'WeavingOrder_Print3.rdl' AS ReportName ,
  'Weaving Order' AS ReportTitle,
isnull(A.IQty,0) AS IssueQty,isnull(A.RQty,0) AS ReturnQty
 
FROM
(
SELECT L.RequisitionLineId,  JOH.SiteId AS SiteId, JOH.DivisionId AS DivisionId, JOH.JobOrderHeaderId, JOH.DocNo AS OrderNo, JOH.DocDate AS DocDate, JOH.CostCenterId AS CostCenterId, JOH.JobWorkerId AS JobWorkerId,
L.ProductId, L.Dimension1Id,  L.Qty AS ReqQty , CL.ReqCanQty AS  CancelQty,
SL.IQty AS IQty,SL.RQty AS RQty
FROM Web.RequisitionHeaders H 
LEFT JOIN web.RequisitionLines L ON L.RequisitionHeaderId = H.RequisitionHeaderId 
LEFT JOIN web.JobOrderHeaders JOH ON JOH.JobOrderHeaderId = H.ReferenceDocId
LEFT JOIN 
(
SELECT CL.RequisitionLineId, sum(CL.Qty) AS ReqCanQty  FROM Web.RequisitionCancelLines CL GROUP BY CL.RequisitionLineId 
) CL ON CL.RequisitionLineId = L.RequisitionLineId
LEFT JOIN 	
(
SELECT RequisitionLineId,
sum (isnull((CASE WHEN DocNature='I' THEN isnull(Qty,0) ELSE 0 END ),0)) AS IQty,
sum (isnull((CASE WHEN DocNature='R' THEN isnull(Qty,0) ELSE 0 END ),0)) AS RQty
 FROM Web.Stocklines
WHERE RequisitionLineId IS NOT NULL 
GROUP BY RequisitionLineId
) SL  ON SL.RequisitionLineId=L.RequisitionLineId
WHERE H.ReferenceDocId = @Id
) A
LEFT JOIN web.Products P ON P.ProductId = A.ProductId 
LEFT JOIN web.Dimension1 D1 ON D1.Dimension1Id = A.Dimension1Id 
LEFT JOIN web.ProductGroups PG ON PG.ProductGroupId = P.ProductGroupId 
LEFT JOIN web.CostCenters C WITH (Nolock) ON C.CostCenterId = A.CostCenterId 
LEFT JOIN web.CostCenterStatusExtendeds CC ON CC.CostCenterId = A.CostCenterId 
LEFT JOIN web.Products CP ON CP.ProductId = CC.ProductId 
LEFT JOIN web.ProductGroups CPG ON CPG.ProductGroupId = CP.ProductGroupId  
LEFT JOIN web.People JW WITH (Nolock) ON JW.PersonID = A.JobWorkerId 
ORDER BY A.RequisitionLineId

End


