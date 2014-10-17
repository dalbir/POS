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
using POS.Repository;
using POS.Services.Common;
using POS.Domain.Common;

namespace POS.Retail.Views
{
    /// <summary>
    /// Interaction logic for frmStylesMatrix.xaml
    /// </summary>
    public partial class frmStylesMatrix : Window
    {
        public frmStylesMatrix()
        {
            InitializeComponent();
        }
        List<string> GroupsNumbers = null;
        private static System.Windows.Controls.TextBox send_txbox = null;
        //private static string getValue;
        private void btnKeyBoard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtItemNumber.IsFocused != false || txtPrefixDescription.IsFocused != false || txtXdimntion.IsFocused != false || txtYdimention.IsFocused != false || txtCost.IsFocused != false || txtPriceCharg.IsFocused != false)
                {
                    fun_load_keyboard(send_txbox, send_txbox.Text);
                    //if (txtItemNumber.IsFocused == true)
                    //{
                    //    getValue = txtItemNumber.Text.Trim();

                    //}
                    //if (txtPrefixDescription.IsFocused == true)
                    //{
                    //    getValue = txtPrefixDescription.Text.Trim();
                    //}
                    //if (txtXdimntion.IsFocused == true)
                    //{
                    //    getValue = txtXdimntion.Text.Trim();
                    //}
                    //if (txtYdimention.IsFocused == true)
                    //{
                    //    getValue = txtYdimention.Text.Trim();
                    //}
                    //if (txtCost.IsFocused == true)
                    //{
                    //    getValue = txtCost.Text.Trim();
                    //}
                    //if (txtPriceCharg.IsFocused == true)
                    //{
                    //    getValue = txtPriceCharg.Text.Trim();
                    //}
                    //Keyboard objKeyboard = new Keyboard("Enter Description");
                    //objKeyboard.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    //objKeyboard.ShowDialog();
                    
                   
                    //if (objKeyboard.set_decrep.Length > 10)
                    //{
                    //    string str = objKeyboard.set_decrep;
                    //    string sub = str.Substring(0, 10);
                    //    txtItemNumber.Text = sub;
                    //}

                    //else
                    //{
                    //    txtItemNumber.Text = objKeyboard.set_decrep;
                    //}
                }
                else
                {
                    MessageBox.Show("Please touch the box you would like to type in", "Precise POS", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Error]", ex.Message);
            }
        }
        private void FillVendorComboBox()
        {
            try
            {
                GroupsClass objGroupsClass = new GroupsClass();
                objGroupsClass.flage = "loadVindors";
                POSManagementService objMgtServices = new POSManagementService();
                objGroupsClass = objMgtServices.GetGroupLoadedData(objGroupsClass);
                cmbVendor.ItemsSource = objGroupsClass.LoadGroupData.DefaultView;
                cmbVendor.DisplayMemberPath = "Company";
                cmbVendor.SelectedValuePath = "Vendor_number";
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Error]", ex.Message);
            }
        }
        private void FillDptComboBox()
        {
            try
            {
                DepartmentClass objDepartmentClass = new DepartmentClass();
                objDepartmentClass.flage = "loadDpt";
                POSManagementService objMgtServices = new POSManagementService();
                objDepartmentClass = objMgtServices.LoadCatIdToDpt(objDepartmentClass);
                cmbDepartment.ItemsSource = objDepartmentClass.LoadDept.DefaultView;
                cmbDepartment.DisplayMemberPath = "Description";
                cmbDepartment.SelectedValuePath = "Dept_ID";
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Error]", ex.Message);
            }
        }
        private void FillStyleComboBox()
        {
            try
            {
                GroupsClass objGroupsClass = new GroupsClass();
                objGroupsClass.flage = "SelectStyle";
                POSManagementService objMgtServices = new POSManagementService();
                objGroupsClass = objMgtServices.GetGroupLoadedData(objGroupsClass);
                cmbSelectSyle.ItemsSource = objGroupsClass.LoadGroupData.DefaultView;
                cmbSelectSyle.DisplayMemberPath = "stlname";
                cmbSelectSyle.SelectedValuePath = "Group_ID";
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Error]", ex.Message);
            }
        }
       
        public System.Windows.Controls.TextBox set_textbox
        {
            get { return send_txbox; }
            set { send_txbox = value; }
        }
        //public string set_Value
        //{
        //    get { return getValue; }
        //    set { getValue = value; }
        //}
        private void fun_load_keyboard(System.Windows.Controls.TextBox selectedtxtbox, string txtbox_text)
        {
            Keyboard kb_frm = new Keyboard("Enter New Value", txtbox_text);
            kb_frm.ShowDialog();
            if (kb_frm.set_new_value != null)
            {
                selectedtxtbox.Text = kb_frm.set_new_value;
            }
            kb_frm.set_new_value = null;
            send_txbox = null;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                load_list();
                txtItemNumber.Text = GroupsNumbers[0];
                FillDptComboBox();
                FillVendorComboBox();
                FillStyleComboBox();
                ChkAutoGnItems.IsEnabled = false;
                //txtItemNumber.IsReadOnly = true;
                showName.Content = cmbSelectSyle.Text;
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Error]", ex.Message);
            }
        }
        private void load_list()
        {
            try
            {
                GroupsClass objGroupsClass = new GroupsClass();
                objGroupsClass.flage = "fillList";
                GroupsNumbers = new List<string>();
                POSManagementService objMgtServices = new POSManagementService();
                objGroupsClass = objMgtServices.GetGroupLoadedData(objGroupsClass);
                for (int i = 0; i < objGroupsClass.LoadGroupData.Rows.Count; i++)
                {
                    GroupsNumbers.Add(objGroupsClass.LoadGroupData.Rows[i]["Group_ID"].ToString());
                }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Error]", ex.Message);
            }
        }
        private void SelectGroupsDataForTextBoxes()
        {
            try
            {
                GroupsClass objGroupsClass = new GroupsClass();
                objGroupsClass.Group_ID = txtItemNumber.Text.Trim();
                objGroupsClass.flage = "LoadGroupsToTextBoxes";
                POSManagementService objPOSManagementService = new POSManagementService();
                objGroupsClass = objPOSManagementService.GetGroupLoadedData(objGroupsClass);

                if (objGroupsClass.LoadGroupData.Rows.Count > 0)
                {
                    for (int i = 0; i < objGroupsClass.LoadGroupData.Rows.Count; i++)
                    {
                        cmbSelectSyle.SelectedValue = objGroupsClass.LoadGroupData.Rows[i]["Group_ID"].ToString();
                        txtPrefixDescription.Text = objGroupsClass.LoadGroupData.Rows[i]["Description"].ToString();
                        txtCost.Text =(Math.Round(Convert.ToDouble( objGroupsClass.LoadGroupData.Rows[i]["Cost"]),2)).ToString();
                        txtPriceCharg.Text =(Math.Round(Convert.ToDouble( objGroupsClass.LoadGroupData.Rows[i]["Price"]),2)).ToString();
                        if (objGroupsClass.LoadGroupData.Rows[i]["Tax_1"].ToString() == "True")
                        {
                            chkText1.IsChecked = true;
                        }
                        else if (objGroupsClass.LoadGroupData.Rows[i]["Tax_1"].ToString() == "False")
                        {
                            chkText1.IsChecked = false;
                        }
                        if (objGroupsClass.LoadGroupData.Rows[i]["Tax_2"].ToString() == "True")
                        {
                            chkText2.IsChecked = true;
                        }
                        else if (objGroupsClass.LoadGroupData.Rows[i]["Tax_2"].ToString() == "False")
                        {
                            chkText2.IsChecked = false;
                        }
                        if (objGroupsClass.LoadGroupData.Rows[i]["Tax_3"].ToString() == "True")
                        {
                            chkText3.IsChecked = true;
                        }
                        else if (objGroupsClass.LoadGroupData.Rows[i]["Tax_3"].ToString() == "False")
                        {
                            chkText3.IsChecked = false;
                        }
                        txtXdimntion.Text = objGroupsClass.LoadGroupData.Rows[i]["Dim_1_Name"].ToString();
                        txtYdimention.Text = objGroupsClass.LoadGroupData.Rows[i]["Dim_2_Name"].ToString();
                        cmbDepartment.SelectedValue = objGroupsClass.LoadGroupData.Rows[i]["Dept_ID"].ToString();
                        cmbVendor.SelectedValue = objGroupsClass.LoadGroupData.Rows[i]["Vendor_Number"].ToString();
                        if (objGroupsClass.LoadGroupData.Rows[i]["AutoGenerate"].ToString() == "True")
                        {
                            ChkAutoGnItems.IsChecked = true;
                        }
                        else if (objGroupsClass.LoadGroupData.Rows[i]["AutoGenerate"].ToString() == "False")
                        {
                            ChkAutoGnItems.IsChecked = false;
                        }
                    }
                }
                if (objGroupsClass.LoadGroupData.Rows.Count < 0)
                {
                    MessageBox.Show("The customer you are searching for can not be found", "Precise POS", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClearFields()
        {
            btnDelete.IsEnabled = true;
            btnSavChanges.IsEnabled = true;
            btnAddSize.IsEnabled = true;
            btnAddColor.IsEnabled = true;
            btnCancel.IsEnabled = true;
            btnExit.Content = "Exit";
            txtItemNumber.IsReadOnly = true;
            btnAddStyle.Content = "Add Style";
            ChkAutoGnItems.IsEnabled = false;
        }
        private void btnAddStyle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                if (btnAddStyle.Content.Equals("Add Style"))
                {
                    Keyboard objKeyboard = new Keyboard("Enter Description");
                    objKeyboard.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    objKeyboard.ShowDialog();
                    btnDelete.IsEnabled = false;
                    btnSavChanges.IsEnabled = false;
                    btnAddSize.IsEnabled = false;
                    btnAddColor.IsEnabled = false;
                    btnCancel.IsEnabled = false;
                    btnExit.Content = "Cancel";
                    txtItemNumber.IsReadOnly = false;
                    btnAddStyle.Content = "Save";
                    ChkAutoGnItems.IsEnabled = true;
                    txtXdimntion.Text="Size";
                    txtYdimention.Text="Color";
                    txtCost.Clear();
                    txtPriceCharg.Clear();
                    //txtItemNumber.Text = objKeyboard.set_decrep;
                    if (objKeyboard.set_decrep.Length > 10)
                    {
                        string str = objKeyboard.set_decrep;
                        string sub = str.Substring(0, 10);
                        txtItemNumber.Text = sub;
                    }
                    else
                    {
                        txtItemNumber.Text = objKeyboard.set_decrep;
                    }
                    txtPrefixDescription.Text = objKeyboard.set_decrep;
                }
                else if (btnAddStyle.Content.Equals("Save"))
                {
                    GroupsClass objGroupsClass = new GroupsClass();
                    objGroupsClass.Group_ID = txtItemNumber.Text.Trim();
                    objGroupsClass.Store_ID = "1001";
                    objGroupsClass.Description = txtPrefixDescription.Text.Trim();
                    objGroupsClass.ItemNumPrefix = txtItemNumber.Text.Trim();
                    objGroupsClass.Cost =Convert.ToDecimal( txtCost.Text.Trim());
                    objGroupsClass.Price = Convert.ToDecimal(txtPriceCharg.Text.Trim());
                    string text1value, text2value, text3value ;
                    var select1 =2;
                    var select2 = 2;
                    var select3 = 3;
                    text1value = chkText1.IsChecked.Value.ToString();
                    
                    if (text1value == "True")
                    {
                        select1 = 1;
                    }
                    else if (text1value == "False")
                    {
                        select1 = 0;
                    }
                    text2value = chkText2.IsChecked.Value.ToString();
                    if (text2value == "True")
                    {
                        select2 = 1;
                    }
                    else if (text2value == "False")
                    {
                        select2 = 0; 
                    }
                    text3value = chkText3.IsChecked.Value.ToString();
                    if (text3value == "True")
                    {
                        select3 = 1;
                    }
                    else if (text3value == "False")
                    {
                        select3 = 0;
                    }
                    objGroupsClass.Tax_1 = select1;
                    objGroupsClass.Tax_2 = select2;
                    objGroupsClass.Tax_3 = select3;
                    objGroupsClass.Dim_1_Name = txtXdimntion.Text.Trim();
                    objGroupsClass.Dim_2_Name = txtYdimention.Text.Trim();
                    objGroupsClass.Dept_ID = Convert.ToString(cmbDepartment.SelectedValue);
                    objGroupsClass.Vendor_Number =Convert.ToString( cmbVendor.SelectedValue);
                    string autogenarate;
                    autogenarate=ChkAutoGnItems.IsChecked.Value.ToString();
                    var selectAuto = 2;
                    if (autogenarate == "True")
                    {
                        selectAuto = 1;
                    }
                    else if (autogenarate == "False")
                    {
                        selectAuto = 0;
                    }
                    objGroupsClass.AutoGenerate = selectAuto;
                    objGroupsClass.isDeleted =Convert.ToInt16(0);
                    POSManagementService objPOSManagementService = new POSManagementService();
                    objGroupsClass.flage = "ReadGroup";
                    string ids = Convert.ToString(objPOSManagementService.loadReadedGroupID(objGroupsClass).ToString());
                    if (ids == txtItemNumber.Text)
                    {
                        MessageBox.Show("This Item number already exist; Please try again.", "Precise POS", MessageBoxButton.OK, MessageBoxImage.Error);                  
                        return;
                    }
                    objGroupsClass.flage = "insert";
                    
                    objPOSManagementService.GetGroupsInfo(objGroupsClass);

                    Groups_ReferenceClass objGroupReferenceClass = new Groups_ReferenceClass();
                    string maxID = Convert.ToString(objPOSManagementService.loadMaxGroupRefrnceID(objGroupReferenceClass));
                    objGroupReferenceClass.flage = "insert";
                    objGroupReferenceClass.ID =Convert.ToInt32( maxID);
                    objGroupReferenceClass.Group_ID = txtItemNumber.Text.Trim();
                    objGroupReferenceClass.Store_ID = "1001";
                    objPOSManagementService.GetGroupRefereceInfo(objGroupReferenceClass);
                    //if (objGroupsClass.IsSuccessfull == true)
                    //{
                    MessageBox.Show("Record Have Added Succesfully", "Precise POS", MessageBoxButton.OK, MessageBoxImage.Information);
                    //}
                    //FillDptComboBox();
                    //FillVendorComboBox();
                    FillStyleComboBox();
                    load_list();
                    ClearFields();
                    txtItemNumber.Text = GroupsNumbers[0];
                    showName.Content = cmbSelectSyle.Text;
                    
                }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Error]", ex.Message);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnExit.Content.Equals("Cancel"))
                {
                    ClearFields();
                    txtItemNumber.Text = GroupsNumbers[0];

                }
                else if (btnExit.Content.Equals("Exit"))
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Error]", ex.Message);
            }
        }

        private void txtItemNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            SelectGroupsDataForTextBoxes();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int count = GroupsNumbers.Count;
                int res = GroupsNumbers.FindIndex(label => label == txtItemNumber.Text);

                if (count != res)
                {
                    int x = res + 1;
                    txtItemNumber.Text = GroupsNumbers[x];
                }
                else
                {
                    txtItemNumber.Text = GroupsNumbers[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbSelectSyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtItemNumber.Text =Convert.ToString( cmbSelectSyle.SelectedValue);
            showName.Content = cmbSelectSyle.Text;
        }

        private void txtItemNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TextBox focusedTextbox = (System.Windows.Controls.TextBox)sender;
            send_txbox = focusedTextbox;
        }

        private void txtPrefixDescription_GotFocus(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TextBox focusedTextbox = (System.Windows.Controls.TextBox)sender;
            send_txbox = focusedTextbox;
        }

        private void txtXdimntion_GotFocus(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TextBox focusedTextbox = (System.Windows.Controls.TextBox)sender;
            send_txbox = focusedTextbox;
        }

        private void txtYdimention_GotFocus(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TextBox focusedTextbox = (System.Windows.Controls.TextBox)sender;
            send_txbox = focusedTextbox;
        }

        private void txtCost_GotFocus(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TextBox focusedTextbox = (System.Windows.Controls.TextBox)sender;
            send_txbox = focusedTextbox;
        }

        private void txtPriceCharg_GotFocus(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TextBox focusedTextbox = (System.Windows.Controls.TextBox)sender;
            send_txbox = focusedTextbox;
        }

        private void btnSavChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GroupsClass objGroupsClass = new GroupsClass();
                objGroupsClass.Group_ID = txtItemNumber.Text.Trim();
                objGroupsClass.Store_ID = "1001";
                objGroupsClass.Description = txtPrefixDescription.Text.Trim();
                objGroupsClass.ItemNumPrefix = txtItemNumber.Text.Trim();
                objGroupsClass.Cost = Convert.ToDecimal(txtCost.Text.Trim());
                objGroupsClass.Price = Convert.ToDecimal(txtPriceCharg.Text.Trim());
                string text1value, text2value, text3value;
                var select1 = 2;
                var select2 = 2;
                var select3 = 3;

                text1value = chkText1.IsChecked.Value.ToString();

                if (text1value == "True")
                {
                    select1 = 1;
                }
                else if (text1value == "False")
                {
                    select1 = 0;
                }
                text2value = chkText2.IsChecked.Value.ToString();
                if (text2value == "True")
                {
                    select2 = 1;
                }
                else if (text2value == "False")
                {
                    select2 = 0;
                }
                text3value = chkText3.IsChecked.Value.ToString();
                if (text3value == "True")
                {
                    select3 = 1;
                }
                else if (text3value == "False")
                {
                    select3 = 0;
                }
                objGroupsClass.Tax_1 = select1;
                objGroupsClass.Tax_2 = select2;
                objGroupsClass.Tax_3 = select3;
                objGroupsClass.Dim_1_Name = txtXdimntion.Text.Trim();
                objGroupsClass.Dim_2_Name = txtYdimention.Text.Trim();
                objGroupsClass.Dept_ID = Convert.ToString(cmbDepartment.SelectedValue);
                objGroupsClass.Vendor_Number = Convert.ToString(cmbVendor.SelectedValue);
                string autogenarate;
                autogenarate = ChkAutoGnItems.IsChecked.Value.ToString();
                var selectAuto = 2;
                if (autogenarate == "True")
                {
                    selectAuto = 1;
                }
                else if (autogenarate == "False")
                {
                    selectAuto = 0;
                }
                objGroupsClass.AutoGenerate = selectAuto;
                objGroupsClass.isDeleted = Convert.ToInt16(0);
                POSManagementService objPOSManagementService = new POSManagementService();
                objGroupsClass.flage = "update";
                objPOSManagementService.GetGroupsInfo(objGroupsClass);
                if (objGroupsClass.IsSuccessfull == true)
                {
                   MessageBox.Show("Record was Updated Succesfully", "Precise POS", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                //FillDptComboBox();
                //FillVendorComboBox();
                //FillStyleComboBox();
                ClearFields();
                load_list();
                txtItemNumber.Text = GroupsNumbers[0];
                showName.Content = cmbSelectSyle.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtItemNumber.Text.Length > 0)
                {
                    var result = MessageBox.Show("Are You Sure You Want to Permenant Delete the Item No: " + txtItemNumber.Text, "Run Time Support", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        GroupsClass objGroupsClass = new GroupsClass();
                        POSManagementService objPOSManagementService = new POSManagementService();
                        objGroupsClass.flage = "delete";
                        objGroupsClass.isDeleted = Convert.ToInt16(1);
                        objGroupsClass.Group_ID = txtItemNumber.Text.Trim();
                        objPOSManagementService.GetGroupsInfo(objGroupsClass);

                        //Groups_ReferenceClass objGroups_ReferenceClass = new Groups_ReferenceClass();
                        //objGroups_ReferenceClass.flage = "delete";
                        //objGroups_ReferenceClass.Group_ID = txtItemNumber.Text.Trim();
                        //objPOSManagementService.GetGroupRefereceInfo(objGroups_ReferenceClass);
                        System.Windows.Forms.MessageBox.Show("This Item has been deleted..!", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                        //FillDptComboBox();
                        //FillVendorComboBox();
                        //FillStyleComboBox();
                        ClearFields();
                        load_list();
                        FillStyleComboBox();
                        txtItemNumber.Text = GroupsNumbers[0];
                        showName.Content = cmbSelectSyle.Text;
                    }
                    else if (result == MessageBoxResult.No)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int count = GroupsNumbers.Count;
                int res = GroupsNumbers.FindIndex(label => label == txtItemNumber.Text);
                
                if (count != res)
                {
                    int x = res - 1;
                    
                    txtItemNumber.Text = GroupsNumbers[x];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
