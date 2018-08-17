using Jobs.Constants.ControllerAction;
using Jobs.Constants.DocumentCategory;
using Jobs.Constants.DocumentType;
using Jobs.Constants.Module;
using Jobs.Constants.SubModule;
using Jobs.Constants.ProductNature;
using Jobs.Constants.Areas;
using Jobs.Constants.RugProductType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobs.Constants.Menu
{
    public static class MenuConstants
    {
        #region "Sales Transactions"
        public static class SaleEnquiry
        {
            public const int MenuId = 1;
            public const string MenuName = "Sale Enquiry";
            public const string Srl = "1";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Sale Enquiry";
            public const int ModuleId = ModuleConstants.Sales.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.SaleEnquiry.ControllerName;
            public const string ActionName = ControllerActionConstants.SaleEnquiry.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.SaleEnquiry.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        public static class SaleEnquiryCancel
        {
            public const int MenuId = 2;
            public const string MenuName = "Sale Enquiry Cancel";
            public const string Srl = "1.05";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Sale Enquiry Cancel";
            public const int ModuleId = ModuleConstants.Sales.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.SaleEnquiryCancel.ControllerName;
            public const string ActionName = ControllerActionConstants.SaleEnquiryCancel.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.SaleEnquiryCancel.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }
        public static class SaleQuotation
        {
            public const int MenuId = 3;
            public const string MenuName = "Sale Quotation";
            public const string Srl = "1.1";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Sale Quotation";
            public const int ModuleId = ModuleConstants.Sales.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.SaleQuotation.ControllerName;
            public const string ActionName = ControllerActionConstants.SaleQuotation.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.SaleQuotation.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }
        public static class SaleQuotationCancel
        {
            public const int MenuId = 4;
            public const string MenuName = "Sale Quotation Cancel";
            public const string Srl = "1.15";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Sale Quotation Cancel";
            public const int ModuleId = ModuleConstants.Sales.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.SaleQuotationCancel.ControllerName;
            public const string ActionName = ControllerActionConstants.SaleQuotationCancel.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.SaleQuotationCancel.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }
        public static class SaleOrder
        {
            public const int MenuId = 5;
            public const string MenuName = "Sale Order";
            public const string Srl = "1.2";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Sale Order";
            public const int ModuleId = ModuleConstants.Sales.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.SaleOrder.ControllerName;
            public const string ActionName = ControllerActionConstants.SaleOrder.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.SaleOrder.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        public static class SaleOrderCancel
        {
            public const int MenuId = 6;
            public const string MenuName = "Sale Order Cancel";
            public const string Srl = "1.25";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Sale Order Cancel";
            public const int ModuleId = ModuleConstants.Sales.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.SaleOrderCancel.ControllerName;
            public const string ActionName = ControllerActionConstants.SaleOrderCancel.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.SaleOrderCancel.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        public static class SaleOrderAmendment
        {
            public const int MenuId = 7;
            public const string MenuName = "Sale Order Amendment";
            public const string Srl = "1.3";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Sale Order Amendment";
            public const int ModuleId = ModuleConstants.Sales.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.SaleOrderAmendment.ControllerName;
            public const string ActionName = ControllerActionConstants.SaleOrderAmendment.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.SaleOrderAmendment.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }
        public static class CustomerAuditRequest
        {
            public const int MenuId = 8;
            public const string MenuName = "Customer Audit Request";
            public const string Srl = "1.35";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Customer Audit Request";
            public const int ModuleId = ModuleConstants.Sales.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.SaleInspectionRequest.ControllerName;
            public const string ActionName = ControllerActionConstants.SaleInspectionRequest.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.CustomerAuditRequest.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }
        public static class CustomerAudit
        {
            public const int MenuId = 9;
            public const string MenuName = "Customer Audit";
            public const string Srl = "1.45";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Customer Audit";
            public const int ModuleId = ModuleConstants.Sales.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.SaleInspection.ControllerName;
            public const string ActionName = ControllerActionConstants.SaleInspection.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.CustomerAudit.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }
        public static class DeliveryOrder
        {
            public const int MenuId = 10;
            public const string MenuName = "Delivery Order";
            public const string Srl = "1.5";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Delivery Order";
            public const int ModuleId = ModuleConstants.Sales.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.SaleDeliveryOrder.ControllerName;
            public const string ActionName = ControllerActionConstants.SaleDeliveryOrder.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.DeliveryOrder.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        public static class DeliveryOrderCancel
        {
            public const int MenuId = 11;
            public const string MenuName = "Delivery Order Cancel";
            public const string Srl = "1.55";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Delivery Order Cancel";
            public const int ModuleId = ModuleConstants.Sales.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.SaleDeliveryOrderCancel.ControllerName;
            public const string ActionName = ControllerActionConstants.SaleDeliveryOrderCancel.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.DeliveryOrderCancel.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }
        public static class QualityCheckingOutword
        {
            public const int MenuId = 12;
            public const string MenuName = "Quality Checking (Outword)";
            public const string Srl = "1.6";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Quality Checking (Outword)";
            public const int ModuleId = ModuleConstants.Sales.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.QualityChecking.ControllerName;
            public const string ActionName = ControllerActionConstants.QualityChecking.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.QualityCheckingOutword.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }
        public static class Packing
        {
            public const int MenuId = 13;
            public const string MenuName = "Packing";
            public const string Srl = "1.65";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Packing";
            public const int ModuleId = ModuleConstants.Sales.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.Packing.ControllerName;
            public const string ActionName = ControllerActionConstants.Packing.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.Packing.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        public static class PerformaInvoice
        {
            public const int MenuId = 14;
            public const string MenuName = "Performa Invoice";
            public const string Srl = "1.7";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Performa Invoice";
            public const int ModuleId = ModuleConstants.Sales.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.PerformaInvoice.ControllerName;
            public const string ActionName = ControllerActionConstants.PerformaInvoice.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.PerformaInvoice.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }
        public static class SaleGoodsDispatch
        {
            public const int MenuId = 15;
            public const string MenuName = "Goods Dispatch";
            public const string Srl = "1.75";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Goods Dispatch";
            public const int ModuleId = ModuleConstants.Sales.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.SaleDispatch.ControllerName;
            public const string ActionName = ControllerActionConstants.SaleDispatch.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.GoodsDispatch.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }
        public static class SaleInvoice
        {
            public const int MenuId = 16;
            public const string MenuName = "Sale Invoice";
            public const string Srl = "1.8";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Sale Invoice";
            public const int ModuleId = ModuleConstants.Sales.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.SaleInvoice.ControllerName;
            public const string ActionName = ControllerActionConstants.SaleInvoice.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.SaleInvoice.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        public static class SaleReturn
        {
            public const int MenuId = 17;
            public const string MenuName = "Sale Return";
            public const string Srl = "1.95";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Sale Return";
            public const int ModuleId = ModuleConstants.Sales.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.SaleInvoiceReturn.ControllerName;
            public const string ActionName = ControllerActionConstants.SaleInvoiceReturn.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.SaleReturn.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }
        #endregion
        #region "Sales Masters"
        public static class Customer
        {
            public const int MenuId = 18;
            public const string MenuName = "Customer";
            public const string Srl = "2";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Customer";
            public const int ModuleId = ModuleConstants.Sales.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.Person.ControllerName;
            public const string ActionName = ControllerActionConstants.Person.ActionName;
            public static readonly string RouteId = DocumentTypeConstants.Customer.DocumentTypeId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        #endregion
        #region "Purchase Transactions"
        public static class PurchasePlan
        {
            public const int MenuId = 25;
            public const string MenuName = "Purchase Plan";
            public const string Srl = "1";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Purchase Plan";
            public const int ModuleId = ModuleConstants.Purchase.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.ProductionOrder.ControllerName;
            public const string ActionName = ControllerActionConstants.ProductionOrder.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.PurchasePlan.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        public static class PurchasePlanCancel
        {
            public const int MenuId = 26;
            public const string MenuName = "Purchase Plan Cancel";
            public const string Srl = "1.03";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Purchase Plan Cancel";
            public const int ModuleId = ModuleConstants.Purchase.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.ProductionOrderCancel.ControllerName;
            public const string ActionName = ControllerActionConstants.ProductionOrderCancel.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.PurchasePlanCancel.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        public static class PurchaseEnquiry
        {
            public const int MenuId = 27;
            public const string MenuName = "Purchase Enquiry";
            public const string Srl = "1.05";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Purchase Enquiry";
            public const int ModuleId = ModuleConstants.Purchase.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobEnquiry.ControllerName;
            public const string ActionName = ControllerActionConstants.JobEnquiry.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.PurchaseEnquiry.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }
        public static class PurchaseEnquiryCancel
        {
            public const int MenuId = 28;
            public const string MenuName = "Purchase Enquiry Cancel";
            public const string Srl = "1.1";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Purchase Enquiry Cancel";
            public const int ModuleId = ModuleConstants.Purchase.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobEnquiryCancel.ControllerName;
            public const string ActionName = ControllerActionConstants.JobEnquiryCancel.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.PurchaseEnquiryCancel.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }
        public static class PurchaseQuotation
        {
            public const int MenuId = 29;
            public const string MenuName = "Purchase Quotation";
            public const string Srl = "1.15";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Purchase Quotation";
            public const int ModuleId = ModuleConstants.Purchase.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobQuotation.ControllerName;
            public const string ActionName = ControllerActionConstants.JobQuotation.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.PurchaseQuotation.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }
        public static class PurchaseQuotationCancel
        {
            public const int MenuId = 30;
            public const string MenuName = "Purchase Quotation Cancel";
            public const string Srl = "1.2";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Purchase Quotation Cancel";
            public const int ModuleId = ModuleConstants.Purchase.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobQuotationCancel.ControllerName;
            public const string ActionName = ControllerActionConstants.JobQuotationCancel.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.PurchaseQuotationCancel.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }
        public static class PurchaseOrder
        {
            public const int MenuId = 31;
            public const string MenuName = "Purchase Order";
            public const string Srl = "1.25";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Purchase Order";
            public const int ModuleId = ModuleConstants.Purchase.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobOrder.ControllerName;
            public const string ActionName = ControllerActionConstants.JobOrder.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.PurchaseOrder.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        public static class PurchaseOrderCancel
        {
            public const int MenuId = 32;
            public const string MenuName = "Purchase Order Cancel";
            public const string Srl = "1.3";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Purchase Order Cancel";
            public const int ModuleId = ModuleConstants.Purchase.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobOrderCancel.ControllerName;
            public const string ActionName = ControllerActionConstants.JobOrderCancel.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.PurchaseOrderCancel.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        public static class PurchaseOrderAmendment
        {
            public const int MenuId = 33;
            public const string MenuName = "Purchase Order Amendment";
            public const string Srl = "1.35";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Purchase Order Amendment";
            public const int ModuleId = ModuleConstants.Purchase.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobOrderAmendment.ControllerName;
            public const string ActionName = ControllerActionConstants.JobOrderAmendment.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.PurchaseOrderAmendment.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }
        public static class SupplierAuditRequest
        {
            public const int MenuId = 34;
            public const string MenuName = "Supplier Audit Request";
            public const string Srl = "1.4";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Supplier Audit Request";
            public const int ModuleId = ModuleConstants.Purchase.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobInspectionRequest.ControllerName;
            public const string ActionName = ControllerActionConstants.JobInspectionRequest.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.SupplierAuditRequest.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }
        public static class SupplierAudit
        {
            public const int MenuId = 35;
            public const string MenuName = "Supplier Audit";
            public const string Srl = "1.50";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Supplier Audit";
            public const int ModuleId = ModuleConstants.Purchase.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobInspection.ControllerName;
            public const string ActionName = ControllerActionConstants.JobInspection.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.SupplierAudit.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }
        public static class GoodsReceipt
        {
            public const int MenuId = 36;
            public const string MenuName = "Goods Receipt";
            public const string Srl = "1.55";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Goods Receipt";
            public const int ModuleId = ModuleConstants.Purchase.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobReceive.ControllerName;
            public const string ActionName = ControllerActionConstants.JobReceive.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.GoodsReceipt.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        public static class QualityCheckingInword
        {
            public const int MenuId = 37;
            public const string MenuName = "Quality Checking (Inword)";
            public const string Srl = "1.60";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Quality Checking (Inword)";
            public const int ModuleId = ModuleConstants.Purchase.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobReceiveQC.ControllerName;
            public const string ActionName = ControllerActionConstants.JobReceiveQC.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.QualityCheckingInword.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }
        public static class PurchaseInvoice
        {
            public const int MenuId = 38;
            public const string MenuName = "Purchase Invoice";
            public const string Srl = "1.65";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Purchase Invoice";
            public const int ModuleId = ModuleConstants.Purchase.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobInvoice.ControllerName;
            public const string ActionName = ControllerActionConstants.JobInvoice.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.PurchaseInvoice.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        public static class DebitNoteOutward
        {
            public const int MenuId = 39;
            public const string MenuName = "Debit Note Outward";
            public const string Srl = "1.7";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Debit Note Outward";
            public const int ModuleId = ModuleConstants.Purchase.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.LedgerHeader.ControllerName;
            public const string ActionName = ControllerActionConstants.LedgerHeader.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.DebitNoteOutward.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }
        public static class CreditNoteOutward
        {
            public const int MenuId = 40;
            public const string MenuName = "Credit Note Outward";
            public const string Srl = "1.75";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Credit Note Outward";
            public const int ModuleId = ModuleConstants.Purchase.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.LedgerHeader.ControllerName;
            public const string ActionName = ControllerActionConstants.LedgerHeader.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.CreditNoteOutward.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }
        #endregion
        #region "Purchase Masters"
        public static class Supplier
        {
            public const int MenuId = 41;
            public const string MenuName = "Supplier";
            public const string Srl = "2";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Supplier";
            public const int ModuleId = ModuleConstants.Purchase.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.Person.ControllerName;
            public const string ActionName = ControllerActionConstants.Person.ActionName;
            public static readonly string RouteId = DocumentTypeConstants.Supplier.DocumentTypeId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        #endregion
        #region "Purchase Standard Reports"
        //public static class PurchaseOrderSummary
        //{
        //    public const int MenuId = 42;
        //    public const string MenuName = "Purchase Order Summary";
        //    public const string Srl = "3";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Purchase Order Summary";
        //    public const int ModuleId = ModuleConstants.Purchase.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.StandardReports.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.Report.ControllerName;
        //    public const string ActionName = ControllerActionConstants.Report.ActionName;
        //    public static readonly string RouteId = null;
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}
        //public static class PurchaseGoodsReceiptSummary
        //{
        //    public const int MenuId = 43;
        //    public const string MenuName = "Purchase Goods Receipt Summary";
        //    public const string Srl = "3.05";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Purchase Goods Receipt Summary";
        //    public const int ModuleId = ModuleConstants.Purchase.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.StandardReports.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.Report.ControllerName;
        //    public const string ActionName = ControllerActionConstants.Report.ActionName;
        //    public static readonly string RouteId = null;
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}
        //public static class PurchaseInvoiceSummary
        //{
        //    public const int MenuId = 44;
        //    public const string MenuName = "Purchase Invoice Summary";
        //    public const string Srl = "3.1";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Purchase Invoice Summary";
        //    public const int ModuleId = ModuleConstants.Purchase.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.StandardReports.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.Report.ControllerName;
        //    public const string ActionName = ControllerActionConstants.Report.ActionName;
        //    public static readonly string RouteId = null;
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}
        //#endregion
        //#region "Purchase Status Reports"
        //public static class PurchaseOrderBalance
        //{
        //    public const int MenuId = 45;
        //    public const string MenuName = "Purchase Order Balance";
        //    public const string Srl = "4";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Purchase Order Balance";
        //    public const int ModuleId = ModuleConstants.Purchase.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.StatusReports.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.Report.ControllerName;
        //    public const string ActionName = ControllerActionConstants.Report.ActionName;
        //    public static readonly string RouteId = null;
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}
        #endregion
        #region "Production Transactions"
        public static class ManufacturingPlan
        {
            public const int MenuId = 46;
            public const string MenuName = "Manufacturing Plan";
            public const string Srl = "1";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Manufacturing Plan";
            public const int ModuleId = ModuleConstants.Production.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.ProductionOrder.ControllerName;
            public const string ActionName = ControllerActionConstants.ProductionOrder.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.ManufacturingPlan.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class ManufacturingPlanCancel
        {
            public const int MenuId = 47;
            public const string MenuName = "Manufacturing Plan Cancel";
            public const string Srl = "1.05";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Manufacturing Plan Cancel";
            public const int ModuleId = ModuleConstants.Production.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.ProductionOrderCancel.ControllerName;
            public const string ActionName = ControllerActionConstants.ProductionOrderCancel.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.ManufacturingPlanCancel.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class JobEnquiry
        {
            public const int MenuId = 48;
            public const string MenuName = "Job Enquiry";
            public const string Srl = "1.1";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Job Enquiry";
            public const int ModuleId = ModuleConstants.Production.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobEnquiry.ControllerName;
            public const string ActionName = ControllerActionConstants.JobEnquiry.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.JobEnquiry.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }

        public static class JobEnquiryCancel
        {
            public const int MenuId = 49;
            public const string MenuName = "Job Enquiry Cancel";
            public const string Srl = "1.15";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Job Enquiry Cancel";
            public const int ModuleId = ModuleConstants.Production.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobEnquiryCancel.ControllerName;
            public const string ActionName = ControllerActionConstants.JobEnquiryCancel.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.JobEnquiryCancel.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }

        public static class JobQuotation
        {
            public const int MenuId = 50;
            public const string MenuName = "Job Quotation";
            public const string Srl = "1.2";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Job Quotation";
            public const int ModuleId = ModuleConstants.Production.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobQuotation.ControllerName;
            public const string ActionName = ControllerActionConstants.JobQuotation.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.JobQuotation.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }

        public static class JobQuotationCancel
        {
            public const int MenuId = 51;
            public const string MenuName = "Job Quotation Cancel";
            public const string Srl = "1.25";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Job Quotation Cancel";
            public const int ModuleId = ModuleConstants.Production.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobQuotationCancel.ControllerName;
            public const string ActionName = ControllerActionConstants.JobQuotationCancel.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.JobQuotationCancel.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }

        public static class JobOrder
        {
            public const int MenuId = 52;
            public const string MenuName = "Job Order";
            public const string Srl = "1.3";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Job Order";
            public const int ModuleId = ModuleConstants.Production.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobOrder.ControllerName;
            public const string ActionName = ControllerActionConstants.JobOrder.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.JobOrder.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class JobOrderCancel
        {
            public const int MenuId = 53;
            public const string MenuName = "Job Order Cancel";
            public const string Srl = "1.35";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Job Order Cancel";
            public const int ModuleId = ModuleConstants.Production.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobOrderCancel.ControllerName;
            public const string ActionName = ControllerActionConstants.JobOrderCancel.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.JobOrderCancel.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class JobOrderAmendment
        {
            public const int MenuId = 54;
            public const string MenuName = "Job Order Amendment";
            public const string Srl = "1.4";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Job Order Amendment";
            public const int ModuleId = ModuleConstants.Production.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobOrderAmendment.ControllerName;
            public const string ActionName = ControllerActionConstants.JobOrderAmendment.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.JobOrderAmendment.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }

        public static class JobInspectionRequest
        {
            public const int MenuId = 55;
            public const string MenuName = "Job Inspection Request";
            public const string Srl = "1.45";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Job Inspection Request";
            public const int ModuleId = ModuleConstants.Production.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobInspectionRequest.ControllerName;
            public const string ActionName = ControllerActionConstants.JobInspectionRequest.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.JobInspectionRequest.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }

        public static class JobInspectionRequestCancellation
        {
            public const int MenuId = 56;
            public const string MenuName = "Job Inspection Request Cancellation";
            public const string Srl = "1.5";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Job Inspection Request Cancellation";
            public const int ModuleId = ModuleConstants.Production.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobInspectionRequestCancel.ControllerName;
            public const string ActionName = ControllerActionConstants.JobInspectionRequestCancel.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.JobInspectionRequestCancel.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }

        public static class JobInspection
        {
            public const int MenuId = 57;
            public const string MenuName = "Job Inspection";
            public const string Srl = "1.55";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Job Inspection";
            public const int ModuleId = ModuleConstants.Production.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobInspection.ControllerName;
            public const string ActionName = ControllerActionConstants.JobInspection.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.JobInspection.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }

        public static class JobGoodsReceipt
        {
            public const int MenuId = 58;
            public const string MenuName = "Job Goods Receipt";
            public const string Srl = "1.6";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Job Goods Receipt";
            public const int ModuleId = ModuleConstants.Production.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobReceive.ControllerName;
            public const string ActionName = ControllerActionConstants.JobReceive.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.JobReceive.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class JobGoodsReceiptQC
        {
            public const int MenuId = 59;
            public const string MenuName = "Job Goods Receipt QC";
            public const string Srl = "1.65";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Job Goods Receipt QC";
            public const int ModuleId = ModuleConstants.Production.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobReceiveQC.ControllerName;
            public const string ActionName = ControllerActionConstants.JobReceiveQC.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.JobReceiveQC.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }

        public static class JobInvoice
        {
            public const int MenuId = 60;
            public const string MenuName = "Job Invoice";
            public const string Srl = "1.7";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Job Invoice";
            public const int ModuleId = ModuleConstants.Production.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobInvoice.ControllerName;
            public const string ActionName = ControllerActionConstants.JobInvoice.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.JobInvoice.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class JobReturn
        {
            public const int MenuId = 61;
            public const string MenuName = "Job Return";
            public const string Srl = "1.9";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Job Return";
            public const int ModuleId = ModuleConstants.Production.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.JobInvoiceReturn.ControllerName;
            public const string ActionName = ControllerActionConstants.JobInvoiceReturn.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.JobReturn.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        #endregion
        #region "Production Masters"
        public static class JobWorker
        {
            public const int MenuId = 61;
            public const string MenuName = "Job Worker";
            public const string Srl = "2";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Job Worker";
            public const int ModuleId = ModuleConstants.Production.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.Person.ControllerName;
            public const string ActionName = ControllerActionConstants.Person.ActionName;
            public static readonly string RouteId = DocumentTypeConstants.JobWorker.DocumentTypeId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        #endregion
        //#region "Production Standard Reports"
        //public static class JobOrderSummary
        //{
        //    public const int MenuId = 62;
        //    public const string MenuName = "Job Order Summary";
        //    public const string Srl = "3";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Job Order Summary";
        //    public const int ModuleId = ModuleConstants.Production.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.StandardReports.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.Report.ControllerName;
        //    public const string ActionName = ControllerActionConstants.Report.ActionName;
        //    public static readonly string RouteId = null;
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}

        //public static class JobReceiveSummary
        //{
        //    public const int MenuId = 63;
        //    public const string MenuName = "Job Receive Summary";
        //    public const string Srl = "3.05";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Job Receive Summary";
        //    public const int ModuleId = ModuleConstants.Production.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.StandardReports.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.Report.ControllerName;
        //    public const string ActionName = ControllerActionConstants.Report.ActionName;
        //    public static readonly string RouteId = null;
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}

        //public static class JobInvoiceSummary
        //{
        //    public const int MenuId = 64;
        //    public const string MenuName = "Job Invoice Summary";
        //    public const string Srl = "3.1";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Job Invoice Summary";
        //    public const int ModuleId = ModuleConstants.Production.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.StandardReports.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.Report.ControllerName;
        //    public const string ActionName = ControllerActionConstants.Report.ActionName;
        //    public static readonly string RouteId = null;
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}
        //#endregion
        //#region "Production Status Reports"
        //public static class JobOrderBalance
        //{
        //    public const int MenuId = 65;
        //    public const string MenuName = "Job Order Balance";
        //    public const string Srl = "4";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Job Order Balance";
        //    public const int ModuleId = ModuleConstants.Production.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.StatusReports.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.Report.ControllerName;
        //    public const string ActionName = ControllerActionConstants.Report.ActionName;
        //    public static readonly string RouteId = null;
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}
        //#endregion
        //#region "Inventory Transactions"
        //public static class MaterialIssue
        //{
        //    public const int MenuId = 66;
        //    public const string MenuName = "Material Issue";
        //    public const string Srl = "1";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Material Issue";
        //    public const int ModuleId = ModuleConstants.Inventory.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.StockIssue.ControllerName;
        //    public const string ActionName = ControllerActionConstants.StockIssue.ActionName;
        //    public static readonly string RouteId = DocumentCategoryConstants.MaterialIssue.DocumentCategoryId.ToString();
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}

        //public static class MaterialReceive
        //{
        //    public const int MenuId = 67;
        //    public const string MenuName = "Material Receive";
        //    public const string Srl = "1.05";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Material Receive";
        //    public const int ModuleId = ModuleConstants.Inventory.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.StockReceive.ControllerName;
        //    public const string ActionName = ControllerActionConstants.StockReceive.ActionName;
        //    public static readonly string RouteId = DocumentCategoryConstants.MaterialReceive.DocumentCategoryId.ToString();
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}

        //public static class MaterialTransfer
        //{
        //    public const int MenuId = 68;
        //    public const string MenuName = "Material Transfer";
        //    public const string Srl = "1.1";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Material Transfer";
        //    public const int ModuleId = ModuleConstants.Inventory.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.StockTransfer.ControllerName;
        //    public const string ActionName = ControllerActionConstants.StockTransfer.ActionName;
        //    public static readonly string RouteId = DocumentCategoryConstants.MaterialTransfer.DocumentCategoryId.ToString();
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}

        //public static class StockExchange
        //{
        //    public const int MenuId = 69;
        //    public const string MenuName = "Stock Exchange";
        //    public const string Srl = "1.15";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Stock Exchange";
        //    public const int ModuleId = ModuleConstants.Inventory.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.StockExchange.ControllerName;
        //    public const string ActionName = ControllerActionConstants.StockExchange.ActionName;
        //    public static readonly string RouteId = DocumentCategoryConstants.StockExchange.DocumentCategoryId.ToString();
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}

        public static class GatePass
        {
            public const int MenuId = 70;
            public const string MenuName = "Gate Pass";
            public const string Srl = "1.2";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Gate Pass";
            public const int ModuleId = ModuleConstants.Inventory.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.GatePass.ControllerName;
            public const string ActionName = ControllerActionConstants.GatePass.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.GatePass.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }

        public static class StockReconciliation
        {
            public const int MenuId = 71;
            public const string MenuName = "Stock Reconciliation";
            public const string Srl = "1.25";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Stock Reconciliation";
            public const int ModuleId = ModuleConstants.Inventory.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.StockReconciliation.ControllerName;
            public const string ActionName = ControllerActionConstants.StockReconciliation.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = null;
        }

        #region "Inventory Masters"
        public static class Product
        {
            public const int MenuId = 72;
            public const string MenuName = "Product";
            public const string Srl = "2";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Product";
            public const int ModuleId = ModuleConstants.Inventory.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.Product.ControllerName;
            public const string ActionName = ControllerActionConstants.Product.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class ProductGroup
        {
            public const int MenuId = 73;
            public const string MenuName = "Product Group";
            public const string Srl = "2.05";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Product Group";
            public const int ModuleId = ModuleConstants.Inventory.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.ProductGroup.ControllerName;
            public const string ActionName = ControllerActionConstants.ProductGroup.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class ProductCategory
        {
            public const int MenuId = 74;
            public const string MenuName = "Product Category";
            public const string Srl = "2.1";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Product Category";
            public const int ModuleId = ModuleConstants.Inventory.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.ProductCategory.ControllerName;
            public const string ActionName = ControllerActionConstants.ProductCategory.ActionName;
            public static readonly string RouteId = ProductNatureConstants.TradingProduct.ProductNatureId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class ProductType
        {
            public const int MenuId = 75;
            public const string MenuName = "Product Type";
            public const string Srl = "2.15";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Product Type";
            public const int ModuleId = ModuleConstants.Inventory.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.ProductType.ControllerName;
            public const string ActionName = ControllerActionConstants.ProductType.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class ProductCustomGroup
        {
            public const int MenuId = 76;
            public const string MenuName = "Product Custom Group";
            public const string Srl = "2.2";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Product Custom Group";
            public const int ModuleId = ModuleConstants.Inventory.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.ProductCustomGroup.ControllerName;
            public const string ActionName = ControllerActionConstants.ProductCustomGroup.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class Godown
        {
            public const int MenuId = 77;
            public const string MenuName = "Godown";
            public const string Srl = "2.25";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Godown";
            public const int ModuleId = ModuleConstants.Inventory.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.Godown.ControllerName;
            public const string ActionName = ControllerActionConstants.Godown.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class HSNCode
        {
            public const int MenuId = 78;
            public const string MenuName = "HSN Code";
            public const string Srl = "2.3";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "HSN Code";
            public const int ModuleId = ModuleConstants.Inventory.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.SalesTaxProductCode.ControllerName;
            public const string ActionName = ControllerActionConstants.SalesTaxProductCode.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class Gate
        {
            public const int MenuId = 79;
            public const string MenuName = "Gate";
            public const string Srl = "2.35";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Gate";
            public const int ModuleId = ModuleConstants.Inventory.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.Gate.ControllerName;
            public const string ActionName = ControllerActionConstants.Gate.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class City
        {
            public const int MenuId = 80;
            public const string MenuName = "City";
            public const string Srl = "2.4";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "City";
            public const int ModuleId = ModuleConstants.AdminSetup.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.City.ControllerName;
            public const string ActionName = ControllerActionConstants.City.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class State
        {
            public const int MenuId = 81;
            public const string MenuName = "State";
            public const string Srl = "2.45";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "State";
            public const int ModuleId = ModuleConstants.AdminSetup.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.State.ControllerName;
            public const string ActionName = ControllerActionConstants.State.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class Country
        {
            public const int MenuId = 82;
            public const string MenuName = "Country";
            public const string Srl = "2.5";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Country";
            public const int ModuleId = ModuleConstants.AdminSetup.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.Country.ControllerName;
            public const string ActionName = ControllerActionConstants.Country.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        #endregion
        #region "Inventory Standard Reports"
        #endregion
        #region "Inventory Status Reports"
        //public static class StockInHand
        //{
        //    public const int MenuId = 83;
        //    public const string MenuName = "Stock In Hand";
        //    public const string Srl = "4";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Stock In Hand";
        //    public const int ModuleId = ModuleConstants.Inventory.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.StatusReports.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.Report.ControllerName;
        //    public const string ActionName = ControllerActionConstants.Report.ActionName;
        //    public static readonly string RouteId = null;
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}

        //public static class StockInProcess
        //{
        //    public const int MenuId = 84;
        //    public const string MenuName = "Stock In Process";
        //    public const string Srl = "4.05";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Stock In Process";
        //    public const int ModuleId = ModuleConstants.Inventory.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.StatusReports.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.Report.ControllerName;
        //    public const string ActionName = ControllerActionConstants.Report.ActionName;
        //    public static readonly string RouteId = null;
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}
        #endregion
        #region "Human Resource Transactions"
        #endregion
        #region "Human Resource Masters"
        public static class Employee
        {
            public const int MenuId = 85;
            public const string MenuName = "Employee";
            public const string Srl = "2";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Employee";
            public const int ModuleId = ModuleConstants.HumanResource.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.Employee.ControllerName;
            public const string ActionName = ControllerActionConstants.Employee.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        #endregion
        #region "Human Resource Standard Reports"
        #endregion
        #region "Human Resource Status Reports"
        #endregion
        #region "Accounts Transactions"
        public static class PaymentVoucher
        {
            public const int MenuId = 86;
            public const string MenuName = "Payment Voucher";
            public const string Srl = "1";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Payment Voucher";
            public const int ModuleId = ModuleConstants.Accounts.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.LedgerHeader.ControllerName;
            public const string ActionName = ControllerActionConstants.LedgerHeader.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.PaymentVoucher.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class ReceiptVoucher
        {
            public const int MenuId = 87;
            public const string MenuName = "Receipt Voucher";
            public const string Srl = "1.05";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Receipt Voucher";
            public const int ModuleId = ModuleConstants.Accounts.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.LedgerHeader.ControllerName;
            public const string ActionName = ControllerActionConstants.LedgerHeader.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.ReceiptVoucher.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class JournalVoucher
        {
            public const int MenuId = 88;
            public const string MenuName = "Journal Voucher";
            public const string Srl = "1.1";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Journal Voucher";
            public const int ModuleId = ModuleConstants.Accounts.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.LedgerHeader.ControllerName;
            public const string ActionName = ControllerActionConstants.LedgerHeader.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.JournalVoucher.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class ContraVoucher
        {
            public const int MenuId = 89;
            public const string MenuName = "Contra Voucher";
            public const string Srl = "1.15";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Contra Voucher";
            public const int ModuleId = ModuleConstants.Accounts.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.LedgerHeader.ControllerName;
            public const string ActionName = ControllerActionConstants.LedgerHeader.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.ContraVoucher.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class DebitNote
        {
            public const int MenuId = 90;
            public const string MenuName = "Debit Note";
            public const string Srl = "1.2";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Debit Note";
            public const int ModuleId = ModuleConstants.Accounts.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.LedgerHeader.ControllerName;
            public const string ActionName = ControllerActionConstants.LedgerHeader.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.DebitNote.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class ChequeCancel
        {
            public const int MenuId = 91;
            public const string MenuName = "Cheque Cancel";
            public const string Srl = "1.25";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Cheque Cancel";
            public const int ModuleId = ModuleConstants.Accounts.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.ChequeCancel.ControllerName;
            public const string ActionName = ControllerActionConstants.ChequeCancel.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.ChequeCancel.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class ExpenseVoucher
        {
            public const int MenuId = 92;
            public const string MenuName = "Expense Voucher";
            public const string Srl = "1.3";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Expense Voucher";
            public const int ModuleId = ModuleConstants.Accounts.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.LedgerHeader.ControllerName;
            public const string ActionName = ControllerActionConstants.LedgerHeader.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.ExpenseVoucher.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class CreditNote
        {
            public const int MenuId = 93;
            public const string MenuName = "Credit Note";
            public const string Srl = "1.35";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Credit Note";
            public const int ModuleId = ModuleConstants.Accounts.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.LedgerHeader.ControllerName;
            public const string ActionName = ControllerActionConstants.LedgerHeader.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.CreditNote.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class BankReconciliation
        {
            public const int MenuId = 94;
            public const string MenuName = "Bank Reconciliation";
            public const string Srl = "1.4";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Bank Reconciliation";
            public const int ModuleId = ModuleConstants.Accounts.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.BankReconciliation.ControllerName;
            public const string ActionName = ControllerActionConstants.BankReconciliation.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        #endregion
        #region "Accounts Masters"
        public static class LedgerAccount
        {
            public const int MenuId = 95;
            public const string MenuName = "Ledger Account";
            public const string Srl = "2";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Ledger Account";
            public const int ModuleId = ModuleConstants.Accounts.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.LedgerAccount.ControllerName;
            public const string ActionName = ControllerActionConstants.LedgerAccount.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class LedgerAccountGroup
        {
            public const int MenuId = 96;
            public const string MenuName = "Ledger Account Group";
            public const string Srl = "2.05";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Ledger Account Group";
            public const int ModuleId = ModuleConstants.Accounts.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.LedgerAccountGroup.ControllerName;
            public const string ActionName = ControllerActionConstants.LedgerAccountGroup.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class CostCenter
        {
            public const int MenuId = 97;
            public const string MenuName = "Cost Center";
            public const string Srl = "2.1";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Cost Center";
            public const int ModuleId = ModuleConstants.Accounts.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.CostCenter.ControllerName;
            public const string ActionName = ControllerActionConstants.CostCenter.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class TdsCategory
        {
            public const int MenuId = 98;
            public const string MenuName = "Tds Category";
            public const string Srl = "2.15";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Tds Category";
            public const int ModuleId = ModuleConstants.Accounts.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.TdsCategory.ControllerName;
            public const string ActionName = ControllerActionConstants.TdsCategory.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class TdsGroup
        {
            public const int MenuId = 99;
            public const string MenuName = "Tds Group";
            public const string Srl = "2.2";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Tds Group";
            public const int ModuleId = ModuleConstants.Accounts.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.TdsGroup.ControllerName;
            public const string ActionName = ControllerActionConstants.TdsGroup.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        #endregion
        #region "Accounts Standard Reports"
        #endregion
        #region "Accounts Status Reports"
        //public static class TrialBalance
        //{
        //    public const int MenuId = 100;
        //    public const string MenuName = "Trial Balance";
        //    public const string Srl = "4";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Trial Balance";
        //    public const int ModuleId = ModuleConstants.Accounts.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.StatusReports.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.Report.ControllerName;
        //    public const string ActionName = ControllerActionConstants.Report.ActionName;
        //    public static readonly string RouteId = null;
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}

        //public static class SubTrialBalance
        //{
        //    public const int MenuId = 101;
        //    public const string MenuName = "Sub Trial Balance";
        //    public const string Srl = "4.05";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Sub Trial Balance";
        //    public const int ModuleId = ModuleConstants.Accounts.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.StatusReports.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.Report.ControllerName;
        //    public const string ActionName = ControllerActionConstants.Report.ActionName;
        //    public static readonly string RouteId = null;
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}

        //public static class BalanceSheet
        //{
        //    public const int MenuId = 102;
        //    public const string MenuName = "Balance Sheet";
        //    public const string Srl = "4.1";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Balance Sheet";
        //    public const int ModuleId = ModuleConstants.Accounts.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.StatusReports.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.Report.ControllerName;
        //    public const string ActionName = ControllerActionConstants.Report.ActionName;
        //    public static readonly string RouteId = null;
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}

        //public static class ProfitAndLossAc
        //{
        //    public const int MenuId = 103;
        //    public const string MenuName = "Profit & Loss A/c";
        //    public const string Srl = "4.15";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Profit & Loss A/c";
        //    public const int ModuleId = ModuleConstants.Accounts.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.StatusReports.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.Report.ControllerName;
        //    public const string ActionName = ControllerActionConstants.Report.ActionName;
        //    public static readonly string RouteId = null;
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}

        //public static class CashBook
        //{
        //    public const int MenuId = 104;
        //    public const string MenuName = "Cash Book";
        //    public const string Srl = "4.2";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Cash Book";
        //    public const int ModuleId = ModuleConstants.Accounts.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.StatusReports.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.Report.ControllerName;
        //    public const string ActionName = ControllerActionConstants.Report.ActionName;
        //    public static readonly string RouteId = null;
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}

        //public static class BankBook
        //{
        //    public const int MenuId = 105;
        //    public const string MenuName = "Bank Book";
        //    public const string Srl = "4.25";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Bank Book";
        //    public const int ModuleId = ModuleConstants.Accounts.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.StatusReports.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.Report.ControllerName;
        //    public const string ActionName = ControllerActionConstants.Report.ActionName;
        //    public static readonly string RouteId = null;
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}

        //public static class DayBook
        //{
        //    public const int MenuId = 106;
        //    public const string MenuName = "Day Book";
        //    public const string Srl = "4.3";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Day Book";
        //    public const int ModuleId = ModuleConstants.Accounts.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.StatusReports.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.Report.ControllerName;
        //    public const string ActionName = ControllerActionConstants.Report.ActionName;
        //    public static readonly string RouteId = null;
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}

        //public static class DebtorsAgeingAnalysisFIFO
        //{
        //    public const int MenuId = 107;
        //    public const string MenuName = "Debtors Ageing Analysis FIFO";
        //    public const string Srl = "4.35";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Debtors Ageing Analysis FIFO";
        //    public const int ModuleId = ModuleConstants.Accounts.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.StatusReports.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.Report.ControllerName;
        //    public const string ActionName = ControllerActionConstants.Report.ActionName;
        //    public static readonly string RouteId = null;
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}

        //public static class DebtorsOutstandingFIFO
        //{
        //    public const int MenuId = 108;
        //    public const string MenuName = "Debtors Outstanding FIFO";
        //    public const string Srl = "4.4";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Debtors Outstanding FIFO";
        //    public const int ModuleId = ModuleConstants.Accounts.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.StatusReports.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.Report.ControllerName;
        //    public const string ActionName = ControllerActionConstants.Report.ActionName;
        //    public static readonly string RouteId = null;
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}

        //public static class CreditorsAgeingAnalysisFIFO
        //{
        //    public const int MenuId = 109;
        //    public const string MenuName = "Creditors Ageing Analysis FIFO";
        //    public const string Srl = "4.45";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Creditors Ageing Analysis FIFO";
        //    public const int ModuleId = ModuleConstants.Accounts.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.StatusReports.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.Report.ControllerName;
        //    public const string ActionName = ControllerActionConstants.Report.ActionName;
        //    public static readonly string RouteId = null;
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}

        //public static class CreditorsOutstandingFIFO
        //{
        //    public const int MenuId = 110;
        //    public const string MenuName = "Creditors Outstanding FIFO";
        //    public const string Srl = "4.5";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Creditors Outstanding FIFO";
        //    public const int ModuleId = ModuleConstants.Accounts.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.StatusReports.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.Report.ControllerName;
        //    public const string ActionName = ControllerActionConstants.Report.ActionName;
        //    public static readonly string RouteId = null;
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}

        //public static class TDSAdvise
        //{
        //    public const int MenuId = 111;
        //    public const string MenuName = "TDS Advise";
        //    public const string Srl = "4.55";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "TDS Advise";
        //    public const int ModuleId = ModuleConstants.Accounts.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.StatusReports.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.Report.ControllerName;
        //    public const string ActionName = ControllerActionConstants.Report.ActionName;
        //    public static readonly string RouteId = null;
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}

        //public static class InputTaxReport
        //{
        //    public const int MenuId = 112;
        //    public const string MenuName = "Input Tax Report";
        //    public const string Srl = "4.6";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Input Tax Report";
        //    public const int ModuleId = ModuleConstants.Accounts.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.StatusReports.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.Report.ControllerName;
        //    public const string ActionName = ControllerActionConstants.Report.ActionName;
        //    public static readonly string RouteId = null;
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}
        #endregion
        #region "Planning Transactions"
        public static class Planning
        {
            public const int MenuId = 113;
            public const string MenuName = "Planning";
            public const string Srl = "1";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Planning";
            public const int ModuleId = ModuleConstants.Planning.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.Planning.ControllerName;
            public const string ActionName = ControllerActionConstants.Planning.ActionName;
            public static readonly string RouteId = DocumentCategoryConstants.Planning.DocumentCategoryId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        #endregion
        #region "Planning Masters"
        #endregion
        #region "Planning Standard Reports"
        #endregion
        #region "Planning Status Reports"
        //public static class SaleOrderPlanStatus
        //{
        //    public const int MenuId = 114;
        //    public const string MenuName = "Sale Order Plan Status";
        //    public const string Srl = "4";
        //    public const string IconName = "glyphicon glyphicon-book";
        //    public const string Description = "Sale Order Plan Status";
        //    public const int ModuleId = ModuleConstants.Planning.ModuleId;
        //    public const int SubModuleId = SubModuleConstants.StatusReports.SubModuleId;
        //    public const string ControllerName = ControllerActionConstants.Report.ControllerName;
        //    public const string ActionName = ControllerActionConstants.Report.ActionName;
        //    public static readonly string RouteId = null;
        //    public const string URL = "JobsDomain";
        //    public const bool IsVisible = true;
        //    public const string AreaName = null;
        //}
        #endregion
        #region "Admin Setup Transactions"
        #endregion
        #region "Admin Setup Masters"
        public static class ChargeGroupSettings
        {
            public const int MenuId = 115;
            public const string MenuName = "Charge Group Settings";
            public const string Srl = "2";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Charge Group Settings";
            public const int ModuleId = ModuleConstants.AdminSetup.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.ChargeGroupSettings.ControllerName;
            public const string ActionName = ControllerActionConstants.ChargeGroupSettings.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class DocumentCategory
        {
            public const int MenuId = 116;
            public const string MenuName = "Document Category";
            public const string Srl = "2.05";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Document Category";
            public const int ModuleId = ModuleConstants.AdminSetup.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.DocumentCategory.ControllerName;
            public const string ActionName = ControllerActionConstants.DocumentCategory.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class DocumentType
        {
            public const int MenuId = 117;
            public const string MenuName = "Document Type";
            public const string Srl = "2.1";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Document Type";
            public const int ModuleId = ModuleConstants.AdminSetup.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.DocumentType.ControllerName;
            public const string ActionName = ControllerActionConstants.DocumentType.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class Site
        {
            public const int MenuId = 118;
            public const string MenuName = "Site";
            public const string Srl = "2.15";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Site";
            public const int ModuleId = ModuleConstants.AdminSetup.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.Site.ControllerName;
            public const string ActionName = ControllerActionConstants.Site.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class Division
        {
            public const int MenuId = 119;
            public const string MenuName = "Division";
            public const string Srl = "2.2";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Division";
            public const int ModuleId = ModuleConstants.AdminSetup.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.Division.ControllerName;
            public const string ActionName = ControllerActionConstants.Division.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class Calculation
        {
            public const int MenuId = 120;
            public const string MenuName = "Calculation";
            public const string Srl = "2.25";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Calculation";
            public const int ModuleId = ModuleConstants.AdminSetup.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.Calculation.ControllerName;
            public const string ActionName = ControllerActionConstants.Calculation.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class CalculationLedgerAccounts
        {
            public const int MenuId = 121;
            public const string MenuName = "Calculation Ledger Accounts";
            public const string Srl = "2.3";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Calculation Ledger Accounts";
            public const int ModuleId = ModuleConstants.AdminSetup.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.CalculationLedgerAccounts.ControllerName;
            public const string ActionName = ControllerActionConstants.CalculationLedgerAccounts.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class Charge
        {
            public const int MenuId = 122;
            public const string MenuName = "Charge";
            public const string Srl = "2.35";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Charge";
            public const int ModuleId = ModuleConstants.AdminSetup.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.Charge.ControllerName;
            public const string ActionName = ControllerActionConstants.Charge.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class AssignPermissions
        {
            public const int MenuId = 123;
            public const string MenuName = "Assign Permissions";
            public const string Srl = "2.4";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Assign Permissions";
            public const int ModuleId = ModuleConstants.AdminSetup.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.AssignPermissions.ControllerName;
            public const string ActionName = ControllerActionConstants.AssignPermissions.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class CreateRoles
        {
            public const int MenuId = 124;
            public const string MenuName = "Create Roles";
            public const string Srl = "2.45";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Create Roles";
            public const int ModuleId = ModuleConstants.AdminSetup.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.CreateRoles.ControllerName;
            public const string ActionName = ControllerActionConstants.CreateRoles.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class Reason
        {
            public const int MenuId = 125;
            public const string MenuName = "Reason";
            public const string Srl = "2.5";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Reason";
            public const int ModuleId = ModuleConstants.AdminSetup.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.Reason.ControllerName;
            public const string ActionName = ControllerActionConstants.Reason.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class AssignNewRoles
        {
            public const int MenuId = 126;
            public const string MenuName = "Assign New Roles";
            public const string Srl = "2.55";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Assign New Roles";
            public const int ModuleId = ModuleConstants.AdminSetup.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.AssignNewRoles.ControllerName;
            public const string ActionName = ControllerActionConstants.AssignNewRoles.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class AssignTemporaryRoles
        {
            public const int MenuId = 127;
            public const string MenuName = "Assign Temporary Roles";
            public const string Srl = "2.6";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Assign Temporary Roles";
            public const int ModuleId = ModuleConstants.AdminSetup.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.AssignTemporaryRoles.ControllerName;
            public const string ActionName = ControllerActionConstants.AssignTemporaryRoles.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class UpdateTableStructure
        {
            public const int MenuId = 128;
            public const string MenuName = "Update Table Structure";
            public const string Srl = "2.65";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Update Table Structure";
            public const int ModuleId = ModuleConstants.AdminSetup.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.UpdateTableStructure.ControllerName;
            public const string ActionName = ControllerActionConstants.UpdateTableStructure.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class UserInvitation
        {
            public const int MenuId = 129;
            public const string MenuName = "User Invitation";
            public const string Srl = "2.7";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "User Invitation";
            public const int ModuleId = ModuleConstants.AdminSetup.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.UserInvitation.ControllerName;
            public const string ActionName = ControllerActionConstants.UserInvitation.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        #endregion
        #region "Admin Setup Standard Reports"
        #endregion
        #region "Admin Setup Status Reports"
        #endregion
        #region "Task Management Transactions"
        public static class DAR
        {
            public const int MenuId = 130;
            public const string MenuName = "DAR";
            public const string Srl = "1";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "DAR";
            public const int ModuleId = ModuleConstants.Task.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.DAR.ControllerName;
            public const string ActionName = ControllerActionConstants.DAR.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        #endregion
        #region "Task Management Masters"
        public static class Tasks
        {
            public const int MenuId = 131;
            public const string MenuName = "Tasks";
            public const string Srl = "2";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Tasks";
            public const int ModuleId = ModuleConstants.Task.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.Tasks.ControllerName;
            public const string ActionName = ControllerActionConstants.Tasks.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        #endregion
        #region "Task Management Standard Reports"
        #endregion
        #region "Task Management Status Reports"
        #endregion


        public static class SaleEnquiryProductMapping
        {
            public const int MenuId = 132;
            public const string MenuName = "Sale Enquiry Product Mapping";
            public const string Srl = "132";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Sale Enquiry Product Mapping";
            public const int ModuleId = ModuleConstants.Sales.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = ControllerActionConstants.SaleEnquiryProductMappingWithGrid.ControllerName;
            public const string ActionName = ControllerActionConstants.SaleEnquiryProductMappingWithGrid.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class Collection
        {
            public const int MenuId = 133;
            public const string MenuName = "Collection";
            public const string Srl = "133";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Collection";
            public const int ModuleId = ModuleConstants.Inventory.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.Collection.ControllerName;
            public const string ActionName = ControllerActionConstants.Collection.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = AreaConstants.Rug.AreaName;
        }

        public static class Content
        {
            public const int MenuId = 134;
            public const string MenuName = "Content";
            public const string Srl = "134";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Content";
            public const int ModuleId = ModuleConstants.Inventory.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.Content.ControllerName;
            public const string ActionName = ControllerActionConstants.Content.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = AreaConstants.Rug.AreaName;
        }

        public static class Quality
        {
            public const int MenuId = 135;
            public const string MenuName = "Quality";
            public const string Srl = "135";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Quality";
            public const int ModuleId = ModuleConstants.Inventory.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.Quality.ControllerName;
            public const string ActionName = ControllerActionConstants.Quality.ActionName;
            public static readonly string RouteId = RugProductTypeConstants.Rug.ProductTypeId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = AreaConstants.Rug.AreaName;
        }

        public static class Dimension1
        {
            public const int MenuId = 136;
            public const string MenuName = "Dimension1";
            public const string Srl = "132";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Dimension1";
            public const int ModuleId = ModuleConstants.Inventory.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.Dimension1.ControllerName;
            public const string ActionName = ControllerActionConstants.Dimension1.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class Size
        {
            public const int MenuId = 137;
            public const string MenuName = "Size";
            public const string Srl = "137";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Size";
            public const int ModuleId = ModuleConstants.Inventory.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.Size.ControllerName;
            public const string ActionName = ControllerActionConstants.Size.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = AreaConstants.Rug.AreaName;
        }

        public static class ProcessSequence
        {
            public const int MenuId = 138;
            public const string MenuName = "Process Sequence";
            public const string Srl = "138";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Process Sequence";
            public const int ModuleId = ModuleConstants.Inventory.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.ProcessSequenceHeader.ControllerName;
            public const string ActionName = ControllerActionConstants.ProcessSequenceHeader.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class Colour
        {
            public const int MenuId = 139;
            public const string MenuName = "Colour";
            public const string Srl = "139";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Colour";
            public const int ModuleId = ModuleConstants.Inventory.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = ControllerActionConstants.Colour.ControllerName;
            public const string ActionName = ControllerActionConstants.Colour.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = AreaConstants.Rug.AreaName;
        }


        public static class StockBalanceDisplay
        {
            public const int MenuId = 140;
            public const string MenuName = "Stock Balance Display";
            public const string Srl = "140";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Stock Balance Display";
            public const int ModuleId = ModuleConstants.Inventory.ModuleId;
            public const int SubModuleId = SubModuleConstants.Display.SubModuleId;
            public const string ControllerName = ControllerActionConstants.StockBalanceDisplay.ControllerName;
            public const string ActionName = ControllerActionConstants.StockBalanceDisplay.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class TrialBalance
        {
            public const int MenuId = 141;
            public const string MenuName = "Trial Balance";
            public const string Srl = "141";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Trial Balance";
            public const int ModuleId = ModuleConstants.Accounts.ModuleId;
            public const int SubModuleId = SubModuleConstants.Display.SubModuleId;
            public const string ControllerName = ControllerActionConstants.TrialBalance.ControllerName;
            public const string ActionName = ControllerActionConstants.TrialBalance.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        public static class SubTrialBalance
        {
            public const int MenuId = 142;
            public const string MenuName = "Sub Trial Balance";
            public const string Srl = "142";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Sub Trial Balance";
            public const int ModuleId = ModuleConstants.Accounts.ModuleId;
            public const int SubModuleId = SubModuleConstants.Display.SubModuleId;
            public const string ControllerName = ControllerActionConstants.TrialBalance.ControllerName;
            public const string ActionName = ControllerActionConstants.TrialBalance.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        public static class BalanceSheet
        {
            public const int MenuId = 143;
            public const string MenuName = "Balance Sheet";
            public const string Srl = "143";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Balance Sheet";
            public const int ModuleId = ModuleConstants.Accounts.ModuleId;
            public const int SubModuleId = SubModuleConstants.Display.SubModuleId;
            public const string ControllerName = ControllerActionConstants.TrialBalance.ControllerName;
            public const string ActionName = ControllerActionConstants.TrialBalance.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
        public static class ProfitAndLoss
        {
            public const int MenuId = 144;
            public const string MenuName = "Profit And Loss";
            public const string Srl = "144";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Profit And Loss";
            public const int ModuleId = ModuleConstants.Accounts.ModuleId;
            public const int SubModuleId = SubModuleConstants.Display.SubModuleId;
            public const string ControllerName = ControllerActionConstants.TrialBalance.ControllerName;
            public const string ActionName = ControllerActionConstants.TrialBalance.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }
    }
}