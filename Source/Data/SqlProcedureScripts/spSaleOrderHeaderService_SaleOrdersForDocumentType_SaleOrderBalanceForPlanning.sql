CREATE Procedure   [Web].[spSaleOrderHeaderService_SaleOrdersForDocumentType_SaleOrderBalanceForPlanning]       
@PlanningDocumentType VARCHAR(20) = NULL,	      
@Site VARCHAR(20) = NULL,      
@Division VARCHAR(20) = NULL,
@BuyerId INT = NULL  
as  Begin  

DECLARE @StartDate NVARCHAR (Max)
SET @StartDate ='01/May/2010'

DECLARE @StrfilterContraDocTypes NVARCHAR (Max) 
DECLARE @CondStr NVARCHAR (Max) 
DECLARE @MaterialPlanSettingId INT =0

SET @MaterialPlanSettingId = 
( SELECT TOP 1 MaterialPlanSettingsId  FROM Web.MaterialPlanSettings WHERE  DocTypeId = @PlanningDocumentType AND SiteId  = @Site AND DivisionId = @Division )

IF @MaterialPlanSettingId =0 

SET @MaterialPlanSettingId = 
( SELECT TOP 1 MaterialPlanSettingsId  FROM Web.MaterialPlanSettings WHERE CreatedBy ='System' )


SET @StrfilterContraDocTypes = 
( SELECT isnull(filterContraDocTypes,'')  FROM Web.MaterialPlanSettings WHERE MaterialPlanSettingsId =@MaterialPlanSettingId )

--SELECT @StrfilterContraDocTypes

IF ( @StrfilterContraDocTypes <> '' OR @StrfilterContraDocTypes IS NULL )
BEGIN 
SELECT VSaleOrder.SaleOrderLineId, IsNull(Sum(VSaleOrder.Qty),0) AS BalanceQty, IsNull(Sum(VSaleOrder.Rate),0) AS Rate, IsNull(Sum(VSaleOrder.Qty),0) * IsNull(Sum(VSaleOrder.Rate),0) AS BalanceAmount, 
Max(VSaleOrder.SaleOrderHeaderId) AS SaleOrderHeaderId, Max(VSaleOrder.SaleOrderNo) AS SaleOrderNo,  Max(VSaleOrder.ProductId) AS ProductId,  Max(VSaleOrder.Specification) AS Specification, Max(VSaleOrder.BuyerId) AS BuyerId, Max(VSaleOrder.DocDate) AS OrderDate,
Max(P.ProductName) ProductName, Max(U.UnitName) UnitName, Max(P.ProductGroupId) ProductGroupId,
--CASE WHEN Max(convert(INT,isnull(FP.IsSample,0))) =1 THEN Convert(BIT,1) ELSE (SELECT Convert(BIT,(CASE WHEN Count(*) > 0 THEN 1 ELSE 0 END)) FROM Web.BomDetails WHERE BaseProductId = Max(VSaleOrder.ProductId)) END  AS BomDetailExists
Convert(BIT,1)  AS BomDetailExists
 FROM 
