using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class Kit_IndexClass: BaseDomain
    {
        public string Kit_ID { get; set; }
        public string Store_ID { get; set; }
        public string ItemNum { get; set; }
        public double Discount { get; set; }
        public double Quantity { get; set; }
        public int Index { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int InvoiceMethodToUse { get; set; }
        public int ChoiceLockdown { get; set; }
        public string quryFlage { get; set; }
    }
}
