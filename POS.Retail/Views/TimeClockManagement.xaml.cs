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
using POS.Retail.Common;
using System.Data;
using POS.Domain.Common.Employee;

namespace POS.Retail.Views
{
    /// <summary>
    /// Interaction logic for TimeClockManagement.xaml
    /// </summary>
    public partial class TimeClockManagement : Window
    {
        POSManagementService objPOSManagementService = new POSManagementService();
        public TimeClockManagement()
        {
            InitializeComponent();
        }
        public void fillCashairCmb()
        {
            EmployeesDataClass objEmployeesDataClass = new EmployeesDataClass();
            DataTable dt = objPOSManagementService.getEmplyeeIds(objEmployeesDataClass);
            if(dt.Rows.Count > 0)
            {
                cmbCashier.ItemsSource = dt.DefaultView;
                cmbCashier.DisplayMemberPath = "EmpName";
                cmbCashier.SelectedValuePath = "Cashier_ID";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fillCashairCmb();
        }
    }
}
