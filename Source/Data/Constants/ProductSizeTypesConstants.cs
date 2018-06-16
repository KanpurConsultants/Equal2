using Jobs.Constants.Country;
using Jobs.Constants.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobs.Constants.ProductSizeTypes
{
    public static class ProductSizeTypesConstants
    {
        public static class Standard
        {
            public const int ProductSizeTypeId = 1;
            public const string ProductSizeTypeName = "Standard";
        }
        public static class ManufaturingSize
        {
            public const int ProductSizeTypeId = 2;
            public const string ProductSizeTypeName = "Manufaturing Size";
        }
        public static class FinishingSize
        {
            public const int ProductSizeTypeId = 3;
            public const string ProductSizeTypeName = "Finishing Size";
        }
        public static class Stencil
        {
            public const int ProductSizeTypeId = 4;
            public const string ProductSizeTypeName = "Stencil";
        }
        public static class Map
        {
            public const int ProductSizeTypeId = 5;
            public const string ProductSizeTypeName = "Map";
        }
       
    }
}