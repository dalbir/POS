using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Inventory_MixNMatch_LevelsClass
    {
        public string ItemNum { get; set; }
        public string Store_ID { get; set; }
        public float Amount { get; set; }
        public decimal Quantity { get; set; }
    }
}
