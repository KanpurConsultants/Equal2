CREATE VIEW Web.Std_PersonRegistrations 
AS 	SELECT  PV.*
				FROM 
					(SELECT R.PersonId AS CustomerId, 'Party ' + R.RegistrationType AS RegType, R.RegistrationNo   
					 FROM Web.PersonRegistrations R
					) R
				Pivot
				(  
					MAX(R.RegistrationNo) FOR R.RegType  IN ([Party TIN NO],[Party PAN NO],[Party AADHAR NO], [Party GST NO],[Party CST NO])
				) AS PV