CREATE Procedure  [Web].[spDyeingOrderPrint](@Id INT)
As
BEGIN
DECLARE @TotalAmount DECIMAL 
SET @TotalAmount = (SELECT Max(Amount) FROM web.jobOrderheadercharges WHERE HeaderTableId = @Id AND ChargeId = 34 ) 

SELECT H.JobOrderHeaderId AS JobOrderHeaderId,P.Name AS DyingHouse,PA.Address,City.CityName AS CityName, P.Mobile AS MobileNo
,(SELECT TOP 1  PR.RegistrationNo  FROM web.PersonRegistrations PR WHERE PersonId =H.JobWorkerId   AND RegistrationType ='Tin No' ) AS TinNo
 , DT.DocumentTypeShortName +'-'+ H.DocNo AS 'OrderNO', replace(convert(VARCHAR, H.DocDate, 106), ' ', '/')  AS 'ORDERDate',replace(convert(VARCHAR, H.DueDate, 106), ' ', '/')  AS DueDate
 , H.CreditDays,PD.ProductName,D1.Dimension1Name AS shade, D1.Description AS Colour,D2.Dimension2Name AS Design,POH.DocNo AS 'PoNo',
 L.Qty AS Qty,L.DealQty AS DealQty, L.Rate, L.Amount AS Amount,H.Remark, H.TermsAndConditions
 ,DT.DocumentTypeShortName, H.DocNo,L.JobOrderlineid
,L.DueDate AS LineDueDate,L.Remark AS LineRemark, U.UnitName AS Unit, isnull(U.DecimalPlaces,0) AS DecimalPlaces,   
  UD.UnitName AS DealUnit, isnull(UD.DecimalPlaces,0) AS DeliveryUnitDecimalPlace, B.Code AS BuyerCode,
 H.ModifiedBy +' ' + Replace(replace(convert(NVARCHAR, H.ModifiedDate, 106), ' ', '/'),'/20','/') + substring (convert(NVARCHAR,H.ModifiedDate),13,7) AS ModifiedBy, H.ModifiedDate,
 CASE WHEN Isnull(H.Status,0)= 0 OR Isnull(H.Status,0)=8 THEN 'Provisional Dyeing Order ' ELSE 'Dyeing Order ' END  AS ReportTitle,
 WD.DivisionName AS DIVISION, WP.Name AS OrderByName,
 H.SiteId AS SiteId,H.DivisionId, 'Rug_DyeingOrderPrint_OC.rdl' AS ReportName,@TotalAmount AS NetAmount,
 H.GatePassHeaderId AS  GatePassHeaderId,'web.jobOrderheadercharges' AS ChargesTableName,  
-- 'spRep_TransactionCharges ' + convert(NVARCHAR,H.JobOrderHeaderId) + ', ' + '''web.jobOrderheadercharges''' AS SubReportProcList 
'spRep_DyeingOrdershadePrint ' + convert(NVARCHAR,@Id)  AS SubReportProcList,NULL AS CanNo,NULL AS CanDate ,
G.GodownName AS Godown,
CASE WHEN Isnull(H.Status,0)=0 OR Isnull(H.Status,0)=8 THEN 0 ELSE 1 END AS Status
--M.MachineName
 
   FROM ( SELECT * FROM [Web]._JobOrderHeaders WITH (nolock) WHERE JobOrderHeaderId	= @Id ) H 
   LEFT JOIN Web.Godowns G WITH (Nolock) ON G.GodownId=H.GodownId
