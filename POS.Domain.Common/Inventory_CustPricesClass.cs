using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class Inventory_CustPricesClass: BaseDomain
    {
        public string Store_ID { get; set; }
        public string ItemNum { get; set; }
        public string CustNum { get; set; }
        public double Price { get; set; }
        public int Allow_Discounts { get; set; }

       //
        public string message { get; set; }

    }
}
