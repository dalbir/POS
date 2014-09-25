using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Inventory_TakingClass
    {
        public string ItemNum { get; set; }
        public string Store_ID { get; set; }
        public string ItemName { get; set; }
        public decimal In_Stock { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public int EditType { get; set; }
        public int Counted { get; set; }
        public string Location { get; set; }
        public string Vendor_Part_Num { get; set; }
        public string RowID { get; set; }
        public string Reason { get; set; }
        public string Cashier_ID { get; set; }
    }
}
