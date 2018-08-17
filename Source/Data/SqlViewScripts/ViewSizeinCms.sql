CREATE VIEW [Web].[ViewSizeinCms] AS   
SELECT S.SizeId, convert(NVARCHAR,CL.Cms)+'X'+convert(NVARCHAR,CW.Cms) AS SizeName, CL.Cms AS Length, CW.Cms AS Width,
CL.Cms * CW.Cms AS Area
FROM web.Sizes S WITH (Nolock)
LEFT JOIN web.FeetConversionToCms CL WITH (Nolock) ON CL.Feet = S.Length AND CL.Inch = S.LengthFraction  
LEFT JOIN web.FeetConversionToCms CW WITH (Nolock) ON CW.Feet = S.Width  AND CW.Inch = S.WidthFraction