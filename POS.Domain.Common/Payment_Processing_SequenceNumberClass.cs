using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Payment_Processing_SequenceNumberClass
    {
        public string Station_ID { get; set; }
        public string Store_ID { get; set; }
        public string BatchNumber { get; set; }
        public string RecordNumber { get; set; }
    }
}
