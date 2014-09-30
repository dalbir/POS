using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
  public  class Invoice_DeliveriesClass
    {
        public int Invoice_Number { get; set; }
        public string Store_ID { get; set; }
        public string Driver_ID { get; set; }
        public DateTime Time_Promised { get; set; }
    }
}
