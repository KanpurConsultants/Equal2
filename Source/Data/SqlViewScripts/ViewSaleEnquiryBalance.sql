CREATE VIEW [Web].[ViewSaleEnquiryBalance] AS  
SELECT VSaleEnquiry.SaleEnquiryLineId, 
IsNull(Sum(VSaleEnquiry.Qty),0) AS BalanceQty, IsNull(Sum(VSaleEnquiry.Rate),0) AS Rate, 
IsNull(Sum(VSaleEnquiry.Qty),0) * IsNull(Sum(VSaleEnquiry.Rate),0) AS BalanceAmount, 
Max(VSaleEnquiry.CurrencyId) AS CurrencyId, Max(VSaleEnquiry.SiteId) AS SiteId,
Max(VSaleEnquiry.SaleEnquiryHeaderId) AS SaleEnquiryHeaderId, Max(VSaleEnquiry.SaleEnquiryNo) AS SaleEnquiryNo,  
Max(VSaleEnquiry.ProductId) AS ProductId, Max(VSaleEnquiry.BuyerId) AS BuyerId, Max(VSaleEnquiry.DocDate) AS OrderDate, Max(VSaleEnquiry.DueDate) AS DueDate,
Max(VSaleEnquiry.Priority) AS Priority,
Max(VSaleEnquiry.Dimension1Id)  Dimension1Id, Max(VSaleEnquiry.Dimension2Id)  Dimension2Id, Max(VSaleEnquiry.Dimension3Id)  Dimension3Id, Max(VSaleEnquiry.Dimension4Id)  Dimension4Id, Max(VSaleEnquiry.DivisionId)  DivisionId
FROM  
( 
SELECT H.SiteId, L.SaleEnquiryLineId, H.DocTypeId AS ReferenceDocTypeId,  L.Qty AS Qty , L.Rate , H.CurrencyId, H.SaleEnquiryHeaderId, H.DocNo AS SaleEnquiryNo, L.ProductId, H.SaleToBuyerId AS BuyerId, H.DocDate, H.DueDate, H.Priority, L.Dimension1Id, L.Dimension2Id,L.Dimension3Id, L.Dimension4Id, H.DivisionId   
FROM Web.SaleEnquiryLines L WITH (Nolock)
LEFT JOIN Web.SaleEnquiryHeaders H WITH (Nolock) ON L.SaleEnquiryHeaderId = H.SaleEnquiryHeaderId 
UNION ALL 
SELECT NULL AS SiteId, L.ReferenceDocLineId AS SaleEnquiryLineId, L.ReferenceDocTypeId,  - L.Qty, 0 AS Rate ,NULL AS CurrencyId, NULL AS SaleEnquiryHeaderId, NULL AS SaleEnquiryNo, NULL AS ProductId, NULL AS BuyerId, NULL AS DocDate  , NULL AS DueDate, NULL AS Priority , NULL AS Dimension1Id, NULL AS Dimension2Id, NULL AS Dimension3Id, NULL AS Dimension4Id,NULL As DivisionId
FROM  Web.SaleOrderLines L  WITH (Nolock)
) AS VSaleEnquiry 
GROUP BY VSaleEnquiry.SaleEnquiryLineId, VSaleEnquiry.ReferenceDocTypeId
HAVING IsNull(Sum(VSaleEnquiry.Qty),0) > 0