using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Mobile_DiscountClass
    {
        public string Store_ID { get; set; }
        public DateTime DateTime { get; set; }
        public int CRENumber { get; set; }
        public decimal Amount { get; set; }
        public string TraceNumber { get; set; }
        public int Sub_Invoice_Number { get; set; }
        public string CreType { get; set; }
        public string MobilePaymentTraceNumber { get; set; }
    }
}
