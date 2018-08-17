CREATE Procedure Web.spPrroductService_GetUnitConversionMultiplier_GetUnitConversion (@FromQty DECIMAL(18,4), @FromUnitId NVARCHAR(3), @Length DECIMAL(18,4),
@Width DECIMAL(18,4), @Height DECIMAL(18,4), @ToUnitId NVARCHAR(3),@DocumentTypeId INT)
AS 
DECLARE @RoundDecimalPlace INT 
DECLARE @ToUnitValue DECIMAL(18,4)
DECLARE @SqlFeet DECIMAL(18,4);
DECLARE @LengthFeet INT 
DECLARE @LengthFractionFeet DECIMAL 
DECLARE @WidthFeet INT 
DECLARE @WidthFractionFeet DECIMAL
SET @ToUnitValue = 0
SET @RoundDecimalPlace = ( SELECT U.DecimalPlaces FROM Web.Units U WHERE U.UnitId =@ToUnitId)
SELECT @LengthFeet = floor(@Length)
SELECT @LengthFractionFeet = (@Length - floor(@Length)) * 100
SELECT @WidthFeet = floor(@Width)
SELECT @WidthFractionFeet = (@Width - floor(@Width)) * 100

SET @Length = Round(@LengthFeet + (@LengthFractionFeet/12),3)
SET @Width = Round(@WidthFeet + (@WidthFractionFeet/12),3)

IF (@FromUnitId = 'PCS' AND @ToUnitId = 'YD2')
BEGIN
	SET @SqlFeet = @Length * @Width
	SET @ToUnitValue = (SELECT Web.FConvertSqFeetToSqYard(@SqlFeet))
END
ELSE IF (@FromUnitId = 'PCS' AND @ToUnitId = 'FT2')
BEGIN
	SELECT @ToUnitValue = @Length * @Width
END 
ELSE IF (@FromUnitId = 'PCS' AND @ToUnitId = 'MT2')
BEGIN
	SET @ToUnitValue = Round((@Length * @Width)/10000,2,1) 
END 
SELECT @ToUnitValue AS ConvertedValue


