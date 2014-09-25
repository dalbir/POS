using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
  public  class PO_PaymentsClass
    {
        public int PO_Number { get; set; }
        public string Store_ID { get; set; }
        public string Cashier_ID { get; set; }
        public string Payment_Method { get; set; }
        public decimal Amount { get; set; }
        public string Reference_Number { get; set; }
        public int Index { get; set; }
        public int Payment_ID { get; set; }
        public string Description { get; set; }
    }
}
