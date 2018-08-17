CREATE VIEW Web.ViewProductGroupContents AS 

SELECT Fp.ProductId, 
Sum(CASE WHEN Pcl.ProductContentLineId IS NOT NULL THEN L.Qty ELSE 0 END) AS ContentQty,
Sum(CASE WHEN Pcl.ProductContentLineId IS NULL THEN L.Qty ELSE 0 END) AS NonContentQty,
Sum(L.Qty) AS TotalBomQty
FROM Web.ViewBomDetailsForWeavingReceivePosting L 
LEFT JOIN Web.BomDetails Bd ON L.BaseProductId = Bd.ProductId
LEFT JOIN Web.FinishedProduct Fp ON Bd.BaseProductId = Fp.ProductId
LEFT JOIN Web.Products P2 ON L.ProductId = P2.ProductId
LEFT JOIN Web.ProductContentHeaders Pch ON Fp.FaceContentId = Pch.ProductContentHeaderId
LEFT JOIN Web.ProductContentLines Pcl ON Pch.ProductContentHeaderId = Pcl.ProductContentHeaderId
	AND P2.ProductGroupId = Pcl.ProductGroupId
GROUP BY Fp.ProductId