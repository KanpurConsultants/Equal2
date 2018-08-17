CREATE VIEW Web.ViewBomDetailsForWeavingReceivePosting
AS 
SELECT L.BomDetailId, L.BaseProductId, L.BatchQty, L.ProductId, 
CASE WHEN IsNULL(VTotalBom.ContentQty,0) <> 0 AND Round(IsNull(VTotalBom.ContentQty,0),3) > IsNull(Round(Pq.Weight,3),0) AND Pcl.ProductContentLineId IS NOT NULL
	 THEN L.Qty - Round(L.Qty * (VTotalBom.ContentQty - IsNull(Pq.Weight,0)) / VTotalBom.ContentQty,3) ELSE  L.Qty END AS Qty, 
L.Qty AS ActualQty,L.ConsumptionPer, L.ProcessId, L.Dimension1Id, L.Dimension2Id,L.Dimension3Id, L.Dimension4Id, L.CreatedBy, L.ModifiedBy, L.CreatedDate, L.ModifiedDate, L.OMSId
FROM Web.BomDetails L 
LEFT JOIN Web.Products BomProduct ON L.BaseProductId = BomProduct.ProductId
LEFT JOIN Web.ProductGroups Pg ON BomProduct.ProductName = Pg.ProductGroupName
LEFT JOIN (SELECT ProductGroupId, Max(ProductId) AS ProductId FROM Web.Products GROUP BY ProductGroupId) AS P ON Pg.ProductGroupId = P.ProductGroupId
LEFT JOIN Web.Products  ProductBomProduct ON BomProduct.ReferenceDocId = ProductBomProduct.ProductId AND BomProduct.ReferenceDocTypeId = 646
LEFT JOIN Web.FinishedProduct Fp ON IsNull(ProductBomProduct.ProductId,P.ProductId) = Fp.ProductId
LEFT JOIN Web.ProductQualities Pq ON Fp.ProductQualityId = Pq.ProductQualityId
LEFT JOIN Web.Products P2 ON L.ProductId = P2.ProductId
LEFT JOIN Web.ProductContentHeaders Pch ON Fp.FaceContentId = Pch.ProductContentHeaderId
LEFT JOIN Web.ProductContentLines Pcl ON Pch.ProductContentHeaderId = Pcl.ProductContentHeaderId
		AND P2.ProductGroupId = Pcl.ProductGroupId
LEFT JOIN (
	SELECT L.BaseProductId,
	Sum(CASE WHEN Pcl.ProductContentLineId IS NOT NULL THEN L.Qty ELSE 0 END) AS ContentQty,
	Sum(CASE WHEN Pcl.ProductContentLineId IS NULL THEN L.Qty ELSE 0 END) AS NonContentQty,
	Sum(L.Qty) AS TotalBomQty
	FROM Web.BomDetails L 
	LEFT JOIN Web.Products BomProduct ON L.BaseProductId = BomProduct.ProductId
	LEFT JOIN Web.ProductGroups Pg ON BomProduct.ProductName = Pg.ProductGroupName
	LEFT JOIN (SELECT ProductGroupId, Max(ProductId) AS ProductId FROM Web.Products GROUP BY ProductGroupId) AS P ON Pg.ProductGroupId = P.ProductGroupId
	LEFT JOIN Web.Products  ProductBomProduct ON BomProduct.ReferenceDocId = ProductBomProduct.ProductId AND BomProduct.ReferenceDocTypeId = 646
	LEFT JOIN Web.FinishedProduct Fp ON IsNull(ProductBomProduct.ProductId,P.ProductId) = Fp.ProductId
	LEFT JOIN Web.Products Pp ON Fp.ProductId = Pp.ProductId
	LEFT JOIN Web.Products P2 ON L.ProductId = P2.ProductId
	LEFT JOIN Web.ProductContentHeaders Pch ON Fp.FaceContentId = Pch.ProductContentHeaderId
	LEFT JOIN Web.ProductContentLines Pcl ON Pch.ProductContentHeaderId = Pcl.ProductContentHeaderId
		AND P2.ProductGroupId = Pcl.ProductGroupId
	GROUP BY L.BaseProductId
) AS VTotalBom ON L.BaseProductId = VTotalBom.BaseProductId
