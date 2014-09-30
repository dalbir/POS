using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Exchange_AdditionalInfoClass
    {
        public int ID { get; set; }
        public string Store_ID { get; set; }
        public int Invoice_Number { get; set; }
        public string WebOrderNumber { get; set; }
        public int CREOrderStatus { get; set; }
        public string Comment { get; set; }
        public string ShippingCarrierName { get; set; }
        public string ShippingTrackingNumber { get; set; }

    }
}
