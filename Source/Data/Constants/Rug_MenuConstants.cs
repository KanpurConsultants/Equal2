using Jobs.Constants.ControllerAction;
using Jobs.Constants.RugControllerAction;
using Jobs.Constants.DocumentCategory;
using Jobs.Constants.DocumentType;
using Jobs.Constants.Module;
using Jobs.Constants.SubModule;
using Jobs.Constants.ProductNature;
using Jobs.Constants.Areas;
using Jobs.Constants.ProductType;
using Jobs.Constants.RugProductType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobs.Constants.RugMenu
{
    public static class RugMenuConstants
    {    
        public static class Carpet
        {
            public const int MenuId = 1001;
            public const string MenuName = "Carpet";
            public const string Srl = "1002";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Carpet";
            public const int ModuleId = ModuleConstants.Inventory.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = RugControllerActionConstants.CarpetMaster.ControllerName;
            public const string ActionName = RugControllerActionConstants.CarpetMaster.ActionName;
            public static readonly string RouteId = "0";
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = AreaConstants.Rug.AreaName;
        }

        public static class DesignColourConsumption
        {
            public const int MenuId = 1002;
            public const string MenuName = "Design-Colour Consumption";
            public const string Srl = "1002";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Design-Colour Consumption";
            public const int ModuleId = ModuleConstants.Inventory.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = RugControllerActionConstants.DesignColourConsumptionHeader.ControllerName;
            public const string ActionName = RugControllerActionConstants.DesignColourConsumptionHeader.ActionName;
            public static readonly string RouteId = null ;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = AreaConstants.Rug.AreaName;
        }

        public static class DyeingOrderWizard
        {
            public const int MenuId = 1003;
            public const string MenuName = "Dyeing Order Wizard";
            public const string Srl = "1002";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Dyeing Order Wizard";
            public const int ModuleId = ModuleConstants.Production.ModuleId;
            public const int SubModuleId = SubModuleConstants.Documents.SubModuleId;
            public const string ControllerName = RugControllerActionConstants.DyeingOrderWizard.ControllerName;
            public const string ActionName = RugControllerActionConstants.DyeingOrderWizard.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = false;
            public const string AreaName = AreaConstants.Rug.AreaName;
        }

        public static class WeavingOrderWizard
        {
            public const int MenuId = 1004;
            public const string MenuName = "Weaving Order Wizard";
            public const string Srl = "1002";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Weaving Order Wizard";
            public const int ModuleId = ModuleConstants.Inventory.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = RugControllerActionConstants.WeavingOrderWizard.ControllerName;
            public const string ActionName = RugControllerActionConstants.WeavingOrderWizard.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = AreaConstants.Rug.AreaName;
        }

        public static class JobOrderSubmit
        {
            public const int MenuId = 1005;
            public const string MenuName = "Job Order Submit Rug";
            public const string Srl = "1005";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Job Order Submit Rug";
            public const int ModuleId = ModuleConstants.Inventory.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = RugControllerActionConstants.JobOrderSubmitRug.ControllerName;
            public const string ActionName = RugControllerActionConstants.JobOrderSubmitRug.ActionName;
            public static readonly string RouteId = null;
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = AreaConstants.Rug.AreaName;
        }


    }
}