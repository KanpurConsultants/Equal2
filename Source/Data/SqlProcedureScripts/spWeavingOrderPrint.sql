Create Procedure  [Web].[spWeavingOrderPrint] 
(@Id INT)  
As  
BEGIN  

DECLARE @Requisition INT=NULL 
DECLARE @PerkCount INT=0 
DECLARE @SiteId INT=0 
DECLARE @ProcessId INT=0 
DECLARE @ReportName NVARCHAR(500) 

SET @PerkCount= ( SELECT isnull(count(*),0) AS cnt FROM Web.JobOrderPerks JOP WITH (Nolock) 
WHERE JOP.JobOrderHeaderId =1
GROUP BY JOP.JobOrderHeaderId )

SELECT @Requisition=(CASE WHEN max(L.RequisitionLineId) IS NOT NULL THEN 1 ELSE NULL END),
@SiteId=max(H.SiteId), @ProcessId = max(H.ProcessId) 
FROM web.JobOrderHeaders H
LEFT JOIN Web.RequisitionHeaders RH WITH (Nolock) ON RH.ReferenceDocId =H.JobOrderHeaderId 
LEFT JOIN web.RequisitionLines L WITH (Nolock) ON L.RequisitionHeaderId = RH.RequisitionHeaderId 
WHERE H.JobOrderHeaderId  = @Id


SET  @ReportName='Rug_WeavingOrder_Print_OC.rdl'

SELECT isnull(@Requisition,0) AS Requisition,isnull(@PerkCount,0) AS PerkCount, H.SiteId, H.DivisionId, H.JobOrderHeaderId, DT.DocumentTypeShortName AS DocumentTypeName, H.DocDate, H.DocNo, H.DueDate, H.CreatedBy, H.CreatedDate,  
H.Remark, Isnull(P.IsSisterConcern,0) AS IsSisterConcern, P.Name AS JobWorkerName,  PA.Address AS JobWorkerAddress,City.CityName AS JobWorkerCity, P.Phone AS JobWorkerContactNo,
PB.Name AS OrderIssueBy, CC.CostCenterName,  H.CreditDays, H.TermsAndConditions,    
0 AS TimeIncentive, 0 AS TimePenalty,0 AS SmallChunksPenaltyRate, 0 AS SmallChunksPenaltyCount,
L.JobOrderLineId, PD.ProductName, L.DueDate AS LineDueDate, L.Remark AS LineRemark, DU.UnitName AS DealUnit,
(CASE WHEN PG.ImageFileName IS NOT NULL THEN 'Uploads\'+PG.ImageFolderName+'\'+PG.ImageFileName 
  ELSE 'Uploads\NoImage.JPG'  END) AS ImagePath, ( SELECT web.FConvertSqFeetToSqYard(VRA.ManufaturingSizeArea))*L.Qty AS AreainYard,
PG.ProductGroupName, 
--CASE WHEN L.DealUnitId= 'MT2' THEN VSC.SizeName ELSE VRA.ManufaturingSizeName END AS SizeName,
CASE WHEN L.DealUnitId= 'MT2' THEN VRA.ManufaturingSizeName ELSE VRA.StandardSizeName END AS SizeName,
 U.UnitName, 
 --isnull(U.DecimalPlaces,0) AS DecimalPlaces, 
 CASE WHEN L.DealUnitId= 'MT2' THEN 2 ELSE isnull(DU.DecimalPlaces,0)  END AS DecimalPlaces,
