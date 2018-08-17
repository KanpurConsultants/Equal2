CREATE Procedure Web.spWeavingReceiveQACombined_Submitted_PostBomForWeavingReceive 
(
	@JobReceiveHeaderId INT
)
AS

DECLARE @ProcessId INT 

IF (SELECT Count(*)
	FROM Web.JobReceiveLines L 
	LEFT JOIN Web.JobReturnLines Rl ON L.JobReceiveLineId = Rl.JobReceiveLineId
	LEFT JOIN 
	(
		SELECT QAR.JobReceiveLineId,sum(QAR.PenaltyAmt) AS Penalty , sum(QAR.Weight) AS Weight 
		FROM Web.JobReceiveQALines  QAR WITH (Nolock)
	    GROUP BY QAR.JobReceiveLineId
	) QA ON QA.JobReceiveLineId=L.JobReceiveLineId
	WHERE L.JobReceiveHeaderId = @JobReceiveHeaderId
	AND (CASE WHEN isnull(isnull(QA.Weight,0),0) <> 0 THEN isnull(QA.Weight,0) ELSE  isnull(L.Weight,0) END) = 0
	AND Rl.JobReturnLineId IS NULL) > 0
	
BEGIN
	DECLARE @BarCodeList NVARCHAR(Max);
	
	SELECT @BarCodeList = 
	( 
	   SELECT Pu.ProductUidName + ', '   
	   FROM  Web.JobReceiveLines L 
	   LEFT JOIN Web.JobReturnLines Rl ON L.JobReceiveLineId = Rl.JobReceiveLineId
	   LEFT JOIN Web.ProductUids Pu ON L.ProductUidId = Pu.ProductUIDId
	   WHERE L.JobReceiveHeaderId = @JobReceiveHeaderId
	   AND IsNull(L.Weight,0) = 0
	   AND Rl.JobReturnLineId IS NULL
	   FOR XML Path ('')
	);
	
	DECLARE @Msg NVARCHAR(Max);
	
	SELECT @Msg = 'Weight is not filled for BarCodes: ' + @BarCodeList ;

	THROW 51000, @Msg , 1;
END 	


SET Context_Info 0x55555
DELETE FROM Web.JobReceiveBoms WHERE JobReceiveHeaderId = @JobReceiveHeaderId
DELETE FROM Web.StockProcesses WHERE StockHeaderId  IN (SELECT StockHeaderId FROM web.JobReceiveHeaders WHERE JobReceiveHeaderId = @JobReceiveHeaderId)


SET @ProcessId = ( SELECT ProcessId FROM web.JobReceiveHeaders WHERE JobReceiveHeaderId =@JobReceiveHeaderId )

