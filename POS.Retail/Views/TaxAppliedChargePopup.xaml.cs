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
    /// Interaction logic for TaxAppliedChargePopup.xaml
    /// </summary>
    public partial class TaxAppliedChargePopup : Window
    {
        private static string chargeNotCharge = null;
        public TaxAppliedChargePopup()
        {
            InitializeComponent();
        }
        public string setChargeNotCharge
        {
            get { return chargeNotCharge; }
            set { chargeNotCharge = value; }
        }

        private void btnNotCharge_Click(object sender, RoutedEventArgs e)
        {
            chargeNotCharge = "N";
            this.Close();
        }

        private void btnCharge_Click(object sender, RoutedEventArgs e)
        {
            chargeNotCharge = "Y";
            this.Close();
        }
    }
}
