CREATE VIEW  Web.ViewSaleInvoiceLine AS 
SELECT L.SaleInvoiceHeaderId, L.SaleInvoiceLineId, PL.ProductUidId, L.ProductID, L.Dimension1Id, L.Dimension2Id,L.Dimension3Id, L.Dimension4Id, PL.Specification , 
L.SaleOrderLineId , L.Qty, PL.BaleNo, L.ProductInvoiceGroupId,
L.DealQty, L.DealUnitId, PL.GrossWeight, PL.NetWeight, L.Rate, L.Amount, L.Remark, L.Sr   
FROM Web.SaleInvoiceLines L 
LEFT JOIN   Web.SaleDispatchLines DL ON L.SaleDispatchLineId = DL.SaleDispatchLineId 
LEFT JOIN   Web.PackingLines PL ON DL.PackingLineId = PL.PackingLineId