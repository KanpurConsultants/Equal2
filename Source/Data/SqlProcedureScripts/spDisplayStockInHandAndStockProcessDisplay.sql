CREATE PROCEDURE Web.spDisplayStockInHandAndStockProcessDisplay
    @ProductType VARCHAR(Max) =NULL,
	@Site VARCHAR(20) = NULL,
	@FromDate NVARCHAR(20) =NULL,
	@ToDate NVARCHAR(20) =NULL,
	@GroupOn VARCHAR(Max) =NULL,
	@ShowBalance VARCHAR(Max) = NULL,
	@Product VARCHAR(Max) = NULL,
	@Godown VARCHAR(Max) = NULL,
	@Process VARCHAR(Max) = NULL,
	@Dimension1 VARCHAR(Max) = NULL,
	@Dimension2 VARCHAR(Max) = NULL,
	@ProductNature VARCHAR(Max) = NULL,  
	@ProductGroup VARCHAR(Max) = NULL,
	@ProductCustomGroup VARCHAR(Max) = NULL,
	/*@ProductDivisionId VARCHAR(Max)=NULL,
	@PersonId VARCHAR(Max)=NULL,
	@DyedUndyedStock VARCHAR(Max)=NULL,*/
	@Dimension3 VARCHAR(Max) = NULL,
	@Dimension4 VARCHAR(Max) = NULL,
	@ShowOpening VARCHAR(10)=NULL,
	@TableName NVARCHAR(Max)=NULL
	AS 
	BEGIN 
	SET @TableName=(CASE WHEN @TableName='Stock' THEN 'web.Stocks' ELSE 'Web.StockProcesses' END )
	DECLARE @ProductDivisionId VARCHAR(Max)=NULL
	DECLARE  @PersonId VARCHAR(Max)=NULL
	DECLARE @DyedUndyedStock VARCHAR(max)=NULL
SET @DyedUndyedStock=CASE WHEN @DyedUndyedStock IS NULL THEN '1' ELSE @DyedUndyedStock END
DECLARE @ParameterDefinition NVARCHAR(4000);
SELECT	@ParameterDefinition = '   
	@ProductTypePerameter VARCHAR(Max),
	@SitePerameter VARCHAR(20),
    @FromDatePerameter VARCHAR(20),
    @ToDatePerameter VARCHAR(20),
    @GroupOnPerameter VARCHAR(Max),
	@ShowBalancePerameter VARCHAR(Max),
@ProductPerameter VARCHAR(Max),
@GodownPerameter VARCHAR(Max),
@ProcessPerameter VARCHAR(Max),
@Dimension1Perameter VARCHAR(Max),
@Dimension2Perameter VARCHAR(Max),
@ProductNaturePerameter VARCHAR(Max),   
	@ProductGroupPerameter VARCHAR(Max),
@ProductCustomGroupPerameter VARCHAR(Max),
@ProductDivisionIdPerameter VARCHAR(Max),
@PersonIdPerameter VARCHAR(Max),
@DyedUndyedStockPerameter VARCHAR(Max),
@Dimension3Perameter VARCHAR(Max),
@Dimension4Perameter VARCHAR(Max),
@ShowOpeningPerameter VARCHAR(10)

';  


DECLARE @SQL AS NVARCHAR(Max)

DECLARE @HeadCondStr AS NVARCHAR(Max)

SET @HeadCondStr=''

SET @SQL=''

if (@Site IS NOT NULL) BEGIN SET @HeadCondStr += N' And G.SiteId IN (SELECT Items FROM [web].[Split] (@SitePerameter,  '',''))' END 

