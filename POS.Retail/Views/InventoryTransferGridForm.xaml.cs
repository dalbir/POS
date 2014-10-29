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

namespace POS.Retail.Views
{
    /// <summary>
    /// Interaction logic for InventoryTransferGridForm.xaml
    /// </summary>
    public partial class InventoryTransferGridForm : Window
    {
        POSManagementService objPOSManagementService = new POSManagementService();
        public InventoryTransferGridForm()
        {
            InitializeComponent();
        }
        public void RetriveTransfer()
        {
            try
            {
                InventoryOrdersClass objInventoryOrdersClass = new InventoryOrdersClass();
                if(cmbCreationStoreID.SelectedIndex == 0)
                    objInventoryOrdersClass.OrderCounter = "%";
                else
                objInventoryOrdersClass.OrderCounter = cmbCreationStoreID.Text + '%';
                int status = cmbStatusToView.SelectedIndex;
                switch(status)
                {
                    case 0:
                        objInventoryOrdersClass.Status = "%";
                        break;
                    case 1:
                        objInventoryOrdersClass.Status = "0";
                        break;
                    case 2:
                        objInventoryOrdersClass.Status = "0";
                        break;
                    case 3:
                        objInventoryOrdersClass.Status = "0";
                        break;
                    case 4:
                        objInventoryOrdersClass.Status = "0";
                        break;
                    case 5:
                        objInventoryOrdersClass.Status = "4";
                        break;
                    default:
                        break;
                }
                DataTable dt = objPOSManagementService.getTransfers(objInventoryOrdersClass);
                if(dt.Rows.Count > 0)
                {
                    dgTransfer.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[InventoryTransfer:Error(RetriveTransfer):]", ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                DataTable dt = objPOSManagementService.getStoreIds();
                cmbCreationStoreID.Items.Add("All");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmbCreationStoreID.Items.Add(dt.Rows[i][0].ToString());
                }
                cmbStatusToView.Items.Add("All");
                cmbStatusToView.Items.Add("Open");
                cmbStatusToView.Items.Add("Sent");
                cmbStatusToView.Items.Add("Partially Received");
                cmbStatusToView.Items.Add("Closed");
                cmbStatusToView.Items.Add("Voided");
                cmbCreationStoreID.SelectedIndex = 0;
                cmbStatusToView.SelectedIndex = 0;
                RetriveTransfer();
            }
            catch (Exception ex)
            {
                
               CustomLogging.Log("[InventoryTransfer:Error(WindowLoading):]", ex.Message);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmbCreationStoreID_DropDownClosed(object sender, EventArgs e)
        {
            RetriveTransfer();
        }

        private void cmbStatusToView_DropDownClosed(object sender, EventArgs e)
        {
            RetriveTransfer();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            Keyboard objkb = new Keyboard("Enter a reason for the Transfer.", 500);
            objkb.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            objkb.ShowDialog();
            if(objkb.set_decrep != null)
            {
                InventoryTransferForm obj = new InventoryTransferForm(objkb.set_decrep);
                obj.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                obj.ShowDialog();
            }
        }
    }
}
