using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Invoice_Totals_TaxExemptClass
    {
        public int Invoice_Number { get; set; }
        public string Store_ID { get; set; }
        public int ExemptOnTheFly { get; set; }
        public string LicenseNum { get; set; }
        public string LicenseStateCode { get; set; }
        public DateTime LicenseExpDate { get; set; }
        public string TaxID { get; set; }
    }
}
