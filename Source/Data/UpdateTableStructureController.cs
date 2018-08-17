using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using System.IO;
using System.Data.SqlClient;
using Model.Models;
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
using Jobs.Constants.IndustryType;
using Jobs.Constants.RugDocumentType;
using Jobs.Constants.RugProcess;
using Jobs.Constants.Calculation;
using Jobs.Constants.RugMenu;
using Jobs.Constants.Currency;

namespace Data.Models
{
    [Authorize]
    public class UpdateTableStructure
    {
        ApplicationDbContext db = new ApplicationDbContext();
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
            InitializeSqlTypeScripts();
            InitializeUserTables();
            InitializePersonTables();
            InitializeSettingsTables();
            InitializeSqlViewScripts();
            InitializeSqlProcedureScripts();
            InitializeSqlFunctionScripts();


            if ((string)System.Web.HttpContext.Current.Session["IndustryType"] == IndustryTypeConstants.Rug.IndustryTypeName)
            {
                InitializeSqlViewScripts_Rug();
                InitializeSqlProcedureScripts_Rug();
                InitializeSqlFunctionScripts_Rug();
            }

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
        public void InsertQuery(string TableName, string UniqueIdFieldName, int UniqueId, int ? DocTypeId)
        {
            string Query = "SELECT Count(*)  FROM Web." + TableName + " WHERE DocTypeId ";
            if (DocTypeId == null )
                Query = Query + " is Null";
            else
                Query = Query + " = " + DocTypeId.ToString() ;


            if ((int)ExecuteScaler(Query) == 0)
            {
                if (DocTypeId == null)
                    mQry = @"INSERT INTO Web." + TableName + @"(" + UniqueIdFieldName + @", CreatedBy, ModifiedBy, CreatedDate, ModifiedDate)
                        VALUES(" + UniqueId  + ", 'System', 'System',getdate(), getdate())";
                else
                    mQry = @"INSERT INTO Web." + TableName + @"(" + UniqueIdFieldName + @", DocTypeId, SiteId, DivisionId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate)
                        VALUES( " + UniqueId  + ", " + DocTypeId + @",  " + SiteConstants.MainSite.SiteId + @",  " + DivisionConstants.MainDivision.DivisionId + @", 'System', 'System',getdate(), getdate())";
                
                ExecuteQuery(mQry);
            }
        }
        public void UpdateQuery(string TableName, int? DocTypeId, string FeildName, string FeildValue)
        {


            if (DocTypeId == null)
                mQry = @"UPDATE Web." + TableName + @"
                        SET " + FeildName + @" = " + FeildValue + @"
                        WHERE " + FeildName + @" IS NULL AND DocTypeId is null";
            else
                mQry = @"UPDATE Web." + TableName + @"
                        SET " + FeildName + @" = " + FeildValue + @"
                        WHERE " + FeildName + @" IS NULL AND DocTypeId = " + DocTypeId + @"";

            ExecuteQuery(mQry);

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


            mQry = " INSERT INTO Web.AspNetRoles (Id, Name) VALUES ('" + RollId + "', 'Admin') ";
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
        private void SqlProcedureExecute(string ProcedureName)
        {
            string script = "";

            try
            {
                script = @"IF OBJECT_ID ('Web.[" + ProcedureName + @"]') IS NOT NULL
	                        DROP PROCEDURE Web.[" + ProcedureName + @"] ";
                ExecuteQuery(script);
                script = File.ReadAllText(path + @"SqlProcedureScripts\" + ProcedureName + @".sql");
                ExecuteQuery(script);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        private void SqlFunctionExecute(string ProcedureName)
        {
            string script = "";
            try
            {
                script = @"IF OBJECT_ID ('Web." + ProcedureName + @"') IS NOT NULL
	                        DROP Function Web." + ProcedureName + @"";
                ExecuteQuery(script);
                script = File.ReadAllText(path + @"SqlFunctionScripts\" + ProcedureName + @".sql");
                ExecuteQuery(script);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        private void SqlViewExecute(string ProcedureName)
        {
            string script = "";
            try
            {
                script = @"IF OBJECT_ID ('Web." + ProcedureName + @"') IS NOT NULL
	                    DROP VIEW [Web].[" + ProcedureName + @"]";
                ExecuteQuery(script);
                script = File.ReadAllText(path + @"SqlViewScripts\" + ProcedureName + @".sql");
                ExecuteQuery(script);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        private void InitializeSqlTypeScripts()
        {
            string script = "";

            try
            {
                script = @"IF OBJECT_ID ('Web.[TypeParameter]') IS NOT NULL
	                        DROP PROCEDURE Web.[TypeParameter] ";
                ExecuteQuery(script);
                script = @"CREATE TYPE Web.TypeParameter AS TABLE
                            (ProdOrderLineId INT,
                              Qty DECIMAL
                            )
                            ; ";
                ExecuteQuery(script);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }            

        }
        private void InitializeSqlProcedureScripts()
        {
           
            SqlProcedureExecute("CalculationHeaderCharge");
            SqlProcedureExecute("CalculationLineCharge");
            SqlProcedureExecute("FGetDocNo");            
            SqlProcedureExecute("GetNewDocNoGatePass");
            SqlProcedureExecute("GetPersonLedgerBalance");
            SqlProcedureExecute("ProcCompanyDetail");
            SqlProcedureExecute("sp_GetProductStandardWeight");
            SqlProcedureExecute("procGetCalculationMaxLineId");
            SqlProcedureExecute("ProcGetProductUidLastValues");            
            SqlProcedureExecute("ProcGetQCStockForPacking");
            SqlProcedureExecute("ProcGetStockForPacking");            
            SqlProcedureExecute("spDisplayStockInHandAndStockProcessDisplay");
            SqlProcedureExecute("spDocumentTypeService_FGetNewDocNo_GetNewDocNo");
            SqlProcedureExecute("spGatePassStockIssue");
            SqlProcedureExecute("spGetHelpListProcessWithChildProcess");
            SqlProcedureExecute("spGetProductProcessForProcessSequence");
            SqlProcedureExecute("SpJobOrderEvents__onHeaderSubmit_UpdateCostCenterStatusExtendedFromOrder");
            SqlProcedureExecute("spJobOrderHeaderService_FGetJobOrderCostCenter_GetJobOrderCostCenter");
            SqlProcedureExecute("spJobOrderLineService_GetJobRate_GetJobOrderRate");     
            SqlProcedureExecute("spMaterialPlanHeaderNewController_Submitted_UpdateMaterialPlanForSaleOrder");
            SqlProcedureExecute("spMaterialPlanLineNewController_GetProdOrders_ListProdOrderBalanceForMPlan");           
            SqlProcedureExecute("spPackingLineService_FGetPendingDeliveryOrderListForPacking_GetPendingDeliveryOrderListForPacking");
            SqlProcedureExecute("spPackingLineService_FGetPendingOrderListForPacking_GetPendingOrderListForPacking");
            SqlProcedureExecute("spPackingLineService_FGetPendingOrderQtyForPacking_GetPendingOrderQtyForPacking");            
            SqlProcedureExecute("spPrroductService_GetUnitConversionMultiplier_GetUnitConversion");        
            SqlProcedureExecute("spRep_TransactionCharges");
            SqlProcedureExecute("spSaleOrderHeaderService_SaleOrdersForDocumentType_SaleOrderBalanceForPlanning");
            SqlProcedureExecute("spUnitConversionFor_GetUnitConversion_GetUnitConversionForSize");
            SqlProcedureExecute("spStockProcessBalance");
            SqlProcedureExecute("sp_GetPrevProcess");

        }
        private void InitializeSqlProcedureScripts_Rug()
        {
            SqlProcedureExecute("ProcGetBomForWeaving");
            SqlProcedureExecute("ProcWeavingOrderPrint1");
            SqlProcedureExecute("ProcWeavingOrderPrint3");
            SqlProcedureExecute("sp_GetProductDimensions");
            SqlProcedureExecute("sp_PostBomForWeavingOrder");
            SqlProcedureExecute("sp_UpdateProductUidValuesForJobOrder");
            SqlProcedureExecute("sp_PostRequisitionForWeavingOrder");
            SqlProcedureExecute("spCarpetMaster_CreateTrace_GetFirstProductForColourWayAndSize");
            SqlProcedureExecute("spCarpetMaster_MakeCustomProductName_GetCustomCarpetSkuName");
            SqlProcedureExecute("spDyeingOrderPrint");
            SqlProcedureExecute("spDyeingOrderWizardController_PendingProdOrders_DyeingOrderWizard_Step1");
            SqlProcedureExecute("spDyeingOrderWizardController_SelectedProdOrderList_DyeingOrderWizard_Step2");
            SqlProcedureExecute("spGatePassRugFinishingOrder");
            SqlProcedureExecute("spJobOrderHeaderSevice_GetProdOrdersForWeavingWizard_WeavingOrderWizard");
            SqlProcedureExecute("spMaterialPlanSetting_GetBomProcedureForDocType_BomProcedure");
            SqlProcedureExecute("spMaterialPlanSetting_GetBomProcedureForDocType_BomProcedure_UndyedYarn");
            SqlProcedureExecute("spPackingLinrService_FGetPendingOrderListForPackingForProductUid_GetPendingOrderListForPackingForProductUid");
            SqlProcedureExecute("spRep_DyeingOrdershadePrint");
            SqlProcedureExecute("spWeavingOrderPrint");
            SqlProcedureExecute("spWeavingReceiveQACombined_Submitted_PostBomForWeavingReceive");
            SqlProcedureExecute("sp_PostProdOrderAtBranch");
            SqlProcedureExecute("sp_UpdateSaleOrderLine_inProductUid_FromWeavingOrder");
            SqlProcedureExecute("sp_PostProdOrderAtBranch");
            SqlProcedureExecute("sp_PostBomForWeavingOrderCancel");
            SqlProcedureExecute("sp_PostRequisitionCancelForWeavingOrderCancel");
            SqlProcedureExecute("sp_PostProdOrderCancelAtBranch");            
                
        }
        private void InitializeSqlFunctionScripts()
        {
            SqlFunctionExecute("FConvertSqFeetToSqYard");
            SqlFunctionExecute("FGenerateBarcodeList");
            SqlFunctionExecute("FGetExcessStock");
            SqlFunctionExecute("FGetExcessStock_WithDimension");
            SqlFunctionExecute("FGetSizeinFeet");
            SqlFunctionExecute("FGetSqFeetFromCMSizes");
            SqlFunctionExecute("FStockBalance");
            SqlFunctionExecute("RoundToNearestHundredDecimals");
            SqlFunctionExecute("Split");

            
        }
        private void InitializeSqlFunctionScripts_Rug()
        {
            SqlFunctionExecute("FConvertSqFeetToSqYard");
            SqlFunctionExecute("FGenerateBarcodeList");
            SqlFunctionExecute("FGetSizeinFeet");
            SqlFunctionExecute("FGetSqFeetFromCMSizes");
        }
        private void InitializeSqlViewScripts()
        {
            SqlViewExecute("_DocumentTypeSettings");
            SqlViewExecute("_JobOrderHeaders");
            SqlViewExecute("_JobOrderLines");
            SqlViewExecute("_People");
            SqlViewExecute("ViewSaleOrderLine");
            SqlViewExecute("ViewJobOrderLine");
            SqlViewExecute("ViewSaleInvoiceLine");
            
            SqlViewExecute("Std_PersonRegistrations");
            SqlViewExecute("ViewDivisionCompany");
            SqlViewExecute("ViewJobOrderBalance");         
            SqlViewExecute("ViewJobReceiveBalance");
            SqlViewExecute("ViewProdOrderBalance");
            SqlViewExecute("ViewProductBuyer");
            SqlViewExecute("ViewProdOrderBalance");
            SqlViewExecute("ViewRequisitionBalance");
            SqlViewExecute("ViewSaleDeliveryOrderLine");
            SqlViewExecute("ViewSaleDeliveryOrderBalanceForPacking");           
            SqlViewExecute("ViewSaleEnquiryBalance");
            SqlViewExecute("ViewSaleOrderBalance");
            SqlViewExecute("ViewSaleOrderBalanceForCancellation");
            SqlViewExecute("ViewSaleOrderBalanceForPlanning");
            SqlViewExecute("ViewSizeinCms");
            SqlViewExecute("ViewStockInBalance");

        }
        private void InitializeSqlViewScripts_Rug()
        {
            SqlViewExecute("ViewBomDetailsForWeavingReceivePosting");
            SqlViewExecute("ViewDesignColourConsumption");
            SqlViewExecute("ViewProductGroupContents");
            SqlViewExecute("ViewProductSize");

        }

        private void InitializeSettingsTables()
        {
            InitializeProductTypeSettings();
            InitializeProductBuyerSettings();
            InitializeCarpetSkuSettings();

            InitializeSaleEnquirySettings();
            InitializeSaleOrderSettings();
            InitializeSaleDeliveryOrderSettings();
            InitializeMaterialPlanSettings();
            InitializeProdOrderSettings();
            InitializeJobOrderSettings();
            InitializeJobReceiveSettings();
            InitializeJobReceiveQASettings();
            InitializeJobInvoiceSettings();
            InitializeLedgerSettings();
            InitializeStockHeaderSettings();
            InitializePackingSettings();
            InitializeSaleInvoiceSettings();
        }

        private void InitializeProductBuyerSettings()
        {
            string mQry = "";

            try
            {
                mQry = "DELETE FROM web.ProductBuyerSettings WHERE CreatedBy ='System'";
                ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

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


            if ((string)System.Web.HttpContext.Current.Session["IndustryType"] == IndustryTypeConstants.Rug.IndustryTypeName)
            {

                try
                {
                    mQry = @"INSERT INTO Web.ProductBuyerSettings (ProductBuyerSettingsId, SiteId, DivisionId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate)
                        VALUES (2, " + SiteConstants.MainSite.SiteId + @",  " + DivisionConstants.MainDivision.DivisionId + @", 'System', 'System',getdate(), getdate())";
                    ExecuteQuery(mQry);
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }

                try
                {
                    mQry = @"UPDATE Web.ProductBuyerSettings
                        SET BuyerSpecificationDisplayName = 'Design'
                        WHERE BuyerSpecificationDisplayName IS NULL AND DivisionId = " + DivisionConstants.MainDivision.DivisionId + @"";
                    ExecuteQuery(mQry);
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }

                try
                {
                    mQry = @"UPDATE Web.ProductBuyerSettings
                        SET BuyerSpecification1DisplayName = 'Size'
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
                        SET BuyerSpecification2DisplayName = 'Colour'
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
                        SET BuyerSpecification3DisplayName = 'Quality'
                        WHERE BuyerSpecification3DisplayName IS NULL ";
                    ExecuteQuery(mQry);
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }

        }
        private void InitializeCarpetSkuSettings()
        {
            string mQry = "";

            try
            {
                mQry = "DELETE FROM web.CarpetSkuSettings WHERE CreatedBy ='System'";
                ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

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
        private void InitializeProductTypeSettings()
        {
            string mQry = "";
            try
            {
                mQry = "DELETE FROM web.ProductTypeSettings WHERE CreatedBy ='System'";
                ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                mQry = @"INSERT INTO Web.ProductTypeSettings(ProductTypeSettingsId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate)
                        VALUES(1, 'System', 'System',getdate(), getdate())";
                ExecuteQuery(mQry);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            if ((string)System.Web.HttpContext.Current.Session["IndustryType"] == IndustryTypeConstants.Rug.IndustryTypeName)
            {
                try
                {
                    mQry = @"INSERT INTO Web.ProductTypeSettings(ProductTypeSettingsId, ProductTypeId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate)
                        VALUES(2, " + RugProductTypeConstants.Rug.ProductTypeId + @", 'System', 'System',getdate(), getdate())";
                    ExecuteQuery(mQry);
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }

                try
                {
                    mQry = @"UPDATE Web.ProductTypeSettings 
                        SET isApplicableDimension1 = 1
                        WHERE isApplicableDimension1 IS NULL AND ProductTypeId =" + RugProductTypeConstants.Rug.ProductTypeId + @" ";
                    ExecuteQuery(mQry);
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }


                try
                {
                    mQry = @"UPDATE Web.ProductTypeSettings 
                        SET isVisibleSalesTaxGroup = 1
                        WHERE isVisibleSalesTaxGroup IS NULL AND ProductTypeId =" + RugProductTypeConstants.Rug.ProductTypeId + @" ";
                    ExecuteQuery(mQry);
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }


                try
                {
                    mQry = @"UPDATE Web.ProductTypeSettings 
                        SET isVisibleLotManagement = 1
                        WHERE isVisibleLotManagement IS NULL AND ProductTypeId =" + RugProductTypeConstants.Rug.ProductTypeId + @" ";
                    ExecuteQuery(mQry);
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }

                try
                {
                    mQry = @"UPDATE Web.ProductTypeSettings 
                        SET isVisibleSalesTaxProductCode = 1
                        WHERE isVisibleSalesTaxProductCode IS NULL AND ProductTypeId =" + RugProductTypeConstants.Rug.ProductTypeId + @" ";
                    ExecuteQuery(mQry);
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }

                try
                {
                    mQry = @"UPDATE Web.ProductTypeSettings 
                        SET UnitId = 'Pcs'
                        WHERE UnitId IS NULL AND ProductTypeId =" + RugProductTypeConstants.Rug.ProductTypeId + @" ";
                    ExecuteQuery(mQry);
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }


                try
                {
                    mQry = @"UPDATE Web.ProductTypeSettings 
                        SET Dimension1Caption = 'Colour'
                        WHERE Dimension1Caption IS NULL AND ProductTypeId =" + RugProductTypeConstants.Rug.ProductTypeId + @" ";
                    ExecuteQuery(mQry);
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }


                try
                {
                    mQry = @"INSERT INTO Web.ProductTypeSettings(ProductTypeSettingsId, ProductTypeId, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate)
                        VALUES(3, " + RugProductTypeConstants.Yarn.ProductTypeId + @", 'System', 'System',getdate(), getdate())";
                    ExecuteQuery(mQry);
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }

                try
                {
                    mQry = @"UPDATE Web.ProductTypeSettings 
                        SET isApplicableDimension1 = 1
                        WHERE isApplicableDimension1 IS NULL AND ProductTypeId =" + RugProductTypeConstants.Yarn.ProductTypeId + @" ";
                    ExecuteQuery(mQry);
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }


                try
                {
                    mQry = @"UPDATE Web.ProductTypeSettings 
                        SET isVisibleSalesTaxGroup = 1
                        WHERE isVisibleSalesTaxGroup IS NULL AND ProductTypeId =" + RugProductTypeConstants.Yarn.ProductTypeId + @" ";
                    ExecuteQuery(mQry);
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }



                try
                {
                    mQry = @"UPDATE Web.ProductTypeSettings 
                        SET isVisibleSalesTaxProductCode = 1
                        WHERE isVisibleSalesTaxProductCode IS NULL AND ProductTypeId =" + RugProductTypeConstants.Yarn.ProductTypeId + @" ";
                    ExecuteQuery(mQry);
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }

                try
                {
                    mQry = @"UPDATE Web.ProductTypeSettings 
                        SET UnitId = 'KG'
                        WHERE UnitId IS NULL AND ProductTypeId =" + RugProductTypeConstants.Yarn.ProductTypeId + @" ";
                    ExecuteQuery(mQry);
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }


                try
                {
                    mQry = @"UPDATE Web.ProductTypeSettings 
                        SET Dimension1Caption = 'Shade'
                        WHERE Dimension1Caption IS NULL AND ProductTypeId =" + RugProductTypeConstants.Yarn.ProductTypeId + @" ";
                    ExecuteQuery(mQry);
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }


        }


        private void InitializeSaleEnquirySettings()
        {
            try
            {                
                InsertQuery("SaleEnquirySettings", "SaleEnquirySettingsId", 1, null);
                UpdateQuery("SaleEnquirySettings", null, "UnitConversionForId", "1");
                UpdateQuery("SaleEnquirySettings", null, "filterPersonRoles", DocumentTypeConstants.Customer.DocumentTypeId.ToString());
                UpdateQuery("SaleEnquirySettings", null, "ProcessId", ProcessConstants.Sale.ProcessId.ToString());
                UpdateQuery("SaleEnquirySettings", null, "SaleOrderDocTypeId", DocumentTypeConstants.SaleOrder.DocumentTypeId.ToString());
                UpdateQuery("SaleEnquirySettings", null, "filterProductTypes", ProductTypeConstants.TradingProduct.ProductTypeId.ToString());

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            
        }
        private void InitializeSaleOrderSettings()
        {

            try
            {
                InsertQuery("SaleOrderSettings", "SaleOrderSettingsId", 1, null);
                UpdateQuery("SaleOrderSettings", null, "UnitConversionForId", "1");
                UpdateQuery("SaleOrderSettings", null, "isVisibleDealUnit", "1");
                UpdateQuery("SaleOrderSettings", null, "filterPersonRoles", DocumentTypeConstants.Customer.DocumentTypeId.ToString());
                UpdateQuery("SaleOrderSettings", null, "ProcessId", ProcessConstants.Sale.ProcessId.ToString());
                UpdateQuery("SaleOrderSettings", null, "filterProductTypes", ProductTypeConstants.TradingProduct.ProductTypeId.ToString());

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        private void InitializeSaleDeliveryOrderSettings()
        {

            try
            {
                InsertQuery("SaleDeliveryOrderSettings", "SaleDeliveryOrderSettingsId", 1, null);
                UpdateQuery("SaleDeliveryOrderSettings", null, "filterPersonRoles", DocumentTypeConstants.Customer.DocumentTypeId.ToString());
                UpdateQuery("SaleDeliveryOrderSettings", null, "ProcessId", ProcessConstants.Sale.ProcessId.ToString());

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        private void InitializeMaterialPlanSettings()
        {

            InsertQuery("MaterialPlanSettings", "MaterialPlanSettingsId", 1, null);
            UpdateQuery("MaterialPlanSettings", null, "PlanType", "'SaleOrder'");

            InsertQuery("MaterialPlanSettings", "MaterialPlanSettingsId", 2, null);
            UpdateQuery("MaterialPlanSettings", null, "PlanType", "'ProdOrder'");

            UpdateQuery("MaterialPlanSettings", null, "isVisibleProdPlanQty", "1");
            UpdateQuery("MaterialPlanSettings", null, "PendingProdOrderList", "'Web.spSaleOrderHeaderService_SaleOrdersForDocumentType_SaleOrderBalanceForPlanning'");
            UpdateQuery("MaterialPlanSettings", null, "DocTypeProductionOrderId", DocumentTypeConstants.ManufacturingPlan.DocumentTypeId.ToString());


            if ((string)System.Web.HttpContext.Current.Session["IndustryType"] == IndustryTypeConstants.Rug.IndustryTypeName)
            {
                // Dyeing Plan
                try
                {
                    InsertQuery("MaterialPlanSettings", "MaterialPlanSettingsId", 3, RugDocumentTypeConstants.DyeingPlan.DocumentTypeId);
                    UpdateQuery("MaterialPlanSettings", RugDocumentTypeConstants.DyeingPlan.DocumentTypeId, "PlanType", "'ProdOrder'");
                    UpdateQuery("MaterialPlanSettings", RugDocumentTypeConstants.DyeingPlan.DocumentTypeId, "isVisibleProdPlanQty", "1");
                    UpdateQuery("MaterialPlanSettings", RugDocumentTypeConstants.DyeingPlan.DocumentTypeId, "SqlProcConsumption", "'Web.spMaterialPlanSetting_GetBomProcedureForDocType_BomProcedure'");
                    UpdateQuery("MaterialPlanSettings", RugDocumentTypeConstants.DyeingPlan.DocumentTypeId, "PendingProdOrderList", "'Web.spMaterialPlanLineNewController_GetProdOrders_ListProdOrderBalanceForMPlan'");
                    UpdateQuery("MaterialPlanSettings", RugDocumentTypeConstants.DyeingPlan.DocumentTypeId, "DocTypeProductionOrderId", DocumentTypeConstants.ManufacturingPlan.DocumentTypeId.ToString());
                    
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }

                // Material Plan
                try
                {
                    InsertQuery("MaterialPlanSettings", "MaterialPlanSettingsId", 4, DocumentTypeConstants.MaterialPlan.DocumentTypeId);
                    UpdateQuery("MaterialPlanSettings", DocumentTypeConstants.MaterialPlan.DocumentTypeId, "PlanType", "'ProdOrder'");
                    UpdateQuery("MaterialPlanSettings", DocumentTypeConstants.MaterialPlan.DocumentTypeId, "isVisiblePurchPlanQty", "1");
                    UpdateQuery("MaterialPlanSettings", DocumentTypeConstants.MaterialPlan.DocumentTypeId, "isVisibleProdPlanQty", "1");
                    UpdateQuery("MaterialPlanSettings", DocumentTypeConstants.MaterialPlan.DocumentTypeId, "SqlProcConsumption", "'Web.spMaterialPlanSetting_GetBomProcedureForDocType_BomProcedure_UndyedYarn'");
                    UpdateQuery("MaterialPlanSettings", DocumentTypeConstants.MaterialPlan.DocumentTypeId, "PendingProdOrderList", "'Web.spMaterialPlanLineNewController_GetProdOrders_ListProdOrderBalanceForMPlan'");
                    UpdateQuery("MaterialPlanSettings", DocumentTypeConstants.MaterialPlan.DocumentTypeId, "DocTypePurchaseIndentId", DocumentTypeConstants.PurchasePlan.DocumentTypeId.ToString());
                    UpdateQuery("MaterialPlanSettings", DocumentTypeConstants.MaterialPlan.DocumentTypeId, "DocTypeProductionOrderId", DocumentTypeConstants.ManufacturingPlan.DocumentTypeId.ToString());

                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }

        }
        private void InitializeProdOrderSettings()
        {

            InsertQuery("ProdOrderSettings", "ProdOrderSettingsId", 1, null);
        }

        private void InitializeJobOrderSettings()
        {
            try
            {
                InsertQuery("JobOrderSettings", "JobOrderSettingsId", 1, null);
                UpdateQuery("JobOrderSettings", null, "filterPersonRoles", DocumentTypeConstants.JobWorker.DocumentTypeId.ToString());
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                InsertQuery("JobOrderSettings", "JobOrderSettingsId", 2, DocumentTypeConstants.PurchaseOrder.DocumentTypeId);
                UpdateQuery("JobOrderSettings", DocumentTypeConstants.PurchaseOrder.DocumentTypeId, "isVisibleRate", "1");
                UpdateQuery("JobOrderSettings", DocumentTypeConstants.PurchaseOrder.DocumentTypeId, "isVisibleLotNo", "1");
                UpdateQuery("JobOrderSettings", DocumentTypeConstants.PurchaseOrder.DocumentTypeId, "isVisibleFromProdOrder", "1");
                UpdateQuery("JobOrderSettings", DocumentTypeConstants.PurchaseOrder.DocumentTypeId, "filterPersonRoles", DocumentTypeConstants.Supplier.DocumentTypeId.ToString());
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                InsertQuery("JobOrderSettings", "JobOrderSettingsId", 3, DocumentTypeConstants.PurchaseOrderCancel.DocumentTypeId);
                UpdateQuery("JobOrderSettings", DocumentTypeConstants.PurchaseOrderCancel.DocumentTypeId, "isVisibleLotNo", "1");
                UpdateQuery("JobOrderSettings", DocumentTypeConstants.PurchaseOrder.DocumentTypeId, "filterPersonRoles", DocumentTypeConstants.Supplier.DocumentTypeId.ToString());
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                InsertQuery("JobOrderSettings", "JobOrderSettingsId", 4, DocumentTypeConstants.JobOrderCancel.DocumentTypeId);
                UpdateQuery("JobOrderSettings", DocumentTypeConstants.JobOrderCancel.DocumentTypeId, "isVisibleDimension1", "1");
                UpdateQuery("JobOrderSettings", DocumentTypeConstants.JobOrderCancel.DocumentTypeId, "isVisibleDimension2", "1");
                UpdateQuery("JobOrderSettings", DocumentTypeConstants.JobOrderCancel.DocumentTypeId, "isVisibleProcessHeader", "1");
                UpdateQuery("JobOrderSettings", DocumentTypeConstants.JobOrderCancel.DocumentTypeId, "filterPersonRoles", DocumentTypeConstants.Supplier.DocumentTypeId.ToString());
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            if ((string)System.Web.HttpContext.Current.Session["IndustryType"] == IndustryTypeConstants.Rug.IndustryTypeName)
            {
                // Weaving Order
                try
                {
                    InsertQuery("JobOrderSettings", "JobOrderSettingsId", 101, RugDocumentTypeConstants.JobOrderWeaving.DocumentTypeId);
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderWeaving.DocumentTypeId, "isVisibleCostCenter","1");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderWeaving.DocumentTypeId, "isVisibleRate", "1");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderWeaving.DocumentTypeId, "isVisibleDealUnit", "1");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderWeaving.DocumentTypeId, "isVisibleUnitConversionFor", "1");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderWeaving.DocumentTypeId, "isVisibleFromProdOrder", "1");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderWeaving.DocumentTypeId, "ProcessId", RugProcessConstants.Weaving.ProcessId.ToString());
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderWeaving.DocumentTypeId, "filterProductTypes", RugProductTypeConstants.Rug.ProductTypeId.ToString());
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderWeaving.DocumentTypeId, "WizardMenuId", RugMenuConstants.WeavingOrderWizard.MenuId.ToString());
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderWeaving.DocumentTypeId, "SqlProcDocumentPrint", "'Web.spWeavingOrderPrint'");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderWeaving.DocumentTypeId, "SqlProcDocumentPrint_AfterSubmit", "'Web.spWeavingOrderPrint'");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderWeaving.DocumentTypeId, "SqlProcDocumentPrint_AfterApprove", "'Web.spWeavingOrderPrint'");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderWeaving.DocumentTypeId, "SqlProcConsumption", "'Web.ProcGetBomForWeaving'");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderWeaving.DocumentTypeId, "SqlProcGenProductUID", "'Web.FGenerateBarcodeList'");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderWeaving.DocumentTypeId, "filterPersonRoles", DocumentTypeConstants.JobWorker.DocumentTypeId.ToString());
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderWeaving.DocumentTypeId, "OnSubmitMenuId", RugMenuConstants.JobOrderSubmit.MenuId.ToString());
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }


                // Dyeing Order
                try
                {
                    InsertQuery("JobOrderSettings", "JobOrderSettingsId", 102, RugDocumentTypeConstants.JobOrderDyeing.DocumentTypeId);
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderDyeing.DocumentTypeId, "isVisibleRate", "1");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderDyeing.DocumentTypeId, "isVisibleDimension1", "1");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderDyeing.DocumentTypeId, "isVisibleDimension2", "1");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderDyeing.DocumentTypeId, "isVisibleFromProdOrder", "1");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderDyeing.DocumentTypeId, "ProcessId", RugProcessConstants.Dyeing.ProcessId.ToString());
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderDyeing.DocumentTypeId, "filterProductTypes", RugProductTypeConstants.Yarn.ProductTypeId.ToString());
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderDyeing.DocumentTypeId, "WizardMenuId", RugMenuConstants.DyeingOrderWizard.MenuId.ToString());
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderDyeing.DocumentTypeId, "filterPersonRoles", DocumentTypeConstants.JobWorker.DocumentTypeId.ToString());
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }

                
                // Finishing Order
                try
                {
                    InsertQuery("JobOrderSettings", "JobOrderSettingsId", 103, RugDocumentTypeConstants.JobOrderFinishing.DocumentTypeId);
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderFinishing.DocumentTypeId, "isVisibleRate", "1");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderFinishing.DocumentTypeId, "isVisibleProductUID", "1");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderFinishing.DocumentTypeId, "isVisibleGodown", "1");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderFinishing.DocumentTypeId, "isMandatoryGodown", "1");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderFinishing.DocumentTypeId, "isVisibleDealUnit", "1");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderFinishing.DocumentTypeId, "isVisibleUnitConversionFor", "1");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderFinishing.DocumentTypeId, "isVisibleProcessHeader", "1");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderFinishing.DocumentTypeId, "isPostedInStock", "1");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderFinishing.DocumentTypeId, "isPostedInStockProcess", "1");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderFinishing.DocumentTypeId, "isVisibleStockIn", "1");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderFinishing.DocumentTypeId, "IsMandatoryStockIn", "1");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderFinishing.DocumentTypeId, "ProcessId", RugProcessConstants.Finishing.ProcessId.ToString());
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderFinishing.DocumentTypeId, "SqlProcGatePass", "'Web.spGatePassRugFinishingOrder'");
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderFinishing.DocumentTypeId, "filterProductTypes", RugProductTypeConstants.Rug.ProductTypeId.ToString());
                    UpdateQuery("JobOrderSettings", RugDocumentTypeConstants.JobOrderFinishing.DocumentTypeId, "filterPersonRoles", DocumentTypeConstants.JobWorker.DocumentTypeId.ToString());
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }

                
            }

        }
        private void InitializeJobReceiveSettings()
        {

            try
            {
                InsertQuery("JobReceiveSettings", "JobReceiveSettingsId", 1, null);
                UpdateQuery("JobReceiveSettings", null, "filterPersonRoles", DocumentTypeConstants.JobWorker.DocumentTypeId.ToString());
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                InsertQuery("JobReceiveSettings", "JobReceiveSettingsId", 2, DocumentTypeConstants.GoodsReceipt.DocumentTypeId);
                UpdateQuery("JobReceiveSettings", DocumentTypeConstants.GoodsReceipt.DocumentTypeId, "IsVisibleForOrderMultiple", "1");
                UpdateQuery("JobReceiveSettings", DocumentTypeConstants.GoodsReceipt.DocumentTypeId, "isVisibleLotNo", "1");
                UpdateQuery("JobReceiveSettings", DocumentTypeConstants.GoodsReceipt.DocumentTypeId, "isPostedInStock", "1");
                UpdateQuery("JobReceiveSettings", DocumentTypeConstants.GoodsReceipt.DocumentTypeId, "isPostedInStockProcess", "1");
                UpdateQuery("JobReceiveSettings", DocumentTypeConstants.GoodsReceipt.DocumentTypeId, "filterPersonRoles", DocumentTypeConstants.Supplier.DocumentTypeId.ToString());
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            if ((string)System.Web.HttpContext.Current.Session["IndustryType"] == IndustryTypeConstants.Rug.IndustryTypeName)
            {

                // Weaving Receive
                try
                {
                    InsertQuery("JobReceiveSettings", "JobReceiveSettingsId", 101, RugDocumentTypeConstants.WeavingReceive.DocumentTypeId);
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.WeavingReceive.DocumentTypeId, "isVisibleProductUID", "1");
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.WeavingReceive.DocumentTypeId, "isVisibleDealUnit", "1");
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.WeavingReceive.DocumentTypeId, "IsVisibleWeight", "1");
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.WeavingReceive.DocumentTypeId, "IsVisibleForOrderMultiple", "1");
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.WeavingReceive.DocumentTypeId, "isPostedInStock", "1");
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.WeavingReceive.DocumentTypeId, "isPostedInStockProcess", "1");
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.WeavingReceive.DocumentTypeId, "ProcessId", RugProcessConstants.Weaving.ProcessId.ToString());
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.WeavingReceive.DocumentTypeId, "filterProductTypes", RugProductTypeConstants.Rug.ProductTypeId.ToString());
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.WeavingReceive.DocumentTypeId, "SqlProcConsumption", "'Web.spWeavingReceiveQACombined_Submitted_PostBomForWeavingReceive'");
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.WeavingReceive.DocumentTypeId, "filterPersonRoles", DocumentTypeConstants.JobWorker.DocumentTypeId.ToString());
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }

                // Dyeing Receive
                try
                {
                    InsertQuery("JobReceiveSettings", "JobReceiveSettingsId", 102, RugDocumentTypeConstants.DyeingReceive.DocumentTypeId);
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.DyeingReceive.DocumentTypeId, "IsVisibleForOrderMultiple", "1");
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.DyeingReceive.DocumentTypeId, "isPostedInStock", "1");
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.DyeingReceive.DocumentTypeId, "isPostedInStockProcess", "1");
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.DyeingReceive.DocumentTypeId, "ProcessId", RugProcessConstants.Dyeing.ProcessId.ToString());
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.DyeingReceive.DocumentTypeId, "filterProductTypes", RugProductTypeConstants.Yarn.ProductTypeId.ToString());
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.DyeingReceive.DocumentTypeId, "SqlProcConsumption", "'Web.spWeavingReceiveQACombined_Submitted_PostBomForWeavingReceive'");
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.DyeingReceive.DocumentTypeId, "filterPersonRoles", DocumentTypeConstants.JobWorker.DocumentTypeId.ToString());
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }

                

                // Finishing Receive
                try
                {
                    InsertQuery("JobReceiveSettings", "JobReceiveSettingsId", 103, RugDocumentTypeConstants.FinishingReceive.DocumentTypeId);
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.FinishingReceive.DocumentTypeId, "isVisibleProductUID", "1");
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.FinishingReceive.DocumentTypeId, "isVisibleDealUnit", "1");
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.FinishingReceive.DocumentTypeId, "isVisibleProcessHeader", "1");
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.FinishingReceive.DocumentTypeId, "IsVisibleForOrderMultiple", "1");
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.FinishingReceive.DocumentTypeId, "isPostedInStock", "1");
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.FinishingReceive.DocumentTypeId, "isPostedInStockProcess", "1");
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.FinishingReceive.DocumentTypeId, "ProcessId", RugProcessConstants.Finishing.ProcessId.ToString());
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.FinishingReceive.DocumentTypeId, "filterProductTypes", RugProductTypeConstants.Rug.ProductTypeId.ToString());
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.FinishingReceive.DocumentTypeId, "SqlProcConsumption", "'Web.spWeavingReceiveQACombined_Submitted_PostBomForWeavingReceive'");
                    UpdateQuery("JobReceiveSettings", RugDocumentTypeConstants.FinishingReceive.DocumentTypeId, "filterPersonRoles", DocumentTypeConstants.JobWorker.DocumentTypeId.ToString());
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }
        }
        private void InitializeJobReceiveQASettings()
        {
            try
            {
                InsertQuery("JobReceiveQASettings", "JobReceiveQASettingsId", 1, null);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }




            if ((string)System.Web.HttpContext.Current.Session["IndustryType"] == IndustryTypeConstants.Rug.IndustryTypeName)
            {

                try
                {
                    InsertQuery("JobReceiveQASettings", "JobReceiveQASettingsId", 2, RugDocumentTypeConstants.WeavingReceive.DocumentTypeId);
                    UpdateQuery("JobReceiveQASettings", RugDocumentTypeConstants.WeavingReceive.DocumentTypeId, "ProcessId", RugProcessConstants.Weaving.ProcessId.ToString());

                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }





                
            }
        }
        private void InitializeJobInvoiceSettings()
        {
            try
            {
                InsertQuery("JobInvoiceSettings", "JobInvoiceSettingsId", 1, null);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            try
            {
                InsertQuery("JobInvoiceSettings", "JobInvoiceSettingsId", 2, DocumentTypeConstants.PurchaseInvoice.DocumentTypeId);
                UpdateQuery("JobInvoiceSettings", DocumentTypeConstants.PurchaseInvoice.DocumentTypeId, "isVisibleLotNo", "1");
                UpdateQuery("JobInvoiceSettings", DocumentTypeConstants.PurchaseInvoice.DocumentTypeId, "isVisibleDealUnit", "1");
                UpdateQuery("JobInvoiceSettings", DocumentTypeConstants.PurchaseInvoice.DocumentTypeId, "isVisibleHeaderJobWorker", "1");
                UpdateQuery("JobInvoiceSettings", DocumentTypeConstants.PurchaseInvoice.DocumentTypeId, "isVisibleJobReceive", "1");
                UpdateQuery("JobInvoiceSettings", DocumentTypeConstants.PurchaseInvoice.DocumentTypeId, "IsVisiblePassQty", "1");
                UpdateQuery("JobInvoiceSettings", DocumentTypeConstants.PurchaseInvoice.DocumentTypeId, "IsVisibleRate", "1");
                UpdateQuery("JobInvoiceSettings", DocumentTypeConstants.PurchaseInvoice.DocumentTypeId, "ProcessId", ProcessConstants.Purchase.ProcessId.ToString());
                UpdateQuery("JobInvoiceSettings", DocumentTypeConstants.PurchaseInvoice.DocumentTypeId, "CalculationId", CalculationConstants.Calculation.CalculationId.ToString());

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }


            if ((string)System.Web.HttpContext.Current.Session["IndustryType"] == IndustryTypeConstants.Rug.IndustryTypeName)
            {

                // Dyeing Invoice
                try
                {
                    InsertQuery("JobInvoiceSettings", "JobInvoiceSettingsId", 101, RugDocumentTypeConstants.JobInvoiceDyeing.DocumentTypeId);
                    UpdateQuery("JobInvoiceSettings", RugDocumentTypeConstants.JobInvoiceDyeing.DocumentTypeId, "isVisibleJobReceive", "1");
                    UpdateQuery("JobInvoiceSettings", RugDocumentTypeConstants.JobInvoiceDyeing.DocumentTypeId, "ProcessId", RugProcessConstants.Dyeing.ProcessId.ToString());
                    UpdateQuery("JobInvoiceSettings", RugDocumentTypeConstants.JobInvoiceDyeing.DocumentTypeId, "CalculationId", CalculationConstants.Calculation.CalculationId.ToString());
                    UpdateQuery("JobInvoiceSettings", RugDocumentTypeConstants.JobInvoiceDyeing.DocumentTypeId, "IsVisiblePassQty", "1");
                    UpdateQuery("JobInvoiceSettings", RugDocumentTypeConstants.JobInvoiceDyeing.DocumentTypeId, "IsVisibleRate", "1");
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }

                // Weaving Invoice
                try
                {
                    InsertQuery("JobInvoiceSettings", "JobInvoiceSettingsId", 102, RugDocumentTypeConstants.JobInvoiceWeaving.DocumentTypeId);
                    UpdateQuery("JobInvoiceSettings", RugDocumentTypeConstants.JobInvoiceWeaving.DocumentTypeId, "isVisibleJobReceive", "1");
                    UpdateQuery("JobInvoiceSettings", RugDocumentTypeConstants.JobInvoiceWeaving.DocumentTypeId, "ProcessId", RugProcessConstants.Weaving.ProcessId.ToString());
                    UpdateQuery("JobInvoiceSettings", RugDocumentTypeConstants.JobInvoiceWeaving.DocumentTypeId, "CalculationId", CalculationConstants.Calculation.CalculationId.ToString());
                    UpdateQuery("JobInvoiceSettings", RugDocumentTypeConstants.JobInvoiceWeaving.DocumentTypeId, "IsVisiblePassQty", "1");
                    UpdateQuery("JobInvoiceSettings", RugDocumentTypeConstants.JobInvoiceWeaving.DocumentTypeId, "IsVisibleRate", "1");
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }
            }

        }
        private void InitializeLedgerSettings()
        {

            try
            {
                InsertQuery("LedgerSettings", "LedgerSettingId", 1, null);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }







        }
        private void InitializeStockHeaderSettings()
        {
            try
            {
                InsertQuery("StockHeaderSettings", "StockHeaderSettingsId", 1, null);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }




            if ((string)System.Web.HttpContext.Current.Session["IndustryType"] == IndustryTypeConstants.Rug.IndustryTypeName)
            {


                try
                {
                    InsertQuery("StockHeaderSettings", "StockHeaderSettingsId", 2, RugDocumentTypeConstants.MaterialIssueForWeaving.DocumentTypeId);
                    UpdateQuery("StockHeaderSettings", RugDocumentTypeConstants.MaterialIssueForWeaving.DocumentTypeId, "isVisibleLineCostCenter", "1");
                    UpdateQuery("StockHeaderSettings", RugDocumentTypeConstants.MaterialIssueForWeaving.DocumentTypeId, "isMandatoryLineCostCenter", "1");
                    UpdateQuery("StockHeaderSettings", RugDocumentTypeConstants.MaterialIssueForWeaving.DocumentTypeId, "isVisibleDimension1", "1");
                    UpdateQuery("StockHeaderSettings", RugDocumentTypeConstants.MaterialIssueForWeaving.DocumentTypeId, "isVisibleDimension2", "1");
                    UpdateQuery("StockHeaderSettings", RugDocumentTypeConstants.MaterialIssueForWeaving.DocumentTypeId, "isPostedInStock", "1");
                    UpdateQuery("StockHeaderSettings", RugDocumentTypeConstants.MaterialIssueForWeaving.DocumentTypeId, "isPostedInStockProcess", "1");
                    UpdateQuery("StockHeaderSettings", RugDocumentTypeConstants.MaterialIssueForWeaving.DocumentTypeId, "isVisibleMaterialRequest", "1");                            

                    UpdateQuery("StockHeaderSettings", RugDocumentTypeConstants.MaterialIssueForWeaving.DocumentTypeId, "ProcessId", RugProcessConstants.Weaving.ProcessId.ToString());
                    UpdateQuery("StockHeaderSettings", RugDocumentTypeConstants.MaterialIssueForWeaving.DocumentTypeId, "filterProductTypes", RugProductTypeConstants.Yarn.ProductTypeId.ToString());
                    UpdateQuery("StockHeaderSettings", RugDocumentTypeConstants.MaterialIssueForWeaving.DocumentTypeId, "PersonFieldHeading", "'Job Worker'");
                    UpdateQuery("StockHeaderSettings", RugDocumentTypeConstants.MaterialIssueForWeaving.DocumentTypeId, "SqlProcGatePass", "'Web.spGatePassStockIssue'");

                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }

                
            }
        }
        private void InitializePackingSettings()
        {
            


            try
            {
               // InsertQuery("PackingSettings", "PackingSettingId", 1, null);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }



            if ((string)System.Web.HttpContext.Current.Session["IndustryType"] == IndustryTypeConstants.Rug.IndustryTypeName)
            {
                try
                {
                    InsertQuery("PackingSettings", "PackingSettingId", 2, RugDocumentTypeConstants.CarpetPacking.DocumentTypeId);
                    UpdateQuery("PackingSettings", RugDocumentTypeConstants.CarpetPacking.DocumentTypeId, "isVisibleProductUID", "1");
                    UpdateQuery("PackingSettings", RugDocumentTypeConstants.CarpetPacking.DocumentTypeId, "isVisibleShipMethod", "1");
                    UpdateQuery("PackingSettings", RugDocumentTypeConstants.CarpetPacking.DocumentTypeId, "isVisibleStockIn", "1");
                    UpdateQuery("PackingSettings", RugDocumentTypeConstants.CarpetPacking.DocumentTypeId, "isVisibleBaleNo", "1");
                    UpdateQuery("PackingSettings", RugDocumentTypeConstants.CarpetPacking.DocumentTypeId, "isVisibleDealUnit", "1");
                    UpdateQuery("PackingSettings", RugDocumentTypeConstants.CarpetPacking.DocumentTypeId, "IsMandatoryStockIn", "1");
                    UpdateQuery("PackingSettings", RugDocumentTypeConstants.CarpetPacking.DocumentTypeId, "isVisibleBaleNo", "1");
                    UpdateQuery("PackingSettings", RugDocumentTypeConstants.CarpetPacking.DocumentTypeId, "filterProductTypes", RugProductTypeConstants.Rug.ProductTypeId.ToString());

           
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                }


      




            }
        }
        private void InitializeSaleInvoiceSettings()
        {
            
            try
            {
                 InsertQuery("SaleInvoiceSettings", "SaleInvoiceSettingId", 1, null);
                 UpdateQuery("SaleInvoiceSettings", null, "IsAutoDocNo", "1");
                 UpdateQuery("SaleInvoiceSettings", null, "CalculationId", CalculationConstants.Calculation.CalculationId.ToString());
                 UpdateQuery("SaleInvoiceSettings", null, "CurrencyId", CurrencyConstants.INR.ID.ToString());
                 UpdateQuery("SaleInvoiceSettings", null, "ProcessId", ProcessConstants.Sale.ProcessId.ToString());
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }



        }
    }
}



