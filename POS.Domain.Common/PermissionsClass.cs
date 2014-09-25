using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class PermissionsClass
    {
        public int PermissionID { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int PermissionType { get; set; }
        public int Category { get; set; }
    }
}
