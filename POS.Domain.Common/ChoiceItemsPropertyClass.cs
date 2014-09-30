using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class ChoiceItemsPropertyClass: BaseDomain
    {
        public string Store_ID { get; set; }
        public string ItemNum { get; set; }
        public int Value_ID { get; set; }

       //
        public string quryFlage { get; set; }
    }
}
