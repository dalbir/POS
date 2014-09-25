using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
  public class Employee_PermExceptionsClass
    {
        public int Cashier_ID { get; set; }
        public int CFA_Setup_Company { get; set; }
        public int CFA_Setup_Tax { get; set; }
        public int CFA_Setup_Bonus { get; set; }
        public int CFA_Setup_Accounting { get; set; }
        public int CFA_Setup_Discounts { get; set; }
        public int CFA_Setup_Display { get; set; }
        public int CFA_Setup_DefPrinter { get; set; }
        public int CFA_Inven_Add { get; set; }
        public int CFA_Inven_Edit { get; set; }
        public int CFA_Vendors_Add { get; set; }
        public int CFA_Vendors_Edit { get; set; }
        public int CFA_Depts_Add { get; set; }
        public int CFA_Depts_Edit { get; set; }
        public int CFA_Inven_TickVouch { get; set; }
        public int CFA_Cust_Add { get; set; }
        public int CFA_Cust_Edit { get; set; }
        public int CFA_Reports_Display { get; set; }
        public int CFA_Reports_DDR { get; set; }
        public int CFA_Reports_Print { get; set; }
        public int CFA_Invoice_Discount { get; set; }
        public int CFA_Invoice_PriceChange { get; set; }
        public int CFA_Invoice_DeleteItems { get; set; }
        public int CFA_Invoice_Void { get; set; }
        public int CFA_CRE_Acct { get; set; }
        public int CFA_CRE_Exit { get; set; }
        public int CFA_Display_Balance { get; set; }
        public int CFA_Refund_Item { get; set; }
        public int CFA_Receive_Items { get; set; }
        public int CFA_DO_POS { get; set; }
        public int CFA_INSTANT_POS { get; set; }
        public int CFA_OTHER_TABLES { get; set; }
        public int CFA_ACCEPT_CASH { get; set; }
        public int CFA_TRANSFER_NOSWIPE { get; set; }
        public int CFA_ADD_CCTIPS { get; set; }
        public int CFA_PRINT_HOLD { get; set; }
        public int CFA_OPEN_CASH_DRAWER { get; set; }
        public int CFA_TRANSFER_TABLES { get; set; }
        public int CFA_SPLIT_CHECKS { get; set; }
        public int CFA_EXTRA_ITEM { get; set; }
        public int CFA_TAX_EXEMPT { get; set; }
        public int CFA_GC_Sell { get; set; }
        public int CFA_GC_Redeem { get; set; }
        public int CFA_SELL_SPECIAL_ITEM { get; set; }
        public int CFA_VENDOR_PAYOUT { get; set; }
        public int CFA_APPLY_GRATUITY { get; set; }
        public int CFA_BUYBACKS_TRADES { get; set; }
        public int CFA_CC_Force { get; set; }
        public int CFA_CC_BELOW_FLOOR { get; set; }
        public int CFA_CASH_ALERTS { get; set; }
        public int CFA_CASH_PICKUP { get; set; }
        public int CFA_ISSUE_CREDIT_SLIP { get; set; }
        public int CFA_REDEEM_CREDIT_SLIP { get; set; }
        public int CFA_REFUND_OVERRIDE { get; set; }
        public int CFA_DRAWER_TRANSFER { get; set; }
        public int CFA_LARGE_PURCHASES { get; set; }
        public int CFA_AUCTION_PHOTO { get; set; }
        public int CFA_AUCTION_LISTREDEEM { get; set; }
        public int CFA_AUCTION_SHIP { get; set; }
        public int CFA_APPROVE_CASHCOUNT { get; set; }
        public int CFA_APPROVE_OLD_RETURNS { get; set; }
        public int CFA_APPROVE_EMERGENCY_CLOCKOUT { get; set; }
        public int CFA_PULLBACK_INVOICE { get; set; }
        public int CFA_MANAGE_TIMECLOCK { get; set; }
        public int CFA_PERFORM_ENDOFDAY { get; set; }
        public int CFA_HOST_LOGIN { get; set; }
        public int CFA_REST_OPENTABS { get; set; }
        public int CFA_REST_TAKEOUT { get; set; }
        public int CFA_REST_DELIVERY { get; set; }
        public int CFA_INVOICE_DELETESENT { get; set; }
        public int CFA_INVEN_VIEW { get; set; }
        public int CFA_INVEN_VIEWCOST { get; set; }
        public int CFA_INVEN_NEGATIVE_INSTANTPOS { get; set; }
        public int CFA_ENDTRANS_CASH { get; set; }
        public int CFA_ENDTRANS_ACCOUNT { get; set; }
        public int CFA_REST_COMP { get; set; }
        public int CFA_CH_FORCE { get; set; }
        public int CFA_TS_CONFIG { get; set; }
        public int CFA_TRANSFER_SERVER { get; set; }
        public int CFA_BACKUP_DATABASE { get; set; }
        public int CFA_CREDIT_CARD_SETTLEMENT { get; set; }
        public int CFA_KITCHEN_REPRINT { get; set; }
        public int CFA_SETUP_RECEIPT_NOTES { get; set; }
        public int CFA_MANAGE_TIMECLOCK_OWNTIME { get; set; }
        public int CFA_SETUP_ADD_EMPLOYEES { get; set; }
        public int CFA_SETUP_EDIT_EMPLOYEES { get; set; }
        public int CFA_INVENTORY_PROMOTIONS { get; set; }
        public int CFA_INVOICE_DISCOUNTS_BELOW_X { get; set; }
        public int CFA_BUYBACKTRADE_ABOVE_SET_AMOUNT { get; set; }
        public int CFA_REPORTS_VIEW_HISTORICAL_DATA { get; set; }
        public int CFA_INVEN_MISC_FIELD_LOCKDOWN { get; set; }
        public int CFA_HH_Create_PO { get; set; }
        public int CFA_HH_DSD { get; set; }
        public int CFA_HH_DSD_Credit { get; set; }
        public int CFA_HH_PO_Receive { get; set; }
        public int CFA_HH_Inv_Edit { get; set; }
        public int CFA_HH_Inv_Adjust { get; set; }
        public int CFA_HH_Inv_Count { get; set; }
        public int CFA_HH_Setup { get; set; }
        public int CFA_CASHIER_OVERRIDE_LICENSESCAN { get; set; }
        public int CFA_INVEN_DELETE { get; set; }
        public int CFA_CASHIER_MANUALY_ENTER_AGE { get; set; }
        public int CFA_INVEN_ADD_COUPON { get; set; }
        public int CFA_INVEN_GLOBALPRICING { get; set; }
        public int CFA_EMP_SCHEDULE_OVERRIDE { get; set; }
        public int CFA_LABOR_SCHEDULER { get; set; }
        public int CFA_NEGATIVE_PRICE_CHANGE { get; set; }
        public int CFA_CUSTOMER_EDIT_CHARGEATCOST { get; set; } 
    }
}
