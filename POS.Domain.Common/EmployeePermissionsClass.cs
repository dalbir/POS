using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class EmployeePermissionsClass
    {
        public string Cashier_ID { get; set; }
        public int PermissionID { get; set; }
        public int AccessLevel { get; set; }
        public int Exception { get; set; }
    }
}
