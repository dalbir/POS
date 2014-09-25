using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class Inventory_Bulk_InfoClass: BaseDomain
    {
        public string ItemNum { get; set; }
        public string Store_ID { get; set; }
        public double Bulk_Price { get; set; }
        public double Bulk_Quan { get; set; }
        public string Description { get; set; }
        public int Price_Type { get; set; }
       //
        public string quryFlg { get; set; }
    }
}
