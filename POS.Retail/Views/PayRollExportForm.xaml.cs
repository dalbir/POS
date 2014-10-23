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

namespace POS.Retail.Views
{
    /// <summary>
    /// Interaction logic for PayRollExportForm.xaml
    /// </summary>
    public partial class PayRollExportForm : Window
    {
        public PayRollExportForm()
        {
            InitializeComponent();
        }

        private void bntExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPayrollExportSetting_Click(object sender, RoutedEventArgs e)
        {
            PayrollexportSettingForm obj = new PayrollexportSettingForm();
            obj.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            obj.ShowDialog();
        }
    }
}
