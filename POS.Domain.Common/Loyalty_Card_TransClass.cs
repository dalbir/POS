using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Loyalty_Card_TransClass
    {
        public int Trans_ID { get; set; }
        public string Store_ID { get; set; }
        public string Card_ID { get; set; }
        public DateTime DateTimeStamp { get; set; }
        public int TransType { get; set; }
        public int Invoice_Number { get; set; }
        public int Dirty { get; set; }
        public decimal TotalAmt { get; set; }
        public string Approval { get; set; }
        public string Reference { get; set; }
        public decimal Price { get; set; }
        public int Units { get; set; }
        public int Points { get; set; }
    }
}
