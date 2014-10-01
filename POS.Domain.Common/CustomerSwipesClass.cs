using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class CustomerSwipesClass:BaseDomain
    {
        public string CustNum { get; set; }
        public string Swipe_ID { get; set; }
        public string flage { get; set; }
    }
}
