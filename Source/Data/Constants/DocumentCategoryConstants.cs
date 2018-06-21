using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobs.Constants.DocumentCategory
{
    public static class DocumentCategoryConstants
    {
        #region "Sales"
        public static class SaleEnquiry
        {
            public const int DocumentCategoryId = 10;
            public const string DocumentCategoryName = "Sale Enquiry";
        }
        public static class SaleEnquiryCancel
        {
            public const int DocumentCategoryId = 20;
            public const string DocumentCategoryName = "Sale Enquiry Cancel";
        }
        public static class SaleQuotation
        {
            public const int DocumentCategoryId = 30;
            public const string DocumentCategoryName = "Sale Quotation";
        }
        public static class SaleQuotationCancel
        {
            public const int DocumentCategoryId = 40;
            public const string DocumentCategoryName = "Sale Quotation Cancel";
        }
        public static class SaleOrder
        {
            public const int DocumentCategoryId = 50;
            public const string DocumentCategoryName = "Sale Order";
        }
        public static class SaleOrderCancel
        {
            public const int DocumentCategoryId = 60;
            public const string DocumentCategoryName = "Sale Order Cancel";
        }
        public static class SaleOrderAmendment
        {
            public const int DocumentCategoryId = 70;
            public const string DocumentCategoryName = "Sale Order Amendment";
        }
        public static class CustomerAuditRequest
        {
            public const int DocumentCategoryId = 80;
            public const string DocumentCategoryName = "Customer Audit Request";
        }
        public static class CustomerAudit
        {
            public const int DocumentCategoryId = 100;
            public const string DocumentCategoryName = "Customer Audit";
        }
        public static class Packing
        {
            public const int DocumentCategoryId = 110;
            public const string DocumentCategoryName = "Packing";
        }
        public static class PerformaInvoice
        {
            public const int DocumentCategoryId = 120;
            public const string DocumentCategoryName = "Performa Invoice";
        }
        public static class GoodsDispatch
        {
            public const int DocumentCategoryId = 130;
            public const string DocumentCategoryName = "Goods Dispatch";
        }
        public static class GoodsReturnInword
        {
            public const int DocumentCategoryId = 140;
            public const string DocumentCategoryName = "Goods Return (Inword)";
        }
        public static class SaleInvoice
        {
            public const int DocumentCategoryId = 150;
            public const string DocumentCategoryName = "Sale Invoice";
        }
        public static class SaleReturn
        {
            public const int DocumentCategoryId = 160;
            public const string DocumentCategoryName = "Sale Return";
        }
        public static class DeliveryOrder
        {
            public const int DocumentCategoryId = 170;
            public const string DocumentCategoryName = "Delivery Order";
        }
        public static class DeliveryOrderCancel
        {
            public const int DocumentCategoryId = 180;
            public const string DocumentCategoryName = "Delivery Order Cancel";
        }
        public static class QualityCheckingOutword
        {
            public const int DocumentCategoryId = 190;
            public const string DocumentCategoryName = "Quality Checking (Outword)";
        }
        public static class WayBillOutword
        {
            public const int DocumentCategoryId = 200;
            public const string DocumentCategoryName = "Way Bill (Outword)";
        }
        public static class WayBillInword
        {
            public const int DocumentCategoryId = 210;
            public const string DocumentCategoryName = "Way Bill (Inword)";
        }
        #endregion
        #region "Purchase"
        public static class PurchasePlan
        {
            public const int DocumentCategoryId = 220;
            public const string DocumentCategoryName = "Purchase Plan";
        }
        public static class PurchasePlanCancel
        {
            public const int DocumentCategoryId = 230;
            public const string DocumentCategoryName = "Purchase Plan Cancel";
        }
        public static class PurchaseEnquiry
        {
            public const int DocumentCategoryId = 240;
            public const string DocumentCategoryName = "Purchase Enquiry";
        }
        public static class PurchaseEnquiryCancel
        {
            public const int DocumentCategoryId = 250;
            public const string DocumentCategoryName = "Purchase Enquiry Cancel";
        }
        public static class PurchaseQuotation
        {
            public const int DocumentCategoryId = 260;
            public const string DocumentCategoryName = "Purchase Quotation";
        }
        public static class PurchaseQuotationCancel
        {
            public const int DocumentCategoryId = 270;
            public const string DocumentCategoryName = "Purchase Quotation Cancel";
        }
        public static class PurchaseOrder
        {
            public const int DocumentCategoryId = 280;
            public const string DocumentCategoryName = "Purchase Order";
        }
        public static class PurchaseOrderCancel
        {
            public const int DocumentCategoryId = 290;
            public const string DocumentCategoryName = "Purchase Order Cancel";
        }
        public static class PurchaseOrderAmendment
        {
            public const int DocumentCategoryId = 300;
            public const string DocumentCategoryName = "Purchase Order Amendment";
        }
        public static class SupplierAuditRequest
        {
            public const int DocumentCategoryId = 320;
            public const string DocumentCategoryName = "Supplier Audit Request";
        }
        public static class SupplierAudit
        {
            public const int DocumentCategoryId = 340;
            public const string DocumentCategoryName = "Supplier Audit";
        }
        public static class GoodsReceipt
        {
            public const int DocumentCategoryId = 350;
            public const string DocumentCategoryName = "Goods Receipt";
        }
        public static class QualityCheckingInword
        {
            public const int DocumentCategoryId = 360;
            public const string DocumentCategoryName = "Quality Checking (Inword)";
        }
        public static class GoodsReturnOutword
        {
            public const int DocumentCategoryId = 370;
            public const string DocumentCategoryName = "Goods Return (Outword)";
        }
        public static class PurchaseInvoice
        {
            public const int DocumentCategoryId = 380;
            public const string DocumentCategoryName = "Purchase Invoice";
        }
        public static class PurchaseReturn
        {
            public const int DocumentCategoryId = 390;
            public const string DocumentCategoryName = "Purchase Return";
        }
        #endregion
        #region "Job"
        public static class ManufacturingPlan
        {
            public const int DocumentCategoryId = 400;
            public const string DocumentCategoryName = "Manufacturing Plan";
        }
        public static class ManufacturingPlanCancel
        {
            public const int DocumentCategoryId = 410;
            public const string DocumentCategoryName = "Manufacturing Plan Cancel";
        }
        public static class JobEnquiry
        {
            public const int DocumentCategoryId = 420;
            public const string DocumentCategoryName = "Job Enquiry";
        }
        public static class JobEnquiryCancel
        {
            public const int DocumentCategoryId = 430;
            public const string DocumentCategoryName = "Job Enquiry Cancel";
        }
        public static class JobQuotation
        {
            public const int DocumentCategoryId = 440;
            public const string DocumentCategoryName = "Job Quotation";
        }
        public static class JobQuotationCancel
        {
            public const int DocumentCategoryId = 450;
            public const string DocumentCategoryName = "Job Quotation Cancel";
        }
        public static class JobOrder
        {
            public const int DocumentCategoryId = 460;
            public const string DocumentCategoryName = "Job Order";
        }
        public static class JobOrderCancel
        {
            public const int DocumentCategoryId = 470;
            public const string DocumentCategoryName = "Job Order Cancel";
        }
        public static class JobOrderAmendment
        {
            public const int DocumentCategoryId = 480;
            public const string DocumentCategoryName = "Job Order Amendment";
        }
        public static class JobReceive
        {
            public const int DocumentCategoryId = 490;
            public const string DocumentCategoryName = "Job Receive";
        }
        public static class JobInspectionRequest
        {
            public const int DocumentCategoryId = 500;
            public const string DocumentCategoryName = "Job Inspection Request";
        }
        public static class JobInspectionRequestCancel
        {
            public const int DocumentCategoryId = 510;
            public const string DocumentCategoryName = "Job Inspection Request Cancel";
        }
        public static class JobInspection
        {
            public const int DocumentCategoryId = 520;
            public const string DocumentCategoryName = "Job Inspection";
        }
        public static class JobReceiveQC
        {
            public const int DocumentCategoryId = 530;
            public const string DocumentCategoryName = "Job Receive QC";
        }
        public static class JobReturn
        {
            public const int DocumentCategoryId = 540;
            public const string DocumentCategoryName = "Job Return";
        }
        public static class JobInvoice
        {
            public const int DocumentCategoryId = 550;
            public const string DocumentCategoryName = "Job Invoice";
        }
        public static class DebitNoteOutward
        {
            public const int DocumentCategoryId = 570;
            public const string DocumentCategoryName = "Debit Note Outward";
        }
        public static class CreditNoteOutward
        {
            public const int DocumentCategoryId = 580;
            public const string DocumentCategoryName = "Credit Note Outward";
        }
        #endregion
        #region "Inventory"
        public static class MaterialRequest
        {
            public const int DocumentCategoryId = 590;
            public const string DocumentCategoryName = "Material Request";
        }
        public static class MaterialRequestCancel
        {
            public const int DocumentCategoryId = 600;
            public const string DocumentCategoryName = "Material Request Cancel";
        }
        public static class MaterialIssue
        {
            public const int DocumentCategoryId = 610;
            public const string DocumentCategoryName = "Material Issue";
        }
        public static class MaterialReceive
        {
            public const int DocumentCategoryId = 620;
            public const string DocumentCategoryName = "Material Receive";
        }
        public static class MaterialTransfer
        {
            public const int DocumentCategoryId = 630;
            public const string DocumentCategoryName = "Material Transfer";
        }
        public static class StockExchange
        {
            public const int DocumentCategoryId = 640;
            public const string DocumentCategoryName = "Stock Exchange";
        }
        public static class GatePass
        {
            public const int DocumentCategoryId = 650;
            public const string DocumentCategoryName = "Gate Pass";
        }
        #endregion
        #region "Planning"
        public static class SaleOrderPlan
        {
            public const int DocumentCategoryId = 660;
            public const string DocumentCategoryName = "Sale Order Plan";
        }
        #endregion
        #region "Accounts"
        public static class PaymentVoucher
        {
            public const int DocumentCategoryId = 670;
            public const string DocumentCategoryName = "Payment Voucher";
        }
        public static class ReceiptVoucher
        {
            public const int DocumentCategoryId = 680;
            public const string DocumentCategoryName = "Receipt Voucher";
        }
        public static class JournalVoucher
        {
            public const int DocumentCategoryId = 690;
            public const string DocumentCategoryName = "Journal Voucher";
        }
        public static class ContraVoucher
        {
            public const int DocumentCategoryId = 700;
            public const string DocumentCategoryName = "Contra Voucher";
        }
        public static class DebitNote
        {
            public const int DocumentCategoryId = 710;
            public const string DocumentCategoryName = "Debit Note";
        }
        public static class CreditNote
        {
            public const int DocumentCategoryId = 720;
            public const string DocumentCategoryName = "Credit Note";
        }
        public static class ChequeCancel
        {
            public const int DocumentCategoryId = 730;
            public const string DocumentCategoryName = "Cheque Cancel";
        }
        public static class PaymentRequest
        {
            public const int DocumentCategoryId = 731;
            public const string DocumentCategoryName = "Payment Request";
        }
        public static class LeaveRequest
        {
            public const int DocumentCategoryId = 732;
            public const string DocumentCategoryName = "Leave Request";
        }
        public static class PaymentAdvise
        {
            public const int DocumentCategoryId = 733;
            public const string DocumentCategoryName = "Payment Advise";
        }
        public static class Salary
        {
            public const int DocumentCategoryId = 734;
            public const string DocumentCategoryName = "Salary";
        }
        public static class ExpenseVoucher
        {
            public const int DocumentCategoryId = 740;
            public const string DocumentCategoryName = "Expense Voucher";
        }
        #endregion
        #region "Masters"
        public static class Person
        {
            public const int DocumentCategoryId = 750;
            public const string DocumentCategoryName = "Person";
        }
        #endregion

        public static class ProductType
        {
            public const int DocumentCategoryId = 751;
            public const string DocumentCategoryName = "Product Type";
        }

        public static class ProductCategory
        {
            public const int DocumentCategoryId = 752;
            public const string DocumentCategoryName = "Product Category";
        }

        public static class ProductGroup
        {
            public const int DocumentCategoryId = 753;
            public const string DocumentCategoryName = "Product Group";
        }
        public static class Product
        {
            public const int DocumentCategoryId = 754;
            public const string DocumentCategoryName = "Product";
        }
        public static class Quality
        {
            public const int DocumentCategoryId = 755;
            public const string DocumentCategoryName = "Quality";
        }

        public static class ProductSize
        {
            public const int DocumentCategoryId = 756;
            public const string DocumentCategoryName = "Product Size";
        }

        public static class Content
        {
            public const int DocumentCategoryId = 757;
            public const string DocumentCategoryName = "Content";
        }

        public static class Construction
        {
            public const int DocumentCategoryId = 758;
            public const string DocumentCategoryName = "Construction";
        }

        public static class ColourWays
        {
            public const int DocumentCategoryId = 759;
            public const string DocumentCategoryName = "Colour Ways";
        }

        public static class Colour
        {
            public const int DocumentCategoryId = 760;
            public const string DocumentCategoryName = "Colour";
        }

        public static class Collection
        {
            public const int DocumentCategoryId = 761;
            public const string DocumentCategoryName = "Collection";
        }
        public static class ProductQuality
        {
            public const int DocumentCategoryId = 763;
            public const string DocumentCategoryName = "Product Quality";
        }
        public static class Size
        {
            public const int DocumentCategoryId = 764;
            public const string DocumentCategoryName = "Size";
        }
        public static class ProductCollection
        {
            public const int DocumentCategoryId = 765;
            public const string DocumentCategoryName = "Product Collection";
        }
        public static class ProductContent
        {
            public const int DocumentCategoryId = 766;
            public const string DocumentCategoryName = "Product Content";
        }

        public static class ProcessSequence
        {
            public const int DocumentCategoryId = 767;
            public const string DocumentCategoryName = "Process Sequence";
        }

        public static class Master
        {
            public const int DocumentCategoryId = 768;
            public const string DocumentCategoryName = "Master";
        }
    }
}