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
    /// Interaction logic for PaymentHistoryForm.xaml
    /// </summary>
    public partial class PaymentHistoryForm : Window
    {
       // GlobalClass glo = new GlobalClass();
        string inv_number = null;
        public PaymentHistoryForm() //Payment_history_frm()
        {
            InitializeComponent();
        }
        public PaymentHistoryForm(string inv_no)
        {
            InitializeComponent();
            this.inv_number = inv_no;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //if (glo.con.State == ConnectionState.Closed)
            //{
            //    glo.con.Open();
            //}
            //SqlCommand cmd_payment_history = new SqlCommand("select Store_ID,TransactionNumber,DateTime, Cashier_ID,Amount from Money_Activity where TransactionNumber='" + inv_number + "'", glo.con);

            //SqlDataAdapter sda = new SqlDataAdapter(cmd_payment_history);
            //DataTable dt = new DataTable("Money_Activity");
            //sda.Fill(dt);
            //dg_payment_history.ItemsSource = dt.DefaultView; 
            //if (glo.con.State == ConnectionState.Open)
            //{
            //    glo.con.Close();
            //}
            label1.Content = "Layaway payment history for invoice #:" + inv_number;
        }

        private void btn_done_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
