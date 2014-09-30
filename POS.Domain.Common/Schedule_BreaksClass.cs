using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Schedule_BreaksClass
    {
        public int RowID { get; set; }
        public int ParentRowID { get; set; }
        public string Store_ID { get; set; }
        public string Reason { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; } 
    }
}
