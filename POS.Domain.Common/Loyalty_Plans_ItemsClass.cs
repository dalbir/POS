using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Loyalty_Plans_ItemsClass
    {
        public int Loyalty_Plan_ID { get; set; }
        public string Loyalty_Item_ID { get; set; }
        public int Index { get; set; }
        public int Exclusive { get; set; }
        public int Prompt_Award { get; set; }
        public int Override_Exclusive { get; set; } 
    }
}
