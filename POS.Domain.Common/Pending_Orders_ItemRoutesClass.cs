using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Pending_Orders_ItemRoutesClass
    {
        public string ObjectID { get; set; }
        public string ParentObjectID { get; set; }
        public string Store_ID { get; set; }
        public int Location { get; set; }
        public int SequenceNumber { get; set; }
        public int Status { get; set; }
        public int RouteNumber { get; set; } 
    }
}
