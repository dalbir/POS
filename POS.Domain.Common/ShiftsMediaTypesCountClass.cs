using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class ShiftsMediaTypesCountClass
    {
        public decimal RowID { get; set; }
        public decimal MediaType { get; set; }
        public decimal OpenAmount { get; set; }
        public decimal CloseAmount { get; set; }
        public decimal SuggestedOpenAmount { get; set; }
        public decimal OverShort { get; set; }
        public decimal Store_ID { get; set; } 
    }
}
