CREATE FUNCTION [Web].FGetSizeinFeet (@SizeinMeter NVARCHAR(100) )
Returns NVARCHAR(100) AS
BEGIN 

DECLARE @SizeinFeet NVARCHAR(100)

DECLARE @SCL DECIMAL(18,5) 
DECLARE @SCW DECIMAL(18,5) 

DECLARE @SLF DECIMAL(18,5) 
DECLARE @SLI DECIMAL(18,5) 
DECLARE @SWF DECIMAL(18,5) 
DECLARE @SWI DECIMAL(18,5) 

/*
SET @SizeinMeter='200X300'
SELECT charindex('X',@SizeinMeter), @SizeinMeter, LEFT(@SizeinMeter,charindex('X',@SizeinMeter)-1),
RIGHT (@SizeinMeter,len(@SizeinMeter)- charindex('X',@SizeinMeter)),
0.393701*convert(DECIMAL(18,5),LEFT(@SizeinMeter,charindex('X',@SizeinMeter)-1)),
0.393701*convert(DECIMAL(18,5),RIGHT (@SizeinMeter,len(@SizeinMeter)- charindex('X',@SizeinMeter)))
*/

SELECT @SCL=0.393701*convert(DECIMAL(18,5),LEFT(@SizeinMeter,charindex('X',@SizeinMeter)-1)),
@SCW=0.393701*convert(DECIMAL(18,5),RIGHT (@SizeinMeter,len(@SizeinMeter)- charindex('X',@SizeinMeter)))


SET @SLF=round(convert(INT,@SCL)/12,0)
SET @SWF=round(convert(INT,@SCW)/12,0)
SET @SLI=round(@SCL%12,0)
SET @SWI=round(@SCW%12,0)


SET @SizeinFeet =convert(NVARCHAR,@SLF)+'`'+convert(NVARCHAR,@SLI)+'"X'+convert(NVARCHAR,@SWF)+'`'+convert(NVARCHAR,@SWI)+'"'
SET @SizeinFeet=replace(@SizeinFeet,'.00000','')
RETURN @SizeinFeet;
END


