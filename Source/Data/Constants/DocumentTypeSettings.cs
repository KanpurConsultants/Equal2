using Jobs.Constants.DocumentType;
using Jobs.Constants.RugDocumentType;


namespace Jobs.Constants.DocumentTypeSettings
{
    public static class DocumentTypeSettingsConstants
    {
        public static class SaleOrderCancel
        {
            public const int DocumentTypeSettingsId = 1;
            public const int DocumentTypeId = DocumentTypeConstants.SaleOrderCancel.DocumentTypeId;
            public const string ProductUidCaption = null;
            public const string PartyCaption = "Buyer";
            public const string ProductCaption = null;
            public const string ProductGroupCaption = null;
            public const string ProductCategoryCaption = null;
            public const string Dimension1Caption = null;
            public const string Dimension2Caption = null;
            public const string Dimension3Caption = null;
            public const string Dimension4Caption = null;
            public const string ContraDocTypeCaption = "Sale Order No";
        }
        public static class DeliveryOrder
        {
            public const int DocumentTypeSettingsId = 2;
            public const int DocumentTypeId = DocumentTypeConstants.DeliveryOrder.DocumentTypeId;
            public const string ProductUidCaption = null;
            public const string PartyCaption = "Buyer";
            public const string ProductCaption = null;
            public const string ProductGroupCaption = null;
            public const string ProductCategoryCaption = null;
            public const string Dimension1Caption = null;
            public const string Dimension2Caption = null;
            public const string Dimension3Caption = null;
            public const string Dimension4Caption = null;
            public const string ContraDocTypeCaption = "Sale Order No";
        }

        public static class MaterialPlan
        {
            public const int DocumentTypeSettingsId = 3;
            public const int DocumentTypeId = DocumentTypeConstants.MaterialPlan.DocumentTypeId;
            public const string ProductUidCaption = null;
            public const string PartyCaption = "Buyer";
            public const string ProductCaption = null;
            public const string ProductGroupCaption = null;
            public const string ProductCategoryCaption = null;
            public const string Dimension1Caption = null;
            public const string Dimension2Caption = null;
            public const string Dimension3Caption = null;
            public const string Dimension4Caption = null;
            public const string ContraDocTypeCaption = "Sale Order No";
        }
    }
}