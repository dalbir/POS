using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
  public  class Inventory_AdditionalInfoClass
    {
        public string Store_ID { get; set; }
        public string ItemNum { get; set; }
        public string ExtendedDescription { get; set; }
        public string Keywords { get; set; }
        public string Brand { get; set; }
        public string Theme { get; set; }
        public string SubCategory { get; set; }
        public string LeadTime { get; set; }
        public int ProductOnPromotionPreOrder { get; set; }
        public int ProductOnSpecialOffer { get; set; }
        public int NewProduct { get; set; }
        public int Discountable { get; set; }
        public decimal WebPrice { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float Weight { get; set; }
        public int NoWebSales { get; set; }
        public int IsPrimaryMatrixItem { get; set; }
        public int Priority { get; set; }
        public int Rating { get; set; }
        public int CustomNumber1 { get; set; }
        public int CustomNumber2 { get; set; }
        public int CustomNumber3 { get; set; }
        public int CustomNumber4 { get; set; }
        public int CustomNumber5 { get; set; }
        public string CustomText1 { get; set; }
        public string CustomText2 { get; set; }
        public string CustomText3 { get; set; }
        public string CustomText4 { get; set; }
        public string CustomText5 { get; set; }
        public string CustomExtendedText1 { get; set; }
        public string CustomExtendedText2 { get; set; }
        public string SubDescription1 { get; set; }
        public string SubDescription2 { get; set; }
        public string SubDescription3 { get; set; }
    }
}