if (@ProductDivisionId IS NOT NULL) BEGIN SET @HeadCondStr += N' And P.DivisionId IN (SELECT Items FROM [web].[Split] (@ProductDivisionIdPerameter,  '',''))' END 
if (@PersonId IS NOT NULL) BEGIN SET @HeadCondStr += N' And H.PersonId IN (SELECT Items FROM [web].[Split] (@PersonIdPerameter,  '',''))' END 
if (@ToDate IS NOT NULL) BEGIN SET @HeadCondStr += N' And @ToDatePerameter >= S.DocDate ' END 
if (@Product IS NOT NULL) BEGIN SET @HeadCondStr += N' And S.ProductId IN (SELECT Items FROM [web].[Split] (@ProductPerameter,  '',''))' END 
if (@Godown IS NOT NULL) BEGIN SET @HeadCondStr += N' And S.GodownId IN (SELECT Items FROM [web].[Split] (@GodownPerameter,  '',''))' END 
if (@Process IS NOT NULL) BEGIN SET @HeadCondStr += N' And S.ProcessId IN (SELECT Items FROM [web].[Split] (@ProcessPerameter,  '',''))' END 
if (@Dimension1 IS NOT NULL) BEGIN SET @HeadCondStr += N' And S.Dimension1Id IN (SELECT Items FROM [web].[Split] (@Dimension1Perameter,  '',''))' END  
if (@Dimension2 IS NOT NULL) BEGIN SET @HeadCondStr += N' And S.Dimension2Id IN (SELECT Items FROM [web].[Split] (@Dimension2Perameter,  '',''))' END 
if (@ProductGroup IS NOT NULL) BEGIN SET @HeadCondStr += N' And Pg.ProductGroupId IN (SELECT Items FROM [web].[Split] (@ProductGroupPerameter,  '',''))' END 
if (@ProductType IS NOT NULL) BEGIN SET @HeadCondStr += N' And PT.ProductTypeId IN (SELECT Items FROM [web].[Split] (@ProductTypePerameter,  '',''))' END 
if (@ProductNature IS NOT NULL) BEGIN SET @HeadCondStr += N' And PT.ProductNatureId IN (SELECT Items FROM [web].[Split] (@ProductNaturePerameter,  '',''))' END  
if (@ProductCustomGroup IS NOT NULL) BEGIN SET @HeadCondStr += N' And PCG.ProductId IS NOT NULL ' END 
if (@Dimension3 IS NOT NULL) BEGIN SET @HeadCondStr += N' And S.Dimension3Id IN (SELECT Items FROM [web].[Split] (@Dimension3Perameter,  '',''))' END  
if (@Dimension4 IS NOT NULL) BEGIN SET @HeadCondStr += N' And S.Dimension4Id IN (SELECT Items FROM [web].[Split] (@Dimension4Perameter,  '',''))' END 
IF ( isnull(@GroupOn,'') = '' )
SET @GroupOn ='Product'
DECLARE @CondStr NVARCHAR(Max)  
DECLARE @IsGroupOnGodown INT 
DECLARE @IsGroupOnProcess INT 
DECLARE @IsGroupOnProduct INT 
DECLARE @IsGroupOnDimension1 INT 
DECLARE @IsGroupOnDimension2 INT 
DECLARE @IsGroupOnDimension3 INT 
DECLARE @IsGroupOnDimension4 INT 
DECLARE @IsGroupOnLotNo INT 
DECLARE @IsGroupOnPerson INT 
SET @IsGroupOnGodown = charindex('Godown',@GroupOn)
SET @IsGroupOnProcess = charindex('Process',@GroupOn)
SET @IsGroupOnProduct = charindex('Product',@GroupOn)
SET @IsGroupOnDimension1 = charindex('Dimension1',@GroupOn)  --Dimension3 , Size
SET @IsGroupOnDimension2 = charindex('Dimension2',@GroupOn)  --Dimension2 ,Style
SET @IsGroupOnDimension3 = charindex('Dimension3',@GroupOn)  --Dimension1 ,Shade
SET @IsGroupOnDimension4 = charindex('Dimension4',@GroupOn)  --Dimension4 ,Fabric
SET @IsGroupOnLotNo = charindex('LotNo',@GroupOn)
SET @IsGroupOnPerson = charindex('Person',@GroupOn)
DECLARE @SelectVal AS NVARCHAR(Max)
DECLARE @GroupVal AS NVARCHAR(Max)
DECLARE @Title AS NVARCHAR(Max)
SET @SelectVal=''
SET @GroupVal=''
SET @Title=''
	IF(@IsGroupOnProduct > 0)
	BEGIN 
		SET @SelectVal += N' isnull(max(PD.ProductName),'' '') as ProductName,S.ProductId, '
	  	SET @GroupVal += N' ,S.ProductId '		
	    --SET @Title += N' max(PTCaption.ProductNameCaption) as GroupTitle1,  '
	END 
	ELSE 
   BEGIN 
    SET @SelectVal += N' '' '' as ProductName , '	  			
	    --SET @Title += N' '' '' as GroupTitle1,  '
	END 
	IF(@IsGroupOnDimension1 > 0 ) 
	BEGIN 
	SET @SelectVal += N' isnull(max(D1.Dimension1Name),'' '') as Dimension1Name,isnull(S.Dimension1Id,'''') as Dimension1Id,'
	SET @GroupVal += N'  ,S.Dimension1Id '	   
   --SET @Title += N' Max(PTCaption.Dimension1Caption) as GroupTitle2,  '
  END 
	ELSE 
	BEGIN 
 	SET @SelectVal += N' '' '' as Dimension1Name,'
	--SET @Title += N' '' '' as GroupTitle2,  '		
	END 
	IF(@IsGroupOnDimension2 > 0 ) 
	BEGIN 
		SET @SelectVal += N' isnull(max(D2.Dimension2Name),'' '') as Dimension2Name,isnull(S.Dimension2Id,'''') as Dimension2Id,  '
	SET @GroupVal += N'  ,S.Dimension2Id '	   
		--SET @Title += N' max(PTCaption.Dimension2Caption) as GroupTitle3,  '
		END 
	ELSE 

	BEGIN 
    SET @SelectVal += N' '' '' as Dimension2Name,  '
   --SET @Title += N' '' '' as GroupTitle3,  '
	    END 

		IF(@IsGroupOnDimension3 > 0)
		BEGIN 
			SET @SelectVal += N' isnull(max(D3.Dimension3Name),'' '') as Dimension3Name,isnull(S.Dimension3Id,'''') as Dimension3Id,  '
			SET @GroupVal += N'  ,S.Dimension3Id '	   
		   --	SET @Title += N' max(PTCaption.Dimension3Caption) as GroupTitle7,  '
		END 
		ELSE
		BEGIN 
	SET @SelectVal += N' '' '' as Dimension3Name,  '

		   --	SET @Title += N' '' '' as GroupTitle7,  
		END
		IF(@IsGroupOnDimension4 > 0)
		BEGIN 
		SET @SelectVal += N' isnull(max(D4.Dimension4Name),'' '') as Dimension4Name,isnull(S.Dimension4Id,'''') as Dimension4Id,  '
		SET @GroupVal += N'  ,S.Dimension4Id '	   

			--SET @Title += N' max(PTCaption.Dimension4Caption) as GroupTitle8,  '
		END 
		ELSE
		BEGIN 
			SET @SelectVal += N' '' '' as Dimension4Name,  '
			--SET @Title += N' '' '' as GroupTitle8,  '
		END 
	IF(@IsGroupOnProcess > 0) 
	BEGIN 
	SET @SelectVal += N' isnull(max(PS.ProcessName),'' '') as ProcessName,S.ProcessId , '
	SET @GroupVal += N'  ,S.ProcessId '		
		--SET @Title += N' ''Process'' as GroupTitle4,  '
	END 
	ELSE 
	BEGIN 
  	SET @SelectVal += N' '' '' as ProcessName , '
		--SET @Title += N' '' '' as GroupTitle4,  '

		END 
	IF(@IsGroupOnLotNo > 0 )
	BEGIN 
	SET @SelectVal += N' isnull(max(S.LotNo),'' '') as LotNo, ' 
	SET @GroupVal += N' ,S.LotNo '	  
	--SET @Title += N' ''Process'' as GroupTitle5,  '
	END 
