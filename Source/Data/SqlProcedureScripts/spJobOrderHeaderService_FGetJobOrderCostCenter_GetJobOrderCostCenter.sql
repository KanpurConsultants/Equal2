Create Procedure [Web].[spJobOrderHeaderService_FGetJobOrderCostCenter_GetJobOrderCostCenter]
    @DocTypeId INT, @DocDate SMALLDATETIME, @DivisionId INT, @SiteId INT 
AS
BEGIN
	DECLARE @StartDate SMALLDATETIME
	DECLARE @EndDate SMALLDATETIME
	DECLARE @Ref_Prefix VARCHAR(10)
	DECLARE @Ref_PadLength INT 
	
	DECLARE @IsNumberingCategoryWise BIT 
	DECLARE @DocCategoryId INT 
	
	SET @IsNumberingCategoryWise =(SELECT IsNumberingDocCategoryWise  FROM web.DocumentTypeSettings WHERE DocumentTypeId = @DocTypeId) 
	SET @DocCategoryId =(SELECT DocumentCategoryId  FROM web.DocumentTypes WHERE DocumentTypeId = @DocTypeId) 
	
	SET @Ref_PadLength = 5
	
	IF (@DocDate >= '01/Apr/2018' AND @DocDate <= '31/Mar/2019 23:59:59' )
	BEGIN
		SET @StartDate = '01/Apr/2018'
		SET @EndDate = '31/Mar/2019 23:59:59'
		SET @Ref_Prefix = '18-'
   	END    	
	ELSE IF (@DocDate >= '01/Apr/2017' AND @DocDate <= '31/Mar/2018' )
	BEGIN
		SET @StartDate = '01/Apr/2017'
		SET @EndDate = '31/Mar/2018'
		SET @Ref_Prefix = '17-'
   	END 
	ELSE IF (@DocDate >= '01/Apr/2016' AND @DocDate <= '31/Mar/2017' )
	BEGIN
		SET @StartDate = '01/Apr/2016'
		SET @EndDate = '31/Mar/2017'
		SET @Ref_Prefix = '16-'
   	END 
	ELSE IF (@DocDate >= '01/Apr/2015' AND @DocDate <= '31/Mar/2016' )
	BEGIN
		SET @StartDate = '01/Apr/2015'
		SET @EndDate = '31/Mar/2016'
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
   	

	
	IF @IsNumberingCategoryWise=1
   	BEGIN     
    SELECT @Ref_Prefix + 
	RIGHT('0000'+ Convert(NVARCHAR , IsNull(Max(Convert(Numeric,Replace(Replace(Replace(C.CostCenterName,@Ref_Prefix,''),'-',''),'.',''))),0) + 1) ,5) As NewDocNo
	FROM Web.JobOrderHeaders H WITH (Nolock)
	LEFT JOIN Web.CostCenters C WITH (Nolock) ON H.CostCenterId = C.CostCenterId
	LEFT JOIN Web.DocumentTypes DT With (NoLock)  on DT.DocumentTypeId =H.DocTypeId
	WHERE DT.DocumentCategoryId = @DocCategoryId
	AND H.DivisionId = @DivisionId
	AND H.SiteId = @SiteId
	AND H.DocDate BETWEEN @StartDate AND @EndDate
	AND IsNumeric(Replace(Replace(Replace(C.CostCenterName,@Ref_Prefix,''),'-',''),'.','')) > 0
	
	END 
	ELSE 
	BEGIN
	SELECT @Ref_Prefix + 
	RIGHT('0000'+ Convert(NVARCHAR , IsNull(Max(Convert(Numeric,Replace(Replace(Replace(C.CostCenterName,@Ref_Prefix,''),'-',''),'.',''))),0) + 1) ,5) As NewDocNo
		FROM Web.JobOrderHeaders H WITH (Nolock)
	LEFT JOIN Web.CostCenters C WITH (Nolock) ON H.CostCenterId = C.CostCenterId
	WHERE H.DocTypeId = @DocTypeId
	AND H.DivisionId = @DivisionId
	AND H.SiteId = @SiteId
	AND H.DocDate BETWEEN @StartDate AND @EndDate
	AND IsNumeric(Replace(Replace(Replace(C.CostCenterName,@Ref_Prefix,''),'-',''),'.','')) > 0
	END 
	
END


