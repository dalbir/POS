using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class Inventory_VendorsClass: BaseDomain
    {
        public string ItemNum { get; set; }
        public string Store_ID { get; set; }
        public string Vendor_Number { get; set; }
        public double CostPer { get; set; }
        public double Case_Cost { get; set; }
        public double NumPerVenCase { get; set; }
        public string Vendor_Part_Num { get; set; }
        public string CubeCost { get; set; }
        public double WeightCost { get; set; }
        public int OverrideCommission { get; set; }
        public double LandedCost { get; set; }

       //
        public string qryFlage { get; set; }
    }
}
