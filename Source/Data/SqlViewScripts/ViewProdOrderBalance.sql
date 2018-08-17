CREATE VIEW [Web].[ViewProdOrderBalance] AS 
SELECT L.ProdOrderLineId, 
IsNull(L.Qty,0) - IsNull(VProdOrderCancel.Qty,0) - (IsNull(VJobOrder.Qty,0) + IsNull(VJobOrderAmendment.Qty,0) - IsNull(VJobOrderCancel.Qty,0)) AS BalanceQty,
H.ProdOrderHeaderId, H.DocNo AS ProdOrderNo, H.DocTypeId, H.SiteId, H.DivisionId,
L.ProductId, H.DocDate AS IndentDate, L.Dimension1Id, L.Dimension2Id,
L.Dimension3Id, L.Dimension4Id,
L.ReferenceDocTypeId, L.ReferenceDocLineId, H.BuyerId
FROM Web.ProdOrderHeaders H 
LEFT JOIN Web.ProdOrderLines L ON H.ProdOrderHeaderId = L.ProdOrderHeaderId
LEFT JOIN (
	SELECT L.ProdOrderLineId, Sum(L.Qty) AS Qty
	FROM Web.ProdOrderCancelLines L 
	GROUP BY L.ProdOrderLineId
) AS VProdOrderCancel ON L.ProdOrderLineId = VProdOrderCancel.ProdOrderLineId
LEFT JOIN (
	SELECT L.ProdOrderLineId, Sum(L.Qty) AS Qty
	FROM Web.JobOrderLines L 
	GROUP BY L.ProdOrderLineId
) AS VJobOrder ON L.ProdOrderLineId = VJobOrder.ProdOrderLineId
LEFT JOIN (
	SELECT Jol.ProdOrderLineId, Sum(L.Qty) AS Qty
	FROM Web.JobOrderCancelLines L 
	LEFT JOIN Web.JobOrderLines Jol ON L.JobOrderLineId = Jol.JobOrderLineId
	GROUP BY Jol.ProdOrderLineId
) AS VJobOrderCancel ON L.ProdOrderLineId = VJobOrderCancel.ProdOrderLineId
LEFT JOIN (
	SELECT Joll.ProdOrderLineId, Sum(L.Qty) AS Qty
	FROM Web.JobOrderQtyAmendmentLines L 
	LEFT JOIN Web.JobOrderLines Joll ON L.JobOrderLineId = Joll.JobOrderLineId
	GROUP BY Joll.ProdOrderLineId
) AS VJobOrderAmendment ON L.ProdOrderLineId = VJobOrderAmendment.ProdOrderLineId
WHERE IsNull(L.Qty,0) - IsNull(VProdOrderCancel.Qty,0) - (IsNull(VJobOrder.Qty,0) + IsNull(VJobOrderAmendment.Qty,0) - IsNull(VJobOrderCancel.Qty,0)) > 0