--IF (SELECT DivisionId  FROM Web.JobReceiveHeaders WHERE JobReceiveHeaderId = @JobReceiveHeaderId) = 2
IF (1=2)
BEGIN
	INSERT INTO Web.StockProcesses (StockHeaderId, ProductId, Dimension1Id, Dimension2Id, ProcessId, CostCenterId, 
	Qty_Iss, Qty_Rec, DocLineId,
	CreatedBy, ModifiedBy, CreatedDate, ModifiedDate, DocDate)
	
	
	
	---------------This Outer Query is implemented to equalize values of new and old tables.--------------
	---------------Qury Can be Remmove when Old Software will be closed.------------------
	SELECT StockHeaderId, ProductId, NULL AS Dimension1Id, NULL AS Dimension2Id, 
	Max(ProcessId) AS ProcessId, CostCenterId, 
	Round(Sum(Qty_Iss),3) AS Qty_Iss, Round(Sum(Qty_Rec),3) AS Qty_Rec, VMain.JobReceiveLineId AS DocLineId, Max(CreatedBy) AS CreatedBy, 
	Max(ModifiedBy) AS ModifiedBy, Max(CreatedDate) AS CreatedDate,getdate() AS ModifiedDate, 
	Max(DocDate) AS DocDate 
	FROM (

		SELECT L.JobReceiveLineId, H.StockHeaderId, Bd.ProductId, NULL Dimension1Id, NULL Dimension2Id, @ProcessId AS ProcessId, Joh.CostCenterId,
		Round(Sum(CASE WHEN Pcl.ProductContentLineId IS NOT NULL THEN 
				Round((LagatWeight) + (L.LagatArea * IsNull(Jol.LossQty,0)) - 
				(L.LagatArea * Jol.NonCountedQty) -
				(L.LagatArea * IsNull(Vpc.NonContentQty,0)),3) * Bd.Qty/ TBD1.TotalBdQty
		ELSE 
			L.LagatArea * Bd.Qty END),3) AS Qty_Iss, 
		0 AS Qty_Rec,
		Max(L.CreatedBy) AS CreatedBy, Max(L.ModifiedBy) AS ModifiedBy, 
		Max(L.CreatedDate) AS CreatedDate, Max(L.ModifiedDate) AS ModifiedDate, Max(H.DocDate) AS DocDate
		FROM (
				SELECT Jrl.* , CASE WHEN isnull(isnull(QA.Weight,0),0) <> 0 THEN isnull(QA.Weight,0) ELSE  isnull(Jrl.Weight,0) END AS LagatWeight,
				QA.Length AS Length,QA.Width AS Width,QA.Height AS Height,
		        S.Length+S.LengthFraction*.1 AS OrderLength, S.Width+S.WidthFraction*.1 AS OrderWidth,		        
		        CASE WHEN JRL.DealUnitId = 'YD2' AND JOH.DocTypeId = 638 AND JOH.SiteId > 1 THEN 
		        web.FConvertSqFeetToSqYard((S.Length+S.LengthFraction/12) * (floor(QA.Width)+(QA.Width %1)*100/12))
		        --(web.FConvertSqFeetToSqYard( (S.Length + S.LengthFraction/12) *(CASE WHEN S.Width + S.WidthFraction*.1 > QA.Width THEN (floor(QA.Width) +(QA.Width %1)*10/12) ELSE (S.Width + S.WidthFraction/12) END )))
		         WHEN JRL.DealUnitId = 'MT2' THEN  
		         	 (QA.Length*QA.Width/10000*1.19599)
		         ELSE web.FConvertSqFeetToSqYard((floor(QA.Length)+(QA.Length %1)*100/12) * (floor(QA.Width)+(QA.Width %1)*100/12)) END AS LagatArea
		     	FROM Web.JobReceiveLines Jrl 
				LEFT JOIN Web.JobReturnLines Jrtl ON Jrl.JobReceiveLineId  = Jrtl.JobReceiveLineId
				LEFT JOIN Web.JobOrderLines Jol ON Jrl.JobOrderLineId = Jol.JobOrderLineId
				LEFT JOIN web.JobOrderHeaders JOH ON JOH.JobOrderHeaderId = JOL.JobOrderHeaderId 
				LEFT JOIN web.ViewProductSize VRS ON VRS.ProductId = Jol.ProductId 
				LEFT JOIN web.Sizes S ON S.SizeId = VRS.ManufaturingSizeID
				LEFT JOIN 
				(
					SELECT QAR.JobReceiveLineId,sum(QAR.PenaltyAmt) AS Penalty , sum(QAR.Weight) AS Weight, 
					Max(QD.Length) AS Length, Max(QD.Width) AS Width,Max(QD.Height) AS Height 
					FROM Web.JobReceiveQALines  QAR WITH (Nolock)
					LEFT JOIN WEB.JobReceiveQALineExtendeds QD ON QD.JobReceiveQALineId = QAR.JobReceiveQALineId 
				    GROUP BY QAR.JobReceiveLineId
				) QA ON QA.JobReceiveLineId=Jrl.JobReceiveLineId				
				WHERE Jrl.JobReceiveHeaderId = @JobReceiveHeaderId
				AND (Jrtl.JobReturnLineId IS NULL OR IsNull(Jrtl.Weight,0) > 0)
			 ) AS L 
		LEFT JOIN Web.JobReceiveHeaders H ON L.JobReceiveHeaderId = H.JobReceiveHeaderId
		LEFT JOIN Web.JobOrderLines Jol ON L.JobOrderLineId = Jol.JobOrderLineId
		LEFT JOIN Web.JobOrderHeaders Joh ON Jol.JobOrderHeaderId = Joh.JobOrderHeaderId
		LEFT JOIN Web.FinishedProduct Fp ON Jol.ProductId= Fp.ProductId
		LEFT JOIN Web.Products Prod ON Fp.ProductId= Prod.ProductId
		LEFT JOIN Web.ProductQualities Pq ON Fp.ProductQualityId = Pq.ProductQualityId
		LEFT JOIN Web.BomDetails B ON Jol.ProductId = B.BaseProductId
		LEFT JOIN Web.BomDetails Bd ON B.ProductId = Bd.BaseProductId AND Bd.BaseProcessId = JOH.ProcessId 
		LEFT JOIN Web.Products P ON Bd.ProductId = P.ProductId
		LEFT JOIN Web.ProductContentHeaders Pch ON Fp.FaceContentId = Pch.ProductContentHeaderId
		LEFT JOIN Web.ProductContentLines Pcl ON Pch.ProductContentHeaderId = Pcl.ProductContentHeaderId
			AND P.ProductGroupId = Pcl.ProductGroupId
		--LEFT JOIN Web.ViewProductGroupContents Vpc ON Prod.ProductGroupId = Vpc.ProductGroupId
		LEFT JOIN Web.ViewProductGroupContents Vpc ON Jol.ProductId = Vpc.ProductId
		LEFT JOIN 
		(
		SELECT BD1.BaseProductId,Pcl1.ProductContentHeaderId,  Sum(BD1.Qty) AS TotalBdQty  
		FROM WEb.BomDetails BD1 WITH (Nolock)
		LEFT JOIN Web.Products P1 ON Bd1.ProductId = P1.ProductId
		LEFT JOIN web.ProductGroups PG1 ON PG1.ProductGroupiD= P1.ProductGroupiD
		LEFT JOIN Web.ProductContentLines Pcl1 ON P1.ProductGroupId = Pcl1.ProductGroupId
		GROUP BY BD1.BaseProductId, Pcl1.ProductContentHeaderId  
		) TBD1 ON TBD1.BaseProductId = Bd.BaseProductId AND TBD1.ProductContentHeaderId =  Fp.FaceContentId	
		GROUP BY L.JobReceiveLineId,H.StockHeaderId, Bd.ProductId, Bd.Dimension1Id, Joh.CostCenterId, L.OMSId
		
	) AS VMain
	GROUP BY VMain.StockHeaderId, VMain.JobReceiveLineId, VMain.ProductId, VMain.CostCenterId
