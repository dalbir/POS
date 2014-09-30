using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Invoice_Serial_SalesClass
    {
        public int Invoice_Number { get; set; }
        public int LineNum { get; set; }
        public string Store_ID { get; set; }
        public string ItemNum { get; set; }
        public string SerialNum { get; set; }
        public decimal Price { get; set; }
    }
}
