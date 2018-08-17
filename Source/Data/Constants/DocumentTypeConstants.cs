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
            public const int DocumentTypeId = 19;
            public const string DocumentTypeShortName = "PP";
            public const string DocumentTypeName = "Purchase Plan";
            public const int DocumentCategoryId = DocumentCategoryConstants.PurchasePlan.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.ProductionOrder.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class PurchasePlanCancel
        {
            public const int DocumentTypeId = 20;
            public const string DocumentTypeShortName = "PPC";
            public const string DocumentTypeName = "Purchase Plan Cancel";
            public const int DocumentCategoryId = DocumentCategoryConstants.PurchasePlanCancel.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.ProductionOrderCancel.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class PurchaseEnquiry
        {
            public const int DocumentTypeId = 21;
            public const string DocumentTypeShortName = "PE";
            public const string DocumentTypeName = "Purchase Enquiry";
            public const int DocumentCategoryId = DocumentCategoryConstants.PurchaseEnquiry.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobEnquiry.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class PurchaseEnquiryCancel
        {
            public const int DocumentTypeId = 22;
            public const string DocumentTypeShortName = "PEC";
            public const string DocumentTypeName = "Purchase Enquiry Cancel";
            public const int DocumentCategoryId = DocumentCategoryConstants.PurchaseEnquiryCancel.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobEnquiryCancel.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class PurchaseQuotation
        {
            public const int DocumentTypeId = 23;
            public const string DocumentTypeShortName = "PQ";
            public const string DocumentTypeName = "Purchase Quotation";
            public const int DocumentCategoryId = DocumentCategoryConstants.PurchaseQuotation.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobQuotation.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class PurchaseQuotationCancel
        {
            public const int DocumentTypeId = 24;
            public const string DocumentTypeShortName = "PQC";
            public const string DocumentTypeName = "Purchase Quotation Cancel";
            public const int DocumentCategoryId = DocumentCategoryConstants.PurchaseQuotationCancel.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobQuotationCancel.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class PurchaseOrder
        {
            public const int DocumentTypeId = 25;
            public const string DocumentTypeShortName = "PO";
            public const string DocumentTypeName = "Purchase Order";
            public const int DocumentCategoryId = DocumentCategoryConstants.PurchaseOrder.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobOrder.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class PurchaseOrderCancel
        {
            public const int DocumentTypeId = 26;
            public const string DocumentTypeShortName = "POC";
            public const string DocumentTypeName = "Purchase Order Cancel";
            public const int DocumentCategoryId = DocumentCategoryConstants.PurchaseOrderCancel.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobOrderCancel.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class PurchaseOrderAmendment
        {
            public const int DocumentTypeId = 27;
            public const string DocumentTypeShortName = "POA";
            public const string DocumentTypeName = "Purchase Order Amendment";
            public const int DocumentCategoryId = DocumentCategoryConstants.PurchaseOrderAmendment.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobOrderAmendment.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class SupplierAuditRequest
        {
            public const int DocumentTypeId = 28;
            public const string DocumentTypeShortName = "SAR";
            public const string DocumentTypeName = "Supplier Audit Request";
            public const int DocumentCategoryId = DocumentCategoryConstants.SupplierAuditRequest.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobInspectionRequest.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class SupplierAudit
        {
            public const int DocumentTypeId = 29;
            public const string DocumentTypeShortName = "SA";
            public const string DocumentTypeName = "Supplier Audit";
            public const int DocumentCategoryId = DocumentCategoryConstants.SupplierAudit.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobInspection.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class GoodsReceipt
        {
            public const int DocumentTypeId = 30;
            public const string DocumentTypeShortName = "GR";
            public const string DocumentTypeName = "Goods Receipt";
            public const int DocumentCategoryId = DocumentCategoryConstants.GoodsReceipt.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobReceive.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class QualityCheckingInword
        {
            public const int DocumentTypeId = 31;
            public const string DocumentTypeShortName = "QCI";
            public const string DocumentTypeName = "Quality Checking (Inword)";
            public const int DocumentCategoryId = DocumentCategoryConstants.QualityCheckingInword.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobReceiveQC.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class GoodsReturnOutword
        {
            public const int DocumentTypeId = 32;
            public const string DocumentTypeShortName = "GRO";
            public const string DocumentTypeName = "Goods Return (Outword)";
            public const int DocumentCategoryId = DocumentCategoryConstants.GoodsReturnOutword.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobReturn.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class PurchaseInvoice
        {
            public const int DocumentTypeId = 33;
            public const string DocumentTypeShortName = "PI";
            public const string DocumentTypeName = "Purchase Invoice";
            public const int DocumentCategoryId = DocumentCategoryConstants.PurchaseInvoice.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobInvoice.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class PurchaseReturn
        {
            public const int DocumentTypeId = 34;
            public const string DocumentTypeShortName = "PR";
            public const string DocumentTypeName = "Purchase Return";
            public const int DocumentCategoryId = DocumentCategoryConstants.PurchaseReturn.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobInvoiceReturn.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class WayBillInword
        {
            public const int DocumentTypeId = 35;
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
            public const int DocumentTypeId = 36;
            public const string DocumentTypeShortName = "MP";
            public const string DocumentTypeName = "Manufacturing Plan";
            public const int DocumentCategoryId = DocumentCategoryConstants.ManufacturingPlan.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.ProductionOrder.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class ManufacturingPlanCancel
        {
            public const int DocumentTypeId = 37;
            public const string DocumentTypeShortName = "MPC";
            public const string DocumentTypeName = "Manufacturing Plan Cancel";
            public const int DocumentCategoryId = DocumentCategoryConstants.ManufacturingPlanCancel.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobQuotation.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class JobEnquiry
        {
            public const int DocumentTypeId = 38;
            public const string DocumentTypeShortName = "JE";
            public const string DocumentTypeName = "Job Enquiry";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobEnquiry.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobEnquiry.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class JobEnquiryCancel
        {
            public const int DocumentTypeId = 39;
            public const string DocumentTypeShortName = "JEC";
            public const string DocumentTypeName = "Job Enquiry Cancel";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobEnquiryCancel.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobEnquiryCancel.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class JobQuotation
        {
            public const int DocumentTypeId = 40;
            public const string DocumentTypeShortName = "JQ";
            public const string DocumentTypeName = "Job Quotation";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobQuotation.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobQuotation.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class JobQuotationCancel
        {
            public const int DocumentTypeId = 41;
            public const string DocumentTypeShortName = "JQC";
            public const string DocumentTypeName = "Job Quotation Cancel";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobQuotationCancel.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobQuotation.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class JobOrder
        {
            public const int DocumentTypeId = 42;
            public const string DocumentTypeShortName = "JO";
            public const string DocumentTypeName = "Job Order";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobOrder.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobOrder.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class JobOrderCancel
        {
            public const int DocumentTypeId = 43;
            public const string DocumentTypeShortName = "JOC";
            public const string DocumentTypeName = "Job Order Cancel";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobOrderCancel.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobOrderCancel.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class JobOrderAmendment
        {
            public const int DocumentTypeId = 44;
            public const string DocumentTypeShortName = "JOA";
            public const string DocumentTypeName = "Job Order Amendment";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobOrderAmendment.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobOrderAmendment.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class JobReceive
        {
            public const int DocumentTypeId = 45;
            public const string DocumentTypeShortName = "JR";
            public const string DocumentTypeName = "Job Receive";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobReceive.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobReceive.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }


        public static class JobInvoice
        {
            public const int DocumentTypeId = 46;
            public const string DocumentTypeShortName = "JI";
            public const string DocumentTypeName = "Job Invoice";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobInvoice.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobInvoice.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }


        public static class JobReturn
        {
            public const int DocumentTypeId = 47;
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
            public const int DocumentTypeId = 48;
            public const string DocumentTypeShortName = "OS";
            public const string DocumentTypeName = "Stock Opening";
            public const int DocumentCategoryId = DocumentCategoryConstants.MaterialReceive.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.StockReceive.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class MaterialRequest
        {
            public const int DocumentTypeId = 49;
            public const string DocumentTypeShortName = "MRQ";
            public const string DocumentTypeName = "Material Request";
            public const int DocumentCategoryId = DocumentCategoryConstants.MaterialRequest.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.StockRequisition.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class MaterialRequestCancel
        {
            public const int DocumentTypeId = 50;
            public const string DocumentTypeShortName = "SRC";
            public const string DocumentTypeName = "Material Request Cancel";
            public const int DocumentCategoryId = DocumentCategoryConstants.MaterialRequestCancel.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.StockRequisitionCancel.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class MaterialIssue
        {
            public const int DocumentTypeId = 51;
            public const string DocumentTypeShortName = "MI";
            public const string DocumentTypeName = "Material Issue";
            public const int DocumentCategoryId = DocumentCategoryConstants.MaterialIssue.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.StockIssue.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class MaterialReceive
        {
            public const int DocumentTypeId = 52;
            public const string DocumentTypeShortName = "MR";
            public const string DocumentTypeName = "Material Receive";
            public const int DocumentCategoryId = DocumentCategoryConstants.MaterialReceive.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.StockReceive.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class MaterialTransfer
        {
            public const int DocumentTypeId = 53;
            public const string DocumentTypeShortName = "MT";
            public const string DocumentTypeName = "Material Transfer";
            public const int DocumentCategoryId = DocumentCategoryConstants.MaterialTransfer.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.StockTransfer.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        #endregion
        #region "Planning"
        public static class SaleOrderPlan
        {
            public const int DocumentTypeId = 600;
            public const string DocumentTypeShortName = "SOPLN";
            public const string DocumentTypeName = "Sales Order Plan";
            public const int DocumentCategoryId = DocumentCategoryConstants.Planning.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Planning.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        #endregion
        #region "Accounts"
        public static class LedgerOpening
        {
            public const int DocumentTypeId = 54;
            public const string DocumentTypeShortName = "LO";
            public const string DocumentTypeName = "Ledger Opening";
            public const int DocumentCategoryId = DocumentCategoryConstants.PaymentVoucher.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.PaymentVoucher.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class BankPayment
        {
            public const int DocumentTypeId = 55;
            public const string DocumentTypeShortName = "BP";
            public const string DocumentTypeName = "Bank Payment";
            public const int DocumentCategoryId = DocumentCategoryConstants.PaymentVoucher.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.PaymentVoucher.DocumentNatureId;
            public const string Nature = "Cr";
            public const string PrintTitle = null;
        }

        public static class CashPayment
        {
            public const int DocumentTypeId = 56;
            public const string DocumentTypeShortName = "CP";
            public const string DocumentTypeName = "Cash Payment";
            public const int DocumentCategoryId = DocumentCategoryConstants.PaymentVoucher.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.PaymentVoucher.DocumentNatureId;
            public const string Nature = "Cr";
            public const string PrintTitle = null;
        }
        public static class CashReceipt
        {
            public const int DocumentTypeId = 57;
            public const string DocumentTypeShortName = "CR";
            public const string DocumentTypeName = "Cash Receipt";
            public const int DocumentCategoryId = DocumentCategoryConstants.ReceiptVoucher.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.ReceiptVoucher.DocumentNatureId;
            public const string Nature = "Dr";
            public const string PrintTitle = null;
        }

        public static class BankReceipt
        {
            public const int DocumentTypeId = 58;
            public const string DocumentTypeShortName = "BR";
            public const string DocumentTypeName = "Bank Receipt";
            public const int DocumentCategoryId = DocumentCategoryConstants.ReceiptVoucher.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.ReceiptVoucher.DocumentNatureId;
            public const string Nature = "Dr";
            public const string PrintTitle = null;
        }
        public static class JournalVoucher
        {
            public const int DocumentTypeId = 59;
            public const string DocumentTypeShortName = "JV";
            public const string DocumentTypeName = "Journal Voucher";
            public const int DocumentCategoryId = DocumentCategoryConstants.JournalVoucher.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JournalVoucher.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class DebitNoteSupplier
        {
            public const int DocumentTypeId = 60;
            public const string DocumentTypeShortName = "DNS";
            public const string DocumentTypeName = "Debit Note (Supplier)";
            public const int DocumentCategoryId = DocumentCategoryConstants.DebitNote.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.DebitNote.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class DebitNoteCustomer
        {
            public const int DocumentTypeId = 61;
            public const string DocumentTypeShortName = "DNC";
            public const string DocumentTypeName = "Debit Note (Customer)";
            public const int DocumentCategoryId = DocumentCategoryConstants.DebitNote.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.DebitNote.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class CreditNoteSupplier
        {
            public const int DocumentTypeId = 62;
            public const string DocumentTypeShortName = "CNS";
            public const string DocumentTypeName = "Credit Note (Supplier)";
            public const int DocumentCategoryId = DocumentCategoryConstants.CreditNote.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.CreditNote.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class CreditNoteCustomer
        {
            public const int DocumentTypeId = 63;
            public const string DocumentTypeShortName = "CNC";
            public const string DocumentTypeName = "Credit Note (Customer)";
            public const int DocumentCategoryId = DocumentCategoryConstants.CreditNote.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.CreditNote.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ChequeCancel
        {
            public const int DocumentTypeId = 64;
            public const string DocumentTypeShortName = "CC";
            public const string DocumentTypeName = "Cheque Cancel";
            public const int DocumentCategoryId = DocumentCategoryConstants.ChequeCancel.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.ChequeCancel.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class ExpenseVoucher
        {
            public const int DocumentTypeId = 65;
            public const string DocumentTypeShortName = "JVT";
            public const string DocumentTypeName = "Journal Voucher (Taxable)";
            public const int DocumentCategoryId = DocumentCategoryConstants.ExpenseVoucher.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.ExpenseVoucher.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class PaymentRequest
        {
            public const int DocumentTypeId = 66;
            public const string DocumentTypeShortName = "PRQ";
            public const string DocumentTypeName = "Payment Request";
            public const int DocumentCategoryId = DocumentCategoryConstants.PaymentRequest.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.PaymentRequest.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class LeaveRequest
        {
            public const int DocumentTypeId = 67;
            public const string DocumentTypeShortName = "LR";
            public const string DocumentTypeName = "Leave Request";
            public const int DocumentCategoryId = DocumentCategoryConstants.LeaveRequest.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.LeaveRequest.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class PaymentAdvise
        {
            public const int DocumentTypeId = 68;
            public const string DocumentTypeShortName = "PA";
            public const string DocumentTypeName = "Payment Advise";
            public const int DocumentCategoryId = DocumentCategoryConstants.PaymentAdvise.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.PaymentAdvise.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class Salary
        {
            public const int DocumentTypeId = 69;
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
            public const int DocumentTypeId = 70;
            public const string DocumentTypeShortName = "CUST";
            public const string DocumentTypeName = "Customer";
            public const int DocumentCategoryId = DocumentCategoryConstants.Person.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Person.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        //public static class Buyer
        //{
        //    public const int DocumentTypeId = 71;
        //    public const string DocumentTypeShortName = "Buyer";
        //    public const string DocumentTypeName = "Buyer";
        //    public const int DocumentCategoryId = DocumentCategoryConstants.Person.DocumentCategoryId;
        //    public const int DocumentNatureId = DocumentNatureConstants.Person.DocumentNatureId;
        //    public const string Nature = null;
        //    public const string PrintTitle = null;
        //}


        public static class Agent
        {
            public const int DocumentTypeId = 72;
            public const string DocumentTypeShortName = "Agent";
            public const string DocumentTypeName = "Agent";
            public const int DocumentCategoryId = DocumentCategoryConstants.Person.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Person.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Financier
        {
            public const int DocumentTypeId = 73;
            public const string DocumentTypeShortName = "FNCR";
            public const string DocumentTypeName = "Financier";
            public const int DocumentCategoryId = DocumentCategoryConstants.Person.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Person.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class SalesExecutive
        {
            public const int DocumentTypeId = 74;
            public const string DocumentTypeShortName = "SEXE";
            public const string DocumentTypeName = "Sales Executive";
            public const int DocumentCategoryId = DocumentCategoryConstants.Person.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Person.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Supplier
        {
            public const int DocumentTypeId = 75;
            public const string DocumentTypeShortName = "SUPP";
            public const string DocumentTypeName = "Supplier";
            public const int DocumentCategoryId = DocumentCategoryConstants.Person.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Person.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class Employee
        {
            public const int DocumentTypeId = 76;
            public const string DocumentTypeShortName = "EMP";
            public const string DocumentTypeName = "Employee";
            public const int DocumentCategoryId = DocumentCategoryConstants.Person.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Person.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class Transporter
        {
            public const int DocumentTypeId = 77;
            public const string DocumentTypeShortName = "TRANS";
            public const string DocumentTypeName = "Transporter";
            public const int DocumentCategoryId = DocumentCategoryConstants.Person.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Person.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class JobWorker
        {
            public const int DocumentTypeId = 78;
            public const string DocumentTypeShortName = "JW";
            public const string DocumentTypeName = "Job Worker";
            public const int DocumentCategoryId = DocumentCategoryConstants.Person.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Person.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Machine
        {
            public const int DocumentTypeId = 79;
            public const string DocumentTypeShortName = "Machi";
            public const string DocumentTypeName = "Machine";
            public const int DocumentCategoryId = DocumentCategoryConstants.ProductType.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.ProductType.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ProductCategory
        {
            public const int DocumentTypeId = 80;
            public const string DocumentTypeShortName = "PC";
            public const string DocumentTypeName = "Product Category";
            public const int DocumentCategoryId = DocumentCategoryConstants.ProductCategory.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.ProductType.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ProductGroup
        {
            public const int DocumentTypeId = 81;
            public const string DocumentTypeShortName = "PG";
            public const string DocumentTypeName = "Product Group";
            public const int DocumentCategoryId = DocumentCategoryConstants.ProductGroup.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.ProductType.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class Product
        {
            public const int DocumentTypeId = 82;
            public const string DocumentTypeShortName = "P";
            public const string DocumentTypeName = "Product";
            public const int DocumentCategoryId = DocumentCategoryConstants.Product.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.ProductType.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        #endregion

        
        public static class MaterialPlan
        {
            public const int DocumentTypeId = 83;
            public const string DocumentTypeShortName = "MPP";
            public const string DocumentTypeName = "Material Plan";
            public const int DocumentCategoryId = DocumentCategoryConstants.Planning.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Planning.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ProductQuality
        {
            public const int DocumentTypeId = 84;
            public const string DocumentTypeShortName = "PRQU";
            public const string DocumentTypeName = "Product Quality";
            public const int DocumentCategoryId = DocumentCategoryConstants.ProductQuality.DocumentCategoryId;
            public const int DocumentNatureId = RugDocumentNatureConstants.Carpet.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class OtherSize
        {
            public const int DocumentTypeId = 85;
            public const string DocumentTypeShortName = "OSZ";
            public const string DocumentTypeName = "Other Size";
            public const int DocumentCategoryId = DocumentCategoryConstants.Size.DocumentCategoryId;
            public const int DocumentNatureId = RugDocumentNatureConstants.Carpet.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class StandardSize
        {
            public const int DocumentTypeId = 86;
            public const string DocumentTypeShortName = "SSZ";
            public const string DocumentTypeName = "Standard Size";
            public const int DocumentCategoryId = DocumentCategoryConstants.Size.DocumentCategoryId;
            public const int DocumentNatureId = RugDocumentNatureConstants.Carpet.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        //public static class ProductCollection
        //{
        //    public const int DocumentTypeId = 87;
        //    public const string DocumentTypeShortName = "PRCL";
        //    public const string DocumentTypeName = "Product Collection";
        //    public const int DocumentCategoryId = DocumentCategoryConstants.ProductCollection.DocumentCategoryId;
        //    public const int DocumentNatureId = RugDocumentNatureConstants.Carpet.DocumentNatureId;
        //    public const string Nature = null;
        //    public const string PrintTitle = null;
        //}

        public static class ProductContent
        {
            public const int DocumentTypeId = 88;
            public const string DocumentTypeShortName = "PCOT";
            public const string DocumentTypeName = "Product Content";
            public const int DocumentCategoryId = DocumentCategoryConstants.ProductContent.DocumentCategoryId;
            public const int DocumentNatureId = RugDocumentNatureConstants.Carpet.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ProcessSequence
        {
            public const int DocumentTypeId = 89;
            public const string DocumentTypeShortName = "PRSQ";
            public const string DocumentTypeName = "Process Sequence";
            public const int DocumentCategoryId = DocumentCategoryConstants.ProcessSequence.DocumentCategoryId;
            public const int DocumentNatureId = RugDocumentNatureConstants.Carpet.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Quality
        {
            public const int DocumentTypeId = 90;
            public const string DocumentTypeShortName = "QLTY";
            public const string DocumentTypeName = "Quality";
            public const int DocumentCategoryId = DocumentCategoryConstants.Quality.DocumentCategoryId;
            public const int DocumentNatureId = RugDocumentNatureConstants.Carpet.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Design
        {
            public const int DocumentTypeId = 91;
            public const string DocumentTypeShortName = "Desig";
            public const string DocumentTypeName = "Design";
            public const int DocumentCategoryId = RugDocumentCategoryConstants.Carpet.DocumentCategoryId;
            public const int DocumentNatureId = RugDocumentNatureConstants.Carpet.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Size
        {
            public const int DocumentTypeId = 92;
            public const string DocumentTypeShortName = "Size";
            public const string DocumentTypeName = "Size";
            public const int DocumentCategoryId = DocumentCategoryConstants.ProductSize.DocumentCategoryId;
            public const int DocumentNatureId = RugDocumentNatureConstants.Carpet.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Content
        {
            public const int DocumentTypeId = 93;
            public const string DocumentTypeShortName = "CONT";
            public const string DocumentTypeName = "Content";
            public const int DocumentCategoryId = DocumentCategoryConstants.Content.DocumentCategoryId;
            public const int DocumentNatureId = RugDocumentNatureConstants.Carpet.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Construction
        {
            public const int DocumentTypeId = 94;
            public const string DocumentTypeShortName = "CONST";
            public const string DocumentTypeName = "Construction";
            public const int DocumentCategoryId = DocumentCategoryConstants.Construction.DocumentCategoryId;
            public const int DocumentNatureId = RugDocumentNatureConstants.Carpet.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ColourWays
        {
            public const int DocumentTypeId = 95;
            public const string DocumentTypeShortName = "COLWY";
            public const string DocumentTypeName = "Colour Ways";
            public const int DocumentCategoryId = DocumentCategoryConstants.ColourWays.DocumentCategoryId;
            public const int DocumentNatureId = RugDocumentNatureConstants.Carpet.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Colour
        {
            public const int DocumentTypeId = 96;
            public const string DocumentTypeShortName = "COL";
            public const string DocumentTypeName = "Colour";
            public const int DocumentCategoryId = DocumentCategoryConstants.Colour.DocumentCategoryId;
            public const int DocumentNatureId = RugDocumentNatureConstants.Carpet.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }


        public static class Collection
        {
            public const int DocumentTypeId = 97;
            public const string DocumentTypeShortName = "COLL";
            public const string DocumentTypeName = "Collection";
            public const int DocumentCategoryId = DocumentCategoryConstants.Collection.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }



        public static class Dimension1
        {
            public const int DocumentTypeId = 98;
            public const string DocumentTypeShortName = "D1";
            public const string DocumentTypeName = "Dimension1";
            public const int DocumentCategoryId = DocumentCategoryConstants.Dimension1.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }


        public static class Dimension2
        {
            public const int DocumentTypeId = 99;
            public const string DocumentTypeShortName = "D2";
            public const string DocumentTypeName = "Dimension2";
            public const int DocumentCategoryId = DocumentCategoryConstants.Dimension2.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }


        public static class Dimension3
        {
            public const int DocumentTypeId = 100;
            public const string DocumentTypeShortName = "D3";
            public const string DocumentTypeName = "Dimension3";
            public const int DocumentCategoryId = DocumentCategoryConstants.Dimension3.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Dimension4
        {
            public const int DocumentTypeId = 101;
            public const string DocumentTypeShortName = "D4";
            public const string DocumentTypeName = "Dimension4";
            public const int DocumentCategoryId = DocumentCategoryConstants.Dimension4.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }



        public static class UserRoles
        {
            public const int DocumentTypeId = 102;
            public const string DocumentTypeShortName = "URole";
            public const string DocumentTypeName = "User Roles";
            public const int DocumentCategoryId = DocumentCategoryConstants.UserRoles.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class SchemeIncentive
        {
            public const int DocumentTypeId = 103;
            public const string DocumentTypeShortName = "SCINC";
            public const string DocumentTypeName = "Scheme Incentive";
            public const int DocumentCategoryId = DocumentCategoryConstants.UnUsedDocumentType.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class RateConversion
        {
            public const int DocumentTypeId = 104;
            public const string DocumentTypeShortName = "RCON";
            public const string DocumentTypeName = "Rate Conversion";
            public const int DocumentCategoryId = DocumentCategoryConstants.RateConversion.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class BinLocation
        {
            public const int DocumentTypeId = 105;
            public const string DocumentTypeShortName = "BINLO";
            public const string DocumentTypeName = "Bin Location";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Godown
        {
            public const int DocumentTypeId = 106;
            public const string DocumentTypeShortName = "Godwn";
            public const string DocumentTypeName = "Godown";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Religion
        {
            public const int DocumentTypeId = 107;
            public const string DocumentTypeShortName = "RLGN";
            public const string DocumentTypeName = "Religion";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }



        public static class DeliveryTerms
        {
            public const int DocumentTypeId = 108;
            public const string DocumentTypeShortName = "Deliv";
            public const string DocumentTypeName = "Delivery Terms";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class FinishedProduct
        {
            public const int DocumentTypeId = 109;
            public const string DocumentTypeShortName = "109";
            public const string DocumentTypeName = "Finished Product";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ProductBuyer
        {
            public const int DocumentTypeId = 110;
            public const string DocumentTypeShortName = "PB";
            public const string DocumentTypeName = "Product Buyer";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }


        public static class FeetConversionToCms
        {
            public const int DocumentTypeId = 111;
            public const string DocumentTypeShortName = "111";
            public const string DocumentTypeName = "Feet Conversion To Cms";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ProductConstruction
        {
            public const int DocumentTypeId = 112;
            public const string DocumentTypeShortName = "112";
            public const string DocumentTypeName = "Product Construction";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ProductConsumption
        {
            public const int DocumentTypeId = 113;
            public const string DocumentTypeShortName = "113";
            public const string DocumentTypeName = "Product Consumption";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ProductDesignPattern
        {
            public const int DocumentTypeId = 114;
            public const string DocumentTypeShortName = "114";
            public const string DocumentTypeName = "Product Design Pattern";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ProductInvoiceGroup
        {
            public const int DocumentTypeId = 115;
            public const string DocumentTypeShortName = "115";
            public const string DocumentTypeName = "Product Invoice Group";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ProductShape
        {
            public const int DocumentTypeId = 116;
            public const string DocumentTypeShortName = "116";
            public const string DocumentTypeName = "Product Shape";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ProductStyle
        {
            public const int DocumentTypeId = 117;
            public const string DocumentTypeShortName = "117";
            public const string DocumentTypeName = "Product Style";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class SalesTaxGroupParty
        {
            public const int DocumentTypeId = 118;
            public const string DocumentTypeShortName = "118";
            public const string DocumentTypeName = "Sales Tax Group Party";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Charge
        {
            public const int DocumentTypeId = 119;
            public const string DocumentTypeShortName = "CHARG";
            public const string DocumentTypeName = "Charge";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ChargeType
        {
            public const int DocumentTypeId = 120;
            public const string DocumentTypeShortName = "120";
            public const string DocumentTypeName = "Charge Type";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }



        public static class Calculation
        {
            public const int DocumentTypeId = 121;
            public const string DocumentTypeShortName = "121";
            public const string DocumentTypeName = "Calculation";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class City
        {
            public const int DocumentTypeId = 122;
            public const string DocumentTypeShortName = "City";
            public const string DocumentTypeName = "City";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }


        public static class Process
        {
            public const int DocumentTypeId = 123;
            public const string DocumentTypeShortName = "123";
            public const string DocumentTypeName = "Process";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Designation
        {
            public const int DocumentTypeId = 124;
            public const string DocumentTypeShortName = "124";
            public const string DocumentTypeName = "Designation";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }


        public static class GatePass
        {
            public const int DocumentTypeId = 125;
            public const string DocumentTypeShortName = "125";
            public const string DocumentTypeName = "Gate Pass";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }


        public static class PersonRateGroup
        {
            public const int DocumentTypeId = 126;
            public const string DocumentTypeShortName = "126";
            public const string DocumentTypeName = "Person Rate Group";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }


        public static class Site
        {
            public const int DocumentTypeId = 127;
            public const string DocumentTypeShortName = "Site";
            public const string DocumentTypeName = "Site";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }


        public static class DescriptionOfGoods
        {
            public const int DocumentTypeId = 128;
            public const string DocumentTypeShortName = "128";
            public const string DocumentTypeName = "Description Of Goods";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }


        public static class UnitConversion
        {
            public const int DocumentTypeId = 129;
            public const string DocumentTypeShortName = "UCON";
            public const string DocumentTypeName = "UnitConversion";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class RateListHeader
        {
            public const int DocumentTypeId = 130;
            public const string DocumentTypeShortName = "130";
            public const string DocumentTypeName = "Rate List Header";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ProductDesign
        {
            public const int DocumentTypeId = 131;
            public const string DocumentTypeShortName = "131";
            public const string DocumentTypeName = "Product Design";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class ProductManufacturingStyle
        {
            public const int DocumentTypeId = 132;
            public const string DocumentTypeShortName = "132";
            public const string DocumentTypeName = "Product Manufacturing Style";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class ProductNature
        {
            public const int DocumentTypeId = 133;
            public const string DocumentTypeShortName = "133";
            public const string DocumentTypeName = "Product Nature";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class ProductSizeType
        {
            public const int DocumentTypeId = 134;
            public const string DocumentTypeShortName = "134";
            public const string DocumentTypeName = "Product Size Type";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class Report
        {
            public const int DocumentTypeId = 135;
            public const string DocumentTypeShortName = "135";
            public const string DocumentTypeName = "Report";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class SalesTaxGroupProduct
        {
            public const int DocumentTypeId = 136;
            public const string DocumentTypeShortName = "136";
            public const string DocumentTypeName = "Sales Tax Group Product";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ShipMethod
        {
            public const int DocumentTypeId = 137;
            public const string DocumentTypeShortName = "137";
            public const string DocumentTypeName = "Ship Method";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ChargeGroupPerson
        {
            public const int DocumentTypeId = 138;
            public const string DocumentTypeShortName = "138";
            public const string DocumentTypeName = "ChargeGroupPerson";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ChargeGroupProduct
        {
            public const int DocumentTypeId = 139;
            public const string DocumentTypeShortName = "139";
            public const string DocumentTypeName = "ChargeGroupProduct";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class CostCenter
        {
            public const int DocumentTypeId = 140;
            public const string DocumentTypeShortName = "140";
            public const string DocumentTypeName = "CostCenter";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Courier
        {
            public const int DocumentTypeId = 141;
            public const string DocumentTypeShortName = "141";
            public const string DocumentTypeName = "Courier";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Currency
        {
            public const int DocumentTypeId = 142;
            public const string DocumentTypeShortName = "142";
            public const string DocumentTypeName = "Currency";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class CustomDetail
        {
            public const int DocumentTypeId = 143;
            public const string DocumentTypeShortName = "143";
            public const string DocumentTypeName = "Custom Detail";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Country
        {
            public const int DocumentTypeId = 144;
            public const string DocumentTypeShortName = "144";
            public const string DocumentTypeName = "Country";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Department
        {
            public const int DocumentTypeId = 145;
            public const string DocumentTypeShortName = "145";
            public const string DocumentTypeName = "Department";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Division
        {
            public const int DocumentTypeId = 146;
            public const string DocumentTypeShortName = "146";
            public const string DocumentTypeName = "DIV";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class DocumentCategory
        {
            public const int DocumentTypeId = 147;
            public const string DocumentTypeShortName = "147";
            public const string DocumentTypeName = "Document Category";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class DocumentType
        {
            public const int DocumentTypeId = 148;
            public const string DocumentTypeShortName = "DT";
            public const string DocumentTypeName = "Document Type";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class DrawBackTariff
        {
            public const int DocumentTypeId = 149;
            public const string DocumentTypeShortName = "149";
            public const string DocumentTypeName = "Draw Back Tariff";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Gate
        {
            public const int DocumentTypeId = 150;
            public const string DocumentTypeShortName = "Gate";
            public const string DocumentTypeName = "Gate";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }



        public static class LeaveType
        {
            public const int DocumentTypeId = 151;
            public const string DocumentTypeShortName = "151";
            public const string DocumentTypeName = "Leave Type";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class LedgerAccount
        {
            public const int DocumentTypeId = 152;
            public const string DocumentTypeShortName = "152";
            public const string DocumentTypeName = "Ledger Account";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class LedgerAccountGroup
        {
            public const int DocumentTypeId = 153;
            public const string DocumentTypeShortName = "153";
            public const string DocumentTypeName = "Ledger Account Group";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Opening
        {
            public const int DocumentTypeId = 154;
            public const string DocumentTypeShortName = "154";
            public const string DocumentTypeName = "Opening";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class Narration
        {
            public const int DocumentTypeId = 155;
            public const string DocumentTypeShortName = "155";
            public const string DocumentTypeName = "Narration";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class PersonContactType
        {
            public const int DocumentTypeId = 156;
            public const string DocumentTypeShortName = "156";
            public const string DocumentTypeName = "Person Contact Type";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ProductCategry
        {
            public const int DocumentTypeId = 157;
            public const string DocumentTypeShortName = "157";
            public const string DocumentTypeName = "Product Categry";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ProductCustomGroup
        {
            public const int DocumentTypeId = 158;
            public const string DocumentTypeShortName = "158";
            public const string DocumentTypeName = "Product Custom Group";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ProductRateGroup
        {
            public const int DocumentTypeId = 159;
            public const string DocumentTypeShortName = "159";
            public const string DocumentTypeName = "Product Rate Group";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ProductType
        {
            public const int DocumentTypeId = 160;
            public const string DocumentTypeShortName = "160";
            public const string DocumentTypeName = "Product Type";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ProductUid
        {
            public const int DocumentTypeId = 161;
            public const string DocumentTypeShortName = "161";
            public const string DocumentTypeName = "ProductUid";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class PromoCode
        {
            public const int DocumentTypeId = 162;
            public const string DocumentTypeShortName = "162";
            public const string DocumentTypeName = "Promo Code";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class QAGroup
        {
            public const int DocumentTypeId = 163;
            public const string DocumentTypeShortName = "163";
            public const string DocumentTypeName = "QAGroup";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Reason
        {
            public const int DocumentTypeId = 164;
            public const string DocumentTypeShortName = "164";
            public const string DocumentTypeName = "Reason";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
        public static class Route
        {
            public const int DocumentTypeId = 165;
            public const string DocumentTypeShortName = "165";
            public const string DocumentTypeName = "Route";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Unit
        {
            public const int DocumentTypeId = 166;
            public const string DocumentTypeShortName = "Unit";
            public const string DocumentTypeName = "Unit";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class TdsGroup
        {
            public const int DocumentTypeId = 167;
            public const string DocumentTypeShortName = "167";
            public const string DocumentTypeName = "Tds Group";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class TdsCategory
        {
            public const int DocumentTypeId = 168;
            public const string DocumentTypeShortName = "168";
            public const string DocumentTypeName = "Tds Category";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class State
        {
            public const int DocumentTypeId = 169;
            public const string DocumentTypeShortName = "169";
            public const string DocumentTypeName = "State";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class PaymentMode
        {
            public const int DocumentTypeId = 170;
            public const string DocumentTypeShortName = "170";
            public const string DocumentTypeName = "Payment Mode";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class CalculationLedgerAccount
        {
            public const int DocumentTypeId = 171;
            public const string DocumentTypeShortName = "171";
            public const string DocumentTypeName = "Calculation Ledger Account";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class PersonDocument
        {
            public const int DocumentTypeId = 172;
            public const string DocumentTypeShortName = "172";
            public const string DocumentTypeName = "PersonDocument";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ChargeGroupSettings
        {
            public const int DocumentTypeId = 173;
            public const string DocumentTypeShortName = "173";
            public const string DocumentTypeName = "Charge Group Settings";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class ProductTypeAttribute
        {
            public const int DocumentTypeId = 174;
            public const string DocumentTypeShortName = "174";
            public const string DocumentTypeName = "Product Type Attribute";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Prospect
        {
            public const int DocumentTypeId = 175;
            public const string DocumentTypeShortName = "175";
            public const string DocumentTypeName = "Prospect";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }


        public static class SalesTaxProductCode
        {
            public const int DocumentTypeId = 176;
            public const string DocumentTypeShortName = "176";
            public const string DocumentTypeName = "Sales Tax Product Code";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class User
        {
            public const int DocumentTypeId = 177;
            public const string DocumentTypeShortName = "User";
            public const string DocumentTypeName = "User";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }


        public static class Manufacturer
        {
            public const int DocumentTypeId = 178;
            public const string DocumentTypeShortName = "178";
            public const string DocumentTypeName = "Manufacturer";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class DocumentTypeTimeExtension
        {
            public const int DocumentTypeId = 179;
            public const string DocumentTypeShortName = "179";
            public const string DocumentTypeName = "Document Type Time Extension";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class PreDispatchWaybill
        {
            public const int DocumentTypeId = 180;
            public const string DocumentTypeShortName = "180";
            public const string DocumentTypeName = "Pre Dispatch Waybill";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class SaleEnquiryProductMapping
        {
            public const int DocumentTypeId = 181;
            public const string DocumentTypeShortName = "181";
            public const string DocumentTypeName = "SaleEnquiryProductMapping";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }


        public static class ServiceTaxCategory
        {
            public const int DocumentTypeId = 182;
            public const string DocumentTypeShortName = "182";
            public const string DocumentTypeName = "Service Tax Category";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class SaleChallan
        {
            public const int DocumentTypeId = 183;
            public const string DocumentTypeShortName = "183";
            public const string DocumentTypeName = "Sale Challan";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class DiscountType
        {
            public const int DocumentTypeId = 184;
            public const string DocumentTypeShortName = "184";
            public const string DocumentTypeName = "Discount Type";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class IncomeVoucher
        {
            public const int DocumentTypeId = 185;
            public const string DocumentTypeShortName = "185";
            public const string DocumentTypeName = "Income Voucher";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class OtherCollection
        {
            public const int DocumentTypeId = 186;
            public const string DocumentTypeShortName = "186";
            public const string DocumentTypeName = "Other Collection";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }


        public static class StoreRequisition
        {
            public const int DocumentTypeId = 187;
            public const string DocumentTypeShortName = "187";
            public const string DocumentTypeName = "Store Requisition";
            public const int DocumentCategoryId = DocumentCategoryConstants.StoreRequisition.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

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