using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobs.Constants.ControllerAction
{
    public static class ControllerActionConstants
    {
        #region "Sales"
        public static class SaleEnquiry
        {            
            public const int ControllerActionId = 1;
            public const string ControllerName = "SaleEnquiryHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class SaleEnquiryCancel
        {
            public const int ControllerActionId = 2;
            public const string ControllerName = "SaleEnquiryCancelHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class SaleQuotation
        {
            public const int ControllerActionId = 3;
            public const string ControllerName = "SaleQuotationHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class SaleQuotationCancel
        {
            public const int ControllerActionId = 4;
            public const string ControllerName = "SaleQuotationCancelHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class SaleOrder
        {
            public const int ControllerActionId = 5;
            public const string ControllerName = "SaleOrderHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class SaleOrderCancel
        {
            public const int ControllerActionId = 6;
            public const string ControllerName = "SaleOrderCancelHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class SaleOrderAmendment
        {
            public const int ControllerActionId = 7;
            public const string ControllerName = "SaleOrderAmendmentHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class SaleInspectionRequest
        {
            public const int ControllerActionId = 8;
            public const string ControllerName = "SaleInspectionRequestHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class SaleInspectionRequestCancel
        {
            public const int ControllerActionId = 9;
            public const string ControllerName = "SaleInspectionRequestCancelHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class SaleInspection
        {
            public const int ControllerActionId = 10;
            public const string ControllerName = "SaleInspectionHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class SaleDeliveryOrder
        {
            public const int ControllerActionId = 11;
            public const string ControllerName = "SaleDeliveryOrderHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class SaleDeliveryOrderCancel
        {
            public const int ControllerActionId = 12;
            public const string ControllerName = "SaleDeliveryOrderCancelHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class QualityChecking
        {
            public const int ControllerActionId = 13;
            public const string ControllerName = "QualityCheckingHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class Packing
        {
            public const int ControllerActionId = 14;
            public const string ControllerName = "PackingHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class PerformaInvoice
        {
            public const int ControllerActionId = 15;
            public const string ControllerName = "PerformaInvoiceHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class SaleDispatch
        {
            public const int ControllerActionId = 16;
            public const string ControllerName = "SaleDispatchHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class SaleDispatchReturn
        {
            public const int ControllerActionId = 17;
            public const string ControllerName = "SaleDispatchReturnHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class SaleInvoice
        {
            public const int ControllerActionId = 18;
            public const string ControllerName = "SaleInvoiceHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class SaleInvoiceReturn
        {
            public const int ControllerActionId = 19;
            public const string ControllerName = "SaleInvoiceReturnHeader";
            public const string ActionName = "DocumentTypeIndex";
        }

        #endregion
        #region "Job"
        public static class JobEnquiry
        {
            public const int ControllerActionId = 22;
            public const string ControllerName = "JobEnquiryHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class JobEnquiryCancel
        {
            public const int ControllerActionId = 23;
            public const string ControllerName = "JobEnquiryCancelHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class JobQuotation
        {
            public const int ControllerActionId = 24;
            public const string ControllerName = "JobQuotationHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class JobQuotationCancel
        {
            public const int ControllerActionId = 25;
            public const string ControllerName = "JobQuotationCancelHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class JobOrder
        {
            public const int ControllerActionId = 26;
            public const string ControllerName = "JobOrderHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class JobOrderCancel
        {
            public const int ControllerActionId = 27;
            public const string ControllerName = "JobOrderCancelHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class JobOrderAmendment
        {
            public const int ControllerActionId = 28;
            public const string ControllerName = "JobOrderAmendmentHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class JobInspectionRequest
        {
            public const int ControllerActionId =29;
            public const string ControllerName = "JobInspectionRequestHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class JobInspectionRequestCancel
        {
            public const int ControllerActionId = 30;
            public const string ControllerName = "JobInspectionRequestCancelHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class JobInspection
        {
            public const int ControllerActionId = 31;
            public const string ControllerName = "JobInspectionHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class JobReceive
        {
            public const int ControllerActionId = 32;
            public const string ControllerName = "JobReceiveHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class JobReceiveQC
        {
            public const int ControllerActionId = 33;
            public const string ControllerName = "JobReceiveQCHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class JobReturn
        {
            public const int ControllerActionId = 34;
            public const string ControllerName = "JobReturnHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class JobInvoice
        {
            public const int ControllerActionId = 35;
            public const string ControllerName = "JobInvoiceReceiveHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class JobInvoiceReturn
        {
            public const int ControllerActionId = 36;
            public const string ControllerName = "JobInvoiceReturnHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        
        #endregion
        #region "Inventory"
        public static class StockRequisition
        {
            public const int ControllerActionId = 39;
            public const string ControllerName = "MaterialRequestHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class StockRequisitionCancel
        {
            public const int ControllerActionId = 40;
            public const string ControllerName = "MaterialRequestCancelHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class StockIssue
        {
            public const int ControllerActionId = 41;
            public const string ControllerName = "StockIssueHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class StockReceive
        {
            public const int ControllerActionId = 42;
            public const string ControllerName = "StockReceiveHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class StockTransfer
        {
            public const int ControllerActionId = 43;
            public const string ControllerName = "MaterialTransferHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class StockExchange
        {
            public const int ControllerActionId = 44;
            public const string ControllerName = "StockExchange";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class StockReconciliation
        {
            public const int ControllerActionId = 45;
            public const string ControllerName = "StockReconciliation";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class GatePass
        {
            public const int ControllerActionId = 46;
            public const string ControllerName = "GatePass";
            public const string ActionName = "Index";
        }
        #endregion
        #region "Planning"
        public static class SaleOrderPlan
        {
            public const int ControllerActionId = 47;
            public const string ControllerName = "MaterialPlanHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class ProductionOrder
        {
            public const int ControllerActionId = 48;
            public const string ControllerName = "ProdOrderHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class ProductionOrderCancel
        {
            public const int ControllerActionId = 49;
            public const string ControllerName = "ProdOrderCancelHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        #endregion
        #region "Accounts"
        public static class LedgerHeader
        {
            public const int ControllerActionId = 50;
            public const string ControllerName = "LedgerHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        
        public static class ChequeCancel
        {
            public const int ControllerActionId = 55;
            public const string ControllerName = "ChequeCancelHeader";
            public const string ActionName = "DocumentTypeIndex";
        }
        public static class BankReconciliation
        {
            public const int ControllerActionId = 58;
            public const string ControllerName = "BankReconciliation";
            public const string ActionName = "Index";
        }
        #endregion
        #region "Report"
        public static class Report
        {
            public const int ControllerActionId = 59;
            public const string ControllerName = "Report_ReportPrint";
            public const string ActionName = "ReportPrint";
        }
#endregion
        #region "Master"
        public static class Person
        {
            public const int ControllerActionId = 60;
            public const string ControllerName = "Person";
            public const string ActionName = "Index";
        }
        public static class Product
        {
            public const int ControllerActionId = 61;
            public const string ControllerName = "Product";
            public const string ActionName = "MaterialIndex";
        }
        public static class ProductGroup
        {
            public const int ControllerActionId = 62;
            public const string ControllerName = "ProductGroup";
            public const string ActionName = "Index";
        }
        public static class ProductCategory
        {
            public const int ControllerActionId = 63;
            public const string ControllerName = "ProductCategory";
            public const string ActionName = "ProductTypeIndex";
        }
        public static class ProductType
        {
            public const int ControllerActionId = 64;
            public const string ControllerName = "ProductType";
            public const string ActionName = "Index";
        }
        public static class ProductCustomGroup
        {
            public const int ControllerActionId = 65;
            public const string ControllerName = "ProductCustomGroup";
            public const string ActionName = "Index";
        }
        public static class Godown
        {
            public const int ControllerActionId = 66;
            public const string ControllerName = "Godown";
            public const string ActionName = "Index";
        }
        public static class SalesTaxProductCode
        {
            public const int ControllerActionId = 67;
            public const string ControllerName = "SalesTaxProductCode";
            public const string ActionName = "Index";
        }
        public static class Gate
        {
            public const int ControllerActionId = 68;
            public const string ControllerName = "Gate";
            public const string ActionName = "Index";
        }
        public static class City
        {
            public const int ControllerActionId = 69;
            public const string ControllerName = "City";
            public const string ActionName = "Index";
        }
        public static class State
        {
            public const int ControllerActionId = 70;
            public const string ControllerName = "State";
            public const string ActionName = "Index";
        }
        public static class Country
        {
            public const int ControllerActionId = 71;
            public const string ControllerName = "Country";
            public const string ActionName = "Index";
        }
        public static class Employee
        {
            public const int ControllerActionId = 72;
            public const string ControllerName = "Employee";
            public const string ActionName = "Index";
        }
        public static class LedgerAccount
        {
            public const int ControllerActionId = 73;
            public const string ControllerName = "LedgerAccount";
            public const string ActionName = "Index";
        }
        public static class LedgerAccountGroup
        {
            public const string ControllerName = "LedgerAccountGroup";
            public const string ActionName = "Index";
        }
        public static class CostCenter
        {
            public const int ControllerActionId = 74;
            public const string ControllerName = "CostCenter";
            public const string ActionName = "Index";
        }
        public static class TdsCategory
        {
            public const int ControllerActionId = 75;
            public const string ControllerName = "TdsCategory";
            public const string ActionName = "Index";
        }
        public static class TdsGroup
        {
            public const int ControllerActionId = 76;
            public const string ControllerName = "TdsGroup";
            public const string ActionName = "Index";
        }
        public static class ChargeGroupSettings
        {
            public const int ControllerActionId = 77;
            public const string ControllerName = "ChargeGroupSettings";
            public const string ActionName = "Index";
        }
        public static class DocumentCategory
        {
            public const int ControllerActionId = 78;
            public const string ControllerName = "DocumentCategory";
            public const string ActionName = "Index";
        }
        public static class DocumentType
        {
            public const int ControllerActionId = 79;
            public const string ControllerName = "DocumentType";
            public const string ActionName = "Index";
        }
        public static class Site
        {
            public const int ControllerActionId = 80;
            public const string ControllerName = "Site";
            public const string ActionName = "Index";
        }
        public static class Division
        {
            public const int ControllerActionId = 81;
            public const string ControllerName = "Division";
            public const string ActionName = "Index";
        }
        public static class Charge
        {
            public const int ControllerActionId = 82;
            public const string ControllerName = "Charge";
            public const string ActionName = "Index";
        }
        public static class Calculation
        {
            public const int ControllerActionId = 83;
            public const string ControllerName = "Calculation";
            public const string ActionName = "Index";
        }
        public static class CalculationLedgerAccounts
        {
            public const int ControllerActionId = 84;
            public const string ControllerName = "CalculationLedgerAccounts";
            public const string ActionName = "Index";
        }
        public static class AssignPermissions
        {
            public const int ControllerActionId = 85;
            public const string ControllerName = "CalculationLedgerAccounts";
            public const string ActionName = "Index";
        }
        public static class CreateRoles
        {
            public const int ControllerActionId = 86;
            public const string ControllerName = "CalculationLedgerAccounts";
            public const string ActionName = "Index";
        }
        public static class Reason
        {
            public const int ControllerActionId = 87;
            public const string ControllerName = "Reason";
            public const string ActionName = "Index";
        }
        public static class AssignNewRoles
        {
            public const int ControllerActionId = 88;
            public const string ControllerName = "AssignNewRoles";
            public const string ActionName = "Index";
        }
        public static class AssignTemporaryRoles
        {
            public const int ControllerActionId = 89;
            public const string ControllerName = "AssignTemporaryRoles";
            public const string ActionName = "Index";
        }
        public static class UpdateTableStructure
        {
            public const int ControllerActionId = 90;
            public const string ControllerName = "UpdateTableStructure";
            public const string ActionName = "UpdateTables";
        }
        public static class UserInvitation
        {
            public const int ControllerActionId = 91;
            public const string ControllerName = "UserInvitation";
            public const string ActionName = "Index";
        }
        public static class DAR
        {
            public const int ControllerActionId = 92;
            public const string ControllerName = "DAR";
            public const string ActionName = "Index";
        }
        public static class Tasks
        {
            public const int ControllerActionId =93;
            public const string ControllerName = "Tasks";
            public const string ActionName = "Index";
        }
        #endregion

        //Only For Carpet Industry
        public static class CarpetMaster
        {
            public const int ControllerActionId = 94;
            public const string ControllerName = "CarpetMaster";
            public const string ActionName = "Index";
        }

        public static class Quality
        {
            public const int ControllerActionId = 95;
            public const string ControllerName = "ProductQuality";
            public const string ActionName = "Index";
        }
        public static class Size
        {
            public const int ControllerActionId = 96;
            public const string ControllerName = "Size";
            public const string ActionName = "Index";
        }

        public static class Collection
        {
            public const int ControllerActionId = 97;
            public const string ControllerName = "ProductCollection";
            public const string ActionName = "Index";
        }

        public static class ProductContent
        {
            public const int ControllerActionId = 98;
            public const string ControllerName = "ProductContentHeader";
            public const string ActionName = "Index";
        }

        public static class ProcessSequenceHeader
        {
            public const int ControllerActionId = 99;
            public const string ControllerName = "ProcessSequenceHeader";
            public const string ActionName = "Index";
        }
        public static class Colour
        {
            public const int ControllerActionId = 100;
            public const string ControllerName = "Colour";
            public const string ActionName = "Index";
        }
    }
}