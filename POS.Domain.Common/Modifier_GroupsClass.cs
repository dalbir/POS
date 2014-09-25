using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Modifier_GroupsClass
    {
        public string ID { get; set; }
        public string Store_ID { get; set; }
        public string Description { get; set; }
        public string Default_Prompt { get; set; }
        public int PrintOrder { get; set; }
    }
}
