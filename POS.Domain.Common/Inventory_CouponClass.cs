using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class Inventory_CouponClass: BaseDomain
    {
        public string Store_ID { get; set; }
        public string ItemNum { get; set; }
        public DateTime Exp_Date { get; set; }
        public int Enforce_Exp { get; set; }
        public int Include_All_Except { get; set; }
        public int Coupon_Flat_Percent { get; set; }
        public int Coupon_Bonus_Only { get; set; }
        public int Apply_To_Parent { get; set; }
        public int Suppress_Bonus { get; set; }
        public double Minimum_Amount_Restriction { get; set; }
        public int NumDays_Restriction { get; set; }
        public int ApplyOnDiscountedItems { get; set; }
        public int ApplyOnSpecialPricing { get; set; }

       //
        public string qruyFalge { get; set; }

    }
}
