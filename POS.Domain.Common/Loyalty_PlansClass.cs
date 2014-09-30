using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Loyalty_PlansClass
    {
        public int Loyalty_Plan_ID { get; set; }
        public string Description { get; set; }
        public int Accumulate_Points { get; set; }
    }
}
