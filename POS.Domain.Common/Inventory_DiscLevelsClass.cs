using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class Inventory_DiscLevelsClass: BaseDomain
    {
        public string Store_ID { get; set; }
        public string ItemNum { get; set; }
        public string Level { get; set; }
        public double Perc { get; set; }

       //
        public string qFlage { get; set; }
    }
}
