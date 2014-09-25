using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;
using System.Data;

namespace POS.Domain.Common
{
  public class Inventory_SKUSClass: BaseDomain
    {
        public string Store_ID { get; set; }
        public string ItemNum { get; set; }
        public string AltSKU { get; set; }
      //
        public string quryFlage { get; set; }
        public string lisBoxValue { get; set; }
        public DataTable dtSku { get; set; }
    }
}
