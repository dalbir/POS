using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Inventory_PendingOrdersClass
    {
        public string ItemNum { get; set; }
        public string Store_ID { get; set; }
        public DateTime DueDate { get; set; }
        public int PickupType { get; set; }
        public int Status { get; set; }
        public int Invoice_Number { get; set; }
        public int LineNum { get; set; }
    }
}