ELSE 
	BEGIN 
  SET @SelectVal += N' '' '' as LotNo, ' 
	--SET @Title += N' '' '' as GroupTitle5,  '

	END 

	IF( @IsGroupOnGodown > 0) 

	BEGIN 
	SET @SelectVal += N' isnull(max(G.GodownName),'' '') as GodownName,S.GodownId, '

	SET @GroupVal += N' ,S.GodownId '		
    --SET @Title += N' ''Godown'' as GroupTitle6, '
	END 
	ELSE 
	BEGIN 
  	SET @SelectVal += N' '' '' as GodownName, '			
	--SET @Title += N' '' '' as GroupTitle6, '		
   END 
	IF( @IsGroupOnPerson > 0) 
	BEGIN 
	SET @SelectVal += N' isnull(max(Pp.Name),'' '') as Name,H.PersonId, '
	SET @GroupVal += N' ,H.PersonId '		
--SET @Title += N' ''Godown'' as GroupTitle6, '
	END 
	ELSE 
	BEGIN 
   	SET @SelectVal += N' '' '' as Name, '			
	--SET @Title += N' '' '' as GroupTitle6, '		
  END 
IF(@ShowOpening='1')
BEGIN
SET @SQL='

SELECT 
max(H.SiteId) as SiteId,
1 AS DivisionId,
'+@SelectVal+@Title+'
max(U.UnitName) AS UnitName,
convert(int,max(U.DecimalPlaces)) AS DecimalPlaces,
convert(int,max(U.DecimalPlaces)) as UnitDecimalPlaces,
Sum(CASE WHEN S.DocDate < @FromDatePerameter Then isnull(Qty_Rec,0)-isnull(Qty_Iss,0) ELSE 0 End) AS Opening,  
Sum(CASE WHEN S.DocDate >=@FromDatePerameter AND S.DocDate <=@ToDatePerameter Then isnull(Qty_Rec,0) ELSE 0 End) AS RecQty, 
Sum(CASE WHEN S.DocDate >=@FromDatePerameter AND S.DocDate <=@ToDatePerameter Then isnull(Qty_Iss,0) ELSE 0 End) AS IssQty,
Sum(CASE WHEN S.DocDate <=@ToDatePerameter Then isnull(Qty_Rec,0)-isnull(Qty_Iss,0) ELSE 0 End) AS BalQty,
Max(DT1.Dimension1TypeName) AS Dimension1TypeName,Max(DT2.Dimension2TypeName) AS Dimension2TypeName,
max(PG.ProductgroupName) as ProductgroupName,
''StockInDisplay.rdl'' as ReportName ,
''Stock In Hand Display'' as ReportTitle,
null as SubReportProcList,
max(PTCaption.Dimension1Caption) as Dimension1Caption,
max(PTCaption.Dimension2Caption) as Dimension2Caption,
max(PTCaption.Dimension3Caption) as Dimension3Caption,
max(PTCaption.Dimension4Caption) as Dimension4Caption,
max(PTCaption.ProductNameCaption) as ProductNameCaption,
@ShowOpeningPerameter as ShowOpening,
@GroupOnPerameter as GroupOn
INTO #MyTempTable1
FROM Web.StockHeaders H WITH (Nolock)
LEFT JOIN '+ @TableName +' S WITH (Nolock) ON S.StockHeaderId=H.StockHeaderId
LEFT JOIN Web.People Pp WITH (Nolock) ON Pp.PersonId =H.PersonId
LEFT JOIN web.Godowns G WITH (Nolock) ON G.GodownId=S.GodownId
LEFT JOIN web.Processes PS WITH (Nolock) ON PS.ProcessId=S.ProcessId
LEFT JOIN Web.Products PD WITH (Nolock) ON PD.ProductId=S.ProductId
LEFT JOIN web.Dimension1 D1 WITH (Nolock) ON D1.Dimension1Id=S.Dimension1Id
LEFT JOIN web.Dimension2 D2 WITH (Nolock) ON D2.Dimension2Id=S.Dimension2Id
LEFT JOIN web.Dimension3 D3 WITH (Nolock) ON D3.Dimension3Id=S.Dimension3Id
LEFT JOIN web.Dimension4 D4 WITH (Nolock) ON D4.Dimension4Id=S.Dimension4Id
LEFT JOIN web.Units U WITH (Nolock) ON U.UnitId=PD.UnitId
LEFT JOIN web.ProductGroups PG WITH (Nolock) ON PG.ProductGroupId=PD.ProductGroupId
LEFT JOIN web.ProductTypes PT WITH (Nolock) ON PT.ProductTypeId=PG.ProductTypeId
LEFT JOIN web.ProductNatures PN WITH (Nolock) ON PN.ProductNatureId=PT.ProductNatureId
LEFT JOIN Web.Dimension1Types Dt1 WITH (Nolock) ON Pt.Dimension1TypeId = Dt1.Dimension1TypeId
LEFT JOIN Web.Dimension2Types Dt2 WITH (Nolock) ON Pt.Dimension2TypeId = Dt2.Dimension2TypeId
LEFT JOIN 
(
SELECT ProductTypeId,
(CASE WHEN Dimension1Caption IS NULL THEN ''Dimension1'' ELSE Dimension1Caption END) as  Dimension1Caption,    
(CASE WHEN Dimension2Caption IS NULL THEN ''Dimension2'' ELSE Dimension2Caption END) as Dimension2Caption,
(CASE WHEN Dimension3Caption IS NULL THEN ''Dimension3'' ELSE Dimension3Caption END) as Dimension3Caption,
(CASE WHEN Dimension4Caption IS NULL THEN ''Dimension4'' ELSE Dimension4Caption END) as Dimension4Caption,
(CASE WHEN ProductNameCaption IS NULL THEN ''Product'' ELSE ProductNameCaption END ) as ProductNameCaption
 FROM Web.ProductTypeSettings
) PTCaption on PTCaption.ProductTypeId=PT.ProductTypeId
LEFT JOIN (
			SELECT ProductId FROM Web.ProductCustomGroupLines WITH (Nolock)
		WHERE 1=1 
			AND ( @ProductCustomGroupPerameter is null or ProductCustomGroupHeaderId IN (SELECT Items FROM [web].[Split] (@ProductCustomGroupPerameter, '',''))) 
			GROUP BY ProductId
			) AS PCG  ON  S.ProductId =PCG.ProductId			
