using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Gift_CardsClass
    {
        public string Card_ID { get; set; }
        public decimal Balance { get; set; }
        public string CustNum { get; set; }
        public DateTime Open_Date { get; set; }
        public DateTime Exp_Date { get; set; }
        public int Dirty { get; set; }
        public decimal OldStyleAmt { get; set; }
        public int CardOrSlip { get; set; } 
    }
}
