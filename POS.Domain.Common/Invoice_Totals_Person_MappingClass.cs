using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Invoice_Totals_Person_MappingClass
    {
        public int Invoice_Number { get; set; }
        public string Store_ID { get; set; }
        public int SeatNum { get; set; }
    }
}
