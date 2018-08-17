Create Procedure Web.spRep_DyeingOrdershadePrint (@Id INT)
AS 
BEGIN
SELECT 
max(H2.H1Shade) AS H1Shade,
max(H2.H1Qty) AS H1Qty,
Max(H2.H1DecimalPlaces) AS H1DecimalPlaces,
max(H2.H2Shade) AS H2Shade,
max(H2.H2Qty) AS H2Qty,
max(H2.H2DecimalPlaces) AS H2DecimalPlace,
max(H2.H3Shade) AS H3Shade,
max(H2.H3Qty) AS H3Qty,
max(H2.H3DecimalPlaces) AS H3DecimalPlaces,
'spRep_TransactionCharges ' + convert(NVARCHAR,@Id) + ', ' + '''web.jobOrderheadercharges''' AS SubReportProcList,
'DyeingOrderShadePrint.rdlc' AS ReportName
 FROM 
(
SELECT 
Convert(INT,(H1.Sr+2)/3) AS Sr,
(CASE WHEN Sr%3 = 1 THEN H1.shade ELSE NULL END) AS H1Shade, 
(CASE WHEN Sr%3 = 1 THEN H1.Qty ELSE NULL END) AS H1Qty, 
(CASE WHEN Sr%3 = 1 THEN H1.DecimalPlaces ELSE NULL END) AS H1DecimalPlaces,
(CASE WHEN Sr%3 = 2 THEN H1.shade ELSE NULL END) AS H2Shade, 
(CASE WHEN Sr%3 = 2 THEN H1.Qty ELSE NULL END) AS H2Qty,
(CASE WHEN Sr%3 = 2 THEN H1.DecimalPlaces ELSE NULL END) AS H2DecimalPlaces,
(CASE WHEN Sr%3 = 0 THEN H1.shade ELSE NULL END) AS H3Shade, 
(CASE WHEN Sr%3 = 0 THEN H1.Qty ELSE NULL END) AS H3Qty ,
(CASE WHEN Sr%3 = 0 THEN H1.DecimalPlaces ELSE NULL END) AS H3DecimalPlaces
 FROM (
SELECT
ROW_NUMBER() OVER(ORDER BY H.shade) as Sr,
 H.shade,Sum(H.Qty) AS Qty,max(H.DecimalPlaces) AS DecimalPlaces  FROM 
(
SELECT  
 D1.Dimension1Name AS shade,
 sum(isnull(L.Qty,0)) AS Qty, 
  isnull(max(U.DecimalPlaces),0) AS DecimalPlaces  
FROM ( SELECT * FROM [Web]._JobOrderHeaders WITH (nolock) WHERE JobOrderHeaderId	= @Id) H 
LEFT JOIN Web._JobOrderLines L WITH (nolock)  ON H.JobOrderHeaderId=L.JobOrderHeaderId
LEFT JOIN Web.Products PD WITH (nolock) ON PD.ProductId = L.ProductId 
LEFT JOIN Web.Units U WITH (nolock) ON U.UnitId = PD.UnitId
LEFT JOIN web.Dimension1 D1  WITH (nolock) ON D1.Dimension1Id=L.Dimension1Id
WHERE H.JobOrderHeaderId	=@Id
GROUP BY D1.Dimension1Name
UNION ALL
 SELECT 
      D1.Dimension1Name AS shade,
    - sum(isnull(JOCL.Qty,0)) AS Qty,
    isnull(max(U.DecimalPlaces),0) AS DecimalPlaces 
	FROM Web.JobOrderCancelLines JOCL WITH (Nolock)
	LEFT JOIN Web.JobOrderLines JOL WITH (Nolock) ON JOCL.JobOrderLineId=JOL.JobOrderLineId
	LEFT JOIN Web.Products PD WITH (nolock) ON PD.ProductId = JOL.ProductId 
    LEFT JOIN Web.Units U WITH (nolock) ON U.UnitId = PD.UnitId
    LEFT JOIN web.Dimension1 D1  WITH (nolock) ON D1.Dimension1Id=JOL.Dimension1Id
	LEFT JOIN Web.JobOrdercancelHeaders JOCH WITH (Nolock) ON JOCH.JobOrderCancelHeaderId=JOCL.JobOrderCancelHeaderId
	LEFT JOIN Web.Documenttypes DT WITH (Nolock) ON DT.DocumentTypeId=JOCH.DocTypeId
	WHERE JOL.JobOrderHeaderId=@Id  AND JOCL.JobOrderCancelLineId IS NOT NULL
	GROUP BY D1.Dimension1Name
	) H 
	GROUP BY H.shade
	HAVING Sum(H.Qty)>0
	) H1
	) H2
	GROUP BY Sr
END


