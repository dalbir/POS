using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Vendor_Payout_Accounting_TransactionClass
    {
        public string Store_ID { get; set; }
        public string Vendor_Number { get; set; }
        public int Id { get; set; }
        public string Txn_Id { get; set; }
        public string EditSequence { get; set; }
        public string TxnLineId { get; set; }
    }
}
