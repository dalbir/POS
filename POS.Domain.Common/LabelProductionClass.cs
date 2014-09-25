using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class LabelProductionClass
    {
        public int ID { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int LogEntryType { get; set; }
        public string Source { get; set; }
        public string Component { get; set; }
        public string LogEntry { get; set; }
    }
}
