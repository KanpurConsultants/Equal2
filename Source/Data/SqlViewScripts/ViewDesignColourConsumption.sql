CREATE VIEW Web.ViewDesignColourConsumption
AS 
SELECT DISTINCT Pg.ProductGroupId, Pg.ProductGroupName, C.ColourId, C.ColourName, Pq.ProductQualityId, Pq.ProductQualityName, IsNull(Bp.ProductId,0) AS BomProductId, IsNull(Bp.StandardWeight,P.GrossWeight) AS Weight
FROM Web.FinishedProduct Fp WITH (NoLock)
LEFT JOIN Web.Products P WITH (NoLock) ON Fp.ProductId = P.ProductId
LEFT JOIN Web.ProductGroups Pg WITH (NoLock) ON P.ProductGroupId = Pg.ProductGroupId
LEFT JOIN Web.Colours C WITH (NoLock) ON Fp.ColourId = C.ColourId
LEFT JOIN Web.ProductQualities Pq ON Fp.ProductQualityId = Pq.ProductQualityId
LEFT JOIN Web.Products Bp WITH (NoLock) ON Replace(Pg.ProductGroupName + '-' + C.ColourName + '-Bom','','') = Replace(Bp.ProductName,'','')
WHERE C.ColourId IS NOT NULL