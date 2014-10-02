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
using POS.Domain.Base;
using POS.Services.Common;
using POS.Domain.Common;

namespace POS.Retail
{
    /// <summary>
    /// Interaction logic for SearchInventoryForm.xaml
    /// </summary>
    public partial class SearchInventoryForm : Window
    {

        private static string item_id = null;
        POSManagementService objPOSManagementService = new POSManagementService();
        public SearchInventoryForm() //SearchInventory()
        {
            InitializeComponent();
        }

        private void fill_combos()
        {
            try
            {
                //string query = "select 'ALL RECORDS' as records, 'No Category' as id union all select  Description as records, [Cat_ID] as id from Categories ";
                DataTable dtc = objPOSManagementService.GetCategory();
                cmb_category.ItemsSource = dtc.DefaultView;

                cmb_category.DisplayMemberPath = "records";
                cmb_category.SelectedValuePath = "id";


                //string querry = "select 'ALL RECORDS' as dept_desc, 'No Depatrment' as id_detp union all select Description as dept_desc, [Dept_ID] as id_detp from Departments";
                DataTable dtd = objPOSManagementService.getDepartments();
                cmb_dept.ItemsSource = dtd.DefaultView;
                cmb_dept.DisplayMemberPath = "dept_desc";
                cmb_dept.SelectedValuePath = "id_detp";

                //string qury = "select 'ALL RECORDS' as records_comp, 'No vendor' as id_compny union all select Company as records_comp, Vendor_Number as id_compny from Vendors";
                DataTable dtv = objPOSManagementService.getVendors();
                cmb_vendor.ItemsSource = dtv.DefaultView;
                cmb_vendor.DisplayMemberPath = "records_comp";
                cmb_vendor.SelectedValuePath = "id_compny";
            }
            catch (Exception)
            { }
        }
        private void fun_select_items()
        {

            try
            {
                if (cmb_category.SelectedIndex > -1 && cmb_dept.SelectedIndex > -1)
                {
                    InventoryClass objInventoryClass = new InventoryClass();
                    string category = null;
                    string dept = null;
                    string modifier = null;
                    string kits = null;
                    string modifier_groups = null;
                    string choice_items = null;
                    string rentals = null;
                    string style_items = null;
                    string serial_no = null;
                    string vendor = null;
                    if (cmb_category.Text == "ALL RECORDS")
                    {
                        category = "%";
                    }
                    else
                    {
                        category = cmb_category.SelectedValue.ToString();
                    }
                    if (cmb_dept.Text == "ALL RECORDS")
                    {
                        dept = "%";
                    }
                    else
                    {
                        dept = cmb_dept.SelectedValue.ToString();
                    }
                    if (cmb_vendor.Text == "ALL RECORDS")
                    {
                        vendor = "'%'" + " or Vendor_Number is null";
                    }
                    else
                    {
                        vendor = cmb_vendor.SelectedValue.ToString();
                    }

                    if (chk_modifier.IsChecked == true)
                    {
                        modifier = "1";
                    }
                    else
                    {
                        modifier = "%";
                    }

                    if (chk_kits.IsChecked == true)
                    {
                        kits = "1";
                    }
                    else
                    {
                        kits = "%";
                    }
                    objInventoryClass.Dept_ID = dept;
                    if (modifier != "%")
                        objInventoryClass.IsModifier = Convert.ToInt32(modifier);
                    if (kits != "%")
                        objInventoryClass.IsKit = Convert.ToInt32(kits);
                    objInventoryClass.Vendor_Number = vendor;
                    objInventoryClass.IsDeleted = 0;
                    objInventoryClass.Cat_id = category;
                    DataTable dt = objPOSManagementService.filterInventory(objInventoryClass);
                    //string quary = "select * from VIEW_ITEMS where c_id like '" + category + "' and d_id like '" + dept + "' and IsModifier like '" + modifier + "' and IsKit like '" + kits + "' and Vendor_Number like " + vendor + " and delte = 0";
                    // DataTable dt = 
                    DG_items.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fill_combos();
            cmb_category.SelectedIndex = 0;
            cmb_dept.SelectedIndex = 0;
            cmb_vendor.SelectedIndex = 0;
            item_id = null;
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmb_category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_dept.SelectedIndex > -1)
            {
                fun_select_items();
            }
        }

        private void cmb_dept_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_category.SelectedIndex > -1)
            {
                fun_select_items();
            }
        }
        private void selec_item()
        {
            if (DG_items.SelectedIndex != -1)
            {
                TextBlock b = DG_items.Columns[0].GetCellContent(DG_items.SelectedItem) as TextBlock;
                string d = b.Text;
                item_id = d;

                this.Close();

            }

        }
        private void btn_search_items_Click(object sender, RoutedEventArgs e)
        {
            //string prec = "%";
            if (rb_item_num.IsChecked == true)
            {
                //string quary = "select * from Inventory where ItemNum like '" + txt_search_text.Text + prec + "' order by ItemNum DESC";
                DataTable dt = objPOSManagementService.searchItem("sbItemNum", txt_search_text.Text);
                DG_items.ItemsSource = dt.DefaultView;
            }
            else if (rb_description.IsChecked == true)
            {
                // string quary = "select * from Inventory where ItemName like '" + txt_search_text.Text + prec + "' order by ItemName DESC";
                DataTable dt = objPOSManagementService.searchItem("sbItemName", txt_search_text.Text);
                DG_items.ItemsSource = dt.DefaultView;
            }
            else if (rb_vendor.IsChecked == true)
            {
                // string quary = "select * from Inventory where Vendor_Part_Num like '" + txt_search_text.Text + prec + "' order by Vendor_Part_Num DESC";
                DataTable dt = objPOSManagementService.searchItem("sbVendorPartNo", txt_search_text.Text);
                DG_items.ItemsSource = dt.DefaultView;
            }
        }

        private void chk_modifier_Checked(object sender, RoutedEventArgs e)
        {
            fun_select_items();
        }

        private void chk_modifier_Unchecked(object sender, RoutedEventArgs e)
        {
            fun_select_items();
        }

        private void chk_kits_Checked(object sender, RoutedEventArgs e)
        {
            fun_select_items();
        }

        private void chk_kits_Unchecked(object sender, RoutedEventArgs e)
        {
            fun_select_items();
        }

        private void cmb_dept_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_category.SelectedIndex > -1)
            {
                fun_select_items();
            }
        }

        private void cmb_category_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_dept.SelectedIndex > -1)
            {
                fun_select_items();
            }
        }

        private void cmb_vendor_DropDownClosed(object sender, EventArgs e)
        {
            fun_select_items();
        }

        private void DG_items_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            selec_item();
        }
        public string set_item_id
        {
            get { return item_id; }
            set { item_id = value; }
        }

        private void btn_select_item_Click(object sender, RoutedEventArgs e)
        {
            selec_item();
        }

        private void btn_new_item_Click(object sender, RoutedEventArgs e)
        {
            InventoryForm obj = new InventoryForm();
            obj.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            obj.ShowDialog();
        }
    }
}
