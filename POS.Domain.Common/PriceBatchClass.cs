using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class PriceBatchClass
    {
        public int BatchID { get; set; }
        public DateTime BatchCreateDate { get; set; }
        public int CreationLocation { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
