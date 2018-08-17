CREATE PROCEDURE Web.sp_GetProductStandardWeight (@ProductId INT) AS 
WITH CTBom AS  
(    
	SELECT row_number() OVER (PARTITION BY B.BaseProductId ORDER BY B.BaseProductId, B.ProductId) AS Sr, 
	B.BaseProductId, B.ProductId, (B.Qty/B.BatchQty) * IsNull((SELECT Web.FConvertSqFeetToSqYard(Vrs.ManufaturingSizeArea)),1) AS ToPQty , 
	B.ProcessId, B.Dimension1Id, B.Dimension2Id, 1 AS LEVEL  
	FROM web.Products T  
	INNER JOIN Web.BomDetails B WITH (Nolock) On B.BaseProductId = T.ProductId
	LEFT JOIN Web.ViewProductSize Vrs WITH (Nolock) ON B.BaseProductId = Vrs.ProductId
	WHERE T.ProductId = @ProductId
	UNION ALL  
	SELECT  1 AS Sr, 
	NULL BaseProductId, NULL ProductId, 0 AS ToPQty , 
	NULL ProcessId, NULL Dimension1Id, NULL Dimension2Id, 1 AS LEVEL  
	FROM web.FinishedProduct P WHERE P.ProductId =@ProductId   AND isnull(P.IsSample,0) =1
	UNION ALL      
	SELECT row_number() OVER (PARTITION BY B.BaseProductId ORDER BY B.BaseProductId, B.ProductId) AS Sr,
	B.BaseProductId, B.ProductId, (B.Qty/B.BatchQty)  * CTBom.ToPQty * IsNull((SELECT Web.FConvertSqFeetToSqYard(Vrs.ManufaturingSizeArea)),1) AS ToPQty ,  
	B.ProcessId,  B.Dimension1Id, B.Dimension2Id, LEVEL + 1  
	FROM Web.BomDetails B WITH (Nolock)     
	INNER JOIN Web.ViewProductSize Vrs WITH (Nolock) ON B.BaseProductId = Vrs.ProductId
	INNER JOIN CTBom on b.BaseProductId = CTBom.ProductId    
)      

SELECT  
Round(Sum(CTBom.ToPQty),3) AS StandardWeight  
FROM CTBom      
LEFT JOIN web.Products P WITH (Nolock) ON P.ProductId = CTBom.BaseProductId
LEFT JOIN web.ProductGroups PG WITH (Nolock) ON PG.ProductGroupId = P.ProductGroupId 
LEFT JOIN web.Dimension2 D2 WITH (Nolock) ON D2.Description = convert(NVARCHAR,PG.ProductGroupId)
LEFT JOIN web.ProductTypes PT WITH (Nolock) ON PT.ProductTypeId = PG.ProductTypeId  
LEFT JOIN ( SELECT BaseProductId, Max(ProductId) AS ProductId FROM web.BomDetails WITH (Nolock) GROUP BY BaseProductId ) 
BD ON BD.BaseProductId = CTBom.BaseProductId
LEFT JOIN web.Products P1 WITH (Nolock) ON P1.ProductId = BD.ProductId
LEFT JOIN web.ProductGroups PG1 WITH (Nolock) ON PG1.ProductGroupId = P1.ProductGroupId 
LEFT JOIN web.Dimension2 D21 WITH (Nolock) ON D21.Description = convert(NVARCHAR,PG1.ProductGroupId)