L.Rate, VPU.OrdArea AS OrdArea,VPU.CanArea AS CanArea,VPU.RecArea AS RecArea,VPU.BalArea AS BalArea,PU.ProductUidList ProductUidName,
isnull(replace(convert(NVARCHAR, JOLS.RateAmendmentDate, 106), ' ', '/'),0) AS RateAmendmentDate,isnull(JOLS.RateAmendmentRate,0) AS RateAmendmentRate,
0 AS LineIncentive, POH.DocNo  AS ProdOrderNo, SOH.BuyerOrderNo  AS BuyerOrderNo, B.Code AS BuyerCode,  COL.ColourName, PQ.ProductQualityName, PQ.Weight AS WoolLagat, L.LossQty, L.NonCountedQty AS ClothQty,
L.Qty AS OrderQty, isnull(JOLS.CancelQty,0) AS CancelQty, L.DealQty - isnull(JOLS.CancelDealQty,0) AS BalanceArea, --FJOL.Qty* VRA.SqYardPerPcs  AS BalanceArea,
( SELECT TOP 1 isnull(RegistrationNo,'')  FROM web.PersonRegistrations WHERE PersonId = H.JobWorkerId AND RegistrationType = 'PAN No' ) AS PanNo,
''  AS CurrentStatus,  '' AS ProductUidList,PSH.ProcessSequenceHeaderName, VRA.MapSizeName,
H.ModifiedBy +' ' + replace(convert(NVARCHAR, H.ModifiedDate, 106), ' ', '/') + substring (convert(NVARCHAR,H.ModifiedDate),13,7) AS ModifiedBy, 
H.ModifiedDate,   AL.ApproveBy +' ' + replace(convert(NVARCHAR, AL.ApproveDate, 106), ' ', '/') + substring (convert(NVARCHAR,AL.ApproveDate),13,7) AS ApproveBy,   AL.ApproveDate,
'ProcWeavingOrderPrint1 ' + convert(NVARCHAR,H.JobOrderHeaderId) AS SubReportProcList,  
@ReportName AS ReportName ,
(CASE WHEN Isnull(H.Status,0)=0 OR Isnull(H.Status,0)=8 THEN 0 ELSE 1 END ) AS Status,
(CASE WHEN Isnull(H.Status,0)= 0 OR Isnull(H.Status,0)=8 THEN 'Provisional Weaving Order Form ' ELSE 'Weaving Order Form ' END ) AS ReportTitle        
FROM ( SELECT * FROM Web._JobOrderHeaders WITH (Nolock) WHERE JobOrderHeaderId = @Id ) H  
LEFT JOIN Web._JobOrderLines L WITH (Nolock) ON L.JobOrderHeaderId = H.JobOrderHeaderId 
LEFT JOIN web.Units DU ON DU.UnitId = L.DealUnitId
LEFT JOIN web.JobOrderLineStatus JOLS WITH (Nolock) ON JOLS.JoborderlineId = L.JoborderlineId
LEFT JOIN Web.DocumentTypes DT WITH (Nolock) ON DT.DocumentTypeId = H.DocTypeId   
LEFT JOIN web.CostCenters CC ON CC.CostCenterId = H.CostCenterId
LEFT JOIN Web._People P WITH (Nolock) ON P.PersonID = H.JobWorkerId       
LEFT JOIN Web.PersonAddresses PA WITH (nolock) ON PA.PersonId = P.PersonID 
LEFT JOIN Web.Cities City WITH (nolock) ON City.CityId = PA.CityId
LEFT JOIN Web.People PB WITH (Nolock) ON PB.PersonID = H.OrderById  
LEFT JOIN Web.Products PD WITH (Nolock) ON PD.ProductId = L.ProductId  
LEFT JOIN web.ProductGroups PG ON PG.ProductGroupId = PD.ProductGroupId 
LEFT JOIN web.FinishedProduct FP ON FP.ProductId =L.ProductId
LEFT JOIN web.Colours COL WITH (Nolock) ON COL.ColourId = FP.ColourId 
LEFT JOIN web.ProductQualities PQ WITH (Nolock) ON PQ.ProductQualityId = FP.ProductQualityId 
LEFT JOIN web.ProdOrderLines POL WITH (Nolock) ON POL.ProdOrderLineId = L.ProdOrderLineId
LEFT JOIN WEb.ProdOrderHeaders POH ON POH.ProdOrderHeaderId = POL.ProdOrderHeaderId
LEFT JOIN web.People B ON B.personId = POH.BuyerId
LEFT JOIN web.SaleOrderHeaders SOH ON SOH.DocNo = POH.DocNo
LEFT JOIN web.ProcessSequenceHeaders PSH WITH (Nolock) ON PSH.ProcessSequenceHeaderId = FP.ProcessSequenceHeaderId
LEFT JOIN Web.Units U WITH (Nolock) ON U.UnitId = PD.UnitId      
LEFT JOIN Web.ViewProductSize VRA WITH (Nolock) ON VRA.ProductId = L.ProductId      
LEFT JOIN web.ViewSizeinCms VSC WITH (Nolock) ON VSC.SizeId =VRA.ManufaturingSizeID
LEFT JOIN 
	(      
	SELECT AL.DocTypeId, AL.DocId, Max(AL.CreatedBy) AS ApproveBy , max(AL.CreatedDate) AS ApproveDate        FROM  Web.ActivityLogs AL      WHERE AL.ActivityType =2      GROUP BY AL.DocTypeId, AL.DocId  
	) AL ON AL.DocTypeId  = H.DocTypeId AND AL.DocId = H.JobOrderHeaderId  
