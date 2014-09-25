using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common.ARSignature
{
   public class ArSignatureClass
    {
        public string Store_ID { get; set; }
        public int Trans_ID { get; set; }
        public string Signature { get; set; }
        public int LineNum { get; set; }
        public int Index { get; set; }
    }
}
