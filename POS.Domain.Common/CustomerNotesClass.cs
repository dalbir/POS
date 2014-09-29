using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class CustomerNotesClass:BaseDomain
    {
        public string CustNum { get; set; }
        public string Notes { get; set; }
        public string flage { get; set; }

    }
}
