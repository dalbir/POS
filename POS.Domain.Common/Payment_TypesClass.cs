using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Payment_TypesClass
    {
        public int PaymentType { get; set; }
        public string Store_ID { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public int OpensCashDrawer { get; set; }
        public int NumReceipts { get; set; }
        public int PromptSignature { get; set; }
        public int PrimaryCurrency { get; set; }
        public float ConversionRate { get; set; }
        public int StoredBalance { get; set; }
        public int RequireID { get; set; }
        public int NumDaysIDValid { get; set; }
        public int Visible { get; set; }
        public int Processes { get; set; }
        public string ProcessType { get; set; }
        public int MediaType { get; set; }
        public int TaxExempt { get; set; }
        public int RequiresPinNumber { get; set; }
        public int RequiresCustomerSelection { get; set; }
        public string MerchantNumber { get; set; }
        public string Processor { get; set; }
        public string PaymentVerificationLocation { get; set; }
        public int RequiresPermission { get; set; }
    }
}
