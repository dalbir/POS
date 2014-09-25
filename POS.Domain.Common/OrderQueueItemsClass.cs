using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class OrderQueueItemsClass
    {
        public string StoreID { get; set; }
        public string StationID { get; set; }
        public string QueueID { get; set; }
        public string ObjectID { get; set; }
        public string Quantity { get; set; }
    }
}
