using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class SubModifiersClass
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Store_ID { get; set; }
        public float PriceModifier { get; set; }
        public float QuantityModifier { get; set; }
        public int Position { get; set; }  
    }
}
