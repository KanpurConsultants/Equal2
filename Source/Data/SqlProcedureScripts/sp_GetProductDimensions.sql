CREATE PROCEDURE Web.sp_GetProductDimensions (@ProductId INT, @DealUnitId VARCHAR(3), @DocTypeId INT)
AS 
DECLARE @SizeId INT 
DECLARE @DimensionUnitId NVARCHAR(3)
DECLARE @DimensionUnitDecimalPlances INT
DECLARE @DocTypeName NVARCHAR(50)
DECLARE @UnitId NVARCHAR(50)


SELECT @DocTypeName = DocumentTypeName FROM Web.DocumentTypes WHERE DocumentTypeId = @DocTypeId

SELECT @DimensionUnitId = Du.UnitId, @DimensionUnitDecimalPlances = Du.DecimalPlaces
FROM Web.Units U 
LEFT JOIN Web.Units Du ON U.DimensionUnitId = Du.UnitId
WHERE U.UnitId = @DealUnitId


IF (@DocTypeName = 'Packing Receive')
BEGIN

	SELECT @SizeId = H.StandardSizeID, @UnitId=S.UnitId    FROM Web.ViewProductSize H
	LEFT JOIN web.Sizes S ON S.SizeId=H.StandardSizeID 
	WHERE H.ProductId = @ProductId
END
ELSE
BEGIN 
	SELECT @SizeId = H.ManufaturingSizeID, @UnitId=S.UnitId    FROM Web.ViewProductSize H
	LEFT JOIN web.Sizes S ON S.SizeId=H.ManufaturingSizeID 
	WHERE H.ProductId = @ProductId
END


IF (@DimensionUnitId = 'CMS')
BEGIN
 IF (@UnitId = 'MET')
 BEGIN
	SELECT Convert(DECIMAL,IsNull(S.Length,0))*100+ Convert(DECIMAL,IsNull(S.LengthFraction,0)) AS Length,
	Convert(DECIMAL,IsNull(S.Width ,0))*100+ Convert(DECIMAL,IsNull(S.WidthFraction,0))  AS Width,
	convert(DECIMAL,0) AS Height,
	@DimensionUnitDecimalPlances AS DimensionUnitDecimalPlaces
	FROM Web.Sizes S 
	WHERE S.SizeId = @SizeId
 END 
 ELSE
  BEGIN
	SELECT Convert(DECIMAL,IsNull(Lfc.Cms,0)) AS Length,
	Convert(DECIMAL,IsNull(Wfc.Cms,0)) AS Width,
	Convert(DECIMAL,IsNull(Hfc.Cms,0)) AS Height,
	@DimensionUnitDecimalPlances AS DimensionUnitDecimalPlaces
	FROM Web.Sizes S 
	LEFT JOIN Web.FeetConversionToCms LFc ON S.Length = Lfc.Feet AND S.LengthFraction = Lfc.Inch
	LEFT JOIN Web.FeetConversionToCms WFc ON S.Width = WFc.Feet AND S.WidthFraction = WFc.Inch
	LEFT JOIN Web.FeetConversionToCms HFc ON S.Height = HFc.Feet AND S.HeightFraction = HFc.Inch
	WHERE S.SizeId = @SizeId
 END 
 
END
ELSE
 BEGIN
 IF (@UnitId = 'MET')
 BEGIN

	
DECLARE @SCL DECIMAL(18,5) 
DECLARE @SCW DECIMAL(18,5) 

DECLARE @SLF DECIMAL(18,5) 
DECLARE @SLI DECIMAL(18,5) 
DECLARE @SWF DECIMAL(18,5) 
DECLARE @SWI DECIMAL(18,5) 

SELECT @SCL=0.393701*(convert(DECIMAL(18,5),S.Length)*100+ convert(DECIMAL(18,5),S.LengthFraction)),  @SCW=0.393701*(convert(DECIMAL(18,5),S.Width)*100+ convert(DECIMAL(18,5),S.WidthFraction)) 
FROM Web.Sizes S WITH (Nolock)
WHERE S.SizeId =@SizeId


SET @SLF=round(convert(INT,@SCL)/12,0)
SET @SWF=round(convert(INT,@SCW)/12,0)
SET @SLI=round(@SCL%12,0)
SET @SWI=round(@SCW%12,0)

SELECT @SLF + @SLI/100 AS Length,
	@SWF + @SWI/100 AS Width,
	convert(DECIMAL,0) AS Height,
	@DimensionUnitDecimalPlances AS DimensionUnitDecimalPlaces
	
 END 
 ELSE
BEGIN
	SELECT S.Length + S.LengthFraction/100 AS Length,
	S.Width + S.WidthFraction/100 AS Width,
	S.Height + S.HeightFraction/100 AS Height,
	@DimensionUnitDecimalPlances AS DimensionUnitDecimalPlaces
	FROM Web.Sizes S 
	WHERE S.SizeId = @SizeId
END
END


