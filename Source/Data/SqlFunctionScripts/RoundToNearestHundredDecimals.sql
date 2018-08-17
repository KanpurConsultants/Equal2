CREATE FUNCTION Web.RoundToNearestHundredDecimals
(@Value DECIMAL(18,4))
RETURNS DECIMAL(18,4)
AS 
BEGIN
	DECLARE @RetValue DECIMAL(18,4);
	SELECT @RetValue = Round(@Value,0) + (ceiling(((@Value - Round(@Value,0)) * 1000)/100) * 100) / 1000
	RETURN @RetValue;
END;