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

namespace POS.Retail
{
    /// <summary>
    /// Interaction logic for EnterVendorForm.xaml
    /// </summary>
    public partial class EnterVendorForm : Window
    {
        PurchaseOrderForm pur = new PurchaseOrderForm();
        private static int cancel = 0;
        POSManagementService objPOSManagementService = new POSManagementService();
        public EnterVendorForm()
        {
            InitializeComponent();
        }
       
        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_vend_parno.Text == "")
                {
                    MessageBox.Show("A Vendor Part Number Must be Provided", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txt_vend_parno.Focus();
                    return;
                }
                else if (txt_case_per.Text == "")
                {
                    MessageBox.Show("A Cost Per Must be a Numeric Value", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txt_case_per.Focus();
                    return;
                }
                else if (txt_no_percase.Text == "")
                {
                    MessageBox.Show("A Number Per Case Must be a Numeric Value", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txt_no_percase.Focus();
                    return;
                }
                if (txt_case_cost.Text == "")
                {
                    MessageBox.Show("Case Cost Must be a Numeric Value", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txt_case_cost.Focus();
                    return;
                }
                Inventory_VendorsClass objInventoryVendorsClass = new Inventory_VendorsClass();
                objInventoryVendorsClass.ItemNum = pur.set_item_no;
                objInventoryVendorsClass.Store_ID = "1001";
                objInventoryVendorsClass.Vendor_Number = pur.set_vendor_no;
                objInventoryVendorsClass.CostPer = Convert.ToDouble(txt_case_per.Text);
                objInventoryVendorsClass.Case_Cost = Convert.ToDouble(txt_case_cost.Text);
                objInventoryVendorsClass.NumPerVenCase = Convert.ToDouble(txt_no_percase.Text);
                objPOSManagementService.ExecuteOredringInfo(objInventoryVendorsClass);
                //string qurry = "insert into Inventory_Vendors(ItemNum,Store_ID,Vendor_Number,CostPer,Case_Cost,NumPerVenCase,Vendor_Part_Num) values('" + pur.set_item_no + "', '1001','" + pur.set_vendor_no + "','" + Convert.ToDouble(txt_case_per.Text) + "','" + Convert.ToDouble(txt_case_cost.Text) + "','" + Convert.ToDecimal(txt_no_percase.Text) + "','" + txt_vend_parno.Text + "')";
                //glo.fun_insert(qurry);
                InventoryClass objInventoryClass = new InventoryClass();
                objInventoryClass.ItemNum = pur.set_item_no;
                objInventoryClass.Vendor_Number = pur.set_vendor_no;
                objInventoryClass.Vendor_Part_Num = txt_vend_parno.Text;
                objPOSManagementService.updateInventory(objInventoryClass);
                //string update_inventory = "update Inventory set Vendor_Number = '"+ pur.set_vendor_no +"', Vendor_Part_Num = '"+ txt_vend_parno.Text +"' where ItemNum = '"+ pur.set_item_no +"'";
                //glo.fun_insert(update_inventory);
                this.Close();
            }
            catch(Exception ex)
            {

            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            cancel = 1;
            this.Close();
        }

        public int set_cancel
        {
            get { return cancel; }
            set { cancel = value; }
        }
    }
}
