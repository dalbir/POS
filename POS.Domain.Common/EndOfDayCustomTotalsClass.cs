using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class EndOfDayCustomTotalsClass
    {
        public string Store_ID { get; set; }
        public int Close_Out_Index { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
