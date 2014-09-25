using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class Inventory_OnSale_InfoClass: BaseDomain
    {
        public string ItemNum { get; set; }
        public string Store_ID { get; set; }
        public DateTime Sale_Start { get; set; }
        public DateTime Sale_End { get; set; }
        public double Percent { get; set; }
        public double Price { get; set; }
        public int SalePriceType { get; set; }

       //
        public string qurryFlage { get; set; }
    }
}
