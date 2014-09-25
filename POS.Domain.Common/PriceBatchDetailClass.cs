using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class PriceBatchDetailClass
    {
        public int BatchID { get; set; }
        public int DetailID { get; set; }
        public string Identifier { get; set; }
        public int IdentifierType { get; set; }
        public int PriceChangeType { get; set; }
        public decimal Amount { get; set; }
        public int ApplicationMethod { get; set; }
        public decimal Quantity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}
