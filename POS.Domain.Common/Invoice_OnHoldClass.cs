using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Invoice_OnHoldClass
    {
        public int Invoice_Number { get; set; }
        public string OnHoldID { get; set; }
        public string Cashier_ID { get; set; }
        public string Store_ID { get; set; }
        public string Occupied { get; set; }
        public string Section_ID { get; set; }
        public int Status { get; set; }
        public string Identifier { get; set; }
        public int PreAuthorized { get; set; }
        public string Name { get; set; }
        public string Station_ID { get; set; }
    }
}
