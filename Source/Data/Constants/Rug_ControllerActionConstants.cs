using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobs.Constants.RugControllerAction
{
    public static class RugControllerActionConstants
    {      
        public static class CarpetMaster
        {
            public const int ControllerActionId = 1001;
            public const string ControllerName = "CarpetMaster";
            public const string ActionName = "Index";
        }

        public static class DesignColourConsumptionHeader
        {
            public const int ControllerActionId = 1002;
            public const string ControllerName = "DesignColourConsumptionHeader";
            public const string ActionName = "Index";
        }

        public static class DyeingOrderWizard
        {
            public const int ControllerActionId = 1003;
            public const string ControllerName = "DyeingOrderWizard";
            public const string ActionName = "CreateDyeingOrder";
        }

        public static class WeavingOrderWizard
        {
            public const int ControllerActionId = 1004;
            public const string ControllerName = "WeavingOrderWizard";
            public const string ActionName = "CreateWeavingOrder";
        }

        public static class JobOrderSubmitRug
        {
            public const int ControllerActionId = 1005;
            public const string ControllerName = "JobOrderEvents";
            public const string ActionName = "JobOrder_OnSubmit";
        }

        public static class SaleInvoiceHeader
        {
            public const int ControllerActionId = 1006;
            public const string ControllerName = "SaleInvoiceHeader";
            public const string ActionName = "Index";
        }

        public static class PackingHeader
        {
            public const int ControllerActionId = 1007;
            public const string ControllerName = "PackingHeader";
            public const string ActionName = "Index";
        }
        public static class WeavingReceiveHeader
        {
            public const int ControllerActionId = 1008;
            public const string ControllerName = "WeavingReceiveQACombined";
            public const string ActionName = "Index";
        }
        public static class StockIssueHeader
        {
            public const int ControllerActionId = 1009;
            public const string ControllerName = "StockIssueHeader";
            public const string ActionName = "Index";
        }
    }
}