LEFT JOIN 
  (
	SELECT H.JobWorkerId , sum(L.Qty* web.FConvertSqFeetToSqYard(VRS.ManufaturingSizeArea)) AS OrdArea,
	sum(isnull(LS.CancelQty,0)*web.FConvertSqFeetToSqYard(VRS.ManufaturingSizeArea)) AS CanArea,
	sum(isnull(LS.ReceiveQty,0)*web.FConvertSqFeetToSqYard(VRS.ManufaturingSizeArea)) AS RecArea,
	sum((L.Qty - isnull(LS.ReceiveQty,0)-isnull(LS.CancelQty,0))*web.FConvertSqFeetToSqYard(VRS.ManufaturingSizeArea)) AS BalArea    
	FROM web.JobOrderHeaders H WITH (Nolock)
	LEFT JOIN web.JobOrderLines L WITH (Nolock) ON L.JobOrderHeaderId = H.JobOrderHeaderId 
	LEFT JOIN web.JobOrderLineStatus LS WITH (Nolock) ON LS.JobOrderLineId = L.JobOrderLineId 
	LEFT JOIN web.ViewProductSize VRS WITH (Nolock) ON VRS.ProductId = L.ProductId 
	WHERE H.JobWorkerId = H.JobWorkerId AND H.ProcessId =43
	GROUP BY H.JobWorkerId 

  ) VPU ON VPU.JobWorkerId = H.JobWorkerId
  LEFT JOIN 
  (
  	SELECT PUH.ProductUIDHeaderId, Min( convert(INT,PU.ProductUidName)) AS MinProductUId, Max(convert(INT,PU.ProductUidName)) AS MaxProductUId,
 	CASE WHEN  Min( convert(INT,PU.ProductUidName)) = Max(convert(INT,PU.ProductUidName)) THEN convert(NVARCHAR,Max(convert(INT,PU.ProductUidName))) ELSE 
	Convert(NVARCHAR,Min( convert(INT,PU.ProductUidName))) +'-'+ convert(NVARCHAR,Max(convert(INT,PU.ProductUidName))) END AS ProductUidList
	FROM
	(
	SELECT * FROM web.ProductUidHeaders WITH (Nolock) WHERE GenDocId = @Id
	) AS PUH
	LEFT JOIN web.ProductUids PU WITH (Nolock) ON PU.ProductUidHeaderId = PUH.ProductUidHeaderId 
	GROUP BY PUH.ProductUIDHeaderId

  ) PU ON PU.ProductUIDHeaderId = L.ProductUIDHeaderId
 WHERE H.JobOrderHeaderId	=  @Id   
 ORDER BY L.JobOrderLineId
 End