LEFT JOIN Web._JobOrderLines L WITH (nolock)  ON H.JobOrderHeaderId=L.JobOrderHeaderId
LEFT JOIN Web.DocumentTypes DT WITH (nolock) ON DT.DocumentTypeId = H.DocTypeId 
LEFT JOIN Web.People P WITH (nolock) ON P.PersonID = H.JobWorkerId
LEFT JOIN Web.PersonAddresses PA WITH (nolock) ON PA.PersonId = P.PersonID 
LEFT JOIN Web.Cities City WITH (nolock) ON City.CityId = PA.CityId
LEFT JOIN Web.Products PD WITH (nolock) ON PD.ProductId = L.ProductId 
LEFT JOIN web.ProductGroups PG WITH (nolock) ON PG.ProductGroupId = PD.ProductGroupId
LEFT JOIN Web.Divisions WD WITH (nolock) ON WD.DivisionId=H.DivisionId
LEFT JOIN Web.Sites WS WITH (nolock) ON WS.SiteId=H.SiteId
LEFT JOIN Web._People WP WITH (nolock) ON   WP.PersonId=H.OrderById
LEFT JOIN web.ProductTypes PT WITH (nolock) ON PT.ProductTypeId = PG.ProductTypeId
LEFT JOIN Web.Units U WITH (nolock) ON U.UnitId = PD.UnitId 
LEFT JOIN Web.Units UD WITH (nolock) ON UD.UnitId = L.DealUnitId  
LEFT JOIN web.Dimension1 D1  WITH (nolock) ON D1.Dimension1Id=L.Dimension1Id
LEFT JOIN web.Dimension2 D2 WITH (nolock) ON D2.Dimension2Id=L.Dimension2Id
LEFT JOIN Web.ProdOrderLines PO WITH (nolock) ON PO.ProdOrderLineId=L.ProdOrderLineId
LEFT JOIN Web.ProdOrderHeaders  POH WITH (nolock) ON  POH.ProdOrderHeaderId=PO.ProdOrderHeaderId
LEFT JOIN Web.People  B WITH (Nolock) ON B.PersonId = POH.BuyerId
WHERE H.JobOrderHeaderId	= @Id

UNION ALL

SELECT 
max(H.JobOrderHeaderId) AS JobOrderHeaderId,max(P.Name) AS DyingHouse,max(PA.Address) AS Address,
max(City.CityName) AS CityName, max(P.Mobile) AS MobileNo
,(SELECT TOP 1  PR.RegistrationNo  FROM web.PersonRegistrations PR WHERE PersonId =max(H.JobWorkerId)   AND RegistrationType ='Tin No' ) AS TinNo
 , max(DT.DocumentTypeShortName +'-'+ H.DocNo) AS 'OrderNO', replace(convert(VARCHAR, max(H.DocDate), 106), ' ', '/')  AS 'ORDERDate',replace(convert(VARCHAR, max(H.DueDate), 106), ' ', '/')  AS DueDate
 , max(H.CreditDays),max(PD.ProductName) AS ProductName,max(D1.Dimension1Name) AS shade, max(D1.Description) AS Colour,max(D2.Dimension2Name) AS Design,max(POH.DocNo) AS 'PoNo',
 sum(Isnull(JOCL.Qty,0)) AS Qty,NULL AS DealQty, max(L.Rate) AS Rate,sum((isnull(L.Amount,0)/isnull(L.Qty,0))*isnull(JOCL.Qty,0)) AS Amount,
 max(H.Remark) AS Remark, max(H.TermsAndConditions) AS TermsAndConditions
 ,max(DT.DocumentTypeShortName) AS DocumentTypeShortName, max(H.DocNo) AS DocNo,L.JobOrderlineid
,NULL AS LineDueDate,NULL AS LineRemark, max(U.UnitName) AS Unit, max(isnull(U.DecimalPlaces,0)) AS DecimalPlaces,   
  max(UD.UnitName) AS DealUnit, max(isnull(UD.DecimalPlaces,0)) AS DeliveryUnitDecimalPlace, Max(B.Code) AS BuyerCode,
 max(H.ModifiedBy +' ' + Replace(replace(convert(NVARCHAR, H.ModifiedDate, 106), ' ', '/'),'/20','/') + substring (convert(NVARCHAR,H.ModifiedDate),13,7)) AS ModifiedBy, max(H.ModifiedDate) AS ModifiedDate,
 max(CASE WHEN Isnull(H.Status,0)= 0 OR Isnull(H.Status,0)=8 THEN 'Provisional Dyeing Order ' ELSE 'Dyeing Order ' END ) AS ReportTitle,
 max(WD.DivisionName) AS DIVISION, max(WP.Name) AS OrderByName,
 max(H.SiteId) AS SiteId,max(H.DivisionId) AS DivisionId, 'Rug_DyeingOrderPrint.rdl' AS ReportName,@TotalAmount AS NetAmount,
 max(H.GatePassHeaderId)AS  GatePassHeaderId,'web.jobOrderheadercharges' AS ChargesTableName,  
