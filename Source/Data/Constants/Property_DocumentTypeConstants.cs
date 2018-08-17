using Jobs.Constants.DocumentCategory;
using Jobs.Constants.DocumentNature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobs.Constants.PropertyDocumentType
{
    public static class PropertyDocumentTypeConstants
    {
        public static class Property
        {
            public const int DocumentTypeId = 2001;
            public const string DocumentTypeShortName = "Prop";
            public const string DocumentTypeName = "Property";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Area
        {
            public const int DocumentTypeId = 2002;
            public const string DocumentTypeShortName = "Area";
            public const string DocumentTypeName = "Area";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class DiscountType
        {
            public const int DocumentTypeId = 2002;
            public const string DocumentTypeShortName = "DType";
            public const string DocumentTypeName = "Discount Type";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }

        public static class Caste
        {
            public const int DocumentTypeId = 2002;
            public const string DocumentTypeShortName = "Caste";
            public const string DocumentTypeName = "Caste";
            public const int DocumentCategoryId = DocumentCategoryConstants.Master.DocumentCategoryId;
            public const int DocumentNatureId = DocumentNatureConstants.Master.DocumentNatureId;
            public const string Nature = null;
            public const string PrintTitle = null;
        }
    }
}