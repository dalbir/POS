using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class User_DefinedClass: BaseDomain
    {
        public string Store_ID { get; set; }
        public string UD_ID { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Type2 { get; set; }
        public string Type3 { get; set; }
        public int RowID { get; set; }   
    }
}
