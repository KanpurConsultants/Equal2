using Jobs.Constants.DocumentCategory;
using Jobs.Constants.DocumentNature;
using Jobs.Constants.RugDocumentCategory;
using Jobs.Constants.RugDocumentNature;
using Jobs.Constants.RugControllerAction;
using Jobs.Constants.Areas;
using System.Linq;
using System.Web;

namespace Jobs.Constants.RugDocumentType
{
    public static class RugDocumentTypeConstants
    {
        public static class CarpetDesign
        {
            public const int DocumentTypeId = 1001;
            public const string DocumentTypeShortName = "CRDSN";
            public const string DocumentTypeName = "Carpet Design";
            public const int DocumentCategoryId = RugDocumentCategoryConstants.Carpet.DocumentCategoryId;
            public const int DocumentNatureId = RugDocumentNatureConstants.Carpet.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }



        public static class Carpet
        {
            public const int DocumentTypeId = 1002;
            public const string DocumentTypeShortName = "Rug";
            public const string DocumentTypeName = "Carpet";
            public const int DocumentCategoryId = RugDocumentCategoryConstants.Carpet.DocumentCategoryId;
            public const int DocumentNatureId = RugDocumentNatureConstants.Carpet.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class CarpetSample
        {
            public const int DocumentTypeId = 1003;
            public const string DocumentTypeShortName = "RUGSA";
            public const string DocumentTypeName = "Carpet Sample";
            public const int DocumentCategoryId = RugDocumentCategoryConstants.CarpetSample.DocumentCategoryId;
            public const int DocumentNatureId = RugDocumentNatureConstants.Carpet.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class ProductAlias
        {
            public const int DocumentTypeId = 1019;
            public const string DocumentTypeShortName = "PALS";
            public const string DocumentTypeName = "Product Alias";
            public const int DocumentCategoryId = DocumentCategoryConstants.StockExchange.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.PaymentVoucher.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }


        public static class JobOrderWeaving
        {
            public const int DocumentTypeId = 1004;
            public const string DocumentTypeShortName = "JOW";
            public const string DocumentTypeName = "Weaving Order";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobOrder.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobOrder.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }
        public static class JobOrderDyeing
        {
            public const int DocumentTypeId = 1005;
            public const string DocumentTypeShortName = "JOD";
            public const string DocumentTypeName = "Dyeing Order";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobOrder.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobOrder.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }
        public static class JobOrderFinishing
        {
            public const int DocumentTypeId = 1006;
            public const string DocumentTypeShortName = "JOF";
            public const string DocumentTypeName = "Finishing Order";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobOrder.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobOrder.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class DesignColourConsumption
        {
            public const int DocumentTypeId = 1007;
            public const string DocumentTypeShortName = "DCC";
            public const string DocumentTypeName = "Design Colour Consumption";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class WeavingReceive
        {
            public const int DocumentTypeId = 1008;
            public const string DocumentTypeShortName = "JRW";
            public const string DocumentTypeName = "Weaving Receive";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobReceive.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobReceive.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = RugControllerActionConstants.WeavingReceiveHeader.ControllerName;
            public const string ActionName = RugControllerActionConstants.WeavingReceiveHeader.ActionName;
            public const string AreaName = AreaConstants.Rug.AreaName;
        }

        public static class DyeingReceive
        {
            public const int DocumentTypeId = 1009;
            public const string DocumentTypeShortName = "JRD";
            public const string DocumentTypeName = "Dyeing Receive";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobReceive.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobReceive.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class FinishingReceive
        {
            public const int DocumentTypeId = 1010;
            public const string DocumentTypeShortName = "JRF";
            public const string DocumentTypeName = "Finishing Receive";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobReceive.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobReceive.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class JobInvoiceWeaving
        {
            public const int DocumentTypeId = 1011;
            public const string DocumentTypeShortName = "JIW";
            public const string DocumentTypeName = "Weaving Invoice";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobInvoice.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobInvoice.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }
        public static class JobInvoiceDyeing
        {
            public const int DocumentTypeId = 1012;
            public const string DocumentTypeShortName = "JID";
            public const string DocumentTypeName = "Dyeing Invoice";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobInvoice.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobInvoice.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }
        public static class JobInvoiceFinishing
        {
            public const int DocumentTypeId = 1013;
            public const string DocumentTypeShortName = "JIF";
            public const string DocumentTypeName = "Finishing Invoice";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobInvoice.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.JobInvoice.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class WeavingConsumptionAdjustment
        {
            public const int DocumentTypeId = 1014;
            public const string DocumentTypeShortName = "WCADJ";
            public const string DocumentTypeName = "Weaving Consumption Adjustment";
            public const int DocumentCategoryId = RugDocumentCategoryConstants.WeavingConsumptionAdjustment.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }


        public static class WeavingPayment
        {
            public const int DocumentTypeId = 1015;
            public const string DocumentTypeShortName = "WVPMT";
            public const string DocumentTypeName = "Weaving Payment";
            public const int DocumentCategoryId = DocumentCategoryConstants.PaymentVoucher.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.PaymentVoucher.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class WeavingTDS
        {
            public const int DocumentTypeId = 1016;
            public const string DocumentTypeShortName = "WVTDS";
            public const string DocumentTypeName = "Weaving TDS";
            public const int DocumentCategoryId = DocumentCategoryConstants.UnUsedDocumentType.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.PaymentVoucher.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class WeavingTimeIncentive
        {
            public const int DocumentTypeId = 1017;
            public const string DocumentTypeShortName = "WTINC";
            public const string DocumentTypeName = "Weaving Time Incentive";
            public const int DocumentCategoryId = DocumentCategoryConstants.UnUsedDocumentType.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.PaymentVoucher.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class WeavingTimePenalty
        {
            public const int DocumentTypeId = 1018;
            public const string DocumentTypeShortName = "WTPNL";
            public const string DocumentTypeName = "Weaving Time Penalty";
            public const int DocumentCategoryId = DocumentCategoryConstants.UnUsedDocumentType.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.PaymentVoucher.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class SmallChunksBazarPenalty
        {
            public const int DocumentTypeId = 1019;
            public const string DocumentTypeShortName = "SCBPN";
            public const string DocumentTypeName = "Small Chunks Bazar Penalty";
            public const int DocumentCategoryId = DocumentCategoryConstants.UnUsedDocumentType.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.PaymentVoucher.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class WeavingCreditNote
        {
            public const int DocumentTypeId = 1020;
            public const string DocumentTypeShortName = "WCRDT";
            public const string DocumentTypeName = "Weaving Credit Note";
            public const int DocumentCategoryId = DocumentCategoryConstants.UnUsedDocumentType.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.PaymentVoucher.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class WeavingDebitNote
        {
            public const int DocumentTypeId = 1021;
            public const string DocumentTypeShortName = "WDEBT";
            public const string DocumentTypeName = "Weaving Debit Note";
            public const int DocumentCategoryId = DocumentCategoryConstants.UnUsedDocumentType.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.PaymentVoucher.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class WeavingReceipt
        {
            public const int DocumentTypeId = 1022;
            public const string DocumentTypeShortName = "WVRCT";
            public const string DocumentTypeName = "Weaving Receipt";
            public const int DocumentCategoryId = DocumentCategoryConstants.UnUsedDocumentType.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.PaymentVoucher.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class PurjaAmtTransfer
        {
            public const int DocumentTypeId = 1023;
            public const string DocumentTypeShortName = "1023";
            public const string DocumentTypeName = "Purja Amt Transfer";
            public const int DocumentCategoryId = DocumentCategoryConstants.UnUsedDocumentType.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.PaymentVoucher.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class PurjaTransfer
        {
            public const int DocumentTypeId = 1024;
            public const string DocumentTypeShortName = "PATRF";
            public const string DocumentTypeName = "Purja Transfer";
            public const int DocumentCategoryId = DocumentCategoryConstants.UnUsedDocumentType.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.PaymentVoucher.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class MaterialIssueForWeaving
        {
            public const int DocumentTypeId = 1025;
            public const string DocumentTypeShortName = "1025";
            public const string DocumentTypeName = "Material Issue For Weaving";
            public const int DocumentCategoryId = DocumentCategoryConstants.MaterialIssue.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.PaymentVoucher.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = RugControllerActionConstants.StockIssueHeader.ControllerName;
            public const string ActionName = RugControllerActionConstants.StockIssueHeader.ActionName;
            public const string AreaName = AreaConstants.Rug.AreaName;
        }

        public static class WeavingExchange
        {
            public const int DocumentTypeId = 1026;
            public const string DocumentTypeShortName = "1026";
            public const string DocumentTypeName = "Weaving Exchange";
            public const int DocumentCategoryId = DocumentCategoryConstants.StockExchange.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.PaymentVoucher.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class RugStencil
        {
            public const int DocumentTypeId = 1027;
            public const string DocumentTypeShortName = "1027";
            public const string DocumentTypeName = "Rug Stencil";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class MaterialReturnFromWeaving
        {
            public const int DocumentTypeId = 1028;
            public const string DocumentTypeShortName = "1028";
            public const string DocumentTypeName = "Material Return From Weaving";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class TraceMapReceive
        {
            public const int DocumentTypeId = 1029;
            public const string DocumentTypeShortName = "1029";
            public const string DocumentTypeName = "Trace Map Receive";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class CarpetPurchaseChallan
        {
            public const int DocumentTypeId = 1030;
            public const string DocumentTypeShortName = "1030";
            public const string DocumentTypeName = "Carpet Purchase Challan";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class CarpetPurchaseGoodsReturn
        {
            public const int DocumentTypeId = 1031;
            public const string DocumentTypeShortName = "1031";
            public const string DocumentTypeName = "Carpet Purchase Goods Return";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class WeavingReturn
        {
            public const int DocumentTypeId = 1032;
            public const string DocumentTypeShortName = "1032";
            public const string DocumentTypeName = "Weaving Return";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class WeavingBazarHalfTuft
        {
            public const int DocumentTypeId = 1033;
            public const string DocumentTypeShortName = "1033";
            public const string DocumentTypeName = "Weaving Bazar Half Tuft";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class DyeingPlan
        {
            public const int DocumentTypeId = 1034;
            public const string DocumentTypeShortName = "DYPLN";
            public const string DocumentTypeName = "Dyeing Plan";
            public const int DocumentCategoryId = DocumentCategoryConstants.Planning.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Planning.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = null;
            public const string ActionName = null;
            public const string AreaName = null;
        }

        public static class CarpetPacking
        {
            public const int DocumentTypeId = 1035;
            public const string DocumentTypeShortName = "CPK";
            public const string DocumentTypeName = "Carpet Packing";
            public const int DocumentCategoryId = DocumentCategoryConstants.Packing.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Packing.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = RugControllerActionConstants.PackingHeader.ControllerName;
            public const string ActionName = RugControllerActionConstants.PackingHeader.ActionName;
            public const string AreaName = AreaConstants.Rug.AreaName;
        }

        public static class ExportInvoice
        {
            public const int DocumentTypeId = 1036;
            public const string DocumentTypeShortName = "EI";
            public const string DocumentTypeName = "Export Invoice";
            public const int DocumentCategoryId = DocumentCategoryConstants.SaleInvoice.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.SaleInvoice.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
            public const string ControllerName = RugControllerActionConstants.SaleInvoiceHeader.ControllerName;
            public const string ActionName = RugControllerActionConstants.SaleInvoiceHeader.ActionName;
            public const string AreaName = AreaConstants.Rug.AreaName;
        }
    }
}