using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class Inventory_MixNMatch_LevelsClass: BaseDomain
    {
        public string ItemNum { get; set; }
        public string Store_ID { get; set; }
        public double Amount { get; set; }
        public double Quantity { get; set; }

       //
       public string qryFlage{get; set;}
    }
}
