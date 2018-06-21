CREATE PROCEDURE [Web].[spUnitConversionFor_GetUnitConversion_GetUnitConversionForSize] (@SizeId INT, @ToUnitId NVARCHAR(3), @Attribute NVARCHAR(20) = NULL)
AS 

DECLARE @ToQty DECIMAL(18,4) = 0
DECLARE @ProductShape NVARCHAR(10)

SELECT @ProductShape = Ps.ProductShapeName 
FROM Web.Sizes S
LEFT JOIN Web.ProductShapes Ps ON S.ProductShapeId = Ps.ProductShapeId
WHERE SizeId = @SizeId


IF (@ToUnitId = 'MT2')
BEGIN
	DECLARE @LengthCms DECIMAL(18,4) = 0
	DECLARE @WidthCms DECIMAL(18,4) = 0
	
	SELECT @LengthCms = IsNull(F.Cms,0)
	FROM Web.Sizes S
	LEFT JOIN Web.FeetConversionToCms F ON S.Length = F.Feet AND S.LengthFraction = F.Inch
	WHERE SizeId = @SizeId
	AND F.FeetConversionToCmsId IS NOT NULL
	
	SELECT @WidthCms = IsNull(F.Cms,0)
	FROM Web.Sizes S
	LEFT JOIN Web.FeetConversionToCms F ON S.Width = F.Feet AND S.WidthFraction = F.Inch
	WHERE SizeId = @SizeId
	AND F.FeetConversionToCmsId IS NOT NULL
	
	
	SET @ToQty =(@LengthCms * @WidthCms)/10000
END

IF (@ToUnitId = 'FT')
BEGIN
	IF (@ProductShape = 'Rectangle')
	BEGIN
		IF (@Attribute = 'Length')
		BEGIN
			SELECT @ToQty = Round((S.Length + (S.LengthFraction / 12)) * 2,3)
			FROM Web.Sizes S
			WHERE SizeId = @SizeId
		END 
		
		IF (@Attribute = 'Width')
		BEGIN
			SELECT @ToQty = Round((S.Width + (S.WidthFraction / 12)) * 2,3)
			FROM Web.Sizes S
			WHERE SizeId = @SizeId
		END 
		
		IF (@Attribute = 'Length + Width')
		BEGIN
			SELECT @ToQty = Round(((S.Length + (S.LengthFraction / 12)) * 2) + ((S.Width + (S.WidthFraction / 12)) * 2),3)
			FROM Web.Sizes S
			WHERE SizeId = @SizeId
		END 
	END
	ELSE
	BEGIN
		SELECT @ToQty = Floor((S.Length + (S.LengthFraction / 12)) * 3.14)
		FROM Web.Sizes S
		WHERE SizeId = @SizeId
	END 
END 

SELECT @ToQty AS ToQty;

