CREATE PROCEDURE [Web].[FGetDocNo](@DocDate DATE, @DocTypeId INT, @SiteId INT, @DivisionId INT, @TableName NVARCHAR(255), @DocNo NVARCHAR (20) OUTPUT )
AS 
BEGIN


--DECLARE @DocNo AS NVARCHAR(50)  
DECLARE @Prefix NVARCHAR (10)

--SET @Prefix = ( SELECT substring(convert(NVARCHAR, @DocDate,104),9,2))

	IF (@DocDate >= '01/Apr/2018' AND @DocDate <= '31/Mar/2019' )
	BEGIN
		SET @Prefix = '18'
   	END 
   	ELSE IF (@DocDate >= '01/Apr/2017' AND @DocDate <= '31/Mar/2018' )
	BEGIN
		SET @Prefix = '17'
   	END 
	ELSE IF (@DocDate >= '01/Apr/2016' AND @DocDate <= '31/Mar/2017' )
	BEGIN
		SET @Prefix = '16'
   	END 
	ELSE IF (@DocDate >= '01/Apr/2015' AND @DocDate <= '31/Mar/2016' )
	BEGIN
		SET @Prefix = '15'
   	END 
	ELSE IF (@DocDate >= '01/Apr/2014' AND @DocDate <= '31/Mar/2015' )
	BEGIN
		SET @Prefix = '14'
   	END 
   	ELSE IF (@DocDate >= '01/Apr/2013' AND @DocDate <= '31/Mar/2014' )
	BEGIN
		SET @Prefix = '13'
   	END  
   	ELSE IF (@DocDate >= '01/Apr/2012' AND @DocDate <= '31/Mar/2013' )
	BEGIN
		SET @Prefix = '12'
   	END  
   	ELSE IF (@DocDate >= '01/Apr/2011' AND @DocDate <= '31/Mar/2012' )
	BEGIN
		SET @Prefix = '11'
   	END  
   	ELSE IF (@DocDate >= '01/Apr/2010' AND @DocDate <= '31/Mar/2011' )
	BEGIN
		SET @Prefix = '10'
   	END  
   	

DECLARE @Qry NVARCHAR(Max);
SET @Qry = '		
		SELECT  H.DocNo
		FROM ' + @TableName + ' H
		WHERE H.DocTypeId	= ' + Convert(Varchar,@DocTypeId ) + '
		AND H.SiteId = ' + Convert(Varchar,@SiteId ) + '
		AND H.DivisionId = ' + Convert(Varchar,@DivisionId ) + '	

'


		
   --PRINT @Qry; 
		
	DECLARE @TmpData TABLE
	(
	DocNo NVARCHAR(50)
	);
	
	
	DECLARE @DocNoInt AS INT 
	
	Insert Into @TmpData EXEC(@Qry)
	
	

	SELECT @DocNoInt = Max( convert(INT,isnull(substring(DocNo,5,10),0) ))
	FROM @TmpData
	WHERE DocNo LIKE @Prefix + '-%'
	
	
	IF (SELECT len(Convert(NVARCHAR,@DocNoInt))) > 5
	BEGIN
		SELECT @DocNo = @Prefix + '-' + Replace(str(isnull(@DocNoInt,0) + 1 ,len(Convert(NVARCHAR,@DocNoInt))),' ','0')
	END
	ELSE
	BEGIN
		SELECT @DocNo = @Prefix + '-' + Replace(str(isnull(@DocNoInt,0) + 1 ,5),' ','0')
	END



END;

