using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Loyalty_Items_InclusionsClass
    {
        public string Loyalty_Item_ID { get; set; }
        public string Store_ID { get; set; }
        public string Inclusion_ID { get; set; }
        public int Inclusion_Type { get; set; }
    }
}
