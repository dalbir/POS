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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rbItem.IsChecked = true;
            DgCustomer.Visibility = Visibility.Hidden;
            DgItem.Visibility = Visibility.Visible;
        }

        private void btnAddPrice_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnRemovePrice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {

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
                    objInveCust.message.Equals("Please Select Customer Number");
                }
                InforPromptForm obj = new InforPromptForm(objInveCust);
                obj.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                obj.ShowDialog();

                DataTable dt = objPOSManagementService.GetRequrdData(objInveCust);
                if (dt.Rows.Count > 0)
                {
                    if (objInveCust.message != "no")
                    {
                        lblType.Content = dt.Rows[0]["ItemNum"].ToString() + '-' + dt.Rows[0]["ItemName"].ToString();
                        DgItem.ItemsSource = dt.DefaultView;
                    }
                    else
                    {
                        lblType.Content = dt.Rows[0]["ItemNum"].ToString() + '-' + dt.Rows[0]["ItemName"].ToString();
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
