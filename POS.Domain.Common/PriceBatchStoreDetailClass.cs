using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class PriceBatchStoreDetailClass
    {
        public int BatchID { get; set; }
        public int DetailID { get; set; }
        public string StoreID { get; set; }
        public int Accepted { get; set; }
        public int Overrided { get; set; }
        public decimal Amount { get; set; }
        public decimal Quantity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } 
    }
}
