using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Invoice_TotalsClass
    {
        public int Invoice_Number { get; set; }
        public string Store_ID { get; set; }
        public string CustNum { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Total_Cost { get; set; }
        public string Discount { get; set; }
        public decimal Total_Price { get; set; }
        public decimal Total_Tax1 { get; set; }
        public decimal Total_Tax2 { get; set; }
        public decimal Total_Tax3 { get; set; }
        public decimal Grand_Total { get; set; }
        public decimal Amt_Tendered { get; set; }
        public decimal Amt_Change { get; set; }
        public int ShipToUsed { get; set; }
        public int InvoiceNotesUsed { get; set; }
        public string Status { get; set; }
        public string Cashier_ID { get; set; }
        public string Station_ID { get; set; }
        public string Payment_Method { get; set; }
        public decimal Acct_Balance_Due { get; set; }
        public DateTime Acct_FullyPaid_Date { get; set; }
        public int Taxed_1 { get; set; }
        public decimal Taxed_Sales { get; set; }
        public decimal NonTaxed_Sales { get; set; }
        public decimal Tax_Exempt_Sales { get; set; }
        public decimal CA_Amount { get; set; }
        public decimal CH_Amount { get; set; }
        public decimal CC_Amount { get; set; }
        public decimal OA_Amount { get; set; }
        public decimal GC_Amount { get; set; }
        public decimal Tip_Amount { get; set; }
        public decimal Old_Balance { get; set; }
        public int Num_People_Party { get; set; }
        public decimal AcctBalanceBefore { get; set; }
        public string Salesperson { get; set; }
        public int Dirty { get; set; }
        public string Zip_Code { get; set; }
        public string InvType { get; set; }
        public decimal FS_Amount { get; set; }
        public decimal Amt_FS_AmtTend { get; set; }
        public decimal Amt_FS_Change { get; set; }
        public string DC_Amount { get; set; }
        public decimal OA_Amount_Limited { get; set; }
        public int Cost_Center_Index { get; set; }
        public string Orig_OnHoldID { get; set; }
        public decimal Total_FixedTax { get; set; }
        public decimal Total_GC_Sold { get; set; }
        public int Tax_Rate_ID { get; set; }
        public int Tax_Rate1_Percent { get; set; }
        public decimal Amt_CA_Sec { get; set; }
        public string Exchange_Rate { get; set; }
        public int IsLayaway { get; set; }
        public decimal Amt_Deposit { get; set; }
        public decimal LAY_Amount { get; set; }
        public decimal Total_GC_Free { get; set; }
        public int MacromatixSyncStatus { get; set; }
        public decimal TotalLiability { get; set; }
        public int ReferenceInvoiceNumber { get; set; }
        public string CourseOrderingProgress { get; set; }
        public decimal Amt_CA_Sec_Tendered { get; set; }
        public string OnlineOrderID { get; set; }
        public int OrderSource { get; set; }
        public decimal OP_Amount { get; set; }
        public decimal MP_Amount { get; set; }
        public int TaxCategory { get; set; }
        public decimal MPDiscount_Amount { get; set; }
        public decimal Donation_Amount { get; set; }
        public decimal Total_UndiscountedSale { get; set; }
    }
}
