using Jobs.Constants.DocumentType;
using Jobs.Constants.LedgerAccountGroup;
using Jobs.Constants.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobs.Constants.PersonSetting
{
    public static class PersonSettingConstants
    {
        public static class Customer
        {
            public const int PersonSettingsId = 1;
            public const int DocTypeId = DocumentTypeConstants.Customer.DocumentTypeId;
            public const int LedgerAccountGroupId = LedgerAccountGroupConstants.SundryDebtors.LedgerAccountGroupId;
            public const int DefaultProcessId = ProcessConstants.Sale.ProcessId;
            public const Boolean isVisibleAddress = true ;
            public const Boolean isVisibleCity = true;
            public const Boolean isVisiblePersonProcessDetail = false;
        }
        public static class Supplier
        {
            public const int PersonSettingsId = 2;
            public const int DocTypeId = DocumentTypeConstants.Supplier.DocumentTypeId;
            public const int LedgerAccountGroupId = LedgerAccountGroupConstants.SundryCreditors.LedgerAccountGroupId;
            public const int DefaultProcessId = ProcessConstants.Purchase.ProcessId;
            public const Boolean isVisibleAddress = true;
            public const Boolean isVisibleCity = true;
            public const Boolean isVisiblePersonProcessDetail = false;
        }


        public static class Employee
        {
            public const int PersonSettingsId = 3;
            public const int DocTypeId = DocumentTypeConstants.Employee.DocumentTypeId;
            public const int LedgerAccountGroupId = LedgerAccountGroupConstants.SundryCreditors.LedgerAccountGroupId;
            public const int DefaultProcessId = ProcessConstants.Sale.ProcessId;
            public const Boolean isVisibleAddress = true;
            public const Boolean isVisibleCity = true;
            public const Boolean isVisiblePersonProcessDetail = false;
        }
        public static class Transporter
        {
            public const int PersonSettingsId =4;
            public const int DocTypeId = DocumentTypeConstants.Transporter.DocumentTypeId;
            public const int LedgerAccountGroupId = LedgerAccountGroupConstants.SundryCreditors.LedgerAccountGroupId;
            public const int DefaultProcessId = ProcessConstants.Sale.ProcessId;
            public const Boolean isVisibleAddress = true;
            public const Boolean isVisibleCity = true;
            public const Boolean isVisiblePersonProcessDetail = false;
        }

        public static class JobWorker
        {
            public const int PersonSettingsId = 5;
            public const int DocTypeId = DocumentTypeConstants.JobWorker.DocumentTypeId;
            public const int LedgerAccountGroupId = LedgerAccountGroupConstants.SundryCreditors.LedgerAccountGroupId;
            public const int DefaultProcessId = ProcessConstants.Manufacturing.ProcessId;
            public const Boolean isVisibleAddress = true;
            public const Boolean isVisibleCity = true;
            public const Boolean isVisiblePersonProcessDetail = true;
        }
    }
}