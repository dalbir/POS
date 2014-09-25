using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
    class Invoice_Totals_PropertiesClass
    {
        public string Store_ID { get; set; }
        public int Invoice_Number { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
