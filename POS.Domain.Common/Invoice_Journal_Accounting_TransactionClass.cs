using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Invoice_Journal_Accounting_TransactionClass
    {
        public string Store_ID { get; set; }
        public DateTime Date { get; set; }
        public int SubType { get; set; }
        public string CustNo { get; set; }
        public string Journal_Txn_Id { get; set; }
        public string Journal_Edit_Seq { get; set; }
        public string Debit_Txn_LineId { get; set; }
        public string Credit_Txn_LineId { get; set; }
    }
}
