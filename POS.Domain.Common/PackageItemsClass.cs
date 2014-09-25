using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class PackageItemsClass
    {
        public int RowID { get; set; }
        public string ParentRowID { get; set; }
        public string ItemRowID { get; set; }
        public decimal QtyShipped { get; set; }
        public decimal QtyReceived { get; set; }
        public decimal QtyDamaged { get; set; }
        public decimal QtyLost { get; set; }
        public decimal Cost { get; set; }
    }
}
