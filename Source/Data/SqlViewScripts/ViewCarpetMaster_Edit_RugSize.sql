IF OBJECT_ID ('Web.ViewCarpetMaster_Edit_RugSize') IS NOT NULL
	DROP VIEW [Web].[ViewCarpetMaster_Edit_RugSize]
GO

CREATE VIEW [Web].[ViewCarpetMaster_Edit_RugSize]
AS
SELECT P.ProductId, SS.SizeId AS StandardSizeID, SS.SizeName + IsNull(SSS.ProductShapeShortName,'') AS StandardSizeName, SS.Area AS StandardSizeArea,  
SM.SizeId AS ManufaturingSizeID, SM.SizeName + IsNull(SSS.ProductShapeShortName,'') AS ManufaturingSizeName, SM.Area AS ManufaturingSizeArea,
SF.SizeId AS FinishingSizeID,SF.SizeName + IsNull(SSS.ProductShapeShortName,'') AS FinishingSizeName, SF.Area AS FinishingSizeArea   ,
ST.SizeId AS StencilSizeID,ST.SizeName + IsNull(SSS.ProductShapeShortName,'') AS StencilSizeName, ST.Area AS StencilSizeArea  ,
SP.SizeId AS MapSizeID,SP.SizeName + IsNull(SSS.ProductShapeShortName,'') AS MapSizeName, SP.Area AS MapSizeArea
FROM Web.Products P
LEFT JOIN(
    SELECT PSS.ProductId, PSS.SizeId
    FROM Web.ProductSizes PSS
    WHERE PSS.ProductSizeTypeId = (SELECT ProductsizetypeID FROM Web.ProductSizeTypes WHERE ProductsizetypeName = 'Standard')
) AS PSS ON P.ProductId = PSS.ProductId
LEFT JOIN (     
    SELECT PSM.ProductId, PSM.SizeId
    FROM Web.ProductSizes PSM
    WHERE PSM.ProductSizeTypeId = (SELECT ProductsizetypeID FROM Web.ProductSizeTypes WHERE ProductsizetypeName = 'Manufaturing Size')
) AS PSM ON P.ProductId = PSM.ProductId
LEFT JOIN (     
    SELECT PSF.ProductId, PSF.SizeId
    FROM Web.ProductSizes PSF
    WHERE PSF.ProductSizeTypeId = (SELECT ProductsizetypeID FROM Web.ProductSizeTypes WHERE ProductsizetypeName = 'Finishing Size')
) AS PSF ON P.ProductId = PSF.ProductId
LEFT JOIN (     
    SELECT PSF.ProductId, PSF.SizeId
    FROM Web.ProductSizes PSF
    WHERE PSF.ProductSizeTypeId = (SELECT ProductsizetypeID FROM Web.ProductSizeTypes WHERE ProductsizetypeName = 'Stencil')
) AS PST ON P.ProductId = PST.ProductId
LEFT JOIN (     
    SELECT PSF.ProductId, PSF.SizeId
    FROM Web.ProductSizes PSF
    WHERE PSF.ProductSizeTypeId = (SELECT ProductsizetypeID FROM Web.ProductSizeTypes WHERE ProductsizetypeName = 'Map')
) AS PSP ON P.ProductId = PSP.ProductId
LEFT JOIN Web.Sizes SS ON SS.SizeId = PSS.SizeId
LEFT JOIN Web.ProductShapes SSS ON SS.ProductShapeId = SSS.ProductShapeId
LEFT JOIN Web.Sizes SM ON SM.SizeId = PSM.SizeId
LEFT JOIN Web.ProductShapes SSM ON SM.ProductShapeId = SSM.ProductShapeId
LEFT JOIN Web.Sizes SF ON SF.SizeId = PSF.SizeId
LEFT JOIN Web.ProductShapes SSF ON SF.ProductShapeId = SSF.ProductShapeId
LEFT JOIN Web.Sizes ST ON ST.SizeId = PST.SizeId
LEFT JOIN Web.ProductShapes SST ON ST.ProductShapeId = SST.ProductShapeId
LEFT JOIN Web.Sizes SP ON SP.SizeId = PSP.SizeId
LEFT JOIN Web.ProductShapes SSP ON SP.ProductShapeId = SSP.ProductShapeId
GO


