using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class PayoutsClass
    {
        public int ID { get; set; }
        public string Store_ID { get; set; }
        public string Cashier_ID { get; set; }
        public DateTime DateTime { get; set; }
        public string Vendor_Number { get; set; }
        public decimal Amount { get; set; }
        public string Station_ID { get; set; }
        public string Description { get; set; }
        public string Payment_Method { get; set; }
        public string Type { get; set; }
        public string Override_ID { get; set; }
        public string ItemNum { get; set; }
    }
}
