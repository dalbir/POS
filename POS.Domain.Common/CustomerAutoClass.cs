using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class CustomerAutoClass:BaseDomain
    {
        public string CustNum { get; set; }
        public string License { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string flage { get; set; }
    }
}