END
ELSE
BEGIN
	INSERT INTO Web.StockProcesses (StockHeaderId, ProductId, Dimension1Id, Dimension2Id, ProcessId, CostCenterId, 
	Qty_Iss, Qty_Rec, DocLineId,
	CreatedBy, ModifiedBy, CreatedDate, ModifiedDate, DocDate)
	
	
	
	---------------This Outer Query is implemented to equalize values of new and old tables.--------------
	---------------Qury Can be Remmove when Old Software will be closed.------------------
	SELECT StockHeaderId, ProductId, NULL AS Dimension1Id, NULL AS Dimension2Id, 
	Max(ProcessId) AS ProcessId, CostCenterId, 
	Round(Sum(Qty_Iss),3) AS Qty_Iss, Round(Sum(Qty_Rec),3) AS Qty_Rec, VMain.JobReceiveLineId AS DocLineId, Max(CreatedBy) AS CreatedBy, 
	Max(ModifiedBy) AS ModifiedBy, Max(CreatedDate) AS CreatedDate,getdate() AS ModifiedDate, 
	Max(DocDate) AS DocDate 
	FROM (

		SELECT L.JobReceiveLineId, H.StockHeaderId, Bd.ProductId, NULL Dimension1Id, NULL Dimension2Id, @ProcessId AS ProcessId, Joh.CostCenterId,
		Round(Sum
		(
		CASE WHEN Pcl.ProductContentLineId IS NOT NULL THEN 		
			 CASE 
					WHEN L.LagatWeight + (L.LagatArea * IsNull(Jol.LossQty,0)) - (L.LagatArea * Jol.NonCountedQty) >
						((L.LagatArea * Vpc.TotalBomQty))
						AND Jol.UnitConversionMultiplier > 4 THEN
							((L.LagatArea * Prod.GrossWeight)) * Bd.Qty / Vpc.ContentQty
					ELSE
					Round((L.LagatWeight) + (L.LagatArea * IsNull(Jol.LossQty,0)) - 
					(L.LagatArea * Jol.NonCountedQty) -
					(L.LagatArea * IsNull(Vpc.NonContentQty,0)),3) * Bd.Qty/ TBD1.TotalBdQty
			 END 
		ELSE 
			L.LagatArea * Bd.Qty 
		END
			
		),3) AS Qty_Iss, 
		0 AS Qty_Rec,
		Max(L.CreatedBy) AS CreatedBy, Max(L.ModifiedBy) AS ModifiedBy, 
		Max(L.CreatedDate) AS CreatedDate, Max(L.ModifiedDate) AS ModifiedDate, Max(H.DocDate) AS DocDate
		FROM (
				SELECT  Jrl.* , CASE WHEN isnull(isnull(QA.Weight,0),0) <> 0 THEN isnull(QA.Weight,0) ELSE  isnull(Jrl.Weight,0) END AS LagatWeight,
				QA.Length AS Length,QA.Width AS Width,QA.Height AS Height,
		        S.Length+S.LengthFraction*.1 AS OrderLength, S.Width+S.WidthFraction*.1 AS OrderWidth,		        
		        CASE WHEN JRL.DealUnitId = 'YD2' AND JOH.DocTypeId = 638 AND JOH.SiteId > 1 THEN 
		        web.FConvertSqFeetToSqYard((S.Length+S.LengthFraction/12) * (floor(QA.Width)+(QA.Width %1)*100/12))
		        --(web.FConvertSqFeetToSqYard( (S.Length + S.LengthFraction/12) *(CASE WHEN S.Width + S.WidthFraction*.1 > QA.Width THEN (floor(QA.Width) +(QA.Width %1)*10/12) ELSE (S.Width + S.WidthFraction/12) END )))
		         WHEN JRL.DealUnitId = 'MT2' THEN  
		         	  (QA.Length*QA.Width/10000)
		         ELSE web.FConvertSqFeetToSqYard((floor(QA.Length)+(QA.Length %1)*100/12) * (floor(QA.Width)+(QA.Width %1)*100/12)) END AS LagatArea
		     	FROM Web.JobReceiveLines Jrl 
				LEFT JOIN Web.JobReturnLines Jrtl ON Jrl.JobReceiveLineId  = Jrtl.JobReceiveLineId
				LEFT JOIN Web.JobOrderLines Jol ON Jrl.JobOrderLineId = Jol.JobOrderLineId
				LEFT JOIN web.JobOrderHeaders JOH ON JOH.JobOrderHeaderId = JOL.JobOrderHeaderId 
				LEFT JOIN web.ViewProductSize VRS ON VRS.ProductId = Jol.ProductId 
				LEFT JOIN web.Sizes S ON S.SizeId = VRS.ManufaturingSizeID
				LEFT JOIN 
				(
					SELECT QAR.JobReceiveLineId,sum(QAR.PenaltyAmt) AS Penalty , sum(QAR.Weight) AS Weight, 
					Max(QD.Length) AS Length, Max(QD.Width) AS Width,Max(QD.Height) AS Height 
					FROM Web.JobReceiveQALines  QAR WITH (Nolock)
					LEFT JOIN WEB.JobReceiveQALineExtendeds QD ON QD.JobReceiveQALineId = QAR.JobReceiveQALineId 
				    GROUP BY QAR.JobReceiveLineId
				) QA ON QA.JobReceiveLineId=Jrl.JobReceiveLineId				
				WHERE Jrl.JobReceiveHeaderId = @JobReceiveHeaderId
				AND (Jrtl.JobReturnLineId IS NULL OR IsNull(Jrtl.Weight,0) > 0)
			 ) AS L 
		LEFT JOIN Web.JobReceiveHeaders H ON L.JobReceiveHeaderId = H.JobReceiveHeaderId
		LEFT JOIN Web.JobOrderLines Jol ON L.JobOrderLineId = Jol.JobOrderLineId
		LEFT JOIN Web.JobOrderHeaders Joh ON Jol.JobOrderHeaderId = Joh.JobOrderHeaderId
		LEFT JOIN Web.FinishedProduct Fp ON Jol.ProductId= Fp.ProductId
		LEFT JOIN Web.Products Prod ON Fp.ProductId= Prod.ProductId
		LEFT JOIN Web.ProductQualities Pq ON Fp.ProductQualityId = Pq.ProductQualityId
		LEFT JOIN Web.BomDetails B ON Jol.ProductId = B.BaseProductId
		LEFT JOIN Web.BomDetails Bd ON B.ProductId = Bd.BaseProductId AND Bd.BaseProcessId = JOH.ProcessId 
		LEFT JOIN Web.Products P ON Bd.ProductId = P.ProductId
		LEFT JOIN Web.ProductContentHeaders Pch ON Fp.FaceContentId = Pch.ProductContentHeaderId
		LEFT JOIN Web.ProductContentLines Pcl ON Pch.ProductContentHeaderId = Pcl.ProductContentHeaderId
			AND P.ProductGroupId = Pcl.ProductGroupId
		--LEFT JOIN Web.ViewProductGroupContents Vpc ON Prod.ProductGroupId = Vpc.ProductGroupId
		LEFT JOIN Web.ViewProductGroupContents Vpc ON Jol.ProductId = Vpc.ProductId
		LEFT JOIN 
		(
		SELECT BD1.BaseProductId,Pcl1.ProductContentHeaderId,  Sum(BD1.Qty) AS TotalBdQty  
		FROM WEb.BomDetails BD1 WITH (Nolock)
		LEFT JOIN Web.Products P1 ON Bd1.ProductId = P1.ProductId
		LEFT JOIN web.ProductGroups PG1 ON PG1.ProductGroupiD= P1.ProductGroupiD
		LEFT JOIN Web.ProductContentLines Pcl1 ON P1.ProductGroupId = Pcl1.ProductGroupId
		GROUP BY BD1.BaseProductId, Pcl1.ProductContentHeaderId  
		) TBD1 ON TBD1.BaseProductId = Bd.BaseProductId AND TBD1.ProductContentHeaderId =  Fp.FaceContentId	
		GROUP BY L.JobReceiveLineId,H.StockHeaderId, Bd.ProductId, Bd.Dimension1Id, Joh.CostCenterId, L.OMSId
		
	) AS VMain
	GROUP BY VMain.StockHeaderId, VMain.JobReceiveLineId, VMain.ProductId, VMain.CostCenterId
