using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class Inventory_ReferenceClass: BaseDomain
    {
        public int ID { get; set; }
        public string ItemNum { get; set; }
        public string Store_ID { get; set; }
    }
}
