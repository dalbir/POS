using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class ARTransactionDtailsClass1
    {
        public int Trans_ID { get; set; }
        public int Invoice_Number { get; set; }
        public decimal Amount { get; set; }
        public decimal Prev_Inv_Balance { get; set; }
        public string Store_ID { get; set; }
        public string targetStore_ID { get; set; }
        public DateTime varDatetime { get; set; }
        public int ID { get; set; }
        public int PID { get; set; } 
    }
}
