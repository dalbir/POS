using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class Inventory_Coupon_RulesClass: BaseDomain
    {
        public string Store_ID { get; set; }
        public string ItemNum { get; set; }
        public int Type { get; set; }
        public string ID { get; set; }
        public int Allow_Or_Disallow { get; set; }

       //
        public string qruFlage { get; set; }
    }
}
