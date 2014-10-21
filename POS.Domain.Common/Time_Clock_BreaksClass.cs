using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class Time_Clock_BreaksClass: BaseDomain
    {
        public int ID { get; set; }
        public string Store_ID { get; set; }
        public DateTime BreakStartDateTime { get; set; }
        public DateTime BreakEndDateTime { get; set; }
        public int NumMinutesBreak { get; set; }
        public string Description { get; set; }
        public int GUIDident { get; set; }
        public int Paid { get; set; }  
 
       //
        public string updateColumn { get; set; }
        public DateTime updateValeDate { get; set; }
        public string whereColumn { get; set; }
        public DateTime whereColumnValue { get; set; }

    }
}
