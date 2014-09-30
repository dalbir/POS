using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Property_ValuesClass
    {
        public string Store_ID { get; set; }
        public int Property_ID { get; set; }
        public int Value_ID { get; set; }
        public string Description { get; set; }
        public int PurchaseType { get; set; }
    }
}
