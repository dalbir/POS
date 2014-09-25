using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class DonationItemizedClass
    {
        public int Donation_Number { get; set; }
        public int Line_Number { get; set; }
        public string Store_ID { get; set; }
        public string ItemNum { get; set; }
        public int Quantity { get; set; }
        public decimal Value_Per { get; set; }
    }
}
