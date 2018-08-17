
CREATE Procedure [Web].[ProcGetBomForWeaving]
(
	@DocTypeId INT,
	@ProductId INT,
	@ProcessId INT,
	@Qty DECIMAL(18,4),
	@Dimension1Id INT = NULL,
	@Dimension2Id INT = NULL

)
AS

Declare @TmpTable as Table  
(  
	ProductId INT,
	Dimension1Id INT,
	Dimension2Id INT,
	ProcessId INT,
	Qty DECIMAL(18,4)  
);

INSERT INTO @TmpTable (ProductId ,	Dimension1Id ,Dimension2Id ,ProcessId ,Qty)
SELECT @ProductId,  @Dimension1Id,  @Dimension2Id, @ProcessId, @Qty ;


WITH CTBom AS  
(    
	SELECT row_number() OVER (PARTITION BY B.BaseProductId ORDER BY B.BaseProductId, B.ProductId) AS Sr, 
	B.BaseProductId, B.ProductId, 
	(B.Qty/B.BatchQty) * T.Qty * (CASE WHEN @DocTypeId = 637 THEN Vrs.ManufaturingSizeArea ELSE (SELECT Web.FConvertSqFeetToSqYard(Vrs.StandardSizeArea)  ) END) AS ToPQty , 
		(B.Qty/B.BatchQty)  * (CASE WHEN @DocTypeId = 637 THEN Vrs.ManufaturingSizeArea  ELSE  (SELECT Web.FConvertSqFeetToSqYard(Vrs.StandardSizeArea)  )END ) / (CASE WHEN @DocTypeId = 637 THEN Vrs.ManufaturingSizeArea ELSE (SELECT Web.FConvertSqFeetToSqYard(Vrs.StandardSizeArea)  )END) AS ToPQty1 , 
	B.ProcessId, B.Dimension1Id, B.Dimension2Id, 1 AS LEVEL  
	FROM @TmpTable  T  
	INNER JOIN Web.BomDetails B On B.BaseProductId = T.ProductId
	LEFT JOIN Web.ViewProductSize Vrs ON B.BaseProductId = Vrs.ProductId
	--WHERE B.ProcessId = @ProcessId
	UNION ALL      
	SELECT row_number() OVER (PARTITION BY B.BaseProductId ORDER BY B.BaseProductId, B.ProductId) AS Sr,
	B.BaseProductId, B.ProductId, (B.Qty/B.BatchQty)  * CTBom.ToPQty AS ToPQty , 
	(B.Qty/B.BatchQty)  * CTBom.ToPQty1 AS ToPQty1 ,  
	B.ProcessId,  B.Dimension1Id, B.Dimension2Id, LEVEL + 1  
	FROM Web.BomDetails B     
	INNER JOIN Web.Processes on b.ProcessId = Web.Processes.ProcessId
	INNER JOIN CTBom on b.BaseProductId = CTBom.ProductId AND B.BaseProcessId =@ProcessId
	--WHERE B.ProcessId = @ProcessId   
)      

SELECT  CTBom.ProductId, CTBom.Dimension1Id, CTBom.Dimension2Id, CTBom.ProcessId,Round(Sum(CTBom.ToPQty),3) AS Qty ,
Round(Max(CTBom.ToPQty1),3) AS BOMQty  
FROM CTBom     
WHERE CTBom.Level = (SELECT Max(Level) FROM CTBom)
GROUP BY CTBom.ProductId, CTBom.ProcessId, CTBom.Dimension1Id, CTBom.Dimension2Id
ORDER BY CTBom.ProductId, CTBom.Dimension1Id, CTBom.Dimension2Id


