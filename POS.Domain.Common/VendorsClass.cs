using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class VendorsClass: BaseDomain
    {
        public string Vendor_Number { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Company { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip_Code { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Vendor_Tax_ID { get; set; }
        public string Vendor_Terms { get; set; }
        public string SSN { get; set; }
        public decimal Commission { get; set; }
        public decimal Rent { get; set; }
        public int Dirty { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public decimal Minimum_Order { get; set; }
        public int Default_Ordering_Mode { get; set; }
        public string Default_Billable_Department { get; set; }
        public int Default_PO_Delivery { get; set; }

       //
        public DataTable dtVendor { get; set; }
        public string quryFlage { get; set; }
        public DataTable dtAllVendor { get; set; }
    }
}
