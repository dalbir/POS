using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Gift_Card_TransClass
    {
        public int Trans_ID { get; set; }
        public string Store_ID { get; set; }
        public string Card_ID { get; set; }
        public string DateTimeStamp { get; set; }
        public int TransType { get; set; }
        public string Amt { get; set; }
        public int Invoice_Number { get; set; }
        public int Dirty { get; set; }
        public int LineNum { get; set; }
        public string TroutD { get; set; }
        public string Approval { get; set; }
        public string Reference { get; set; }
        public string VoucherText { get; set; }
        public string ReceiptText { get; set; }
        public string BatchNumber { get; set; }
        public string AdditionalInfo { get; set; }
        public string TerminalNumber { get; set; }
        public string OrderId { get; set; }
        public string CardDescription { get; set; }
        public int VoucherType { get; set; }
        public string Responsemessage { get; set; }
        public int ProcessingType { get; set; }
        public int CheckType { get; set; }
        public string CheckReturnNotes { get; set; }
        public decimal CheckRetrunFee { get; set; }
        public int IsPrePaidCard { get; set; }
        public int InitiatedByReturn { get; set; }
    }
}
