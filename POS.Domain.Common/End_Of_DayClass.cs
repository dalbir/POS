using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class End_Of_DayClass
    {
        public string Store_ID { get; set; }
        public int Close_Out_Index { get; set; }
        public decimal Actual_Cash { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public decimal OverShort { get; set; }
        public string Cashier_ID { get; set; }
        public decimal Actual_C2 { get; set; }
        public decimal OverShort_C2 { get; set; } 
    }
}
