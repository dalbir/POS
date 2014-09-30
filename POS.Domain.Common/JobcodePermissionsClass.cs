using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class JobcodePermissionsClass
    {
        public int RowID { get; set; }
        public string JobCodeID { get; set; }
        public int PermissionID { get; set; }
        public int AccessLevel { get; set; }
        public int Exception { get; set; }
    }
}
