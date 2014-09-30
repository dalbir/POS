using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class PropertiesClas
    {
        public string Store_ID { get; set; }
        public int Property_ID { get; set; }
        public string Description { get; set; }
        public int AllowCustomer { get; set; }
        public int AllowInventory { get; set; }
    }
}
