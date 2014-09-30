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
    /// Interaction logic for QuestionBoxTipAmount.xaml
    /// </summary>
    public partial class QuestionBoxTipAmount : Window
    {
        double p;
        double tip_amt = 0;
        double g_totals = 0;
        string inv_number = null;

        public QuestionBoxTipAmount() //Question_Box_tip_amount()
        {
            InitializeComponent();
           
        }

        public QuestionBoxTipAmount(double tip_amounts, double g_total, string inv_num)
        {
            InitializeComponent();
            this.p = tip_amounts;
            this.tip_amt = tip_amounts;
            this.g_totals = g_total;
            this.inv_number = inv_num;
            lbl_heading.Content = "This Credit Card has a tip of "+tip_amounts+",\n do you wish to change the tip?";
        }
               
            
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_no_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void btn_yes_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
            NumberKeypaid num_paid = new NumberKeypaid(36, p.ToString());
            num_paid.ShowDialog();
            if (num_paid.set_cash_reg_price != null)
            {
                double final_total=g_totals+Convert.ToDouble(num_paid.set_cash_reg_price);
                //Question_Box_final_tip_amount qustn_bx_final_tip_amt = new Question_Box_final_tip_amount(final_total, inv_number, Convert.ToDouble(num_paid.set_cash_reg_price));
                //qustn_bx_final_tip_amt.ShowDialog();
            }
        }
    }
}
