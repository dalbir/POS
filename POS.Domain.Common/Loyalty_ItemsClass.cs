using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Loyalty_ItemsClass
    {
        public string Loyalty_Item_ID { get; set; }
        public string Store_ID { get; set; }
        public string Description { get; set; }
        public int Loyalty_Type { get; set; }
        public int Criteria { get; set; }
        public string ItemNum { get; set; }
        public int Tax_1 { get; set; }
        public int Tax_2 { get; set; }
        public int Tax_3 { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public int Redemption_Allowed { get; set; }
        public int ChildItemsFree { get; set; }
    }
}