END 




SET Context_Info 0x55555
INSERT INTO Web.JobReceiveBoms (JobReceiveHeaderId,JobReceiveLineId, ProductId, Dimension1Id, Dimension2Id, CostCenterId, 
Qty, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate)
SELECT H.JobReceiveHeaderId, L.JobReceiveLineId, Bd.ProductId, Bd.Dimension1Id Dimension1Id, NULL Dimension2Id, Joh.CostCenterId,
Round(Sum(CASE WHEN Pcl.ProductContentLineId IS NOT NULL THEN 
		Round((L.LagatWeight) + (L.Qty * Jol.UnitConversionMultiplier * IsNull(Jol.LossQty,0)) - 
		(L.LagatArea * Jol.NonCountedQty) -
		(L.LagatArea * IsNull(Vpc.NonContentQty,0)),3) * Bd.Qty/Vpc.ContentQty
ELSE 
	L.LagatArea * Bd.Qty END),3) AS Qty, 
Max(L.CreatedBy) AS CreatedBy, Max(L.ModifiedBy) AS ModifiedBy, 
Max(L.CreatedDate) AS CreatedDate, Max(L.ModifiedDate) AS ModifiedDate
		FROM (
				SELECT Jrl.* , CASE WHEN isnull(isnull(QA.Weight,0),0) <> 0 THEN isnull(QA.Weight,0) ELSE  isnull(Jrl.Weight,0) END AS LagatWeight,
				QA.Length AS Length,QA.Width AS Width,QA.Height AS Height,
		        S.Length+S.LengthFraction*.1 AS OrderLength, S.Width+S.WidthFraction*.1 AS OrderWidth,		        
		        CASE WHEN JRL.DealUnitId = 'YD2' AND JOH.DocTypeId = 638 AND JOH.SiteId > 1 THEN 
		        web.FConvertSqFeetToSqYard((S.Length+S.LengthFraction/12) * (floor(QA.Width)+(QA.Width %1)*100/12))
		        --(web.FConvertSqFeetToSqYard( (S.Length + S.LengthFraction/12) *(CASE WHEN S.Width + S.WidthFraction*.1 > QA.Width THEN (floor(QA.Width) +(QA.Width %1)*10/12) ELSE (S.Width + S.WidthFraction/12) END )))
		         WHEN JRL.DealUnitId = 'MT2' THEN  
		         	  (QA.Length*QA.Width/10000*1.19599)
		         ELSE web.FConvertSqFeetToSqYard((floor(QA.Length)+(QA.Length %1)*100/12) * (floor(QA.Width)+(QA.Width %1)*100/12)) END AS LagatArea
		     	FROM Web.JobReceiveLines Jrl 
				LEFT JOIN Web.JobReturnLines Jrtl ON Jrl.JobReceiveLineId  = Jrtl.JobReceiveLineId
				LEFT JOIN Web.JobOrderLines Jol ON Jrl.JobOrderLineId = Jol.JobOrderLineId
				LEFT JOIN web.JobOrderHeaders JOH ON JOH.JobOrderHeaderId = JOL.JobOrderHeaderId 
				LEFT JOIN web.ViewProductSize VRS ON VRS.ProductId = Jol.ProductId 
				LEFT JOIN web.Sizes S ON S.SizeId = VRS.ManufaturingSizeID
				LEFT JOIN 
				(
					SELECT QAR.JobReceiveLineId,sum(QAR.PenaltyAmt) AS Penalty , sum(QAR.Weight) AS Weight, 
					Max(QD.Length) AS Length, Max(QD.Width) AS Width,Max(QD.Height) AS Height 
					FROM Web.JobReceiveQALines  QAR WITH (Nolock)
					LEFT JOIN WEB.JobReceiveQALineExtendeds QD ON QD.JobReceiveQALineId = QAR.JobReceiveQALineId 
				    GROUP BY QAR.JobReceiveLineId
				) QA ON QA.JobReceiveLineId=Jrl.JobReceiveLineId				
				WHERE Jrl.JobReceiveHeaderId = @JobReceiveHeaderId
				AND (Jrtl.JobReturnLineId IS NULL OR IsNull(Jrtl.Weight,0) > 0)
			 ) AS L 
