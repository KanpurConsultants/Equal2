using Jobs.Constants.LedgerAccount;
using Jobs.Constants.RugProductType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobs.Constants.RugProductGroup
{
    public static class RugProductGroupConstants
    {
        public static class Trace
        {
            public const int ProductGroupId = 101;
            public const string ProductGroupName = "Trace";
            public const int ProductTypeId = RugProductTypeConstants.Trace.ProductTypeId;
        }
        public static class Map
        {
            public const int ProductGroupId = 102;
            public const string ProductGroupName = "Map";
            public const int ProductTypeId = RugProductTypeConstants.Map.ProductTypeId;
        }

    }
}