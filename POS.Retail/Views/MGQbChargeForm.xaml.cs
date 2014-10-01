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

namespace POS.Retail
{
    /// <summary>
    /// Interaction logic for MGQbChargeForm.xaml
    /// </summary>
    public partial class MGQbChargeForm : Window
    {
         private static string charge = null;
        public MGQbChargeForm()// Frm_MG_Qb_Charge()
        {
            InitializeComponent();
        }

        private void btn_yes_Click(object sender, RoutedEventArgs e)
        {
            charge = "Yes";
            this.Close();
            // test vv
        }
        public string set_charge
        {
            get { return charge; }
            set { charge = value; }
        }

        private void btn_no_Click(object sender, RoutedEventArgs e)
        {
            charge = "No";
            this.Close();
        }
    }
}
