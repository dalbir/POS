using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class CardPaymentBatchesClass
    {
        public string Store_ID { get; set; }
        public int BatchNumber { get; set; }
        public string ApprovalNumber { get; set; }
        public int BatchTransactionCount { get; set; }
        public decimal BatchTransactionAmount { get; set; }
        public string TerminalNumber { get; set; }
        public DateTime varDatetime { get; set; }
        public int Settlement_Status { get; set; }
        public int RowID { get; set; }
    }
}
