using System.Collections.Generic;
using System.Web.Mvc;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System;
using Jobs.Constants.ProductSizeTypes;
using Jobs.Constants.Country;
using Jobs.Constants.ProductDesign;
using Jobs.Constants.DocumentType;
using Jobs.Constants.Division;
using Jobs.Constants.Site;
using Jobs.Constants.Process;
using Jobs.Constants.City;
using Jobs.Constants.LedgerAccountGroup;
using Jobs.Constants.ProductType;
using Jobs.Constants.RugProductType;
using System.Reflection;
using System.Configuration;


namespace Data.Models
{
    [Authorize]
    public class UpdateTableStructure
    {
        string mQry = "";
        string path = @"D:\Active Projects\Web\Equal2\Source\Data\";
        //path = ConfigurationManager.AppSettings["ScriptFilePath"];
        public void UpdateTables()
        {

                //AddFields("LedgerAccountGroups", "ParentLedgerAccountGroupId", "INT", "LedgerAccountGroups");
                //AddFields("LedgerAccountGroups", "BSNature", "NVARCHAR (20)");

                //try
                //{
                //    if ((int)ExecuteScaler("SELECT Count(*) AS Cnt FROM INFORMATION_SCHEMA.Tables WHERE TABLE_NAME = 'SalaryLineReferences'") == 0)
                //    {
                //        mQry = @"
                //            CREATE TABLE Web.SalaryLineReferences
                //         (
                //         SalaryLineId                   INT NOT NULL,
                //         ReferenceDocTypeId             INT,
                //            ReferenceDocId                 INT NOT NULL,
                //         ReferenceDocLineId             INT NOT NULL,                  
                //            CONSTRAINT [PK_Web.SalaryLineReferences] PRIMARY KEY (SalaryLineId,ReferenceDocTypeId,ReferenceDocId,ReferenceDocLineId),
                //         CONSTRAINT [FK_Web.SalaryLineReferences_Web.SalaryLines_SalaryLineIdId] FOREIGN KEY (SalaryLineId) REFERENCES Web.SalaryLines (SalaryLineId),
                //         CONSTRAINT [FK_Web.SalaryLineReferences_Web.DocumentType_ReferenceDocTypeId] FOREIGN KEY (ReferenceDocTypeId) REFERENCES Web.DocumentTypes (DocumentTypeId)
                //         )

                //        CREATE INDEX [IX_SalaryLineId]
                //         ON Web.SalaryLineReferences (SalaryLineId)


                //        CREATE INDEX [IX_ReferenceDocTypeId]
                //         ON Web.SalaryLineReferences (ReferenceDocTypeId)


                //        CREATE INDEX [IX_ReferenceDocId]
                //         ON Web.SalaryLineReferences (ReferenceDocId)

                //        CREATE INDEX [IX_ReferenceDocLineId]
                //         ON Web.SalaryLineReferences (ReferenceDocLineId)

                //            ";
                //        ExecuteQuery(mQry);
                //    }
                //}
                //catch (Exception ex)
                //{
                //    RecordError(ex);
                //}
              
            
            //DataCorrection();
            InitializeUserTables();
            InitializePersonTables();
            InitializeSettingsTables();
            InitializeSqlProcedureScripts();
            InitializeSqlFunctionScripts();
            InitializeSqlViewScripts();

        }
        public void AddFields(string TableName, string FieldName, string DataType, string ForeignKeyTable = null)
        {
            try
            {
                if ((int)ExecuteScaler("SELECT Count(*) AS Cnt FROM INFORMATION_SCHEMA.Columns WHERE COLUMN_NAME =  '" + FieldName + "' AND TABLE_NAME = '" + TableName + "'") == 0)
                {
                    mQry = "ALTER TABLE Web." + TableName + " ADD " + FieldName + " " + DataType;
                    ExecuteQuery(mQry);

                    if (ForeignKeyTable != "" && ForeignKeyTable != null)
                    {
                        string ForeignKeyTablePrimaryField = "";
                        mQry = " SELECT column_name " +
                                " FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC " +
                                " INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KU ON TC.CONSTRAINT_TYPE = 'PRIMARY KEY' AND TC.CONSTRAINT_NAME = KU.CONSTRAINT_NAME " +
                                " and ku.table_name= '" + ForeignKeyTable + "' " +
                                " ORDER BY KU.TABLE_NAME, KU.ORDINAL_POSITION ";
                        ForeignKeyTablePrimaryField = (string)ExecuteScaler(mQry);

                        mQry = " ALTER TABLE Web." + TableName + "  ADD CONSTRAINT [FK_Web." + TableName + "_Web." + ForeignKeyTable + "_" + FieldName + "] FOREIGN KEY (" + FieldName + ") REFERENCES Web." + ForeignKeyTable + "(" + ForeignKeyTablePrimaryField + ")";
                        ExecuteQuery(mQry);
                    }
                }
            }
            catch (Exception ex)
            {
                RecordError(ex);
            }
        }
        public void DropFields(string TableName, string FieldName)
        {
            string Foreign_Key_Name = "";
            string Index_Name = "";
            try
            {
                if ((int)ExecuteScaler("SELECT Count(*) AS Cnt FROM INFORMATION_SCHEMA.Columns WHERE COLUMN_NAME =  '" + FieldName + "' AND TABLE_NAME = '" + TableName + "'") != 0)
                {
                    mQry = @"SELECT fk.name AS FK_name
                                FROM sys.objects o1
                                INNER JOIN sys.foreign_keys fk ON o1.object_id = fk.parent_object_id
                                INNER JOIN sys.foreign_key_columns fkc ON fk.object_id = fkc.constraint_object_id
                                INNER JOIN sys.columns c1 ON fkc.parent_object_id = c1.object_id
                                    AND fkc.parent_column_id = c1.column_id
                                WHERE o1.name = '" + TableName + "' AND c1.name = '" + FieldName + "'";
                    Foreign_Key_Name = (string)ExecuteScaler(mQry);
                    if (Foreign_Key_Name != null && Foreign_Key_Name != "")
                    {
                        mQry = "ALTER TABLE Web." + TableName + " DROP CONSTRAINT " + "[" + Foreign_Key_Name + "]";
                        ExecuteQuery(mQry);
                    }


                    mQry = @"SELECT ind.name
                            FROM sys.indexes ind 
                            INNER JOIN sys.index_columns ic ON  ind.object_id = ic.object_id and ind.index_id = ic.index_id 
                            INNER JOIN sys.columns col ON ic.object_id = col.object_id and ic.column_id = col.column_id 
                            INNER JOIN sys.tables t ON ind.object_id = t.object_id 
                            WHERE ind.is_primary_key = 0 
                            AND ind.is_unique = 0 
                            AND ind.is_unique_constraint = 0 
                            AND t.is_ms_shipped = 0 
                            AND t.name =  '" + TableName + "' AND col.name = '" + FieldName + "'";
                    Index_Name = (string)ExecuteScaler(mQry);
                    if (Index_Name != null && Index_Name != "")
                    {
                        mQry = "DROP Index Web." + TableName + "." + "[" + Index_Name + "]";
                        ExecuteQuery(mQry);
                    }


                    mQry = "ALTER TABLE Web." + TableName + " DROP COLUMN " + FieldName + " ";
                    ExecuteQuery(mQry);
                }
            }
            catch (Exception ex)
            {
                RecordError(ex);
            }
        }
        public void RenameFields(string TableName, string OldFieldName, string NewFieldName)
        {
            try
            {
                if ((int)ExecuteScaler("SELECT Count(*) AS Cnt FROM INFORMATION_SCHEMA.Columns WHERE COLUMN_NAME =  '" + OldFieldName + "' AND TABLE_NAME = '" + TableName + "'") > 0)
                {
                    mQry = "EXEC sp_rename 'Web." + TableName + "." + OldFieldName + "', '" + NewFieldName + "', 'COLUMN'";
                    ExecuteQuery(mQry);
                }
            }
            catch (Exception ex)
            {
                RecordError(ex);
            }
        }
        public void RecordError(Exception ex)
        {
            int CurrentSiteId = (int)System.Web.HttpContext.Current.Session["SiteId"];
            int CurrentDivisionId = (int)System.Web.HttpContext.Current.Session["DivisionId"];


            mQry = @"INSERT INTO Web.ActivityLogs (DocId, ActivityType, Narration, UserRemark, CreatedBy, CreatedDate, DocStatus, SiteId, DivisionId)
                    SELECT 0 AS DocId, 1 AS ActivityType, 'Update Table Structure' AS Narration, '" + ex.Message.Replace("'", "") + "' AS UserRemark, 'System' AS CreatedBy, getdate() AS CreatedDate, 0 As DocStatus, " + CurrentSiteId + " As SiteId, " + CurrentDivisionId + " As DivisionId ";
            ExecuteQuery(mQry);
        }
        public void ExecuteQuery(string Qry)
        {
            string ConnectionString = (string)System.Web.HttpContext.Current.Session["DefaultConnectionString"];

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(Qry);
                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();
            }
        }
        public object ExecuteScaler(string Qry)
        {
            object val = null;
            string ConnectionString = (string)System.Web.HttpContext.Current.Session["DefaultConnectionString"];

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(Qry);
                cmd.Connection = sqlConnection;
                val = cmd.ExecuteScalar();
            }
            return val;
        }
        public void DataCorrection()
        {
            try
            {
                mQry = @"UPDATE Web.JobReceiveLines
                        SET Web.JobReceiveLines.ProductId = V1.ProductId
                        FROM (
	                        SELECT L.JobReceiveLineId, Jol.ProductId
	                        FROM Web.JobReceiveLines L 
	                        LEFT JOIN Web.JobOrderLines Jol ON L.JobOrderLineId = Jol.JobOrderLineId
	                        WHERE L.JobOrderLineId IS NOT NULL
	                        AND L.ProductId IS NULL
                        ) AS V1 WHERE Web.JobReceiveLines.JobReceiveLineId = V1.JobReceiveLineId";
                ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                RecordError(ex);
            }


            try
            {
                mQry = @"UPDATE Web.JobReceiveLines
                        SET Web.JobReceiveLines.Dimension1Id = V1.Dimension1Id
                        FROM (
	                        SELECT L.JobReceiveLineId, Jol.Dimension1Id
	                        FROM Web.JobReceiveLines L 
	                        LEFT JOIN Web.JobOrderLines Jol ON L.JobOrderLineId = Jol.JobOrderLineId
	                        WHERE L.JobOrderLineId IS NOT NULL
	                        AND L.Dimension1Id IS NULL AND Jol.Dimension1Id IS NOT NULL
                        ) AS V1 WHERE Web.JobReceiveLines.JobReceiveLineId = V1.JobReceiveLineId";
                ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                RecordError(ex);
            }

            try
            {
                mQry = @"UPDATE Web.JobReceiveLines
                        SET Web.JobReceiveLines.Dimension2Id = V1.Dimension2Id
                        FROM (
	                        SELECT L.JobReceiveLineId, Jol.Dimension2Id
	                        FROM Web.JobReceiveLines L 
	                        LEFT JOIN Web.JobOrderLines Jol ON L.JobOrderLineId = Jol.JobOrderLineId
	                        WHERE L.JobOrderLineId IS NOT NULL
	                        AND L.Dimension2Id IS NULL AND Jol.Dimension2Id IS NOT NULL
                        ) AS V1 WHERE Web.JobReceiveLines.JobReceiveLineId = V1.JobReceiveLineId";
                ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                RecordError(ex);
            }

            try
            {
                mQry = @"UPDATE Web.JobReceiveLines
                        SET Web.JobReceiveLines.Dimension3Id = V1.Dimension3Id
                        FROM (
	                        SELECT L.JobReceiveLineId, Jol.Dimension3Id
	                        FROM Web.JobReceiveLines L 
	                        LEFT JOIN Web.JobOrderLines Jol ON L.JobOrderLineId = Jol.JobOrderLineId
	                        WHERE L.JobOrderLineId IS NOT NULL
	                        AND L.Dimension3Id IS NULL AND Jol.Dimension3Id IS NOT NULL
                        ) AS V1 WHERE Web.JobReceiveLines.JobReceiveLineId = V1.JobReceiveLineId";
                ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                RecordError(ex);
            }


            try
            {
                mQry = @"UPDATE Web.JobReceiveLines
                        SET Web.JobReceiveLines.Dimension4Id = V1.Dimension4Id
                        FROM (
	                        SELECT L.JobReceiveLineId, Jol.Dimension4Id
	                        FROM Web.JobReceiveLines L 
	                        LEFT JOIN Web.JobOrderLines Jol ON L.JobOrderLineId = Jol.JobOrderLineId
	                        WHERE L.JobOrderLineId IS NOT NULL
	                        AND L.Dimension4Id IS NULL AND Jol.Dimension4Id IS NOT NULL
                        ) AS V1 WHERE Web.JobReceiveLines.JobReceiveLineId = V1.JobReceiveLineId";
                ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                RecordError(ex);
            }



            try
            {
                if ((int)ExecuteScaler("SELECT Count(*)  FROM Web.ProductNatures WHERE ProductNatureName = 'Ledger Account'") == 0)
                {
                    mQry = @"INSERT INTO Web.ProductNatures (ProductNatureName, IsActive, IsSystemDefine, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate)
                            VALUES ('Ledger Account', 1, 0, 'System', 'System', getdate(), getdate())";
                    ExecuteQuery(mQry);
                }
            }
            catch (Exception ex)
            {
                RecordError(ex);
            }

            try
            {
                if ((int)ExecuteScaler("SELECT Count(*)  FROM Web.ProductTypes WHERE ProductTypeName = 'Ledger Account'") == 0)
                {
                    mQry = @"INSERT INTO Web.ProductTypes (ProductTypeName, ProductNatureId, IsCustomUI, IsActive, IsPostedInStock, IsSystemDefine, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate)
                            VALUES ('Ledger Account', (SELECT ProductNatureId  FROM Web.ProductNatures WHERE ProductNatureName = 'Ledger Account'), 0, 1, 1, 0, 'System', 'System', getdate(), getdate())";
                    ExecuteQuery(mQry);
                }
            }
            catch (Exception ex)
            {
                RecordError(ex);
            }


            try
            {
                if ((int)ExecuteScaler("SELECT Count(*)  FROM Web.ProductGroups WHERE ProductGroupName = 'Ledger Account'") == 0)
                {
                    mQry = @"INSERT INTO Web.ProductGroups (ProductGroupName, ProductTypeId, IsSystemDefine, IsActive, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate, RateDecimalPlaces)
                            VALUES ('Ledger Account', (SELECT ProductTypeId  FROM Web.ProductTypes WHERE ProductTypeName = 'Ledger Account'), 0, 1, 'System', 'System', getdate(), getdate(), 2)";
                    ExecuteQuery(mQry);
                }
            }
            catch (Exception ex)
            {
                RecordError(ex);
            }


            try
            {
                if ((int)ExecuteScaler("SELECT CHARACTER_MAXIMUM_LENGTH  FROM INFORMATION_SCHEMA.Columns WHERE TABLE_NAME = 'Products' AND COLUMN_NAME = 'ProductName'") == 50)
                {
                    mQry = @"ALTER TABLE Web.Products ALTER COLUMN ProductName NVARCHAR(100) NOT NULL";
                    ExecuteQuery(mQry);
                }
            }
            catch (Exception ex)
            {
                RecordError(ex);
            }


            try
            {
                if ((int)ExecuteScaler("SELECT Count(*) FROM INFORMATION_SCHEMA.Columns WHERE TABLE_NAME = 'JobReceiveHeaders' AND COLUMN_NAME = 'JobReceiveById' AND IS_NULLABLE = 'NO'") > 0)
                {
                    mQry = @"ALTER TABLE Web.JobReceiveHeaders ALTER COLUMN JobReceiveById INT NULL";
                    ExecuteQuery(mQry);
                }
            }
            catch (Exception ex)
            {
                RecordError(ex);
            }

            try
            {
                if ((int)ExecuteScaler("SELECT Count(*) FROM INFORMATION_SCHEMA.Columns WHERE TABLE_NAME = 'JobReceiveQAHeaders' AND COLUMN_NAME = 'QAById' AND IS_NULLABLE = 'NO'") > 0)
                {
                    mQry = @"ALTER TABLE Web.JobReceiveQAHeaders ALTER COLUMN QAById INT NULL";
                    ExecuteQuery(mQry);
                }
            }
            catch (Exception ex)
            {
                RecordError(ex);
            }


            try
            {
                mQry = @"INSERT INTO Web.Products (ProductCode, ProductName, ProductDescription, ProductSpecification, StandardCost, ProductGroupId, SalesTaxGroupProductId, DrawBackTariffHeadId, UnitId, DivisionId, ImageFolderName, ImageFileName, StandardWeight, Tags, CBM, IsActive, IsSystemDefine, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate, ReferenceDocTypeId, ReferenceDocId, OMSId, Discriminator, PurchaseProduction, CheckSum, ProductPhotoName, Photo, GrossWeight, ProfitMargin, CarryingCost, DocTypeId, ProductCategoryId, SaleRate, Dimension1, DefaultDimension1Id, DefaultDimension2Id, DefaultDimension3Id, DefaultDimension4Id, DiscontinueDate, DiscontinueReason, SalesTaxProductCodeId)
                        SELECT SubString(A.LedgerAccountName,1,50) AS ProductCode, A.LedgerAccountName, A.LedgerAccountName,
                        NULL AS ProductSpecification, 0 AS StandardCost, 
                        (SELECT ProductGroupId  FROM Web.ProductGroups WHERE ProductGroupName  = 'Ledger Account') AS ProductGroupId, 
                        (SELECT ChargeGroupProductId  FROM Web.ChargeGroupProducts WHERE ChargeGroupProductName = 'GST 5%') AS SalesTaxGroupProductId, 
                        NULL AS DrawBackTariffHeadId, 'Nos' AS UnitId, 1 AS DivisionId, 
                        NULL AS ImageFolderName, NULL AS ImageFileName, 0 AS StandardWeight, NULL AS Tags, NULL AS CBM, 
                        1 AS IsActive, 1 AS IsSystemDefine, A.CreatedBy, A.ModifiedBy, A.CreatedDate, A.ModifiedDate, 
                        NULL AS ReferenceDocTypeId, NULL AS ReferenceDocId, NULL AS OMSId, NULL AS Discriminator, 
                        NULL AS PurchaseProduction, NULL AS CheckSum, NULL AS ProductPhotoName, NULL AS Photo, 
                        0 AS GrossWeight, 0 AS ProfitMargin, 0 AS CarryingCost, 
                        NULL AS DocTypeId, NULL AS ProductCategoryId, 0 AS SaleRate, NULL AS Dimension1, 
                        NULL AS DefaultDimension1Id, NULL AS DefaultDimension2Id, NULL AS DefaultDimension3Id, NULL AS DefaultDimension4Id, 
                        NULL AS DiscontinueDate, NULL AS DiscontinueReason, NULL AS SalesTaxProductCodeId
                        FROM Web.LedgerAccounts A
                        LEFT JOIN Web.Products P ON A.LedgerAccountName = P.ProductName
                        WHERE A.PersonId IS NULL
                        AND P.ProductId IS NULL";
                ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                RecordError(ex);
            }

            try
            {
                mQry = @"UPDATE Web.LedgerAccounts
                        SET Web.LedgerAccounts.ProductId = V1.ProductId
                        FROM (
	                        SELECT A.LedgerAccountId, P.ProductId
	                        FROM Web.LedgerAccounts A
	                        LEFT JOIN Web.Products P ON A.LedgerAccountName = P.ProductName
	                        WHERE A.ProductId IS NULL
	                        AND P.ProductId IS NOT NULL
                        ) AS V1 WHERE Web.LedgerAccounts.LedgerAccountId = V1.LedgerAccountId";
                ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                RecordError(ex);
            }

            try
            {
                if ((int)ExecuteScaler("SELECT Count(*) FROM Web.UserRoles WHERE SiteId IS NULL") > 0)
                {
                    mQry = @"UPDATE Web.UserRoles SET SiteId = (SELECT SiteId FROM Web.Sites WHERE SiteCode = 'Main') Where SiteId Is Null";
                    ExecuteQuery(mQry);

                    mQry = " ALTER TABLE Web.UserRoles ALTER COLUMN SiteId INT NOT NULL";
                    ExecuteQuery(mQry);
                }
            }
            catch (Exception ex)
            {
                RecordError(ex);
            }

            try
            {
                if ((int)ExecuteScaler("SELECT Count(*) FROM Web.UserRoles WHERE DivisionId IS NULL") > 0)
                {
                    mQry = @"UPDATE Web.UserRoles SET DivisionId = (SELECT DivisionId FROM Web.Divisions WHERE DivisionName = 'Main') Where DivisionId Is Null";
                    ExecuteQuery(mQry);

                    mQry = " ALTER TABLE Web.UserRoles ALTER COLUMN DivisionId INT NOT NULL";
                    ExecuteQuery(mQry);
                }
            }
            catch (Exception ex)
            {
                RecordError(ex);
            }

            try
            {
                if ((int)ExecuteScaler("SELECT Count(*) FROM Web.UserRoles WHERE CreatedDate IS NULL") > 0)
                {
                    mQry = @"UPDATE Web.UserRoles SET CreatedDate = getdate() Where CreatedDate Is Null";
                    ExecuteQuery(mQry);

                    mQry = " ALTER TABLE Web.UserRoles ALTER COLUMN CreatedDate DATETIME NOT NULL";
                    ExecuteQuery(mQry);
                }
            }
            catch (Exception ex)
            {
                RecordError(ex);
            }

            try
            {
                if ((int)ExecuteScaler("SELECT Count(*) FROM Web.UserRoles WHERE ModifiedDate IS NULL") > 0)
                {
                    mQry = @"UPDATE Web.UserRoles SET ModifiedDate = getdate() Where ModifiedDate Is Null";
                    ExecuteQuery(mQry);

                    mQry = " ALTER TABLE Web.UserRoles ALTER COLUMN ModifiedDate DATETIME NOT NULL";
                    ExecuteQuery(mQry);

                }
            }
            catch (Exception ex)
            {
                RecordError(ex);
            }

            try
            {
                if ((int)ExecuteScaler("SELECT Count(*) FROM Web.DocumentCategories WHERE DocumentCategoryName = 'User'") == 0)
                {
                    mQry = @"INSERT INTO Web.DocumentCategories (DocumentCategoryName, IsActive, IsSystemDefine, OMSId)
                                VALUES ('User', 1, 0, NULL)";
                    ExecuteQuery(mQry);
                }
            }
            catch (Exception ex)
            {
                RecordError(ex);
            }

            try
            {
                if ((int)ExecuteScaler("SELECT Count(*) FROM Web.DocumentTypes WHERE DocumentTypeName = 'User'") == 0)
                {
                    mQry = @"INSERT INTO Web.DocumentTypes (DocumentTypeShortName, DocumentTypeName, DocumentCategoryId, IsSystemDefine, IsActive, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate)
                            VALUES ('User', 'User', (SELECT DocumentCategoryId  FROM Web.DocumentCategories WHERE DocumentCategoryName = 'User'), 
                            1, 1, 'Admin', 'Admin', getdate(), getdate()) ";
                    ExecuteQuery(mQry);
                }
            }
            catch (Exception ex)
            {
                RecordError(ex);
            }



            try
            {
                if ((int)ExecuteScaler("SELECT Count(*) AS Cnt FROM INFORMATION_SCHEMA.Columns WHERE COLUMN_NAME =  'EmployeeId' AND TABLE_NAME = 'Employees'") == 0)
                {
                    mQry = @"ALTER TABLE Web.Employees ADD EmployeeId INT ";
                    ExecuteQuery(mQry);
                    mQry = @"UPDATE Web.Employees
                    SET Web.Employees.EmployeeId = V1.EmployeeId
                    FROM (
	                    SELECT Row_number() OVER (ORDER BY PersonID) AS EmployeeId, PersonID FROM Web.Employees
                    ) AS V1 WHERE Web.Employees.PersonId = V1.PersonId ";
                    ExecuteQuery(mQry);
                    mQry = @"ALTER TABLE Web.Employees ALTER COLUMN EmployeeId INT  NOT NULL ";
                    ExecuteQuery(mQry);
                    mQry = @"ALTER TABLE Web.JobReceiveHeaders DROP CONSTRAINT [FK_Web.JobReceiveHeaders_Web.Employees_JobReceiveById] ";
                    ExecuteQuery(mQry);
                    mQry = @"ALTER TABLE Web.JobOrderAmendmentHeaders DROP CONSTRAINT [FK_Web.JobOrderAmendmentHeaders_Web.Employees_OrderById] ";
                    ExecuteQuery(mQry);
                    mQry = @"ALTER TABLE Web.JobReceiveQAHeaders DROP CONSTRAINT [FK_Web.JobReceiveQAHeaders_Web.Employees_QAById] ";
                    ExecuteQuery(mQry);
                    mQry = @"ALTER TABLE Web.PurchaseOrderInspectionHeaders DROP CONSTRAINT [FK_Web.PurchaseOrderInspectionHeaders_Web.Employees_InspectionById] ";
                    ExecuteQuery(mQry);
                    mQry = @"ALTER TABLE Web.JobInvoiceAmendmentHeaders DROP CONSTRAINT [FK_Web.JobInvoiceAmendmentHeaders_Web.Employees_OrderById] ";
                    ExecuteQuery(mQry);
                    mQry = @"ALTER TABLE Web.JobOrderHeaders DROP CONSTRAINT [FK_Web.JobOrderHeaders_Web.Employees_OrderById] ";
                    ExecuteQuery(mQry);
                    mQry = @"ALTER TABLE Web.JobOrderCancelHeaders DROP CONSTRAINT [FK_Web.JobOrderCancelHeaders_Web.Employees_OrderById] ";
                    ExecuteQuery(mQry);
                    mQry = @"ALTER TABLE Web.JobOrderInspectionHeaders DROP CONSTRAINT [FK_Web.JobOrderInspectionHeaders_Web.Employees_InspectionById] ";
                    ExecuteQuery(mQry);
                    mQry = @"ALTER TABLE Web.JobReturnHeaders DROP CONSTRAINT [FK_Web.JobReturnHeaders_Web.Employees_OrderById] ";
                    ExecuteQuery(mQry);
                    mQry = @"ALTER TABLE Web.SaleDeliveryOrderCancelHeaders DROP CONSTRAINT [FK_Web.SaleDeliveryOrderCancelHeaders_Web.Employees_OrderById] ";
                    ExecuteQuery(mQry);
                    mQry = @"ALTER TABLE Web.GatePassHeaders DROP CONSTRAINT [FK__GatePassH__Order__42FBEF3C] ";
                    ExecuteQuery(mQry);
                    mQry = @"ALTER TABLE Web.AttendanceLines DROP CONSTRAINT [FK__Attendanc__Emplo__16935D19] ";
                    ExecuteQuery(mQry);
                    mQry = @"ALTER TABLE Web.Employees DROP CONSTRAINT [PK_Web.Employees] ";
                    ExecuteQuery(mQry);
                    mQry = @"ALTER TABLE Web.Employees ADD CONSTRAINT [PK_Web.Employees] PRIMARY KEY (EmployeeId) ";
                    ExecuteQuery(mQry);
                }
            }
            catch (Exception ex)
            {
                RecordError(ex);
            }
        }


        private void InitializeUserTables()
        {
            string mQry = "";
            string RollId = "302b9430-498e-46e8-8ead-9e92867b7c9f";
            string UserId = "99bddeed-49d4-45fd-8f2c-df57c78434dd";

            mQry = "DELETE FROM Web.UserRoles WHERE CreatedBy = 'System'";
            ExecuteQuery(mQry);

            mQry = "DELETE FROM Web.AspNetUsers WHERE Id = '" + UserId + "'";
            ExecuteQuery(mQry);

            mQry = "DELETE FROM Web.Users WHERE Id = '" + UserId + "'";
            ExecuteQuery(mQry);

            mQry = "DELETE FROM Web.AspNetRoles WHERE Id = '" + RollId + "'";
            ExecuteQuery(mQry);


            mQry = " INSERT INTO Web.AspNetRoles (Id, Name) VALUES ('"+ RollId + "', 'Admin') ";
            ExecuteQuery(mQry);

            mQry = " INSERT INTO Web.Users (Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName, FirstName, LastName, Discriminator) " +
                    " VALUES ('" + UserId + "', 'meet2arpit@rediffmail.com', 1, 'AIrF0x9YIMRYD8NbDwddsu59QH2AojxsDKdH3yxRYT180EEJqSrnTmWjF1fgxnSZ8g==', '432a52e7-c4f9-4ef5-81cf-7fdc75c7d964', NULL, 0, 0, NULL, 0, 1, 'System', NULL, NULL, '1') ";
            ExecuteQuery(mQry);

            mQry = " INSERT INTO Web.AspNetUsers (Id) " +
                    " VALUES ('" + UserId + "') ";
            ExecuteQuery(mQry);


            mQry = @"INSERT INTO Web.UserRoles (UserId, RoleId, SiteId, DivisionId,  ExpiryDate, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate) 
                    VALUES ('" + UserId + "', '" + RollId + @"', 
                    " + SiteConstants.MainSite.SiteId + @",
                    " + DivisionConstants.MainDivision.DivisionId + @",
                    NULL, 'System', getdate(), 'System', getdate()) ";
            ExecuteQuery(mQry);

            //mQry = "INSERT INTO Web.RolesSites (RoleId, SiteId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate) " +
            //        " VALUES('302b9430-498e-46e8-8ead-9e92867b7c9f', " + SiteConstants.MainSite.SiteId + @", 'System', 'System', getdate(), getdate()) ";
            //ExecuteQuery(mQry);

            //mQry = "INSERT INTO Web.RolesDivisions (RoleId, DivisionId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate) " +
            //        " VALUES('302b9430-498e-46e8-8ead-9e92867b7c9f', " + DivisionConstants.MainDivision.DivisionId + @", 'System', 'System', getdate(), getdate()) ";
            //ExecuteQuery(mQry);

        }
        private void InitializePersonTables()
        {
            string mQry = "";
            try
            {
                mQry = "DELETE FROM Web.PersonProcesses  WHERE CreatedBy = 'System'";
                ExecuteQuery(mQry);

                mQry = "DELETE FROM Web.PersonRoles  WHERE CreatedBy = 'System'";
                ExecuteQuery(mQry);


                mQry = "DELETE FROM Web.PersonAddresses  WHERE CreatedBy = 'System'";
                ExecuteQuery(mQry);

                mQry = "DELETE FROM Web.LedgerAccounts WHERE PersonID IN (SELECT PersonID FROM web.People WHERE CreatedBy = 'System')";
                ExecuteQuery(mQry);

                mQry = "DELETE FROM Web.BusinessEntities WHERE PersonID IN(SELECT PersonID FROM web.People WHERE CreatedBy = 'System')";
                ExecuteQuery(mQry);

                mQry = "DELETE FROM Web.People  WHERE CreatedBy = 'System'";
                ExecuteQuery(mQry);

                mQry = "INSERT INTO Web.People (DocTypeId, Name, Suffix, Code, IsActive, IsSisterConcern, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate) " +
                        " VALUES(" + DocumentTypeConstants.Customer.DocumentTypeId + ", 'Customer', '00000721', '00000721', 1, 0, 'System', 'System', getdate(), getdate()) ";
                ExecuteQuery(mQry);

                mQry = "INSERT INTO Web.BusinessEntities (PersonID, IsSisterConcern, DivisionIds, SiteIds) " +
                        " SELECT P.PersonID, 0, '|" + DivisionConstants.MainDivision.DivisionId.ToString() + "|','|" + SiteConstants.MainSite.SiteId.ToString() + "|' " +
                        " FROM web.People P WITH(nolock) " +
                        " WHERE P.Name = 'Customer' AND P.DocTypeId =  " + DocumentTypeConstants.Customer.DocumentTypeId + "";
                ExecuteQuery(mQry);

                mQry = "INSERT INTO Web.LedgerAccounts (LedgerAccountId, LedgerAccountName, LedgerAccountSuffix, PersonId, LedgerAccountGroupId, IsActive, IsSystemDefine, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate) " +
                        " SELECT (SELECT Max(G.LedgerAccountId) FROM web.LedgerAccounts G WITH (Nolock) ) +1 AS LedgerAccountId, P.Name AS LedgerAccountName, P.Suffix AS LedgerAccountSuffix, P.PersonID, " + LedgerAccountGroupConstants.SundryDebtors.LedgerAccountGroupId + ", 1, 1, 'System', 'System', getdate(), getdate() " +
                        " FROM web.People P WITH(nolock) " +
                        " WHERE P.Name = 'Customer' AND P.DocTypeId =  " + DocumentTypeConstants.Customer.DocumentTypeId + "";
                         ExecuteQuery(mQry);

                mQry = "INSERT INTO Web.PersonAddresses (PersonId, CityId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate) " +
                        "SELECT P.PersonID, " + CityConstants.Kanpur.CityId + ", 'System', 'System', getdate(), getdate() " +
                        " FROM web.People P WITH(nolock) " +
                        " WHERE P.Name = 'Customer' AND P.DocTypeId = " + DocumentTypeConstants.Customer.DocumentTypeId + "";
                ExecuteQuery(mQry);


                mQry = "INSERT INTO Web.PersonRoles (PersonId, RoleDocTypeId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate) " +
                        "SELECT P.PersonID,  " + DocumentTypeConstants.Customer.DocumentTypeId + ", 'System', 'System', getdate(), getdate() " +
                        " FROM web.People P WITH(nolock) " +
                        " WHERE P.Name = 'Customer' AND P.DocTypeId = " + DocumentTypeConstants.Customer.DocumentTypeId + "";
                ExecuteQuery(mQry);


                mQry = "INSERT INTO Web.PersonProcesses(PersonId, ProcessId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate) " +
                         "SELECT P.PersonID,  " + ProcessConstants.Sale.ProcessId + ", 'System', 'System', getdate(), getdate() " +
                         " FROM web.People P WITH(nolock) " +
                         " WHERE P.Name = 'Customer' AND P.DocTypeId = " + DocumentTypeConstants.Customer.DocumentTypeId + "";
                ExecuteQuery(mQry);


            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

           

        }


        private void InitializeSqlProcedureScripts()
        {
            string script = "";
                        
            try
            {
                script = @"IF OBJECT_ID ('Web.spCarpetMaster_CreateTrace_GetFirstProductForColourWayAndSize') IS NOT NULL
                           DROP PROCEDURE Web.spCarpetMaster_CreateTrace_GetFirstProductForColourWayAndSize";
                ExecuteQuery(script);
                script = File.ReadAllText(path + @"SqlProcedureScripts\spCarpetMaster_CreateTrace_GetFirstProductForColourWayAndSize.sql");
                ExecuteQuery(script);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                script = @"IF OBJECT_ID ('Web.spCarpetMaster_MakeCustomProductName_GetCustomCarpetSkuName') IS NOT NULL
                            DROP PROCEDURE Web.spCarpetMaster_MakeCustomProductName_GetCustomCarpetSkuName";
                ExecuteQuery(script);
                script = File.ReadAllText(path + @"SqlProcedureScripts\spCarpetMaster_MakeCustomProductName_GetCustomCarpetSkuName.sql");
                ExecuteQuery(script);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                script = @"IF OBJECT_ID ('Web.[spDocumentTypeService_FGetNewDocNo_GetNewDocNo]') IS NOT NULL
	                        DROP PROCEDURE Web.[spDocumentTypeService_FGetNewDocNo_GetNewDocNo] ";
                ExecuteQuery(script);
                script = File.ReadAllText(path + @"SqlProcedureScripts\spDocumentTypeService_FGetNewDocNo_GetNewDocNo.sql");
                ExecuteQuery(script);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                script = @"IF OBJECT_ID ('Web.[spUnitConversionFor_GetUnitConversion_GetUnitConversionForSize]') IS NOT NULL
	                        DROP PROCEDURE Web.[spUnitConversionFor_GetUnitConversion_GetUnitConversionForSize] ";
                ExecuteQuery(script);
                script = File.ReadAllText(path + @"SqlProcedureScripts\spUnitConversionFor_GetUnitConversion_GetUnitConversionForSize.sql");
                ExecuteQuery(script);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }


        }
        private void InitializeSqlFunctionScripts()
        {
            string script = "";
            try
            {
                script = @"IF OBJECT_ID ('Web.fProductMap_Edit_ConvertSqFeetToSqYard') IS NOT NULL
	                        DROP Function Web.fProductMap_Edit_ConvertSqFeetToSqYard";
                ExecuteQuery(script);
                script = File.ReadAllText(path + @"SqlFunctionScripts\fProductMap_Edit_ConvertSqFeetToSqYard.sql");
                ExecuteQuery(script);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

        }
        private void InitializeSqlViewScripts()
        {
            string script = "";

            try
            {
                script = @"IF OBJECT_ID ('Web.ViewSaleOrderLine') IS NOT NULL
                            DROP VIEW[Web].[ViewSaleOrderLine]";
                ExecuteQuery(script);
                script = File.ReadAllText(path + @"SqlViewScripts\ViewSaleOrderLine.sql");
                ExecuteQuery(script);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                script = @"IF OBJECT_ID ('Web.ViewJobOrderLine') IS NOT NULL
                            DROP VIEW[Web].[ViewJobOrderLine]";
                ExecuteQuery(script);
                script = File.ReadAllText(path + @"SqlViewScripts\ViewJobOrderLine.sql");
                ExecuteQuery(script);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                script = @"IF OBJECT_ID ('Web.ViewPackingLineService_FGetPendingOrderQtyForDispatch_SaleOrderBalance') IS NOT NULL
	                    DROP VIEW [Web].[ViewPackingLineService_FGetPendingOrderQtyForDispatch_SaleOrderBalance]";
                ExecuteQuery(script);
                script = File.ReadAllText(path + @"SqlViewScripts\ViewPackingLineService_FGetPendingOrderQtyForDispatch_SaleOrderBalance.sql");
                ExecuteQuery(script);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }



            try
            {
                script = @"IF OBJECT_ID ('Web.ViewCarpetMaster_Edit_RugSize') IS NOT NULL
	                        DROP VIEW [Web].[ViewCarpetMaster_Edit_RugSize]";
                ExecuteQuery(script);
                script = File.ReadAllText(path + @"SqlViewScripts\ViewCarpetMaster_Edit_RugSize.sql");
                ExecuteQuery(script);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

        }

        private void InitializeSettingsTables()
        {
            string mQry = "";
            mQry = "DELETE FROM web.ProductTypeSettings WHERE CreatedBy ='System'";
            ExecuteQuery(mQry);

            mQry = "INSERT INTO Web.ProductTypeSettings (ProductTypeSettingsId, ProductTypeId, UnitId, isShowMappedDimension1, isShowUnMappedDimension1, isApplicableDimension1, Dimension1Caption, isShowMappedDimension2, isShowUnMappedDimension2, isApplicableDimension2, Dimension2Caption, isShowMappedDimension3, isShowUnMappedDimension3, isApplicableDimension3, Dimension3Caption, isShowMappedDimension4, isShowUnMappedDimension4, isApplicableDimension4, Dimension4Caption, isVisibleProductDescription, isVisibleProductSpecification, isVisibleProductCategory, isVisibleSalesTaxGroup, isVisibleSaleRate, isVisibleStandardCost, isVisibleTags, isVisibleMinimumOrderQty, isVisibleReOrderLevel, isVisibleGodownId, isVisibleBinLocationId, isVisibleProfitMargin, isVisibleCarryingCost, isVisibleLotManagement, isVisibleConsumptionDetail, isVisibleProductProcessDetail, isVisibleDefaultDimension1, isVisibleDefaultDimension2, isVisibleDefaultDimension3, isVisibleDefaultDimension4, isVisibleDiscontinueDate, isVisibleSalesTaxProductCode, IndexFilterParameter, ProductNameCaption, ProductCodeCaption, ProductDescriptionCaption, ProductSpecificationCaption, ProductGroupCaption, ProductCategoryCaption, SalesTaxProductCodeCaption, SqlProcProductCode, ImportMenuId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate) " +
                    " VALUES(1, " + RugProductTypeConstants.Rug.ProductTypeId + ", 'Pcs', 0, 0, 1, 'Colour', 0, 0, 0, NULL, 0, 0, 0, NULL, 0, 0, 0, NULL, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'System', 'System', Getdate(), Getdate())";
            ExecuteQuery(mQry);

            mQry = "INSERT INTO Web.ProductTypeSettings (ProductTypeSettingsId, ProductTypeId, UnitId, isShowMappedDimension1, isShowUnMappedDimension1, isApplicableDimension1, Dimension1Caption, isShowMappedDimension2, isShowUnMappedDimension2, isApplicableDimension2, Dimension2Caption, isShowMappedDimension3, isShowUnMappedDimension3, isApplicableDimension3, Dimension3Caption, isShowMappedDimension4, isShowUnMappedDimension4, isApplicableDimension4, Dimension4Caption, isVisibleProductDescription, isVisibleProductSpecification, isVisibleProductCategory, isVisibleSalesTaxGroup, isVisibleSaleRate, isVisibleStandardCost, isVisibleTags, isVisibleMinimumOrderQty, isVisibleReOrderLevel, isVisibleGodownId, isVisibleBinLocationId, isVisibleProfitMargin, isVisibleCarryingCost, isVisibleLotManagement, isVisibleConsumptionDetail, isVisibleProductProcessDetail, isVisibleDefaultDimension1, isVisibleDefaultDimension2, isVisibleDefaultDimension3, isVisibleDefaultDimension4, isVisibleDiscontinueDate, isVisibleSalesTaxProductCode, IndexFilterParameter, ProductNameCaption, ProductCodeCaption, ProductDescriptionCaption, ProductSpecificationCaption, ProductGroupCaption, ProductCategoryCaption, SalesTaxProductCodeCaption, SqlProcProductCode, ImportMenuId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate) " +
                    " VALUES(2, " + RugProductTypeConstants.Yarn.ProductTypeId + ", 'KG', 0, 0, 1, 'Shade', 0, 0, 0, NULL, 0, 0, 0, NULL, 0, 0, 0, NULL, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'System', 'System', Getdate(), Getdate())";
            ExecuteQuery(mQry);

            InitializeSaleEnquirySettings();
            InitializeSaleOrderSettings();
            InitializeProductBuyerSettings();
            InitializeCarpetSkuSettings();

        }

        private void InitializeSaleOrderSettings()
        {
            string mQry = "";
            try
            {
                mQry = @"INSERT INTO Web.SaleOrderSettings(SaleOrderSettingsId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate)
                        VALUES(1, 'System', 'System',getdate(), getdate())";
                ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                mQry = @"UPDATE Web.SaleOrderSettings 
                        SET UnitConversionForId = 1
                        WHERE UnitConversionForId IS NULL ";
                ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                mQry = @"UPDATE Web.SaleOrderSettings 
                        SET isVisibleDealUnit = 1
                        WHERE isVisibleDealUnit IS NULL ";
                ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                mQry = @"UPDATE Web.SaleOrderSettings 
                        SET filterPersonRoles = '" + DocumentTypeConstants.Customer.DocumentTypeId.ToString() + @"'
                        WHERE filterPersonRoles IS NULL ";
                ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                mQry = @"UPDATE Web.SaleOrderSettings 
                        SET ProcessId = " + ProcessConstants.Sale.ProcessId + @"
                        WHERE ProcessId IS NULL ";
                ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }


        }

        private void InitializeSaleEnquirySettings()
        {
            string mQry = "";
            try
            {
                mQry = @"INSERT INTO Web.SaleEnquirySettings(SaleEnquirySettingsId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate)
                        VALUES(1, 'System', 'System',getdate(), getdate())";
                ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                mQry = @"UPDATE Web.SaleEnquirySettings 
                        SET UnitConversionForId = 1
                        WHERE UnitConversionForId IS NULL ";
                 ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                mQry = @"UPDATE Web.SaleEnquirySettings 
                        SET isVisibleDealUnit = 1
                        WHERE isVisibleDealUnit IS NULL ";
                 ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                mQry = @"UPDATE Web.SaleEnquirySettings 
                        SET filterPersonRoles = '" + DocumentTypeConstants.Customer.DocumentTypeId.ToString() + @"'
                        WHERE filterPersonRoles IS NULL ";
                 ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                mQry = @"UPDATE Web.SaleEnquirySettings 
                        SET ProcessId = " + ProcessConstants.Sale.ProcessId + @"
                        WHERE ProcessId IS NULL ";
                 ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                mQry = @"UPDATE Web.SaleEnquirySettings 
                        SET SaleOrderDocTypeId = " + DocumentTypeConstants.SaleOrder.DocumentTypeId + @"
                        WHERE SaleOrderDocTypeId IS NULL ";
                 ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

        }
        private void InitializeProductBuyerSettings()
        {
            string mQry = "";
            try
            {
                mQry = @"INSERT INTO Web.ProductBuyerSettings (ProductBuyerSettingsId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate)
                        VALUES (1, 'System', 'System',getdate(), getdate())";
                 ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                mQry = @"UPDATE Web.ProductBuyerSettings
                        SET BuyerSpecificationDisplayName = 'BuyerSpecification'
                        WHERE BuyerSpecificationDisplayName IS NULL ";
                 ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                mQry = @"UPDATE Web.ProductBuyerSettings
                        SET BuyerSpecification1DisplayName = 'BuyerSpecification1'
                        WHERE BuyerSpecification1DisplayName IS NULL ";
                 ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                mQry = @"UPDATE Web.ProductBuyerSettings
                        SET BuyerSpecification2DisplayName = 'BuyerSpecification2'
                        WHERE BuyerSpecification2DisplayName IS NULL ";
                 ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                mQry = @"UPDATE Web.ProductBuyerSettings
                        SET BuyerSpecification3DisplayName = 'BuyerSpecification3'
                        WHERE BuyerSpecification3DisplayName IS NULL ";
                 ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

        }
        private void InitializeCarpetSkuSettings()
        {
            string mQry = "";
            try
            {
                mQry = @"INSERT INTO Web.CarpetSkuSettings (CarpetSkuSettingsId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate)
                         VALUES (1, 'System', 'System', getdate(), getdate())";
                 ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                mQry = @"UPDATE Web.CarpetSkuSettings
                        SET AddColourInProductName = 1
                        WHERE AddColourInProductName IS NULL ";
                 ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                mQry = @"UPDATE Web.CarpetSkuSettings
                         SET ProductDesignId = " + ProductDesignConstants.NA.ProductDesignId + @" 
                         WHERE ProductDesignId IS NULL ";
                 ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                mQry = @"UPDATE Web.CarpetSkuSettings
                         SET OriginCountryId = " + CountryConstants.India.CountryId + @" 
                         WHERE OriginCountryId IS NULL ";
                 ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                mQry = @"UPDATE Web.CarpetSkuSettings
                         SET PerimeterSizeTypeId =  " + ProductSizeTypesConstants.Standard.ProductSizeTypeId + @" 
                         WHERE PerimeterSizeTypeId IS NULL ";
                 ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                mQry = @"UPDATE Web.CarpetSkuSettings
                         SET UnitConversions = 'MT2' 
                         WHERE UnitConversions IS NULL ";
                 ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                mQry = @"UPDATE Web.CarpetSkuSettings
                         SET ManufacturingSizeName = 'ManufacturingSizeName' 
                         WHERE ManufacturingSizeName IS NULL ";
                 ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

    }
}



