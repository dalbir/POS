using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Inventory_ReorderClass
    {
        public string ItemNum { get; set; }
        public string ItemName { get; set; }
        public string Store_ID { get; set; }
        public decimal Cost { get; set; }
        public decimal In_Stock { get; set; }
        public float Reorder_Level { get; set; }
        public float Reorder_Quantity { get; set; }
        public string Vendor_Number { get; set; }
        public string Dept_ID { get; set; }
    }
}