( 
SELECT L.SaleOrderLineId, L.Qty , L.Rate , H.SaleOrderHeaderId, H.DocNo AS SaleOrderNo, L.ProductId, L.Specification, H.SaleToBuyerId AS BuyerId, H.DocDate 
FROM web.SaleOrderLines L  
LEFT JOIN web.SaleOrderHeaders H ON L.SaleOrderHeaderId = H.SaleOrderHeaderId 
WHERE  1=1 
AND H.DocDate >=@StartDate
AND H.Status <> 5 
UNION ALL 
SELECT L.SaleOrderLineId, - L.Qty, 0 AS Rate, NULL AS SaleOrderHeaderId, NULL AS SaleOrderNo, NULL AS ProductId, NULL Specification, NULL AS BuyerId, NULL AS DocDate 
FROM web.SaleOrderCancelLines L  
LEFT JOIN web.SaleOrderLines SOL WITH (Nolock) ON SOL.SaleOrderLineId = L.SaleOrderLineId
LEFT JOIN web.SaleOrderHeaders SOH WITH (Nolock) ON SOL.SaleOrderHeaderId = SOH.SaleOrderHeaderId 
WHERE  1=1 
AND SOH.DocDate >=@StartDate
AND SOH.Status <> 5 

UNION 
ALL SELECT L.SaleOrderLineId, L.Qty, 0 AS Rate , NULL AS SaleOrderHeaderId, NULL AS SaleOrderNo, NULL AS ProductId, NULL Specification, NULL AS BuyerId, NULL AS DocDate 
FROM web.SaleOrderQtyAmendmentLines L  
LEFT JOIN web.SaleOrderLines SOL WITH (Nolock) ON SOL.SaleOrderLineId = L.SaleOrderLineId
LEFT JOIN web.SaleOrderHeaders SOH WITH (Nolock) ON SOL.SaleOrderHeaderId = SOH.SaleOrderHeaderId 
WHERE 1=1 
AND SOH.DocDate >=@StartDate
AND SOH.Status <> 5 

UNION ALL 
SELECT L.SaleOrderLineId, 0 AS Qty, L.Rate , NULL AS SaleOrderHeaderId, NULL AS SaleOrderNo, NULL AS ProductId, NULL Specification, NULL AS BuyerId, NULL AS DocDate 
FROM web.SaleOrderRateAmendmentLines L  
LEFT JOIN web.SaleOrderLines SOL WITH (Nolock) ON SOL.SaleOrderLineId = L.SaleOrderLineId
LEFT JOIN web.SaleOrderHeaders SOH WITH (Nolock) ON SOL.SaleOrderHeaderId = SOH.SaleOrderHeaderId 
WHERE 1=1
AND  SOH.DocDate >=@StartDate
AND SOH.Status <> 5 

UNION ALL 
SELECT l.SaleOrderLineId,  - L.Qty, 0 AS Rate ,SOL.SaleOrderHeaderId  AS SaleOrderHeaderId, NULL AS SaleOrderNo, NULL AS ProductId, NULL Specification, NULL AS BuyerId, NULL AS DocDate  
FROM web.MaterialPlanForSaleOrders  L  
LEFT JOIN web.MaterialPlanHeaders H ON H.MaterialPlanHeaderId  = L.MaterialPlanHeaderId 
LEFT JOIN Web.SaleOrderLines SOL ON SOL.SaleOrderLineId  = L.SaleOrderLineId
LEFT JOIN web.SaleOrderHeaders SOH WITH (Nolock) ON SOL.SaleOrderHeaderId = SOH.SaleOrderHeaderId 
WHERE H.DocTypeId = @PlanningDocumentType
AND SOH.DocDate >=@StartDate
AND SOH.Status <> 5 

) AS VSaleOrder 
LEFT JOIN Web.SaleOrderHeaders SOH ON SOH.SaleOrderHeaderId = VSaleOrder.SaleOrderHeaderId
LEFT JOIN web.Products P ON VSaleOrder.ProductId = P.ProductId
LEFT JOIN web.FinishedProduct FP ON FP.ProductId = P.ProductId  
LEFT JOIN Web.Units U ON P.UnitId = U.UnitId 
--WHERE SOH.Status <> 5 --# Where Status <> 'Closed'
--AND  SOH.DocTypeId IN (SELECT Items FROM  Web.[Split] (@StrfilterContraDocTypes, ',')) 
GROUP BY VSaleOrder.SaleOrderLineId
HAVING IsNull(Sum(VSaleOrder.Qty),0) > 0 
AND max(SOH.Status) <> 5 --# Where Status <> 'Closed'
AND max(P.DivisionId) = @Division
AND ( @BuyerId is null or max(SOH.SaleToBuyerId)  IN (SELECT Items FROM [web].[Split] (@BuyerId, ','))) 
--AND max(SOH.DocTypeId) IN (SELECT Items FROM  Web.[Split] (@StrfilterContraDocTypes, ',')) 

END 


ELSE --In case Contra doc types are defined



