using Jobs.Constants.RugLedgerAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobs.Constants.RugProcess
{
    public static class RugProcessConstants
    {
        public static class Weaving
        {
            public const int ProcessId = 101;
            public const string ProcessCode = "Weaving";
            public const string ProcessName = "Weaving";
            public const int AccountId = RugLedgerAccountConstants.WeavingAc.LedgerAccountId;
            public const int  ParentProcessId = 0 ;
            
        }
        public static class Dyeing
        {
            public const int ProcessId = 102;
            public const string ProcessCode = "Dyeing";
            public const string ProcessName = "Dyeing";
            public const int AccountId = RugLedgerAccountConstants.DyeingAc.LedgerAccountId;
            public const int ParentProcessId = 0;
        }

        public static class Finishing
        {
            public const int ProcessId = 103;
            public const string ProcessCode = "Finishing";
            public const string ProcessName = "Finishing";
            public const int AccountId = RugLedgerAccountConstants.FinishingAc.LedgerAccountId;
            public const int ParentProcessId = 0;
        }

        public static class Packing
        {
            public const int ProcessId = 104;
            public const string ProcessCode = "Packing";
            public const string ProcessName = "Packing";
            public const int AccountId = RugLedgerAccountConstants.PackingAc.LedgerAccountId;
            public const int ParentProcessId = 0;
        }

        public static class Washing
        {
            public const int ProcessId = 105;
            public const string ProcessCode = "Washing";
            public const string ProcessName = "Washing";
            public const int AccountId = RugLedgerAccountConstants.WashingAc.LedgerAccountId;
            public const int ParentProcessId = Finishing.ProcessId;
        }

        public static class Binding
        {
            public const int ProcessId = 106;
            public const string ProcessCode = "Binding";
            public const string ProcessName = "Binding";
            public const int AccountId = RugLedgerAccountConstants.BindingAc.LedgerAccountId;
            public const int ParentProcessId = Finishing.ProcessId;
        }

        public static class Clipping
        {
            public const int ProcessId = 107;
            public const string ProcessCode = "Clipping";
            public const string ProcessName = "Clipping";
            public const int AccountId = RugLedgerAccountConstants.ClippingAc.LedgerAccountId;
            public const int ParentProcessId = Finishing.ProcessId;
        }

        public static class Embossing
        {
            public const int ProcessId = 108;
            public const string ProcessCode = "Embossing";
            public const string ProcessName = "Embossing";
            public const int AccountId = RugLedgerAccountConstants.EmbossingAc.LedgerAccountId;
            public const int ParentProcessId = Finishing.ProcessId;
        }
    }
}