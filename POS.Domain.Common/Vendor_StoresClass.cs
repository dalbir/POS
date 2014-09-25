using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Vendor_StoresClass
    {
        public string Vendor_Number { get; set; }
        public string Store_ID { get; set; }
        public int Allow_Purchase_Orders { get; set; }
        public int Allow_Purchase_Now { get; set; }
        public int Order_Type_Allowed { get; set; }
        public int Template_ID { get; set; }
        public int Typical_Delivery_Time { get; set; }
        public string Default_Instructions { get; set; }
        public string Notes { get; set; }
    }
}
