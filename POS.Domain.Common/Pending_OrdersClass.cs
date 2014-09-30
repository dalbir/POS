using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Pending_OrdersClass
    {
        public string Area { get; set; }
        public DateTime Time_Started { get; set; }
        public int Invoice_Number { get; set; }
        public string Station_ID { get; set; }
        public string Store_ID { get; set; }
        public string Cashier_ID { get; set; }
        public string OnHoldID { get; set; }
        public int Status { get; set; }
        public int Completed { get; set; }
    }
}