WHERE  S.ProductId IS NOT NULL  AND ( (@DyedUndyedStockPerameter=''Dyed'' AND  S.Dimension1Id Is NOT NULL) or 
                                      (@DyedUndyedStockPerameter=''UnDyed'' AND S.Dimension1Id IS  NULL) or
                                     (@DyedUndyedStockPerameter=''1'' ))
                                   
 '+@HeadCondStr+'

GROUP BY  G.SiteId '+@GroupVal+'

having (Sum(CASE WHEN H.DocDate < @FromDatePerameter Then isnull(Qty_Rec,0)-isnull(Qty_Iss,0) ELSE 0 End) <> 0 or     Sum(CASE WHEN H.DocDate >=@FromDatePerameter AND H.DocDate <=@ToDatePerameter Then isnull(Qty_Rec,0) ELSE 0 End) <> 0 or Sum(CASE WHEN H.DocDate >=@FromDatePerameter AND H.DocDate <=@ToDatePerameter Then isnull(Qty_Iss,0) ELSE 0 End)<> 0 or Sum(CASE WHEN H.DocDate <=@ToDatePerameter Then isnull(Qty_Rec,0)-isnull(Qty_Iss,0) ELSE 0 End) <> 0)
order By max(PD.ProductName)
IF (@ShowBalancePerameter = ''Not Zero'')
	SELECT row_number() OVER (ORDER BY ProductName) AS Id,* FROM #MyTempTable1  WHERE Round(BalQty,4) <> 0
