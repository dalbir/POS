using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Invoice_SubCheck_ItemsClass
    {
        public int Invoice_Number { get; set; }
        public string Store_ID { get; set; }
        public int SubCheckNum { get; set; }
        public int SubCheckLineNum { get; set; }
        public int LineNum { get; set; }
        public decimal Quantity { get; set; }
        public int IsModifier { get; set; }
    }
}
