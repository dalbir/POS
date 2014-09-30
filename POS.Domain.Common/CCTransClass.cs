using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
  public  class CCTransClass
    {
        public string Store_ID { get; set; }
        public DateTime varDateTime { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public string TransType { get; set; }
        public string Expiration { get; set; }
        public decimal Amount { get; set; }
        public string Approval { get; set; }
        public string Reference { get; set; }
        public int CREType { get; set; }
        public int CRENumber { get; set; }
        public decimal TipAmount { get; set; }
        public int Sub_Invoice_Number { get; set; }
        public int CardType { get; set; }
        public int Tip_Applied { get; set; }
        public int Merchant { get; set; }
        public string TroutD { get; set; }
        public string PostAuthReferenceNumber { get; set; }
        public string OrderId { get; set; }
        public string ResponseMessage { get; set; }
        public int AccountType { get; set; }
        public string Language { get; set; }
        public string AppliedGratuity { get; set; }
        public string TruncatedCardNumber { get; set; }
        public int PaymentMethod { get; set; }
        public string CashBack { get; set; }
        public string TerminalNumber { get; set; }
        public int BatchNumber { get; set; }
        public int BatchRecordNumber { get; set; }
        public string ErrorMessage { get; set; }
        public string ACI { get; set; }
        public string VisaResponseCode { get; set; }
        public int CardEntrySource { get; set; }
        public string TraceNumber { get; set; }
        public int SequenceNumber { get; set; }
        public int IsPrePaidCard { get; set; }
        public decimal PreAuthAmount { get; set; }
        public int Settlement_Status { get; set; }
        public string VoucherNumber { get; set; }
        public string appLabel { get; set; }
        public string appPreferredName { get; set; }
        public string cardPlan { get; set; }
        public string emv_aid { get; set; }
        public string arqc_tvr { get; set; }
        public string arqc { get; set; }
        public string tc_acc_tvr { get; set; }
        public string tc_acc { get; set; }
        public string supplementalData { get; set; }
        public string cvm_Indicator { get; set; }
        public string ResponseMessage2 { get; set; }
        public string Token { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
    }
}
