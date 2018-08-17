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
        public static class Trace
        {
            public const int ProductGroupId = 1;
            public const string ProductGroupName = "Raw Material";
            public const int ProductTypeId = ProductTypeConstants.RawMaterial.ProductTypeId;
        }
        public static class TradingProduct
        {
            public const int ProductGroupId = 2;
            public const string ProductGroupName = "Trading Product";
            public const int ProductTypeId = ProductTypeConstants.TradingProduct.ProductTypeId;
        }
        public static class OtherMaterial
        {
            public const int ProductGroupId = 3;
            public const string ProductGroupName = "Other Material";
            public const int ProductTypeId = ProductTypeConstants.OtherMaterial.ProductTypeId;
        }
        public static class Bom
        {
            public const int ProductGroupId = 4;
            public const string ProductGroupName = "Bom";
            public const int ProductTypeId = ProductTypeConstants.Bom.ProductTypeId;
        }

        public static class LedgerAccount
        {
            public const int ProductGroupId = 5;
            public const string ProductGroupName = "Ledger Account";
            public const int ProductTypeId = ProductTypeConstants.LedgerAccount.ProductTypeId;
        }
    }
}