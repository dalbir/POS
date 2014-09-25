using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Modifier_Groups_SubModsClass
    {
        public string ID { get; set; }
        public string Store_ID { get; set; }
        public string Caption { get; set; }
        public string Quan_Modifier { get; set; }
        public string Price_Modifier { get; set; }
        public int Index { get; set; } 
    }
}
