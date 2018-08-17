CREATE Procedure [Web].[CalculationHeaderCharge]
	@HeaderTableld VARCHAR(50),
	@HeaderTableName VARCHAR(50), 
	@LineTableName VARCHAR(50) 
AS 
BEGIN 

DECLARE @Qry VARCHAR(Max)
SET @Qry='

Select  H.*, C.ChargeName,CASE WHEN H.AddDeduct = 1 THEN ''Add'' WHEN H.AddDeduct = 0 THEN  ''Deduct'' ELSE '''' END AddDeductName, C.ChargeCode, COC.ChargeCode as CalculateOnCode,COC.ChargeName as CalculateOnName, PC.ChargeCode  ParentChargeCode, ProdC.ChargeCode ProductChargeCode
From ' + @HeaderTableName + ' H With (NoLock)  
Left Join Web.Charges C With (NoLock) On H.ChargeId = C.ChargeId
Left Join Web.Charges COC With (NoLock) On H.CalculateOnId = COC.ChargeId
Left Join Web.Charges PC With (NoLock) On H.ParentChargeId = PC.ChargeId
Left Join Web.Charges ProdC With (NoLock) On ProductChargeId = ProdC.ChargeId
Where H.HeaderTableId = ' + @HeaderTableld + '
Order By H.Sr
'
exec(@Qry)


End


