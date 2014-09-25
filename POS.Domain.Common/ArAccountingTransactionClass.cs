using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common.ARAccountingTransaction
{
   public class ArAccountingTransactionClass
    {
        public string Store_ID { get; set; }
        public int Trans_ID { get; set; }
        public string Txn_Id { get; set; }
        public string EditSequence { get; set; }
    }
}
