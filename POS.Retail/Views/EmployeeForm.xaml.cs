using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using POS.Retail.Common;
using POS.Domain.Common;
using POS.Services.Common;
using POS.Domain.Common.Employee;

namespace POS.Retail
{
    /// <summary>
    /// Interaction logic for EmployeeForm.xaml
    /// </summary>
    public partial class EmployeeForm : Window
    {
        POSManagementService objPOSManagementService = new POSManagementService();
        int index = 0;
        string s = string.Empty;
        DataTable dt = new DataTable();
        //GlobalClass glo = new GlobalClass();
        public EmployeeForm()
        {
            InitializeComponent();
            fill_employee();
            //cmb_search_emp.SelectedIndex = 0;
        }

        private void fun_hide_permission_grid()
        {
            gird_func.Visibility = Visibility.Hidden;
            Grid_per_inventory.Visibility = Visibility.Hidden;
            Grid_permis_customer.Visibility = Visibility.Hidden;
            Grid_permis_reports.Visibility = Visibility.Hidden;
            grid_permis_setup.Visibility = Visibility.Hidden;
            grid_permis_Restaurant.Visibility = Visibility.Hidden;
            grid_permis_handhold.Visibility = Visibility.Hidden;

        }
        private void fun_clear_fields()
        {
            txt_emp_id.Clear();
            txt_emp_passd.Clear();
            txt_first_name.Clear();
            txt_emp_dispname.Clear();
            txt_emp_dispname.Clear();
            txt_first_name.Clear();
            txt_houlywages.Clear();
            txt_SSN.Clear();
            txt_phone.Clear();
            txt_start_overtime.Clear();
            txt_state.Clear();
            txt_zipcode.Clear();
            txt_middle_name.Clear();
            txt_last_name.Clear();
            txt_email.Clear();
            txt_customer.Clear();
            txt_city.Clear();
            txt_cardswip.Clear();
            txt_birthday.Clear();
            state_additional_credits_txt.Clear();
            txt_fed_allwnce.Clear();
            txt_state_allown.Clear();

        }

        #region permission girds buttons's click events on permission tabcontrol

        private void btn_per_func_Click(object sender, RoutedEventArgs e)
        {
            fun_hide_permission_grid();
            gird_func.Visibility = Visibility.Visible;
        }

        private void btn_per_inventory_Click(object sender, RoutedEventArgs e)
        {
            fun_hide_permission_grid();
            Grid_per_inventory.Visibility = Visibility.Visible;
        }

        private void btn_per_customer_Click(object sender, RoutedEventArgs e)
        {
            fun_hide_permission_grid();
            Grid_permis_customer.Visibility = Visibility.Visible;
        }

        private void btn_per_report_Click(object sender, RoutedEventArgs e)
        {
            fun_hide_permission_grid();
            Grid_permis_reports.Visibility = Visibility.Visible;
        }

        private void btn_per_setup_Click(object sender, RoutedEventArgs e)
        {
            fun_hide_permission_grid();
            grid_permis_setup.Visibility = Visibility.Visible;
        }

        private void btn_per_resturt_Click(object sender, RoutedEventArgs e)
        {
            fun_hide_permission_grid();
            grid_permis_Restaurant.Visibility = Visibility.Visible;
        }

        private void btn_per_handhold_Click(object sender, RoutedEventArgs e)
        {
            fun_hide_permission_grid();
            grid_permis_handhold.Visibility = Visibility.Visible;
        }
        #endregion

        private void btn_exit_emp_Click(object sender, RoutedEventArgs e)
        {
            if (btn_exit_emp.Content.Equals("Exit"))
            {
                this.Close();
            }
            else if (btn_exit_emp.Content.Equals("Cancel"))
            {
                btn_add_emp.Content = "Add Employee";
                btn_exit_emp.Content = "Exit";
                btn_delete_emp.IsHitTestVisible = true;
                btn_emp_next.IsHitTestVisible = true;
                btn_emp_next.IsHitTestVisible = true;
                btn_emp_prev.IsHitTestVisible = true;
                btn_savechages_emp.IsHitTestVisible = true;
                lbl_serch_emp.Visibility = Visibility.Visible;
                cmb_search_emp.Visibility = Visibility.Visible;
            }

        }

