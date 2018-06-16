using Jobs.Constants.LedgerAccount;
using Jobs.Constants.ProductType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobs.Constants.ProductGroup
{
    public static class ProductGroupConstants
    {
        //Only For Carpet Industry
        public static class Trace
        {
            public const int ProductGroupId = 1;
            public const string ProductGroupName = "Trace";
            public const int ProductTypeId = ProductTypeConstants.Trace.ProductTypeId;
        }
        //Only For Carpet Industry
        public static class Map
        {
            public const int ProductGroupId = 2;
            public const string ProductGroupName = "Map";
            public const int ProductTypeId = ProductTypeConstants.Map.ProductTypeId;
        }
        public static class Bom
        {
            public const int ProductGroupId = 3;
            public const string ProductGroupName = "Bom";
            public const int ProductTypeId = ProductTypeConstants.Bom.ProductTypeId;
        }
    }
}