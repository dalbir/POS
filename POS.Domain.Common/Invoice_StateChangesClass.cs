using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Invoice_StateChangesClass
    {
        public int Invoice_Number { get; set; }
        public string Store_ID { get; set; }
        public DateTime DateTime { get; set; }
        public int State { get; set; }
    }
}
