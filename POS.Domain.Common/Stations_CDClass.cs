
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Stations_CDClass
    {
        public string Station_ID { get; set; }
        public string Store_ID { get; set; }
        public string CDL { get; set; }
        public int Occupied { get; set; }
        public string CD_Name { get; set; }
        public int PrinterPos { get; set; }
    }
}
