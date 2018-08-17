CREATE VIEW Web._DocumentTypeSettings as
SELECT 
DTS.DocumentTypeSettingsId,DT.DocumentTypeId,
IsNull(Dts.DocIDCaption,'Doc.') AS DocIdCaption,
CASE WHEN DTS.ProductCaption IS NULL THEN 'Product' ELSE DTS.ProductCaption END AS ProductCaption ,
CASE WHEN DTS.ProductGroupCaption IS NULL THEN 'Group' ELSE DTS.ProductGroupCaption END AS ProductGroupCaption,
CASE WHEN DTS.ProductCategoryCaption IS NULL THEN 'Product Category' ELSE DTS.ProductCategoryCaption END AS ProductCategoryCaption ,
CASE WHEN DTS.Dimension1Caption IS NULL THEN 'Dimension1' ELSE DTS. Dimension1Caption END AS Dimension1Caption,
CASE WHEN DTS.Dimension2Caption IS NULL THEN 'Dimension2' ELSE DTS.Dimension2Caption END  AS Dimension2Caption,
CASE WHEN DTS.Dimension3Caption IS NULL THEN 'Dimension3' ELSE  DTS.Dimension3Caption END AS Dimension3Caption,
CASE WHEN DTS.Dimension4Caption IS NULL THEN 'Dimension4' ELSE DTS.Dimension4Caption END  AS Dimension4Caption,
DTS.CreatedBy, DTS.ModifiedBy, DTS.CreatedDate, DTS.ModifiedDate, DTS.OMSId, 
CASE WHEN DTS.PartyCaption IS NULL THEN 'Person' ELSE DTS.PartyCaption END AS PartyCaption ,
CASE WHEN DTS.ProductUidCaption IS NULL THEN 'Bar Code' ELSE DTS.ProductUidCaption END AS ProductUidCaption,
CASE WHEN DTS.ContraDocTypeCaption IS NULL THEN 'Ref No' ELSE DTS.ContraDocTypeCaption END AS ContraDocTypeCaption,
CASE WHEN DTS.DealQtyCaption IS NULL THEN 'Deal Qty' ELSE DTS.DealQtyCaption END AS DealQtyCaption,
CASE WHEN DTS.WeightCaption IS NULL THEN 'Weight' ELSE DTS.WeightCaption END AS WeightCaption,
CASE WHEN DTS.CostCenterCaption IS NULL THEN 'Purja No' ELSE DTS.CostCenterCaption END AS CostCenterCaption,
CASE WHEN DTS.SpecificationCaption IS NULL THEN 'Specification' ELSE DTS.SpecificationCaption END AS SpecificationCaption,
NULL  AS SignatoryleftCaption,
NULL AS SignatoryMiddleCaption,
NULL AS SignatoryRightCaption, NULL AS IsVisibleCompanyOnRightSignatory,
NULL  AS PrintSpecification,NULL  AS PrintProductGroup,NULL  AS PrintProductdescription 
/*isnull(DTS.SignatoryleftCaption,'') AS SignatoryleftCaption,
isnull(DTS.SignatoryMiddleCaption,'') AS SignatoryMiddleCaption,
isnull(DTS.SignatoryRightCaption,'Authorised Signatory') AS SignatoryRightCaption, IsNull(Dts.IsVisibleCompanyOnRightSignatory,1) AS IsVisibleCompanyOnRightSignatory,
isnull(DTS.PrintSpecification,0) AS PrintSpecification,isnull(PrintProductGroup,0) AS PrintProductGroup,isnull(PrintProductdescription,0) AS PrintProductdescription 
*/

 FROM Web.DocumentTypes DT
LEFT JOIN  Web.DocumentTypeSettings DTS ON DTS.DocumentTypeId=DT.DocumentTypeId