        private void btn_add_emp_Click(object sender, RoutedEventArgs e)
        {
            if (btn_add_emp.Content.Equals("Add Employee"))
            {
                btn_add_emp.Content = "Save";
                btn_exit_emp.Content = "Cancel";
                btn_delete_emp.IsHitTestVisible = false;
                btn_emp_next.IsHitTestVisible = false;
                btn_emp_next.IsHitTestVisible = false;
                btn_emp_prev.IsHitTestVisible = false;
                btn_savechages_emp.IsHitTestVisible = false;
                lbl_serch_emp.Visibility = Visibility.Hidden;
                cmb_search_emp.Visibility = Visibility.Hidden;
                txt_emp_id.Background = Brushes.Yellow;
                txt_emp_id.Focus();
                fun_clear_fields();
            }
            else
                if (btn_add_emp.Content.Equals("Save"))
                {

                    if (txt_emp_id.Text != "")
                    {
                        EmployeesDataClass objEmployeesData = new EmployeesDataClass();
                        objEmployeesData.Cashier_ID = txt_emp_id.Text;
                        objEmployeesData.CustNum = txt_customer.Text;
                        objEmployeesData.Dept_ID = cmb_cetegory.Text;
                        objEmployeesData.Password = txt_emp_passd.Text;
                        objEmployeesData.Swipe_ID = txt_cardswip.Text;
                        objEmployeesData.Hourly_Wage = txt_houlywages.Text;
                        objEmployeesData.Form_Color = "";
                        objEmployeesData.CDL = "";
                        objEmployeesData.Name = txt_customer.Text;
                        objEmployeesData.CFA_Setup_Company = combo_check(setup_cmb);
                        objEmployeesData.CFA_Setup_Tax = combo_check(tax_rate_cmb);
                        objEmployeesData.CFA_Setup_Bonus = combo_check(bonus_plan_cmb);
                        objEmployeesData.CFA_Setup_Accounting = combo_check(accountinginterface_cmb);
                        objEmployeesData.CFA_Setup_Discounts = combo_check(discount_cmb);
                        objEmployeesData.CFA_Setup_Display = combo_check(displaysetting_cmb);
                        objEmployeesData.CFA_Setup_DefPrinter = combo_check(defaultprinter_cmb);
                        objEmployeesData.CFA_Inven_Add = combo_check(add_inventory_cmb);
                        objEmployeesData.CFA_Inven_Edit = combo_check(Inventory_edit_cmb);
                        objEmployeesData.CFA_Vendors_Add = combo_check(add_vendor_cmb);
                        objEmployeesData.CFA_Vendors_Edit = combo_check(update_vendor_cmb);
                        objEmployeesData.CFA_Depts_Add = combo_check(add_department_cmb);
                        objEmployeesData.CFA_Depts_Edit = combo_check(edit_department_cmb);
                        objEmployeesData.CFA_Inven_TickVouch = combo_check(delete_inventory_cmb);
                        objEmployeesData.CFA_Cust_add = combo_check(add_customer_cmb);
                        objEmployeesData.CFA_Cust_Edit = combo_check(edit_customer_cmb);
                        objEmployeesData.CFA_Reports_Display = combo_check(display_reports_cmb);
                        objEmployeesData.CFA_Reports_DDR = combo_check(ddr_print_cmb);
                        objEmployeesData.CFA_Reports_Print = combo_check(print_reports_cmb);
                        objEmployeesData.CFA_Invoice_Discount = combo_check(invoice_discount_cmb);
                        objEmployeesData.CFA_Invoice_PriceChange = combo_check(modify_price_cmb);
                        objEmployeesData.CFA_Invoice_DeleteItems = combo_check(delete_items_cmb);
                        objEmployeesData.CFA_Invoice_Void = combo_check(void_invoice_cmb);
                        objEmployeesData.CFA_CRE_Acct = combo_check(accountinginterface_cmb);
                        objEmployeesData.CFA_CRE_Exit = combo_check(allow_exit_cmb);
                        objEmployeesData.Dirty = 1;
                        objEmployeesData.Last_DDR = DateTime.Today;
                        objEmployeesData.CFA_Display_Balance = combo_check(display_balance_cmb);
                        objEmployeesData.CFA_Refund_Item = combo_check(override_refund_cmb);
                        objEmployeesData.Disp_Pay_Option = 1;
                        objEmployeesData.Disp_Item_Option = 1;
                        objEmployeesData.EmpName = "";
                        objEmployeesData.CFA_Receive_Items = combo_check(po_receive_item_cmb);
                        objEmployeesData.CFA_DO_POS = combo_check(create_po_cmb);
                        objEmployeesData.CFA_INSTANT_POS = combo_check(instant_po_cmb);
                        objEmployeesData.Section_ID = "";
                        objEmployeesData.CFA_Other_Tables = combo_check(other_tables_cmb);
                        objEmployeesData.CFA_Accept_Cash = combo_check(cash_pickups_cmb);
                        objEmployeesData.CFA_TRANSFER_NOSWIPE = combo_check(transfer_without_cmb);
                        objEmployeesData.CFA_ADD_CCTIPS = combo_check(cc_tips_cmb);
                        objEmployeesData.Disabled = 0;
                        //objEmployeesData.Admin_Access = dirty;
                        objEmployeesData.CFA_PRINT_HOLD = combo_check(hold_print_cmb);
                        objEmployeesData.CFA_Open_Cash_Drawer = combo_check(open_cash_cmb);
                        objEmployeesData.CCTipsNow = 0;
                        objEmployeesData.ReqClockIn = 0;
                        objEmployeesData.CFA_Split_Checks = combo_check(split_checks_cmb);
                        objEmployeesData.CFA_Transfer_Tables = combo_check(transfer_tables_cmb);
                        objEmployeesData.CFA_Extra_Item = "P";
                        objEmployeesData.CFA_Tax_Exempt = combo_check(tax_ex_cmb);
                        objEmployeesData.CFA_GC_Sell = combo_check(sell_giftc_cmb);
                        objEmployeesData.CFA_GC_Redeem = combo_check(redeem_giftc_cmb);
                        objEmployeesData.CFA_SELL_SPECIAL_ITEM = combo_check(sell_special_cmb);
                        objEmployeesData.CFA_VENDOR_PAYOUT = combo_check(vendor_payouts_cmb);
                        objEmployeesData.CFA_APPLY_GRATUITY = combo_check(apply_gratuity_cmb);
                        objEmployeesData.First_Name = txt_first_name.Text;
                        objEmployeesData.Middle_Name = txt_middle_name.Text;
                        objEmployeesData.Last_Name = txt_last_name.Text;
                        objEmployeesData.SSN = txt_SSN.Text;
                        objEmployeesData.Address_1 = address_1_txt.Text;
                        objEmployeesData.Address_2 = address_2_txt.Text;
                        objEmployeesData.City = txt_city.Text;
                        objEmployeesData.State = txt_state.Text;
                        objEmployeesData.Zip_Code = txt_zipcode.Text;
                        objEmployeesData.Phone_1 = txt_phone.Text;
                        objEmployeesData.EMail = txt_email.Text;
                        objEmployeesData.Birthday = Convert.ToDateTime(txt_birthday.Text);
                        objEmployeesData.Picture = "";
                        objEmployeesData.CFA_BUYBACKS_TRADES = combo_check(buyback_trade_cmb);
                        objEmployeesData.CFA_CC_Force = combo_check(force_credit_cmb);
                        objEmployeesData.CFA_CC_Below_Floor = "P";
                        objEmployeesData.Current_Cash = 0.00;
                        objEmployeesData.CFA_Cash_Alerts = combo_check(cas_alert_cmb);
                        objEmployeesData.CFA_Cash_Pickup = combo_check(cash_pickups_cmb);
                        objEmployeesData.CDL_Stations_ID = "P";
                        objEmployeesData.CFA_Issue_Credit_Slip = combo_check(issue_credit_cmb);
                        objEmployeesData.CFA_Redeem_Credit_Slip = combo_check(redeem_credit_slip);
                        objEmployeesData.CFA_REFUND_OVERRIDE = combo_check(override_refund_cmb);
                        objEmployeesData.CFA_DRAWER_TRANSFER = combo_check(drawer_transfer_cmb);
                        objEmployeesData.CFA_LARGE_PURCHASES = combo_check(allow_large_purchase_cmb);
                        objEmployeesData.CFA_AUCTION_PHOTO = "P";
                        objEmployeesData.CFA_AUCTION_LISTREDEEM = "P";
                        objEmployeesData.CFA_AUCTION_SHIP = "";
                        objEmployeesData.CFA_APPROVE_CASHCOUNT = combo_check(approve_cash_count_cmb);
                        objEmployeesData.Orig_Emp_ID = "";
                        objEmployeesData.Orig_Store_ID = "";
                        objEmployeesData.CD_Name = "P";
                        objEmployeesData.CFA_APPROVE_OLD_RETURNS = combo_check(allow_old_return_cmb);
                        objEmployeesData.CFA_APPROVE_EMERGENCY_CLOCKOUT = combo_check(approve_emer_cmb);
                        objEmployeesData.TimeWorkedThisPeriod = 0;
                        objEmployeesData.OvertimeThreshold = Convert.ToInt32(txt_start_overtime.Text);
                        objEmployeesData.CFA_PULLBACK_INVOICE = combo_check(pullback_cmb);
                        objEmployeesData.CFA_MANAGE_TIMECLOCK = "P";
                        objEmployeesData.CFA_PERFORM_ENDOFDAY = combo_check(perform_endofday_cmb);
                        objEmployeesData.CFA_HOST_LOGIN = combo_check(host_module_cmb);
                        objEmployeesData.CFA_REST_OPENTABS = combo_check(open_tabs_cmb);
                        objEmployeesData.CFA_REST_TAKEOUT = combo_check(take_out_orders_cmb);
                        objEmployeesData.CFA_REST_DELIVERY = combo_check(delivery_orders_cmb);
                        objEmployeesData.CFA_INVOICE_DELETESENT = combo_check(invoice_price_change_cmb);
                        objEmployeesData.CFA_INVEN_VIEW = combo_check(view_inventory_cmb);
                        objEmployeesData.CFA_INVEN_VIEWCOST = combo_check(view_inventory_cost);
                        objEmployeesData.CFA_INVEN_NEGATIVE_INSTANTPOS = combo_check(instant_po_cmb);
                        objEmployeesData.CFA_ENDTRANS_CASH = combo_check(end_cash_cmb);
                        objEmployeesData.CFA_ENDTRANS_ACCOUNT = combo_check(end_transaction_cmb);
                        objEmployeesData.CFA_REST_COMP = "P";
                        objEmployeesData.CFA_CH_FORCE = combo_check(force_check_cmb);
                        objEmployeesData.CFA_TS_CONFIG = combo_check(configure_virtual_cmb);
                        objEmployeesData.CFA_TRANSFER_SERVER = combo_check(transfer_servers_cmb);
                        objEmployeesData.CFA_BACKUP_DATABASE = combo_check(backup_database_cmb);
                        objEmployeesData.CFA_CREDIT_CARD_SETTLEMENT = combo_check(settle_credit_cmb);
                        objEmployeesData.CFA_KITCHEN_REPRINT = combo_check(reprint_kitchen_cmb);
                        objEmployeesData.CFA_SETUP_RECEIPT_NOTES = combo_check(configure_receipt_cmb);
                        objEmployeesData.CFA_MANAGE_TIMECLOCK_OWNTIME = "P";
                        objEmployeesData.CFA_SETUP_ADD_EMPLOYEES = combo_check(add_employee_cmb);
                        objEmployeesData.CFA_SETUP_EDIT_EMPLOYEES = combo_check(modify_employee_cmb);
                        objEmployeesData.CFA_INVENTORY_PROMOTIONS = "P";
                        objEmployeesData.CFA_INVOICE_DISCOUNTS_BELOW_X = "P";
                        objEmployeesData.CFA_BUYBACKTRADE_ABOVE_SET_AMOUNT = "P";
                        objEmployeesData.CFA_REPORTS_VIEW_HISTORICAL_DATA = combo_check(view_historical_cmb);
                        objEmployeesData.CFA_INVEN_MISC_FIELD_LOCKDOWN = combo_check(limited_edit_lockdown_cmb);
                        objEmployeesData.CFA_HH_Create_PO = combo_check(create_po_cmb);
                        objEmployeesData.CFA_HH_DSD = combo_check(DSD_cmb);
                        objEmployeesData.CFA_HH_DSD_Credit = combo_check(DSD_credit_cmb);
                        objEmployeesData.CFA_HH_PO_Receive = combo_check(po_receive_item_cmb);
                        objEmployeesData.CFA_HH_Inv_Edit = combo_check(Inventory_edit_cmb);
                        objEmployeesData.CFA_HH_Inv_Adjust = combo_check(inventory_adjust_cmb);
                        objEmployeesData.CFA_HH_Inv_Count = combo_check(inventory_count_cmb);
                        objEmployeesData.CFA_HH_Setup = combo_check(setup_cmb);
                        objEmployeesData.CFA_CASHIER_OVERRIDE_LICENSESCAN = "P";
                        objEmployeesData.CFA_INVEN_DELETE = combo_check(delete_inventory_cmb);
                        objEmployeesData.CFA_CASHIER_MANUALY_ENTER_AGE = combo_check(manual_age_cmb);
                        objEmployeesData.CreateDate = DateTime.Today;
                        objEmployeesData.DateDisabled = DateTime.Today;
                        objEmployeesData.CFA_INVEN_ADD_COUPON = combo_check(add_coupons_cmb);
                        objEmployeesData.CFA_INVEN_GLOBALPRICING = combo_check(global_pricing_cmb);
                        objEmployeesData.CFA_EMP_SCHEDULE_OVERRIDE = combo_check(labor_schedule_cmb);
                        objEmployeesData.CFA_LABOR_SCHEDULER = combo_check(labor_schedule_cmb);
                        objEmployeesData.GLNumber = "P";
                        objEmployeesData.CFA_NEGATIVE_PRICE_CHANGE = combo_check(negative_price_cmb);
                        objEmployeesData.CFA_CUSTOMER_EDIT_CHARGEATCOST = combo_check(charge_at_cost_cmb);
                        objEmployeesData.CFA_GPI_FUEL_DRIVE_OFF = combo_check(fuel_off_cmb);
                        // inserton of data in main employee table
                        objPOSManagementService.insertEmpData(objEmployeesData);
                        if(objEmployeesData.IsSuccessfull == true)
                        {
                            MessageBox.Show("Employee Record Added Successfully", "");
                        }
                        ////using(SqlCommand cmd=new SqlCommand("SP_",global.con);
                        ////{
                        ////    SqlParameter sp1=new SqlParameter("@cust_id",txt_emp_id);
                        ////    cmd.a
                        ////}
                        //glo.con.Open();
                        //using (SqlCommand cmd = new SqlCommand("SP_SAVE_EMPLOYEE", glo.con))
                        //{
                        //    #region STORED PROCEDURE TO ENTER EMPLOYEE DETAILS TO EMPLOYEE TABLE BY WAQAR
                        //    cmd.CommandType = CommandType.StoredProcedure;

                        //    SqlParameter param1 = null;
                        //    SqlParameter param2 = null;
                        //    SqlParameter param3 = null;
                        //    SqlParameter param4 = null;
                        //    SqlParameter param5 = null;
                        //    SqlParameter param6 = null;
                        //    SqlParameter param7 = null;
                        //    SqlParameter param8 = null;
                        //    SqlParameter param9 = null;
                        //    SqlParameter param10 = null;
                        //    SqlParameter param11 = null;
                        //    SqlParameter param12 = null;
                        //    SqlParameter param13 = null;
                        //    SqlParameter param14 = null;
                        //    SqlParameter param15 = null;
                        //    SqlParameter param16 = null;
                        //    SqlParameter param17 = null;
                        //    SqlParameter param18 = null;
                        //    SqlParameter param19 = null;
                        //    SqlParameter param20 = null;
                        //    SqlParameter param21 = null;
                        //    SqlParameter param22 = null;
                        //    SqlParameter param23 = null;
                        //    SqlParameter param24 = null;
                        //    SqlParameter param25 = null;
                        //    SqlParameter param26 = null;
                        //    SqlParameter param27 = null;
                        //    SqlParameter param28 = null;
                        //    SqlParameter param29 = null;
                        //    SqlParameter param30 = null;
                        //    SqlParameter param31 = null;
                        //    SqlParameter param32 = null;
                        //    SqlParameter param33 = null;
                        //    SqlParameter param34 = null;
                        //    SqlParameter param35 = null;
                        //    SqlParameter param36 = null;
                        //    SqlParameter param37 = null;
                        //    SqlParameter param38 = null;
                        //    SqlParameter param39 = null;
                        //    SqlParameter param40 = null;
                        //    SqlParameter param41 = null;
                        //    SqlParameter param42 = null;
                        //    SqlParameter param43 = null;
                        //    SqlParameter param44 = null;
                        //    SqlParameter param45 = null;
                        //    SqlParameter param46 = null;
                        //    SqlParameter param47 = null;
                        //    SqlParameter param48 = null;
                        //    SqlParameter param49 = null;
                        //    SqlParameter param50 = null;
                        //    SqlParameter param51 = null;
                        //    SqlParameter param52 = null;
                        //    SqlParameter param53 = null;
                        //    SqlParameter param54 = null;
                        //    SqlParameter param55 = null;
                        //    SqlParameter param56 = null;
                        //    SqlParameter param57 = null;
                        //    SqlParameter param58 = null;
                        //    SqlParameter param59 = null;
                        //    SqlParameter param60 = null;
                        //    SqlParameter param61 = null;
                        //    SqlParameter param62 = null;
                        //    SqlParameter param63 = null;
                        //    SqlParameter param64 = null;
                        //    SqlParameter param65 = null;
                        //    SqlParameter param66 = null;
                        //    SqlParameter param67 = null;
                        //    SqlParameter param68 = null;
                        //    SqlParameter param69 = null;
                        //    SqlParameter param70 = null;
                        //    SqlParameter param71 = null;
                        //    SqlParameter param72 = null;
                        //    SqlParameter param73 = null;
                        //    SqlParameter param74 = null;
                        //    SqlParameter param75 = null;
                        //    SqlParameter param76 = null;
                        //    SqlParameter param77 = null;
                        //    SqlParameter param78 = null;
                        //    SqlParameter param79 = null;
                        //    SqlParameter param80 = null;
                        //    SqlParameter param81 = null;
                        //    SqlParameter param82 = null;
                        //    SqlParameter param83 = null;
                        //    SqlParameter param84 = null;
                        //    SqlParameter param85 = null;
                        //    SqlParameter param86 = null;
                        //    SqlParameter param87 = null;
                        //    SqlParameter param88 = null;
                        //    SqlParameter param89 = null;
                        //    SqlParameter param90 = null;
                        //    SqlParameter param91 = null;
                        //    SqlParameter param92 = null;
                        //    SqlParameter param93 = null;
                        //    SqlParameter param94 = null;
                        //    SqlParameter param95 = null;
                        //    SqlParameter param96 = null;
                        //    SqlParameter param97 = null;
                        //    SqlParameter param98 = null;
                        //    SqlParameter param99 = null;
                        //    SqlParameter param100 = null;
                        //    SqlParameter param101 = null;
                        //    SqlParameter param102 = null;
                        //    SqlParameter param103 = null;
                        //    SqlParameter param104 = null;
                        //    SqlParameter param105 = null;
                        //    SqlParameter param106 = null;
                        //    SqlParameter param107 = null;
                        //    SqlParameter param108 = null;
                        //    SqlParameter param109 = null;
                        //    SqlParameter param110 = null;
                        //    SqlParameter param111 = null;
                        //    SqlParameter param112 = null;
                        //    SqlParameter param113 = null;
                        //    SqlParameter param114 = null;
                        //    SqlParameter param115 = null;
                        //    SqlParameter param116 = null;
                        //    SqlParameter param117 = null;
                        //    SqlParameter param118 = null;
                        //    SqlParameter param119 = null;
                        //    SqlParameter param120 = null;
                        //    SqlParameter param121 = null;
                        //    SqlParameter param122 = null;
                        //    SqlParameter param123 = null;
                        //    SqlParameter param124 = null;
                        //    SqlParameter param125 = null;
                        //    SqlParameter param126 = null;
                        //    SqlParameter param127 = null;
                        //    SqlParameter param128 = null;
                        //    SqlParameter param129 = null;
                        //    SqlParameter param130 = null;
                        //    SqlParameter param131 = null;
                        //    SqlParameter param132 = null;
                        //    SqlParameter param133 = null;
                        //    SqlParameter param134 = null;
                        //    SqlParameter param135 = null;
                        //    SqlParameter param136 = null;
                        //    SqlParameter param137 = null;
                        //    SqlParameter param138 = null;
                        //    SqlParameter param139 = null;
                        //    SqlParameter param140 = null;
                        //    SqlParameter param141 = null;
                        //    SqlParameter param142 = null;
                        //    SqlParameter param143 = null;
                        //    SqlParameter param144 = null;
                        //    SqlParameter param145 = null;
                        //    SqlParameter param146 = null;
                        //    SqlParameter param147 = null;
                        //    SqlParameter param148 = null;
                        //    SqlParameter param149 = null;
                        //    SqlParameter param150 = null;
                        //    SqlParameter param151 = null;

                        //    int i = 0;
                        //    bool dirty = Convert.ToBoolean(0);

                        //    param1 = new SqlParameter("@Cashier_ID", "StoreID" + txt_emp_id.Text);
                        //    param2 = new SqlParameter("@CustNum", txt_customer.Text);
                        //    param3 = new SqlParameter("@Dept_ID", cmb_cetegory.Text);
                        //    param4 = new SqlParameter("@Password", txt_emp_passd.Text);
                        //    param5 = new SqlParameter("@Swipe_ID", txt_cardswip.Text);
                        //    param6 = new SqlParameter("@Hourly_Wage", txt_houlywages.Text);
                        //    param7 = new SqlParameter("@Form_Color ", i);
                        //    //param8 = new SqlParameter("@CDL", );
                        //    param9 = new SqlParameter("@Name", txt_customer.Text);
                        //    param10 = new SqlParameter("@CFA_Setup_Company", combo_check(setup_cmb));
                        //    param11 = new SqlParameter("@CFA_Setup_Tax", combo_check(tax_rate_cmb));
                        //    param12 = new SqlParameter("@CFA_Setup_Bonus", combo_check(bonus_plan_cmb));
                        //    param13 = new SqlParameter("@CFA_Setup_Accounting", combo_check(accountinginterface_cmb));
                        //    param14 = new SqlParameter("@CFA_Setup_Discounts", combo_check(discount_cmb));
                        //    param15 = new SqlParameter("@CFA_Setup_Display", combo_check(displaysetting_cmb));
                        //    param16 = new SqlParameter("@CFA_Setup_DefPrinter", combo_check(defaultprinter_cmb));
                        //    param17 = new SqlParameter("@CFA_Inven_Add", combo_check(add_inventory_cmb));
                        //    param18 = new SqlParameter("@CFA_Inven_Edit", combo_check(Inventory_edit_cmb));
                        //    param19 = new SqlParameter("@CFA_Vendors_Add", combo_check(add_vendor_cmb));
                        //    param20 = new SqlParameter("@CFA_Vendors_Edit", combo_check(update_vendor_cmb));
                        //    param21 = new SqlParameter("@CFA_Depts_Add", combo_check(add_department_cmb));
                        //    param22 = new SqlParameter("@CFA_Depts_Edit", combo_check(edit_department_cmb));
                        //    param23 = new SqlParameter("@CFA_Inven_TickVouch", combo_check(delete_inventory_cmb));
                        //    param24 = new SqlParameter("@CFA_Cust_add", combo_check(add_customer_cmb));
                        //    param25 = new SqlParameter("@CFA_Cust_Edit", combo_check(edit_customer_cmb));
                        //    param26 = new SqlParameter("@CFA_Reports_Display", combo_check(display_reports_cmb));
                        //    param27 = new SqlParameter("@CFA_Reports_DDR", combo_check(ddr_print_cmb));
                        //    param28 = new SqlParameter("@CFA_Reports_Print", combo_check(print_reports_cmb));
                        //    param29 = new SqlParameter("@CFA_Invoice_Discount", combo_check(invoice_discount_cmb));
                        //    param30 = new SqlParameter("@CFA_Invoice_PriceChange", combo_check(modify_price_cmb));
                        //    param31 = new SqlParameter("@CFA_Invoice_DeleteItems", combo_check(delete_items_cmb));
                        //    param32 = new SqlParameter("@CFA_Invoice_Void", combo_check(void_invoice_cmb));
                        //    param33 = new SqlParameter("@CFA_CRE_Acct", combo_check(accountinginterface_cmb));
                        //    param34 = new SqlParameter("@CFA_CRE_Exit", combo_check(allow_exit_cmb));
                        //    param35 = new SqlParameter("@Dirty", dirty);
                        //    //param36 = new SqlParameter("@Last_DDR ", combo_check());
                        //    param37 = new SqlParameter("@CFA_Display_Balance", combo_check(display_balance_cmb));
                        //    param38 = new SqlParameter("@CFA_Refund_Item", combo_check(override_refund_cmb));
                        //    param39 = new SqlParameter("@Disp_Pay_Option", dirty);
                        //    param40 = new SqlParameter("@Disp_Item_Option ", dirty);
                        //    //param41 = new SqlParameter("@EmpName ", );
                        //    param42 = new SqlParameter("@CFA_Receive_Items", combo_check(po_receive_item_cmb));
                        //    param43 = new SqlParameter("@CFA_DO_POS", combo_check(create_po_cmb));
                        //    param44 = new SqlParameter("@CFA_INSTANT_POS", combo_check(instant_po_cmb));
                        //    //param45 = new SqlParameter("@Section_ID ", stat);
                        //    param46 = new SqlParameter("@CFA_Other_Tables", combo_check(other_tables_cmb));
                        //    param47 = new SqlParameter("@CFA_Accept_Cash", combo_check(cash_pickups_cmb));
                        //    param48 = new SqlParameter("@CFA_TRANSFER_NOSWIPE", combo_check(transfer_without_cmb));
                        //    param49 = new SqlParameter("@CFA_ADD_CCTIPS", combo_check(cc_tips_cmb));
                        //    param50 = new SqlParameter("@Disabled", dirty);
                        //    param51 = new SqlParameter("@Admin_Access ", dirty);
                        //    param52 = new SqlParameter("@CFA_PRINT_HOLD", combo_check(hold_print_cmb));
                        //    param53 = new SqlParameter("@CFA_Open_Cash_Drawer", combo_check(open_cash_cmb));
                        //    param54 = new SqlParameter("@CCTipsNow", dirty);
                        //    param55 = new SqlParameter("@ReqClockIn", dirty);
                        //    param56 = new SqlParameter("@CFA_Split_Checks", combo_check(split_checks_cmb));
                        //    param57 = new SqlParameter("@CFA_Transfer_Tables", combo_check(transfer_tables_cmb));
                        //    //param58 = new SqlParameter("@CFA_Extra_Item ", combo_check());
                        //    param59 = new SqlParameter("@CFA_Tax_Exempt", combo_check(tax_ex_cmb));
                        //    param60 = new SqlParameter("@CFA_GC_Sell", combo_check(sell_giftc_cmb));
                        //    param61 = new SqlParameter("@CFA_GC_Redeem", combo_check(redeem_giftc_cmb));
                        //    param62 = new SqlParameter("@CFA_SELL_SPECIAL_ITEM ", combo_check(sell_special_cmb));
                        //    param63 = new SqlParameter("@CFA_VENDOR_PAYOUT", combo_check(vendor_payouts_cmb));
                        //    param64 = new SqlParameter("@CFA_APPLY_GRATUITY", combo_check(apply_gratuity_cmb));
                        //    param65 = new SqlParameter("@First_Name", txt_first_name.Text);
                        //    param66 = new SqlParameter("@Middle_Name", txt_middle_name.Text);
                        //    param67 = new SqlParameter("@Last_Name", txt_last_name.Text);
                        //    param68 = new SqlParameter("@SSN", txt_SSN.Text);
                        //    param69 = new SqlParameter("@Address_1", address_1_txt.Text);
                        //    param70 = new SqlParameter("@Address_2", address_2_txt.Text);
                        //    param71 = new SqlParameter("@City", txt_city.Text);
                        //    param72 = new SqlParameter("@State", txt_state.Text);
                        //    param73 = new SqlParameter("@Zip_Code", txt_zipcode.Text);
                        //    param74 = new SqlParameter("@Phone_1", txt_phone.Text);
                        //    param75 = new SqlParameter("@EMail", txt_email.Text);
                        //    param76 = new SqlParameter("@Birthday", txt_birthday.Text);
                        //    //param77 = new SqlParameter("@Picture ", );
                        //    param78 = new SqlParameter("@CFA_BUYBACKS_TRADES", combo_check(buyback_trade_cmb));
                        //    param79 = new SqlParameter("@CFA_CC_Force", combo_check(force_credit_cmb));
                        //    //param80 = new SqlParameter("@CFA_CC_Below_Floor ", combo_check());
                        //    //param81 = new SqlParameter("@Current_Cash ", );
                        //    param82 = new SqlParameter("@CFA_Cash_Alerts", combo_check(cas_alert_cmb));
                        //    param83 = new SqlParameter("@CFA_Cash_Pickup", combo_check(cash_pickups_cmb));
                        //    //param84 = new SqlParameter("@CDL_Stations_ID ", combo_check());
                        //    param85 = new SqlParameter("@CFA_Issue_Credit_Slip", combo_check(issue_credit_cmb));
                        //    param86 = new SqlParameter("@CFA_Redeem_Credit_Slip", combo_check(redeem_credit_slip));
                        //    param87 = new SqlParameter("@CFA_REFUND_OVERRIDE", combo_check(override_refund_cmb));
                        //    param88 = new SqlParameter("@CFA_DRAWER_TRANSFER", combo_check(drawer_transfer_cmb));
                        //    param89 = new SqlParameter("@CFA_LARGE_PURCHASES", combo_check(allow_large_purchase_cmb));
                        //    //param90 = new SqlParameter("@CFA_AUCTION_PHOTO ", combo_check());
                        //    //param91 = new SqlParameter("@CFA_AUCTION_LISTREDEEM ", combo_check(auc));
                        //    //param92 = new SqlParameter("@CFA_AUCTION_SHIP ", );
                        //    param93 = new SqlParameter("@CFA_APPROVE_CASHCOUNT", combo_check(approve_cash_count_cmb));
                        //    //param94 = new SqlParameter("@Orig_Emp_ID ", );
                        //    //param95 = new SqlParameter("@Orig_Store_ID ", );
                        //    //param96 = new SqlParameter("@CD_Name ", txt_c);
                        //    param97 = new SqlParameter("@CFA_APPROVE_OLD_RETURNS", combo_check(allow_old_return_cmb));
                        //    param98 = new SqlParameter("@CFA_APPROVE_EMERGENCY_CLOCKOUT", combo_check(approve_emer_cmb));
                        //    //param99 = new SqlParameter("@TimeWorkedThisPeriod ", combo_check(w));
                        //    param100 = new SqlParameter("@OvertimeThreshold", txt_start_overtime.Text);
                        //    param101 = new SqlParameter("@CFA_PULLBACK_INVOICE", combo_check(pullback_cmb));
                        //    //param102 = new SqlParameter("@CFA_MANAGE_TIMECLOCK ", combo_check(to));
                        //    param103 = new SqlParameter("@CFA_PERFORM_ENDOFDAY", combo_check(perform_endofday_cmb));
                        //    param104 = new SqlParameter("@CFA_HOST_LOGIN", combo_check(host_module_cmb));
                        //    param105 = new SqlParameter("@CFA_REST_OPENTABS", combo_check(open_tabs_cmb));
                        //    param106 = new SqlParameter("@CFA_REST_TAKEOUT ", combo_check(take_out_orders_cmb));
                        //    param107 = new SqlParameter("@CFA_REST_DELIVERY ", combo_check(delivery_orders_cmb));
                        //    param108 = new SqlParameter("@CFA_INVOICE_DELETESENT ", combo_check(invoice_price_change_cmb));
                        //    param109 = new SqlParameter("@CFA_INVEN_VIEW ", combo_check(view_inventory_cmb));
                        //    param110 = new SqlParameter("@CFA_INVEN_VIEWCOST ", combo_check(view_inventory_cost));
                        //    param111 = new SqlParameter("@CFA_INVEN_NEGATIVE_INSTANTPOS ", combo_check(instant_po_cmb));
                        //    param112 = new SqlParameter("@CFA_ENDTRANS_CASH ", combo_check(end_cash_cmb));
                        //    param113 = new SqlParameter("@CFA_ENDTRANS_ACCOUNT ", combo_check(end_transaction_cmb));
                        //    //param114 = new SqlParameter("@CFA_REST_COMP ", combo_check(com));
                        //    param115 = new SqlParameter("@CFA_CH_FORCE ", combo_check(force_check_cmb));
                        //    param116 = new SqlParameter("@CFA_TS_CONFIG ", combo_check(configure_virtual_cmb));
                        //    param117 = new SqlParameter("@CFA_TRANSFER_SERVER ", combo_check(transfer_servers_cmb));
                        //    param118 = new SqlParameter("@CFA_BACKUP_DATABASE ", combo_check(backup_database_cmb));
                        //    param119 = new SqlParameter("@CFA_CREDIT_CARD_SETTLEMENT ", combo_check(settle_credit_cmb));
                        //    param120 = new SqlParameter("@CFA_KITCHEN_REPRINT ", combo_check(reprint_kitchen_cmb));
                        //    param121 = new SqlParameter("@CFA_SETUP_RECEIPT_NOTES ", combo_check(configure_receipt_cmb));
                        //    //param122 = new SqlParameter("@CFA_MANAGE_TIMECLOCK_OWNTIME ", combo_check());
                        //    param123 = new SqlParameter("@CFA_SETUP_ADD_EMPLOYEES ", combo_check(add_employee_cmb));
                        //    param124 = new SqlParameter("@CFA_SETUP_EDIT_EMPLOYEES ", combo_check(modify_employee_cmb));
                        //    //param125 = new SqlParameter("@CFA_INVENTORY_PROMOTIONS ", combo_check(promost));
                        //    //param126 = new SqlParameter("@CFA_INVOICE_DISCOUNTS_BELOW_X ", combo_check(discou));
                        //    //param127 = new SqlParameter("@CFA_BUYBACKTRADE_ABOVE_SET_AMOUNT ", combo_check());
                        //    param128 = new SqlParameter("@CFA_REPORTS_VIEW_HISTORICAL_DATA ", combo_check(view_historical_cmb));
                        //    param129 = new SqlParameter("@CFA_INVEN_MISC_FIELD_LOCKDOWN ", combo_check(limited_edit_lockdown_cmb));
                        //    param130 = new SqlParameter("@CFA_HH_Create_PO ", combo_check(create_po_cmb));
                        //    param131 = new SqlParameter("@CFA_HH_DSD ", combo_check(DSD_cmb));
                        //    param132 = new SqlParameter("@CFA_HH_DSD_Credit ", combo_check(DSD_credit_cmb));
                        //    param133 = new SqlParameter("@CFA_HH_PO_Receive ", combo_check(po_receive_item_cmb));
                        //    param134 = new SqlParameter("@CFA_HH_Inv_Edit ", combo_check(Inventory_edit_cmb));
                        //    param135 = new SqlParameter("@CFA_HH_Inv_Adjust ", combo_check(inventory_adjust_cmb));
                        //    param136 = new SqlParameter("@CFA_HH_Inv_Count ", combo_check(inventory_count_cmb));
                        //    param137 = new SqlParameter("@CFA_HH_Setup ", combo_check(setup_cmb));
                        //    //param138 = new SqlParameter("@CFA_CASHIER_OVERRIDE_LICENSESCAN ", combo_check(overr));
                        //    param139 = new SqlParameter("@CFA_INVEN_DELETE ", combo_check(delete_inventory_cmb));
                        //    param140 = new SqlParameter("@CFA_CASHIER_MANUALY_ENTER_AGE ", combo_check(manual_age_cmb));
                        //    //param141 = new SqlParameter("@CreateDate ", );
                        //    //param142 = new SqlParameter("@DateDisabled ", );
                        //    param143 = new SqlParameter("@CFA_INVEN_ADD_COUPON ", combo_check(add_coupons_cmb));
                        //    param144 = new SqlParameter("@CFA_INVEN_GLOBALPRICING ", combo_check(global_pricing_cmb));
                        //    param145 = new SqlParameter("@CFA_EMP_SCHEDULE_OVERRIDE ", combo_check(labor_schedule_cmb));
                        //    param146 = new SqlParameter("@CFA_LABOR_SCHEDULER ", combo_check(labor_schedule_cmb));
                        //    //param147 = new SqlParameter("@GLNumber ", combo_check());
                        //    param148 = new SqlParameter("@CFA_NEGATIVE_PRICE_CHANGE ", combo_check(negative_price_cmb));
                        //    param149 = new SqlParameter("@CFA_CUSTOMER_EDIT_CHARGEATCOST ", combo_check(charge_at_cost_cmb));
                        //    param150 = new SqlParameter("@CFA_GPI_FUEL_DRIVE_OFF ", combo_check(fuel_off_cmb));
                        //    //param151 = new SqlParameter("@CFA_SETUP_VPDCONFIGURATION ", );


                        //    cmd.Parameters.Add(param1);
                        //    cmd.Parameters.Add(param2);
                        //    cmd.Parameters.Add(param3);
                        //    cmd.Parameters.Add(param4);
                        //    cmd.Parameters.Add(param5);
                        //    cmd.Parameters.Add(param6);
                        //    cmd.Parameters.Add(param7);
                        //    //cmd.Parameters.Add(param8);
                        //    cmd.Parameters.Add(param9);
                        //    cmd.Parameters.Add(param10);
                        //    cmd.Parameters.Add(param11);
                        //    cmd.Parameters.Add(param12);
                        //    cmd.Parameters.Add(param13);
                        //    cmd.Parameters.Add(param14);
                        //    cmd.Parameters.Add(param15);
                        //    cmd.Parameters.Add(param16);
                        //    cmd.Parameters.Add(param17);
                        //    cmd.Parameters.Add(param18);
                        //    cmd.Parameters.Add(param19);
                        //    cmd.Parameters.Add(param20);
                        //    cmd.Parameters.Add(param21);
                        //    cmd.Parameters.Add(param22);
                        //    cmd.Parameters.Add(param23);
                        //    cmd.Parameters.Add(param24);
                        //    cmd.Parameters.Add(param25);
                        //    cmd.Parameters.Add(param26);
                        //    cmd.Parameters.Add(param27);
                        //    cmd.Parameters.Add(param28);
                        //    cmd.Parameters.Add(param29);
                        //    cmd.Parameters.Add(param30);
                        //    cmd.Parameters.Add(param31);
                        //    cmd.Parameters.Add(param32);
                        //    cmd.Parameters.Add(param33);
                        //    cmd.Parameters.Add(param34);
                        //    cmd.Parameters.Add(param35);
                        //    //cmd.Parameters.Add(param36);
                        //    cmd.Parameters.Add(param37);
                        //    cmd.Parameters.Add(param38);
                        //    cmd.Parameters.Add(param39);
                        //    cmd.Parameters.Add(param40);
                        //    //cmd.Parameters.Add(param41);
                        //    cmd.Parameters.Add(param42);
                        //    cmd.Parameters.Add(param43);
                        //    cmd.Parameters.Add(param44);
                        //    //cmd.Parameters.Add(param45);
                        //    cmd.Parameters.Add(param46);
                        //    cmd.Parameters.Add(param47);
                        //    cmd.Parameters.Add(param48);
                        //    cmd.Parameters.Add(param49);
                        //    cmd.Parameters.Add(param50);
                        //    cmd.Parameters.Add(param51);
                        //    cmd.Parameters.Add(param52);
                        //    cmd.Parameters.Add(param53);
                        //    cmd.Parameters.Add(param54);
                        //    cmd.Parameters.Add(param55);
                        //    cmd.Parameters.Add(param56);
                        //    cmd.Parameters.Add(param57);
                        //    //cmd.Parameters.Add(param58);
                        //    cmd.Parameters.Add(param59);
                        //    cmd.Parameters.Add(param60);
                        //    cmd.Parameters.Add(param61);
                        //    cmd.Parameters.Add(param62);
                        //    cmd.Parameters.Add(param63);
                        //    cmd.Parameters.Add(param64);
                        //    cmd.Parameters.Add(param65);
                        //    cmd.Parameters.Add(param66);
                        //    cmd.Parameters.Add(param67);
                        //    cmd.Parameters.Add(param68);
                        //    cmd.Parameters.Add(param69);
                        //    cmd.Parameters.Add(param70);
                        //    cmd.Parameters.Add(param71);
                        //    cmd.Parameters.Add(param72);
                        //    cmd.Parameters.Add(param73);
                        //    cmd.Parameters.Add(param74);
                        //    cmd.Parameters.Add(param75);
                        //    cmd.Parameters.Add(param76);
                        //    //cmd.Parameters.Add(param77);
                        //    cmd.Parameters.Add(param78);
                        //    cmd.Parameters.Add(param79);
                        //    //cmd.Parameters.Add(param80);
                        //    //cmd.Parameters.Add(param81);
                        //    cmd.Parameters.Add(param82);
                        //    cmd.Parameters.Add(param83);
                        //    //cmd.Parameters.Add(param84);
                        //    cmd.Parameters.Add(param85);
                        //    cmd.Parameters.Add(param86);
                        //    cmd.Parameters.Add(param87);
                        //    cmd.Parameters.Add(param88);
                        //    cmd.Parameters.Add(param89);
                        //    //cmd.Parameters.Add(param90);
                        //    //cmd.Parameters.Add(param91);
                        //    //cmd.Parameters.Add(param92);
                        //    cmd.Parameters.Add(param93);
                        //    //cmd.Parameters.Add(param94);
                        //    //cmd.Parameters.Add(param95);
                        //    //cmd.Parameters.Add(param96);
                        //    cmd.Parameters.Add(param97);
                        //    cmd.Parameters.Add(param98);
                        //    //cmd.Parameters.Add(param99);
                        //    cmd.Parameters.Add(param100);
                        //    cmd.Parameters.Add(param101);
                        //    //cmd.Parameters.Add(param102);
                        //    cmd.Parameters.Add(param103);
                        //    cmd.Parameters.Add(param104);
                        //    cmd.Parameters.Add(param105);
                        //    cmd.Parameters.Add(param106);
                        //    cmd.Parameters.Add(param107);
                        //    cmd.Parameters.Add(param108);
                        //    cmd.Parameters.Add(param109);
                        //    cmd.Parameters.Add(param110);
                        //    cmd.Parameters.Add(param111);
                        //    cmd.Parameters.Add(param112);
                        //    cmd.Parameters.Add(param113);
                        //    //cmd.Parameters.Add(param114);
                        //    cmd.Parameters.Add(param115);
                        //    cmd.Parameters.Add(param116);
                        //    cmd.Parameters.Add(param117);
                        //    cmd.Parameters.Add(param118);
                        //    cmd.Parameters.Add(param119);
                        //    cmd.Parameters.Add(param120);
                        //    cmd.Parameters.Add(param121);
                        //    //cmd.Parameters.Add(param122);
                        //    cmd.Parameters.Add(param123);
                        //    cmd.Parameters.Add(param124);
                        //    //cmd.Parameters.Add(param125);
                        //    //cmd.Parameters.Add(param126);
                        //    //cmd.Parameters.Add(param127);
                        //    cmd.Parameters.Add(param128);
                        //    cmd.Parameters.Add(param129);
                        //    cmd.Parameters.Add(param130);
                        //    cmd.Parameters.Add(param131);
                        //    cmd.Parameters.Add(param132);
                        //    cmd.Parameters.Add(param133);
                        //    cmd.Parameters.Add(param134);
                        //    cmd.Parameters.Add(param135);
                        //    cmd.Parameters.Add(param136);
                        //    cmd.Parameters.Add(param137);
                        //    //cmd.Parameters.Add(param138);
                        //    cmd.Parameters.Add(param139);
                        //    cmd.Parameters.Add(param140);
                        //    //cmd.Parameters.Add(param141);
                        //    //cmd.Parameters.Add(param142);
                        //    cmd.Parameters.Add(param143);
                        //    cmd.Parameters.Add(param144);
                        //    cmd.Parameters.Add(param145);
                        //    cmd.Parameters.Add(param146);
                        //    //cmd.Parameters.Add(param147);
                        //    cmd.Parameters.Add(param148);
                        //    cmd.Parameters.Add(param149);
                        //    cmd.Parameters.Add(param150);
                        //    //cmd.Parameters.Add(param151);

                        //    cmd.ExecuteNonQuery();

                        //    #endregion
                        //}
                        //glo.con.Close();
                    }
                    else
                    {
                        MessageBox.Show("You must enter Employe Id ","Run Time Support",MessageBoxButton.OK,MessageBoxImage.Warning);
                    }

                    fun_clear_fields();
                    cmb_search_emp.Items.Clear();
                    fill_employee();
                }
        }

