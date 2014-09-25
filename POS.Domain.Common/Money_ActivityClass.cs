using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Money_ActivityClass
    {
        public int Index { get; set; }
        public string Store_ID { get; set; }
        public int TransactionNumber { get; set; }
        public int PaymentType { get; set; }
        public DateTime DateTime { get; set; }
        public int TransactionType { get; set; }
        public string Cashier_ID { get; set; }
        public decimal Amount { get; set; }
        public float CurrentConversionRate { get; set; }
        public int SubInvoiceNumber { get; set; }
        public int ReferenceNumber { get; set; }
        public decimal TenderAmount { get; set; }
        public string Station_ID { get; set; }
        public decimal FleetCardAmount { get; set; }
        public int IsRefundable { get; set; }
    }
}
