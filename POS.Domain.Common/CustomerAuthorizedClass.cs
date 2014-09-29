using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class CustomerAuthorizedClass:BaseDomain
    {
        public string CustNum { get; set; }
        public string Member { get; set; }
        public int  Dirty { get; set; }
        public string flage { get; set; }
    }
}
