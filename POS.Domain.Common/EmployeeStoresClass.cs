using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class EmployeeStoresClass
    {
        public int RowID { get; set; }
        public string Cashier_ID { get; set; }
        public string Store_ID { get; set; }
        public int Inactive { get; set; }
    }
}
