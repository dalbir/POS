using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
  public  class Inventory_Accounting_TransactionClass
    {
        public string Store_ID { get; set; }
        public string Id { get; set; }
        public string Txn_Id { get; set; }
        public string EditSequence { get; set; }
    }
}