BEGIN
SELECT VSaleOrder.SaleOrderLineId, IsNull(Sum(VSaleOrder.Qty),0) AS BalanceQty, IsNull(Sum(VSaleOrder.Rate),0) AS Rate, IsNull(Sum(VSaleOrder.Qty),0) * IsNull(Sum(VSaleOrder.Rate),0) AS BalanceAmount, 
Max(VSaleOrder.SaleOrderHeaderId) AS SaleOrderHeaderId, Max(VSaleOrder.SaleOrderNo) AS SaleOrderNo,  Max(VSaleOrder.ProductId) AS ProductId,  Max(VSaleOrder.Specification) AS Specification, Max(VSaleOrder.ProductId) AS ProductId, Max(VSaleOrder.BuyerId) AS BuyerId, Max(VSaleOrder.DocDate) AS OrderDate,
Max(P.ProductName) ProductName, Max(U.UnitName) UnitName, Max(P.ProductGroupId) ProductGroupId,
--CASE WHEN Max(convert(INT,isnull(FP.IsSample,0))) =1 THEN Convert(BIT,1) ELSE (SELECT Convert(BIT,(CASE WHEN Count(*) > 0 THEN 1 ELSE 0 END)) FROM Web.BomDetails WHERE BaseProductId = Max(VSaleOrder.ProductId)) END  AS BomDetailExists
Convert(BIT,1)  AS BomDetailExists
FROM 
( 
SELECT L.SaleOrderLineId, L.Qty , L.Rate , H.SaleOrderHeaderId, H.DocNo AS SaleOrderNo, L.ProductId, L.Specification , H.SaleToBuyerId AS BuyerId, H.DocDate 
FROM web.SaleOrderLines L  
LEFT JOIN web.SaleOrderHeaders H ON L.SaleOrderHeaderId = H.SaleOrderHeaderId 
WHERE  1=1  
AND H.DocDate >=@StartDate
AND H.Status <> 5 
UNION ALL 
SELECT L.SaleOrderLineId, - L.Qty, 0 AS Rate, NULL AS SaleOrderHeaderId, NULL AS SaleOrderNo, NULL AS ProductId, NULL Specification, NULL AS BuyerId, NULL AS DocDate 
FROM web.SaleOrderCancelLines L  
LEFT JOIN web.SaleOrderLines SOL WITH (Nolock) ON SOL.SaleOrderLineId = L.SaleOrderLineId
LEFT JOIN web.SaleOrderHeaders SOH WITH (Nolock) ON SOL.SaleOrderHeaderId = SOH.SaleOrderHeaderId 
WHERE  1=1  
AND SOH.DocDate >=@StartDate
AND SOH.Status <> 5 

UNION 
ALL SELECT L.SaleOrderLineId, L.Qty, 0 AS Rate , NULL AS SaleOrderHeaderId, NULL AS SaleOrderNo, NULL AS ProductId, NULL Specification, NULL AS BuyerId, NULL AS DocDate 
FROM web.SaleOrderQtyAmendmentLines L  
LEFT JOIN web.SaleOrderLines SOL WITH (Nolock) ON SOL.SaleOrderLineId = L.SaleOrderLineId
LEFT JOIN web.SaleOrderHeaders SOH WITH (Nolock) ON SOL.SaleOrderHeaderId = SOH.SaleOrderHeaderId 
WHERE 1=1 
AND SOH.DocDate >=@StartDate
AND SOH.Status <> 5 

UNION ALL 
SELECT L.SaleOrderLineId, 0 AS Qty, L.Rate , NULL AS SaleOrderHeaderId, NULL AS SaleOrderNo, NULL AS ProductId, NULL Specification, NULL AS BuyerId, NULL AS DocDate 
FROM web.SaleOrderRateAmendmentLines L  
LEFT JOIN web.SaleOrderLines SOL WITH (Nolock) ON SOL.SaleOrderLineId = L.SaleOrderLineId
LEFT JOIN web.SaleOrderHeaders SOH WITH (Nolock) ON SOL.SaleOrderHeaderId = SOH.SaleOrderHeaderId 
WHERE 1=1
AND SOH.DocDate >=@StartDate
AND SOH.Status <> 5 

UNION ALL 
SELECT l.SaleOrderLineId,  - L.Qty, 0 AS Rate ,SOL.SaleOrderHeaderId AS SaleOrderHeaderId, NULL AS SaleOrderNo, NULL AS ProductId, NULL Specification, NULL AS BuyerId, NULL AS DocDate  
FROM web.MaterialPlanForSaleOrders  L  
LEFT JOIN web.MaterialPlanHeaders H ON H.MaterialPlanHeaderId  = L.MaterialPlanHeaderId 
LEFT JOIN Web.SaleOrderLines SOL ON SOL.SaleOrderLineId  = L.SaleOrderLineId
LEFT JOIN web.SaleOrderHeaders SOH WITH (Nolock) ON SOL.SaleOrderHeaderId = SOH.SaleOrderHeaderId 
WHERE H.DocTypeId = @PlanningDocumentType
AND SOH.DocDate >=@StartDate
AND SOH.Status <> 5 
) AS VSaleOrder 
LEFT JOIN Web.SaleOrderHeaders SOH ON SOH.SaleOrderHeaderId = VSaleOrder.SaleOrderHeaderId
LEFT JOIN web.Products P ON VSaleOrder.ProductId = P.ProductId 
LEFT JOIN web.FinishedProduct FP ON FP.ProductId = P.ProductId 
LEFT JOIN Web.Units U ON P.UnitId = U.UnitId 
--WHERE SOH.Status <> 5  
GROUP BY VSaleOrder.SaleOrderLineId
HAVING IsNull(Sum(VSaleOrder.Qty),0) > 0 
AND max(SOH.Status) <> 5 --# Where Status <> 'Closed'
AND ( @BuyerId is null or max(SOH.SaleToBuyerId)  IN (SELECT Items FROM [web].[Split] (@BuyerId, ','))) 
AND max(P.DivisionId) = @Division
AND max(SOH.DocTypeId) IN (SELECT Items FROM  web.[Split] (@StrfilterContraDocTypes, ',')) 
END  
End

