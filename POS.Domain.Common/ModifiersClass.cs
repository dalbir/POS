using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class ModifiersClass: BaseDomain
    {
        public string ItemNum { get; set; }
        public string Store_ID { get; set; }
        public string ModNum { get; set; }
        public string ModName { get; set; }
        public string Dirty { get; set; }
        public int Group_Or_Individual { get; set; }
        public int ChargePrice { get; set; }
        public string NumToSelect { get; set; }
        public string Prompt { get; set; }
        public int Index { get; set; }
        public int Forced { get; set; }
        public int RowID { get; set; }

       //
        public string quryFlage { get; set; }
    }
}
