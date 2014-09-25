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

namespace POS.Retail
{
    /// <summary>
    /// Interaction logic for JobCodeSetupForm.xaml
    /// </summary>
    public partial class JobCodeSetupForm : Window
    {
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
            
        }
        public void fill_jobcode()
        {
            //glo.con.Open();

            //SqlCommand com = new SqlCommand("SELECT JobCodeID FROM JobCode", glo.con);
            //SqlDataReader rr = com.ExecuteReader();

            //while (rr.Read())
            //{
            //    cmb_jobcodes_all.Items.Add(rr["JobCodeID"]);
            //}
            //rr.Close();
            //glo.con.Close();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
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
            }
            else if (btn_add.Content.Equals("Save"))
            {
                if (txt_jobcode.Text == "" || txt_wage_normal.Text == "" || txt_wage_overtime.Text =="")
                {
                    MessageBox.Show("Please enter the the Job Code ID, Wage and Overtime");
                }
                else
                {
                    //glo.con.Open();
                    //using (SqlCommand cmd = new SqlCommand("SP_SAVE_JOBCODE", glo.con))
                    //{
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


                    //    param1 = new SqlParameter("@JobCodeID", txt_jobcode.Text);
                    //    param2 = new SqlParameter("@AccessToPos", check_box_verification(box_POS));
                    //    param3 = new SqlParameter("@Print_DDR", Convert.ToInt32(check_box_verification(check_CC_transactions)));//
                    //    param4 = new SqlParameter("@DDR_Num_Copies", Convert.ToInt32(cmb_rpt_number.Text));
                    //    //param5 = new SqlParameter("@Picture",		);
                    //    param6 = new SqlParameter("@Prompt_Cash_Tips", check_box_verification(check_cash_tips));
                    //    param7 = new SqlParameter("@Record_Cash_Bank", check_box_verification(check_cash_bank));
                    //    param8 = new SqlParameter("@Default_Wage",  Convert.ToInt32(txt_wage_normal.Text));
                    //    param9 = new SqlParameter("@DDR_CC_Itemize", check_box_verification(check_CC_transactions));
                    //    param10 = new SqlParameter("@Require_CD_Select", check_box_verification(check_require_cash_drawer));
                    //    param11 = new SqlParameter("@Require_Clockout_CashBreakdown", check_box_verification(check_require_cash_count_screen));
                    //    param12 = new SqlParameter("@Default_OvertimeWage",  Convert.ToInt32(txt_wage_overtime.Text));
                    //    param13 = new SqlParameter("@AccessToDonationCenter", Convert.ToBoolean(0));//
                    //    param14 = new SqlParameter("@AccessToProductionSoftware", Convert.ToBoolean(0));//
                    //    param15 = new SqlParameter("@DeliveryTracking", check_box_verification(check_delivery_tracking));
                    //    param16 = new SqlParameter("@RoleVisibility", check_box_verification(check_CC_transactions));//
                    //    param17 = new SqlParameter("@JobCodeName", txt_jobcode.Text);

                    //    cmd.Parameters.Add(param1);
                    //    cmd.Parameters.Add(param2);
                    //    cmd.Parameters.Add(param3);
                    //    cmd.Parameters.Add(param4);
                    //    //cmd.Parameters.Add(param5);
                    //    cmd.Parameters.Add(param6);
                    //    cmd.Parameters.Add(param7);
                    //    cmd.Parameters.Add(param8);
                    //    cmd.Parameters.Add(param9);
                    //    cmd.Parameters.Add(param10);
                    //    cmd.Parameters.Add(param11);
                    //    cmd.Parameters.Add(param12);
                    //    cmd.Parameters.Add(param13);
                    //    cmd.Parameters.Add(param14);
                    //    cmd.Parameters.Add(param15);
                    //    cmd.Parameters.Add(param16);
                    //    cmd.Parameters.Add(param17);

                    //    cmd.ExecuteNonQuery();
                    //}
                    //glo.con.Close();
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
            //if (cmb_jobcodes_all.SelectedIndex != -1)
            //{
            //    btn_add.Content = "Add";
            //    glo.con.Open();
            //    SqlCommand com = new SqlCommand("SELECT * FROM JobCode WHERE JobCodeID ='" + cmb_jobcodes_all.SelectedItem.ToString() + "'", glo.con);

            //    SqlDataReader rr = com.ExecuteReader();
            //    while (rr.Read())
            //    {
            //        txt_jobcode.Text = rr["JobCodeID"].ToString();
            //        txt_wage_normal.Text = (Convert.ToInt32(rr["Default_Wage"])).ToString();
            //        txt_wage_overtime.Text = (Convert.ToInt32(rr["Default_OvertimeWage"])).ToString();

            //        cmb_rpt_number.Text = (Convert.ToInt32(rr["DDR_Num_Copies"])).ToString();

            //        checking_checkboxes(Convert.ToBoolean(rr["Prompt_Cash_Tips"]), check_cash_tips);
            //        checking_checkboxes(Convert.ToBoolean(rr["Record_Cash_Bank"]), check_cash_bank);
            //        checking_checkboxes(Convert.ToBoolean(rr["DDR_CC_Itemize"]), check_CC_transactions);
            //        checking_checkboxes(Convert.ToBoolean(rr["Require_CD_Select"]), check_require_cash_drawer);

            //        //checking_checkboxes(Convert.ToBoolean(rr["Require_Clockout_CashBreakdown"]), check_department_totals);
            //        //checking_checkboxes(Convert.ToBoolean(rr["AccessToDonationCenter"]), check_);

            //        checking_checkboxes(Convert.ToBoolean(rr["AccessToProductionSoftware"]), box_POS);
            //        checking_checkboxes(Convert.ToBoolean(rr["DeliveryTracking"]), check_delivery_tracking);
            //        checking_checkboxes(Convert.ToBoolean(rr["RoleVisibility"]), check_assignable_admin_only);
            //    }
            //    rr.Close();
            //    glo.con.Close();
            //}
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
            if (cmb_jobcodes_all.SelectedIndex < cmb_jobcodes_all.MaxHeight)
            {
                cmb_jobcodes_all.SelectedIndex = cmb_jobcodes_all.SelectedIndex + 1;
            }
            else
            {
                MessageBox.Show("No More Job Codes, thank you!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_previous_Click(object sender, RoutedEventArgs e)
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

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            //if (cmb_jobcodes_all.SelectedIndex != -1)
            //{
            //    glo.con.Open();

            //    using (SqlCommand cmd = new SqlCommand("SP_UPDATE_JOBCODE", glo.con))
            //    {
            //        #region UPDATING THE JOBCODE
            //        cmd.CommandType = CommandType.StoredProcedure;

            //        SqlParameter param1 = null;
            //        SqlParameter param2 = null;
            //        SqlParameter param3 = null;
            //        SqlParameter param4 = null;
            //        //SqlParameter param5 = null;
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


            //        param1 = new SqlParameter("@JobCodeID", txt_jobcode.Text);
            //        param2 = new SqlParameter("@AccessToPos", check_box_verification(box_POS));
            //        param3 = new SqlParameter("@Print_DDR", Convert.ToInt32(check_box_verification(check_CC_transactions)));//
            //        param4 = new SqlParameter("@DDR_Num_Copies", Convert.ToInt32(cmb_rpt_number.Text));
            //        //param5 = new SqlParameter("@Picture",		);
            //        param6 = new SqlParameter("@Prompt_Cash_Tips", check_box_verification(check_cash_tips));
            //        param7 = new SqlParameter("@Record_Cash_Bank", check_box_verification(check_cash_bank));
            //        param8 = new SqlParameter("@Default_Wage", Convert.ToInt32(txt_wage_normal.Text));
            //        param9 = new SqlParameter("@DDR_CC_Itemize", check_box_verification(check_CC_transactions));
            //        param10 = new SqlParameter("@Require_CD_Select", check_box_verification(check_require_cash_drawer));
            //        param11 = new SqlParameter("@Require_Clockout_CashBreakdown", check_box_verification(check_require_cash_count_screen));
            //        param12 = new SqlParameter("@Default_OvertimeWage", Convert.ToInt32(txt_wage_overtime.Text));
            //        param13 = new SqlParameter("@AccessToDonationCenter", Convert.ToBoolean(0));//
            //        param14 = new SqlParameter("@AccessToProductionSoftware", Convert.ToBoolean(0));//
            //        param15 = new SqlParameter("@DeliveryTracking", check_box_verification(check_delivery_tracking));
            //        param16 = new SqlParameter("@RoleVisibility", check_box_verification(check_CC_transactions));//
            //        param17 = new SqlParameter("@JobCodeName", txt_jobcode.Text);

            //        cmd.Parameters.Add(param1);
            //        cmd.Parameters.Add(param2);
            //        cmd.Parameters.Add(param3);
            //        cmd.Parameters.Add(param4);
            //        //cmd.Parameters.Add(param5);
            //        cmd.Parameters.Add(param6);
            //        cmd.Parameters.Add(param7);
            //        cmd.Parameters.Add(param8);
            //        cmd.Parameters.Add(param9);
            //        cmd.Parameters.Add(param10);
            //        cmd.Parameters.Add(param11);
            //        cmd.Parameters.Add(param12);
            //        cmd.Parameters.Add(param13);
            //        cmd.Parameters.Add(param14);
            //        cmd.Parameters.Add(param15);
            //        cmd.Parameters.Add(param16);
            //        cmd.Parameters.Add(param17);

            //        cmd.ExecuteNonQuery();

            //        glo.con.Close();
            //        #endregion
            //    }
            //}
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_jobcodes_all.SelectedIndex != -1)
            {
                //glo.con.Open();
                //SqlCommand com = new SqlCommand("DELETE FROM JobCode WHERE JobCodeID = '" + cmb_jobcodes_all.SelectedItem.ToString() + "'", glo.con);

                //com.ExecuteNonQuery();
                //cmb_jobcodes_all.Items.Clear();

                //glo.con.Close();


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
        }
    }
}