LEFT JOIN Web.JobReceiveHeaders H ON L.JobReceiveHeaderId = H.JobReceiveHeaderId
LEFT JOIN Web.JobOrderLines Jol ON L.JobOrderLineId = Jol.JobOrderLineId
LEFT JOIN Web.JobOrderHeaders Joh ON Jol.JobOrderHeaderId = Joh.JobOrderHeaderId
LEFT JOIN Web.FinishedProduct Fp ON Jol.ProductId= Fp.ProductId
LEFT JOIN Web.Products Prod ON Fp.ProductId= Prod.ProductId
LEFT JOIN Web.ProductQualities Pq ON Fp.ProductQualityId = Pq.ProductQualityId
LEFT JOIN Web.BomDetails B ON Jol.ProductId = B.BaseProductId
LEFT JOIN Web.BomDetails Bd ON B.ProductId = Bd.BaseProductId AND Bd.BaseProcessId = JOH.ProcessId 
LEFT JOIN Web.Products P ON Bd.ProductId = P.ProductId
LEFT JOIN Web.ProductContentHeaders Pch ON Fp.FaceContentId = Pch.ProductContentHeaderId
LEFT JOIN Web.ProductContentLines Pcl ON Pch.ProductContentHeaderId = Pcl.ProductContentHeaderId
	AND P.ProductGroupId = Pcl.ProductGroupId
