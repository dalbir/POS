using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class Inventory_TagAlongsClass: BaseDomain
    {
        public string ItemNum { get; set; }
        public string Store_ID { get; set; }
        public string TagAlong_ItemNum { get; set; }
        public decimal Quantity { get; set; }
        public string quryFlage { get; set; }
        public string listBoxValueTag { get; set; }

    }
}
