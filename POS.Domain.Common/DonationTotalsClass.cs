using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class DonationTotalsClass
    {
        public int Donation_Number { get; set; }
        public string Store_ID { get; set; }
        public string Station_ID { get; set; }
        public string Cashier_ID { get; set; }
        public DateTime varDateTime { get; set; }
        public decimal Total_Value { get; set; }
        public string Status { get; set; }
        public string CustNum { get; set; }
    }
}
