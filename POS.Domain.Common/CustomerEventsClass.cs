using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class CustomerEventsClass
    {
        public string CustNum { get; set; }
        public DateTime Event_Date { get; set; }
        public string Event_Desc { get; set; }
        public int Dirty { get; set; }
    }
}
