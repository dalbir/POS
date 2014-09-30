using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class EndOfDayCustomTotalsSetupClass
    {
        public string Store_ID { get; set; }
        public string Description { get; set; }
        public string GLNumber { get; set; }
        public string GLNumberOffset { get; set; }
        public int Enabled { get; set; }
    }
}
