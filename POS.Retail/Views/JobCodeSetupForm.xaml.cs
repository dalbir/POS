using System;
using System.Collections.Generic;
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
using POS.Domain.Common;
using POS.Services.Common;
using System.Data;

namespace POS.Retail
{
    /// <summary>
    /// Interaction logic for JobCodeSetupForm.xaml
    /// </summary>
    public partial class JobCodeSetupForm : Window
    {
        POSManagementService objPOSManagementService = new POSManagementService();
       public JobCodeSetupForm() //job_code_setup()
        {
           
            InitializeComponent();
            fill_jobcode();
            if (cmb_jobcodes_all.Items.IsEmpty == true)
            {
                txt_jobcode.IsEnabled = false;
                txt_wage_normal.IsEnabled = false;
                txt_wage_overtime.IsEnabled = false;

                check_assignable_admin_only.IsEnabled = false;
                check_cash_bank.IsEnabled = false;
                check_cash_tips.IsEnabled = false;
                check_CC_transactions.IsEnabled = false;
                check_delivery_tracking.IsEnabled = false;
                check_department_totals.IsEnabled = false;
                check_require_cash_count_screen.IsEnabled = false;
                check_require_cash_drawer.IsEnabled = false;

                cmb_rpt_number.IsEnabled = false;
            }
            else
            {
                cmb_jobcodes_all.SelectedIndex = 0;
            }
        }
        //GlobalClass glo = new GlobalClass();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fill_jobcode();
        }
        public void fill_jobcode()
        {
            DataTable dt = objPOSManagementService.getJobCodes();
           if(dt.Rows.Count > 0)
           {
               cmb_jobcodes_all.ItemsSource = dt.DefaultView;
               cmb_jobcodes_all.DisplayMemberPath = "JobCodeName";
               cmb_jobcodes_all.SelectedValuePath = "JobCodeID";
           }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
          

            if (cmb_jobcodes_all.Items.IsEmpty == true)
            {
                txt_jobcode.IsEnabled = true;
                txt_wage_normal.IsEnabled = true;
                txt_wage_overtime.IsEnabled = true;
                check_assignable_admin_only.IsEnabled = true;
                check_cash_bank.IsEnabled = true;
                check_cash_tips.IsEnabled = true;
                check_CC_transactions.IsEnabled = true;
                check_delivery_tracking.IsEnabled = true;
                check_department_totals.IsEnabled = true;
                check_require_cash_count_screen.IsEnabled = true;
                check_require_cash_drawer.IsEnabled = true;

                cmb_rpt_number.IsEnabled = true;
            }
            if (btn_add.Content.Equals("Add"))
            {
                btn_add.Content = "Save";
                cmb_jobcodes_all.SelectedIndex = -1;
                txt_jobcode.Text = "";
                txt_wage_normal.Text = "";
                txt_wage_overtime.Text = "";
                check_assignable_admin_only.IsChecked = false;
                check_cash_bank.IsChecked = false;
                check_cash_tips.IsChecked = false;
                check_CC_transactions.IsChecked = false;
                check_delivery_tracking.IsChecked = false;
                check_department_totals.IsChecked = false;
                check_require_cash_count_screen.IsChecked = false;
                check_require_cash_drawer.IsChecked = false;
                cmb_rpt_number.SelectedIndex = -1;

            }
            else if (btn_add.Content.Equals("Save"))
            {
                if (txt_jobcode.Text == "" || txt_wage_normal.Text == "" || txt_wage_overtime.Text =="")
                {
                    MessageBox.Show("Please enter the the Job Code ID, Wage and Overtime","Run Time Support",MessageBoxButton.OK,MessageBoxImage.Warning);
                }
                else
                {
                    JobCodeClass objJobCodeClass = new JobCodeClass();
                    objJobCodeClass.JobCodeID = "1001"+ txt_jobcode.Text;
                    objJobCodeClass.AccessToPos = Convert.ToByte(box_POS.IsChecked);// check_box_verification(box_POS);
                    objJobCodeClass.Print_DDR = Convert.ToByte(check_CC_transactions.IsChecked);
                    objJobCodeClass.DDR_Num_Copies = Convert.ToInt32(cmb_rpt_number.Text);
                    objJobCodeClass.Picture = null;
                    objJobCodeClass.Prompt_Cash_Tips = Convert.ToByte(check_cash_tips.IsChecked); // check_box_verification(check_cash_tips);
                    objJobCodeClass.Record_Cash_Bank = Convert.ToByte(check_cash_bank.IsChecked); // check_box_verification(check_cash_bank);
                    objJobCodeClass.Default_Wage = Convert.ToInt32(txt_wage_normal.Text);
                    objJobCodeClass.DDR_CC_Itemize = Convert.ToByte(check_CC_transactions.IsChecked); // check_box_verification(check_CC_transactions);
                    objJobCodeClass.Require_CD_Select = Convert.ToByte(check_require_cash_drawer.IsChecked);
                    objJobCodeClass.Require_Clockout_CashBreakdown = Convert.ToByte(check_require_cash_count_screen.IsChecked);
                    objJobCodeClass.Default_OvertimeWage = Convert.ToInt32(txt_wage_overtime.Text);
                    objJobCodeClass.AccessToDonationCenter = 0;
                    objJobCodeClass.AccessToProductionSoftware = 0;
                    objJobCodeClass.DeliveryTracking = Convert.ToByte(check_delivery_tracking.IsChecked);
                    objJobCodeClass.RoleVisibility = Convert.ToByte(check_CC_transactions.IsChecked);
                    objJobCodeClass.JobCodeName = txt_jobcode.Text;
                    objPOSManagementService.insertJobCodes(objJobCodeClass);
                    if(objJobCodeClass.IsSuccessfull == true)
                    {
                        btn_add.Content = "Save";
                        txt_jobcode.IsEnabled = false;
                        fill_jobcode();
                    }
                }
            }
        }

