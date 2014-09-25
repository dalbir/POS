using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class CustomerGiftRegistryClass
    {
        public string Registry_ID { get; set; }
        public string CustNum { get; set; }
        public string Description { get; set; }
        public DateTime Event_Date { get; set; }
        public string Date_Created { get; set; }
        public int Dirty { get; set; }
    }
}
