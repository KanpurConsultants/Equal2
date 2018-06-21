using Jobs.Constants.LedgerAccount;
using Jobs.Constants.ProductNature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobs.Constants.RugProductType
{
    public static class RugProductTypeConstants
    {
        public static class Rug
        {
            public const int ProductTypeId = 101;
            public const string ProductTypeName = "Rug";
            public const int ProductNatureId = ProductNatureConstants.TradingProduct.ProductNatureId;
        }
        public static class Yarn
        {
            public const int ProductTypeId = 102;
            public const string ProductTypeName = "Yarn";
            public const int ProductNatureId = ProductNatureConstants.RawMaterial.ProductNatureId;
        }

        public static class Trace
        {
            public const int ProductTypeId = 103;
            public const string ProductTypeName = "Trace";
            public const int ProductNatureId = ProductNatureConstants.RawMaterial.ProductNatureId;
        }
        public static class Map
        {
            public const int ProductTypeId = 104;
            public const string ProductTypeName = "Map";
            public const int ProductNatureId = ProductNatureConstants.RawMaterial.ProductNatureId;
        }
    }
}