        public void fill_employee()
        {
            //glo.con.Open();

            //SqlCommand com = new SqlCommand("SELECT Cashier_ID from Employee", glo.con);
            //SqlDataReader rr = com.ExecuteReader();

            //while (rr.Read())
            //{
            //    cmb_search_emp.Items.Add(Convert.ToString(rr["Cashier_ID"]));
            //}
            //rr.Close();
            //glo.con.Close();
        }

        public bool yesno_checker(ComboBox x)
        {
            if (x.SelectedValue == "Yes")
            {
                return Convert.ToBoolean("1");
            }
            else if (x.SelectedValue == "No")
            {
                return Convert.ToBoolean("0");
            }

            return Convert.ToBoolean("1");
        }

        public string combo_check(ComboBox x)
        {
            string value = null;

            if (x.Text == "Prompt")
            {
                value = "P";
            }
            else if (x.Text == "Override")
            {
                value = "O";
            }
            else if (x.Text == "Yes")
            {
                value = "Y";
            }
            else if (x.Text == "No")
            {
                value = "N";
            }
            return value;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillCombo();
        }

        public void FillCombo()
        {
            DepartmentClass objDept = new DepartmentClass();

            
        }

        private void btn_savechages_emp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(txt_emp_id.Text != "")
                {
                   
                }
                else
                {
                    MessageBox.Show("You must enter Employe Id ", "Run Time Support", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
 
            }
            //if (txt_emp_id.Text != "")
            //{
            //    glo.con.Open();
            //    using (SqlCommand cmd = new SqlCommand("SP_UPDATE_EMPLOYEE", glo.con))
            //    {
            //        #region STORED PROCEDURE TO UPDATE EMPLOYEE DETAILS TO EMPLOYEE TABLE BY WAQAR
            //        cmd.CommandType = CommandType.StoredProcedure;

            //        SqlParameter param1 = null;
            //        SqlParameter param2 = null;
            //        SqlParameter param3 = null;
            //        SqlParameter param4 = null;
            //        SqlParameter param5 = null;
            //        SqlParameter param6 = null;
            //        SqlParameter param7 = null;
            //        SqlParameter param8 = null;
            //        SqlParameter param9 = null;
            //        SqlParameter param10 = null;
            //        SqlParameter param11 = null;
            //        SqlParameter param12 = null;
            //        SqlParameter param13 = null;
            //        SqlParameter param14 = null;
            //        SqlParameter param15 = null;
            //        SqlParameter param16 = null;
            //        SqlParameter param17 = null;
            //        SqlParameter param18 = null;
            //        SqlParameter param19 = null;
            //        SqlParameter param20 = null;
            //        SqlParameter param21 = null;
            //        SqlParameter param22 = null;
            //        SqlParameter param23 = null;
            //        SqlParameter param24 = null;
            //        SqlParameter param25 = null;
            //        SqlParameter param26 = null;
            //        SqlParameter param27 = null;
            //        SqlParameter param28 = null;
            //        SqlParameter param29 = null;
            //        SqlParameter param30 = null;
            //        SqlParameter param31 = null;
            //        SqlParameter param32 = null;
            //        SqlParameter param33 = null;
            //        SqlParameter param34 = null;
            //        SqlParameter param35 = null;
            //        SqlParameter param36 = null;
            //        SqlParameter param37 = null;
            //        SqlParameter param38 = null;
            //        SqlParameter param39 = null;
            //        SqlParameter param40 = null;
            //        SqlParameter param41 = null;
            //        SqlParameter param42 = null;
            //        SqlParameter param43 = null;
            //        SqlParameter param44 = null;
            //        SqlParameter param45 = null;
            //        SqlParameter param46 = null;
            //        SqlParameter param47 = null;
            //        SqlParameter param48 = null;
            //        SqlParameter param49 = null;
            //        SqlParameter param50 = null;
            //        SqlParameter param51 = null;
            //        SqlParameter param52 = null;
            //        SqlParameter param53 = null;
            //        SqlParameter param54 = null;
            //        SqlParameter param55 = null;
            //        SqlParameter param56 = null;
            //        SqlParameter param57 = null;
            //        SqlParameter param58 = null;
            //        SqlParameter param59 = null;
            //        SqlParameter param60 = null;
            //        SqlParameter param61 = null;
            //        SqlParameter param62 = null;
            //        SqlParameter param63 = null;
            //        SqlParameter param64 = null;
            //        SqlParameter param65 = null;
            //        SqlParameter param66 = null;
            //        SqlParameter param67 = null;
            //        SqlParameter param68 = null;
            //        SqlParameter param69 = null;
            //        SqlParameter param70 = null;
            //        SqlParameter param71 = null;
            //        SqlParameter param72 = null;
            //        SqlParameter param73 = null;
            //        SqlParameter param74 = null;
            //        SqlParameter param75 = null;
            //        SqlParameter param76 = null;
            //        SqlParameter param77 = null;
            //        SqlParameter param78 = null;
            //        SqlParameter param79 = null;
            //        SqlParameter param80 = null;
            //        SqlParameter param81 = null;
            //        SqlParameter param82 = null;
            //        SqlParameter param83 = null;
            //        SqlParameter param84 = null;
            //        SqlParameter param85 = null;
            //        SqlParameter param86 = null;
            //        SqlParameter param87 = null;
            //        SqlParameter param88 = null;
            //        SqlParameter param89 = null;
            //        SqlParameter param90 = null;
            //        SqlParameter param91 = null;
            //        SqlParameter param92 = null;
            //        SqlParameter param93 = null;
            //        SqlParameter param94 = null;
            //        SqlParameter param95 = null;
            //        SqlParameter param96 = null;
            //        SqlParameter param97 = null;
            //        SqlParameter param98 = null;
            //        SqlParameter param99 = null;
            //        SqlParameter param100 = null;
            //        SqlParameter param101 = null;
            //        SqlParameter param102 = null;
            //        SqlParameter param103 = null;
            //        SqlParameter param104 = null;
            //        SqlParameter param105 = null;
            //        SqlParameter param106 = null;
            //        SqlParameter param107 = null;
            //        SqlParameter param108 = null;
            //        SqlParameter param109 = null;
            //        SqlParameter param110 = null;
            //        SqlParameter param111 = null;
            //        SqlParameter param112 = null;
            //        SqlParameter param113 = null;
            //        SqlParameter param114 = null;
            //        SqlParameter param115 = null;
            //        SqlParameter param116 = null;
            //        SqlParameter param117 = null;
            //        SqlParameter param118 = null;
            //        SqlParameter param119 = null;
            //        SqlParameter param120 = null;
            //        SqlParameter param121 = null;
            //        SqlParameter param122 = null;
            //        SqlParameter param123 = null;
            //        SqlParameter param124 = null;
            //        SqlParameter param125 = null;
            //        SqlParameter param126 = null;
            //        SqlParameter param127 = null;
            //        SqlParameter param128 = null;
            //        SqlParameter param129 = null;
            //        SqlParameter param130 = null;
            //        SqlParameter param131 = null;
            //        SqlParameter param132 = null;
            //        SqlParameter param133 = null;
            //        SqlParameter param134 = null;
            //        SqlParameter param135 = null;
            //        SqlParameter param136 = null;
            //        SqlParameter param137 = null;
            //        SqlParameter param138 = null;
            //        SqlParameter param139 = null;
            //        SqlParameter param140 = null;
            //        SqlParameter param141 = null;
            //        SqlParameter param142 = null;
            //        SqlParameter param143 = null;
            //        SqlParameter param144 = null;
            //        SqlParameter param145 = null;
            //        SqlParameter param146 = null;
            //        SqlParameter param147 = null;
            //        SqlParameter param148 = null;
            //        SqlParameter param149 = null;
            //        SqlParameter param150 = null;
            //        SqlParameter param151 = null;

            //        int i = 0;
            //        bool dirty = Convert.ToBoolean(0);

            //        param1 = new SqlParameter("@Cashier_ID", txt_emp_id.Text);
            //        param2 = new SqlParameter("@CustNum", txt_customer.Text);
            //        param3 = new SqlParameter("@Dept_ID", cmb_cetegory.Text);
            //        param4 = new SqlParameter("@Password", txt_emp_passd.Text);
            //        param5 = new SqlParameter("@Swipe_ID", txt_cardswip.Text);
            //        param6 = new SqlParameter("@Hourly_Wage", txt_houlywages.Text);
            //        param7 = new SqlParameter("@Form_Color ", i);
            //        //param8 = new SqlParameter("@CDL", );
            //        param9 = new SqlParameter("@Name", txt_customer.Text);
            //        param10 = new SqlParameter("@CFA_Setup_Company", combo_check(setup_cmb));
            //        param11 = new SqlParameter("@CFA_Setup_Tax", combo_check(tax_rate_cmb));
            //        param12 = new SqlParameter("@CFA_Setup_Bonus", combo_check(bonus_plan_cmb));
            //        param13 = new SqlParameter("@CFA_Setup_Accounting", combo_check(accountinginterface_cmb));
            //        param14 = new SqlParameter("@CFA_Setup_Discounts", combo_check(discount_cmb));
            //        param15 = new SqlParameter("@CFA_Setup_Display", combo_check(displaysetting_cmb));
            //        param16 = new SqlParameter("@CFA_Setup_DefPrinter", combo_check(defaultprinter_cmb));
            //        param17 = new SqlParameter("@CFA_Inven_Add", combo_check(add_inventory_cmb));
            //        param18 = new SqlParameter("@CFA_Inven_Edit", combo_check(Inventory_edit_cmb));
            //        param19 = new SqlParameter("@CFA_Vendors_Add", combo_check(add_vendor_cmb));
            //        param20 = new SqlParameter("@CFA_Vendors_Edit", combo_check(update_vendor_cmb));
            //        param21 = new SqlParameter("@CFA_Depts_Add", combo_check(add_department_cmb));
            //        param22 = new SqlParameter("@CFA_Depts_Edit", combo_check(edit_department_cmb));
            //        param23 = new SqlParameter("@CFA_Inven_TickVouch", combo_check(delete_inventory_cmb));
            //        param24 = new SqlParameter("@CFA_Cust_add", combo_check(add_customer_cmb));
            //        param25 = new SqlParameter("@CFA_Cust_Edit", combo_check(edit_customer_cmb));
            //        param26 = new SqlParameter("@CFA_Reports_Display", combo_check(display_reports_cmb));
            //        param27 = new SqlParameter("@CFA_Reports_DDR", combo_check(ddr_print_cmb));
            //        param28 = new SqlParameter("@CFA_Reports_Print", combo_check(print_reports_cmb));
            //        param29 = new SqlParameter("@CFA_Invoice_Discount", combo_check(invoice_discount_cmb));
            //        param30 = new SqlParameter("@CFA_Invoice_PriceChange", combo_check(modify_price_cmb));
            //        param31 = new SqlParameter("@CFA_Invoice_DeleteItems", combo_check(delete_items_cmb));
            //        param32 = new SqlParameter("@CFA_Invoice_Void", combo_check(void_invoice_cmb));
            //        param33 = new SqlParameter("@CFA_CRE_Acct", combo_check(accountinginterface_cmb));
            //        param34 = new SqlParameter("@CFA_CRE_Exit", combo_check(allow_exit_cmb));
            //        param35 = new SqlParameter("@Dirty", dirty);
            //        //param36 = new SqlParameter("@Last_DDR ", combo_check());
            //        param37 = new SqlParameter("@CFA_Display_Balance", combo_check(display_balance_cmb));
            //        param38 = new SqlParameter("@CFA_Refund_Item", combo_check(override_refund_cmb));
            //        param39 = new SqlParameter("@Disp_Pay_Option", dirty);
            //        param40 = new SqlParameter("@Disp_Item_Option ", dirty);
            //        //param41 = new SqlParameter("@EmpName ", );
            //        param42 = new SqlParameter("@CFA_Receive_Items", combo_check(po_receive_item_cmb));
            //        param43 = new SqlParameter("@CFA_DO_POS", combo_check(create_po_cmb));
            //        param44 = new SqlParameter("@CFA_INSTANT_POS", combo_check(instant_po_cmb));
            //        //param45 = new SqlParameter("@Section_ID ", stat);
            //        param46 = new SqlParameter("@CFA_Other_Tables", combo_check(other_tables_cmb));
            //        param47 = new SqlParameter("@CFA_Accept_Cash", combo_check(cash_pickups_cmb));
            //        param48 = new SqlParameter("@CFA_TRANSFER_NOSWIPE", combo_check(transfer_without_cmb));
            //        param49 = new SqlParameter("@CFA_ADD_CCTIPS", combo_check(cc_tips_cmb));
            //        param50 = new SqlParameter("@Disabled", dirty);
            //        param51 = new SqlParameter("@Admin_Access ", dirty);
            //        param52 = new SqlParameter("@CFA_PRINT_HOLD", combo_check(hold_print_cmb));
            //        param53 = new SqlParameter("@CFA_Open_Cash_Drawer", combo_check(open_cash_cmb));
            //        param54 = new SqlParameter("@CCTipsNow", dirty);
            //        param55 = new SqlParameter("@ReqClockIn", dirty);
            //        param56 = new SqlParameter("@CFA_Split_Checks", combo_check(split_checks_cmb));
            //        param57 = new SqlParameter("@CFA_Transfer_Tables", combo_check(transfer_tables_cmb));
            //        //param58 = new SqlParameter("@CFA_Extra_Item ", combo_check());
            //        param59 = new SqlParameter("@CFA_Tax_Exempt", combo_check(tax_ex_cmb));
            //        param60 = new SqlParameter("@CFA_GC_Sell", combo_check(sell_giftc_cmb));
            //        param61 = new SqlParameter("@CFA_GC_Redeem", combo_check(redeem_giftc_cmb));
            //        param62 = new SqlParameter("@CFA_SELL_SPECIAL_ITEM ", combo_check(sell_special_cmb));
            //        param63 = new SqlParameter("@CFA_VENDOR_PAYOUT", combo_check(vendor_payouts_cmb));
            //        param64 = new SqlParameter("@CFA_APPLY_GRATUITY", combo_check(apply_gratuity_cmb));
            //        param65 = new SqlParameter("@First_Name", txt_first_name.Text);
            //        param66 = new SqlParameter("@Middle_Name", txt_middle_name.Text);
            //        param67 = new SqlParameter("@Last_Name", txt_last_name.Text);
            //        param68 = new SqlParameter("@SSN", txt_SSN.Text);
            //        param69 = new SqlParameter("@Address_1", address_1_txt.Text);
            //        param70 = new SqlParameter("@Address_2", address_2_txt.Text);
            //        param71 = new SqlParameter("@City", txt_city.Text);
            //        param72 = new SqlParameter("@State", txt_state.Text);
            //        param73 = new SqlParameter("@Zip_Code", txt_zipcode.Text);
            //        param74 = new SqlParameter("@Phone_1", txt_phone.Text);
            //        param75 = new SqlParameter("@EMail", txt_email.Text);
            //        param76 = new SqlParameter("@Birthday", txt_birthday.Text);
            //        //param77 = new SqlParameter("@Picture ", );
            //        param78 = new SqlParameter("@CFA_BUYBACKS_TRADES", combo_check(buyback_trade_cmb));
            //        param79 = new SqlParameter("@CFA_CC_Force", combo_check(force_credit_cmb));
            //        //param80 = new SqlParameter("@CFA_CC_Below_Floor ", combo_check());
            //        //param81 = new SqlParameter("@Current_Cash ", );
            //        param82 = new SqlParameter("@CFA_Cash_Alerts", combo_check(cas_alert_cmb));
            //        param83 = new SqlParameter("@CFA_Cash_Pickup", combo_check(cash_pickups_cmb));
            //        //param84 = new SqlParameter("@CDL_Stations_ID ", combo_check());
            //        param85 = new SqlParameter("@CFA_Issue_Credit_Slip", combo_check(issue_credit_cmb));
            //        param86 = new SqlParameter("@CFA_Redeem_Credit_Slip", combo_check(redeem_credit_slip));
            //        param87 = new SqlParameter("@CFA_REFUND_OVERRIDE", combo_check(override_refund_cmb));
            //        param88 = new SqlParameter("@CFA_DRAWER_TRANSFER", combo_check(drawer_transfer_cmb));
            //        param89 = new SqlParameter("@CFA_LARGE_PURCHASES", combo_check(allow_large_purchase_cmb));
            //        //param90 = new SqlParameter("@CFA_AUCTION_PHOTO ", combo_check());
            //        //param91 = new SqlParameter("@CFA_AUCTION_LISTREDEEM ", combo_check(auc));
            //        //param92 = new SqlParameter("@CFA_AUCTION_SHIP ", );
            //        param93 = new SqlParameter("@CFA_APPROVE_CASHCOUNT", combo_check(approve_cash_count_cmb));
            //        //param94 = new SqlParameter("@Orig_Emp_ID ", );
            //        //param95 = new SqlParameter("@Orig_Store_ID ", );
            //        //param96 = new SqlParameter("@CD_Name ", txt_c);
            //        param97 = new SqlParameter("@CFA_APPROVE_OLD_RETURNS", combo_check(allow_old_return_cmb));
            //        param98 = new SqlParameter("@CFA_APPROVE_EMERGENCY_CLOCKOUT", combo_check(approve_emer_cmb));
            //        //param99 = new SqlParameter("@TimeWorkedThisPeriod ", combo_check(w));
            //        param100 = new SqlParameter("@OvertimeThreshold", txt_start_overtime.Text);
            //        param101 = new SqlParameter("@CFA_PULLBACK_INVOICE", combo_check(pullback_cmb));
            //        //param102 = new SqlParameter("@CFA_MANAGE_TIMECLOCK ", combo_check(to));
            //        param103 = new SqlParameter("@CFA_PERFORM_ENDOFDAY", combo_check(perform_endofday_cmb));
            //        param104 = new SqlParameter("@CFA_HOST_LOGIN", combo_check(host_module_cmb));
            //        param105 = new SqlParameter("@CFA_REST_OPENTABS", combo_check(open_tabs_cmb));
            //        param106 = new SqlParameter("@CFA_REST_TAKEOUT ", combo_check(take_out_orders_cmb));
            //        param107 = new SqlParameter("@CFA_REST_DELIVERY ", combo_check(delivery_orders_cmb));
            //        param108 = new SqlParameter("@CFA_INVOICE_DELETESENT ", combo_check(invoice_price_change_cmb));
            //        param109 = new SqlParameter("@CFA_INVEN_VIEW ", combo_check(view_inventory_cmb));
            //        param110 = new SqlParameter("@CFA_INVEN_VIEWCOST ", combo_check(view_inventory_cost));
            //        param111 = new SqlParameter("@CFA_INVEN_NEGATIVE_INSTANTPOS ", combo_check(instant_po_cmb));
            //        param112 = new SqlParameter("@CFA_ENDTRANS_CASH ", combo_check(end_cash_cmb));
            //        param113 = new SqlParameter("@CFA_ENDTRANS_ACCOUNT ", combo_check(end_transaction_cmb));
            //        //param114 = new SqlParameter("@CFA_REST_COMP ", combo_check(com));
            //        param115 = new SqlParameter("@CFA_CH_FORCE ", combo_check(force_check_cmb));
            //        param116 = new SqlParameter("@CFA_TS_CONFIG ", combo_check(configure_virtual_cmb));
            //        param117 = new SqlParameter("@CFA_TRANSFER_SERVER ", combo_check(transfer_servers_cmb));
            //        param118 = new SqlParameter("@CFA_BACKUP_DATABASE ", combo_check(backup_database_cmb));
            //        param119 = new SqlParameter("@CFA_CREDIT_CARD_SETTLEMENT ", combo_check(settle_credit_cmb));
            //        param120 = new SqlParameter("@CFA_KITCHEN_REPRINT ", combo_check(reprint_kitchen_cmb));
            //        param121 = new SqlParameter("@CFA_SETUP_RECEIPT_NOTES ", combo_check(configure_receipt_cmb));
            //        //param122 = new SqlParameter("@CFA_MANAGE_TIMECLOCK_OWNTIME ", combo_check());
            //        param123 = new SqlParameter("@CFA_SETUP_ADD_EMPLOYEES ", combo_check(add_employee_cmb));
            //        param124 = new SqlParameter("@CFA_SETUP_EDIT_EMPLOYEES ", combo_check(modify_employee_cmb));
            //        //param125 = new SqlParameter("@CFA_INVENTORY_PROMOTIONS ", combo_check(promost));
            //        //param126 = new SqlParameter("@CFA_INVOICE_DISCOUNTS_BELOW_X ", combo_check(discou));
            //        //param127 = new SqlParameter("@CFA_BUYBACKTRADE_ABOVE_SET_AMOUNT ", combo_check());
            //        param128 = new SqlParameter("@CFA_REPORTS_VIEW_HISTORICAL_DATA ", combo_check(view_historical_cmb));
            //        param129 = new SqlParameter("@CFA_INVEN_MISC_FIELD_LOCKDOWN ", combo_check(limited_edit_lockdown_cmb));
            //        param130 = new SqlParameter("@CFA_HH_Create_PO ", combo_check(create_po_cmb));
            //        param131 = new SqlParameter("@CFA_HH_DSD ", combo_check(DSD_cmb));
            //        param132 = new SqlParameter("@CFA_HH_DSD_Credit ", combo_check(DSD_credit_cmb));
            //        param133 = new SqlParameter("@CFA_HH_PO_Receive ", combo_check(po_receive_item_cmb));
            //        param134 = new SqlParameter("@CFA_HH_Inv_Edit ", combo_check(Inventory_edit_cmb));
            //        param135 = new SqlParameter("@CFA_HH_Inv_Adjust ", combo_check(inventory_adjust_cmb));
            //        param136 = new SqlParameter("@CFA_HH_Inv_Count ", combo_check(inventory_count_cmb));
            //        param137 = new SqlParameter("@CFA_HH_Setup ", combo_check(setup_cmb));
            //        //param138 = new SqlParameter("@CFA_CASHIER_OVERRIDE_LICENSESCAN ", combo_check(overr));
            //        param139 = new SqlParameter("@CFA_INVEN_DELETE ", combo_check(delete_inventory_cmb));
            //        param140 = new SqlParameter("@CFA_CASHIER_MANUALY_ENTER_AGE ", combo_check(manual_age_cmb));
            //        //param141 = new SqlParameter("@CreateDate ", );
            //        //param142 = new SqlParameter("@DateDisabled ", );
            //        param143 = new SqlParameter("@CFA_INVEN_ADD_COUPON ", combo_check(add_coupons_cmb));
            //        param144 = new SqlParameter("@CFA_INVEN_GLOBALPRICING ", combo_check(global_pricing_cmb));
            //        param145 = new SqlParameter("@CFA_EMP_SCHEDULE_OVERRIDE ", combo_check(labor_schedule_cmb));
            //        param146 = new SqlParameter("@CFA_LABOR_SCHEDULER ", combo_check(labor_schedule_cmb));
            //        //param147 = new SqlParameter("@GLNumber ", combo_check());
            //        param148 = new SqlParameter("@CFA_NEGATIVE_PRICE_CHANGE ", combo_check(negative_price_cmb));
            //        param149 = new SqlParameter("@CFA_CUSTOMER_EDIT_CHARGEATCOST ", combo_check(charge_at_cost_cmb));
            //        param150 = new SqlParameter("@CFA_GPI_FUEL_DRIVE_OFF ", combo_check(fuel_off_cmb));
            //        //param151 = new SqlParameter("@CFA_SETUP_VPDCONFIGURATION ", );


            //        cmd.Parameters.Add(param1);
            //        cmd.Parameters.Add(param2);
            //        cmd.Parameters.Add(param3);
            //        cmd.Parameters.Add(param4);
            //        cmd.Parameters.Add(param5);
            //        cmd.Parameters.Add(param6);
            //        cmd.Parameters.Add(param7);
            //        //cmd.Parameters.Add(param8);
            //        cmd.Parameters.Add(param9);
            //        cmd.Parameters.Add(param10);
            //        cmd.Parameters.Add(param11);
            //        cmd.Parameters.Add(param12);
            //        cmd.Parameters.Add(param13);
            //        cmd.Parameters.Add(param14);
            //        cmd.Parameters.Add(param15);
            //        cmd.Parameters.Add(param16);
            //        cmd.Parameters.Add(param17);
            //        cmd.Parameters.Add(param18);
            //        cmd.Parameters.Add(param19);
            //        cmd.Parameters.Add(param20);
            //        cmd.Parameters.Add(param21);
            //        cmd.Parameters.Add(param22);
            //        cmd.Parameters.Add(param23);
            //        cmd.Parameters.Add(param24);
            //        cmd.Parameters.Add(param25);
            //        cmd.Parameters.Add(param26);
            //        cmd.Parameters.Add(param27);
            //        cmd.Parameters.Add(param28);
            //        cmd.Parameters.Add(param29);
            //        cmd.Parameters.Add(param30);
            //        cmd.Parameters.Add(param31);
            //        cmd.Parameters.Add(param32);
            //        cmd.Parameters.Add(param33);
            //        cmd.Parameters.Add(param34);
            //        cmd.Parameters.Add(param35);
            //        //cmd.Parameters.Add(param36);
            //        cmd.Parameters.Add(param37);
            //        cmd.Parameters.Add(param38);
            //        cmd.Parameters.Add(param39);
            //        cmd.Parameters.Add(param40);
            //        //cmd.Parameters.Add(param41);
            //        cmd.Parameters.Add(param42);
            //        cmd.Parameters.Add(param43);
            //        cmd.Parameters.Add(param44);
            //        //cmd.Parameters.Add(param45);
            //        cmd.Parameters.Add(param46);
            //        cmd.Parameters.Add(param47);
            //        cmd.Parameters.Add(param48);
            //        cmd.Parameters.Add(param49);
            //        cmd.Parameters.Add(param50);
            //        cmd.Parameters.Add(param51);
            //        cmd.Parameters.Add(param52);
            //        cmd.Parameters.Add(param53);
            //        cmd.Parameters.Add(param54);
            //        cmd.Parameters.Add(param55);
            //        cmd.Parameters.Add(param56);
            //        cmd.Parameters.Add(param57);
            //        //cmd.Parameters.Add(param58);
            //        cmd.Parameters.Add(param59);
            //        cmd.Parameters.Add(param60);
            //        cmd.Parameters.Add(param61);
            //        cmd.Parameters.Add(param62);
            //        cmd.Parameters.Add(param63);
            //        cmd.Parameters.Add(param64);
            //        cmd.Parameters.Add(param65);
            //        cmd.Parameters.Add(param66);
            //        cmd.Parameters.Add(param67);
            //        cmd.Parameters.Add(param68);
            //        cmd.Parameters.Add(param69);
            //        cmd.Parameters.Add(param70);
            //        cmd.Parameters.Add(param71);
            //        cmd.Parameters.Add(param72);
            //        cmd.Parameters.Add(param73);
            //        cmd.Parameters.Add(param74);
            //        cmd.Parameters.Add(param75);
            //        cmd.Parameters.Add(param76);
            //        //cmd.Parameters.Add(param77);
            //        cmd.Parameters.Add(param78);
            //        cmd.Parameters.Add(param79);
            //        //cmd.Parameters.Add(param80);
            //        //cmd.Parameters.Add(param81);
            //        cmd.Parameters.Add(param82);
            //        cmd.Parameters.Add(param83);
            //        //cmd.Parameters.Add(param84);
            //        cmd.Parameters.Add(param85);
            //        cmd.Parameters.Add(param86);
            //        cmd.Parameters.Add(param87);
            //        cmd.Parameters.Add(param88);
            //        cmd.Parameters.Add(param89);
            //        //cmd.Parameters.Add(param90);
            //        //cmd.Parameters.Add(param91);
            //        //cmd.Parameters.Add(param92);
            //        cmd.Parameters.Add(param93);
            //        //cmd.Parameters.Add(param94);
            //        //cmd.Parameters.Add(param95);
            //        //cmd.Parameters.Add(param96);
            //        cmd.Parameters.Add(param97);
            //        cmd.Parameters.Add(param98);
            //        //cmd.Parameters.Add(param99);
            //        cmd.Parameters.Add(param100);
            //        cmd.Parameters.Add(param101);
            //        //cmd.Parameters.Add(param102);
            //        cmd.Parameters.Add(param103);
            //        cmd.Parameters.Add(param104);
            //        cmd.Parameters.Add(param105);
            //        cmd.Parameters.Add(param106);
            //        cmd.Parameters.Add(param107);
            //        cmd.Parameters.Add(param108);
            //        cmd.Parameters.Add(param109);
            //        cmd.Parameters.Add(param110);
            //        cmd.Parameters.Add(param111);
            //        cmd.Parameters.Add(param112);
            //        cmd.Parameters.Add(param113);
            //        //cmd.Parameters.Add(param114);
            //        cmd.Parameters.Add(param115);
            //        cmd.Parameters.Add(param116);
            //        cmd.Parameters.Add(param117);
            //        cmd.Parameters.Add(param118);
            //        cmd.Parameters.Add(param119);
            //        cmd.Parameters.Add(param120);
            //        cmd.Parameters.Add(param121);
            //        //cmd.Parameters.Add(param122);
            //        cmd.Parameters.Add(param123);
            //        cmd.Parameters.Add(param124);
            //        //cmd.Parameters.Add(param125);
            //        //cmd.Parameters.Add(param126);
            //        //cmd.Parameters.Add(param127);
            //        cmd.Parameters.Add(param128);
            //        cmd.Parameters.Add(param129);
            //        cmd.Parameters.Add(param130);
            //        cmd.Parameters.Add(param131);
            //        cmd.Parameters.Add(param132);
            //        cmd.Parameters.Add(param133);
            //        cmd.Parameters.Add(param134);
            //        cmd.Parameters.Add(param135);
            //        cmd.Parameters.Add(param136);
            //        cmd.Parameters.Add(param137);
            //        //cmd.Parameters.Add(param138);
            //        cmd.Parameters.Add(param139);
            //        cmd.Parameters.Add(param140);
            //        //cmd.Parameters.Add(param141);
            //        //cmd.Parameters.Add(param142);
            //        cmd.Parameters.Add(param143);
            //        cmd.Parameters.Add(param144);
            //        cmd.Parameters.Add(param145);
            //        cmd.Parameters.Add(param146);
            //        //cmd.Parameters.Add(param147);
            //        cmd.Parameters.Add(param148);
            //        cmd.Parameters.Add(param149);
            //        cmd.Parameters.Add(param150);
            //        //cmd.Parameters.Add(param151);

            //        cmd.ExecuteNonQuery();

            //        #endregion
            //    }
            //    glo.con.Close();
            //}
            //else
            //{
            //    MessageBox.Show("You must enter Employe Id ");
            //}
        }

