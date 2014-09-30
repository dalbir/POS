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
using POS.Retail.Common;
using System.Text.RegularExpressions;

namespace POS.Retail
{
    /// <summary>
    /// Interaction logic for VendorMaintForm.xaml
    /// </summary>
    public partial class VendorMaintForm : Window
    {
        RegexClass regex = new RegexClass();
        string command_type;
        public VendorMaintForm()
        {
            InitializeComponent();
        }

        private void btn_exit_vend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btn_exit_vend.Content.Equals("Exit"))
                {
                    this.Close();
                }
                if (btn_exit_vend.Content.Equals("Cancel"))
                {
                    btn_add_vendor.Content = "Add";

                    txt_vendor_id.Background = Brushes.White;
                    cmbVenSearchById.Visibility = Visibility.Visible;
                    lbl_searchby_id.Visibility = Visibility.Visible;
                    btn_exit_vend.Content = "Exit";
                    btn_savechange.IsHitTestVisible = true;
                    btn_delete_vend.IsHitTestVisible = true;
                    btn_vendor_next.IsHitTestVisible = true;
                    btn_vendor_prev.IsHitTestVisible = true;
                }
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
            }
        }

        private void funven_clear()
        {
            txt_vendor_id.Clear();
            txt_zipcode.Clear();
            txt_ven_website.Clear();
            txt_ven_term.Clear();
            txt_ven_state.Clear();
            txt_ven_securty.Clear();
            txt_ven_email.Clear();
            txt_ven_contry.Clear();
            txt_ven_city.Clear();
            txt_ven_commis.Clear();
            txt_tax_id.Clear();
            txt_min_order.Clear();
            txt_fname.Clear();
            txt_last_name.Clear();
            txt_flaterent.Clear();
            txt_comp_name.Clear();
            txt_address2.Clear();
            txt_ph_no.Clear();
            txt_saddress.Clear();
            cmb_po_dm.Text = "";
            txt_fax_no.Clear();
            txt_pay_dept.Clear();
        }

        private void btn_add_vendor_Click(object sender, RoutedEventArgs e)
        {
          
            if (btn_add_vendor.Content.Equals("Add"))
            {
                btn_add_vendor.Content = "Save";
                txt_vendor_id.IsReadOnly = false;
                txt_vendor_id.Focus();
                txt_vendor_id.Background = Brushes.Yellow;
                cmbVenSearchById.Visibility = Visibility.Hidden;
                lbl_searchby_id.Visibility = Visibility.Hidden;
                btn_exit_vend.Content = "Cancel";
                btn_savechange.IsHitTestVisible = false;
                btn_delete_vend.IsHitTestVisible = false;
                btn_vendor_next.IsHitTestVisible = false;
                btn_vendor_prev.IsHitTestVisible = false;
                funven_clear();
            }

            else if (btn_add_vendor.Content.Equals("Save"))
            {
                if (txt_vendor_id.Text.Equals(""))
                {
                    System.Windows.Forms.MessageBox.Show("A Vendor Number is Required in Order to Add A Vendor", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    txt_vendor_id.Focus();
                }
                else if (txt_comp_name.Text.Equals(""))
                {
                    System.Windows.Forms.MessageBox.Show("A Company Name is Required in Order to Add A Vendor", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    txt_comp_name.Focus();
                }
                else
                {
                    try
                    {
                        
                        if (Regex.IsMatch(txt_min_order.Text, @"[^0-9]+"))
                        {
                            MessageBox.Show("Value must be Numeric", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            txt_min_order.Focus();
                            return;
                        }
                        if (Regex.IsMatch(txt_flaterent.Text, @"[^0-9]+"))
                        {
                            MessageBox.Show("Value must be Numeric", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            txt_flaterent.Focus();
                            return;
                        }
                        if (Regex.IsMatch(txt_ven_commis.Text, @"[^0-9]+"))
                        {
                            MessageBox.Show("Value must be Numeric", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            txt_ven_commis.Focus();
                            return;
                        }
                        //if (txt_ven_email.Text.Length == 0 || txt_ven_email.Text.Length == 0)
                        //{
                        //    MessageBox.Show("email is not a valid formate please reenter", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        //    txt_ven_email.Focus();
                        //}
                        if (txt_ven_email.Text != "" && !Regex.IsMatch(txt_ven_email.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                        {
                            MessageBox.Show("Email is not a valid formate please Reenter", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            txt_ven_email.Focus();
                            return;
                        }
                        POSManagementService managmentService = new POSManagementService();
                        VendorsClass objVendor = new VendorsClass();
                        objVendor.quryFlage = "insert";

                        objVendor.Vendor_Number = txt_vendor_id.Text;
                        objVendor.First_Name = txt_fname.Text;
                        objVendor.Last_Name = txt_last_name.Text;
                        objVendor.Company = txt_comp_name.Text;
                        objVendor.Address_1 = txt_saddress.Text;
                        objVendor.Address_2 = txt_address2.Text;
                        objVendor.City = txt_ven_city.Text;
                        objVendor.State = txt_ven_state.Text;
                        objVendor.Zip_Code = txt_zipcode.Text;
                        objVendor.Phone = txt_ph_no.Text;
                        objVendor.Fax = txt_fax_no.Text;
                        objVendor.Vendor_Tax_ID = txt_tax_id.Text;
                        objVendor.Vendor_Terms = txt_ven_term.Text;
                        objVendor.SSN = txt_ven_securty.Text;
                        if (txt_ven_commis.Text != "")
                        objVendor.Commission = Convert.ToDecimal(txt_ven_commis.Text);
                        if (txt_flaterent.Text != "")
                        objVendor.Rent = Convert.ToDecimal(txt_flaterent.Text);
                        objVendor.Default_Billable_Department = txt_pay_dept.Text;
                        objVendor.Dirty = 1;
                        objVendor.County = txt_ven_contry.Text;
                        objVendor.Email = txt_ven_email.Text;
                        objVendor.Website = txt_ven_website.Text;
                        if (txt_min_order.Text != "")
                        objVendor.Minimum_Order = Convert.ToDecimal(txt_min_order.Text);
                        objVendor.Default_PO_Delivery = cmb_po_dm.SelectedIndex;

                        managmentService.InsertVendorInfo(objVendor);
                        if (objVendor.IsSuccessfull == true)
                        {

                            var result = System.Windows.Forms.MessageBox.Show("Record Added Successfully Do You Want to Add Another Record", "Information", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Exclamation);
                            if (result == System.Windows.Forms.DialogResult.Yes)
                            {
                                funven_clear();
                            }
                            else
                            {
                                btn_add_vendor.Content = "Add";

                                txt_vendor_id.Background = Brushes.White;
                                cmbVenSearchById.Visibility = Visibility.Visible;
                                lbl_searchby_id.Visibility = Visibility.Visible;
                                btn_exit_vend.Content = "Exit";
                                btn_savechange.IsHitTestVisible = true;
                                btn_delete_vend.IsHitTestVisible = true;
                                btn_vendor_next.IsHitTestVisible = true;
                                btn_vendor_prev.IsHitTestVisible = true;
                            }
                            fillCombo();
                        }
                    }
                    catch (Exception ex)
                    {
                        CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
                    }
                    
                }
            }
        }
        private void btn_delete_vend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_vendor_id.Text != "")
                {
                    var result = System.Windows.Forms.MessageBox.Show("Are You Sure to Delete the Record", "Record Delete?", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        POSManagementService managmentService = new POSManagementService();
                        VendorsClass objVendor = new VendorsClass();
                        objVendor.quryFlage = "delete";
                        objVendor.Vendor_Number = txt_vendor_id.Text;
                        managmentService.InsertVendorInfo(objVendor);
                        if (objVendor.IsSuccessfull == true)
                        {
                            System.Windows.Forms.MessageBox.Show("Record Deleted Successfully", "Record Deleted", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                        }
                        fillCombo();
                    }
                }
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
            }
        }
        private void btn_savechange_Click(object sender, RoutedEventArgs e)
        {
            if (txt_vendor_id.Text != "")
            {
                if (txt_vendor_id.Text.Equals(""))
                {
                    System.Windows.Forms.MessageBox.Show("A Vendor Number is Required in Order to Add A Vendor", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    txt_vendor_id.Focus();
                }
                else if (txt_comp_name.Text.Equals(""))
                {
                    System.Windows.Forms.MessageBox.Show("A Company Name is Required in Order to Add A Vendor", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    txt_comp_name.Focus();
                }
                else
                {
                    try
                    {
                        POSManagementService managmentService = new POSManagementService();
                        VendorsClass objVendor = new VendorsClass();
                        objVendor.quryFlage = "update";

                        objVendor.Vendor_Number = txt_vendor_id.Text;
                        objVendor.First_Name = txt_fname.Text;
                        objVendor.Last_Name = txt_last_name.Text;
                        objVendor.Company = txt_comp_name.Text;
                        objVendor.Address_1 = txt_saddress.Text;
                        objVendor.Address_2 = txt_address2.Text;
                        objVendor.City = txt_ven_city.Text;
                        objVendor.State = txt_ven_state.Text;
                        objVendor.Zip_Code = txt_zipcode.Text;
                        objVendor.Phone = txt_ph_no.Text;
                        objVendor.Fax = txt_fax_no.Text;
                        objVendor.Vendor_Tax_ID = txt_tax_id.Text;
                        objVendor.Vendor_Terms = txt_ven_term.Text;
                        objVendor.SSN = txt_ven_securty.Text;
                        if (txt_ven_commis.Text != "")
                        objVendor.Commission = Convert.ToDecimal(txt_ven_commis.Text);
                        if(txt_flaterent.Text != "")
                        objVendor.Rent = Convert.ToDecimal(txt_flaterent.Text);
                        objVendor.Default_Billable_Department = txt_pay_dept.Text;
                        objVendor.Dirty = 1;
                        objVendor.County = txt_ven_contry.Text;
                        objVendor.Email = txt_ven_email.Text;
                        objVendor.Website = txt_ven_website.Text;
                        if(txt_min_order.Text != "")
                        objVendor.Minimum_Order = Convert.ToDecimal(txt_min_order.Text);
                        objVendor.Default_PO_Delivery = cmb_po_dm.SelectedIndex;

                        managmentService.InsertVendorInfo(objVendor);
                        if (objVendor.IsSuccessfull == true)
                        {

                            MessageBox.Show("Record Updated Successfully", "Save Changes", MessageBoxButton.OK, MessageBoxImage.Information);
                            fillCombo();
                        }
                    }
                    catch (Exception ex)
                    {
                        CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
                    }

                }
            }
        }      
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fillCombo();
        }
        public void fillCombo()
        {
            try
            {
                txt_vendor_id.IsReadOnly = true;
                POSManagementService managmentService = new POSManagementService();
                VendorsClass objVendor = new VendorsClass();
                managmentService.RetriveVendor(objVendor);
                if (objVendor.dtVendor.Rows.Count > 0)
                {
                    cmbVenSearchById.ItemsSource = objVendor.dtVendor.DefaultView;
                    cmbVenSearchById.DisplayMemberPath = "Vendor_name";
                    cmbVenSearchById.SelectedValuePath = "Vendor_Number";
                }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
            }
        }

        private void cmbVenSearchById_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                VendorsClass objVendor = new VendorsClass();
                //string[] split = cmbVenSearchById.SelectedValue.ToString().Split(' ');
                objVendor.Vendor_Number = cmbVenSearchById.SelectedValue.ToString();
                POSManagementService mangmentService = new POSManagementService();
                mangmentService.RetriveAllVendorRecord(objVendor);
                if (objVendor.dtAllVendor.Rows.Count > 0)
                {
                    txt_vendor_id.Text = objVendor.dtAllVendor.Rows[0]["Vendor_Number"].ToString();
                    txt_fname.Text = objVendor.dtAllVendor.Rows[0]["First_Name"].ToString();
                    txt_last_name.Text = objVendor.dtAllVendor.Rows[0]["Last_Name"].ToString();
                    txt_comp_name.Text = objVendor.dtAllVendor.Rows[0]["Company"].ToString();
                    txt_saddress.Text = objVendor.dtAllVendor.Rows[0]["Address_1"].ToString();
                    txt_address2.Text = objVendor.dtAllVendor.Rows[0]["Address_2"].ToString();
                    txt_ven_city.Text = objVendor.dtAllVendor.Rows[0]["City"].ToString();
                    txt_ven_state.Text = objVendor.dtAllVendor.Rows[0]["State"].ToString();
                    txt_zipcode.Text = objVendor.dtAllVendor.Rows[0]["Zip_Code"].ToString();
                    txt_ph_no.Text = objVendor.dtAllVendor.Rows[0]["Phone"].ToString();
                    txt_fax_no.Text = objVendor.dtAllVendor.Rows[0]["Fax"].ToString();
                    txt_tax_id.Text = objVendor.dtAllVendor.Rows[0]["Vendor_Tax_ID"].ToString();
                    txt_ven_term.Text = objVendor.dtAllVendor.Rows[0]["Vendor_Terms"].ToString();
                    txt_ven_securty.Text = objVendor.dtAllVendor.Rows[0]["SSN"].ToString();
                    txt_ven_commis.Text = objVendor.dtAllVendor.Rows[0]["Commission"].ToString();
                    txt_flaterent.Text = objVendor.dtAllVendor.Rows[0]["Rent"].ToString();
                    txt_pay_dept.Text = objVendor.dtAllVendor.Rows[0]["Default_Billable_Department"].ToString();
                    txt_ven_contry.Text = objVendor.dtAllVendor.Rows[0]["County"].ToString();
                    txt_ven_email.Text = objVendor.dtAllVendor.Rows[0]["Email"].ToString();
                    txt_ven_website.Text = objVendor.dtAllVendor.Rows[0]["Website"].ToString();
                    txt_min_order.Text = objVendor.dtAllVendor.Rows[0]["Minimum_Order"].ToString();
                    cmb_po_dm.SelectedIndex = Convert.ToInt32(objVendor.dtAllVendor.Rows[0]["Default_PO_Delivery"]);
                }
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
            }
        }

        private void btn_vendor_next_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = cmbVenSearchById.SelectedIndex;
                if (index != cmbVenSearchById.Items.Count)
                {
                    index = index + 1;
                }
                else
                {
                    index = 0;
                }
                cmbVenSearchById.SelectedIndex = index;

            }
            catch(Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
            }
        }

        private void btn_vendor_prev_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = cmbVenSearchById.SelectedIndex;
                if (index != 0)
                {
                    index = index - 1;
                }
                else
                {
                    index = 0;
                }
                cmbVenSearchById.SelectedIndex = index;

            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
            }
        }
    }
}
