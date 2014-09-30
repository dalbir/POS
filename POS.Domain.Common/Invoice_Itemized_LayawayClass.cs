using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Invoice_Itemized_LayawayClass
    {
        public int Invoice_Number { get; set; }
        public int LineNum { get; set; }
        public string Store_ID { get; set; }
        public decimal Amount_Paid { get; set; }
        public int Picked_Up { get; set; }
        public DateTime Pickup_Date { get; set; }
    }
}
