using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Invoice_SubCheck_PaymentsClass
    {
        public int Invoice_Number { get; set; }
        public string Store_ID { get; set; }
        public int SubCheckNum { get; set; }
        public string Payment_Method { get; set; }
        public decimal Amount { get; set; }
        public string Details { get; set; }
        public int InvoiceRefNum { get; set; }
        public int RowID { get; set; }
    }
}
