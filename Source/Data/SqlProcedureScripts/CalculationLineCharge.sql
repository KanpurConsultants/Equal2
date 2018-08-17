CREATE Procedure [Web].[CalculationLineCharge]
	@LineTableld VARCHAR(50),
	@LineTableName VARCHAR(50) 
AS 
BEGIN 

DECLARE @Qry VARCHAR(Max)
SET @Qry='

Select H.*, C.ChargeName, C.ChargeCode, COC.ChargeCode as CalculateOnCode, PC.ChargeCode  ParentChargeCode
From ' + @LineTableName + ' H With (NoLock)  
Left Join Web.Charges C With (NoLock) On H.ChargeId = C.ChargeId
Left Join Web.Charges COC With (NoLock) On H.CalculateOnId = COC.ChargeId
Left Join Web.Charges PC With (NoLock) On H.ParentChargeId = PC.ChargeId
Where H.LineTableId = ' + @LineTableld + '
ORDER BY H.Sr'
exec(@Qry)


End

