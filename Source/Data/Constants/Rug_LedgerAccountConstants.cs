using Jobs.Constants.LedgerAccountGroup;
using Jobs.Constants.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobs.Constants.RugLedgerAccount
{
    public static class RugLedgerAccountConstants
    {
        public static class WeavingAc
        {
            public const int LedgerAccountId = 1001;
            public const string LedgerAccountName = "Weaving A/c";
            public const string LedgerAccountSuffix = "Weaving";
            public const int LedgerAccountGroupId = LedgerAccountGroupConstants.SundryCreditors.LedgerAccountGroupId;
        }

        public static class DyeingAc
        {
            public const int LedgerAccountId = 1002;
            public const string LedgerAccountName = "Dyeing A/c";
            public const string LedgerAccountSuffix = "Dyeing";
            public const int LedgerAccountGroupId = LedgerAccountGroupConstants.SundryCreditors.LedgerAccountGroupId;
        }

        public static class FinishingAc
        {
            public const int LedgerAccountId = 1003;
            public const string LedgerAccountName = "Finishing A/c";
            public const string LedgerAccountSuffix = "Finishing";
            public const int LedgerAccountGroupId = LedgerAccountGroupConstants.SundryCreditors.LedgerAccountGroupId;
        }
        public static class PackingAc
        {
            public const int LedgerAccountId = 1004;
            public const string LedgerAccountName = "Packing A/c";
            public const string LedgerAccountSuffix = "Packing";
            public const int LedgerAccountGroupId = LedgerAccountGroupConstants.SundryCreditors.LedgerAccountGroupId;
        }


        public static class WashingAc
        {
            public const int LedgerAccountId = 1005;
            public const string LedgerAccountName = "Washing A/c";
            public const string LedgerAccountSuffix = "Washing";
            public const int LedgerAccountGroupId = LedgerAccountGroupConstants.SundryCreditors.LedgerAccountGroupId;
        }
        public static class BindingAc
        {
            public const int LedgerAccountId = 1006;
            public const string LedgerAccountName = "Binding A/c";
            public const string LedgerAccountSuffix = "Binding";
            public const int LedgerAccountGroupId = LedgerAccountGroupConstants.SundryCreditors.LedgerAccountGroupId;
        }
        public static class ClippingAc
        {
            public const int LedgerAccountId = 1007;
            public const string LedgerAccountName = "Clipping A/c";
            public const string LedgerAccountSuffix = "Clipping";
            public const int LedgerAccountGroupId = LedgerAccountGroupConstants.SundryCreditors.LedgerAccountGroupId;
        }

        public static class EmbossingAc
        {
            public const int LedgerAccountId = 1008;
            public const string LedgerAccountName = "Embossing A/c";
            public const string LedgerAccountSuffix = "Embossing";
            public const int LedgerAccountGroupId = LedgerAccountGroupConstants.SundryCreditors.LedgerAccountGroupId;
        }
    }
}