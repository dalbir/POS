using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Timesheet_Accounting_TransactionClass
    {
        public string Store_ID { get; set; }
        public int ID { get; set; }
        public string Txn_Id { get; set; }
        public string EditSequence { get; set; }
        public int Type { get; set; }
        public int SeqNo { get; set; }  
    }
}
