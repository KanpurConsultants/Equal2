Create VIEW [Web].[_People] as
SELECT PersonID, Name+' {'+Code+'}' AS Name, Suffix, Code, Description,(CASE WHEN Phone IS NULL OR  Phone='' THEN Mobile ELSE Phone END) AS  Phone,(CASE WHEN Mobile IS NULL OR  Mobile='' THEN Phone ELSE Mobile END) AS  Mobile, Email, IsActive, Tags, ImageFolderName, ImageFileName, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate, OMSId, ApplicationUser_Id, IsSisterConcern, Nature, DocTypeId
FROM Web.People
