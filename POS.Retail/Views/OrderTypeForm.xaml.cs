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
    /// Interaction logic for OrderTypeForm.xaml
    /// </summary>
    public partial class OrderTypeForm : Window
    {
        private static int order_type = -1;
        public OrderTypeForm() //OrderType()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            order_type = -1;
        }

        public int set_order_type
        {
            get { return order_type; }
            set { order_type = value; }
        }

        private void btn_spo_Click(object sender, RoutedEventArgs e)
        {
            order_type = 0;
            this.Close();
        }

        private void btn_return_tov_Click(object sender, RoutedEventArgs e)
        {
            order_type = 1;
            this.Close();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