ELSE IF (@ShowBalancePerameter = ''Zero'')
	SELECT row_number() OVER (ORDER BY ProductName) AS Id,* FROM #MyTempTable1  WHERE Round(BalQty,4) = 0
ELSE IF (@ShowBalancePerameter = ''Greater Than Zero'')
	SELECT row_number() OVER (ORDER BY ProductName) AS Id,* FROM #MyTempTable1 WHERE Round(BalQty,4) > 0
ELSE IF (@ShowBalancePerameter = ''Less Than Zero'')
	SELECT row_number() OVER (ORDER BY ProductName) AS Id,* FROM #MyTempTable1 WHERE Round(BalQty,4) < 0
ELSE IF (@ShowBalancePerameter = ''Period Negative'')
	SELECT row_number() OVER (ORDER BY ProductName) AS Id,* FROM #MyTempTable1  WHERE Round(BalQty,4) < 0 AND Round(Opening,4) >= 0 
ELSE
	SELECT row_number() OVER (ORDER BY ProductName) AS Id,* FROM #MyTempTable1

'
END 
 ELSE 
 BEGIN 
SET @SQL='

SELECT 
max(H.SiteId) as SiteId,
1 AS DivisionId,
'+@SelectVal+@Title+'
max(U.UnitName) AS UnitName,
convert(int,max(U.DecimalPlaces)) AS DecimalPlaces,
convert(int,max(U.DecimalPlaces)) as UnitDecimalPlaces,
CONVERT(DECIMAL(16,4), 0) as Opening,
Sum(CASE WHEN S.DocDate >=@FromDatePerameter AND S.DocDate <=@ToDatePerameter Then isnull(Qty_Rec,0) ELSE 0 End) AS RecQty, 
Sum(CASE WHEN S.DocDate >=@FromDatePerameter AND S.DocDate <=@ToDatePerameter Then isnull(Qty_Iss,0) ELSE 0 End) AS IssQty,
--Sum(CASE WHEN S.DocDate <=@ToDatePerameter Then isnull(Qty_Rec,0)-isnull(Qty_Iss,0) ELSE 0 End) AS BalQty,
Sum(CASE WHEN S.DocDate >=@FromDatePerameter AND S.DocDate <=@ToDatePerameter Then isnull(Qty_Rec,0)-isnull(Qty_Iss,0) ELSE 0 End) AS BalQty,
Max(DT1.Dimension1TypeName) AS Dimension1TypeName,Max(DT2.Dimension2TypeName) AS Dimension2TypeName,
max(PG.ProductgroupName) as ProductgroupName,
''StockInDisplay.rdl'' as ReportName ,
''Stock In Hand Display'' as ReportTitle,
null as SubReportProcList
INTO #MyTempTable
FROM Web.StockHeaders H WITH (Nolock)
LEFT JOIN '+ @TableName +' S WITH (Nolock) ON S.StockHeaderId=H.StockHeaderId
LEFT JOIN web.Godowns G WITH (Nolock) ON G.GodownId=S.GodownId
LEFT JOIN web.Processes PS WITH (Nolock) ON PS.ProcessId=S.ProcessId
LEFT JOIN Web.Products PD WITH (Nolock) ON PD.ProductId=S.ProductId
LEFT JOIN web.Dimension1 D1 WITH (Nolock) ON D1.Dimension1Id=S.Dimension1Id
LEFT JOIN web.Dimension2 D2 WITH (Nolock) ON D2.Dimension2Id=S.Dimension2Id
LEFT JOIN web.Dimension3 D3 WITH (Nolock) ON D3.Dimension3Id=S.Dimension3Id
LEFT JOIN web.Dimension4 D4 WITH (Nolock) ON D4.Dimension4Id=S.Dimension4Id
LEFT JOIN web.Units U WITH (Nolock) ON U.UnitId=PD.UnitId
LEFT JOIN web.ProductGroups PG WITH (Nolock) ON PG.ProductGroupId=PD.ProductGroupId
LEFT JOIN web.ProductTypes PT WITH (Nolock) ON PT.ProductTypeId=PG.ProductTypeId
LEFT JOIN web.ProductNatures PN WITH (Nolock) ON PN.ProductNatureId=PT.ProductNatureId
LEFT JOIN Web.Dimension1Types Dt1 WITH (Nolock) ON Pt.Dimension1TypeId = Dt1.Dimension1TypeId
LEFT JOIN Web.Dimension2Types Dt2 WITH (Nolock) ON Pt.Dimension2TypeId = Dt2.Dimension2TypeId
LEFT JOIN 
(
SELECT ProductTypeId,
(CASE WHEN Dimension1Caption IS NULL THEN ''Dimension1'' ELSE Dimension1Caption END) as  Dimension1Caption,
(CASE WHEN Dimension2Caption IS NULL THEN ''Dimension2'' ELSE Dimension2Caption END) as Dimension2Caption,
(CASE WHEN Dimension3Caption IS NULL THEN ''Dimension3'' ELSE Dimension3Caption END) as Dimension3Caption,
(CASE WHEN Dimension4Caption IS NULL THEN ''Dimension4'' ELSE Dimension4Caption END) as Dimension4Caption,
(CASE WHEN ProductNameCaption IS NULL THEN ''Product'' ELSE ProductNameCaption END ) as ProductNameCaption
 FROM Web.ProductTypeSettings
) PTCaption on PTCaption.ProductTypeId=PT.ProductTypeId

