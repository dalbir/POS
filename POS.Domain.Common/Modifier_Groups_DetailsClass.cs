using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Modifier_Groups_DetailsClass
    {
        public string ID { get; set; }
        public string Store_ID { get; set; }
        public string ItemNum { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public int Index { get; set; }
    }
}
