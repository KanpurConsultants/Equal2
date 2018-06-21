CREATE PROCEDURE [Web].[spDocumentTypeService_FGetNewDocNo_GetNewDocNo]
    @FieldName VARCHAR(50), @TableName VARCHAR(50),@DocTypeId INT, @DocDate SMALLDATETIME, @DivisionId INT, @SiteId INT --,@NewDocNo nVarChar(50) OUTPUT
AS
BEGIN
	DECLARE @StartDate SMALLDATETIME
	DECLARE @EndDate SMALLDATETIME
	DECLARE @Ref_Prefix VARCHAR(10)
	DECLARE @Ref_PadLength INT 
	
	DECLARE @IsNumberingCategoryWise BIT 
	DECLARE @DocCategoryId INT 
	DECLARE @IsNumberingSiteWise BIT 
	DECLARE @IsNumberingDivisionWise BIT 
	
	SELECT @IsNumberingCategoryWise=IsNumberingDocCategoryWise, @IsNumberingSiteWise=IsNumberingSiteWise , @IsNumberingDivisionWise=IsNumberingDivisionWise  
	FROM web.DocumentTypeSettings WHERE DocumentTypeId = @DocTypeId
	
	SET @DocCategoryId =(SELECT DocumentCategoryId  FROM web.DocumentTypes WHERE DocumentTypeId = @DocTypeId) 
	
	
	SET @Ref_PadLength = 5
	IF (@DocDate >= '01/Apr/2018' AND @DocDate <= '31/Mar/2019 23:59:59' )
	BEGIN
		SET @StartDate = '01/Apr/2018'
		SET @EndDate = '31/Mar/2019 23:59:59'
		SET @Ref_Prefix = '18-'
   	END    	
	ELSE IF (@DocDate >= '01/Apr/2017' AND @DocDate <= '31/Mar/2018 23:59:59' )
	BEGIN
		SET @StartDate = '01/Apr/2017'
		--SET @EndDate = '31/Mar/2018 23:59:59'
		SET @EndDate = '31/Mar/2018'
		SET @Ref_Prefix = '17-'
   	END 
	ELSE IF (@DocDate >= '01/Apr/2016' AND @DocDate <= '31/Mar/2017 23:59:59' )
	BEGIN
		SET @StartDate = '01/Apr/2016'
		SET @EndDate = '31/Mar/2017 23:59:59'
		SET @Ref_Prefix = '16-'
   	END 
	ELSE IF (@DocDate >= '01/Apr/2015' AND @DocDate <= '31/Mar/2016 23:59:59' )
	BEGIN
		SET @StartDate = '01/Apr/2015'
		SET @EndDate = '31/Mar/2016 23:59:59'
		SET @Ref_Prefix = '15-'
   	END 
	ELSE IF (@DocDate >= '01/Apr/2014' AND @DocDate <= '31/Mar/2015' )
	BEGIN
		SET @StartDate = '01/Apr/2014'
		SET @EndDate = '31/Mar/2015'
		SET @Ref_Prefix = '14-'
   	END 
   	ELSE IF (@DocDate >= '01/Apr/2013' AND @DocDate <= '31/Mar/2014' )
	BEGIN
		SET @StartDate = '01/Apr/2013'
		SET @EndDate = '31/Mar/2014'
		SET @Ref_Prefix = '13-'
   	END  
   	ELSE IF (@DocDate >= '01/Apr/2012' AND @DocDate <= '31/Mar/2013' )
	BEGIN
		SET @StartDate = '01/Apr/2012'
		SET @EndDate = '31/Mar/2013'
		SET @Ref_Prefix = '12-'
   	END  
   	ELSE IF (@DocDate >= '01/Apr/2011' AND @DocDate <= '31/Mar/2012' )
	BEGIN
		SET @StartDate = '01/Apr/2011'
		SET @EndDate = '31/Mar/2012'
		SET @Ref_Prefix = '11-'
   	END  
   	ELSE IF (@DocDate >= '01/Apr/2010' AND @DocDate <= '31/Mar/2011' )
	BEGIN
		SET @StartDate = '01/Apr/2010'
		SET @EndDate = '31/Mar/2011'
		SET @Ref_Prefix = '10-'
   	END  
   	
	
    DECLARE @Sql VARCHAR(2000)
    
    IF @IsNumberingCategoryWise=1
   	BEGIN 
   		IF ( @IsNumberingSiteWise=0 AND @IsNumberingDivisionWise=0)
	   	BEGIN 
	    SET @sql = N' 
	    SELECT ''' + @Ref_Prefix +  ''' + 
	    RIGHT(''0000''+ Convert(nvarchar, IsNull(Max(Convert(Numeric,Replace(Replace(Replace(' + @FieldName +',''' + @Ref_Prefix +''',''''),''-'',''''),''.'',''''))),0) + 1) ,5) As NewDocNo
	    From ' + @TableName +' H With (NoLock) 
	    LEFT JOIN Web.DocumentTypes DT With (NoLock)  on DT.DocumentTypeId =H.DocTypeId
	    WHERE IsNumeric(Replace(Replace(Replace(' + @FieldName +',''-'',''''),''.'',''''),''' + @Ref_Prefix +''',''''))>0  
	    And DocumentCategoryId  = ' + Convert(nvarchar ,@DocCategoryId) +' 
	    And DocDate Between ''' + Convert(nvarchar ,@StartDate) +''' and  ''' + Convert(nvarchar ,@EndDate) +''' 
	    AND IsNumeric(' + @FieldName +') = 0'
	    END
	    ELSE 
	    BEGIN 
	    SET @sql = N' 
	    SELECT ''' + @Ref_Prefix +  ''' + 
	    RIGHT(''0000''+ Convert(nvarchar, IsNull(Max(Convert(Numeric,Replace(Replace(Replace(' + @FieldName +',''' + @Ref_Prefix +''',''''),''-'',''''),''.'',''''))),0) + 1) ,5) As NewDocNo
	    From ' + @TableName +' H With (NoLock) 
	    LEFT JOIN Web.DocumentTypes DT With (NoLock)  on DT.DocumentTypeId =H.DocTypeId
	    WHERE IsNumeric(Replace(Replace(Replace(' + @FieldName +',''-'',''''),''.'',''''),''' + @Ref_Prefix +''',''''))>0  
	    And DocumentCategoryId  = ' + Convert(nvarchar ,@DocCategoryId) +' And DivisionId = ' + Convert(nvarchar ,@DivisionId) +' 
	    And SiteId = ' + Convert(nvarchar ,@SiteId) +' 
	    And DocDate Between ''' + Convert(nvarchar ,@StartDate) +''' and  ''' + Convert(nvarchar ,@EndDate) +''' 
	    AND IsNumeric(' + @FieldName +') = 0'
	    END
	END 
	ELSE
	   BEGIN 
	    SET @sql = N' 
	    SELECT ''' + @Ref_Prefix +  ''' + 
	    RIGHT(''0000''+ Convert(nvarchar, IsNull(Max(Convert(Numeric,Replace(Replace(Replace(' + @FieldName +',''' + @Ref_Prefix +''',''''),''-'',''''),''.'',''''))),0) + 1) ,5) As NewDocNo
	    From ' + @TableName +' With (NoLock) 
	    WHERE IsNumeric(Replace(Replace(Replace(' + @FieldName +',''-'',''''),''.'',''''),''' + @Ref_Prefix +''',''''))>0  
	    And DocTypeId  = ' + Convert(nvarchar ,@DocTypeId) +' And DivisionId = ' + Convert(nvarchar ,@DivisionId) +' 
	    And SiteId = ' + Convert(nvarchar ,@SiteId) +' 
	    And DocDate Between ''' + Convert(nvarchar ,@StartDate) +''' and  ''' + Convert(nvarchar ,@EndDate) +''' 
	    AND IsNumeric(' + @FieldName +') = 0'
	END 

	Exec(@sql)
	PRINT @sql
	
	--SET @NewDocNo = @Ref_Prefix +  RIGHT('000'+ IsNull(@NewDocNo,''),4) 
	--Return @NewDocNo
	--PRINT @NewDocNo
END


