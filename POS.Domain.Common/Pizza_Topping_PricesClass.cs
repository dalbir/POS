using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
    class Pizza_Topping_PricesClass
    {
        public string ToppingItemNum { get; set; }
        public string SizeItemNum { get; set; }
        public string Store_ID { get; set; }
        public float Price { get; set; }
    }
}
