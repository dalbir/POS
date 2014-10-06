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
using POS.Services.Common;
using POS.Domain.Common;
using System.Data;

namespace POS.Retail.Views
{
    /// <summary>
    /// Interaction logic for CustomerSpecificItemPrices.xaml
    /// </summary>
    public partial class CustomerSpecificItemPrices : Window
    {
        POSManagementService objPOSManagementService = new POSManagementService();
        Inventory_CustPricesClass objInveCust = new Inventory_CustPricesClass();
        public CustomerSpecificItemPrices()
        {
            InitializeComponent();
        }

        private void rbItem_Checked(object sender, RoutedEventArgs e)
        {
            lblType.Content = "No Customer Selected";
            DgCustomer.Visibility = Visibility.Hidden;
            DgItem.Visibility = Visibility.Visible;
            btnSelect.Content = "Select Customer";
        }

        private void rbCustomer_Checked(object sender, RoutedEventArgs e)
        {
            lblType.Content = "No Item Selected";
            DgCustomer.Visibility = Visibility.Visible;
            DgItem.Visibility = Visibility.Hidden;
            btnSelect.Content = "Select Item";
            DgItem.ItemsSource = null;
            DgCustomer.ItemsSource = null;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rbItem.IsChecked = true;
            DgCustomer.Visibility = Visibility.Hidden;
            DgItem.Visibility = Visibility.Visible;
            DgItem.ItemsSource = null;
            DgCustomer.ItemsSource = null;
        }