LEFT JOIN Web.ViewProductGroupContents Vpc ON Jol.ProductId = Vpc.ProductId
GROUP BY H.JobReceiveHeaderId, L.JobReceiveLineId, Bd.ProductId, Bd.Dimension1Id, Joh.CostCenterId



UPDATE web.CostCenterStatusExtendeds  SET web.CostCenterStatusExtendeds.ConsumeQty = A.Qty
FROM 
(
SELECT SP.CostCenterId, sum(SP.Qty_Iss) Qty  
FROM ( SELECT * FROM Web.JobReceiveHeaders H WITH (Nolock) WHERE H.DocTypeId =448) H
LEFT JOIN Web.StockProcesses SP WITH (Nolock) ON SP.StockHeaderId = H.StockHeaderId 
WHERE SP.CostCenterId IS NOT NULL 
AND SP.CostcenterId IN 
(
	SELECT L.CostCenterId
	FROM (SELECT * FROM Web.JobReceiveHeaders WHERE JobReceiveHeaderId = @JobReceiveHeaderId) AS  H 
	LEFT JOIN Web.StockProcesses  L ON H.StockHeaderId = L.StockHeaderId
	GROUP BY L.CostCenterId
)
GROUP BY SP.CostCenterId 
) A
WHERE web.CostCenterStatusExtendeds.CostCenterId = A.CostCenterId

