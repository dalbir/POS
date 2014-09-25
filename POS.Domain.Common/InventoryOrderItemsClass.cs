using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class InventoryOrderItemsClass
    {
        public int RowID { get; set; }
        public string ItemNum { get; set; }
        public string ItemName { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal QtyOrdered { get; set; }
        public decimal QtyReceived { get; set; }
        public decimal QtyDamaged { get; set; }
        public decimal QtyLost { get; set; }
        public string CaseOrIndividual { get; set; }
        public int Status { get; set; }
        public string OrderItemCounter { get; set; }
        public int NumPerCase { get; set; }
        public int OrderRowID { get; set; } 
    }
}
