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
        
        public static class Size
        {
            public const int MenuId = 1001;
            public const string MenuName = "Size";
            public const string Srl = "2";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Size";
            public const int ModuleId = ModuleConstants.Inventory.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = RugControllerActionConstants.Size.ControllerName;
            public const string ActionName = RugControllerActionConstants.Size.ActionName;
            public static readonly string RouteId = RugProductTypeConstants.Rug.ProductTypeId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = AreaConstants.Rug.AreaName;
        }
        
       public static class ProcessSequence
        {
            public const int MenuId = 1002;
            public const string MenuName = "Process Sequence";
            public const string Srl = "2";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Process Sequence";
            public const int ModuleId = ModuleConstants.Inventory.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = RugControllerActionConstants.ProcessSequenceHeader.ControllerName;
            public const string ActionName = RugControllerActionConstants.ProcessSequenceHeader.ActionName;
            public static readonly string RouteId = RugProductTypeConstants.Rug.ProductTypeId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = null;
        }

        public static class Colour
        {
            public const int MenuId = 1003;
            public const string MenuName = "Colour";
            public const string Srl = "2";
            public const string IconName = "glyphicon glyphicon-book";
            public const string Description = "Colour";
            public const int ModuleId = ModuleConstants.Inventory.ModuleId;
            public const int SubModuleId = SubModuleConstants.Setup.SubModuleId;
            public const string ControllerName = RugControllerActionConstants.Colour.ControllerName;
            public const string ActionName = RugControllerActionConstants.Colour.ActionName;
            public static readonly string RouteId = RugProductTypeConstants.Rug.ProductTypeId.ToString();
            public const string URL = "JobsDomain";
            public const bool IsVisible = true;
            public const string AreaName = AreaConstants.Rug.AreaName;
        }
    }
}