using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class Invoice_ItemizedClass
    {
        public int Invoice_Number  {get; set; }
        public int LineNum  {get; set; }
        public string ItemNum  {get; set; }
        public decimal Quantity  {get; set; }
        public decimal CostPer  {get; set; }
        public decimal PricePer  {get; set; }
        public decimal Tax1Per  {get; set; }
        public decimal Tax2Per  {get; set; }
        public decimal Tax3Per  {get; set; }
        public int Serial_Num  {get; set; } 
        public string Kit_ItemNum  {get; set; }
        public int BC_Invoice_Number  {get; set; } 
        public string LineDisc  {get; set; }
        public string DiffItemName  {get; set; }
        public int NumScans  {get; set; } 
        public int numBonus  {get; set; }
        public int Line_Tax_Exempt  {get; set; } 
        public decimal Commission  {get; set; }
        public string Store_ID  {get; set; } 
        public decimal origPricePer  {get; set; }
        public int Allow_Discounts  {get; set; } 
        public string Person  {get; set; }
        public int Sale_Type  {get; set; } 
        public string Ticket_Number  {get; set; }
        public int IsRental  {get; set; }
        public decimal FixedTaxPer  {get; set; }
        public decimal GC_Sold  {get; set; }
        public string Special_Price_Lock  {get; set; }
        public int As_Is  {get; set; } 
        public int Returned  {get; set; } 
        public decimal DOB  {get; set; } 
        public string UserDefined  {get; set; }
        public string Cashier_ID_Itemized  {get; set; }
        public int IsLayaway  {get; set; }
        public decimal ReturnedQuantity  {get; set; }
        public decimal GC_Free  {get; set; }
        public int ScaleItemType  {get; set; }
        public string ObjectID  {get; set; }
        public string ParentObjectID  {get; set; }
        public string BulkRate  {get; set; }
        public decimal SecurityDeposit  {get; set; }
        public decimal Liability  {get; set; }
        public decimal SalePricePer  {get; set; }
        public int Line_Tax_Exempt_2  {get; set; }
        public int Line_Tax_Exempt_3  {get; set; }
        public int modifierPriceLock  {get; set; }
        public string Salesperson  {get; set; }
        public int ComboApplied  {get; set; } 
        public decimal KitchenQuantityPrinted  {get; set; }
        public decimal PricePerBeforeDiscount  {get; set; }
        public int OrigPriceSetBy  {get; set; }
        public int PriceChangedBy  {get; set; }
        public decimal Kit_Override  {get; set; } 
        public decimal KitTotal  {get; set; }
    }
}
