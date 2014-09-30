using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Invoice_Itemized_Return_DetailsClass
    {
        public string Store_ID { get; set; }
        public int Invoice_Number { get; set; }
        public int LineNum { get; set; }
        public int Orig_Invoice_Number { get; set; }
        public string CustName { get; set; }
        public string Vendor_Number { get; set; }
        public string Reason_Code { get; set; }
        public int Dirty { get; set; }
        public int Orig_LineNum { get; set; }
        public string Cashier_ID { get; set; }
    }
}
