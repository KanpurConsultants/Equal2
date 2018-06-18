IF OBJECT_ID ('Web.spCarpetMaster_CreateTrace_GetFirstProductForColourWayAndSize') IS NOT NULL
	DROP PROCEDURE Web.spCarpetMaster_CreateTrace_GetFirstProductForColourWayAndSize
GO

CREATE Procedure Web.spCarpetMaster_CreateTrace_GetFirstProductForColourWayAndSize (@ProductDesignId INT, @StandardSizeID INT)
AS 

DECLARE @ProductGruopName NVARCHAR(200)
DECLARE @SizeName NVARCHAR(200)

SELECT @ProductGruopName = Replace(ProductGroupName,'-','')
FROM Web.ProductGroups
WHERE ProductGroupId  IN (
	SELECT Min(Pg.ProductGroupId)
	FROM Web.FinishedProduct F 
	LEFT JOIN Web.Products P ON F.ProductId = P.ProductId
	LEFT JOIN Web.ProductGroups Pg ON P.ProductGroupId = Pg.ProductGroupId
	WHERE F.ProductDesignId = @ProductDesignId
)

SELECT @SizeName = Replace(Replace(Replace(Replace(S.SizeName,'`',''),'"',''),'X',''),' ','')  + 
IsNull(Ps.ProductShapeShortName, '')
FROM Web.Sizes S
LEFT JOIN Web.ProductShapes Ps ON S.ProductShapeId = Ps.ProductShapeId
WHERE S.SizeId = @StandardSizeID



DECLARE @StencilSizeID INT

SELECT @StencilSizeID = StencilSizeID
FROM Web.ViewRugSize
WHERE ProductId IN
(
    SELECT Min(F.ProductId)
    FROM Web.FinishedProduct F
    LEFT JOIN Web.ViewRugSize Vrs ON F.ProductId = Vrs.ProductId
    WHERE F.ProductDesignId = @ProductDesignId AND Vrs.StandardSizeID = @StandardSizeID
)

SELECT @ProductGruopName +'-' + @SizeName AS ProductName, @StandardSizeID AS StandardSizeID, @StencilSizeID AS StencilSizeID 
GO



