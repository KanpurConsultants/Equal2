IF OBJECT_ID ('Web.spCarpetMaster_MakeCustomProductName_GetCustomCarpetSkuName') IS NOT NULL
	DROP PROCEDURE Web.spCarpetMaster_MakeCustomProductName_GetCustomCarpetSkuName
GO

CREATE PROCEDURE [Web].spCarpetMaster_MakeCustomProductName_GetCustomCarpetSkuName 
(@ProductGroupName VARCHAR(50), @StandardSizeName VARCHAR(50), @ColourName VARCHAR(50))
AS 
SELECT Replace(@ProductGroupName,'-','') + '-' + @StandardSizeName + '-' + @ColourName AS ProductName
GO

