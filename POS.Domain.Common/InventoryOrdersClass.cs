using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class InventoryOrdersClass
    {
        public int RowID { get; set; }
        public string OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderedBy { get; set; }
        public string CreationLocation { get; set; }
        public int OrderType { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public string OrderCounter { get; set; }
    }
}
