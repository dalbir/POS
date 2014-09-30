using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class Inventory_PricesClass: BaseDomain
    {
        public string ItemNum { get; set; }
        public string Store_ID { get; set; }
        public double Price { get; set; }
        public string Criteria1 { get; set; }
        public string Criteria2 { get; set; }
        public string Criteria3 { get; set; }
        public int Enabled { get; set; }
        public int PriceType { get; set; }

       //
        public string quryFlage { get; set; }
    }
}
