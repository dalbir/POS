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
    /// Interaction logic for CreditCardTipsForm.xaml
    /// </summary>
    public partial class CreditCardTipsForm : Window
    {
       //GlobalClass glo = new GlobalClass();
        public CreditCardTipsForm()
        {
            InitializeComponent();
        }

        private void btn_add_tip_Click(object sender, RoutedEventArgs e)
        {
            //NumberKeypaid num_paid = new NumberKeypaid(35, "0");
            //num_paid.ShowDialog();

            //if (num_paid.set_invoice_number != null)
            //{
            //    if (glo.con.State == ConnectionState.Closed)
            //    {
            //        glo.con.Open();
            //    }
            //    SqlCommand cmd_check_invoice = new SqlCommand("Select count(*) from Invoice_Totals where Invoice_Number='"+num_paid.set_invoice_number+"'",glo.con);
            //    if (Convert.ToInt32(cmd_check_invoice.ExecuteScalar()) == 0)
            //    {
            //        MessageBox.Show("This Invoice number cannot be found");
            //    }
            //    else
            //    {
            //        SqlCommand cmd_check_invoice_credtcard = new SqlCommand("Select count(*) from CC_Trans where CRENumber='" + num_paid.set_invoice_number + "'", glo.con);
            //        if(Convert.ToInt32(cmd_check_invoice_credtcard.ExecuteScalar())==0)
            //        {
            //             MessageBox.Show("This is not a credit card invoice. You can not apply a tip to it");
            //        }
            //        else
            //        {
            //            double tip_amount = 0;
            //            string inv_number = null;
            //            double grand_total = 0;
            //            SqlCommand cmd_tip_amount = new SqlCommand("select Invoice_Totals.Tip_Amount, Invoice_Totals.Grand_Total,CC_Trans.CRENumber "+
            //            "from Invoice_Totals inner join CC_Trans on Invoice_Totals.Invoice_Number=CC_Trans.CRENumber where CC_Trans.CRENumber='" + num_paid.set_invoice_number + "'", glo.con);

            //            SqlDataReader rdr_tip_amount=cmd_tip_amount.ExecuteReader();
            //            inv_number = Convert.ToString(rdr_tip_amount["CRENumber"]);
            //            grand_total = Convert.ToDouble(rdr_tip_amount["Grand_Total"]);
            //            if(tip_amount==0)
            //            {
            //                NumberKeypaid number_paid = new NumberKeypaid(36, "0.00");
            //                number_paid.ShowDialog();
            //                if (number_paid.set_cash_reg_price != null)
            //                {
            //                    double final_total = grand_total + Convert.ToDouble(number_paid.set_cash_reg_price);
            //                    Question_Box_final_tip_amount qustn_bx_final_tip_amt = new Question_Box_final_tip_amount(final_total, inv_number, Convert.ToDouble(number_paid.set_cash_reg_price));
            //                    qustn_bx_final_tip_amt.ShowDialog();
            //                }
            //            }
            //            else
            //            {
            //                Question_Box_tip_amount qustion_bx = new Question_Box_tip_amount(tip_amount,grand_total,inv_number);
            //                qustion_bx.ShowDialog();
                            
            //            }
            //        }

                        
            //        }
            //    if (glo.con.State == ConnectionState.Open)
            //    {
            //        glo.con.Close();
            //    }
            //    }
        }
    }
}
