using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Base;

namespace POS.Domain.Common
{
   public class InventoryClass: BaseDomain
    {
        public string ItemNum { get; set; }
        public string ItemName { get; set; }
        public string Store_ID { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal Retail_Price { get; set; }
        public decimal In_Stock { get; set; }
        public double Reorder_Level { get; set; }
        public double Reorder_Quantity { get; set; }
        public int Tax_1 { get; set; }
        public int Tax_2 { get; set; }
        public int Tax_3 { get; set; }
        public string Vendor_Number { get; set; }
        public string Dept_ID { get; set; }
        public int IsKit { get; set; }
        public int IsModifier { get; set; }
        public double Kit_Override { get; set; }
        public int Inv_Num_Barcode_Labels { get; set; }
        public int Use_Serial_Numbers { get; set; }
        public int Num_Bonus_Points { get; set; }
        public int IsRental { get; set; }
        public int Use_Bulk_Pricing { get; set; }
        public int Print_Ticket { get; set; }
        public int Print_Voucher { get; set; }
        public int Num_Days_Valid { get; set; }
        public int IsMatrixItem { get; set; }
        public string Vendor_Part_Num { get; set; }
        public string Location { get; set; }
        public int AutoWeigh { get; set; }
        public int numBoxes { get; set; }
        public int Dirty { get; set; }
        public string Tear { get; set; }
        public int NumPerCase { get; set; }
        public int FoodStampable { get; set; }
        public decimal ReOrder_Cost { get; set; }
        public string Helper_ItemNum { get; set; }
        public string ItemName_Extra { get; set; }
        public int Exclude_Acct_Limit { get; set; }
        public int Check_ID { get; set; }
        public decimal Old_InStock { get; set; }
        public DateTime Date_Created { get; set; }
        public int ItemType { get; set; }
        public int Prompt_Price { get; set; }
        public int Prompt_Quantity { get; set; }
        public int Inactive { get; set; }
        public int Allow_BuyBack { get; set; }
        public DateTime Last_Sold { get; set; }
        public string Unit_Type { get; set; }
        public double Unit_Size { get; set; }
        public decimal Fixed_Tax { get; set; }
        public decimal DOB { get; set; }
        public int Special_Permission { get; set; }
        public int Prompt_Description { get; set; }
        public int Check_ID2 { get; set; }
        public int Count_This_Item { get; set; }
        public double Transfer_Cost_Markup { get; set; }
        public int Print_On_Receipt { get; set; }
        public int Transfer_Markup_Enabled { get; set; }
        public int As_Is { get; set; }
        public int InStock_Committed { get; set; }
        public int RequireCustomer { get; set; }
        public int PromptCompletionDate { get; set; }
        public int PromptInvoiceNotes { get; set; }
        public decimal Prompt_DescriptionOverDollarAmt { get; set; }
        public int Exclude_From_Loyalty { get; set; }
        public int BarTaxInclusive { get; set; }
        public int ScaleSingleDeduct { get; set; }
        public string GLNumber { get; set; }
        public int ModifierType { get; set; }
        public int Position { get; set; }
        public double numberOfFreeToppings { get; set; }
        public int ScaleItemType { get; set; }
        public int DiscountType { get; set; }
        public int AllowReturns { get; set; }
        public decimal SuggestedDeposit { get; set; }
        public int Liability { get; set; }
        public int IsDeleted { get; set; }
        public int ItemLocale { get; set; }
        public decimal QuantityRequired { get; set; }
        public int AllowOnDepositInvoices { get; set; }
        public double Import_Markup { get; set; }
        public decimal PricePerMeasure { get; set; }
        public float UnitMeasure { get; set; }
        public string ShipCompliantProductType { get; set; }
        public double AlcoholContent { get; set; }
        public int AvailableOnline { get; set; }
        public int AllowOnFleetCard { get; set; }
        public int DoughnutTax { get; set; }
        public int DisplayTaxInPrice { get; set; }
        public int NeverPrintInKitchen { get; set; }
        public string dptFlage { get; set; }
        public DataTable dtDeptCmb { get; set; }

       //
        public string qryType { get; set; }
        public string Cat_id { get; set; }
       
    }
}
