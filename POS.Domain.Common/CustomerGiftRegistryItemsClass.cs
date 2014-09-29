using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class CustomerGiftRegistryItemsClass:BaseDomain
    {
        public string Registry_ID { get; set; }
        public string Store_ID { get; set; }
        public string ItemNum { get; set; }
        public decimal Quan_Req { get; set; }
        public decimal Quan_Purch { get; set; }
        public string flage { get; set; }
    }
}
