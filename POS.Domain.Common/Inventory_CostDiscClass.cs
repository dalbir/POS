using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Inventory_CostDiscClass
    {
        public string Store_ID { get; set; }
        public string ItemNum { get; set; }
        public string Desc1 { get; set; }
        public string Amt1 { get; set; }
        public int Type1 { get; set; }
        public string Desc2 { get; set; }
        public decimal Amt2 { get; set; }
        public string Type2 { get; set; }
        public string Desc3 { get; set; }
        public decimal Amt3 { get; set; }
        public int Type3 { get; set; } 
    }
}
