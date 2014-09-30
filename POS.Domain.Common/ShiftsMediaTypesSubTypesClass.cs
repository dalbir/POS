using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class ShiftsMediaTypesSubTypesClass
    {
        public string RowID { get; set; }
        public int MediaType { get; set; }
        public string MediaSubType { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal NumSales { get; set; }
    }
}
