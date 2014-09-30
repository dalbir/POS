using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
   public class ShiftsClass
    {
        public decimal RowID { get; set; }
        public decimal ShiftID { get; set; }
        public decimal Store_ID { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public decimal IDUsed { get; set; }
        public decimal NetSalesTaxed { get; set; }
        public decimal NetSalesNonTaxed { get; set; }
        public decimal NetSalesTaxExempt { get; set; }
        public decimal Tax1 { get; set; }
        public decimal Tax2 { get; set; }
        public decimal Tax3 { get; set; }
        public decimal TaxOther { get; set; }
        public int TotalNumTrans { get; set; }
        public decimal Open_Cashier_ID { get; set; }
        public decimal Close_Cashier_ID { get; set; }
        public int Close_Out_Index { get; set; }
        public decimal CashbackAmount { get; set; } 
    }
}
