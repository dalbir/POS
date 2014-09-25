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
    /// Interaction logic for QuestionFormDeactivateGftLoyalty.xaml
    /// </summary>
    public partial class QuestionFormDeactivateGftLoyalty : Window
    {
       private static string g_c_id = null;

        public QuestionFormDeactivateGftLoyalty() //Question_form_deactivate_gft_loyalty()
        {
            InitializeComponent();
        }
        public string gft_card_id
        {
         
            get { return g_c_id; }
            set { g_c_id = value; }
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.L)
            { }
            else
            if (e.Key == Key.G)
            { }
        }

        private void gift_card()
        {
            MyDialog dialog = new MyDialog("Scan, Swipe or Type Gift Card ID:", "");
                     dialog.ShowDialog();

                     if (dialog.InputText1.Length != 0)
                     {
                         g_c_id = dialog.InputText1;
                         MessageBox.Show("This card is added to the invoice. If there is a refund, it will display only\nat the end of transaction.");
                     }
                     this.Close();
        }
        private void loyalty_card()
        { }

        private void btn_gift_card_Click(object sender, RoutedEventArgs e)
        {
            gift_card();
        }

        private void btn_loyalty_card_Click(object sender, RoutedEventArgs e)
        {
            loyalty_card();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gft_card_id = null;
        }
    }
}
