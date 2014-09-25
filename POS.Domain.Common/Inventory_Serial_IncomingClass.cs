using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Inventory_Serial_IncomingClass
    {
        public string Store_ID { get; set; }
        public string ItemNum { get; set; }
        public string SerialNum { get; set; }
        public decimal Quantity { get; set; }
        public DateTime Date_Received { get; set; }
        public int PO_Number { get; set; }
    }
}
