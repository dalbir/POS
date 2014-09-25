using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Inventory_SpecialClass
    {
        public string Store_ID { get; set; }
        public string ItemNum { get; set; }
        public string Serial { get; set; }
        public string CustNum { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; }
    }
}
