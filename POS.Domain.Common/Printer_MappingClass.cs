using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Printer_MappingClass
    {
        public string Station_ID { get; set; }
        public string Store_ID { get; set; }
        public string LocalPort { get; set; }
        public string NetworkPort { get; set; }
        public string PrinterName { get; set; }
        public string Details { get; set; }
        public int Disabled { get; set; }
        public int Two_Color_Printing { get; set; }
        public int CutReceipt { get; set; }
        public int LineFeedsBeforeCut { get; set; }
        public int PrintMasterSubordinate { get; set; }
    }
}