        private void cmb_search_emp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fun_clear_fields();
            //glo.con.Open();

            //SqlCommand com = new SqlCommand("SELECT * FROM Employee WHERE Cashier_ID = '" + cmb_search_emp.SelectedItem.ToString() + "'", glo.con);
            //SqlDataReader rr = com.ExecuteReader();

            //while (rr.Read())
            //{
            //    #region RETRIEVING RECORD FROM DATABASE AND DISPLAYING THEM IN FEILDS ACCORDINGLY
            //    txt_emp_id.Text = Convert.ToString(rr["Cashier_ID"]);
            //    txt_customer.Text = Convert.ToString(rr["CustNum"]);
            //    Convert.ToString(rr["Dept_ID"]);
            //    txt_emp_passd.Text = Convert.ToString(rr["Swipe_ID"]);
            //    txt_houlywages.Text = Convert.ToString(rr["Hourly_Wage"]);
            //    //Convert.ToString(rr["Form_Color"]));
            //    //combo_check(,Convert.ToString(rr["CDL"]));
            //    txt_emp_dispname.Text = Convert.ToString(rr["Name"]);
            //    combo_check(setup_cmb, Convert.ToString(rr["CFA_Setup_Company"]));
            //    combo_check(tax_rate_cmb, Convert.ToString(rr["CFA_Setup_Tax"]));
            //    combo_check(bonus_plan_cmb, Convert.ToString(rr["CFA_Setup_Bonus"]));
            //    combo_check(accountinginterface_cmb, Convert.ToString(rr["CFA_Setup_Accounting"]));
            //    combo_check(discount_cmb, Convert.ToString(rr["CFA_Setup_Discounts"]));
            //    combo_check(displaysetting_cmb, Convert.ToString(rr["CFA_Setup_Display"]));
            //    combo_check(defaultprinter_cmb, Convert.ToString(rr["CFA_Setup_DefPrinter"]));
            //    combo_check(add_inventory_cmb, Convert.ToString(rr["CFA_Inven_Add"]));
            //    combo_check(Inventory_edit_cmb, Convert.ToString(rr["CFA_Inven_Edit"]));
            //    combo_check(add_vendor_cmb, Convert.ToString(rr["CFA_Vendors_Add"]));
            //    combo_check(update_vendor_cmb, Convert.ToString(rr["CFA_Vendors_Edit"]));
            //    combo_check(add_department_cmb, Convert.ToString(rr["CFA_Depts_Add"]));
            //    combo_check(edit_department_cmb, Convert.ToString(rr["CFA_Depts_Edit"]));
            //    combo_check(delete_inventory_cmb, Convert.ToString(rr["CFA_Inven_TickVouch"]));
            //    combo_check(add_customer_cmb, Convert.ToString(rr["CFA_Cust_add"]));
            //    combo_check(edit_customer_cmb, Convert.ToString(rr["CFA_Cust_Edit"]));
            //    combo_check(display_reports_cmb, Convert.ToString(rr["CFA_Reports_Display"]));
            //    combo_check(ddr_print_cmb, Convert.ToString(rr["CFA_Reports_DDR"]));
            //    combo_check(print_reports_cmb, Convert.ToString(rr["CFA_Reports_Print"]));
            //    combo_check(invoice_discount_cmb, Convert.ToString(rr["CFA_Invoice_Discount"]));
            //    combo_check(modify_price_cmb, Convert.ToString(rr["CFA_Invoice_PriceChange"]));
            //    combo_check(delete_items_cmb, Convert.ToString(rr["CFA_Invoice_DeleteItems"]));
            //    combo_check(void_invoice_cmb, Convert.ToString(rr["CFA_Invoice_Void"]));
            //    combo_check(accountinginterface_cmb, Convert.ToString(rr["CFA_CRE_Acct"]));
            //    combo_check(allow_exit_cmb, Convert.ToString(rr["CFA_CRE_Exit"]));
            //    //combo_check(boolean,Convert.ToString(rr["Dirty"]));
            //    //combo_check(,Convert.ToString(rr["Last_DDR"]));
            //    combo_check(display_balance_cmb, Convert.ToString(rr["CFA_Display_Balance"]));
            //    combo_check(displaysetting_cmb, Convert.ToString(rr["CFA_Refund_Item"]));
            //    //combo_check(,Convert.ToString(rr["Disp_Pay_Option"]));
            //    //combo_check(,Convert.ToString(rr["Disp_Item_Option"]));
            //    //combo_check(,Convert.ToString(rr["EmpName"]));
            //    combo_check(po_receive_item_cmb, Convert.ToString(rr["CFA_Receive_Items"]));
            //    combo_check(create_po_cmb, Convert.ToString(rr["CFA_DO_POS"]));
            //    combo_check(instant_po_cmb, Convert.ToString(rr["CFA_INSTANT_POS"]));
            //    //combo_check(,Convert.ToString(rr["Section_ID"]));
            //    combo_check(other_tables_cmb, Convert.ToString(rr["CFA_Other_Tables"]));
            //    combo_check(cash_pickups_cmb, Convert.ToString(rr["CFA_Accept_Cash"]));
            //    combo_check(transfer_without_cmb, Convert.ToString(rr["CFA_TRANSFER_NOSWIPE"]));
            //    combo_check(cc_tips_cmb, Convert.ToString(rr["CFA_ADD_CCTIPS"]));
            //    //combo_check(,Convert.ToString(rr["Disabled"]));
            //    //combo_check(,Convert.ToString(rr["Admin_Access"]));
            //    combo_check(hold_print_cmb, Convert.ToString(rr["CFA_PRINT_HOLD"]));
            //    combo_check(open_cash_cmb, Convert.ToString(rr["CFA_Open_Cash_Drawer"]));
            //    //combo_check(,Convert.ToString(rr["CCTipsNow"]));
            //    //combo_check(,Convert.ToString(rr["ReqClockIn"]));
            //    combo_check(split_checks_cmb, Convert.ToString(rr["CFA_Split_Checks"]));
            //    combo_check(transfer_tables_cmb, Convert.ToString(rr["CFA_Transfer_Tables"]));
            //    //combo_check(,Convert.ToString(rr["CFA_Extra_Item"]));
            //    combo_check(tax_ex_cmb, Convert.ToString(rr["CFA_Tax_Exempt"]));
            //    combo_check(sell_giftc_cmb, Convert.ToString(rr["CFA_GC_Sell"]));
            //    combo_check(redeem_giftc_cmb, Convert.ToString(rr["CFA_GC_Redeem"]));
            //    combo_check(sell_special_cmb, Convert.ToString(rr["CFA_SELL_SPECIAL_ITEM"]));
            //    combo_check(vendor_payouts_cmb, Convert.ToString(rr["CFA_VENDOR_PAYOUT"]));
            //    combo_check(apply_gratuity_cmb, Convert.ToString(rr["CFA_APPLY_GRATUITY"]));
            //    txt_first_name.Text = Convert.ToString(rr["First_Name"]);
            //    txt_middle_name.Text = Convert.ToString(rr["Middle_Name"]);
            //    txt_last_name.Text = Convert.ToString(rr["Last_Name"]);
            //    txt_SSN.Text = Convert.ToString(rr["SSN"]);
            //    address_1_txt.Text = Convert.ToString(rr["Address_1"]);
            //    address_2_txt.Text = Convert.ToString(rr["Address_2"]);
            //    txt_city.Text = Convert.ToString(rr["City"]);
            //    txt_state.Text = Convert.ToString(rr["State"]);
            //    txt_zipcode.Text = Convert.ToString(rr["Zip_Code"]);
            //    txt_phone.Text = Convert.ToString(rr["Phone_1"]);
            //    txt_email.Text = Convert.ToString(rr["EMail"]);
            //    txt_birthday.Text = Convert.ToString(rr["Birthday"]);
            //    //combo_check(,Convert.ToString(rr["Picture"]));
            //    combo_check(buyback_trade_cmb, Convert.ToString(rr["CFA_BUYBACKS_TRADES"]));
            //    combo_check(force_credit_cmb, Convert.ToString(rr["CFA_CC_Force"]));
            //    //combo_check(,Convert.ToString(rr["CFA_CC_Below_Floor"]));
            //    //combo_check(,Convert.ToString(rr["Current_Cash "]));
            //    combo_check(cas_alert_cmb, Convert.ToString(rr["CFA_Cash_Alerts"]));
            //    combo_check(cash_pickups_cmb, Convert.ToString(rr["CFA_Cash_Pickup"]));
            //    //combo_check(,Convert.ToString(rr["CDL_Stations_ID"]));
            //    combo_check(issue_credit_cmb, Convert.ToString(rr["CFA_Issue_Credit_Slip"]));
            //    combo_check(redeem_credit_slip, Convert.ToString(rr["CFA_Redeem_Credit_Slip"]));
            //    combo_check(override_refund_cmb, Convert.ToString(rr["CFA_REFUND_OVERRIDE"]));
            //    combo_check(drawer_transfer_cmb, Convert.ToString(rr["CFA_DRAWER_TRANSFER"]));
            //    combo_check(allow_large_purchase_cmb, Convert.ToString(rr["CFA_LARGE_PURCHASES"]));
            //    //combo_check(,Convert.ToString(rr["CFA_AUCTION_PHOTO"]));
            //    //combo_check(,Convert.ToString(rr["CFA_AUCTION_LISTREDEEM"]));
            //    //combo_check(,Convert.ToString(rr["CFA_AUCTION_SHIP"]));
            //    combo_check(approve_cash_count_cmb, Convert.ToString(rr["CFA_APPROVE_CASHCOUNT"]));
            //    //combo_check(,Convert.ToString(rr["Orig_Emp_ID"]));
            //    //combo_check(,Convert.ToString(rr["Orig_Store_ID"]));
            //    //combo_check(,Convert.ToString(rr["CD_Name"]));
            //    combo_check(allow_old_return_cmb, Convert.ToString(rr["CFA_APPROVE_OLD_RETURNS"]));
            //    combo_check(approve_emer_cmb, Convert.ToString(rr["CFA_APPROVE_EMERGENCY_CLOCKOUT"]));
            //    //combo_check(,Convert.ToString(rr["TimeWorkedThisPeriod"]));
            //    Convert.ToString(rr["OvertimeThreshold"]);
            //    combo_check(pullback_cmb, Convert.ToString(rr["CFA_PULLBACK_INVOICE"]));
            //    //combo_check(,Convert.ToString(rr["CFA_MANAGE_TIMECLOCK"]));
            //    combo_check(perform_endofday_cmb, Convert.ToString(rr["CFA_PERFORM_ENDOFDAY"]));
            //    combo_check(host_module_cmb, Convert.ToString(rr["CFA_HOST_LOGIN"]));
            //    combo_check(open_tabs_cmb, Convert.ToString(rr["CFA_REST_OPENTABS"]));
            //    combo_check(take_out_orders_cmb, Convert.ToString(rr["CFA_REST_TAKEOUT"]));
            //    combo_check(delivery_orders_cmb, Convert.ToString(rr["CFA_REST_DELIVERY"]));
            //    combo_check(invoice_price_change_cmb, Convert.ToString(rr["CFA_INVOICE_DELETESENT"]));
            //    combo_check(view_inventory_cmb, Convert.ToString(rr["CFA_INVEN_VIEW"]));
            //    combo_check(view_inventory_cost, Convert.ToString(rr["CFA_INVEN_VIEWCOST"]));
            //    combo_check(instant_po_cmb, Convert.ToString(rr["CFA_INVEN_NEGATIVE_INSTANTPOS"]));
            //    combo_check(end_cash_cmb, Convert.ToString(rr["CFA_ENDTRANS_CASH"]));
            //    combo_check(end_transaction_cmb, Convert.ToString(rr["CFA_ENDTRANS_ACCOUNT"]));
            //    //combo_check(,Convert.ToString(rr["CFA_REST_COMP"]));
            //    combo_check(force_check_cmb, Convert.ToString(rr["CFA_CH_FORCE"]));
            //    combo_check(configure_virtual_cmb, Convert.ToString(rr["CFA_TS_CONFIG"]));
            //    combo_check(transfer_servers_cmb, Convert.ToString(rr["CFA_TRANSFER_SERVER"]));
            //    combo_check(backup_database_cmb, Convert.ToString(rr["CFA_BACKUP_DATABASE"]));
            //    combo_check(settle_credit_cmb, Convert.ToString(rr["CFA_CREDIT_CARD_SETTLEMENT"]));
            //    combo_check(reprint_kitchen_cmb, Convert.ToString(rr["CFA_KITCHEN_REPRINT"]));
            //    combo_check(configure_receipt_cmb, Convert.ToString(rr["CFA_SETUP_RECEIPT_NOTES"]));
            //    //combo_check(,Convert.ToString(rr["CFA_MANAGE_TIMECLOCK_OWNTIME"]));
            //    combo_check(add_employee_cmb, Convert.ToString(rr["CFA_SETUP_ADD_EMPLOYEES"]));
            //    combo_check(modify_employee_cmb, Convert.ToString(rr["CFA_SETUP_EDIT_EMPLOYEES"]));
            //    //combo_check(,Convert.ToString(rr["CFA_INVENTORY_PROMOTIONS"]));
            //    //combo_check(,Convert.ToString(rr["CFA_INVOICE_DISCOUNTS_BELOW_X"]));
            //    //combo_check(,Convert.ToString(rr["CFA_BUYBACKTRADE_ABOVE_SET_AMOUNT"]));
            //    combo_check(view_historical_cmb, Convert.ToString(rr["CFA_REPORTS_VIEW_HISTORICAL_DATA"]));
            //    combo_check(limited_edit_lockdown_cmb, Convert.ToString(rr["CFA_INVEN_MISC_FIELD_LOCKDOWN"]));
            //    combo_check(create_po_cmb, Convert.ToString(rr["CFA_HH_Create_PO"]));
            //    combo_check(DSD_cmb, Convert.ToString(rr["CFA_HH_DSD"]));
            //    combo_check(DSD_credit_cmb, Convert.ToString(rr["CFA_HH_DSD_Credit"]));
            //    combo_check(po_receive_item_cmb, Convert.ToString(rr["CFA_HH_PO_Receive"]));
            //    combo_check(Inventory_edit_cmb, Convert.ToString(rr["CFA_HH_Inv_Edit"]));
            //    combo_check(inventory_adjust_cmb, Convert.ToString(rr["CFA_HH_Inv_Adjust"]));
            //    combo_check(inventory_count_cmb, Convert.ToString(rr["CFA_HH_Inv_Count"]));
            //    combo_check(setup_cmb, Convert.ToString(rr["CFA_HH_Setup"]));
            //    //combo_check(,Convert.ToString(rr["CFA_CASHIER_OVERRIDE_LICENSESCAN"]));
            //    combo_check(delete_inventory_cmb, Convert.ToString(rr["CFA_INVEN_DELETE"]));
            //    combo_check(manual_age_cmb, Convert.ToString(rr["CFA_CASHIER_MANUALY_ENTER_AGE"]));
            //    //combo_check(,Convert.ToString(rr["CreateDate"]));
            //    //combo_check(,Convert.ToString(rr["DateDisabled"]));
            //    combo_check(add_coupons_cmb, Convert.ToString(rr["CFA_INVEN_ADD_COUPON"]));
            //    combo_check(global_pricing_cmb, Convert.ToString(rr["CFA_INVEN_GLOBALPRICING"]));
            //    combo_check(labor_schedule_cmb, Convert.ToString(rr["CFA_EMP_SCHEDULE_OVERRIDE"]));
            //    combo_check(labor_schedule_cmb, Convert.ToString(rr["CFA_LABOR_SCHEDULER"]));
            //    //combo_check(,Convert.ToString(rr["GLNumber "]));
            //    combo_check(negative_price_cmb, Convert.ToString(rr["CFA_NEGATIVE_PRICE_CHANGE"]));
            //    combo_check(charge_at_cost_cmb, Convert.ToString(rr["CFA_CUSTOMER_EDIT_CHARGEATCOST"]));
            //    combo_check(fuel_off_cmb, Convert.ToString(rr["CFA_GPI_FUEL_DRIVE_OFF"]));
            //    //combo_check(,Convert.ToString(rr["CFA_SETUP_VPDCONFIGURATION "]));
            //    #endregion
            //}

