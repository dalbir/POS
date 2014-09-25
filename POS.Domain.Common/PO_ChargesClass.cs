using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class PO_ChargesClass
    {
        public int PO_Number { get; set; }
        public string Store_ID { get; set; }
        public int Index { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
