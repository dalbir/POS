using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Payment_Processing_ConfigClass
    {
        public string Store_ID { get; set; }
        public string Station_ID { get; set; }
        public int PaymentMethod { get; set; }
        public string ClassAssemblyName { get; set; }
        public string PrimaryUrl { get; set; }
        public string SecondaryUrl { get; set; }
        public string MerchantNumber { get; set; }
        public string ClientNumber { get; set; }
        public string TerminalNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ProcessingCompany { get; set; }
        public string PortNumber { get; set; }
        public string FilePath { get; set; }
        public string UserFriendlyName { get; set; }
        public int TimeOut { get; set; }
        public int Require_Cvv2 { get; set; }
        public int Process_Offline { get; set; }
        public int IsCanadianDebitProcessor { get; set; }
        public int IsCheckNumberVerification { get; set; }
        public int IsCheckDriversLicenceVerification { get; set; }
        public int IsCheckAccountNumberVerification { get; set; }
        public int IsCheckFullMICRVerification { get; set; }
        public int IsCheckPhoneNumberVerification { get; set; }
        public int ProcessOffline { get; set; }
        public int DefaultMerchant { get; set; }
        public string SecondaryProcessingCompany { get; set; }
        public string SecondaryMerchantNumber { get; set; }
        public int CheckTransactionType { get; set; }
        public string PosID { get; set; }
        public string RoutingID { get; set; }
        public string AuthenticationCode { get; set; }
        public string AuthenticationFactor1 { get; set; }
        public string AuthenticationFactor2 { get; set; }
        public int ProcessDebitCardsUsingCreditProcessor { get; set; }
        public string SecondaryTerminalNumber { get; set; }
        public string AltMerchantNumber { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public string SecondaryPhoneNumber { get; set; }
        public int AVSType { get; set; }
        public int SupportsTrack11WithoutSentinel { get; set; }
        public int SupportsTokenization { get; set; }
        public int MobileBusinessType { get; set; }
        public int TimeoutForBackGroundChecking { get; set; }
        public int CaptureType { get; set; } 
    }
}
