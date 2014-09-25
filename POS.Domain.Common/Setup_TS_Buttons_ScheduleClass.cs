using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Setup_TS_Buttons_ScheduleClass
    {
        public string Store_ID { get; set; }
        public string Station_ID { get; set; }
        public int ScheduleIndex { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public int IsHoliday { get; set; }
        public int UseDateRange { get; set; }
    }
}
