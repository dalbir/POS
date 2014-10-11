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
using POS.Retail.Views;
using POS.Domain.Common;
using POS.Services.Common;
using System.Data;

namespace POS.Retail.Views
{
    /// <summary>
    /// Interaction logic for Mix_NMatch.xaml
    /// </summary>
    public partial class Mix_NMatch : Window
    {
        public Mix_NMatch()
        {
            InitializeComponent();
        }
        POSManagementService objPosManagementService = new POSManagementService();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbPriceGroup.Items.Add("Discount Amount");
            cmbPriceGroup.Items.Add("Bulk Price");
            cmbPriceGroup.Items.Add("Discount %");
            DepartmentClass objDept = new DepartmentClass();
            objDept.Store_ID = "1001";
            DataTable dt = objPosManagementService.getDepartment(objDept);
            if(dt.Rows.Count > 0)
            {
                cmbDepartment.ItemsSource = dt.DefaultView;
                cmbDepartment.DisplayMemberPath = "Description";
                cmbDepartment.SelectedValuePath = "Dept_ID";
            }
            txtPriceGroupID.IsEnabled = false;
        }

        private void cmbPriceGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.cmbPriceGroup.SelectedIndex == 0)
            {
                lblAmount.Content = "Amount to Discount";
                dgDiscountLevel.Visibility = Visibility.Hidden;
                lblDiscountLevel.Visibility = Visibility.Hidden;
                chkbLocalPrice.Visibility = Visibility.Hidden;
                chkbTax2.Visibility = Visibility.Visible;
                grdTax.Visibility = Visibility.Visible;
                btnAddDiscountLevel.Visibility = Visibility.Hidden;
                btnDeleteDiscount.Visibility = Visibility.Hidden;
            }
            else if (this.cmbPriceGroup.SelectedIndex == 1)
            {
                lblAmount.Content = "Bulk Price";
                dgDiscountLevel.Visibility = Visibility.Visible;
                lblDiscountLevel.Visibility = Visibility.Visible;
                chkbLocalPrice.Visibility = Visibility.Visible;
                chkbTax2.Visibility = Visibility.Hidden;
                grdTax.Visibility = Visibility.Hidden;
                btnAddDiscountLevel.Visibility = Visibility.Visible;
                btnDeleteDiscount.Visibility = Visibility.Visible;
            }
            else if (this.cmbPriceGroup.SelectedIndex == 2)
            {
                lblAmount.Content = "Discount Percentage";
                dgDiscountLevel.Visibility = Visibility.Visible;
                lblDiscountLevel.Visibility = Visibility.Visible;
                chkbLocalPrice.Visibility = Visibility.Visible;
                chkbTax2.Visibility = Visibility.Hidden;
                grdTax.Visibility = Visibility.Hidden;
                btnAddDiscountLevel.Visibility = Visibility.Visible;
                btnDeleteDiscount.Visibility = Visibility.Visible;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            // insertion in inventory table
                InventoryClass objInventoryClass = new InventoryClass();
                objInventoryClass.Store_ID = "1001";
                objInventoryClass.ItemNum = txtPriceGroupID.Text;
                objInventoryClass.ItemName = txtDescription.Text;
                objInventoryClass.Price = Convert.ToDecimal(txtAmount.Text);
                objInventoryClass.Tax_1 = Convert.ToByte(chkTax1.IsChecked);
                objInventoryClass.Tax_2 = Convert.ToByte(chkbTax2.IsChecked);
                objInventoryClass.Tax_3 = Convert.ToByte(chkbTax3.IsChecked);
                objInventoryClass.Date_Created = Convert.ToDateTime(DateTime.Today);
                objInventoryClass.Last_Sold = Convert.ToDateTime(DateTime.Today);
                objInventoryClass.FoodStampable = Convert.ToByte(chkbFoodstampable.IsChecked);
                objInventoryClass.Dept_ID = Convert.ToString(cmbDepartment.SelectedValue);
                objInventoryClass.ItemType = 5;
                objInventoryClass.Dirty = 1;
                objInventoryClass.QuantityRequired = Convert.ToDecimal(txtQuantity.Text);
                objInventoryClass.AllowReturns = 1;
                objInventoryClass.Print_On_Receipt = 1;
                objInventoryClass.Count_This_Item = 1;
                objPosManagementService.insertInventory(objInventoryClass);
                if(objInventoryClass.IsSuccessfull == true)
                {
                    Inventory_OnSale_InfoClass objIvnOnsaleInfo = new Inventory_OnSale_InfoClass();
                    objIvnOnsaleInfo.Store_ID = "1001";
                    objIvnOnsaleInfo.ItemNum = txtPriceGroupID.Text;
                    objIvnOnsaleInfo.Sale_Start = Convert.ToDateTime(txtStartDate.Text);
                    objIvnOnsaleInfo.Sale_End = Convert.ToDateTime(txtEndDate.Text);
                    objPosManagementService.insertOnSaleInfo(objIvnOnsaleInfo);
                }
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[Error:]", ex.Message);
            }
        }

        private void btnAddItems_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SearchInventoryForm objSearchInventory = new SearchInventoryForm();
                InventoryClass objInventory = new InventoryClass();
                objSearchInventory.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                objSearchInventory.ShowDialog();
                if(objSearchInventory.set_item_id != null)
                {
                    objInventory.ItemNum = objSearchInventory.set_item_id;
                    DataTable dt = objPosManagementService.getInventoryId(objInventory);
                    var data = new item { ItemNum = dt.Rows[0]["ItemNum"].ToString(), ItemName = dt.Rows[0]["ItemName"].ToString(), Price = Math.Round(Convert.ToDouble(dt.Rows[0]["Price"]), 2).ToString() };
                    dgItems.Items.Add(data);          
                }
                
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[Error:]", ex.Message);
            }
        }
        public class item
        {
            public string ItemNum { get; set; }
            public string ItemName { get; set; }
            public string Price { get; set; }
        }

        private void btnAddDiscountLevel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NumberKeypaid objkepaid = new NumberKeypaid(101);
                objkepaid.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                objkepaid.ShowDialog();
                if(objkepaid.set_quantity != null)
                {
                    NumberKeypaid objkpaid = new NumberKeypaid(102);
                    objkpaid.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                    objkpaid.ShowDialog();
                    if(objkpaid.set_price != null)
                    {
                        var data = new level { Quantity = objkepaid.set_quantity, amount = objkpaid.set_price};
                        dgDiscountLevel.Items.Add(data); 
                    }
                }
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[Error:]", ex.Message);
            }
        }
        public class level
        {
            public string Quantity { get; set; }
            public string amount { get; set; }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            btnExit.Content = "Cancel";
            cmbPriceGroup.SelectedIndex = 0;
            txtPriceGroupID.IsEnabled = true;
            txtPriceGroupID.Clear();
            txtDescription.Clear();
            cmbSearchPriceGroup.Visibility = Visibility.Hidden;
            lblSearchPriceGroup.Visibility = Visibility.Hidden;
            txtPriceGroupID.Background = Brushes.Yellow;
            this.btnAdd.IsEnabled = false;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if(btnExit.Content.Equals("Exit"))
            {
                this.Close();
            }
            else
            {
                btnExit.Content = "Exit";
               // cmbPriceGroup.SelectedIndex = 0;
                txtPriceGroupID.IsEnabled = false;
                //txtPriceGroupID.Clear();
                //txtDescription.Clear();
                cmbSearchPriceGroup.Visibility = Visibility.Visible;
                lblSearchPriceGroup.Visibility = Visibility.Visible;
                txtPriceGroupID.Background = Brushes.White;
                this.btnAdd.IsEnabled = true;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgItems.SelectedIndex >= 0)
            {
                for (int i = 0; i < dgItems.SelectedItems.Count; i++)
                {
                    dgItems.Items.Remove(dgItems.SelectedItems[i]);
                };
            }
        }

        private void btnDeleteDiscount_Click(object sender, RoutedEventArgs e)
        {
            if (dgDiscountLevel.SelectedIndex >= 0)
            {
                for (int i = 0; i < dgDiscountLevel.SelectedItems.Count; i++)
                {
                    dgDiscountLevel.Items.Remove(dgDiscountLevel.SelectedItems[i]);
                };
            }
        }
    }
}
