using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class ExceptionsClass
    {
        public int ID { get; set; }
        public DateTime Exception_DateTime { get; set; }
        public string Store_ID { get; set; }
        public string Cashier_ID { get; set; }
        public string Override_Cashier_ID { get; set; }
        public int Exception_Type { get; set; }
        public string Reason_Code { get; set; }
        public string RowID { get; set; }
    }
}
