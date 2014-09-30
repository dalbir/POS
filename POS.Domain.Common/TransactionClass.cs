using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class TransactionClass
    {
        public int Trans_ID { get; set; }
        public DateTime DateTime { get; set; }
        public string Cashier_ID { get; set; }
        public string CustNum { get; set; }
        public string Trans_Type { get; set; }
        public decimal Prev_Cust_Balance { get; set; }
        public decimal Prev_Inv_Balance { get; set; }
        public decimal Trans_Amount { get; set; }
        public string Payment_Method { get; set; }
        public string Payment_Info { get; set; }
        public string Description { get; set; }
        public int Invoice_Number { get; set; }
        public string Store_ID { get; set; }
        public int Dirty { get; set; }
        public string Station_ID { get; set; }
        public int Payment_Type { get; set; }
        public decimal AmountRemaining { get; set; }
    }
}