LEFT JOIN (
			SELECT ProductId FROM Web.ProductCustomGroupLines WITH (Nolock)
			WHERE 1=1 
			AND ( @ProductCustomGroupPerameter is null or ProductCustomGroupHeaderId IN (SELECT Items FROM [web].[Split] (@ProductCustomGroupPerameter, '',''))) 
			GROUP BY ProductId
			) AS PCG  ON  S.ProductId =PCG.ProductId			
WHERE  S.ProductId IS NOT NULL  AND ( (@DyedUndyedStockPerameter=''Dyed'' AND  S.Dimension1Id Is NOT NULL) or 
                                     (@DyedUndyedStockPerameter=''UnDyed'' AND S.Dimension1Id IS  NULL) or
                                     (@DyedUndyedStockPerameter=''1'' ))
                                    
 '+@HeadCondStr+'

GROUP BY  G.SiteId '+@GroupVal+'
having (Sum(CASE WHEN H.DocDate >=@FromDatePerameter AND H.DocDate <=@ToDatePerameter Then isnull(Qty_Rec,0) ELSE 0 End) <> 0 or Sum(CASE WHEN H.DocDate >=@FromDatePerameter AND H.DocDate <=@ToDatePerameter Then isnull(Qty_Iss,0) ELSE 0 End)<> 0 or Sum(CASE WHEN S.DocDate >=@FromDatePerameter AND S.DocDate <=@ToDatePerameter Then isnull(Qty_Rec,0)-isnull(Qty_Iss,0) ELSE 0 End) <> 0)
order By max(PD.ProductName)
IF (@ShowBalancePerameter = ''Not Zero'')
	SELECT row_number() OVER (ORDER BY ProductName) AS Id,* FROM #MyTempTable  WHERE Round(BalQty,4) <> 0
