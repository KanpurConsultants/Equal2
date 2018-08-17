create Procedure [Web].[SpJobOrderEvents__onHeaderSubmit_UpdateCostCenterStatusExtendedFromOrder] (@JobOrderHeaderId INT)
AS 
BEGIN 


-- For Job Order BOM
UPDATE web.CostCenterStatusExtendeds  SET web.CostCenterStatusExtendeds.BOMQty = A.Qty
FROM 
(
SELECT JOH.CostCenterId, sum(H.Qty) AS Qty  
FROM web.JobOrderBoms H WITH (Nolock)
LEFT JOIN web.JobOrderHeaders JOH WITH (Nolock) ON JOH.JobOrderHeaderId = H.JobOrderHeaderId
WHERE JOH.CostCenterId IS NOT NULL AND JOH.CostCenterId = @JobOrderHeaderId
GROUP BY JOH.CostCenterId 

) A
WHERE web.CostCenterStatusExtendeds.CostCenterId = A.CostCenterId


-- For ProductId
UPDATE web.CostCenterStatusExtendeds  SET web.CostCenterStatusExtendeds.ProductId = A.ProductId
FROM 
(
SELECT H.CostCenterId, max(L.ProductId) AS ProductId
FROM web.JobOrderHeaders H WITH (Nolock)
LEFT JOIN web.JobOrderLines L WITH (Nolock) ON L.JobOrderHeaderId = H.JobOrderHeaderId
WHERE H.JobOrderHeaderId = @JobOrderHeaderId
GROUP BY H.CostCenterId  

) A
WHERE web.CostCenterStatusExtendeds.CostCenterId = A.CostCenterId

-- For RequisitionProductCount
UPDATE web.CostCenterStatusExtendeds  SET web.CostCenterStatusExtendeds.RequisitionProductCount = A.Cnt
FROM 
(
SELECT H.CostCenterId, count( * ) AS Cnt 
FROM web.RequisitionHeaders H WITH (Nolock)
LEFT JOIN web.RequisitionLines L WITH (Nolock) ON L.RequisitionHeaderId = H.RequisitionHeaderId 
WHERE H.ReferenceDocId = @JobOrderHeaderId
GROUP BY H.CostCenterId 
) A
WHERE web.CostCenterStatusExtendeds.CostCenterId = A.CostCenterId


End


