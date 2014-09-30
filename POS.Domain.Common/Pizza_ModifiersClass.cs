using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Pizza_ModifiersClass
    {
        public string PizzaItemNum { get; set; }
        public string ModifierItemNum { get; set; }
        public string Store_ID { get; set; }
        public int PizzaRegion { get; set; }
    }
}
