using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Domain.Common;
using POS.Repository.SQLServer;
using POS.Domain.Common.Employee;
using System.Data;

namespace POS.Repository.SQLServer
{
   public class EmployeeRepository
    {
       SQLServerRepository objSQLServerRepository = new SQLServerRepository();

       public EmployeesDataClass insertEmployeeData(EmployeesDataClass objEmployeesData)
       {
           try
           {
               string checkRecordExist = objSQLServerRepository.ExecuteScalar("select Cashier_ID from Employee where Cashier_ID = '" + objEmployeesData.Cashier_ID + "'");
               if(checkRecordExist != null)
               {
                   objSQLServerRepository.ExecuteNonQuery("delete from Employee where Cashier_ID = '" + objEmployeesData.Cashier_ID + "'");
               }
               int result = objSQLServerRepository.ExecuteNonQuery("INSERT INTO Employee" +
                                                                   "(Cashier_ID,"+
                                                                   "CustNum,"+
                                                                   "Dept_ID,"+
                                                                   "Password,"+
                                                                   "Swipe_ID,"+
                                                                   "Hourly_Wage,"+
                                                                   "Form_Color,"+
                                                                   "CDL,"+
                                                                   "Name,"+
                                                                   "CFA_Setup_Company,"+
                                                                   "CFA_Setup_Tax,"+
                                                                   "CFA_Setup_Bonus,"+
                                                                   "CFA_Setup_Accounting,"+
                                                                   "CFA_Setup_Discounts,"+
                                                                   "CFA_Setup_Display,"+
                                                                   "CFA_Setup_DefPrinter,"+
                                                                   "CFA_Inven_Add,"+
                                                                   "CFA_Inven_Edit,"+
                                                                   "CFA_Vendors_Add,"+
                                                                   "CFA_Vendors_Edit,"+
                                                                   "CFA_Depts_Add,"+
                                                                   "CFA_Depts_Edit,"+
                                                                   "CFA_Inven_TickVouch,"+
                                                                   "CFA_Cust_add,"+
                                                                   "CFA_Cust_Edit,"+
                                                                   "CFA_Reports_Display,"+
                                                                   "CFA_Reports_DDR,"+
                                                                   "CFA_Reports_Print,"+
                                                                   "CFA_Invoice_Discount,"+
                                                                   "CFA_Invoice_PriceChange,"+
                                                                   "CFA_Invoice_DeleteItems,"+
                                                                   "CFA_Invoice_Void,"+
                                                                   "CFA_CRE_Acct,"+
                                                                   "CFA_CRE_Exit,"+
                                                                   "Dirty,"+
                                                                   "Last_DDR,"+
                                                                   "CFA_Display_Balance,"+
                                                                   "CFA_Refund_Item,"+
                                                                   "Disp_Pay_Option,"+
                                                                   "Disp_Item_Option,"+
                                                                   "EmpName,"+
                                                                   "CFA_Receive_Items,"+
                                                                   "CFA_DO_POS,"+
                                                                   "CFA_INSTANT_POS,"+
                                                                   "Section_ID,"+
                                                                   "CFA_Other_Tables,"+
                                                                   "CFA_Accept_Cash,"+
                                                                   "CFA_TRANSFER_NOSWIPE,"+
                                                                   "CFA_ADD_CCTIPS,"+
                                                                   "Disabled,"+
                                                                   "CFA_PRINT_HOLD,"+
                                                                   "CFA_Open_Cash_Drawer,"+
                                                                   "CCTipsNow,"+
                                                                   "ReqClockIn,"+
                                                                   "CFA_Split_Checks,"+
                                                                   "CFA_Transfer_Tables,"+
                                                                   "CFA_Extra_Item,"+
                                                                   "CFA_Tax_Exempt,"+
                                                                   "CFA_GC_Sell,"+
                                                                   "CFA_GC_Redeem,"+
                                                                   "CFA_SELL_SPECIAL_ITEM,"+
                                                                   "CFA_VENDOR_PAYOUT,"+
                                                                   "CFA_APPLY_GRATUITY,"+
                                                                   "First_Name,"+
                                                                   "Middle_Name,"+
                                                                   "Last_Name,"+
                                                                   "SSN,"+
                                                                   "Address_1,"+
                                                                   "Address_2,"+
                                                                   "City,"+
                                                                   "State,"+
                                                                   "Zip_Code,"+
                                                                   "Phone_1,"+
                                                                   "EMail,"+
                                                                   "Birthday,"+
                                                                   "Picture,"+
                                                                   "CFA_BUYBACKS_TRADES,"+
                                                                   "CFA_CC_Force,"+
                                                                   "CFA_CC_Below_Floor,"+
                                                                   "Current_Cash,"+
                                                                   "CFA_Cash_Alerts,"+
                                                                   "CFA_Cash_Pickup,"+
                                                                   "CDL_Stations_ID,"+
                                                                   "CFA_Issue_Credit_Slip,"+
                                                                   "CFA_Redeem_Credit_Slip,"+
                                                                   "CFA_REFUND_OVERRIDE,"+
                                                                   "CFA_DRAWER_TRANSFER,"+
                                                                   "CFA_LARGE_PURCHASES,"+
                                                                   "CFA_AUCTION_PHOTO,"+
                                                                   "CFA_AUCTION_LISTREDEEM,"+
                                                                   "CFA_AUCTION_SHIP,"+
                                                                   "CFA_APPROVE_CASHCOUNT,"+
                                                                   "Orig_Emp_ID,"+
                                                                   "Orig_Store_ID,"+
                                                                   "CD_Name,"+
                                                                   "CFA_APPROVE_OLD_RETURNS,"+
                                                                   "CFA_APPROVE_EMERGENCY_CLOCKOUT,"+
                                                                   "TimeWorkedThisPeriod,"+
                                                                   "OvertimeThreshold,"+
                                                                   "CFA_PULLBACK_INVOICE,"+
                                                                   "CFA_MANAGE_TIMECLOCK,"+
                                                                   "CFA_PERFORM_ENDOFDAY,"+
                                                                   "CFA_HOST_LOGIN,"+
                                                                   "CFA_REST_OPENTABS,"+
                                                                   "CFA_REST_TAKEOUT,"+
                                                                   "CFA_REST_DELIVERY,"+
                                                                   "CFA_INVOICE_DELETESENT,"+
                                                                   "CFA_INVEN_VIEW,"+
                                                                   "CFA_INVEN_VIEWCOST,"+
                                                                   "CFA_INVEN_NEGATIVE_INSTANTPOS,"+
                                                                   "CFA_ENDTRANS_CASH,"+
                                                                   "CFA_ENDTRANS_ACCOUNT,"+
                                                                   "CFA_REST_COMP,"+
                                                                   "CFA_CH_FORCE,"+
                                                                   "CFA_TS_CONFIG,"+
                                                                   "CFA_TRANSFER_SERVER,"+
                                                                   "CFA_BACKUP_DATABASE,"+
                                                                   "CFA_CREDIT_CARD_SETTLEMENT,"+
                                                                   "CFA_KITCHEN_REPRINT,"+
                                                                   "CFA_SETUP_RECEIPT_NOTES,"+
                                                                   "CFA_MANAGE_TIMECLOCK_OWNTIME,"+
                                                                   "CFA_SETUP_ADD_EMPLOYEES,"+
                                                                   "CFA_SETUP_EDIT_EMPLOYEES,"+
                                                                   "CFA_INVENTORY_PROMOTIONS,"+
                                                                   "CFA_INVOICE_DISCOUNTS_BELOW_X,"+
                                                                   "CFA_BUYBACKTRADE_ABOVE_SET_AMOUNT,"+
                                                                   "CFA_REPORTS_VIEW_HISTORICAL_DATA,"+
                                                                   "CFA_INVEN_MISC_FIELD_LOCKDOWN,"+
                                                                   "CFA_HH_Create_PO,"+
                                                                   "CFA_HH_DSD,"+
                                                                   "CFA_HH_DSD_Credit,"+
                                                                   "CFA_HH_PO_Receive,"+
                                                                   "CFA_HH_Inv_Edit,"+
                                                                   "CFA_HH_Inv_Adjust,"+
                                                                   "CFA_HH_Inv_Count,"+
                                                                   "CFA_HH_Setup,"+
                                                                   "CFA_CASHIER_OVERRIDE_LICENSESCAN,"+
                                                                   "CFA_INVEN_DELETE,"+
                                                                   "CFA_CASHIER_MANUALY_ENTER_AGE,"+
                                                                   "CreateDate,"+
                                                                   "DateDisabled,"+
                                                                   "CFA_INVEN_ADD_COUPON,"+
                                                                   "CFA_INVEN_GLOBALPRICING,"+
                                                                   "CFA_EMP_SCHEDULE_OVERRIDE,"+
                                                                   "CFA_LABOR_SCHEDULER,"+
                                                                   "GLNumber,"+
                                                                   "CFA_NEGATIVE_PRICE_CHANGE,"+
                                                                   "CFA_CUSTOMER_EDIT_CHARGEATCOST,"+
                                                                   "CFA_GPI_FUEL_DRIVE_OFF,"+
                                                                   "CFA_SETUP_VPDCONFIGURATION,"+
                                                                   "CFA_CLOSE_SHIFT,"+
                                                                   "CFA_REPRINT_RECEIPT,"+
                                                                   "Locked_Time,"+
                                                                   "Retry_Count,"+
                                                                   "Password_Hash,"+
                                                                   "Salt_Key)"+
                                                             "VALUES"+
                                                                   "('"+objEmployeesData.Cashier_ID +"',"+
                                                                   "'"+objEmployeesData.CustNum +"',"+
                                                                   "'"+objEmployeesData.Dept_ID +"',"+
                                                                   "'"+objEmployeesData.Password +"',"+
                                                                   "'"+objEmployeesData.Swipe_ID +"',"+
                                                                   "'"+objEmployeesData.Hourly_Wage +"',"+
                                                                   "'"+objEmployeesData.Form_Color +"',"+
                                                                   "'"+objEmployeesData.CDL +"',"+
                                                                   "'"+objEmployeesData.Name +"',"+
                                                                   "'"+objEmployeesData.CFA_Setup_Company +"',"+
                                                                   "'"+objEmployeesData.CFA_Setup_Tax +"',"+
                                                                   "'"+objEmployeesData.CFA_Setup_Bonus +"',"+
                                                                   "'"+objEmployeesData.CFA_Setup_Accounting +"',"+
                                                                   "'"+objEmployeesData.CFA_Setup_Discounts +"',"+
                                                                   "'"+objEmployeesData.CFA_Setup_Display +"',"+
                                                                   "'"+objEmployeesData.CFA_Setup_DefPrinter +"',"+
                                                                   "'"+objEmployeesData.CFA_Inven_Add +"',"+
                                                                   "'"+objEmployeesData.CFA_Inven_Edit +"',"+
                                                                   "'"+objEmployeesData.CFA_Vendors_Add +"',"+
                                                                   "'"+objEmployeesData.CFA_Vendors_Edit +"',"+
                                                                   "'"+objEmployeesData.CFA_Depts_Add +"',"+
                                                                   "'"+objEmployeesData.CFA_Depts_Edit +"',"+
                                                                   "'"+objEmployeesData.CFA_Inven_TickVouch +"',"+
                                                                   "'"+objEmployeesData.CFA_Cust_add +"',"+
                                                                   "'"+objEmployeesData.CFA_Cust_Edit +"',"+
                                                                   "'"+objEmployeesData.CFA_Reports_Display +"',"+
                                                                   "'"+objEmployeesData.CFA_Reports_DDR +"',"+
                                                                   "'"+objEmployeesData.CFA_Reports_Print +"',"+
                                                                   "'"+objEmployeesData.CFA_Invoice_Discount +"',"+
                                                                   "'"+objEmployeesData.CFA_Invoice_PriceChange +"',"+
                                                                   "'"+objEmployeesData.CFA_Invoice_DeleteItems +"',"+
                                                                   "'"+objEmployeesData.CFA_Invoice_Void +"',"+
                                                                   "'"+objEmployeesData.CFA_CRE_Acct +"',"+
                                                                   "'"+objEmployeesData.CFA_CRE_Exit +"',"+
                                                                   "'"+objEmployeesData.Dirty +"',"+
                                                                   "'"+objEmployeesData.Last_DDR +"',"+
                                                                   "'"+objEmployeesData.CFA_Display_Balance +"',"+
                                                                   "'"+objEmployeesData.CFA_Refund_Item +"',"+
                                                                   "'"+objEmployeesData.Disp_Pay_Option +"',"+
                                                                   "'"+objEmployeesData.Disp_Item_Option +"',"+
                                                                   "'"+objEmployeesData.EmpName +"',"+
                                                                   "'"+objEmployeesData.CFA_Receive_Items +"',"+
                                                                   "'"+objEmployeesData.CFA_DO_POS +"',"+
                                                                   "'"+objEmployeesData.CFA_INSTANT_POS +"',"+
                                                                   "'"+objEmployeesData.Section_ID +"',"+
                                                                   "'"+objEmployeesData.CFA_Other_Tables +"',"+
                                                                   "'"+objEmployeesData.CFA_Accept_Cash +"',"+
                                                                   "'"+objEmployeesData.CFA_TRANSFER_NOSWIPE +"',"+
                                                                   "'"+objEmployeesData.CFA_ADD_CCTIPS +"',"+
                                                                   "'"+objEmployeesData.Disabled +"',"+
                                                                   "'"+objEmployeesData.CFA_PRINT_HOLD +"',"+
                                                                   "'"+objEmployeesData.CFA_Open_Cash_Drawer +"',"+
                                                                   "'"+objEmployeesData.CCTipsNow +"',"+
                                                                   "'"+objEmployeesData.ReqClockIn +"',"+
                                                                   "'"+objEmployeesData.CFA_Split_Checks +"',"+
                                                                   "'"+objEmployeesData.CFA_Transfer_Tables +"',"+
                                                                   "'"+objEmployeesData.CFA_Extra_Item +"',"+
                                                                   "'"+objEmployeesData.CFA_Tax_Exempt +"',"+
                                                                   "'"+objEmployeesData.CFA_GC_Sell +"',"+
                                                                   "'"+objEmployeesData.CFA_GC_Redeem +"',"+
                                                                   "'"+objEmployeesData.CFA_SELL_SPECIAL_ITEM +"',"+
                                                                   "'"+objEmployeesData.CFA_VENDOR_PAYOUT +"',"+
                                                                   "'"+objEmployeesData.CFA_APPLY_GRATUITY +"',"+
                                                                   "'"+objEmployeesData.First_Name +"',"+
                                                                   "'"+objEmployeesData.Middle_Name +"',"+
                                                                   "'"+objEmployeesData.Last_Name +"',"+
                                                                   "'"+objEmployeesData.SSN +"',"+
                                                                   "'"+objEmployeesData.Address_1 +"',"+
                                                                   "'"+objEmployeesData.Address_2 +"',"+
                                                                   "'"+objEmployeesData.City +"',"+
                                                                   "'"+objEmployeesData.State +"',"+
                                                                   "'"+objEmployeesData.Zip_Code +"',"+
                                                                   "'"+objEmployeesData.Phone_1 +"',"+
                                                                   "'"+objEmployeesData.EMail +"',"+
                                                                   "'"+objEmployeesData.Birthday +"',"+
                                                                   "'"+objEmployeesData.Picture +"',"+
                                                                   "'"+objEmployeesData.CFA_BUYBACKS_TRADES +"',"+
                                                                   "'"+objEmployeesData.CFA_CC_Force +"',"+
                                                                   "'"+objEmployeesData.CFA_CC_Below_Floor +"',"+
                                                                   "'"+objEmployeesData.Current_Cash +"',"+
                                                                   "'"+objEmployeesData.CFA_Cash_Alerts +"',"+
                                                                   "'"+objEmployeesData.CFA_Cash_Pickup +"',"+
                                                                   "'"+objEmployeesData.CDL_Stations_ID +"',"+
                                                                   "'"+objEmployeesData.CFA_Issue_Credit_Slip +"',"+
                                                                   "'"+objEmployeesData.CFA_Redeem_Credit_Slip +"',"+
                                                                   "'"+objEmployeesData.CFA_REFUND_OVERRIDE +"',"+
                                                                   "'"+objEmployeesData.CFA_DRAWER_TRANSFER +"',"+
                                                                   "'"+objEmployeesData.CFA_LARGE_PURCHASES +"',"+
                                                                   "'"+objEmployeesData.CFA_AUCTION_PHOTO +"',"+
                                                                   "'"+objEmployeesData.CFA_AUCTION_LISTREDEEM +"',"+
                                                                   "'"+objEmployeesData.CFA_AUCTION_SHIP +"',"+
                                                                   "'"+objEmployeesData.CFA_APPROVE_CASHCOUNT +"',"+
                                                                   "'"+objEmployeesData.Orig_Emp_ID +"',"+
                                                                   "'"+objEmployeesData.Orig_Store_ID +"',"+
                                                                   "'"+objEmployeesData.CD_Name +"',"+
                                                                   "'"+objEmployeesData.CFA_APPROVE_OLD_RETURNS +"',"+
                                                                   "'"+objEmployeesData.CFA_APPROVE_EMERGENCY_CLOCKOUT +"',"+
                                                                   "'"+objEmployeesData.TimeWorkedThisPeriod +"',"+
                                                                   "'"+objEmployeesData.OvertimeThreshold +"',"+
                                                                   "'"+objEmployeesData.CFA_PULLBACK_INVOICE +"',"+
                                                                   "'"+objEmployeesData.CFA_MANAGE_TIMECLOCK +"',"+
                                                                   "'"+objEmployeesData.CFA_PERFORM_ENDOFDAY +"',"+
                                                                   "'"+objEmployeesData.CFA_HOST_LOGIN +"',"+
                                                                   "'"+objEmployeesData.CFA_REST_OPENTABS +"',"+
                                                                   "'"+objEmployeesData.CFA_REST_TAKEOUT +"',"+
                                                                   "'"+objEmployeesData.CFA_REST_DELIVERY +"',"+
                                                                   "'"+objEmployeesData.CFA_INVOICE_DELETESENT +"',"+
                                                                   "'"+objEmployeesData.CFA_INVEN_VIEW +"',"+
                                                                   "'"+objEmployeesData.CFA_INVEN_VIEWCOST +"',"+
                                                                   "'"+objEmployeesData.CFA_INVEN_NEGATIVE_INSTANTPOS +"',"+
                                                                   "'"+objEmployeesData.CFA_ENDTRANS_CASH +"',"+
                                                                   "'"+objEmployeesData.CFA_ENDTRANS_ACCOUNT +"',"+
                                                                   "'"+objEmployeesData.CFA_REST_COMP +"',"+
                                                                   "'"+objEmployeesData.CFA_CH_FORCE +"',"+
                                                                   "'"+objEmployeesData.CFA_TS_CONFIG +"',"+
                                                                   "'"+objEmployeesData.CFA_TRANSFER_SERVER +"',"+
                                                                   "'"+objEmployeesData.CFA_BACKUP_DATABASE +"',"+
                                                                   "'"+objEmployeesData.CFA_CREDIT_CARD_SETTLEMENT +"',"+
                                                                   "'"+objEmployeesData.CFA_KITCHEN_REPRINT +"',"+
                                                                   "'"+objEmployeesData.CFA_SETUP_RECEIPT_NOTES +"',"+
                                                                   "'"+objEmployeesData.CFA_MANAGE_TIMECLOCK_OWNTIME +"',"+
                                                                   "'"+objEmployeesData.CFA_SETUP_ADD_EMPLOYEES +"',"+
                                                                   "'"+objEmployeesData.CFA_SETUP_EDIT_EMPLOYEES +"',"+
                                                                   "'"+objEmployeesData.CFA_INVENTORY_PROMOTIONS +"',"+
                                                                   "'"+objEmployeesData.CFA_INVOICE_DISCOUNTS_BELOW_X +"',"+
                                                                   "'"+objEmployeesData.CFA_BUYBACKTRADE_ABOVE_SET_AMOUNT +"',"+
                                                                   "'"+objEmployeesData.CFA_REPORTS_VIEW_HISTORICAL_DATA +"',"+
                                                                   "'"+objEmployeesData.CFA_INVEN_MISC_FIELD_LOCKDOWN +"',"+
                                                                   "'"+objEmployeesData.CFA_HH_Create_PO +"',"+
                                                                   "'"+objEmployeesData.CFA_HH_DSD +"',"+
                                                                   "'"+objEmployeesData.CFA_HH_DSD_Credit +"',"+
                                                                   "'"+objEmployeesData.CFA_HH_PO_Receive +"',"+
                                                                   "'"+objEmployeesData.CFA_HH_Inv_Edit +"',"+
                                                                   "'"+objEmployeesData.CFA_HH_Inv_Adjust +"',"+
                                                                   "'"+objEmployeesData.CFA_HH_Inv_Count +"',"+
                                                                   "'"+objEmployeesData.CFA_HH_Setup +"',"+
                                                                   "'"+objEmployeesData.CFA_CASHIER_OVERRIDE_LICENSESCAN +"',"+
                                                                   "'"+objEmployeesData.CFA_INVEN_DELETE +"',"+
                                                                   "'"+objEmployeesData.CFA_CASHIER_MANUALY_ENTER_AGE +"',"+
                                                                   "'"+objEmployeesData.CreateDate +"',"+
                                                                   "'"+objEmployeesData.DateDisabled +"',"+
                                                                   "'"+objEmployeesData.CFA_INVEN_ADD_COUPON +"',"+
                                                                   "'"+objEmployeesData.CFA_INVEN_GLOBALPRICING +"',"+
                                                                   "'"+objEmployeesData.CFA_EMP_SCHEDULE_OVERRIDE +"',"+
                                                                   "'"+objEmployeesData.CFA_LABOR_SCHEDULER +"',"+
                                                                   "'"+objEmployeesData.GLNumber +"',"+
                                                                   "'"+objEmployeesData.CFA_NEGATIVE_PRICE_CHANGE +"',"+
                                                                   "'"+objEmployeesData.CFA_CUSTOMER_EDIT_CHARGEATCOST +"',"+
                                                                   "'"+objEmployeesData.CFA_GPI_FUEL_DRIVE_OFF +"',"+
                                                                   "'"+objEmployeesData.CFA_SETUP_VPDCONFIGURATION +"',"+
                                                                   "'"+objEmployeesData.CFA_CLOSE_SHIFT +"',"+
                                                                   "'"+objEmployeesData.CFA_REPRINT_RECEIPT +"',"+
                                                                   "'"+objEmployeesData.Locked_Time +"',"+
                                                                   "'"+objEmployeesData.Retry_Count +"',"+
                                                                   "'"+objEmployeesData.Password_Hash +"',"+
                                                                   "'"+objEmployeesData.Salt_Key +"')");
               if(result > 0)
               {
                   objEmployeesData.IsSuccessfull = true;
               }
               else
               {
                   objEmployeesData.IsSuccessfull = false;
               }
           }
           catch (Exception ex)
           {
               CustomLogging.Log("[SQLServerRepository:]", ex.Message);
           }
           return objEmployeesData;
       }
       DataTable dtdept;
       public DataTable getDepforEmployee(DepartmentClass objDept)
       {
           try
           {
               dtdept = objSQLServerRepository.GetDataTable("select Dept_ID,Dept_ID + '-' + Description as Dept from Departments where Type = '" + objDept.Type + "' and Store_ID = '" + objDept.Store_ID + "'");
           }
           catch (Exception ex)
           {
               CustomLogging.Log("[SQLServerRepository:]", ex.Message);
           }
           return dtdept;
       }
    }
}
