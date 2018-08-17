CREATE FUNCTION [Web].[FGetSqFeetFromCMSizes](@SizeId DECIMAL(18,4))  
RETURNS @Results TABLE (SqFeet DECIMAL(18,4))  AS  
BEGIN  
DECLARE @SqFeets Decimal(18,4)
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

SELECT @SqFeets=round((@SLF+@SLI/12)*(@SWF+@SWI/12),3)

INSERT INTO @Results(SqFeet) VALUES(@SqFeets) 

RETURN  END


