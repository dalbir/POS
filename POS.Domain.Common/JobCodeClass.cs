using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class JobCodeClass: BaseDomain
    {
        public string JobCodeID { get; set; }
        public int AccessToPos { get; set; }
        public int Print_DDR { get; set; }
        public int DDR_Num_Copies { get; set; }
        public string Picture { get; set; }
        public int Prompt_Cash_Tips { get; set; }
        public int Record_Cash_Bank { get; set; }
        public decimal Default_Wage { get; set; }
        public int DDR_CC_Itemize { get; set; }
        public int Require_CD_Select { get; set; }
        public int Require_Clockout_CashBreakdown { get; set; }
        public decimal Default_OvertimeWage { get; set; }
        public int AccessToDonationCenter { get; set; }
        public int AccessToProductionSoftware { get; set; }
        public int DeliveryTracking { get; set; }
        public int RoleVisibility { get; set; }
        public string JobCodeName { get; set; }
    }
}
