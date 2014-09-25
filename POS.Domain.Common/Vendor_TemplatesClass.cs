using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Vendor_TemplatesClass
    {
        public int Template_ID { get; set; }
        public string Vendor_Number { get; set; }
        public string Template_Description { get; set; }
        public string Logo_Location { get; set; }
        public decimal Minimum_Order { get; set; }
    }
}
