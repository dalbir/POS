using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Inventory_BumpBarSettingsClass
    {
        public string Store_ID { get; set; }
        public string ItemNum { get; set; }
        public int Backcolor { get; set; }
        public int Forecolor { get; set; } 
    }
}
