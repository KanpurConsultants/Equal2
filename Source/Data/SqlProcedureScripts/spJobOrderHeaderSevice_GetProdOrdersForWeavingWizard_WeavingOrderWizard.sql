CREATE Procedure   [Web].[spJobOrderHeaderSevice_GetProdOrdersForWeavingWizard_WeavingOrderWizard]     
@SiteId VARCHAR(20) = NULL, 
@DivisionId VARCHAR(20) = NULL,
@DocumentTypeId VARCHAR(20) = NULL
AS  
Begin  
DECLARE @ContraSites VARCHAR(50)
DECLARE @ContraDivisions VARCHAR(50)
DECLARE @ContraDocTypes VARCHAR(50)
DECLARE @FilterProductTypes VARCHAR(50)
DECLARE @DealUnitId VARCHAR(50)


SELECT @ContraSites = Max(H.filterContraSites),
@ContraDivisions = Max(H.filterContraDivisions),
@ContraDocTypes = Max(H.filterContraDocTypes), 
@FilterProductTypes = Max(H.filterProductTypes),
@DealUnitId = Max(H.DealUnitId)
FROM Web.JobOrderSettings H  WITH (Nolock)
WHERE H.DocTypeId   = @DocumentTypeId 
AND (@SiteId IS NULL or H.SiteId  = @SiteId)
AND (@DivisionId IS NULL or H.DivisionId   = @DivisionId)



IF (@ContraSites IS NULL ) 
SET @ContraSites = @SiteId

IF (@ContraDivisions IS NULL ) 
SET @ContraDivisions = @DivisionId



SELECT --(SELECT SqYard FROM  Web.[FConvertSqFeetToSqYard] (VRS.ManufaturingSizeArea * H.BalanceQty) ) AS Area, 
CASE WHEN PC.ProductCategoryName ='Nepali' THEN  VRS.ManufaturingSizeArea*  (H.BalanceQty)
ELSE (SELECT Web.[FConvertSqFeetToSqYard] (VRS.ManufaturingSizeArea) )*  (H.BalanceQty) END AS Area , 
--CASE WHEN PC.ProductCategoryName ='Nepali' THEN 'MT2' ELSE  'YD2' END AS Unit,
IsNull((SELECT Web.[FConvertSqFeetToSqYard] (VRS.ManufaturingSizeArea) ),0) AS AreaPerPc,
H.BalanceQty AS MaxBalanceQty,
H.BalanceQty, H.BalanceQty AS Qty, H.BalanceQty AS OtherQty, POH.BuyerId, isnull(PB.Code,B.Code) AS BuyerName, PG.ProductGroupName AS DesignName,
convert(NVARCHAR,H.IndentDate,103) AS DATE , H.ProdOrderNo AS DocNo, convert(NVARCHAR,POH.DueDate,103) AS DueDate, PQ.ProductQualityName AS Quality , --VRS.ManufaturingSizeName AS Size, 
--CASE WHEN @DealUnitId= 'MT2' THEN VSC.SizeName ELSE VRS.ManufaturingSizeName END AS Size,
VRS.ManufaturingSizeName AS Size,
C.ColourName AS Colour,
H.ProdOrderLineId, H.ReferenceDocLineId AS RefDocLineId, H.ReferenceDocTypeId AS RefDocTypeId, PD.ProductDesignName AS DesignPatternName,
IsNull(RL.Rate,0) AS Rate, P.ProductCategoryId         
FROM Web.ViewProdOrderBalance H WITH (Nolock)
LEFT JOIN web.ViewProductSize VRS  WITH (Nolock) ON VRS.ProductId = H.ProductId 
LEFT JOIN web.ViewSizeinCms VSC WITH (Nolock) ON VSC.SizeId =VRS.ManufaturingSizeID
LEFT JOIN web.ProdOrderHeaders POH  WITH (Nolock) ON POH.ProdOrderHeaderId = H.ProdOrderHeaderId 
LEFT JOIN web.People PB  WITH (Nolock) ON PB.PersonID = POH.BuyerId 
LEFT JOIN web.Products P  WITH (Nolock) ON P.ProductId = H.ProductId 
LEFT JOIN web.ProductGroups PG  WITH (Nolock) ON PG.ProductGroupId = P.ProductGroupId 
LEFT JOIN web.FinishedProduct FP  WITH (Nolock) ON FP.ProductId = P.ProductId 
LEFT JOIN web.ProductQualities PQ  WITH (Nolock) ON PQ.ProductQualityId = FP.ProductQualityId 
LEFT JOIN web.ProductDesigns PD  WITH (Nolock) ON PD.ProductDesignId = FP.ProductDesignId 
LEFT JOIN Web.Colours C WITH (NoLock) ON Fp.ColourId = C.ColourId
LEFT JOIN web.JobOrderLines JOL ON JOL.JobOrderLineId = H.ReferenceDocLineId 
LEFT JOIN web.ProdOrderLines POL ON POL.ProdOrderLineId = JOL.ProdOrderLineId
LEFT JOIN web.ProdOrderHeaders POH1 ON POH1.ProdOrderHeaderId = POL.ProdOrderHeaderId 
LEFT JOIN web.People B ON B.PersonID = POH1.BuyerId 
LEFT JOIN web.ProductCategories PC WITH (Nolock) ON PC.ProductCategoryId = P.ProductCategoryId 
LEFT JOIN Web.RateListHeaders RLH ON RLH.ProcessId =43 AND RLH.DivisionId = H.DivisionId AND RLH.SiteId = H.SiteId 
LEFT JOIN web.RateListLines RL WITH (NoLock) ON P.ProductId = rl.ProductId  AND RLH.RateListHeaderId = RL.RateListHeaderId 
WHERE 1=1
AND (@ContraSites IS NULL or H.SiteId  IN (SELECT Items FROM web.Split(@ContraSites,',')))
AND (@ContraDivisions IS NULL or H.DivisionId  IN (SELECT Items FROM web.Split(@ContraDivisions,',')))
AND (@ContraDocTypes IS NULL or H.DocTypeId IN (SELECT Items FROM web.Split(@ContraDocTypes,',')))
AND (@FilterProductTypes IS NULL or PG.ProductTypeId  IN (SELECT Items FROM web.Split(@FilterProductTypes,',')))

END