ELSE IF (@ShowBalancePerameter = ''Zero'')
	SELECT row_number() OVER (ORDER BY ProductName) AS Id,* FROM #MyTempTable  WHERE Round(BalQty,4) = 0
ELSE IF (@ShowBalancePerameter = ''Greater Than Zero'')
	SELECT row_number() OVER (ORDER BY ProductName) AS Id,* FROM #MyTempTable WHERE Round(BalQty,4) > 0
ELSE IF (@ShowBalancePerameter = ''Less Than Zero'')
	SELECT row_number() OVER (ORDER BY ProductName) AS Id,* FROM #MyTempTable WHERE Round(BalQty,4) < 0
ELSE IF (@ShowBalancePerameter = ''Period Negative'')
	SELECT row_number() OVER (ORDER BY ProductName) AS Id,* FROM #MyTempTable  WHERE Round(BalQty,4) < 0 AND Round(Opening,4) >= 0 
ELSE
	SELECT row_number() OVER (ORDER BY ProductName) AS Id,* FROM #MyTempTable 
'
END 
EXEC sp_executeSQL 

				@SQL,
				@ParameterDefinition,
				@ProductTypePerameter=@ProductType,
				@SitePerameter=@Site,
				@FromDatePerameter=@FromDate,
				@ToDatePerameter=@ToDate,
				@GroupOnPerameter=@GroupOn,
				@ShowBalancePerameter=@ShowBalance,
				@ProductPerameter=@Product,
				@GodownPerameter=@Godown,
				@ProcessPerameter=@Process,
				@Dimension1Perameter=@Dimension1,
				@Dimension2Perameter=@Dimension2,
				@ProductNaturePerameter=@ProductNature,
				@ProductGroupPerameter=@ProductGroup,
				@ProductCustomGroupPerameter=@ProductCustomGroup,
				@ProductDivisionIdPerameter=@ProductDivisionId,
				@PersonIdPerameter=@PersonId,
				@DyedUndyedStockPerameter=@DyedUndyedStock,
				@Dimension3Perameter=@Dimension3,
				@Dimension4Perameter=@Dimension4,
				@ShowOpeningPerameter=@ShowOpening

END