-- 'spRep_TransactionCharges ' + convert(NVARCHAR,max(H.JobOrderHeaderId)) + ', ' + '''web.jobOrderheadercharges''' AS SubReportProcList,  
'spRep_DyeingOrdershadePrint ' + convert(NVARCHAR,max(H.JobOrderHeaderId))  AS SubReportProcList,
  max(JOCL.Canno) AS CanNo,max(JOCL.Date) AS CanDate ,
  max(G.GodownName) AS Godown, 
  max(CASE WHEN Isnull(H.Status,0)=0 OR Isnull(H.Status,0)=8 THEN 0 ELSE 1 END ) AS Status
  --max(M.MachineName) AS MachineName
   FROM (
    SELECT JOCL.JobOrderLineId,DT.DocumentTypeShortName + '-' + JOCH.DocNo AS Canno,replace(convert(VARCHAR, JOCH.DocDate,106),' ','-') AS Date, 
    - JOCL.Qty AS Qty
	FROM Web.JobOrderCancelLines JOCL WITH (Nolock)
	LEFT JOIN Web.JobOrderLines JOL WITH (Nolock) ON JOCL.JobOrderLineId=JOL.JobOrderLineId
	LEFT JOIN Web.JobOrdercancelHeaders JOCH WITH (Nolock) ON JOCH.JobOrderCancelHeaderId=JOCL.JobOrderCancelHeaderId
	LEFT JOIN Web.Documenttypes DT WITH (Nolock) ON DT.DocumentTypeId=JOCH.DocTypeId
	WHERE JOL.JobOrderHeaderId=@Id  AND JOCL.JobOrderCancelLineId IS NOT NULL    
    ) JOCL
	LEFT JOIN Web._JobOrderLines L WITH (nolock)  ON JOCL.JobOrderLineId=L.JobOrderLineId
	LEFT JOIN Web._JobOrderHeaders H WITH (nolock) ON H.JobOrderHeaderId=L.JobOrderHeaderId
	LEFT JOIN Web.DocumentTypes DT WITH (nolock) ON DT.DocumentTypeId = H.DocTypeId 
    LEFT JOIN Web.People P WITH (nolock) ON P.PersonID = H.JobWorkerId
	LEFT JOIN Web.PersonAddresses PA WITH (nolock) ON PA.PersonId = P.PersonID 
	LEFT JOIN Web.Cities City WITH (nolock) ON City.CityId = PA.CityId
	LEFT JOIN Web.Products PD WITH (nolock) ON PD.ProductId = L.ProductId 
	LEFT JOIN web.ProductGroups PG WITH (nolock) ON PG.ProductGroupId = PD.ProductGroupId
	LEFT JOIN Web.Divisions WD WITH (nolock) ON WD.DivisionId=H.DivisionId
	LEFT JOIN Web.Sites WS WITH (nolock) ON WS.SiteId=H.SiteId
	LEFT JOIN Web._People WP WITH (nolock) ON   WP.PersonId=H.OrderById
	LEFT JOIN web.ProductTypes PT WITH (nolock) ON PT.ProductTypeId = PG.ProductTypeId
	LEFT JOIN Web.Units U WITH (nolock) ON U.UnitId = PD.UnitId 
	LEFT JOIN Web.Godowns G WITH (Nolock) ON G.GodownId=H.GodownId
	LEFT JOIN Web.Units UD WITH (nolock) ON UD.UnitId = L.DealUnitId  
	LEFT JOIN web.Dimension1 D1  WITH (nolock) ON D1.Dimension1Id=L.Dimension1Id
	LEFT JOIN web.Dimension2 D2 WITH (nolock) ON D2.Dimension2Id=L.Dimension2Id
	LEFT JOIN Web.ProdOrderLines PO WITH (nolock) ON PO.ProdOrderLineId=L.ProdOrderLineId
	LEFT JOIN Web.ProdOrderHeaders  POH WITH (nolock) ON  POH.ProdOrderHeaderId=PO.ProdOrderHeaderId
	LEFT JOIN Web.People  B WITH (Nolock) ON B.PersonId = POH.BuyerId 
	WHERE H.JobOrderHeaderId	= @Id
	GROUP BY  H.JobOrderHeaderId,L.JobOrderLineId,L.ProductId 

End


