﻿using System;
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
using Microsoft.Win32;
using POS.Retail.Common;

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
        RegexClass objRegex = new Common.RegexClass();
        DataTable dt = new DataTable();
        //GlobalClass glo = new GlobalClass();
        public EmployeeForm()
        {
            InitializeComponent();
            //fill_employee();
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
            txt_birthday.DisplayDate = DateTime.Today;
            state_additional_credits_txt.Clear();
            txt_fed_allwnce.Clear();
            txt_state_allown.Clear();
            DG_jobs.Rows.Clear();
            txt_additional_fed_allown.Clear();
            state_additional_with_amount_txt.Clear();
            imgEmpPhoto.Source = null;

        }

        #region permission girds buttons's click events on permission tabcontrol

        private void btn_per_func_Click(object sender, RoutedEventArgs e)
        {
            fun_hide_permission_grid();
            gird_func.Visibility = Visibility.Visible;
            btnClorChange_Click(this.btn_per_func);
        }

        private void btn_per_inventory_Click(object sender, RoutedEventArgs e)
        {
            fun_hide_permission_grid();
            Grid_per_inventory.Visibility = Visibility.Visible;
            btnClorChange_Click(this.btn_per_inventory);
        }

        private void btn_per_customer_Click(object sender, RoutedEventArgs e)
        {
            fun_hide_permission_grid();
            Grid_permis_customer.Visibility = Visibility.Visible;
            btnClorChange_Click(this.btn_per_customer);
        }

        private void btn_per_report_Click(object sender, RoutedEventArgs e)
        {
            fun_hide_permission_grid();
            Grid_permis_reports.Visibility = Visibility.Visible;
            btnClorChange_Click(this.btn_per_report);
        }

        private void btn_per_setup_Click(object sender, RoutedEventArgs e)
        {
            fun_hide_permission_grid();
            grid_permis_setup.Visibility = Visibility.Visible;
            btnClorChange_Click(this.btn_per_setup);
        }

        private void btn_per_resturt_Click(object sender, RoutedEventArgs e)
        {
            fun_hide_permission_grid();
            grid_permis_Restaurant.Visibility = Visibility.Visible;
            btnClorChange_Click(this.btn_per_resturt);
        }

        private void btn_per_handhold_Click(object sender, RoutedEventArgs e)
        {
            fun_hide_permission_grid();
            grid_permis_handhold.Visibility = Visibility.Visible;
            btnClorChange_Click(this.btn_per_handhold);
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
                btnSaveChagesEmp.IsHitTestVisible = true;
                lbl_serch_emp.Visibility = Visibility.Visible;
                cmb_search_emp.Visibility = Visibility.Visible;
                cmb_search_emp.SelectedIndex = 0;
            }

        }

        private void btn_add_emp_Click(object sender, RoutedEventArgs e)
        {
         
            try
            {
                if (btn_add_emp.Content.Equals("Add Employee"))
                {
                    btn_add_emp.Content = "Save";
                    btn_exit_emp.Content = "Cancel";
                    btn_delete_emp.IsHitTestVisible = false;
                    btn_emp_next.IsHitTestVisible = false;
                    btn_emp_next.IsHitTestVisible = false;
                    btn_emp_prev.IsHitTestVisible = false;
                    btnSaveChagesEmp.IsHitTestVisible = false;
                    lbl_serch_emp.Visibility = Visibility.Hidden;
                    cmb_search_emp.Visibility = Visibility.Hidden;
                    txt_emp_id.Background = Brushes.Yellow;
                    txt_emp_id.Focus();
                    fun_clear_fields();
                    cmb_search_emp.SelectedIndex = -1;
                    txt_emp_id.IsReadOnly = false;
                }
                else
                    if (btn_add_emp.Content.Equals("Save"))
                    {

                        if (txt_emp_id.Text != "")
                        {
                            EmployeesDataClass objEmployeesData = new EmployeesDataClass();
                        
                            objEmployeesData.Cashier_ID = "1001" + txt_emp_id.Text;
                          
                            objEmployeesData.CustNum = txt_customer.Text;
                            objEmployeesData.Dept_ID = cmb_cetegory.SelectedValue.ToString();
                            objEmployeesData.Password = txt_emp_passd.Text;
                            objEmployeesData.Swipe_ID = txt_cardswip.Text;
                            objEmployeesData.Hourly_Wage = txt_houlywages.Text;
                            objEmployeesData.Form_Color = 1;
                            objEmployeesData.CDL = "";
                            objEmployeesData.EmpName = txt_emp_dispname.Text;
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
                            objEmployeesData.CFA_Receive_Items = combo_check(po_receive_item_cmb);
                            objEmployeesData.CFA_DO_POS = combo_check(create_po_cmb);
                            objEmployeesData.CFA_INSTANT_POS = combo_check(instant_po_cmb);
                            objEmployeesData.Section_ID = "";
                            objEmployeesData.CFA_Other_Tables = combo_check(other_tables_cmb);
                            objEmployeesData.CFA_Accept_Cash = combo_check(cash_pickups_cmb);
                            objEmployeesData.CFA_TRANSFER_NOSWIPE = combo_check(transfer_without_cmb);
                            objEmployeesData.CFA_ADD_CCTIPS = combo_check(cc_tips_cmb);
                            objEmployeesData.Disabled = Convert.ToByte(chkDisableEmployee.IsChecked);
                            //objEmployeesData.Admin_Access = dirty;
                            objEmployeesData.CFA_PRINT_HOLD = combo_check(hold_print_cmb);
                            objEmployeesData.CFA_Open_Cash_Drawer = combo_check(open_cash_cmb);
                            objEmployeesData.CCTipsNow = Convert.ToByte(chkTakeCcTips.IsChecked);
                            objEmployeesData.ReqClockIn = Convert.ToByte(requireClockinBeforeLogin.IsChecked);
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
                            objEmployeesData.Birthday = Convert.ToDateTime(txt_birthday.SelectedDate);
                            objEmployeesData.Picture = image_name;
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
                            objEmployeesData.Orig_Store_ID = "1001";
                            objEmployeesData.CD_Name = "P";
                            objEmployeesData.CFA_APPROVE_OLD_RETURNS = combo_check(allow_old_return_cmb);
                            objEmployeesData.CFA_APPROVE_EMERGENCY_CLOCKOUT = combo_check(approve_emer_cmb);
                            objEmployeesData.TimeWorkedThisPeriod = 0;
                            if (txt_start_overtime.Text == "")
                                objEmployeesData.OvertimeThreshold = 0;
                            else
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
                            if (objEmployeesData.IsSuccessfull == true)
                            {
                                // isertion of additional info pay rol information Table: EmployeeAdditionalInfo
                                EmployeeAdditionalInfoClass objAddtionalInfo = new EmployeeAdditionalInfoClass();
                                objAddtionalInfo.Cashier_ID = "1001" + txt_emp_id.Text;
                                objAddtionalInfo.AdditionalFederalWithholdingAmount = txt_additional_fed_allown.Text;
                                objAddtionalInfo.FederalAllowances = Convert.ToInt32(txt_fed_allwnce.Text);
                                objAddtionalInfo.StateAllowances = Convert.ToInt32(txt_state_allown.Text);
                                objAddtionalInfo.AdditionalStateWithholdingAmount = state_additional_with_amount_txt.Text;
                                objAddtionalInfo.StateAdditionalCredits = state_additional_credits_txt.Text;
                                if (cmb_exempt.SelectedIndex == 0)
                                    objAddtionalInfo.Exempt = 1;
                                else
                                    objAddtionalInfo.Exempt = 0;
                                objAddtionalInfo.TaxFilingStatus = cmb_filing_status.SelectedIndex;
                                objAddtionalInfo.ExcludeInPayrollExp = Convert.ToByte(exclude_chk.IsChecked);
                                objPOSManagementService.insertPayrolInfo(objAddtionalInfo);
                                // insertion of job codes and wages Table: Employee_jobCodes
                                if (DG_jobs.Rows.Count > 0)
                                {
                                    EmployeeJobCodeClass objEmployeeJobCodeClass = new EmployeeJobCodeClass();
                                    objEmployeeJobCodeClass.Cashier_ID = "1001" + txt_emp_id.Text;
                                    for (int i = 0; i < DG_jobs.Rows.Count; i++)
                                    {
                                        objEmployeeJobCodeClass.JobCodeID = DG_jobs.Rows[i].Cells[0].Value.ToString();
                                        objEmployeeJobCodeClass.Hourly_Wage = Convert.ToDouble(DG_jobs.Rows[i].Cells[1].Value.ToString());
                                        objEmployeeJobCodeClass.OvertimeHourly_Wage = Convert.ToDouble(DG_jobs.Rows[i].Cells[2].Value.ToString());
                                        objPOSManagementService.insertEmployeejob(objEmployeeJobCodeClass);
                                    }
                                }                                
                                MessageBox.Show("Employee Record Added Successfully", "Run Time Support", MessageBoxButton.OK, MessageBoxImage.Information);
                                btn_add_emp.Content = "Add Employee";
                                btn_exit_emp.Content = "Exit";
                                btn_delete_emp.IsHitTestVisible = true;
                                btn_emp_next.IsHitTestVisible = true;
                                btn_emp_next.IsHitTestVisible = true;
                                btn_emp_prev.IsHitTestVisible = true;
                                btnSaveChagesEmp.IsHitTestVisible = true;
                                lbl_serch_emp.Visibility = Visibility.Visible;
                                cmb_search_emp.Visibility = Visibility.Visible;
                            }

                        }
                        else
                        {
                            MessageBox.Show("You must enter Employe Id ", "Run Time Support", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }

                        // fun_clear_fields();
                        // cmb_search_emp.Items.Clear();
                        fill_employee();
                    }
            }
            catch (Exception ex)
            {
  
            }
        }

        public void fill_employee()
        {
            try
            {
                EmployeesDataClass objEmployeesDataClass = new EmployeesDataClass();
                DataTable dt = objPOSManagementService.getEmplyeeIds(objEmployeesDataClass);
                if (dt.Rows.Count > 0)
                {
                    cmb_search_emp.ItemsSource = dt.DefaultView;
                    cmb_search_emp.DisplayMemberPath = "Cashier_ID";
                    cmb_search_emp.SelectedValuePath = "Cashier_ID";
                }
                cmb_search_emp.SelectedIndex = 1;
            }
            catch (Exception ex)
            {

            }
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
            fill_employee();
           
        }

        public void FillCombo()
        {
            DepartmentClass objDept = new DepartmentClass();
            objDept.Store_ID = "1001";
            objDept.Type = 2;
            DataTable dt = objPOSManagementService.getDeptforEmployee(objDept);
            if(dt.Rows.Count > 0)
            {
                cmb_cetegory.ItemsSource = dt.DefaultView;
                cmb_cetegory.DisplayMemberPath = "Dept";
                cmb_cetegory.SelectedValuePath = "Dept_ID";
            }
            
        }
    
        private void cmb_search_emp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                fun_clear_fields();
                txt_emp_id.IsReadOnly = true;
                EmployeesDataClass objEmployeesDataClass = new EmployeesDataClass();
                objEmployeesDataClass.Cashier_ID = cmb_search_emp.SelectedValue.ToString();
                DataTable dt = objPOSManagementService.RetriveEmpRecord(objEmployeesDataClass);
                if (dt.Rows.Count > 0)
                {
                    #region RETRIEVING RECORD FROM DATABASE AND DISPLAYING THEM IN FEILDS ACCORDINGLY
                    txt_emp_id.Text = Convert.ToString(dt.Rows[0]["Cashier_ID"]);
                    txt_customer.Text = Convert.ToString(dt.Rows[0]["CustNum"]);
                    cmb_cetegory.SelectedValue = Convert.ToString(dt.Rows[0]["Dept_ID"]);
                    txt_cardswip.Text = Convert.ToString(dt.Rows[0]["Swipe_ID"]);
                    txt_houlywages.Text = Convert.ToString(dt.Rows[0]["Hourly_Wage"]);
                    txt_emp_passd.Text = dt.Rows[0]["Password"].ToString();
                    //Convert.ToString(dt.Rows[0]["Form_Color"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["CDL"]));
                    txt_emp_dispname.Text = Convert.ToString(dt.Rows[0]["EmpName"]);
                    combo_check(setup_cmb, Convert.ToString(dt.Rows[0]["CFA_Setup_Company"]));
                    combo_check(tax_rate_cmb, Convert.ToString(dt.Rows[0]["CFA_Setup_Tax"]));
                    combo_check(bonus_plan_cmb, Convert.ToString(dt.Rows[0]["CFA_Setup_Bonus"]));
                    combo_check(accountinginterface_cmb, Convert.ToString(dt.Rows[0]["CFA_Setup_Accounting"]));
                    combo_check(discount_cmb, Convert.ToString(dt.Rows[0]["CFA_Setup_Discounts"]));
                    combo_check(displaysetting_cmb, Convert.ToString(dt.Rows[0]["CFA_Setup_Display"]));
                    combo_check(defaultprinter_cmb, Convert.ToString(dt.Rows[0]["CFA_Setup_DefPrinter"]));
                    combo_check(add_inventory_cmb, Convert.ToString(dt.Rows[0]["CFA_Inven_Add"]));
                    combo_check(Inventory_edit_cmb, Convert.ToString(dt.Rows[0]["CFA_Inven_Edit"]));
                    combo_check(add_vendor_cmb, Convert.ToString(dt.Rows[0]["CFA_Vendors_Add"]));
                    combo_check(update_vendor_cmb, Convert.ToString(dt.Rows[0]["CFA_Vendors_Edit"]));
                    combo_check(add_department_cmb, Convert.ToString(dt.Rows[0]["CFA_Depts_Add"]));
                    combo_check(edit_department_cmb, Convert.ToString(dt.Rows[0]["CFA_Depts_Edit"]));
                    combo_check(delete_inventory_cmb, Convert.ToString(dt.Rows[0]["CFA_Inven_TickVouch"]));
                    combo_check(add_customer_cmb, Convert.ToString(dt.Rows[0]["CFA_Cust_add"]));
                    combo_check(edit_customer_cmb, Convert.ToString(dt.Rows[0]["CFA_Cust_Edit"]));
                    combo_check(display_reports_cmb, Convert.ToString(dt.Rows[0]["CFA_Reports_Display"]));
                    combo_check(ddr_print_cmb, Convert.ToString(dt.Rows[0]["CFA_Reports_DDR"]));
                    combo_check(print_reports_cmb, Convert.ToString(dt.Rows[0]["CFA_Reports_Print"]));
                    combo_check(invoice_discount_cmb, Convert.ToString(dt.Rows[0]["CFA_Invoice_Discount"]));
                    combo_check(modify_price_cmb, Convert.ToString(dt.Rows[0]["CFA_Invoice_PriceChange"]));
                    combo_check(delete_items_cmb, Convert.ToString(dt.Rows[0]["CFA_Invoice_DeleteItems"]));
                    combo_check(void_invoice_cmb, Convert.ToString(dt.Rows[0]["CFA_Invoice_Void"]));
                    combo_check(accountinginterface_cmb, Convert.ToString(dt.Rows[0]["CFA_CRE_Acct"]));
                    combo_check(allow_exit_cmb, Convert.ToString(dt.Rows[0]["CFA_CRE_Exit"]));
                    //combo_check(boolean,Convert.ToString(dt.Rows[0]["Dirty"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["Last_DDR"]));
                    combo_check(display_balance_cmb, Convert.ToString(dt.Rows[0]["CFA_Display_Balance"]));
                    combo_check(displaysetting_cmb, Convert.ToString(dt.Rows[0]["CFA_Refund_Item"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["Disp_Pay_Option"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["Disp_Item_Option"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["EmpName"]));
                    combo_check(po_receive_item_cmb, Convert.ToString(dt.Rows[0]["CFA_Receive_Items"]));
                    combo_check(create_po_cmb, Convert.ToString(dt.Rows[0]["CFA_DO_POS"]));
                    combo_check(instant_po_cmb, Convert.ToString(dt.Rows[0]["CFA_INSTANT_POS"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["Section_ID"]));
                    combo_check(other_tables_cmb, Convert.ToString(dt.Rows[0]["CFA_Other_Tables"]));
                    combo_check(cash_pickups_cmb, Convert.ToString(dt.Rows[0]["CFA_Accept_Cash"]));
                    combo_check(transfer_without_cmb, Convert.ToString(dt.Rows[0]["CFA_TRANSFER_NOSWIPE"]));
                    combo_check(cc_tips_cmb, Convert.ToString(dt.Rows[0]["CFA_ADD_CCTIPS"]));
                    chkDisableEmployee.IsChecked = Convert.ToBoolean(dt.Rows[0]["Disabled"]);
                    //combo_check(,Convert.ToString(dt.Rows[0]["Admin_Access"]));
                    combo_check(hold_print_cmb, Convert.ToString(dt.Rows[0]["CFA_PRINT_HOLD"]));
                    combo_check(open_cash_cmb, Convert.ToString(dt.Rows[0]["CFA_Open_Cash_Drawer"]));
                    chkTakeCcTips.IsChecked = Convert.ToBoolean(dt.Rows[0]["CCTipsNow"]);
                    requireClockinBeforeLogin.IsChecked = Convert.ToBoolean(dt.Rows[0]["ReqClockIn"]);

                    combo_check(split_checks_cmb, Convert.ToString(dt.Rows[0]["CFA_Split_Checks"]));
                    combo_check(transfer_tables_cmb, Convert.ToString(dt.Rows[0]["CFA_Transfer_Tables"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["CFA_Extra_Item"]));
                    combo_check(tax_ex_cmb, Convert.ToString(dt.Rows[0]["CFA_Tax_Exempt"]));
                    combo_check(sell_giftc_cmb, Convert.ToString(dt.Rows[0]["CFA_GC_Sell"]));
                    combo_check(redeem_giftc_cmb, Convert.ToString(dt.Rows[0]["CFA_GC_Redeem"]));
                    combo_check(sell_special_cmb, Convert.ToString(dt.Rows[0]["CFA_SELL_SPECIAL_ITEM"]));
                    combo_check(vendor_payouts_cmb, Convert.ToString(dt.Rows[0]["CFA_VENDOR_PAYOUT"]));
                    combo_check(apply_gratuity_cmb, Convert.ToString(dt.Rows[0]["CFA_APPLY_GRATUITY"]));
                    txt_first_name.Text = Convert.ToString(dt.Rows[0]["First_Name"]);
                    txt_middle_name.Text = Convert.ToString(dt.Rows[0]["Middle_Name"]);
                    txt_last_name.Text = Convert.ToString(dt.Rows[0]["Last_Name"]);
                    txt_SSN.Text = Convert.ToString(dt.Rows[0]["SSN"]);
                    address_1_txt.Text = Convert.ToString(dt.Rows[0]["Address_1"]);
                    address_2_txt.Text = Convert.ToString(dt.Rows[0]["Address_2"]);
                    txt_city.Text = Convert.ToString(dt.Rows[0]["City"]);
                    txt_state.Text = Convert.ToString(dt.Rows[0]["State"]);
                    txt_zipcode.Text = Convert.ToString(dt.Rows[0]["Zip_Code"]);
                    txt_phone.Text = Convert.ToString(dt.Rows[0]["Phone_1"]);
                    txt_email.Text = Convert.ToString(dt.Rows[0]["EMail"]);

                    txt_birthday.SelectedDate = Convert.ToDateTime(dt.Rows[0]["Birthday"]);
                    ImageSourceConverter isc = new ImageSourceConverter();
                    if (dt.Rows[0]["Picture"].ToString() != "")
                        imgEmpPhoto.SetValue(Image.SourceProperty, isc.ConvertFromString(dt.Rows[0]["Picture"].ToString()));
                    combo_check(buyback_trade_cmb, Convert.ToString(dt.Rows[0]["CFA_BUYBACKS_TRADES"]));
                    combo_check(force_credit_cmb, Convert.ToString(dt.Rows[0]["CFA_CC_Force"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["CFA_CC_Below_Floor"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["Cudt.Rows[0]ent_Cash "]));
                    combo_check(cas_alert_cmb, Convert.ToString(dt.Rows[0]["CFA_Cash_Alerts"]));
                    combo_check(cash_pickups_cmb, Convert.ToString(dt.Rows[0]["CFA_Cash_Pickup"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["CDL_Stations_ID"]));
                    combo_check(issue_credit_cmb, Convert.ToString(dt.Rows[0]["CFA_Issue_Credit_Slip"]));
                    combo_check(redeem_credit_slip, Convert.ToString(dt.Rows[0]["CFA_Redeem_Credit_Slip"]));
                    //combo_check(ovedt.Rows[0]ide_refund_cmb, Convert.ToString(dt.Rows[0]["CFA_REFUND_OVEdt.Rows[0]IDE"]));
                    combo_check(drawer_transfer_cmb, Convert.ToString(dt.Rows[0]["CFA_DRAWER_TRANSFER"]));
                    combo_check(allow_large_purchase_cmb, Convert.ToString(dt.Rows[0]["CFA_LARGE_PURCHASES"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["CFA_AUCTION_PHOTO"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["CFA_AUCTION_LISTREDEEM"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["CFA_AUCTION_SHIP"]));
                    combo_check(approve_cash_count_cmb, Convert.ToString(dt.Rows[0]["CFA_APPROVE_CASHCOUNT"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["Orig_Emp_ID"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["Orig_Store_ID"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["CD_Name"]));
                    combo_check(allow_old_return_cmb, Convert.ToString(dt.Rows[0]["CFA_APPROVE_OLD_RETURNS"]));
                    combo_check(approve_emer_cmb, Convert.ToString(dt.Rows[0]["CFA_APPROVE_EMERGENCY_CLOCKOUT"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["TimeWorkedThisPeriod"]));
                    Convert.ToString(dt.Rows[0]["OvertimeThreshold"]);
                    combo_check(pullback_cmb, Convert.ToString(dt.Rows[0]["CFA_PULLBACK_INVOICE"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["CFA_MANAGE_TIMECLOCK"]));
                    combo_check(perform_endofday_cmb, Convert.ToString(dt.Rows[0]["CFA_PERFORM_ENDOFDAY"]));
                    combo_check(host_module_cmb, Convert.ToString(dt.Rows[0]["CFA_HOST_LOGIN"]));
                    combo_check(open_tabs_cmb, Convert.ToString(dt.Rows[0]["CFA_REST_OPENTABS"]));
                    combo_check(take_out_orders_cmb, Convert.ToString(dt.Rows[0]["CFA_REST_TAKEOUT"]));
                    combo_check(delivery_orders_cmb, Convert.ToString(dt.Rows[0]["CFA_REST_DELIVERY"]));
                    combo_check(invoice_price_change_cmb, Convert.ToString(dt.Rows[0]["CFA_INVOICE_DELETESENT"]));
                    combo_check(view_inventory_cmb, Convert.ToString(dt.Rows[0]["CFA_INVEN_VIEW"]));
                    combo_check(view_inventory_cost, Convert.ToString(dt.Rows[0]["CFA_INVEN_VIEWCOST"]));
                    combo_check(instant_po_cmb, Convert.ToString(dt.Rows[0]["CFA_INVEN_NEGATIVE_INSTANTPOS"]));
                    combo_check(end_cash_cmb, Convert.ToString(dt.Rows[0]["CFA_ENDTRANS_CASH"]));
                    combo_check(end_transaction_cmb, Convert.ToString(dt.Rows[0]["CFA_ENDTRANS_ACCOUNT"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["CFA_REST_COMP"]));
                    combo_check(force_check_cmb, Convert.ToString(dt.Rows[0]["CFA_CH_FORCE"]));
                    combo_check(configure_virtual_cmb, Convert.ToString(dt.Rows[0]["CFA_TS_CONFIG"]));
                    combo_check(transfer_servers_cmb, Convert.ToString(dt.Rows[0]["CFA_TRANSFER_SERVER"]));
                    combo_check(backup_database_cmb, Convert.ToString(dt.Rows[0]["CFA_BACKUP_DATABASE"]));
                    combo_check(settle_credit_cmb, Convert.ToString(dt.Rows[0]["CFA_CREDIT_CARD_SETTLEMENT"]));
                    combo_check(reprint_kitchen_cmb, Convert.ToString(dt.Rows[0]["CFA_KITCHEN_REPRINT"]));
                    combo_check(configure_receipt_cmb, Convert.ToString(dt.Rows[0]["CFA_SETUP_RECEIPT_NOTES"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["CFA_MANAGE_TIMECLOCK_OWNTIME"]));
                    combo_check(add_employee_cmb, Convert.ToString(dt.Rows[0]["CFA_SETUP_ADD_EMPLOYEES"]));
                    combo_check(modify_employee_cmb, Convert.ToString(dt.Rows[0]["CFA_SETUP_EDIT_EMPLOYEES"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["CFA_INVENTORY_PROMOTIONS"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["CFA_INVOICE_DISCOUNTS_BELOW_X"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["CFA_BUYBACKTRADE_ABOVE_SET_AMOUNT"]));
                    combo_check(view_historical_cmb, Convert.ToString(dt.Rows[0]["CFA_REPORTS_VIEW_HISTORICAL_DATA"]));
                    combo_check(limited_edit_lockdown_cmb, Convert.ToString(dt.Rows[0]["CFA_INVEN_MISC_FIELD_LOCKDOWN"]));
                    combo_check(create_po_cmb, Convert.ToString(dt.Rows[0]["CFA_HH_Create_PO"]));
                    combo_check(DSD_cmb, Convert.ToString(dt.Rows[0]["CFA_HH_DSD"]));
                    combo_check(DSD_credit_cmb, Convert.ToString(dt.Rows[0]["CFA_HH_DSD_Credit"]));
                    combo_check(po_receive_item_cmb, Convert.ToString(dt.Rows[0]["CFA_HH_PO_Receive"]));
                    combo_check(Inventory_edit_cmb, Convert.ToString(dt.Rows[0]["CFA_HH_Inv_Edit"]));
                    combo_check(inventory_adjust_cmb, Convert.ToString(dt.Rows[0]["CFA_HH_Inv_Adjust"]));
                    combo_check(inventory_count_cmb, Convert.ToString(dt.Rows[0]["CFA_HH_Inv_Count"]));
                    combo_check(setup_cmb, Convert.ToString(dt.Rows[0]["CFA_HH_Setup"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["CFA_CASHIER_OVEdt.Rows[0]IDE_LICENSESCAN"]));
                    combo_check(delete_inventory_cmb, Convert.ToString(dt.Rows[0]["CFA_INVEN_DELETE"]));
                    combo_check(manual_age_cmb, Convert.ToString(dt.Rows[0]["CFA_CASHIER_MANUALY_ENTER_AGE"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["CreateDate"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["DateDisabled"]));
                    combo_check(add_coupons_cmb, Convert.ToString(dt.Rows[0]["CFA_INVEN_ADD_COUPON"]));
                    combo_check(global_pricing_cmb, Convert.ToString(dt.Rows[0]["CFA_INVEN_GLOBALPRICING"]));
                    combo_check(labor_schedule_cmb, Convert.ToString(dt.Rows[0]["CFA_EMP_SCHEDULE_OVERRIDE"]));
                    combo_check(labor_schedule_cmb, Convert.ToString(dt.Rows[0]["CFA_LABOR_SCHEDULER"]));
                    // combo_check(,Convert.ToString(dt.Rows[0]["GLNumber"]));
                    combo_check(negative_price_cmb, Convert.ToString(dt.Rows[0]["CFA_NEGATIVE_PRICE_CHANGE"]));
                    combo_check(charge_at_cost_cmb, Convert.ToString(dt.Rows[0]["CFA_CUSTOMER_EDIT_CHARGEATCOST"]));
                    combo_check(fuel_off_cmb, Convert.ToString(dt.Rows[0]["CFA_GPI_FUEL_DRIVE_OFF"]));
                    //combo_check(,Convert.ToString(dt.Rows[0]["CFA_SETUP_VPDCONFIGURATION "]));

                    // retrive additional information pay rol information
                    EmployeeAdditionalInfoClass objAdditionalInfo = new EmployeeAdditionalInfoClass();
                    objAdditionalInfo.Cashier_ID = cmb_search_emp.SelectedValue.ToString();
                    DataTable dta = objPOSManagementService.retriveAddionalInfo(objAdditionalInfo);
                    if (dta.Rows.Count > 0)
                    {
                        txt_additional_fed_allown.Text = dta.Rows[0]["AdditionalFederalWithholdingAmount"].ToString();
                        txt_fed_allwnce.Text = dta.Rows[0]["FederalAllowances"].ToString();
                        txt_state_allown.Text = dta.Rows[0]["StateAllowances"].ToString();
                        state_additional_with_amount_txt.Text = dta.Rows[0]["AdditionalStateWithholdingAmount"].ToString();
                        state_additional_credits_txt.Text = dta.Rows[0]["StateAdditionalCredits"].ToString();
                        cmb_filing_status.SelectedIndex = Convert.ToInt32(dta.Rows[0]["TaxFilingStatus"]);
                        exclude_chk.IsChecked = Convert.ToBoolean(dta.Rows[0]["ExcludeInPayrollExp"]);
                        if (Convert.ToInt32(dta.Rows[0]["Exempt"]) == 0)
                        {
                            cmb_exempt.SelectedIndex = 1;
                        }
                        else if (Convert.ToInt32(dta.Rows[0]["Exempt"]) == 1)
                        {
                            cmb_exempt.SelectedIndex = 0;
                        }
                    }

                    // retrive employee job codes and hourly wage
                    EmployeeJobCodeClass objEmployeeJobCodeClass = new EmployeeJobCodeClass();
                    objEmployeeJobCodeClass.Cashier_ID = cmb_search_emp.SelectedValue.ToString();
                    DataTable dtJob = objPOSManagementService.retriveEmployeJob(objEmployeeJobCodeClass);
                    if (dtJob.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtJob.Rows.Count; i++)
                        {
                            DG_jobs.Rows.Add(dtJob.Rows[i]["JobCodeID"].ToString(), dtJob.Rows[i]["Hourly_Wage"].ToString(), dtJob.Rows[i]["OvertimeHourly_Wage"].ToString());
                        }
                    }
                    #endregion
                }
            }
            catch (Exception)
            {

            }

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
            try
            {
                if (cmb_search_emp.SelectedIndex > cmb_search_emp.MaxHeight)
                {
                    MessageBox.Show("No More Employees, thank you!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    cmb_search_emp.SelectedIndex = cmb_search_emp.SelectedIndex + 1;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btn_emp_prev_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btn_jobcode_Click(object sender, RoutedEventArgs e)
        {
            JobCodeSetupForm job = new JobCodeSetupForm();
            job.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            job.ShowDialog();
        }
        string value1;
        string value2;
        private void btn_add_job_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectVendorForm obj = new SelectVendorForm(1);
                obj.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                obj.ShowDialog();
                if (obj.set_jobCodeId != null)
                {
                    for(int i=0; i<DG_jobs.Rows.Count; i++)
                    {
                        if (DG_jobs.Rows[i].Cells[0].Value.ToString() == obj.set_jobCodeId)
                        {
                            MessageBox.Show("This Employee already has this job code listed.", "Stop", MessageBoxButton.OK, MessageBoxImage.Stop);
                            return;
                        }
                    }
                    NumberKeypaid objnkp = new NumberKeypaid(103);
                    objnkp.ShowDialog();
                    if (objnkp.set_value != null)
                    {
                        value1 = objnkp.set_value.ToString();
                        NumberKeypaid objkp = new NumberKeypaid(104);
                        objkp.ShowDialog();
                        if (objkp.set_value != null)
                        {
                            value2 = objkp.set_value;
                            DG_jobs.Rows.Add(obj.set_jobCodeId.ToString(), value1, value2);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnChangOvrtmWage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string oldValue = DG_jobs.CurrentRow.Cells[2].Value.ToString();
                NumberKeypaid objkb = new NumberKeypaid(103, oldValue);
                objkb.ShowDialog();
                if (objkb.set_value != null)
                {
                    DG_jobs.CurrentRow.Cells[2].Value = objkb.set_value;
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnChangHrWwage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string oldValue = DG_jobs.CurrentRow.Cells[1].Value.ToString();
                NumberKeypaid objkb = new NumberKeypaid(103, oldValue);
                objkb.ShowDialog();
                if (objkb.set_value != null)
                {
                    DG_jobs.CurrentRow.Cells[1].Value = objkb.set_value;
                }
            }
            catch (Exception)
            {
            }
        }

        private void btn_remove_job_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DG_jobs.SelectedRows.Count > 0)
                {

                    // remove from database
                    EmployeeJobCodeClass objEmployeeJobCode = new EmployeeJobCodeClass();
                    objEmployeeJobCode.Cashier_ID = txt_emp_id.Text;
                    objEmployeeJobCode.JobCodeID = DG_jobs.CurrentRow.Cells[0].Value.ToString();
                    objPOSManagementService.deleteSelectedJob(objEmployeeJobCode);
                    // remove from data grid.
                    DG_jobs.Rows.RemoveAt(DG_jobs.CurrentRow.Index);
                }
                else
                {
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        string image_name;
     
        private void lbl_imge_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                fldlg.ShowDialog();
                {
                    image_name = fldlg.FileName;
                    ImageSourceConverter isc = new ImageSourceConverter();
                    imgEmpPhoto.SetValue(Image.SourceProperty, isc.ConvertFromString(image_name));
                }

                fldlg = null;
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
            }
        }
        private void btnClorChange_Click(Button btn)
        {
               btn_per_func.Foreground = Brushes.Black;
               btn_per_func.Width = 115;
               btn_per_inventory.Foreground = Brushes.Black;
               btn_per_inventory.Width = 115;
               btn_per_customer.Foreground = Brushes.Black;
               btn_per_customer.Width = 115;
               btn_per_report.Foreground = Brushes.Black;
               btn_per_report.Width = 115;
               btn_per_setup.Foreground = Brushes.Black;
               btn_per_setup.Width = 115;
               btn_per_resturt.Foreground = Brushes.Black;
               btn_per_resturt.Width = 115;
               btn_per_handhold.Foreground = Brushes.Black;
               btn_per_handhold.Width = 115;
               btn.Foreground = Brushes.Yellow;
               btn.Width = 120;
        }

        private void btnSaveChagesEmp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_emp_id.Text != "")
                {
                    EmployeesDataClass objEmployeesData = new EmployeesDataClass();

                    objEmployeesData.Cashier_ID = txt_emp_id.Text;

                    objEmployeesData.CustNum = txt_customer.Text;
                            objEmployeesData.Dept_ID = cmb_cetegory.SelectedValue.ToString();
                            objEmployeesData.Password = txt_emp_passd.Text;
                            objEmployeesData.Swipe_ID = txt_cardswip.Text;
                            objEmployeesData.Hourly_Wage = txt_houlywages.Text;
                            objEmployeesData.Form_Color = 1;
                            objEmployeesData.CDL = "";
                            objEmployeesData.CustNum = txt_customer.Text;
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
                         
                            objEmployeesData.CFA_Receive_Items = combo_check(po_receive_item_cmb);
                            objEmployeesData.CFA_DO_POS = combo_check(create_po_cmb);
                            objEmployeesData.CFA_INSTANT_POS = combo_check(instant_po_cmb);
                            objEmployeesData.Section_ID = "";
                            objEmployeesData.CFA_Other_Tables = combo_check(other_tables_cmb);
                            objEmployeesData.CFA_Accept_Cash = combo_check(cash_pickups_cmb);
                            objEmployeesData.CFA_TRANSFER_NOSWIPE = combo_check(transfer_without_cmb);
                            objEmployeesData.CFA_ADD_CCTIPS = combo_check(cc_tips_cmb);
                            objEmployeesData.Disabled = Convert.ToByte(chkDisableEmployee.IsChecked);
                            //objEmployeesData.Admin_Access = dirty;
                            objEmployeesData.CFA_PRINT_HOLD = combo_check(hold_print_cmb);
                            objEmployeesData.CFA_Open_Cash_Drawer = combo_check(open_cash_cmb);
                            objEmployeesData.CCTipsNow = Convert.ToByte(chkTakeCcTips.IsChecked);
                            objEmployeesData.ReqClockIn = Convert.ToByte(requireClockinBeforeLogin.IsChecked);
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
                            objEmployeesData.Birthday = Convert.ToDateTime(txt_birthday.SelectedDate);
                            objEmployeesData.Picture = image_name;
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
                            objEmployeesData.Orig_Store_ID = "1001";
                            objEmployeesData.CD_Name = "P";
                            objEmployeesData.CFA_APPROVE_OLD_RETURNS = combo_check(allow_old_return_cmb);
                            objEmployeesData.CFA_APPROVE_EMERGENCY_CLOCKOUT = combo_check(approve_emer_cmb);
                            objEmployeesData.TimeWorkedThisPeriod = 0;
                            if (txt_start_overtime.Text == "")
                                objEmployeesData.OvertimeThreshold = 0;
                            else
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
                    objPOSManagementService.updateEmployeeRecord(objEmployeesData);
                    if(objEmployeesData.IsSuccessfull == true)
                    {
                        // updating of additional information table: Employee_Additional_Info
                        EmployeeAdditionalInfoClass objAddtionalInfo = new EmployeeAdditionalInfoClass();
                        objAddtionalInfo.Cashier_ID = txt_emp_id.Text;
                        objAddtionalInfo.AdditionalFederalWithholdingAmount = txt_additional_fed_allown.Text;
                        objAddtionalInfo.FederalAllowances = Convert.ToInt32(txt_fed_allwnce.Text);
                        objAddtionalInfo.StateAllowances = Convert.ToInt32(txt_state_allown.Text);
                        objAddtionalInfo.AdditionalStateWithholdingAmount = state_additional_with_amount_txt.Text;
                        objAddtionalInfo.StateAdditionalCredits = state_additional_credits_txt.Text;
                        if (cmb_exempt.SelectedIndex == 0)
                            objAddtionalInfo.Exempt = 1;
                        else
                            objAddtionalInfo.Exempt = 0;
                        objAddtionalInfo.TaxFilingStatus = cmb_filing_status.SelectedIndex;
                        objAddtionalInfo.ExcludeInPayrollExp = Convert.ToByte(exclude_chk.IsChecked);
                        objPOSManagementService.updateEmpAdditionalInfo(objAddtionalInfo);

                        // updating of employee job codes and hourly wage
                        if (DG_jobs.Rows.Count > 0)
                        {
                            EmployeeJobCodeClass objEmployeeJobCodeClass = new EmployeeJobCodeClass();
                            objEmployeeJobCodeClass.Cashier_ID = txt_emp_id.Text;
                            for (int i = 0; i < DG_jobs.Rows.Count; i++)
                            {
                                objEmployeeJobCodeClass.JobCodeID = DG_jobs.Rows[i].Cells[0].Value.ToString();
                                objEmployeeJobCodeClass.Hourly_Wage = Convert.ToDouble(DG_jobs.Rows[i].Cells[1].Value.ToString());
                                objEmployeeJobCodeClass.OvertimeHourly_Wage = Convert.ToDouble(DG_jobs.Rows[i].Cells[2].Value.ToString());
                                objPOSManagementService.updateEmpJobCose(objEmployeeJobCodeClass);
                            }
                        }
                        MessageBox.Show("Record Updated Successfully.","Information",MessageBoxButton.OK,MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void txt_houlywages_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox txt = sender as TextBox;
            objRegex.checkForNumericWithDot(e);
        }

    }
}
