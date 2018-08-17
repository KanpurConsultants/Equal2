CREATE Procedure  [Web].[ProcCompanyDetail] 
(
@SiteId INT, 
@DivisionId INT = NULL,
@DocDate VARCHAR(20) =NULL    
)
AS 
BEGIN


IF ( @DivisionId IS NOT NULL  AND @DivisionId <> 0 )
BEGIN 
SET @DivisionId = @DivisionId

SELECT  (SELECT SiteCode  FROM Web.Sites WHERE SiteId = @SiteId) SiteName, 
VDC.DivisionName AS DivisionName, VDC.CompanyName, VDC.CompanyAddress, VDC.CompanyCity, '221401' AS CompanyPinNo,
VDC.CompanyPhoneNo, VDC.CompanyTinNo, VDC.CompanyCSTNo, VDC.CompanyFaxNo,VDC.CountryName AS CompanyCountry,
vdc.ReportHeaderTextRight1, vdc.ReportHeaderTextRight2, vdc.ReportHeaderTextRight3, vdc.ReportHeaderTextRight4,
VDC.LogoBlob  AS CompanyLogoPath
FROM web.ViewDivisionCompany VDC
WHERE VDC.DivisionId  = @DivisionId
END 
ELSE
BEGIN 
SELECT @DivisionId = DefaultDivisionId   FROM Web.Sites WHERE SiteId = @SiteId

SELECT  (SELECT SiteCode  FROM Web.Sites WHERE SiteId = @SiteId) SiteName, 
'Consolidated' AS DivisionName, VDC.CompanyName, VDC.CompanyAddress, VDC.CompanyCity,'221401' AS CompanyPinNo,
VDC.CompanyPhoneNo, VDC.CompanyTinNo, VDC.CompanyCSTNo, VDC.CompanyFaxNo, VDC.CountryName AS CompanyCountry,
VDC.LogoBlob AS CompanyLogoPath
FROM web.ViewDivisionCompany VDC
WHERE VDC.DivisionId  = @DivisionId

END 
End

