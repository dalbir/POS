using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Reports_SetupClass
    {
        public string Store_ID { get; set; }
        public int DDR_BD_PAYTYPES { get; set; }
        public int DDR_BD_DEPT { get; set; }
        public int DDR_BD_ITEMS_SOLD { get; set; }
        public int DDR_BD_AR_PAYTYPES { get; set; }
        public int DDR_Print_Costs { get; set; }
        public int DDR_ZOut { get; set; }
        public int DDR_Payouts { get; set; }
        public int DDR_Line_Disc { get; set; }
        public int DDR_Total_BuyBacks { get; set; }
        public int DDR_BD_Categories { get; set; }
        public int DDR_Performance { get; set; }
        public int Report_StartDate { get; set; }
        public int Report_EndDate { get; set; }
        public DateTime Report_StartTime { get; set; }
        public DateTime Report_EndTime { get; set; }
        public int DDR_BD_lncludeDiscountsInTotalItemPrice { get; set; }
    }
}
