using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Finance_ChargesClass
    {
        public int ID { get; set; }
        public string Store_ID { get; set; }
        public string Custnum { get; set; }
        public int Finance_Charge_Type { get; set; }
        public string Finance_Charge_Date { get; set; }
        public string Percentage_Applied { get; set; }
        public decimal Amount { get; set; }
        public int Invoice_Number { get; set; }
        public string Cashier_ID { get; set; }
    }
}
