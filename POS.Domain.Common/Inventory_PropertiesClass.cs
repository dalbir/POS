using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Inventory_PropertiesClass
    {
        public string Store_ID { get; set; }
        public string ItemNum { get; set; }
        public int Value_ID { get; set; }
        public int StoreWithInvoice { get; set; }
    }
}
