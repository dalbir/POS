using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Mobile_TransClass
    {
        public string Store_ID { get; set; }
        public DateTime DateTime { get; set; }
        public int CRENumber { get; set; }
        public decimal Amount { get; set; }
        public decimal TipAmount { get; set; }
        public string TraceNumber { get; set; }
        public int SequenceNumber { get; set; }
        public string Token { get; set; }
        public int Sub_Invoice_Number { get; set; }
        public string CreType { get; set; }
        public string TransType { get; set; }
        public string CardType { get; set; }
        public string ResponseMessage { get; set; }
        public int QRCodeStatus { get; set; }
    }
}
