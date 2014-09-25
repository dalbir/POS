using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Tax_TableClass
    {
        public string Store_ID { get; set; }
        public int Tax_Rate { get; set; }
        public decimal Range_Start { get; set; }
        public decimal Range_End { get; set; }
        public decimal Amount { get; set; }  
    }
}
