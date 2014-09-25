using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class Tax_Rate_AreasClass: BaseDomain
    {
        public int Tax_Rate_ID { get; set; }
        public string Area { get; set; }
        public string Description { get; set; }
        public double Percent1 { get; set; }
        public double Percent2 { get; set; }
        public double Percent3 { get; set; }  
    }
}
