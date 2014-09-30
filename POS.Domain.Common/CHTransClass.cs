using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
  public class CHTransClass
    {
        public string Store_ID  {get; set; }
        public string CheckNum   {get; set; }
        public string AcctNum   {get; set; }
        public string RoutNum   {get; set; }
        public int Trans_Number  {get; set; }
        public decimal Amount { get; set; }
        public int Trans_Type   {get; set; } 
        public string DLNumber   {get; set; }
        public string PhoneNum   {get; set; }
        public string DLStateCode   {get; set; }
        public string TroutD   {get; set; }
        public int  eCheck   {get; set; }
        public int Sub_Invoice_Number   {get; set; } 
        public int BatchNumber   {get; set; } 
        public int BatchRecordNumber   {get; set; } 
        public int SequenceNumber   {get; set; } 
        public string Approval   {get; set; }
        public string TransType   {get; set; }
        public int Settlement_Status   {get; set; } 
        public string ErrorMessage  {get; set; }
        public string TerminalNumber   {get; set; }
        public DateTime DateTime {get; set; }
        public decimal CheckRetrunFee {get; set; }
        public int CheckType   {get; set; } 
        public string CheckReturnNotes {get; set; }
    }
}
