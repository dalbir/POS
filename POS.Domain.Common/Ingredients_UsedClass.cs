using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
  public  class Ingredients_UsedClass
    {
        public int ID { get; set; }
        public string ItemNum { get; set; }
        public string Store_ID { get; set; }
        public decimal Quantity { get; set; }
        public string Reason { get; set; }
        public DateTime Date_Used { get; set; }
    }
}
