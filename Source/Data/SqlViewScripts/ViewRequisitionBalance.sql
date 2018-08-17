CREATE VIEW [Web].[ViewRequisitionBalance] AS 
SELECT VRequisition.RequisitionLineId, IsNull(Sum(VRequisition.Qty),0) AS BalanceQty, Max(VRequisition.RequisitionHeaderId) AS RequisitionHeaderId,  Max(VRequisition.RequisitionNo) AS RequisitionNo,  Max(VRequisition.ProductId) AS ProductId, Max(VRequisition.Dimension1Id) Dimension1Id, Max(VRequisition.Dimension2Id) Dimension2Id, 
Max(VRequisition.Dimension3Id) Dimension3Id, Max(VRequisition.Dimension4Id) Dimension4Id, Max(VRequisition.PersonId) AS PersonId, Max(VRequisition.CostCenterId) AS CostCenterId,  Max(VRequisition.SiteId) AS SiteId, Max(VRequisition.DivisionId) AS DivisionId, Max(VRequisition.DocDate) AS OrderDate  
FROM  (  
	SELECT L.RequisitionLineId, H.SiteId, H.DivisionId, L.Qty , H.RequisitionHeaderId, H.DocNo AS RequisitionNo,  L.ProductId, L.Dimension1Id, L.Dimension2Id, L.Dimension3Id, L.Dimension4Id,H.PersonId, H.DocDate ,H.CostCenterId 
	FROM  Web.RequisitionLines L   
	LEFT JOIN Web.RequisitionHeaders H ON L.RequisitionHeaderId = H.RequisitionHeaderId  
	UNION ALL  
	SELECT L.RequisitionLineId, NULL SiteId, NULL AS DivisionId, - L.Qty, NULL AS RequisitionHeaderId, NULL AS RequisitionNo, NULL AS ProductId, NULL Dimension1Id, NULL Dimension2Id, NULL Dimension3Id, NULL Dimension4Id, NULL AS PersonId,  NULL AS DocDate  ,NULL AS CostCenterId
	FROM  Web.RequisitionCancelLines L   
	UNION ALL  
	SELECT L.RequisitionLineId,  NULL SiteId, NULL AS DivisionId, - L.Qty,NULL AS RequisitionHeaderId, NULL AS RequisitionNo, NULL AS ProductId, NULL Dimension1Id, NULL Dimension2Id,  NULL Dimension3Id, NULL Dimension4Id, NULL AS PersonId,  NULL AS DocDate   ,NULL as CostCenterId
	FROM  Web.StockLines L   WHERE L.RequisitionLineId IS NOT NULL 
	AND L.DocNature = 'I'
	UNION ALL  
	SELECT L.RequisitionLineId,  NULL SiteId, NULL AS DivisionId, L.Qty,NULL AS RequisitionHeaderId, NULL AS RequisitionNo, NULL AS ProductId, NULL Dimension1Id, NULL Dimension2Id,  NULL Dimension3Id, NULL Dimension4Id, NULL AS PersonId,  NULL AS DocDate   ,NULL as CostCenterId
	FROM  Web.StockLines L   WHERE L.RequisitionLineId IS NOT NULL 
	AND L.DocNature = 'R'
	) AS VRequisition  
GROUP BY VRequisition.RequisitionLineId