using Jobs.Constants.DocumentCategory;
using Jobs.Constants.DocumentNature;
using Jobs.Constants.RugDocumentCategory;
using Jobs.Constants.RugDocumentNature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobs.Constants.DocumentType
{
    public static class DocumentTypeConstants
    {
        #region "Sales"
        public static class SaleEnquiry
        {
            public const int DocumentTypeId = 1;
            public const string DocumentTypeShortName = "SE";
            public const string DocumentTypeName = "Sale Enquiry";
            public const int DocumentCategoryId = DocumentCategoryConstants.SaleEnquiry.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.SaleEnquiry.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class SaleEnquiryCancel
        {
            public const int DocumentTypeId = 2;
            public const string DocumentTypeShortName = "SEC";
            public const string DocumentTypeName = "Sale Enquiry Cancel";
            public const int DocumentCategoryId = DocumentCategoryConstants.SaleEnquiryCancel.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.SaleEnquiryCancel.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class SaleQuotation
        {
            public const int DocumentTypeId = 3;
            public const string DocumentTypeShortName = "SQ";
            public const string DocumentTypeName = "Sale Quotation";
            public const int DocumentCategoryId = DocumentCategoryConstants.SaleQuotation.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.SaleQuotation.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class SaleQuotationCancel
        {
            public const int DocumentTypeId = 4;
            public const string DocumentTypeShortName = "SQC";
            public const string DocumentTypeName = "Sale Quotation Cancel";
            public const int DocumentCategoryId = DocumentCategoryConstants.SaleQuotationCancel.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.SaleQuotationCancel.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class SaleOrder 
        {
            public const int DocumentTypeId = 5;
            public const string DocumentTypeShortName = "SO";
            public const string DocumentTypeName = "Sale Order";
            public const int DocumentCategoryId = DocumentCategoryConstants.SaleOrder.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.SaleOrder.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class SaleOrderCancel
        {
            public const int DocumentTypeId = 6;
            public const string DocumentTypeShortName = "SOC";
            public const string DocumentTypeName = "Sale Order Cancel";
            public const int DocumentCategoryId = DocumentCategoryConstants.SaleOrderCancel.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.SaleOrderCancel.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class SaleOrderAmendment
        {
            public const int DocumentTypeId = 7;
            public const string DocumentTypeShortName = "SOA";
            public const string DocumentTypeName = "Sale Order Amendment";
            public const int DocumentCategoryId = DocumentCategoryConstants.SaleOrderAmendment.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.SaleOrderAmendment.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class CustomerAuditRequest
        {
            public const int DocumentTypeId = 8;
            public const string DocumentTypeShortName = "CAR";
            public const string DocumentTypeName = "Customer Audit Request";
            public const int DocumentCategoryId = DocumentCategoryConstants.CustomerAuditRequest.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.SaleInspectionRequest.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class CustomerAudit
        {
            public const int DocumentTypeId = 9;
            public const string DocumentTypeShortName = "CA";
            public const string DocumentTypeName = "Customer Audit";
            public const int DocumentCategoryId = DocumentCategoryConstants.CustomerAudit.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.SaleInspection.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class Packing
        {
            public const int DocumentTypeId = 10;
            public const string DocumentTypeShortName = "PK";
            public const string DocumentTypeName = "Packing";
            public const int DocumentCategoryId = DocumentCategoryConstants.Packing.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Packing.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class GoodsDispatch
        {
            public const int DocumentTypeId = 11;
            public const string DocumentTypeShortName = "GD";
            public const string DocumentTypeName = "Goods Dispatch";
            public const int DocumentCategoryId = DocumentCategoryConstants.GoodsDispatch.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.SaleGoodsDispatch.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class GoodsReturnInword
        {
            public const int DocumentTypeId = 12;
            public const string DocumentTypeShortName = "GRI";
            public const string DocumentTypeName = "Goods Return (Inword)";
            public const int DocumentCategoryId = DocumentCategoryConstants.GoodsReturnInword.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.SaleGoodsDispatchReturn.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class SaleInvoice
        {
            public const int DocumentTypeId = 13;
            public const string DocumentTypeShortName = "SI";
            public const string DocumentTypeName = "Sale Invoice";
            public const int DocumentCategoryId = DocumentCategoryConstants.SaleInvoice.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.SaleInvoice.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class SaleReturn
        {
            public const int DocumentTypeId = 14;
            public const string DocumentTypeShortName = "SR";
            public const string DocumentTypeName = "Sale Return";
            public const int DocumentCategoryId = DocumentCategoryConstants.SaleReturn.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.SaleInvoiceReturn.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class DeliveryOrder
        {
            public const int DocumentTypeId = 15;
            public const string DocumentTypeShortName = "DO";
            public const string DocumentTypeName = "Delivery Order";
            public const int DocumentCategoryId = DocumentCategoryConstants.DeliveryOrder.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.SaleInvoiceReturn.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class DeliveryOrderCancel
        {
            public const int DocumentTypeId = 16;
            public const string DocumentTypeShortName = "DOC";
            public const string DocumentTypeName = "Delivery Order Cancel";
            public const int DocumentCategoryId = DocumentCategoryConstants.DeliveryOrderCancel.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.SaleInvoiceReturn.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class QualityCheckingOutword
        {
            public const int DocumentTypeId = 17;
            public const string DocumentTypeShortName = "QCO";
            public const string DocumentTypeName = "Quality Checking (Outword)";
            public const int DocumentCategoryId = DocumentCategoryConstants.QualityCheckingOutword.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.SaleInvoiceReturn.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class WayBillOutword
        {
            public const int DocumentTypeId = 18;
            public const string DocumentTypeShortName = "WBO";
            public const string DocumentTypeName = "Way Bill (Outword)";
            public const int DocumentCategoryId = DocumentCategoryConstants.WayBillOutword.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.SaleInvoiceReturn.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        #endregion
        #region "Purchase"
        public static class PurchasePlan
        {
            public const int DocumentTypeId = 101;
            public const string DocumentTypeShortName = "PP";
            public const string DocumentTypeName = "Purchase Plan";
            public const int DocumentCategoryId = DocumentCategoryConstants.PurchasePlan.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.ProductionOrder.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class PurchasePlanCancel
        {
            public const int DocumentTypeId = 102;
            public const string DocumentTypeShortName = "PPC";
            public const string DocumentTypeName = "Purchase Plan Cancel";
            public const int DocumentCategoryId = DocumentCategoryConstants.PurchasePlanCancel.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.ProductionOrderCancel.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class PurchaseEnquiry
        {
            public const int DocumentTypeId = 103;
            public const string DocumentTypeShortName = "PE";
            public const string DocumentTypeName = "Purchase Enquiry";
            public const int DocumentCategoryId = DocumentCategoryConstants.PurchaseEnquiry.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobEnquiry.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class PurchaseEnquiryCancel
        {
            public const int DocumentTypeId = 104;
            public const string DocumentTypeShortName = "PEC";
            public const string DocumentTypeName = "Purchase Enquiry Cancel";
            public const int DocumentCategoryId = DocumentCategoryConstants.PurchaseEnquiryCancel.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobEnquiryCancel.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class PurchaseQuotation
        {
            public const int DocumentTypeId = 105;
            public const string DocumentTypeShortName = "PQ";
            public const string DocumentTypeName = "Purchase Quotation";
            public const int DocumentCategoryId = DocumentCategoryConstants.PurchaseQuotation.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobQuotation.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class PurchaseQuotationCancel
        {
            public const int DocumentTypeId = 106;
            public const string DocumentTypeShortName = "PQC";
            public const string DocumentTypeName = "Purchase Quotation Cancel";
            public const int DocumentCategoryId = DocumentCategoryConstants.PurchaseQuotationCancel.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobQuotationCancel.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class PurchaseOrder
        {
            public const int DocumentTypeId = 107;
            public const string DocumentTypeShortName = "PO";
            public const string DocumentTypeName = "Purchase Order";
            public const int DocumentCategoryId = DocumentCategoryConstants.PurchaseOrder.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobOrder.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class PurchaseOrderCancel
        {
            public const int DocumentTypeId = 108;
            public const string DocumentTypeShortName = "POC";
            public const string DocumentTypeName = "Purchase Order Cancel";
            public const int DocumentCategoryId = DocumentCategoryConstants.PurchaseOrderCancel.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobOrderCancel.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class PurchaseOrderAmendment
        {
            public const int DocumentTypeId = 109;
            public const string DocumentTypeShortName = "POA";
            public const string DocumentTypeName = "Purchase Order Amendment";
            public const int DocumentCategoryId = DocumentCategoryConstants.PurchaseOrderAmendment.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobOrderAmendment.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class SupplierAuditRequest
        {
            public const int DocumentTypeId = 110;
            public const string DocumentTypeShortName = "SAR";
            public const string DocumentTypeName = "Supplier Audit Request";
            public const int DocumentCategoryId = DocumentCategoryConstants.SupplierAuditRequest.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobInspectionRequest.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class SupplierAudit
        {
            public const int DocumentTypeId = 111;
            public const string DocumentTypeShortName = "SA";
            public const string DocumentTypeName = "Supplier Audit";
            public const int DocumentCategoryId = DocumentCategoryConstants.SupplierAudit.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobInspection.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class GoodsReceipt
        {
            public const int DocumentTypeId = 112;
            public const string DocumentTypeShortName = "GR";
            public const string DocumentTypeName = "Goods Receipt";
            public const int DocumentCategoryId = DocumentCategoryConstants.GoodsReceipt.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobReceive.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class QualityCheckingInword
        {
            public const int DocumentTypeId = 113;
            public const string DocumentTypeShortName = "QCI";
            public const string DocumentTypeName = "Quality Checking (Inword)";
            public const int DocumentCategoryId = DocumentCategoryConstants.QualityCheckingInword.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobReceiveQC.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class GoodsReturnOutword
        {
            public const int DocumentTypeId = 114;
            public const string DocumentTypeShortName = "GRO";
            public const string DocumentTypeName = "Goods Return (Outword)";
            public const int DocumentCategoryId = DocumentCategoryConstants.GoodsReturnOutword.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobReturn.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class PurchaseInvoice
        {
            public const int DocumentTypeId = 115;
            public const string DocumentTypeShortName = "PI";
            public const string DocumentTypeName = "Purchase Invoice";
            public const int DocumentCategoryId = DocumentCategoryConstants.PurchaseInvoice.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobInvoice.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class PurchaseReturn
        {
            public const int DocumentTypeId = 116;
            public const string DocumentTypeShortName = "PR";
            public const string DocumentTypeName = "Purchase Return";
            public const int DocumentCategoryId = DocumentCategoryConstants.PurchaseReturn.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobInvoiceReturn.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class WayBillInword
        {
            public const int DocumentTypeId = 117;
            public const string DocumentTypeShortName = "WBI";
            public const string DocumentTypeName = "Way Bill (Inword)";
            public const int DocumentCategoryId = DocumentCategoryConstants.WayBillInword.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.SaleInvoiceReturn.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        #endregion
        #region "Job"
        public static class ManufacturingPlan
        {
            public const int DocumentTypeId = 301;
            public const string DocumentTypeShortName = "MP";
            public const string DocumentTypeName = "Manufacturing Plan";
            public const int DocumentCategoryId = DocumentCategoryConstants.ManufacturingPlan.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.ProductionOrder.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class ManufacturingPlanCancel
        {
            public const int DocumentTypeId = 302;
            public const string DocumentTypeShortName = "MPC";
            public const string DocumentTypeName = "Manufacturing Plan Cancel";
            public const int DocumentCategoryId = DocumentCategoryConstants.ManufacturingPlanCancel.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobQuotation.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class JobEnquiry
        {
            public const int DocumentTypeId = 303;
            public const string DocumentTypeShortName = "JE";
            public const string DocumentTypeName = "Job Enquiry";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobEnquiry.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobEnquiry.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class JobEnquiryCancel
        {
            public const int DocumentTypeId = 304;
            public const string DocumentTypeShortName = "JEC";
            public const string DocumentTypeName = "Job Enquiry Cancel";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobEnquiryCancel.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobEnquiryCancel.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class JobQuotation
        {
            public const int DocumentTypeId = 305;
            public const string DocumentTypeShortName = "JQ";
            public const string DocumentTypeName = "Job Quotation";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobQuotation.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobQuotation.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class JobQuotationCancel
        {
            public const int DocumentTypeId = 306;
            public const string DocumentTypeShortName = "JQC";
            public const string DocumentTypeName = "Job Quotation Cancel";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobQuotationCancel.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobQuotation.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class JobOrder
        {
            public const int DocumentTypeId = 307;
            public const string DocumentTypeShortName = "JO";
            public const string DocumentTypeName = "Job Order";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobOrder.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobOrder.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class JobOrderWeaving
        {
            public const int DocumentTypeId = 308;
            public const string DocumentTypeShortName = "JOW";
            public const string DocumentTypeName = "Weaving Order";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobOrder.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobOrder.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class JobOrderDyeing
        {
            public const int DocumentTypeId = 309;
            public const string DocumentTypeShortName = "JOD";
            public const string DocumentTypeName = "Dyeing Order";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobOrder.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobOrder.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class JobOrderFinishing
        {
            public const int DocumentTypeId = 310;
            public const string DocumentTypeShortName = "JOF";
            public const string DocumentTypeName = "Finishing Order";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobOrder.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobOrder.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class JobOrderCancel
        {
            public const int DocumentTypeId = 311;
            public const string DocumentTypeShortName = "JOC";
            public const string DocumentTypeName = "Job Order Cancel";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobOrderCancel.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobOrderCancel.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class JobOrderAmendment
        {
            public const int DocumentTypeId = 312;
            public const string DocumentTypeShortName = "JOA";
            public const string DocumentTypeName = "Job Order Amendment";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobOrderAmendment.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobOrderAmendment.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class JobReceive
        {
            public const int DocumentTypeId = 313;
            public const string DocumentTypeShortName = "JR";
            public const string DocumentTypeName = "Job Receive";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobReceive.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobReceive.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class WeavingReceive
        {
            public const int DocumentTypeId = 314;
            public const string DocumentTypeShortName = "JRW";
            public const string DocumentTypeName = "Weaving Receive";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobReceive.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobReceive.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class DyeingReceive
        {
            public const int DocumentTypeId = 315;
            public const string DocumentTypeShortName = "JRD";
            public const string DocumentTypeName = "Dyeing Receive";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobReceive.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobReceive.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class FinishingReceive
        {
            public const int DocumentTypeId = 316;
            public const string DocumentTypeShortName = "JRF";
            public const string DocumentTypeName = "Finishing Receive";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobReceive.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobReceive.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class JobInvoice
        {
            public const int DocumentTypeId = 317;
            public const string DocumentTypeShortName = "JI";
            public const string DocumentTypeName = "Job Invoice";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobInvoice.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobInvoice.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class JobInvoiceWeaving
        {
            public const int DocumentTypeId = 318;
            public const string DocumentTypeShortName = "JIW";
            public const string DocumentTypeName = "Weaving Invoice";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobInvoice.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobInvoice.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class JobInvoiceDyeing
        {
            public const int DocumentTypeId = 319;
            public const string DocumentTypeShortName = "JID";
            public const string DocumentTypeName = "Dyeing Invoice";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobInvoice.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobInvoice.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class JobInvoiceFinishing
        {
            public const int DocumentTypeId = 320;
            public const string DocumentTypeShortName = "JIF";
            public const string DocumentTypeName = "Finishing Invoice";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobInvoice.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobInvoice.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class JobReturn
        {
            public const int DocumentTypeId = 321;
            public const string DocumentTypeShortName = "JRT";
            public const string DocumentTypeName = "Job Return";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobReturn.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobInvoiceReturn.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        #endregion
        #region "Inventory"
        public static class StockOpening
        {
            public const int DocumentTypeId = 401;
            public const string DocumentTypeShortName = "OS";
            public const string DocumentTypeName = "Stock Opening";
            public const int DocumentCategoryId = DocumentCategoryConstants.MaterialReceive.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.StockReceive.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class MaterialRequest
        {
            public const int DocumentTypeId = 402;
            public const string DocumentTypeShortName = "MRQ";
            public const string DocumentTypeName = "Material Request";
            public const int DocumentCategoryId = DocumentCategoryConstants.MaterialRequest.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.StockRequisition.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class MaterialRequestCancel
        {
            public const int DocumentTypeId = 403;
            public const string DocumentTypeShortName = "SRC";
            public const string DocumentTypeName = "Material Request Cancel";
            public const int DocumentCategoryId = DocumentCategoryConstants.MaterialRequestCancel.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.StockRequisitionCancel.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class MaterialIssue
        {
            public const int DocumentTypeId = 404;
            public const string DocumentTypeShortName = "MI";
            public const string DocumentTypeName = "Material Issue";
            public const int DocumentCategoryId = DocumentCategoryConstants.MaterialIssue.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.StockIssue.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class MaterialReceive
        {
            public const int DocumentTypeId = 405;
            public const string DocumentTypeShortName = "MR";
            public const string DocumentTypeName = "Material Receive";
            public const int DocumentCategoryId = DocumentCategoryConstants.MaterialReceive.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.StockReceive.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class MaterialTransfer
        {
            public const int DocumentTypeId = 406;
            public const string DocumentTypeShortName = "MT";
            public const string DocumentTypeName = "Material Transfer";
            public const int DocumentCategoryId = DocumentCategoryConstants.MaterialTransfer.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.StockTransfer.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        #endregion
        #region "Planning"
        //public static class SaleOrderPlan
        //{
        //    public const int DocumentTypeId = 600;
        //    public const string DocumentTypeShortName = "SOPLN";
        //    public const string DocumentTypeName = "Sales Order Plan";
        //    public const int DocumentCategoryId = DocumentCategoryConstants.SaleOrderPlan.DocumentCategoryId;
        //    public const int DocumentNatureId = DocumentNatureConstants.SaleOrderPlan.DocumentNatureId;
        //    public const string Nature = null;
        //    public const string PrintTitle = null;
        //}
        #endregion
        #region "Accounts"
        public static class LedgerOpening
        {
            public const int DocumentTypeId = 501;
            public const string DocumentTypeShortName = "LO";
            public const string DocumentTypeName = "Ledger Opening";
            public const int DocumentCategoryId = DocumentCategoryConstants.PaymentVoucher.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.PaymentVoucher.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class BankPayment
        {
            public const int DocumentTypeId = 502;
            public const string DocumentTypeShortName = "BP";
            public const string DocumentTypeName = "Bank Payment";
            public const int DocumentCategoryId = DocumentCategoryConstants.PaymentVoucher.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.PaymentVoucher.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class CashPayment
        {
            public const int DocumentTypeId = 503;
            public const string DocumentTypeShortName = "CP";
            public const string DocumentTypeName = "Cash Payment";
            public const int DocumentCategoryId = DocumentCategoryConstants.PaymentVoucher.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.PaymentVoucher.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class CashReceipt
        {
            public const int DocumentTypeId = 504;
            public const string DocumentTypeShortName = "CR";
            public const string DocumentTypeName = "Cash Receipt";
            public const int DocumentCategoryId = DocumentCategoryConstants.ReceiptVoucher.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.ReceiptVoucher.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class BankReceipt
        {
            public const int DocumentTypeId = 505;
            public const string DocumentTypeShortName = "BR";
            public const string DocumentTypeName = "Bank Receipt";
            public const int DocumentCategoryId = DocumentCategoryConstants.ReceiptVoucher.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.ReceiptVoucher.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class JournalVoucher
        {
            public const int DocumentTypeId = 506;
            public const string DocumentTypeShortName = "JV";
            public const string DocumentTypeName = "Journal Voucher";
            public const int DocumentCategoryId = DocumentCategoryConstants.JournalVoucher.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JournalVoucher.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class DebitNoteSupplier
        {
            public const int DocumentTypeId = 507;
            public const string DocumentTypeShortName = "DNS";
            public const string DocumentTypeName = "Debit Note (Supplier)";
            public const int DocumentCategoryId = DocumentCategoryConstants.DebitNote.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.DebitNote.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class DebitNoteCustomer
        {
            public const int DocumentTypeId = 508;
            public const string DocumentTypeShortName = "DNC";
            public const string DocumentTypeName = "Debit Note (Customer)";
            public const int DocumentCategoryId = DocumentCategoryConstants.DebitNote.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.DebitNote.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class CreditNoteSupplier
        {
            public const int DocumentTypeId = 509;
            public const string DocumentTypeShortName = "CNS";
            public const string DocumentTypeName = "Credit Note (Supplier)";
            public const int DocumentCategoryId = DocumentCategoryConstants.CreditNote.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.CreditNote.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class CreditNoteCustomer
        {
            public const int DocumentTypeId = 510;
            public const string DocumentTypeShortName = "CNC";
            public const string DocumentTypeName = "Credit Note (Customer)";
            public const int DocumentCategoryId = DocumentCategoryConstants.CreditNote.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.CreditNote.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ChequeCancel
        {
            public const int DocumentTypeId = 511;
            public const string DocumentTypeShortName = "CC";
            public const string DocumentTypeName = "Cheque Cancel";
            public const int DocumentCategoryId = DocumentCategoryConstants.ChequeCancel.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.ChequeCancel.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class ExpenseVoucher
        {
            public const int DocumentTypeId = 512;
            public const string DocumentTypeShortName = "JVT";
            public const string DocumentTypeName = "Journal Voucher (Taxable)";
            public const int DocumentCategoryId = DocumentCategoryConstants.ExpenseVoucher.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.ExpenseVoucher.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class PaymentRequest
        {
            public const int DocumentTypeId = 513;
            public const string DocumentTypeShortName = "PRQ";
            public const string DocumentTypeName = "Payment Request";
            public const int DocumentCategoryId = DocumentCategoryConstants.PaymentRequest.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.PaymentRequest.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class LeaveRequest
        {
            public const int DocumentTypeId = 514;
            public const string DocumentTypeShortName = "LR";
            public const string DocumentTypeName = "Leave Request";
            public const int DocumentCategoryId = DocumentCategoryConstants.LeaveRequest.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.LeaveRequest.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class PaymentAdvise
        {
            public const int DocumentTypeId = 515;
            public const string DocumentTypeShortName = "PA";
            public const string DocumentTypeName = "Payment Advise";
            public const int DocumentCategoryId = DocumentCategoryConstants.PaymentAdvise.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.PaymentAdvise.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class Salary
        {
            public const int DocumentTypeId = 516;
            public const string DocumentTypeShortName = "WAG";
            public const string DocumentTypeName = "Salary";
            public const int DocumentCategoryId = DocumentCategoryConstants.Salary.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Salary.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        #endregion
        #region "Masters"
        public static class Customer
        {
            public const int DocumentTypeId = 701;
            public const string DocumentTypeShortName = "CUST";
            public const string DocumentTypeName = "Customer";
            public const int DocumentCategoryId = DocumentCategoryConstants.Person.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Person.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class Supplier
        {
            public const int DocumentTypeId = 702;
            public const string DocumentTypeShortName = "SUPP";
            public const string DocumentTypeName = "Supplier";
            public const int DocumentCategoryId = DocumentCategoryConstants.Person.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Person.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class Employee
        {
            public const int DocumentTypeId = 703;
            public const string DocumentTypeShortName = "EMP";
            public const string DocumentTypeName = "Employee";
            public const int DocumentCategoryId = DocumentCategoryConstants.Person.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Person.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class Transporter
        {
            public const int DocumentTypeId = 704;
            public const string DocumentTypeShortName = "TRANS";
            public const string DocumentTypeName = "Transporter";
            public const int DocumentCategoryId = DocumentCategoryConstants.Person.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Person.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class JobWorker
        {
            public const int DocumentTypeId = 705;
            public const string DocumentTypeShortName = "JW";
            public const string DocumentTypeName = "Job Worker";
            public const int DocumentCategoryId = DocumentCategoryConstants.Person.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Person.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Machine
        {
            public const int DocumentTypeId = 706;
            public const string DocumentTypeShortName = "Machi";
            public const string DocumentTypeName = "Machine";
            public const int DocumentCategoryId = DocumentCategoryConstants.ProductType.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.ProductType.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ProductCategory
        {
            public const int DocumentTypeId = 707;
            public const string DocumentTypeShortName = "PC";
            public const string DocumentTypeName = "Product Category";
            public const int DocumentCategoryId = DocumentCategoryConstants.ProductCategory.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.ProductType.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ProductGroup
        {
            public const int DocumentTypeId = 708;
            public const string DocumentTypeShortName = "PG";
            public const string DocumentTypeName = "Product Group";
            public const int DocumentCategoryId = DocumentCategoryConstants.ProductGroup.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.ProductType.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class Product
        {
            public const int DocumentTypeId = 709;
            public const string DocumentTypeShortName = "P";
            public const string DocumentTypeName = "Product";
            public const int DocumentCategoryId = DocumentCategoryConstants.Product.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.ProductType.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        #endregion


        //public static class ProductUid
        //{
        //    public const int DocumentTypeId = 710;
        //    public const string DocumentTypeShortName = "PUID ";
        //    public const string DocumentTypeName = "Product Uid";
        //    public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
        //    public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
        //    public const string Nature = null;
        //    public const string PrintTitle = null;
        //}

        //public static class ProcessSequence
        //{
        //    public const int DocumentTypeId = 711;
        //    public const string DocumentTypeShortName = "PRSQ";
        //    public const string DocumentTypeName = "Process Sequence";
        //    public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
        //    public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
        //    public const string Nature = null;
        //    public const string PrintTitle = null;
        //}

        //public static class City
        //{
        //    public const int DocumentTypeId = 712;
        //    public const string DocumentTypeShortName = "City";
        //    public const string DocumentTypeName = "City";
        //    public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
        //    public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
        //    public const string Nature = null;
        //    public const string PrintTitle = null;
        //}

        //public static class ProcessSequence
        //{
        //    public const int DocumentTypeId = 713;
        //    public const string DocumentTypeShortName = "PRSQ";
        //    public const string DocumentTypeName = "Process Sequence";
        //    public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
        //    public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
        //    public const string Nature = null;
        //    public const string PrintTitle = null;
        //}

        //public static class ProcessSequence
        //{
        //    public const int DocumentTypeId = 714;
        //    public const string DocumentTypeShortName = "PRSQ";
        //    public const string DocumentTypeName = "Process Sequence";
        //    public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
        //    public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
        //    public const string Nature = null;
        //    public const string PrintTitle = null;
        //}

        //public static class ProcessSequence
        //{
        //    public const int DocumentTypeId = 715;
        //    public const string DocumentTypeShortName = "PRSQ";
        //    public const string DocumentTypeName = "Process Sequence";
        //    public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
        //    public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
        //    public const string Nature = null;
        //    public const string PrintTitle = null;
        //}

        //public static class ProcessSequence
        //{
        //    public const int DocumentTypeId = 716;
        //    public const string DocumentTypeShortName = "PRSQ";
        //    public const string DocumentTypeName = "Process Sequence";
        //    public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
        //    public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
        //    public const string Nature = null;
        //    public const string PrintTitle = null;
        //}

        //public static class ProcessSequence
        //{
        //    public const int DocumentTypeId = 717;
        //    public const string DocumentTypeShortName = "PRSQ";
        //    public const string DocumentTypeName = "Process Sequence";
        //    public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
        //    public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
        //    public const string Nature = null;
        //    public const string PrintTitle = null;
        //}

        //public static class ProcessSequence
        //{
        //    public const int DocumentTypeId = 718;
        //    public const string DocumentTypeShortName = "PRSQ";
        //    public const string DocumentTypeName = "Process Sequence";
        //    public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
        //    public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
        //    public const string Nature = null;
        //    public const string PrintTitle = null;
        //}

        //public static class ProcessSequence
        //{
        //    public const int DocumentTypeId = 719;
        //    public const string DocumentTypeShortName = "PRSQ";
        //    public const string DocumentTypeName = "Process Sequence";
        //    public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
        //    public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
        //    public const string Nature = null;
        //    public const string PrintTitle = null;
        //}


        /*
        public const string City = "City";
        public const string Process = "Process";
        public const string Godown = "Godown";
        public const string Gate = "Gate";
        public const string LeaveType = "Leave Type";
        public const string SalesTaxProductCode = "Sales Tax Product Code";


        public const string Task = "Task";
        public const string DAR = "DAR";
        public const string UserTeam = "UserTeam";
        public const string Project = "Project";
        public const string Other = "Other";
        public const string Prospect = "Prospect";



        public const string Style = "Style";

        public const string Shape = "Shape";

        public const string DesignPattern = "Design Pattern";
        public const string Content = "Content";
        public const string Construction = "Construction";
        public const string ColourWays = "Colour Ways";
        public const string Colour = "Colour";
        public const string Collection = "Collection";
        public const string CarpetSample = "Carpet Sample";
        public const string Carpet = "Carpet";
        public const string Unit = "Unit";
        public const string TdsGroup = "Tds Group";
        public const string TdsCategory = "Tds Category";
        public const string State = "State";
        public const string Site = "Site";
        public const string ShipMethod = "Ship Method";
        public const string ServiceTaxCategory = "Service Tax Category";
        public const string SalesTaxGroupProduct = "Sales Tax Group Product";
        public const string SalesTaxGroupParty = "Sales Tax Group Party";
        public const string Route = "Route";
        public const string ProductTypeAttribute = "Product Type Attribute";
        public const string ProductType = "Product Type";
        public const string ProductNature = "Product Nature";
        public const string ProductInvoiceGroup = "Product Invoice Group";
        public const string ProductCustomGroup = "Product Custom Group";
        public const string PersonRateGroup = "Person Rate Group";
        public const string ProductRateGroup = "Product Rate Group";
        public const string RateListHeader = "Rate List Header";
        public const string Manufacturer = "Manufacturer";
        public const string LedgerAccountGroup = "Ledger Account Group";
        public const string LedgerAccount = "Ledger Account";
        public const string DrawBackTariff = "Draw Back Tariff";
        public const string DocumentType = "Document Type";
        public const string DocumentCategory = "Document Category";
        public const string Division = "Division";
        public const string Designation = "Designation";
        public const string DesignConsumption = "Design Consumption";
        public const string DesignColourConsumption = "Design Colour Consumption";
        public const string DescriptionOfGoods = "Description Of Goods";
        public const string Department = "Department";
        public const string DeliveryTerms = "DeliveryTerms";
        public const string Currency = "Currency";
        public const string Courier = "Courier";
        public const string CostCenter = "Cost Center";
        public const string Agent = "Agent";
        public const string Financier = "Financier";
        public const string SalesExecutive = "Sales Executive";
        public const string FeetConversionToCms = "FeetConversionToCms";

        public const string Dimension1 = "Dimension1";
        public const string Dimension2 = "Dimension2";
        public const string Dimension3 = "Dimension3";
        public const string Dimension4 = "Dimension4";
        public const string Country = "Country";
        public const string CustomDetail = "Custom Detail";
        public const string FinishedProduct = "Finished Product";
        public const string Narration = "Narration";

        public const string PromoCode = "Promo Code";

        public const string PersonContactType = "Person Contact Type";
        public const string Reason = "Reason";
        public const string RugStencil = "RugStencil";
        public const string GatePass = "Gate Pass";
        public const string UnitConversion = "Unit Conversion";
        public const string ChargeGroupPerson = "Charge Group Person";

        //ForLogActivity Master Constants
        public const string Calculation = "Calculation";
        public const string CalculationLedgerAccount = "Calculation Ledger Account";
        public const string Charge = "Charge";
        public const string ChargeGroupProduct = "Charge Group Product";
        public const string ChargeGroupSettings = "Charge Group Settings";
        public const string QAGroup = "QA Group";
        public const string ChargeType = "Charge Type";
        public const string ProductConsumption = "Product Consumption";
        public const string ProductBuyer = "Product Buyer";
        public const string ProductCollection = "Product Collection";
        public const string ProductConstruction = "Product Construction";
        public const string ProductContent = "Product Content";
        public const string ProductAlias = "Product Alias";
        public const string ProductDesign = "Product Design";
        public const string ProductDesignPattern = "Product Design Pattern";
        public const string ProductManufacturingStyle = "Product Manufacturing Style";
        public const string ProductQuality = "Product Quality";
        public const string ProductShape = "Product Shape";
        public const string ProductSize = "Product Size";
        public const string ProductSizeType = "Product Size Type";
        public const string ProductStyle = "Product Style";
        public const string PersonAddress = "Person Address";
        public const string PersonBankAccount = "Person Bank Account";
        public const string PersonContact = "Person Contact";
        public const string PersonDocument = "Person Document";
        public const string RateList = "Rate List";
        public const string UserRoles = "User Roles";
        public const string DocumentTypeTimeExtension = "DocumentType Time Extension";
        public const string DocumentTypeTimePlan = "DocumentType Time Plan";

        public const string User = "User";
        */

    }
}