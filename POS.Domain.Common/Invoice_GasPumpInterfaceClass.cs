using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Invoice_GasPumpInterfaceClass
    {
        public int Invoice_Number { get; set; }
        public string Store_ID { get; set; }
        public int LineNum { get; set; }
        public string PumpNumber { get; set; }
        public string CarWashCode { get; set; }
        public string Payment_Method { get; set; }
        public int SaleType { get; set; }
        public string Note1 { get; set; }
        public int SpecialSaleType { get; set; }
        public string TransactionNumber { get; set; }
        public int RefInvoice_Number { get; set; }
        public int IsSaleComplete { get; set; }
        public decimal DollarAmount { get; set; }
    }
}
