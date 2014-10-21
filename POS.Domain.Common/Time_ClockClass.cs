using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
  public  class Time_ClockClass: BaseDomain
    {
        public int ID { get; set; }
        public string Store_ID { get; set; }
        public string Cashier_ID { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int NumMinutes { get; set; }
        public decimal Wages { get; set; }
        public decimal Taxes { get; set; }
        public decimal Tips { get; set; }
        public string Status { get; set; }
        public int Dirty { get; set; }
        public decimal Hourly_Wage { get; set; }
        public string JobCodeID { get; set; }
        public decimal Drawer_Start { get; set; }
        public decimal Drawer_End { get; set; }
        public decimal Drawer_OverShort { get; set; }
        public decimal Total_Cash_Sales { get; set; }
        public decimal Total_Cash_AR_Payments { get; set; }
        public decimal Total_Cash_Payouts { get; set; }
        public decimal Credit_Tips_Earned { get; set; }
        public decimal Credit_Tips_Taken { get; set; }
        public decimal Total_Sales { get; set; }
        public decimal Total_Voids { get; set; }
        public decimal Total_CC_Sales { get; set; }
        public decimal Total_CH_Sales { get; set; }
        public decimal Total_Cash_Pickups { get; set; }
        public decimal Total_Drawer_Transfers { get; set; }
        public decimal Total_Found_Money { get; set; }
        public decimal Cashier_Specific_Sales { get; set; }
        public string EmergencyOverrideID { get; set; }
        public decimal OvertimeHourly_Wage { get; set; }
        public decimal OvertimeWagesEarned { get; set; }
        public decimal Total_ECheck_Sales { get; set; }
        public int State { get; set; }
        public DateTime Last_Delivery { get; set; }
        public decimal Total_GC_Payments { get; set; }
        public string ClockOutStation_ID { get; set; }
        public int NumMinutesBreakUnpaid { get; set; }
        public int NumMinutesBreakPaid { get; set; }
        public decimal NonAppliedGratuityCashTips { get; set; }
        public decimal CashbackAmount { get; set; }
        public decimal Total_DC_Sales { get; set; }
        public decimal Total_FS_Sales { get; set; }
        public decimal Total_Cash_Layaway_Payments { get; set; }
        public decimal Drawer_End_SecCurr { get; set; }
        public decimal Total_SecCurr_Sales { get; set; }
        public decimal Credit_Tips_Withheld { get; set; }
        public decimal Total_MP_Sales { get; set; }
        public decimal Total_MPDiscount_Sales { get; set; } 
 
      //
        public string updateColumn { get; set; }
        public DateTime updateValeDate { get; set; }
    }
}
