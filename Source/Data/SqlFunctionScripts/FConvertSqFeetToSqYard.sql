CREATE FUNCTION [Web].[FConvertSqFeetToSqYard](@SqFeets DECIMAL(18,4))  
RETURNS DECIMAL (18,4)  
AS  
BEGIN  DECLARE @MyInt INT   
DECLARE @MyFrcation Decimal(18,4)  DECLARE @TempSqYard Decimal(18,4) 
SET @TempSqYard = @SqFeets * 0.111111111  SET @MyInt = Convert(INT,@TempSqYard)  SET @MyFrcation = @TempSqYard - @MyInt  If (@MyFrcation * 16) > 1      begin      SET @MyFrcation = @MyFrcation * 16     SET @MyFrcation = convert(INT,@MyFrcation)     SET @MyFrcation = @MyFrcation / 16     end  Else IF @MyInt > 0       BEGIN        SET @MyFrcation = 0      END   SET @SqFeets = @MyInt + @MyFrcation  
RETURN @SqFeets END