        private void btnAddPrice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnSelect.Content.Equals("Select Item"))
                {
                    Inventory_CustPricesClass objInvCustPricesClass = new Inventory_CustPricesClass();
                    objInvCustPricesClass.message = "Enter Price";
                    NumberKeypaid objNk = new NumberKeypaid(objInvCustPricesClass);
                    objNk.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                    objNk.ShowDialog();
                    objInvCustPricesClass.message = "customer";
                    InforPromptForm obj = new InforPromptForm(objInvCustPricesClass);
                    obj.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                    obj.ShowDialog();
                    objInvCustPricesClass.Store_ID = "1001";
                    string[] str = lblType.Content.ToString().Split('-');
                    objInvCustPricesClass.ItemNum = str[0].ToString();
                    objInvCustPricesClass.Allow_Discounts = 1;
                    objPOSManagementService.insertCustomerWithSpecifedITem(objInvCustPricesClass);
                    objInvCustPricesClass.message = "item";
                    DataTable dt = objPOSManagementService.GetRequrdData(objInvCustPricesClass);
                    DgCustomer.ItemsSource = dt.DefaultView;

                }
                else if (btnSelect.Content.Equals("Select Customer"))
                {
                    Inventory_CustPricesClass objInvCustPricesClass = new Inventory_CustPricesClass();
                    objInvCustPricesClass.message = "Enter Price";
                    NumberKeypaid objNk = new NumberKeypaid(objInvCustPricesClass);
                    objNk.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                    objNk.ShowDialog();
                    objInvCustPricesClass.message = "item";
                    InforPromptForm obj = new InforPromptForm(objInvCustPricesClass);
                    obj.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                    obj.ShowDialog();
                    objInvCustPricesClass.Store_ID = "1001";
                    string[] str = lblType.Content.ToString().Split('-');
                    objInvCustPricesClass.CustNum = str[0].ToString();
                    objInvCustPricesClass.Allow_Discounts = 1;
                    objPOSManagementService.insertCustomerWithSpecifedITem(objInvCustPricesClass);
                    objInvCustPricesClass.message = "customer";
                     DataTable dt = objPOSManagementService.GetRequrdData(objInvCustPricesClass);
                    DgItem.ItemsSource = dt.DefaultView;
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void btnRemovePrice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Inventory_CustPricesClass objCustPrcies = new Inventory_CustPricesClass();
                objCustPrcies.Store_ID = "1001";
                if(DgItem.IsVisible == true)
                {
                    if (DgItem.SelectedIndex != -1)
                    {
                        TextBlock a = DgItem.Columns[0].GetCellContent(DgItem.SelectedItem) as TextBlock;
                        objCustPrcies.ItemNum = a.Text;
                        string[] str = lblType.Content.ToString().Split('-');
                        objCustPrcies.CustNum = str[0].ToString();
                        objPOSManagementService.removeCustPrice(objCustPrcies);
                        objCustPrcies.message = "itemDg";
                        DataTable dt = objPOSManagementService.fillDataGrids(objCustPrcies);
                        DgItem.ItemsSource = dt.DefaultView;
                    }
                    else
                    {
                        MessageBox.Show("Please Select a Price to Remove", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else if(DgCustomer.IsVisible == true)
                {
                    if (DgCustomer.SelectedIndex != -1)
                    {
                        TextBlock a = DgItem.Columns[0].GetCellContent(DgItem.SelectedItem) as TextBlock;
                        objCustPrcies.CustNum = a.Text;
                        string[] str = lblType.Content.ToString().Split('-');
                        objCustPrcies.ItemNum = str[0].ToString();
                        objPOSManagementService.removeCustPrice(objCustPrcies);
                        objCustPrcies.message = "costomerDg";
                        DataTable dt = objPOSManagementService.fillDataGrids(objCustPrcies);
                        DgCustomer.ItemsSource = dt.DefaultView;
                    }
                    else
                    {
                        MessageBox.Show("Please Select a Price to Remove", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                
                
            }
            catch(Exception ex)
            {

            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnSelect.Content.Equals("Select Item"))
                {
                    objInveCust.message = "item";
                }
                else if (btnSelect.Content.Equals("Select Customer"))
                {
                    objInveCust.message = "customer";
                }
                InforPromptForm obj = new InforPromptForm(objInveCust);
                obj.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                obj.ShowDialog();

                DataTable dt = objPOSManagementService.GetRequrdData(objInveCust);
                if (dt.Rows.Count > 0)
                {
                    if (btnSelect.Content.Equals("Select Item"))
                    {
                        if (objInveCust.message != "no")
                        {
                            lblType.Content = dt.Rows[0]["ItemNum"].ToString() + '-' + dt.Rows[0]["ItemName"].ToString();
                            DgCustomer.ItemsSource = dt.DefaultView;
                        }
                        else
                        {
                            lblType.Content = dt.Rows[0]["ItemNum"].ToString() + '-' + dt.Rows[0]["ItemName"].ToString();
                        }
                    }
                    if (btnSelect.Content.Equals("Select Customer"))
                    {
                        if (objInveCust.message != "no")
                        {
                            lblType.Content = dt.Rows[0]["CustNum"].ToString() + '-' + dt.Rows[0]["CustName"].ToString();
                            DgItem.ItemsSource = dt.DefaultView;
                        }
                        else
                        {
                            lblType.Content = dt.Rows[0]["CustNum"].ToString() + '-' + dt.Rows[0]["CustName"].ToString();
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

       
        private void DgCustomer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //try
            //{
            //    if (DgCustomer.SelectedIndex != -1)
            //    {
            //        Inventory_CustPricesClass objCustPrice = new Inventory_CustPricesClass();
                
            //        string[] str = lblType.Content.ToString().Split('-');
            //        objCustPrice.ItemNum = str[0].ToString();
            //        TextBlock a = DgCustomer.Columns[0].GetCellContent(DgCustomer.SelectedItem) as TextBlock;
            //        objCustPrice.CustNum = a.Text;
            //        TextBlock b = DgCustomer.Columns[2].GetCellContent(DgCustomer.SelectedItem) as TextBlock;
            //        objCustPrice.Price = Convert.ToDouble(b.Text);
            //        objCustPrice.message = "Enter New Amount";
            //        objCustPrice.Store_ID = "1001";
            //        NumberKeypaid kb = new NumberKeypaid(objCustPrice);
            //        kb.ShowDialog();
            //        objPOSManagementService.updateCustPrice(objCustPrice);
            //        objCustPrice.message = "item";
            //        DataTable dt = objPOSManagementService.GetRequrdData(objCustPrice);
            //        DgCustomer.ItemsSource = dt.DefaultView;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void DgItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //try
            //{
            //    if (DgItem.SelectedIndex != -1)
            //    {
            //        Inventory_CustPricesClass objCustPrice = new Inventory_CustPricesClass();
           
            //        string[] str = lblType.Content.ToString().Split('-');
            //        objCustPrice.CustNum = str[0].ToString();
            //        TextBlock a = DgItem.Columns[0].GetCellContent(DgItem.SelectedItem) as TextBlock;
            //        objCustPrice.ItemNum = a.Text;
            //        TextBlock b = DgItem.Columns[2].GetCellContent(DgItem.SelectedItem) as TextBlock;
            //        objCustPrice.Price = Convert.ToDouble(b.Text);
            //        objCustPrice.message = "Enter New Amount";
            //        objCustPrice.Store_ID = "1001";
            //        NumberKeypaid kb = new NumberKeypaid(objCustPrice);
            //        kb.ShowDialog();
            //        objPOSManagementService.updateCustPrice(objCustPrice);
            //        objCustPrice.message = "customer";
            //        DataTable dt = objPOSManagementService.GetRequrdData(objCustPrice);
            //        DgItem.ItemsSource = dt.DefaultView;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Inventory_CustPricesClass objCustPrices = new Inventory_CustPricesClass();
                CheckBox chk = sender as CheckBox;
                if (chk.IsChecked == true)
                {
                    objCustPrices.Allow_Discounts = 1;
                }
                else
                {
                    objCustPrices.Allow_Discounts = 0;
                }

                TextBlock a = DgCustomer.Columns[0].GetCellContent(DgCustomer.SelectedItem) as TextBlock;
                objCustPrices.CustNum = a.Text;
                string[] str = lblType.Content.ToString().Split('-');
                objCustPrices.ItemNum = str[0].ToString();
                objCustPrices.Store_ID = "1001";
                objPOSManagementService.updateAllowDiscounts(objCustPrices);
                objCustPrices.message = "item";
                DataTable dt = objPOSManagementService.GetRequrdData(objCustPrices);
                DgCustomer.ItemsSource = dt.DefaultView;
            }
            catch(Exception ex)
            {

            }
        }

        private void CheckBox_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Inventory_CustPricesClass objCustPrices = new Inventory_CustPricesClass();
                CheckBox chk = sender as CheckBox;
                if (chk.IsChecked == true)
                {
                    objCustPrices.Allow_Discounts = 1;
                }
                else
                {
                    objCustPrices.Allow_Discounts = 0;
                }

                TextBlock a = DgItem.Columns[0].GetCellContent(DgItem.SelectedItem) as TextBlock;
                objCustPrices.ItemNum = a.Text;
                string[] str = lblType.Content.ToString().Split('-');
                objCustPrices.CustNum = str[0].ToString();
                objCustPrices.Store_ID = "1001";
                objPOSManagementService.updateAllowDiscounts(objCustPrices);
                objCustPrices.message = "customer";
                DataTable dt = objPOSManagementService.GetRequrdData(objCustPrices);
                DgItem.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {

            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox txt = sender as TextBox;
            try
            {
                if (DgCustomer.SelectedIndex != -1)
                {
                    Inventory_CustPricesClass objCustPrice = new Inventory_CustPricesClass();

                    string[] str = lblType.Content.ToString().Split('-');
                    objCustPrice.ItemNum = str[0].ToString();
                    TextBlock a = DgCustomer.Columns[0].GetCellContent(DgCustomer.SelectedItem) as TextBlock;
                    objCustPrice.CustNum = a.Text;
                    //TextBlock b = DgCustomer.Columns[2].GetCellContent(DgCustomer.SelectedItem) as TextBlock;

                    objCustPrice.Price = Convert.ToDouble(txt.Text);
                   
                    objCustPrice.message = "Enter New Amount";
                    objCustPrice.Store_ID = "1001";
                    NumberKeypaid kb = new NumberKeypaid(objCustPrice);
                    kb.ShowDialog();
                    objPOSManagementService.updateCustPrice(objCustPrice);
                    objCustPrice.message = "item";
                    DataTable dt = objPOSManagementService.GetRequrdData(objCustPrice);
                    DgCustomer.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox_DgItem_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox txt = sender as TextBox;
            try
            {
                if (DgItem.SelectedIndex != -1)
                {
                    Inventory_CustPricesClass objCustPrice = new Inventory_CustPricesClass();

                    string[] str = lblType.Content.ToString().Split('-');
                    objCustPrice.CustNum = str[0].ToString();
                    TextBlock a = DgItem.Columns[0].GetCellContent(DgItem.SelectedItem) as TextBlock;
                    objCustPrice.ItemNum = a.Text;
                    //TextBlock b = DgItem.Columns[2].GetCellContent(DgItem.SelectedItem) as TextBlock;
                    objCustPrice.Price = Convert.ToDouble(txt.Text);
                    objCustPrice.message = "Enter New Amount";
                    objCustPrice.Store_ID = "1001";
                    NumberKeypaid kb = new NumberKeypaid(objCustPrice);
                    kb.ShowDialog();
                    objPOSManagementService.updateCustPrice(objCustPrice);
                    objCustPrice.message = "customer";
                    DataTable dt = objPOSManagementService.GetRequrdData(objCustPrice);
                    DgItem.ItemsSource = dt.DefaultView;
                    e.Handled = false;
                    a.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemovePrice_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
