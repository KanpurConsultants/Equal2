Create Procedure  [Web].[spRep_TransactionCharges](@Id INT, @TableName NVARCHAR(255))
As
BEGIN

DECLARE @StrGrossAmount AS NVARCHAR(50)  
DECLARE @StrBasicExciseDuty AS NVARCHAR(50)  
DECLARE @StrExciseECess AS NVARCHAR(50)  
DECLARE @StrExciseHECess AS NVARCHAR(50)  

DECLARE @StrSalesTaxTaxableAmt AS NVARCHAR(50)  
DECLARE @StrVAT AS NVARCHAR(50)  
DECLARE @StrSAT AS NVARCHAR(50) 
DECLARE @StrCST AS NVARCHAR(50) 

SET @StrGrossAmount = 'Gross Amount'
SET @StrBasicExciseDuty = 'Basic Excise Duty'
SET @StrExciseECess ='Excise ECess'
SET @StrExciseHECess = 'Excise HECess'

SET @StrSalesTaxTaxableAmt = 'Sales Tax Taxable Amt'
SET @StrVAT = 'VAT'
SET @StrSAT = 'SAT'
SET @StrCST = 'CST'

DECLARE @Qry NVARCHAR(Max);
SET @Qry = '
		DECLARE @GrossAmount AS DECIMAL 
		DECLARE @BasicExciseDutyAmount AS DECIMAL 
		DECLARE @SalesTaxTaxableAmt AS DECIMAL 
		
		SELECT @GrossAmount = sum ( CASE WHEN C.ChargeName = ''' + @StrGrossAmount + ''' THEN  H.Amount  ELSE 0 END ) ,
		@BasicExciseDutyAmount = sum( CASE WHEN C.ChargeName = ''' + @StrBasicExciseDuty + ''' THEN  H.Amount  ELSE 0 END ) ,
		@SalesTaxTaxableAmt = sum( CASE WHEN C.ChargeName = ''' + @StrSalesTaxTaxableAmt + ''' THEN  H.Amount  ELSE 0 END )
		FROM ' + @TableName + ' H
		LEFT JOIN web.ChargeTypes CT ON CT.ChargeTypeId = H.ChargeTypeId 
		LEFT JOIN web.Charges C ON C.ChargeId = H.ChargeId 
		WHERE H.Amount <> 0 AND H.HeaderTableId	= ' + Convert(Varchar,@Id ) + '
		GROUP BY H.HeaderTableId
		
		
		SELECT H.Id, H.HeaderTableId, H.Sr, C.ChargeName, H.Amount, H.ChargeTypeId,  CT.ChargeTypeName, 
		--CASE WHEN C.ChargeName = ''Vat'' THEN ( H.Amount*100/ @GrossAmount ) ELSE H.Rate End  AS Rate,
		CASE 
		WHEN @SalesTaxTaxableAmt>0 And C.ChargeName IN ( ''' + @StrVAT + ''',''' + @StrSAT + ''',''' + @StrCST+ ''')  THEN ( H.Amount*100/ @SalesTaxTaxableAmt   ) 
		WHEN @GrossAmount>0 AND C.ChargeName IN ( ''' + @StrBasicExciseDuty + ''')  THEN ( H.Amount*100/ @GrossAmount   ) 
		WHEN  @BasicExciseDutyAmount>0 AND  C.ChargeName IN ( ''' + @StrExciseECess + ''', ''' +@StrExciseHECess+ ''')  THEN ( H.Amount*100/ @BasicExciseDutyAmount   ) 
		ELSE 0 End  AS Rate,
		''TransactionChargesPrint.rdl'' AS ReportName,
		''Transaction Charges'' AS ReportTitle     
		FROM  ' + @TableName + '  H
		LEFT JOIN web.ChargeTypes CT ON CT.ChargeTypeId = H.ChargeTypeId 
		LEFT JOIN web.Charges C ON C.ChargeId = H.ChargeId 
		WHERE  ( isnull(H.ChargeTypeId,0) <> ''4'' OR C.ChargeName = ''Net Amount'') AND H.Amount <> 0
		AND H.HeaderTableId	= ' + Convert(Varchar,@Id ) + ''
		
	--PRINT @Qry; 
		
	DECLARE @TmpData TABLE
	(
	id BIGINT,
	HeaderTableId INT,
	Sr INT,
	ChargeName NVARCHAR(50),
	Amount DECIMAL(18,4),
	ChargeTypeId INT,
	ChargeTypeName NVARCHAR(50),
	Rate DECIMAL(38,20),
	ReportName nVarchar(255),
	ReportTitle nVarchar(255)
	);
	
	
	Insert Into @TmpData EXEC(@Qry)
	SELECT id,HeaderTableId,Sr,ChargeName,Amount,ChargeTypeId,ChargeTypeName,Rate,ReportName FROM @TmpData
	ORDER BY Sr	
		
End

