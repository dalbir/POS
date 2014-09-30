using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Invoice_ExceptionsClass
    {
        public int Invoice_Number { get; set; }
        public string Store_ID { get; set; }
        public string Override_Cashier_ID { get; set; }
        public int Exception_Type { get; set; }
        public string ItemNum { get; set; }
        public decimal Amount { get; set; }
        public decimal Quantity { get; set; }
        public string Reason_Code { get; set; }
        public int LineNum { get; set; }
    }
}
