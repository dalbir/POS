using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Invoice_AccountingExportClass
    {
        public string Store_ID { get; set; }
        public int Invoice_Number { get; set; }
        public int SubType { get; set; }
        public string Txn_Id { get; set; }
        public string EditSequence { get; set; }
        public int TaxType { get; set; }
        public int Invoice_Type { get; set; }
    }
}
