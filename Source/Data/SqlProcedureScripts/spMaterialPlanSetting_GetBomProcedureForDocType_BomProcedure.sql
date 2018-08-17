CREATE PROCEDURE [Web].[spMaterialPlanSetting_GetBomProcedureForDocType_BomProcedure]
(
	@T AS Web.TypeParameter READONLY,
	@MaterialPlanHeaderId INT  =NULL 
)
AS

Declare @TmpTable as Table  
(  
	ProdOrderLineId INT,
	ProductId INT,
	Dimension1Id INT,
	Dimension2Id INT,
	ProcessId INT,
	Qty Float  
);

INSERT INTO @TmpTable (ProdOrderLineId,	ProductId ,	Dimension1Id ,Dimension2Id ,ProcessId ,Qty)
SELECT POL.ProdOrderLineId, POL.ProductId, NULL AS Dimension1Id, NULL AS Dimension2Id, POL.ProcessId, T.Qty AS  Qty    
FROM @T AS T 	
LEFT JOIN Web.ProdOrderLines AS POL  WITH (Nolock) ON T.ProdOrderLineId = POL.ProdOrderLineId;


WITH CTBom AS  
(    
	SELECT row_number() OVER (PARTITION BY B.BaseProductId ORDER BY B.BaseProductId, B.ProductId) AS Sr, 
	T.ProdOrderLineId, B.BaseProductId, B.ProductId, (B.Qty/B.BatchQty) * T.Qty * ( CASE WHEN PC.ProductCategoryName ='NEPALI' THEN IsNull(Vrs.ManufaturingSizeArea,1) ELSE  IsNull((SELECT  Web.FConvertSqFeetToSqYard(Vrs.StandardSizeArea )),1) END ) AS ToPQty , 
	B.ProcessId, B.Dimension1Id, B.Dimension2Id, 1 AS LEVEL  
	FROM @TmpTable  T  
	INNER JOIN Web.BomDetails B WITH (Nolock) On B.BaseProductId = T.ProductId
	LEFT JOIN Web.ViewProductSize Vrs WITH (Nolock) ON B.BaseProductId = Vrs.ProductId
	LEFT JOIN web.Products P ON P.ProductId = B.baseProductId 
	LEFT JOIN web.ProductCategories PC ON PC.ProductCategoryId =P.ProductCategoryId 
	UNION ALL      
	SELECT row_number() OVER (PARTITION BY B.BaseProductId ORDER BY B.BaseProductId, B.ProductId) AS Sr,
	CTBom.ProdOrderLineId, B.BaseProductId, B.ProductId, (B.Qty/B.BatchQty)  * CTBom.ToPQty * IsNull((SELECT  Web.FConvertSqFeetToSqYard(Vrs.StandardSizeArea)),1) AS ToPQty ,  
	B.ProcessId,  B.Dimension1Id, B.Dimension2Id, LEVEL + 1  
	FROM Web.BomDetails B WITH (Nolock)     
	INNER JOIN Web.ViewProductSize Vrs WITH (Nolock) ON B.BaseProductId = Vrs.ProductId
	--INNER JOIN Web.Processes on b.ProcessId = Web.Processes.ProcessId
	INNER JOIN CTBom on b.BaseProductId = CTBom.ProductId    
)      

SELECT  CTBom.ProdOrderLineId, CTBom.ProductId, CTBom.Dimension1Id, CASE WHEN Max(PT.ProductTypeName) <> 'Rug' THEN D21.Dimension2Id ELSE D2.Dimension2Id END AS Dimension2Id, 
CASE WHEN Max(PT.ProductTypeName) <> 'Rug' THEN D31.Dimension3Id ELSE D3.Dimension3Id END AS Dimension3Id, NULL AS Dimension4Id,
CTBom.ProcessId,
Round(Sum(CTBom.ToPQty),3) AS Qty  
--ceiling(Sum(CTBom.ToPQty)) AS Qty  
FROM CTBom     
LEFT JOIN web.ProdOrderLines POL WITH (Nolock) ON POL.ProdOrderLineId = CTBom.ProdOrderLineId  
LEFT JOIN web.Products P WITH (Nolock) ON P.ProductId = POL.ProductId
LEFT JOIN web.ProductGroups PG WITH (Nolock) ON PG.ProductGroupId = P.ProductGroupId 
LEFT JOIN web.FinishedProduct FP WITH (Nolock) ON FP.ProductId = P.ProductId 
LEFT JOIN web.Dimension2 D2 WITH (Nolock) ON D2.Description = convert(NVARCHAR,PG.ProductGroupId)
LEFT JOIN web.Dimension3 D3 WITH (Nolock) ON D3.Description = convert(NVARCHAR,FP.ColourId )
---- For Dimension2 of Finished Material
LEFT JOIN web.ProductTypes PT WITH (Nolock) ON PT.ProductTypeId = PG.ProductTypeId  
LEFT JOIN ( SELECT BaseProductId, Max(ProductId) AS ProductId FROM web.BomDetails WITH (Nolock) GROUP BY BaseProductId ) 
BD ON BD.BaseProductId = POL.ProductId 
LEFT JOIN web.Products P1 WITH (Nolock) ON P1.ProductId = BD.ProductId
LEFT JOIN web.FinishedProduct FP1 WITH (Nolock) ON FP1.ProductId = P1.ProductId 
LEFT JOIN web.ProductGroups PG1 WITH (Nolock) ON PG1.ProductGroupId = P1.ProductGroupId 
LEFT JOIN web.Dimension2 D21 WITH (Nolock) ON D21.Description = convert(NVARCHAR,PG1.ProductGroupId)  
LEFT JOIN web.Dimension3 D31 WITH (Nolock) ON D31.Description = convert(NVARCHAR,FP1.ColourId )
WHERE CTBom.Dimension1Id IS NOT NULL
GROUP BY CTBom.ProdOrderLineId, CTBom.ProductId, CTBom.ProcessId, CTBom.Dimension1Id, D2.Dimension2Id, D21.Dimension2Id,D3.Dimension3Id, D31.Dimension3Id
ORDER BY max(CTBom.Level)

