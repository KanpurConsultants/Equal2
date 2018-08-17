using System;
using System.Collections.Generic;
using System.Linq;
using Jobs.Constants.DocumentCategory;

namespace Jobs.Constants.Reasons
{
    public static class ReasonConstants
    {
        public static class NotRequired
        {
            public const int ReasonId = 1;
            public const string ReasonName = "Not Required";
            public const int DocumentCategoryId = DocumentCategoryConstants.JobOrderCancel.DocumentCategoryId;
        }
        public static class ToldByBuyer
        {
            public const int ReasonId = 2;
            public const string ReasonName = "Told By Buyer";
            public const int DocumentCategoryId = DocumentCategoryConstants.SaleOrderCancel.DocumentCategoryId;
        }
        public static class StoreRequisition
        {
            public const int ReasonId = 3;
            public const string ReasonName = "Material Requirement";
            public const int DocumentCategoryId = DocumentCategoryConstants.StoreRequisition.DocumentCategoryId;
        }
    }
}