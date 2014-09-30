using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Inventory_CommissionsClass
    {
        public string Store_ID { get; set; }
        public string ItemNum { get; set; }
        public int Comm_Type { get; set; }
        public decimal Comm_Amt { get; set; }
    }
}