            //rr.Close();
            //glo.con.Close();
        }

        //the fnction to set the values of the access specifier combo boxes...
        public void combo_check(ComboBox cmb, string str)
        {
            if (str == "P")
            {
                cmb.Text = "Prompt";
            }
            else if (str == "O")
            {
                cmb.Text = "Override";
            }
            else if (str == "Y")
            {
                cmb.Text = "Yes";
            }
            else if (str == "N")
            {
                cmb.Text = "No";
            }
            else if (str == null)
            {
                cmb.Text = "Prompt";
            }
        }

        private void btn_emp_next_Click(object sender, RoutedEventArgs e)
        {
            //int count = Convert.ToInt32(cmb_search_emp.MaxHeight);
            if (cmb_search_emp.SelectedIndex > cmb_search_emp.MaxHeight)
            {
                MessageBox.Show("No More Employees, thank you!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                cmb_search_emp.SelectedIndex = cmb_search_emp.SelectedIndex + 1;
            }
        }

        private void btn_emp_prev_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_search_emp.SelectedIndex != cmb_search_emp.MinHeight)
            {
                cmb_search_emp.SelectedIndex = cmb_search_emp.SelectedIndex - 1;
            }
            else
            {
                MessageBox.Show("No More Employees, thank you!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_jobcode_Click(object sender, RoutedEventArgs e)
        {
            //job_code_setup job = new job_code_setup();
            //job.ShowDialog();
        }

        private void btn_add_job_Click(object sender, RoutedEventArgs e)
        {
            //job_code_setup job = new job_code_setup();
            //job.ShowDialog();
        }
    }
}
