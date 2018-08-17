CREATE Procedure [Web].[procGetCalculationMaxLineId]
	@HeaderTableKeyValue VARCHAR(50),	
	@LineTableName VARCHAR(50),
	@HeaderFieldName VARCHAR(50), 
	@LineTableKeyField VARCHAR(50)
AS 
BEGIN 

DECLARE @Qry VARCHAR(Max)
SET @Qry='

Select IsNull(Max(' + @LineTableKeyField +'),0) As MaxId 
From ' + @LineTableName + ' With (NoLock)  
Where ' + @HeaderFieldName + ' = '+ @HeaderTableKeyValue  +'
'
exec(@Qry)


End

