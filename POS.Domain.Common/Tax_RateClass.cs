using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;
using System.Data;

namespace POS.Domain.Common
{
   public class Tax_RateClass: BaseDomain
    {
        public string Store_ID { get; set; }
        public double Tax1_Rate { get; set; }
        public double Tax2_Rate { get; set; }
        public string Tax1_Name { get; set; }
        public string Tax2_Name { get; set; }
        public string Tax3_Name { get; set; }
        public string Tax4_Name { get; set; }
        public double Tax3_Rate { get; set; }
        public double Tax4_Rate { get; set; }
        public int Tax2OnTax1 { get; set; }
        public double Tax2Threshold { get; set; }
        public int Tax_3_Units { get; set; }
        public double Doughnut_Tax_Rate { get; set; }
        public float Doughnut_Tax_Rate_Threshold { get; set; }
        public double Tax1_Rate_Secondary { get; set; }
        public double Tax2_Rate_Secondary { get; set; }
        public double Tax3_Rate_Secondary { get; set; }
        public double Liter_Tax_Primary { get; set; }
        public double Liter_Tax_Secondary { get; set; }

       //
        public DataTable dtTaxRates { get; set; }
    }
}
