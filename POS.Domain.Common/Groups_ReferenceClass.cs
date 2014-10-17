using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class Groups_ReferenceClass: BaseDomain
    {
        public int ID  {get; set; }
        public string Group_ID  {get; set; }
        public string Store_ID  {get; set; }

       //
        public string flage { get; set; }
    }
}
