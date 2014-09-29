using POS.Retail.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using POS.Domain;
using POS.Domain.Common;
using POS.Services.Common;

namespace POS.Retail
{
    /// <summary>
    /// Interaction logic for CustomerForm.xaml
    /// </summary>
    /// 
    public partial class CustomerForm : Window
    {
        public CustomerClass objCustomerClass = new CustomerClass();
        RegexClass regclass = new RegexClass();
       // GlobalClass glo = new GlobalClass();
        string dt_format = "yyyy-MM-dd";
        string indx;
        Int32 count_cust_num = 0;
        List<string> cust_numbers = null;
        Int32 indx2 = 0;
        public CustomerForm()
        {
            InitializeComponent();
            //glo.getcon();

        }

        private void btn_add_customer_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (btn_add_customer.Content.Equals("Add"))
                {
                    btn_delete_customer.IsEnabled = false;
                    btn_update_custmer.IsEnabled = false;
                    btn_exit_custmer.Content = "Cancel";
                    txt_custmer_id.IsReadOnly = false;
                    btn_add_customer.Content = "Save";
                    Clear_Fields();
                    txt_custmer_id.Background = Brushes.White;
                }
                else if (btn_add_customer.Content.Equals("Save"))
                {
                    if (txt_custmer_id.Text.Length == 0)
                    {
                        MessageBox.Show("Please Insert Customer Id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        txt_custmer_id.Focus();
                    }
                    else if (txt_custmer_fname.Text.Length == 0)
                    {
                        MessageBox.Show("Please Insert Customer First Name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        txt_custmer_fname.Focus();
                    }
                    else if (txt_custmer_lname.Text.Length == 0)
                    {
                        MessageBox.Show("Please Insert Customer Last Name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        txt_custmer_lname.Focus();
                    }
                    else if (IsEmailSyntaxValid(txt_custmer_email.Text) == false)
                    {
                        MessageBox.Show("Invalid Email Address", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        txt_custmer_email.Focus();
                    }
                    else if (validate_date(txt_cus_app_date.Text) == false && txt_cus_app_date.Text.Length > 0)
                    {
                        MessageBox.Show("Invalid format of Application date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        txt_cus_app_date.Focus();
                    }
                    else if (validate_date(txt_cust_birthday.Text) == false && txt_cust_birthday.Text.Length > 0)
                    {
                        MessageBox.Show("Invalid format of Birthday date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        txt_cust_birthday.Focus();
                    }


                    else
                    {
                        sql_sp("INSERT");
                        //load_list();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool validate_date(string date_valid)
        {
            DateTime dt;
            bool validate_dt = DateTime.TryParseExact(date_valid, "MM/dd/yyyy", null, DateTimeStyles.None, out dt);
            return validate_dt;
        }
        private bool IsEmailSyntaxValid(string emailToValidate)
        {
            bool validate_email = true;
            if (emailToValidate.Length > 0)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(emailToValidate,
                    @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$") == false)
                {
                    validate_email = false;
                }
                else
                {
                    validate_email = true;
                }
            }
            return validate_email;
        }

        private void sql_sp(string statement_type)
        {
            try
            {
                objCustomerClass.flage = "insert";
                
                //if (txt_cus_bonaspoint.Text.Length > 0)
                //{
                //    sparam21 = new SqlParameter("@Bonus_Plan_Member", 1);
                //    cmd.Parameters.Add(sparam21);
                //}
                //else
                //{
                //    sparam21 = new SqlParameter("@Bonus_Plan_Member", "");
                //    cmd.Parameters.Add(sparam21);
                //}
                if (txt_cus_bonaspoint.Text.Length != 0)
                {
                    Convert.ToInt32(txt_cus_bonaspoint.Text);
                }
                string txExmpt,ReqPo,Pnotes,AccStandrd,chargCost;
                var typeex = 2;
                var typePo = 3;
                var typeNots = 2;
                var typeAcc = 2;
                var typeCost = 2;
                
                txExmpt = chk_tax_exempt.IsChecked.Value.ToString();
                ReqPo = chk_require_po_no.IsChecked.Value.ToString();
                Pnotes = chk_print_notes_receipt.IsChecked.Value.ToString();
                AccStandrd = rb_standard.IsChecked.Value.ToString();
                chargCost = chk_charge_at_cast.IsChecked.Value.ToString();
                
                if (txExmpt == "true")
                {
                    typeex = 1;
                }
                else if (txExmpt == "false")
                {
                    typeex = 0;
                }
                if (ReqPo == "true")
                {
                    typePo = 1;
                }
                else if (ReqPo == "false")
                {
                    typePo = 0;
                }
                if (Pnotes == "true")
                {
                    typeNots = 1;
                }
                else if (Pnotes == "false")
                {
                    typeNots = 0;
                }
                if (AccStandrd == "true" && txt_acc_open_date.Text.Length != 0)
                {
                    typeAcc = 1;
                }
                else if (AccStandrd== "false" && txt_acc_open_date.Text.Length != 0)
                {
                    typeAcc = 0;
                }
                if (chargCost == "true")
                {
                    typeCost = 1;
                }
                else if (chargCost == "false")
                {
                    typeCost = 0;
                }
                else
                {
                    objCustomerClass.CustNum = txt_custmer_id.Text.Trim();
                    objCustomerClass.First_Name = txt_custmer_fname.Text.Trim();
                    objCustomerClass.Last_Name = txt_custmer_lname.Text.Trim();
                    objCustomerClass.Company = txt_cus_compname.Text.Trim();
                    objCustomerClass.Address_1 = txt_cus_addres.Text.Trim();
                    objCustomerClass.Address_2 = txt_cus_addres2.Text.Trim();
                    objCustomerClass.City = txt_cus_city.Text.Trim();
                    objCustomerClass.State = txt_cus_state.Text.Trim();
                    objCustomerClass.Zip_Code = txt_cus_zipcode.Text.Trim();
                    objCustomerClass.Phone_1 = txt_cus_phone.Text.Trim();
                    objCustomerClass.Phone_2 = txt_cus_alphone.Text.Trim();
                    objCustomerClass.CC_Type =Convert.ToString( lstbx_credt_card_type.SelectedItem);
                    objCustomerClass.CC_Num = txt_crdt_nmber.Text.Trim();
                    objCustomerClass.CC_Exp = txt_expiration.Text.Trim();
                    objCustomerClass.Discount_Level = txt_cus_discont.Text.Trim();
                    objCustomerClass.Acct_Open_Date =Convert.ToDateTime( txt_acc_open_date.Text.Trim());
                    objCustomerClass.Acct_Close_Date =Convert.ToDateTime( txt_acc_close_date.Text.Trim());
                    objCustomerClass.Acct_Balance =Convert.ToDecimal( lbl_bal_due_figures.Content);
                    objCustomerClass.Acct_Max_Balance =Convert.ToDecimal( txt_max_bal.Text.Trim());
                    objCustomerClass.Bonus_Plan_Member =Convert.ToInt32( txt_cus_bonaspoint.Text.Trim());
                    objCustomerClass.Bonus_Points =Convert.ToInt32( txt_cus_bonaspoint.Text.Trim());
                    objCustomerClass.Tax_Exempt = typeex;
                    objCustomerClass.Member_Exp =Convert.ToDateTime( txt_membershp_exp.Text.Trim());
                    objCustomerClass.Dirty = 1;
                    objCustomerClass.Phone_3 = txt_mob_phone.Text.Trim();
                    objCustomerClass.Phone_4 = txt_fax.Text.Trim();
                    objCustomerClass.EMail = txt_custmer_email.Text.Trim();
                    objCustomerClass.County = txt_cus_country.Text.Trim();
                    objCustomerClass.Def_SP = "";
                    objCustomerClass.CreateDate =Convert.ToDateTime( System.DateTime.Today.ToString(dt_format));
                    objCustomerClass.Referral =Convert.ToString( cmb_referal_source.SelectedItem);
                    objCustomerClass.Birthday =Convert.ToDateTime( txt_cust_birthday.Text.Trim());
                    objCustomerClass.Last_Birthday_Bonus = "";
                    objCustomerClass.Last_Visit = Convert.ToDateTime(System.DateTime.Today.ToString(dt_format));
                    objCustomerClass.Require_PONum = typePo;
                    objCustomerClass.Max_Charge_NumDays=Convert.ToInt32(txt_over.Text);
                    objCustomerClass.Max_Charge_Amount=Convert.ToDecimal (txt_restrict_spnd_to.Text);
                    objCustomerClass.License_Num = txt_driver_licns_id.Text.Trim();
                    objCustomerClass.ID_Last_Checked = Convert.ToDateTime(System.DateTime.Today.ToString(dt_format));
                    objCustomerClass.Next_Start_Date =Convert.ToDateTime( txt_days_started.Text.Trim());
                    objCustomerClass.PrintNotes = typeNots;
                    objCustomerClass.Loyalty_Plan_ID= 0;
                    objCustomerClass.Tax_Rate_ID= Convert.ToInt32(cmb_tax_rate.SelectedItem);
                    objCustomerClass.Bill_To_Name= txt_bill_to.Text.Trim();
                    objCustomerClass.Contact_1= txt_bill_primery_contact.Text.Trim();
                    objCustomerClass.Contact_2= txt_bill_scndry_contact.Text.Trim();
                    objCustomerClass.Terms= txt_bill_terms.Text.Trim();
                    objCustomerClass.Resale_Num= txt_bill_resale_number.Text.Trim();
                    objCustomerClass.Last_Coupon=  Convert.ToDateTime(System.DateTime.Today.ToString(dt_format));
                    if( txt_acc_open_date.Text.Length != 0)
                     {
                          objCustomerClass.Account_Type= "0";
                     }
                    else if (rb_layaway.IsChecked == true && txt_acc_open_date.Text.Length != 0)
                    {
                        objCustomerClass.Account_Type= "1";
                    }
                    if (chk_charge_at_cast.IsChecked == true)
                    {
                        objCustomerClass.ChargeAtCost= 1;
                    }
                    else if (chk_charge_at_cast.IsChecked == false)
                    {
                        objCustomerClass.ChargeAtCost = 0;
                    }
                    objCustomerClass.Disabled = 0;
                    objCustomerClass.ImagePath = null;
                    objCustomerClass.License_ExpDate = Convert.ToDateTime(txt_license_exp_date.Text.Trim());
                    objCustomerClass.TaxID = txt_tax_id.Text.Trim();
                    objCustomerClass.SecretCode = "";
                    objCustomerClass.OnlineUserName = "";
                    objCustomerClass.OnlinePassword = "";
                    POSManagementService objMgtServices = new POSManagementService();
                    objMgtServices.InsertCustomerInfo(objCustomerClass);

                    CustomerAccountingTransactionClass objCusAccTrans = new CustomerAccountingTransactionClass();
                    objCusAccTrans.CustNum = txt_custmer_id.Text.Trim();
                    objCusAccTrans.EditSequence = "";
                    objMgtServices.insertCusAccTrans(objCusAccTrans);

                    CustomerAuthorizedClass objCustAutorized = new CustomerAuthorizedClass();
                    objCustAutorized.CustNum = txt_custmer_id.Text.Trim();
                    for (int i = 0; i < listBox_authorized.Items.Count; i++)
                    {
                        objCustAutorized.Member = listBox_authorized.Items[i].ToString();
                    }
                    objCustAutorized.Dirty = 1;
                    objMgtServices.insertCusAutho(objCustAutorized);

                    CustomerAutoClass objCusAuto = new CustomerAutoClass();
                    objCusAuto.CustNum = txt_custmer_id.Text.Trim();
                    objCusAuto.License = txt_driver_licns_id.Text.Trim();
                    objCusAuto.Make = "";
                    objCusAuto.Model = "";
                    objMgtServices.insertCusauto(objCusAuto);

                    CustomerEventsClass objCusEvents = new CustomerEventsClass();
                    objCusEvents.CustNum = txt_custmer_id.Text.Trim();
                    objCusEvents.Event_Date = Convert.ToDateTime(txt_event_date.Text.Trim());
                    objCusEvents.Event_Desc = txt_event_desctiption.Text.Trim();
                    objCusEvents.Dirty = 1;
                    objMgtServices.insertCusEvents(objCusEvents);

                    //CustomerGiftRegistryClass objCusGft = new CustomerGiftRegistryClass();
                    //objCusGft.CustNum = txt_custmer_id.Text.Trim();
                    CustomerNotesClass objCustNotes = new CustomerNotesClass();
                    objCustNotes.CustNum = txt_custmer_id.Text.Trim();
                    objCustNotes.Notes = txt_notes.Text.Trim();
                    


                    




                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
            //try
            //{
            //    if (glo.con.State == ConnectionState.Closed)
            //    {
            //        glo.con.Open();
            //    }
            //    using (SqlCommand cmd = new SqlCommand("SP_CUSTOMER_INSERT_UPDATE", glo.con))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        SqlParameter sparam1 = null;
            //        SqlParameter sparam2 = null;
            //        SqlParameter sparam3 = null;
            //        SqlParameter sparam4 = null;
            //        SqlParameter sparam5 = null;
            //        SqlParameter sparam6 = null;
            //        SqlParameter sparam7 = null;
            //        SqlParameter sparam8 = null;
            //        SqlParameter sparam9 = null;
            //        SqlParameter sparam10 = null;
            //        SqlParameter sparam11 = null;
            //        SqlParameter sparam12 = null;
            //        SqlParameter sparam13 = null;
            //        SqlParameter sparam14 = null;
            //        SqlParameter sparam15 = null;
            //        SqlParameter sparam16 = null;
            //        SqlParameter sparam17 = null;
            //        SqlParameter sparam18 = null;
            //        SqlParameter sparam19 = null;
            //        SqlParameter sparam20 = null;
            //        SqlParameter sparam21 = null;
            //        SqlParameter sparam22 = null;
            //        SqlParameter sparam23 = null;
            //        SqlParameter sparam24 = null;
            //        SqlParameter sparam25 = null;
            //        SqlParameter sparam26 = null;
            //        SqlParameter sparam27 = null;
            //        SqlParameter sparam28 = null;
            //        SqlParameter sparam29 = null;
            //        SqlParameter sparam30 = null;
            //        SqlParameter sparam31 = null;
            //        SqlParameter sparam32 = null;
            //        SqlParameter sparam33 = null;
            //        SqlParameter sparam34 = null;
            //        SqlParameter sparam35 = null;
            //        SqlParameter sparam36 = null;
            //        SqlParameter sparam37 = null;
            //        SqlParameter sparam38 = null;
            //        SqlParameter sparam39 = null;
            //        SqlParameter sparam40 = null;
            //        SqlParameter sparam41 = null;
            //        SqlParameter sparam42 = null;
            //        SqlParameter sparam43 = null;
            //        SqlParameter sparam44 = null;
            //        SqlParameter sparam45 = null;
            //        SqlParameter sparam46 = null;
            //        SqlParameter sparam47 = null;
            //        SqlParameter sparam48 = null;
            //        SqlParameter sparam49 = null;
            //        SqlParameter sparam50 = null;
            //        SqlParameter sparam51 = null;
            //        SqlParameter sparam52 = null;
            //        SqlParameter sparam53 = null;
            //        SqlParameter sparam54 = null;
            //        SqlParameter sparam55 = null;
            //        SqlParameter sparam56 = null;
            //        SqlParameter sparam57 = null;
            //        SqlParameter sparam58 = null;
            //        SqlParameter sparam59 = null;
            //        SqlParameter sparam60 = null;
            //        SqlParameter sparam61 = null;

            //        sparam1 = new SqlParameter("@CustNum ", txt_custmer_id.Text);
            //        sparam2 = new SqlParameter("@First_Name", txt_custmer_fname.Text);
            //        sparam3 = new SqlParameter("@Last_Name", txt_custmer_lname.Text);
            //        sparam4 = new SqlParameter("@Company", txt_cus_compname.Text);
            //        sparam5 = new SqlParameter("@Address_1", txt_cus_addres.Text);
            //        sparam6 = new SqlParameter("@Address_2", txt_cus_addres2.Text);
            //        sparam7 = new SqlParameter("@City", txt_cus_city.Text);
            //        sparam8 = new SqlParameter("@State", txt_cus_state.Text);
            //        sparam9 = new SqlParameter("@Zip_Code", txt_cus_zipcode.Text);
            //        sparam10 = new SqlParameter("@Phone_1", txt_cus_phone.Text);
            //        sparam11 = new SqlParameter("@Phone_2", txt_cus_alphone.Text);
            //        sparam12 = new SqlParameter("@CC_Type", lstbx_credt_card_type.SelectedItem);
            //        sparam13 = new SqlParameter("@CC_Num", txt_crdt_nmber.Text);
            //        sparam14 = new SqlParameter("@CC_Exp", txt_expiration.Text);
            //        sparam15 = new SqlParameter("@Discount_Level", cmb_cust_pricelevel.SelectedItem);
            //        if (txt_cus_discont.Text.Length > 0)
            //        {
            //            sparam16 = new SqlParameter("@Discount_Percent", Convert.ToDecimal(txt_cus_discont.Text));
            //            cmd.Parameters.Add(sparam16);
            //        }
            //        if (txt_acc_open_date.Text.Length == 0)
            //        {
            //            sparam17 = new SqlParameter("@Acct_Open_Date", "");
            //        }
            //        else
            //        {
            //            sparam17 = new SqlParameter("@Acct_Open_Date", txt_acc_open_date.Text);
            //        }
            //        if (txt_acc_close_date.Text.Length == 0)
            //        {
            //            sparam18 = new SqlParameter("@Acct_Close_Date", "");
            //        }
            //        else
            //        {
            //            sparam18 = new SqlParameter("@Acct_Close_Date", txt_acc_close_date.Text);
            //        }
            //        sparam19 = new SqlParameter("@Acct_Balance", lbl_bal_due_figures.Content);
            //        sparam20 = new SqlParameter("@Acct_Max_Balance", txt_max_bal.Text);
            //        if (txt_cus_bonaspoint.Text.Length > 0)
            //        {
            //            sparam21 = new SqlParameter("@Bonus_Plan_Member", 1);
            //            cmd.Parameters.Add(sparam21);
            //        }
            //        else
            //        {
            //            sparam21 = new SqlParameter("@Bonus_Plan_Member", "");
            //            cmd.Parameters.Add(sparam21);
            //        }
            //        if (txt_cus_bonaspoint.Text.Length != 0)
            //        {
            //            sparam22 = new SqlParameter("@Bonus_Points", Convert.ToInt32(txt_cus_bonaspoint.Text));
            //            cmd.Parameters.Add(sparam22);
            //        }
            //        if (chk_tax_exempt.IsChecked == true)
            //        {
            //            sparam23 = new SqlParameter("@Tax_Exempt", 1);
            //            cmd.Parameters.Add(sparam23);
            //        }
            //        else if (chk_tax_exempt.IsChecked == false)
            //        {
            //            sparam23 = new SqlParameter("@Tax_Exempt", "");
            //            cmd.Parameters.Add(sparam23);
            //        }
            //        if (txt_membershp_exp.Text.Length > 0)
            //        {
            //            sparam24 = new SqlParameter("@Member_Exp", Convert.ToDateTime(txt_membershp_exp.Text));
            //            cmd.Parameters.Add(sparam24);
            //        }
            //        sparam25 = new SqlParameter("@Dirty", 1);
            //        sparam26 = new SqlParameter("@Phone_3", txt_mob_phone.Text);
            //        sparam27 = new SqlParameter("@Phone_4", txt_fax.Text);
            //        sparam28 = new SqlParameter("@EMail", txt_custmer_email.Text);
            //        sparam29 = new SqlParameter("@County", txt_cus_country.Text);
            //        sparam30 = new SqlParameter("@Def_SP", "");
            //        if (statement_type == "INSERT")
            //        {
            //            sparam31 = new SqlParameter("@CreateDate", System.DateTime.Today.ToString(dt_format));
            //            cmd.Parameters.Add(sparam31);
            //        }
            //        sparam32 = new SqlParameter("@Referral", cmb_referal_source.SelectedItem);
            //        sparam33 = new SqlParameter("@Birthday", txt_cust_birthday.Text);
            //        sparam34 = new SqlParameter("@Last_Birthday_Bonus", "");
            //        sparam35 = new SqlParameter("@Last_Visit", System.DateTime.Today.ToString(dt_format));
            //        if (chk_require_po_no.IsChecked == true)
            //        {
            //            sparam36 = new SqlParameter("@Require_PONum", 1);
            //            cmd.Parameters.Add(sparam36);
            //        }
            //        else if (chk_require_po_no.IsChecked == false)
            //        {
            //            sparam36 = new SqlParameter("@Require_PONum", "");
            //            cmd.Parameters.Add(sparam36);
            //        }
            //        if (txt_over.Text.Length != 0)
            //        {
            //            sparam37 = new SqlParameter("@Max_Charge_NumDays", Convert.ToInt32(txt_over.Text));
            //            cmd.Parameters.Add(sparam37);
            //        }
            //        if (txt_restrict_spnd_to.Text.Length != 0)
            //        {
            //            sparam38 = new SqlParameter("@Max_Charge_Amount", txt_restrict_spnd_to.Text);
            //            cmd.Parameters.Add(sparam38);
            //        }
            //        sparam39 = new SqlParameter("@License_Num", txt_driver_licns_id.Text);
            //        sparam40 = new SqlParameter("@ID_Last_Checked", System.DateTime.Today.ToString(dt_format));
            //        sparam41 = new SqlParameter("@Next_Start_Date", txt_days_started.Text);
            //        sparam42 = new SqlParameter("@Checking_AcctNum", "");
            //        if (chk_print_notes_receipt.IsChecked == true)
            //        {
            //            sparam43 = new SqlParameter("@PrintNotes", 1);
            //            cmd.Parameters.Add(sparam43);
            //        }
            //        else if (chk_print_notes_receipt.IsChecked == false)
            //        {
            //            sparam43 = new SqlParameter("@PrintNotes", "");
            //            cmd.Parameters.Add(sparam43);
            //        }
            //        sparam44 = new SqlParameter("@Loyalty_Plan_ID", 0);
            //        sparam45 = new SqlParameter("@Tax_Rate_ID", Convert.ToInt32(cmb_tax_rate.SelectedItem));
            //        sparam46 = new SqlParameter("@Bill_To_Name", txt_bill_to.Text);
            //        sparam47 = new SqlParameter("@Contact_1", txt_bill_primery_contact.Text);
            //        sparam48 = new SqlParameter("@Contact_2", txt_bill_scndry_contact.Text);
            //        sparam49 = new SqlParameter("@Terms", txt_bill_terms.Text);
            //        sparam50 = new SqlParameter("@Resale_Num", txt_bill_resale_number.Text);
            //        sparam51 = new SqlParameter("@Last_Coupon", System.DateTime.Today.ToString(dt_format));
            //        if (rb_standard.IsChecked == true && txt_acc_open_date.Text.Length != 0)
            //        {
            //            sparam52 = new SqlParameter("@Account_Type", "0");
            //            cmd.Parameters.Add(sparam52);
            //        }
            //        else if (rb_layaway.IsChecked == true && txt_acc_open_date.Text.Length != 0)
            //        {
            //            sparam52 = new SqlParameter("@Account_Type", "1");
            //            cmd.Parameters.Add(sparam52);
            //        }
            //        if (chk_charge_at_cast.IsChecked == true)
            //        {
            //            sparam53 = new SqlParameter("@ChargeAtCost", 1);
            //            cmd.Parameters.Add(sparam53);
            //        }
            //        else if (chk_charge_at_cast.IsChecked == false)
            //        {
            //            sparam53 = new SqlParameter("@ChargeAtCost", "");
            //            cmd.Parameters.Add(sparam53);
            //        }
            //        sparam54 = new SqlParameter("@Disabled", null);
            //        sparam55 = new SqlParameter("@ImagePath", null);
            //        sparam56 = new SqlParameter("@License_ExpDate", txt_license_exp_date.Text);
            //        sparam57 = new SqlParameter("@TaxID", txt_tax_id.Text);
            //        sparam58 = new SqlParameter("@SecretCode", "");
            //        sparam59 = new SqlParameter("@OnlineUserName", "");
            //        sparam60 = new SqlParameter("@OnlinePassword", "");
            //        sparam61 = new SqlParameter("@Statement_Type", statement_type);


            //        cmd.Parameters.Add(sparam1);
            //        cmd.Parameters.Add(sparam2);
            //        cmd.Parameters.Add(sparam3);
            //        cmd.Parameters.Add(sparam4);
            //        cmd.Parameters.Add(sparam5);
            //        cmd.Parameters.Add(sparam6);
            //        cmd.Parameters.Add(sparam7);
            //        cmd.Parameters.Add(sparam8);
            //        cmd.Parameters.Add(sparam9);
            //        cmd.Parameters.Add(sparam10);
            //        cmd.Parameters.Add(sparam11);
            //        cmd.Parameters.Add(sparam12);
            //        cmd.Parameters.Add(sparam13);
            //        cmd.Parameters.Add(sparam14);
            //        cmd.Parameters.Add(sparam15);
            //        cmd.Parameters.Add(sparam17);
            //        cmd.Parameters.Add(sparam18);
            //        cmd.Parameters.Add(sparam19);
            //        cmd.Parameters.Add(sparam20);
            //        cmd.Parameters.Add(sparam25);
            //        cmd.Parameters.Add(sparam26);
            //        cmd.Parameters.Add(sparam27);
            //        cmd.Parameters.Add(sparam28);
            //        cmd.Parameters.Add(sparam29);
            //        cmd.Parameters.Add(sparam30);
            //        cmd.Parameters.Add(sparam32);
            //        cmd.Parameters.Add(sparam33);
            //        cmd.Parameters.Add(sparam34);
            //        cmd.Parameters.Add(sparam35);
            //        cmd.Parameters.Add(sparam39);
            //        cmd.Parameters.Add(sparam40);
            //        cmd.Parameters.Add(sparam41);
            //        cmd.Parameters.Add(sparam42);
            //        cmd.Parameters.Add(sparam44);
            //        cmd.Parameters.Add(sparam45);
            //        cmd.Parameters.Add(sparam46);
            //        cmd.Parameters.Add(sparam47);
            //        cmd.Parameters.Add(sparam48);
            //        cmd.Parameters.Add(sparam49);
            //        cmd.Parameters.Add(sparam50);
            //        cmd.Parameters.Add(sparam51);
            //        cmd.Parameters.Add(sparam54);
            //        cmd.Parameters.Add(sparam55);
            //        cmd.Parameters.Add(sparam56);
            //        cmd.Parameters.Add(sparam57);
            //        cmd.Parameters.Add(sparam58);
            //        cmd.Parameters.Add(sparam59);
            //        cmd.Parameters.Add(sparam60);
            //        cmd.Parameters.Add(sparam61);

            //        cmd.ExecuteNonQuery();

            //    }
            //    if (statement_type == "INSERT")
            //    {
            //        cust_insert_shft_tos();
            //    }
            //    else if (statement_type == "UPDATE")
            //    {
            //        SqlCommand cmd_count_cust_shftos = new SqlCommand("select count(*) from Customer_ShipTos where CustNum like '%" + txt_custmer_id.Text + "%'", glo.con);
            //        if (Convert.ToInt32(cmd_count_cust_shftos.ExecuteScalar()) == 0)
            //        {
            //            cust_insert_shft_tos();
            //        }
            //        else
            //        {
            //            SqlCommand cmd_update_cust_shftos = new SqlCommand("UPDATE Customer_ShipTos SET First_Name='" + txt_shipping_first_name.Text + "', Last_Name ='" + txt_shipping_last_name.Text + "' " +
            //            ",Company='" + txt_shiping_company_name.Text + "',Address_1='" + txt_shiping_st_address.Text + "',Address_2='" + txt_shiping_extnd_adres.Text + "',City ='" + txt_shiping_city.Text + "' ," +
            //            "State='" + txt_shiping_state.Text + "',Zip_Code='" + txt_shiping_zip.Text + "',Phone='" + txt_shipng_phone_number.Text + "',Dirty ='True' ,County='" + txt_shiping_country.Text + "'," +
            //            "DeliveryAddressSpecialInstructions='' WHERE CustNum='" + txt_custmer_id.Text + "'", glo.con);
            //            cmd_update_cust_shftos.ExecuteNonQuery();
            //        }
            //    }
            //    if (glo.con.State == ConnectionState.Closed)
            //    {
            //        glo.con.Open();
            //    }
            //    SqlCommand cmd_chk_cus_notes = new SqlCommand("select count(*) from Customer_Notes where CustNum='" + txt_custmer_id.Text + "'", glo.con);
            //    if (Convert.ToInt32(cmd_chk_cus_notes.ExecuteScalar()) == 0)
            //    {
            //        SqlCommand cmd_notes_insert = new SqlCommand("Insert into Customer_Notes (CustNum , Notes) values ('" + txt_custmer_id.Text + "','" + txt_notes.Text + "')", glo.con);
            //        cmd_notes_insert.ExecuteNonQuery();
            //    }
            //    else
            //    {
            //        SqlCommand cmd_notes_update = new SqlCommand("update Customer_Notes set Notes ='" + txt_notes.Text + "' where  CustNum like '%" + txt_custmer_id.Text + "%'", glo.con);
            //        cmd_notes_update.ExecuteNonQuery();
            //    }
            //    SqlCommand cmd_customer_swipes_del = new SqlCommand("delete from Customer_Swipes where CustNum like '%" + txt_custmer_id.Text + "%'", glo.con);
            //    cmd_customer_swipes_del.ExecuteNonQuery();
            //    for (int i = 0; i < lstbx_card_swip_ids.Items.Count; i++)
            //    {
            //        SqlCommand cmd_customer_swipes_insert = new SqlCommand("insert into Customer_Swipes( CustNum, Swipe_ID )values ('" + txt_custmer_id.Text + "','" + lstbx_card_swip_ids.Items[i].ToString() + "')", glo.con);
            //        cmd_customer_swipes_insert.ExecuteNonQuery();
            //    }
            //    SqlCommand cmd_customer_auths_del = new SqlCommand("delete from Customer_Authorized where CustNum like '%" + txt_custmer_id.Text + "%'", glo.con);
            //    cmd_customer_auths_del.ExecuteNonQuery();
            //    for (int i = 0; i < listBox_authorized.Items.Count; i++)
            //    {
            //        SqlCommand cmd_customer_auths_insert = new SqlCommand("insert into Customer_Authorized( CustNum, Member,Dirty )values ('" + txt_custmer_id.Text + "','" + listBox_authorized.Items[i].ToString() + "','True')", glo.con);
            //        cmd_customer_auths_insert.ExecuteNonQuery();
            //    }

            //    if (glo.con.State == ConnectionState.Open)
            //    {
            //        glo.con.Close();
            //    }
            //    cancel();

            //    load_list();

            //    int res = cust_numbers.FindIndex(label => label == txt_custmer_id.Text);

            //    indx2 = res;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        private void cust_insert_shft_tos()
        {
            //if (glo.con.State == ConnectionState.Closed)
            //{
            //    glo.con.Open();
            //}
            //if (txt_shipping_first_name.Text.Length != 0 ||
            //            txt_shipping_last_name.Text.Length != 0 ||
            //            txt_shiping_company_name.Text.Length != 0 ||
            //            txt_shipng_phone_number.Text.Length != 0 ||
            //            txt_shiping_st_address.Text.Length != 0 ||
            //            txt_shiping_city.Text.Length != 0 ||
            //            txt_shiping_extnd_adres.Text.Length != 0 ||
            //            txt_shiping_state.Text.Length != 0 ||
            //            txt_shiping_zip.Text.Length != 0 ||
            //            txt_shiping_country.Text.Length != 0)
            //{
            //    SqlCommand cmd_cust_shfto_insert = new SqlCommand("INSERT INTO Customer_ShipTos(CustNum,First_Name,Last_Name,Company,Address_1,Address_2,City,State,Zip_Code,Phone,Dirty,County,DeliveryAddressSpecialInstructions) values " +
            //        "('" + txt_custmer_id.Text + "','" + txt_shipping_first_name.Text + "','" + txt_shipping_last_name.Text + "','" + txt_shiping_company_name.Text + "','" + txt_shiping_st_address.Text + "','" + txt_shiping_extnd_adres.Text + "'," +
            //         "'" + txt_shiping_city.Text + "','" + txt_shiping_state.Text + "','" + txt_shiping_zip.Text + "','" + txt_shipng_phone_number.Text + "','" + "True" + "','" + txt_shiping_country.Text + "','')", glo.con);
            //    cmd_cust_shfto_insert.ExecuteNonQuery();

            //}
            //if (glo.con.State == ConnectionState.Open)
            //{
            //    glo.con.Close();
            //}
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //txt_custmer_id.IsReadOnly = true;
            txt_custmer_id.Background = Brushes.Yellow;
            txt_custmer_id.IsReadOnly = true;
            for (int i = 65; i <= 90; i++)
            {
                cmb_cust_pricelevel.Items.Add(Convert.ToChar(i));
            }
            cmb_cust_pricelevel.SelectedIndex = 0;
            load_customers();
        }
        private void load_customers()
        {
            //try
            //{
            //    if (glo.con.State == ConnectionState.Closed)
            //    {
            //        glo.con.Open();
            //    }
            //    SqlCommand cmd_count_custs = new SqlCommand("select COUNT(CustNum) from Customer", glo.con);
            //    if (Convert.ToInt32(cmd_count_custs.ExecuteScalar()) != 0)
            //    {

            //        load_list();
            //        //MessageBox.Show(indx + " " + cust_numbers.Count());
            //    }
            //    indx = cust_numbers[indx2];
            //    indx2 = 0;
            //    count_cust_num = cust_numbers.Count();
            //    next_prev(indx, "NAVIGATE");
            //    indx2 = 0;
            //    //else
            //    //{
            //    //    btn_customer_next.IsEnabled = false;
            //    //    btn_custmer_prev.IsEnabled = false;
            //    //}
            //    if (glo.con.State == ConnectionState.Open)
            //    {
            //        glo.con.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        private void load_list()
        {
            //try
            //{
            //    if (glo.con.State == ConnectionState.Closed)
            //    {
            //        glo.con.Open();
            //    }
            //    SqlCommand cmd_cust_num = new SqlCommand("SELECT CustNum FROM Customer order by CreateDate", glo.con);
            //    cust_numbers = new List<string>();
            //    SqlDataReader rr1;
            //    rr1 = cmd_cust_num.ExecuteReader();
            //    while (rr1.Read())
            //    {
            //        cust_numbers.Add(rr1["CustNum"].ToString());
            //        //MessageBox.Show(rr1["CustNum"].ToString());
            //    }
            //    rr1.Close();
            //    if (glo.con.State == ConnectionState.Open)
            //    {
            //        glo.con.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        private void next_prev(string indx, string st_type)
        {
            //try
            //{
            //    if (glo.con.State == ConnectionState.Closed)
            //    {
            //        glo.con.Open();
            //    }
            //    using (SqlCommand cmd = new SqlCommand("dbo.SP_RETRIEVE_CUSTOMER"))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@CustNum", indx);
            //        cmd.Parameters.AddWithValue("@st_type", st_type);
            //        cmd.Connection = glo.con;

            //        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            //        {
            //            while (rdr.Read())
            //            {
            //                txt_custmer_id.Text = rdr.GetString(rdr.GetOrdinal("CustNum"));
            //                txt_custmer_fname.Text = rdr.GetString(rdr.GetOrdinal("First_Name"));
            //                txt_custmer_lname.Text = rdr.GetString(rdr.GetOrdinal("Last_Name"));
            //                txt_cus_compname.Text = rdr.GetString(rdr.GetOrdinal("Company"));
            //                txt_cus_addres.Text = rdr.GetString(rdr.GetOrdinal("Address_1"));
            //                txt_cus_addres2.Text = rdr.GetString(rdr.GetOrdinal("Address_2"));
            //                txt_cus_city.Text = rdr.GetString(rdr.GetOrdinal("City"));
            //                txt_cus_state.Text = rdr.GetString(rdr.GetOrdinal("State"));
            //                txt_cus_zipcode.Text = rdr.GetString(rdr.GetOrdinal("Zip_Code"));
            //                txt_cus_phone.Text = rdr.GetString(rdr.GetOrdinal("Phone_1"));
            //                txt_cus_alphone.Text = rdr.GetString(rdr.GetOrdinal("Phone_2"));
            //                lstbx_credt_card_type.SelectedItem = rdr.GetString(rdr.GetOrdinal("CC_Type"));
            //                txt_crdt_nmber.Text = rdr.GetString(rdr.GetOrdinal("CC_Num"));
            //                txt_expiration.Text = rdr.GetString(rdr.GetOrdinal("CC_Exp"));
            //                cmb_cust_pricelevel.SelectedItem = rdr.GetString(rdr.GetOrdinal("Discount_Level"));
            //                txt_cus_discont.Text = rdr["Discount_Percent"].ToString();
            //                if (rdr["Acct_Open_Date"].ToString() != "")
            //                {
            //                    DateTime acc_dt = Convert.ToDateTime(rdr["Acct_Open_Date"]);

            //                    txt_acc_open_date.Text = acc_dt.ToString("MM/dd/yyy");
            //                }
            //                else
            //                {
            //                    txt_acc_open_date.Clear();
            //                }
            //                //dp_open_act_Date.SelectedDate = Convert.ToDateTime(rdr.GetString(rdr.GetOrdinal("Acct_Open_Date")));
            //                //dp_close_act_Date.SelectedDate = Convert.ToDateTime(rdr.GetString(rdr.GetOrdinal("Acct_Close_Date")));
            //                if (rdr["Acct_Close_Date"].ToString() != "")
            //                {
            //                    DateTime acc_dt = Convert.ToDateTime(rdr["Acct_Close_Date"]);
            //                    txt_acc_close_date.Text = acc_dt.ToString("MM/dd/yyy");
            //                }
            //                else
            //                {
            //                    txt_acc_close_date.Clear();
            //                }
            //                lbl_bal_due_figures.Content = rdr["Acct_Balance"].ToString();
            //                txt_max_bal.Text = Convert.ToString(rdr["Acct_Max_Balance"]);
            //                txt_cus_bonaspoint.Text = Convert.ToString(rdr["Bonus_Points"]);
            //                if (rdr["Tax_Exempt"].ToString() == "True")
            //                {
            //                    chk_tax_exempt.IsChecked = true;
            //                }
            //                else if (rdr["Tax_Exempt"].ToString() == "False")
            //                {
            //                    chk_tax_exempt.IsChecked = false;
            //                }

            //                txt_membershp_exp.Text = rdr["Member_Exp"].ToString();
            //                txt_mob_phone.Text = rdr.GetString(rdr.GetOrdinal("Phone_3"));
            //                txt_fax.Text = rdr.GetString(rdr.GetOrdinal("Phone_4"));
            //                txt_custmer_email.Text = rdr.GetString(rdr.GetOrdinal("EMail"));
            //                txt_cus_country.Text = rdr.GetString(rdr.GetOrdinal("County"));
            //                cmb_referal_source.SelectedItem = rdr.GetString(rdr.GetOrdinal("Referral"));
            //                txt_cust_birthday.Text = Convert.ToDateTime(rdr["Birthday"]).ToString("MM-dd-yyyy");
            //                if (rdr["Require_PONum"].ToString() == "True")
            //                {
            //                    chk_require_po_no.IsChecked = true;
            //                }
            //                else if (rdr["Require_PONum"].ToString() == "False")
            //                {
            //                    chk_require_po_no.IsChecked = false;
            //                }
            //                txt_over.Text = Convert.ToString(rdr["Max_Charge_NumDays"]);
            //                txt_restrict_spnd_to.Text = Convert.ToString(rdr["Max_Charge_Amount"]);
            //                txt_driver_licns_id.Text = rdr.GetString(rdr.GetOrdinal("License_Num"));
            //                txt_days_started.Text = rdr["Next_Start_Date"].ToString();
            //                if (rdr["PrintNotes"].ToString() == "True")
            //                {
            //                    chk_print_notes_receipt.IsChecked = true;
            //                }
            //                else if (rdr["PrintNotes"].ToString() == "False")
            //                {
            //                    chk_print_notes_receipt.IsChecked = false;
            //                }
            //                cmb_tax_rate.SelectedItem = Convert.ToString(rdr["Tax_Rate_ID"]);
            //                txt_bill_to.Text = rdr.GetString(rdr.GetOrdinal("Bill_To_Name"));
            //                txt_bill_primery_contact.Text = rdr.GetString(rdr.GetOrdinal("Contact_1"));
            //                txt_bill_scndry_contact.Text = rdr.GetString(rdr.GetOrdinal("Contact_2"));
            //                txt_bill_terms.Text = rdr.GetString(rdr.GetOrdinal("Terms"));
            //                txt_bill_resale_number.Text = rdr.GetString(rdr.GetOrdinal("Resale_Num"));
            //                if (rdr["Account_Type"].ToString() == "0")
            //                {
            //                    rb_layaway.IsChecked = false;
            //                    rb_standard.IsChecked = true;
            //                }
            //                else if (rdr["Account_Type"].ToString() == "1")
            //                {
            //                    rb_standard.IsChecked = false;
            //                    rb_layaway.IsChecked = true;
            //                }
            //                if (rdr["Account_Type"].ToString() == "True")
            //                {
            //                    chk_charge_at_cast.IsChecked = true;
            //                }
            //                else if (rdr["Account_Type"].ToString() == "False")
            //                {
            //                    chk_charge_at_cast.IsChecked = false;
            //                }
            //                txt_license_exp_date.Text = rdr["License_ExpDate"].ToString();
            //                txt_tax_id.Text = rdr.GetString(rdr.GetOrdinal("TaxID"));



            //            }
            //            rdr.Close();
            //        }
            //    }
            //    if (glo.con.State == ConnectionState.Closed)
            //    {
            //        glo.con.Open();
            //    }
            //    SqlCommand cmd_count_cust_shftos = new SqlCommand("select count(*) from Customer_ShipTos where CustNum='" + indx + "'", glo.con);
            //    if (Convert.ToInt32(cmd_count_cust_shftos.ExecuteScalar()) != 0)
            //    {
            //        SqlCommand cmd_show_cust_shftos = new SqlCommand("select First_Name,Last_Name,Company,Address_1,Address_2,City,State,Zip_Code,Phone,Dirty,County from Customer_ShipTos where CustNum like '%" + txt_custmer_id.Text + "%'", glo.con);
            //        SqlDataReader rdr_show_cust_shftos = cmd_show_cust_shftos.ExecuteReader();
            //        rdr_show_cust_shftos.Read();
            //        txt_shipping_first_name.Text = rdr_show_cust_shftos["First_Name"].ToString();
            //        txt_shipping_last_name.Text = rdr_show_cust_shftos["Last_Name"].ToString();
            //        txt_shiping_company_name.Text = rdr_show_cust_shftos["Company"].ToString();
            //        txt_shiping_st_address.Text = rdr_show_cust_shftos["Address_1"].ToString();
            //        txt_shiping_extnd_adres.Text = rdr_show_cust_shftos["Address_2"].ToString();
            //        txt_shiping_city.Text = rdr_show_cust_shftos["City"].ToString();
            //        txt_shiping_state.Text = rdr_show_cust_shftos["State"].ToString();
            //        txt_shiping_zip.Text = rdr_show_cust_shftos["Zip_Code"].ToString();
            //        txt_shipng_phone_number.Text = rdr_show_cust_shftos["Phone"].ToString();
            //        rdr_show_cust_shftos.Close();
            //    }
            //    else
            //    {
            //        txt_shipping_first_name.Clear();
            //        txt_shipping_last_name.Clear();
            //        txt_shiping_company_name.Clear();
            //        txt_shipng_phone_number.Clear();
            //        txt_shiping_st_address.Clear();
            //        txt_shiping_city.Clear();
            //        txt_shiping_extnd_adres.Clear();
            //        txt_shiping_state.Clear();
            //        txt_shiping_zip.Clear();
            //        txt_shiping_country.Clear();
            //    }
            //    SqlCommand cmd3 = new SqlCommand("select a.CustNum,a.DateTime,b.Invoice_Number,b.ItemNum,b.DiffItemName,b.Quantity,b.PricePer,b.Store_ID,b.Serial_Num " +
            //                    "from Invoice_Totals a,Invoice_Itemized b where a.Invoice_Number=b.Invoice_Number and a.CustNum='" + indx + "' and a.Status not in('V','O') order by a.DateTime desc", glo.con);
            //    cmd3.ExecuteNonQuery();
            //    DataSet _Bind = new DataSet();

            //    SqlDataAdapter sda = new SqlDataAdapter(cmd3);
            //    sda.Fill(_Bind, "MyBinding");
            //    DataTable dt = _Bind.Tables[0];

            //    dg_cust_hsitory.SelectedValuePath = "Invoice_Number";

            //    dg_cust_hsitory.DataContext = _Bind;
            //    _Bind.Dispose();
            //    SqlCommand cmd_notes_count = new SqlCommand("Select count(*) from Customer_Notes where CustNum='" + indx + "'", glo.con);
            //    if (Convert.ToInt32(cmd_notes_count.ExecuteScalar()) != 0)
            //    {
            //        SqlCommand cmd_notes_show = new SqlCommand("Select Notes from Customer_Notes where CustNum='" + indx + "'", glo.con);
            //        SqlDataAdapter ad1 = new SqlDataAdapter(cmd_notes_show);
            //        DataTable dt1 = new DataTable();
            //        //check_dg = 1;
            //        ad1.Fill(dt1);
            //        txt_notes.Text = dt1.Rows[0]["Notes"].ToString();
            //    }
            //    else
            //    {
            //        txt_notes.Clear();
            //    }

            //    SqlCommand cmd_customer_swipes_count = new SqlCommand("Select count(*) from Customer_Swipes where CustNum='" + indx + "'", glo.con);
            //    if (Convert.ToInt32(cmd_customer_swipes_count.ExecuteScalar()) != 0)
            //    {
            //        SqlCommand cmd_customer_swipes_show = new SqlCommand("Select Swipe_ID from Customer_Swipes where CustNum='" + indx + "'", glo.con);
            //        SqlDataReader rdr_customer_swipes_show = cmd_customer_swipes_show.ExecuteReader();
            //        while (rdr_customer_swipes_show.Read())
            //        {
            //            lstbx_card_swip_ids.Items.Add(rdr_customer_swipes_show["Swipe_ID"].ToString());
            //        }
            //        rdr_customer_swipes_show.Close();
            //    }
            //    else
            //    {
            //        lstbx_card_swip_ids.Items.Clear();
            //    }
            //    SqlCommand cmd_customer_auths_count = new SqlCommand("Select count(*) from Customer_Authorized where CustNum='" + indx + "'", glo.con);
            //    if (Convert.ToInt32(cmd_customer_auths_count.ExecuteScalar()) != 0)
            //    {
            //        SqlCommand cmd_customer_auths_show = new SqlCommand("Select Member from Customer_Authorized where CustNum='" + indx + "'", glo.con);
            //        SqlDataReader rdr_customer_auths_show = cmd_customer_auths_show.ExecuteReader();
            //        while (rdr_customer_auths_show.Read())
            //        {
            //            listBox_authorized.Items.Add(rdr_customer_auths_show["Member"].ToString());
            //        }
            //        rdr_customer_auths_show.Close();
            //    }
            //    else
            //    {
            //        listBox_authorized.Items.Clear();
            //    }
            //    if (glo.con.State == ConnectionState.Open)
            //    {
            //        glo.con.Close();
            //    }
            //    //using (SqlCommand cmd1 = new SqlCommand("SP_RETRIEVE_CUSTOMER", glo.con))
            //    //{

            //    //    cmd1.CommandType = CommandType.StoredProcedure;
            //    //    SqlParameter param1 = null;
            //    //    SqlParameter param2 = null;
            //    //    param1=new SqlParameter("@CustNum", indx);
            //    //    param2 = new SqlParameter("@st_type", st_type);
            //    //    cmd1.Parameters.Add(param1);
            //    //    cmd1.Parameters.Add(param2);
            //    //    cmd1.ExecuteNonQuery();
            //    //    DataSet _Bind = new DataSet();

            //    //    SqlDataAdapter sda = new SqlDataAdapter(cmd1);

            //    //    sda.Fill(_Bind, "MyBinding");

            //    //    DataTable dt = _Bind.Tables[0];
            //    //    if (dt.Rows.Count == 0)
            //    //    {
            //    //        MessageBox.Show("Record not found", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    //    }
            //    //    else
            //    //    {
            //    //        dg_cust_hsitory.SelectedValuePath = "CustNum";
            //    //        dg_cust_hsitory.DataContext = _Bind;
            //    //        dg_cust_hsitory.Visibility = Visibility.Visible;
            //    //        dg_cust_hsitory.Visibility = Visibility.Hidden;
            //    //    }

            //    //}
            //    if (glo.con.State == ConnectionState.Open)
            //    {
            //        glo.con.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btn_exit_custmer_Click(object sender, RoutedEventArgs e)
        {
            if (btn_exit_custmer.Content.Equals("Cancel"))
            {
                indx = cust_numbers[indx2];
                next_prev(indx, "NAVIGATE");
                cancel();

            }
            else if (btn_exit_custmer.Content.Equals("Exit"))
            {
                this.Close();
            }



        }
        private void cancel()
        {
            btn_delete_customer.IsEnabled = true;
            btn_update_custmer.IsEnabled = true;
            btn_exit_custmer.Content = "Exit";
            txt_custmer_id.IsReadOnly = true;
            btn_add_customer.Content = "Add";
            txt_custmer_id.Background = Brushes.Yellow;
        }

        private void btn_update_custmer_Click(object sender, RoutedEventArgs e)
        {
            sql_sp("UPDATE");
        }

        private void btn_custmer_prev_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (indx2 > 0)
                {
                    indx = cust_numbers[indx2 - 1];
                    next_prev(indx, "NAVIGATE");
                    indx2 = indx2 - 1;
                }
                //else
                //{
                //    MessageBox.Show("You are viewing First Record", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_customer_next_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //MessageBox.Show(cust_numbers.Count.ToString());
                if (count_cust_num > 1 && indx2 != count_cust_num - 1)
                {
                    indx = cust_numbers[indx2 + 1];
                    next_prev(indx, "NAVIGATE");
                    indx2 = indx2 + 1;
                }

                //else
                //{
                //    MessageBox.Show("You are viewing Last Record", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txt_search_custmer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                search_customer();
            }
        }
        private void search_customer()
        {
            try
            {
                if (txt_search_custmer.Text.Length != 0)
                {
                    if (cust_numbers.Contains(txt_custmer_id.Text) == true)
                    {
                        indx2 = cust_numbers.IndexOf(txt_custmer_id.Text);
                        next_prev(txt_search_custmer.Text, "SEARCH");
                    }
                    else
                    {
                        MessageBox.Show("Cannot found the Customer you are searching for.", "Not Found", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    //int chk_indx=cust_numbers.FindIndex(label => label == txt_search_custmer.Text);
                    //if (chk_indx >= 0 && chk_indx <= cust_numbers.Count())
                    //{
                    //    for (int ind = 0; ind <= cust_numbers.Count(); ind++)
                    //    {
                    //        string x = cust_numbers[ind];
                    //        //if(cust_numbers.Contains(txt_custmer_id.Text)
                    //        //if (txt_search_custmer.Text == x)
                    //        if (String.Compare(txt_search_custmer.Text, x, true) == 0)
                    //        {
                    //            indx2 = ind;
                    //            next_prev(txt_search_custmer.Text, "SEARCH");
                    //            break;
                    //        }
                    //    }
                    //    int res = cust_numbers.FindIndex(label => label == txt_search_custmer.Text);
                    //    indx2 = res;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Cannot found the Customer you are searching for.", "Not Found", MessageBoxButton.OK, MessageBoxImage.Error);
                    //}
                    //MessageBox.Show(res+"");
                    //int result = list.Find(item => item > 20);
                    //indx2 = cust_numbers[txt_search_custmer.Text]
                    //MessageBox.Show(indx2.ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot found the Customer you are searching for.", "Not Found", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Clear_Fields()
        {
            lstbx_card_swip_ids.Items.Clear();
            listBox_authorized.Items.Clear();
            txt_notes.Clear();
            txt_custmer_id.Clear();
            txt_custmer_fname.Clear();
            txt_custmer_lname.Clear();
            txt_cus_compname.Clear();
            txt_cus_addres.Clear();
            txt_cus_addres2.Clear();
            txt_cus_city.Clear();
            txt_cus_state.Clear();
            txt_cus_zipcode.Clear();
            txt_cus_phone.Clear();
            txt_cus_alphone.Clear();
            lstbx_credt_card_type.SelectedIndex = -1;
            txt_crdt_nmber.Clear();
            txt_expiration.Clear();
            cmb_cust_pricelevel.SelectedIndex = 0;
            txt_cus_discont.Clear();
            txt_acc_close_date.Clear();
            txt_acc_open_date.Clear();
            lbl_bal_due_figures.Content = "";
            txt_max_bal.Clear();
            txt_cus_bonaspoint.Clear();
            chk_tax_exempt.IsChecked = false;
            txt_membershp_exp.Clear();
            txt_mob_phone.Clear();
            txt_fax.Clear();
            txt_custmer_email.Clear();
            txt_cus_country.Clear();
            cmb_referal_source.SelectedIndex = -1;
            txt_cust_birthday.Clear();
            chk_require_po_no.IsChecked = false;
            txt_over.Clear();
            txt_restrict_spnd_to.Clear();
            txt_driver_licns_id.Clear();
            txt_days_started.Clear();
            chk_print_notes_receipt.IsChecked = false;
            cmb_tax_rate.SelectedIndex = -1;
            txt_bill_to.Clear();
            txt_bill_primery_contact.Clear();
            txt_bill_scndry_contact.Clear();
            txt_bill_terms.Clear();
            txt_bill_resale_number.Clear();
            rb_standard.IsChecked = false;
            rb_layaway.IsChecked = false;
            chk_charge_at_cast.IsChecked = false;
            txt_license_exp_date.Clear();
            txt_tax_id.Clear();
            txt_shipping_first_name.Clear();
            txt_shipping_last_name.Clear();
            txt_shiping_company_name.Clear();
            txt_shipng_phone_number.Clear();
            txt_shiping_st_address.Clear();
            txt_shiping_city.Clear();
            txt_shiping_extnd_adres.Clear();
            txt_shiping_state.Clear();
            txt_shiping_zip.Clear();
            txt_shiping_country.Clear();
        }

        private void btn_lookup_Click(object sender, RoutedEventArgs e)
        {
            search_customer();
        }

        private void txt_acc_close_date_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBox focusedTextbox = (TextBox)sender;
            set_date_value(focusedTextbox);
        }

        private void txt_acc_open_date_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBox focusedTextbox = (TextBox)sender;
            set_date_value(focusedTextbox);

        }
        private void set_date_value(TextBox txt_box_date)
        {
            //frmCalender calender = new frmCalender(2);
            //calender.ShowDialog();
            //if (calender.set_the_date.ToShortDateString() != "1/1/0001")
            //{
            //    txt_box_date.Text = calender.set_the_date.ToString("MM/dd/yyyy");
            //}
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            txt_acc_open_date.Text = DateTime.Now.Date.ToString("MM/dd/yyyy");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            txt_acc_close_date.Text = DateTime.Now.Date.ToString("MM/dd/yyyy");
        }

        private void btn_plus_autorized_members_Click(object sender, RoutedEventArgs e)
        {
            //MyDialog dialog = new MyDialog("Enter the new Authorized member's name", "");
            //dialog.ShowDialog();

            //if (dialog.InputText.Length != 0)
            //{

            //    if (listBox_authorized.Items.Contains(dialog.InputText))
            //    {
            //        MessageBox.Show("Authorized member you entered already exists in the list", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //    else
            //    {
            //        listBox_authorized.Items.Add(dialog.InputText);
            //    }
            //}
        }

        private void btn_minus_autorized_members_Click(object sender, RoutedEventArgs e)
        {
            if (listBox_authorized.SelectedItem == null)
            {
                MessageBox.Show("Please Select the authorized member you want to remove", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {

                listBox_authorized.Items.RemoveAt(listBox_authorized.SelectedIndex);
            }
        }



        private void txt_acc_open_date_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox focusedTextbox = (TextBox)sender;
            check_date_onlostfocus(focusedTextbox, e);
            //if (txt_acc_open_date.Text.Length > 0)
            //{
            //    if (validate_date(txt_acc_open_date.Text) == false)
            //    {
            //        MessageBox.Show("Invalid Date Format, Use MM/dd/yyyy", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            //        e.Handled = true;
            //        txt_acc_open_date.SelectionStart = 0;
            //        txt_acc_open_date.SelectionLength = txt_acc_open_date.Text.Length;

            //    }
            //}
        }
        private void check_date_onlostfocus(TextBox date_textbox, KeyboardFocusChangedEventArgs e)
        {
            if (date_textbox.Text.Length > 0)
            {
                if (validate_date(date_textbox.Text) == false)
                {
                    MessageBox.Show("Invalid Date Format, Use MM/dd/yyyy", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    e.Handled = true;
                    date_textbox.SelectionStart = 0;
                    date_textbox.SelectionLength = date_textbox.Text.Length;

                }
            }
        }

        private void txt_acc_close_date_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox focusedTextbox = (TextBox)sender;
            check_date_onlostfocus(focusedTextbox, e);
            //if (txt_acc_close_date.Text.Length > 0)
            //{
            //    if (validate_date(txt_acc_close_date.Text) == false)
            //    {
            //        MessageBox.Show("Invalid Date Format, Use MM/dd/yyyy", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            //        e.Handled = true;
            //        txt_acc_close_date.SelectionStart = 0;
            //        txt_acc_close_date.SelectionLength = txt_acc_close_date.Text.Length;

            //    }
            //}
        }

        private void btn_sc_add_Click(object sender, RoutedEventArgs e)
        {
            //Keyboard kb_frm = new Keyboard("Please Enter the new swipe ID you would like to use for this customer");
            //kb_frm.ShowDialog();
            //if (kb_frm.k_b_swipeid != null)
            //{
            //    if (lstbx_card_swip_ids.Items.Contains(kb_frm.k_b_swipeid))
            //    {
            //        MessageBox.Show("Swipe Id you entered already exists in the list", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //    else
            //    {
            //        lstbx_card_swip_ids.Items.Add(kb_frm.k_b_swipeid);
            //    }
            //}
        }

        private void btn_sc_del_Click(object sender, RoutedEventArgs e)
        {
            if (lstbx_card_swip_ids.SelectedItem == null)
            {
                MessageBox.Show("Please Select the Swipe ID you want to remove", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                lstbx_card_swip_ids.Items.RemoveAt(lstbx_card_swip_ids.SelectedIndex);
            }
        }

        private void btn_delete_customer_Click(object sender, RoutedEventArgs e)
        {
            //if (txt_custmer_id.Text.Length != 0)
            //{
            //    if (MessageBox.Show("Are you sure, you want to delete this customer", "Deleting", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            //    {
            //        if (glo.con.State == ConnectionState.Closed)
            //        {
            //            glo.con.Open();
            //        }
            //        SqlCommand cmd_count_cust_shftos = new SqlCommand("select count(*) from Customer_ShipTos where CustNum like '%" + txt_custmer_id.Text + "%'", glo.con);
            //        if (Convert.ToInt32(cmd_count_cust_shftos.ExecuteScalar()) != 0)
            //        {
            //            SqlCommand cmd_delete_shftos = new SqlCommand("Delete from Customer_ShipTos where CustNum like '%" + txt_custmer_id.Text + "%'", glo.con);
            //            cmd_delete_shftos.ExecuteNonQuery();
            //        }
            //        SqlCommand cmd_customer_notes_del = new SqlCommand("delete from Customer_Notes where CustNum like '%" + txt_custmer_id.Text + "%'", glo.con);
            //        cmd_customer_notes_del.ExecuteNonQuery();
            //        SqlCommand cmd_customer_swipes_del = new SqlCommand("delete from Customer_Swipes where CustNum like '%" + txt_custmer_id.Text + "%'", glo.con);
            //        cmd_customer_swipes_del.ExecuteNonQuery();

            //        SqlCommand cmd_customer_auths_del = new SqlCommand("delete from Customer_Authorized where CustNum like '%" + txt_custmer_id.Text + "%'", glo.con);
            //        cmd_customer_auths_del.ExecuteNonQuery();
            //        SqlCommand cmd_delete_customer = new SqlCommand("Delete from Customer where CustNum like '%" + txt_custmer_id.Text + "%'", glo.con);
            //        cmd_delete_customer.ExecuteNonQuery();
            //        if (glo.con.State == ConnectionState.Open)
            //        {
            //            glo.con.Close();
            //        }
            //        if (cust_numbers.IndexOf(txt_custmer_id.Text) == 0)
            //        {
            //            indx2 = indx2 + 1;
            //            cust_numbers.RemoveAt(cust_numbers.IndexOf(txt_custmer_id.Text));
            //            indx = cust_numbers[indx2];
            //            next_prev(indx, "NAVIGATE");
            //        }
            //        else if (cust_numbers.IndexOf(txt_custmer_id.Text) == cust_numbers.Count)
            //        {
            //            indx2 = indx2 - 1;
            //            cust_numbers.RemoveAt(cust_numbers.IndexOf(txt_custmer_id.Text));
            //            indx = cust_numbers[indx2];
            //            next_prev(indx, "NAVIGATE");
            //        }
            //        else
            //        {
            //            indx2 = indx2 + 1;
            //            cust_numbers.RemoveAt(cust_numbers.IndexOf(txt_custmer_id.Text));
            //            indx = cust_numbers[indx2];
            //            next_prev(indx, "NAVIGATE");
            //        }


            //    }
            //}

        }

        private void txt_cus_compname_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBox focusedTextbox = (TextBox)sender;
            set_textbox_value(focusedTextbox);
        }
        private void set_textbox_value(TextBox selectedtxtbox)
        {
            //Keyboard kb_frm = new Keyboard("Enter New Value");
            //kb_frm.ShowDialog();
            //if (kb_frm.set_new_value != null)
            //{
            //    selectedtxtbox.Text = kb_frm.set_new_value;
            //}
        }

        private void txt_expiration_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        //    frmCalender calender = new frmCalender(2);
        //    calender.ShowDialog();
        //    if (calender.set_the_date.ToShortDateString() != "1/1/0001")
        //    {
        //        txt_expiration.Text = calender.set_the_date.ToString("MM/yy");
        //    }

        }

        private void txt_expiration_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txt_expiration.Text.Length > 0)
            {
                if (validate_date(txt_expiration.Text) == false && validate_date_2(txt_expiration.Text) == false)
                {
                    MessageBox.Show("Invalid Date Format, Use Correct Format", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    e.Handled = true;
                    txt_expiration.SelectionStart = 0;
                    txt_expiration.SelectionLength = txt_expiration.Text.Length;

                }
                else
                {
                    DateTime exp_date = Convert.ToDateTime(txt_expiration.Text);
                    txt_expiration.Text = exp_date.ToString("MM/yy");
                }
            }
        }
        private bool validate_date_2(string date_valid)
        {
            DateTime dt;
            bool validate_dt = DateTime.TryParseExact(date_valid, "MM/yy", null, DateTimeStyles.None, out dt);
            return validate_dt;
        }

        private void txt_cus_bonaspoint_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBox focusedTextbox = (TextBox)sender;
            set_number_textbox(focusedTextbox);
        }
        private void set_number_textbox(TextBox txtbox_number)
        {
            //NumberKeypaid numpaid_frm = new NumberKeypaid(7);
            //numpaid_frm.ShowDialog();
            //if (numpaid_frm.set_number != null)
            //{
            //    txtbox_number.Text = numpaid_frm.set_number;
            //}
        }

        private void txt_expiration_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //regclass.checkForNumeric();
        }
    }
}
