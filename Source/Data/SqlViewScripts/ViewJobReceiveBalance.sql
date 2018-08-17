CREATE VIEW [Web].[ViewJobReceiveBalance] AS 
SELECT L.JobReceiveLineId, L.JobOrderLineId, Jol.JobOrderHeaderId,
IsNull(L.PassQty,0) - IsNull(VRet.Qty,0) - IsNull(VInvoice.Qty,0) AS BalanceQty,
L.JobReceiveHeaderId, H.DocNo AS JobReceiveNo, Joh.DocNo AS JobOrderNo,
Jol.ProductId, Jol.Dimension1Id, Jol.Dimension2Id, Jol.Dimension3Id, Jol.Dimension4Id,H.JobWorkerId, H.DocDate AS OrderDate, 
H.DocTypeId, H.DivisionId, H.SiteId
FROM Web.JobReceiveHeaders H WITH (NoLock)
LEFT JOIN Web.JobReceiveLines L WITH (NoLock) ON L.JobReceiveHeaderId = H.JobReceiveHeaderId
LEFT JOIN Web.JobOrderLines Jol WITH (NoLock) ON L.JobOrderLineId = Jol.JobOrderLineId
LEFT JOIN Web.JobOrderHeaders Joh WITH (NoLock) ON Jol.JobOrderHeaderId = Joh.JobOrderHeaderId
LEFT JOIN (
	SELECT L.JobReceiveLineId, Sum(L.Qty) AS Qty
	FROM Web.JobReturnLines L WITH (NoLock)
	GROUP BY L.JobReceiveLineId
) AS VRet ON L.JobReceiveLineId = VRet.JobReceiveLineId
LEFT JOIN (
	SELECT L.JobReceiveLineId, Sum(Jrl.PassQty) AS Qty
	FROM Web.JobInvoiceLines L WITH (NoLock)
	LEFT JOIN Web.JobReceiveLines Jrl ON L.JobReceiveLineId = Jrl.JobReceiveLineId
	GROUP BY L.JobReceiveLineId
) AS VInvoice ON L.JobReceiveLineId = VInvoice.JobReceiveLineId
WHERE IsNull(L.PassQty,0) - IsNull(VRet.Qty,0) - IsNull(VInvoice.Qty,0) > 0