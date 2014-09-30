using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Invoice_SubCheckClass
    {
        public int Invoice_Number { get; set; }
        public string Store_ID { get; set; }
        public int SubCheckNum { get; set; }
        public int Paid { get; set; }
        public decimal Total_Tax_1 { get; set; }
        public decimal Total_Tax_2 { get; set; }
        public decimal Total_Tax_3 { get; set; }
        public decimal Total_Price { get; set; }
        public decimal Total_Tip { get; set; }
        public decimal Total_GC_Sold { get; set; }
        public decimal Grand_Total { get; set; }
        public string SubCustNum { get; set; }
        public decimal Total_GC_Free { get; set; }
        public decimal Donation_Amount { get; set; }
    }
}
