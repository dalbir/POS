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
                DataTable dt = objPOSManagementService.getTransfers(objInventoryOrdersClass);
                if(dt.Rows.Count > 0)
                {
                    dgTransfer.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RetriveTransfer();
           DataTable dt =  objPOSManagementService.getStoreIds();
           cmbCreationStoreID.Items.Add("All");
           for(int i=0; i<dt.Rows.Count; i++)
           {
               cmbCreationStoreID.Items.Add(dt.Rows[i][0].ToString());
           }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
