using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Groups_DimensionsClass
    {
        public string Store_ID { get; set; }
        public string Group_ID { get; set; }
        public string Dimension { get; set; }
        public int IndexPos { get; set; }
        public string XY { get; set; }
    }
}
