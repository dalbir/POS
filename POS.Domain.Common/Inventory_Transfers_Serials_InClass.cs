using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Inventory_Transfers_Serials_InClass
    {
        public string Trans_ID { get; set; }
        public string ItemNum { get; set; }
        public string SerialNum { get; set; }
        public string Store_ID { get; set; }
        public decimal Quantity { get; set; }
        public int Dirty { get; set; }
        public string Originator { get; set; }
    }
}
