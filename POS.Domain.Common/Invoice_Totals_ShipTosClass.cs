using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Invoice_Totals_ShipTosClass
    {
        public int Invoice_Number { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Company { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip_Code { get; set; }
        public string Phone { get; set; }
        public int Dirty { get; set; }
        public string County { get; set; }
        public string Store_ID { get; set; }
        public string ReferenceCustNum { get; set; }
        public string Email { get; set; }
        public string DeliveryAddressSpecialInstructions { get; set; }
    }
}
