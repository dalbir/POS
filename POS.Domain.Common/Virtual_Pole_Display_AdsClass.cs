using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Virtual_Pole_Display_AdsClass
    {
        public string Store_ID { get; set; }
        public int RowID { get; set; }
        public int ImageIndex { get; set; }
        public int AdType { get; set; }
        public string Location { get; set; } 
    }
}
