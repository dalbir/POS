using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class ShiftsMediaTypesClass
    {
        public string RowID { get; set; }
        public int MediaType { get; set; }
        public decimal MediaTotal { get; set; }
        public int NumSales { get; set; }
        public decimal Payouts { get; set; }
        public decimal SafeDrops { get; set; }
        public decimal TipsCollected { get; set; }
        public string Store_ID { get; set; }
        public decimal Cashback { get; set; } 
    }
}
