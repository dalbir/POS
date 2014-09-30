using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class OrderQueueSummaryClass
    {
        public string StoreID { get; set; }
        public string StationID { get; set; }
        public int QueueID { get; set; }
        public int Accepted { get; set; }
        public DateTime DueDateTime { get; set; }
        public int HasProblems { get; set; }
        public int InvoiceNumber { get; set; }
        public string Notes { get; set; }
        public DateTime QueuedDateTime { get; set; }
        public int OrderType { get; set; }
        public int SendCopyNow { get; set; }
        public int Visible { get; set; }
        public int ParentQueueID { get; set; } 
    }
}
