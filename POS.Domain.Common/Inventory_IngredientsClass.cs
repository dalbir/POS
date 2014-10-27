using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class Inventory_IngredientsClass: BaseDomain
    {
        public string ItemNum { get; set; }
        public string Store_ID { get; set; }
        public string Ingredient { get; set; }
        public decimal Quantity { get; set; }
        public int Measurement { get; set; }
        public string Yield { get; set; }
    }
}
