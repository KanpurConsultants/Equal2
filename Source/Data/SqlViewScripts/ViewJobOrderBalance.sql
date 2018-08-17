CREATE VIEW Web.ViewJobOrderBalance AS 
SELECT L.JobOrderLineId, 
L.Qty - (IsNull(VReceive.ReceiveQty,0) - IsNULL(VReturn.ReturnQty,0)) - IsNull(VCancel.CancelQty,0) + IsNull(VQtyAmendment.AmendmentQty,0) AS BalanceQty,
L.Rate + IsNULL(VRateAmendment.AmendmentRate,0) AS Rate,
(L.Qty - (IsNull(VReceive.ReceiveQty,0) - IsNULL(VReturn.ReturnQty,0)) - IsNull(VCancel.CancelQty,0) + IsNull(VQtyAmendment.AmendmentQty,0)) * (L.Rate + IsNULL(VRateAmendment.AmendmentRate,0)) AS BalanceAmount,
L.JobOrderHeaderId, 
H.DocNo AS JobOrderNo, L.ProductUidId, L.ProductId, L.Dimension1Id, L.Dimension2Id, L.Dimension3Id, L.Dimension4Id, H.JobWorkerId, H.SiteId, H.DivisionId, 
H.DocDate AS OrderDate, H.ProcessId 
FROM Web.JobOrderHeaders H WITH (NoLock) 
LEFT JOIN Web.JobOrderLines L WITH (NoLock) ON L.JobOrderHeaderId = H.JobOrderHeaderId
LEFT JOIN (
	SELECT L.JobOrderLineId, Sum(L.Qty + IsNull(L.LossQty,0)) AS ReceiveQty
	FROM Web.JobReceiveLines L WITH (NoLock)
	GROUP BY L.JobOrderLineId
) AS VReceive ON L.JobOrderLineId = VReceive.JobOrderLineId
LEFT JOIN (
	SELECT L.JobOrderLineId, Sum(L.Qty) AS CancelQty
	FROM Web.JobOrderCancelLines L WITH (NoLock)
	GROUP BY L.JobOrderLineId
) AS VCancel ON L.JobOrderLineId = VCancel.JobOrderLineId
LEFT JOIN (
	SELECT Jrl.JobOrderLineId, Sum(L.Qty) AS ReturnQty
	FROM Web.JobReturnLines L WITH (NoLock)
	LEFT JOIN Web.JobReceiveLines Jrl WITH (NoLock) ON L.JobReceiveLineId = Jrl.JobReceiveLineId
	GROUP BY Jrl.JobOrderLineId
) AS VReturn ON L.JobOrderLineId = VReturn.JobOrderLineId
LEFT JOIN (
	SELECT L.JobOrderLineId, Sum(L.Qty) AS AmendmentQty
	FROM Web.JobOrderQtyAmendmentLines L WITH (NoLock)
	GROUP BY L.JobOrderLineId
) AS VQtyAmendment ON L.JobOrderLineId = VQtyAmendment.JobOrderLineId
LEFT JOIN (
	SELECT L.JobOrderLineId, Sum(L.Rate) AS AmendmentRate
	FROM Web.JobOrderRateAmendmentLines L WITH (NoLock)
	GROUP BY L.JobOrderLineId
) AS VRateAmendment ON L.JobOrderLineId = VRateAmendment.JobOrderLineId
WHERE H.Status <> 5
AND L.Qty - (IsNull(VReceive.ReceiveQty,0) - IsNULL(VReturn.ReturnQty,0)) - IsNull(VCancel.CancelQty,0) + IsNull(VQtyAmendment.AmendmentQty,0) >0


