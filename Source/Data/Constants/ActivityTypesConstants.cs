using Jobs.Constants.Country;
using Jobs.Constants.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobs.Constants.ActivityTypes
{
    public static class ActivityTypesConstants
    {
        public static class UnKnown
        {
            public const int ActivityTypeId = 0;
            public const string ActivityTypeName = "UnKnown";
        }
        public static class Submitted
        {
            public const int ActivityTypeId = 1;
            public const string ActivityTypeName = "Submitted";
        }
        public static class Approved
        {
            public const int ActivityTypeId = 2;
            public const string ActivityTypeName = "Approved";
        }
        public static class Modified
        {
            public const int ActivityTypeId = 3;
            public const string ActivityTypeName = "Modified";
        }
        public static class ModificationSumbitted
        {
            public const int ActivityTypeId = 4;
            public const string ActivityTypeName = "ModificationSumbitted";
        }
        public static class Deleted
        {
            public const int ActivityTypeId = 5;
            public const string ActivityTypeName = "Deleted";
        }
        public static class Added
        {
            public const int ActivityTypeId = 6;
            public const string ActivityTypeName = "Added";
        }
        public static class Closed
        {
            public const int ActivityTypeId = 7;
            public const string ActivityTypeName = "Closed";
        }

        public static class Report
        {
            public const int ActivityTypeId = 8;
            public const string ActivityTypeName = "Report";
        }
        public static class Reviewed
        {
            public const int ActivityTypeId = 9;
            public const string ActivityTypeName = "Reviewed";
        }
        public static class Import
        {
            public const int ActivityTypeId = 10;
            public const string ActivityTypeName = "Import";
        }
        public static class WizardCreate
        {
            public const int ActivityTypeId = 11;
            public const string ActivityTypeName = "WizardCreate";
        }

        public static class MultipleCreate
        {
            public const int ActivityTypeId = 12;
            public const string ActivityTypeName = "MultipleCreate";
        }

        public static class Print
        {
            public const int ActivityTypeId = 13;
            public const string ActivityTypeName = "Print";
        }

        public static class Detail
        {
            public const int ActivityTypeId = 14;
            public const string ActivityTypeName = "Detail";
        }

        public static class FileAdded
        {
            public const int ActivityTypeId = 15;
            public const string ActivityTypeName = "FileAdded";
        }

        public static class FileRemoved
        {
            public const int ActivityTypeId = 16;
            public const string ActivityTypeName = "FileRemoved";
        }

        public static class SettingsAdded
        {
            public const int ActivityTypeId = 17;
            public const string ActivityTypeName = "SettingsAdded";
        }

        public static class SettingsModified
        {
            public const int ActivityTypeId = 18;
            public const string ActivityTypeName = "SettingsModified";
        }
    }
}