CREATE VIEW [Web].[ViewDivisionCompany] AS  
SELECT D.DivisionId,  D.DivisionName, C.CompanyName, C.Address AS CompanyAddress, CT.CityName AS CompanyCity,
C.Phone AS CompanyPhoneNo, C.TinNo AS CompanyTinNo, C.CstNo AS CompanyCSTNo, C.Fax  AS CompanyFaxNo,
ST.StateName, CNT.CountryName, 
D.LogoBlob,  D.ReportHeaderTextRight1, D.ReportHeaderTextRight2,
D.ReportHeaderTextRight3, D.ReportHeaderTextRight4   
FROM web.Divisions  D
LEFT JOIN Web.Companies C ON C.CompanyId = D.CompanyId
LEFT JOIN web.Cities CT ON CT.CityId = C.CityId
LEFT JOIN web.States ST ON ST.StateId = CT.StateId 
LEFT JOIN web.Countries CNT ON CNT.CountryId = ST.CountryId