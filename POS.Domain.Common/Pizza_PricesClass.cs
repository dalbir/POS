using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Pizza_PricesClass
    {
        public string PizzaItemNum { get; set; }
        public string SizeItemNum { get; set; }
        public string CrustItemNum { get; set; }
        public string Store_ID { get; set; }
        public decimal Price { get; set; }
    }
}