        public bool check_box_verification(CheckBox check)
        {
            if (check.IsChecked == true)
            {
                return Convert.ToBoolean(1);
            }
            else if (check.IsChecked == false)
            {
                return Convert.ToBoolean(0);
            }

            return Convert.ToBoolean(0);
        }

        private void cmb_jobcodes_all_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                JobCodeClass objJobCodeClass = new JobCodeClass();
                objJobCodeClass.JobCodeID = cmb_jobcodes_all.SelectedValue.ToString();
                DataTable dt = objPOSManagementService.RetriveJobCodeRecord(objJobCodeClass);
                if (dt.Rows.Count > 0)
                {
                    box_POS.IsChecked = Convert.ToBoolean(dt.Rows[0]["AccessToPos"]);
                    check_CC_transactions.IsChecked = Convert.ToBoolean(dt.Rows[0]["Print_DDR"]);
                    cmb_rpt_number.Text = dt.Rows[0]["DDR_Num_Copies"].ToString();
                    //  = Picture
                    check_cash_tips.IsChecked = Convert.ToBoolean(dt.Rows[0]["Prompt_Cash_Tips"]);
                    check_cash_bank.IsChecked = Convert.ToBoolean(dt.Rows[0]["Record_Cash_Bank"]);
                    txt_wage_normal.Text = dt.Rows[0]["Default_Wage"].ToString();
                    check_CC_transactions.IsChecked = Convert.ToBoolean(dt.Rows[0]["DDR_CC_Itemize"]);
                    check_require_cash_drawer.IsChecked = Convert.ToBoolean(dt.Rows[0]["Require_CD_Select"]);
                    check_require_cash_count_screen.IsChecked = Convert.ToBoolean(dt.Rows[0]["Require_Clockout_CashBreakdown"]);
                    txt_wage_overtime.Text = dt.Rows[0]["Default_OvertimeWage"].ToString();
                    //= AccessToDonationCenter
                    // = AccessToProductionSoftware
                    check_delivery_tracking.IsChecked = Convert.ToBoolean(dt.Rows[0]["DeliveryTracking"]);
                    check_CC_transactions.IsChecked = Convert.ToBoolean(dt.Rows[0]["RoleVisibility"]);
                    txt_jobcode.Text = dt.Rows[0]["JobCodeName"].ToString();
                }
            }
            catch(Exception ex)
            {

            }
        }
        public void checking_checkboxes(bool check, CheckBox box)
        {
            if (check == true)
            {
                box.IsChecked = true;
            }
            else if (check == false)
            {
                box.IsChecked = false;
            }
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_next_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmb_jobcodes_all.SelectedIndex < cmb_jobcodes_all.MaxHeight)
                {
                    cmb_jobcodes_all.SelectedIndex = cmb_jobcodes_all.SelectedIndex + 1;
                }
                else
                {
                    MessageBox.Show("No More Job Codes, thank you!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btn_previous_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmb_jobcodes_all.SelectedIndex > cmb_jobcodes_all.MinHeight)
                {
                    cmb_jobcodes_all.SelectedIndex = cmb_jobcodes_all.SelectedIndex - 1;
                }
                else
                {
                    MessageBox.Show("No More Job Codes, thank you!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmb_jobcodes_all.SelectedIndex != -1)
                {
                    if (txt_jobcode.Text == "" || txt_wage_normal.Text == "" || txt_wage_overtime.Text == "")
                    {
                        MessageBox.Show("Please enter the the Job Code ID, Wage and Overtime", "Run Time Support", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        JobCodeClass objJobCodeClass = new JobCodeClass();
                        objJobCodeClass.JobCodeID = "1001" + txt_jobcode.Text;
                        objJobCodeClass.AccessToPos = Convert.ToByte(box_POS);// check_box_verification(box_POS);
                        objJobCodeClass.Print_DDR = Convert.ToInt32(check_box_verification(check_CC_transactions));
                        objJobCodeClass.DDR_Num_Copies = Convert.ToInt32(cmb_rpt_number.Text);
                        objJobCodeClass.Picture = null;
                        objJobCodeClass.Prompt_Cash_Tips = Convert.ToByte(check_cash_tips); // check_box_verification(check_cash_tips);
                        objJobCodeClass.Record_Cash_Bank = Convert.ToByte(check_cash_bank); // check_box_verification(check_cash_bank);
                        objJobCodeClass.Default_Wage = Convert.ToInt32(txt_wage_normal.Text);
                        objJobCodeClass.DDR_CC_Itemize = Convert.ToByte(check_CC_transactions); // check_box_verification(check_CC_transactions);
                        objJobCodeClass.Require_CD_Select = Convert.ToByte(check_require_cash_drawer);
                        objJobCodeClass.Require_Clockout_CashBreakdown = Convert.ToByte(check_require_cash_count_screen);
                        objJobCodeClass.Default_OvertimeWage = Convert.ToInt32(txt_wage_overtime.Text);
                        objJobCodeClass.AccessToDonationCenter = 0;
                        objJobCodeClass.AccessToProductionSoftware = 0;
                        objJobCodeClass.DeliveryTracking = Convert.ToByte(check_delivery_tracking);
                        objJobCodeClass.RoleVisibility = Convert.ToByte(check_CC_transactions);
                        objJobCodeClass.JobCodeName = txt_jobcode.Text;
                        objPOSManagementService.updateJobCodes(objJobCodeClass);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmb_jobcodes_all.SelectedIndex != -1)
                {
                    JobCodeClass objjobcodeClass = new JobCodeClass();
                    objjobcodeClass.JobCodeID = cmb_jobcodes_all.SelectedItem.ToString();
                    objPOSManagementService.deleteJobCode(objjobcodeClass);
                    if (objjobcodeClass.IsSuccessfull == true)
                    {
                        txt_jobcode.Text = "";
                        txt_wage_normal.Text = "";
                        txt_wage_overtime.Text = "";

                        check_assignable_admin_only.IsChecked = false;
                        check_cash_bank.IsChecked = false;
                        check_cash_tips.IsChecked = false;
                        check_CC_transactions.IsChecked = false;
                        check_delivery_tracking.IsChecked = false;
                        check_department_totals.IsChecked = false;
                        check_require_cash_count_screen.IsChecked = false;
                        check_require_cash_drawer.IsChecked = false;

                        cmb_rpt_number.SelectedIndex = -1;

                        fill_jobcode();
                    }
                    else
                    {
                        MessageBox.Show("You Cannot Delete this Job Code because it is Currently assigned to one or more Employees", "Run Time Support", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }
                }
            }
            catch (Exception ex)
            {
 
            }
        }

        private void btn_permissions_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
