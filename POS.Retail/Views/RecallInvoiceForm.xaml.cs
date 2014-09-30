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
    /// Interaction logic for RecallInvoiceForm.xaml
    /// </summary>
    public partial class RecallInvoiceForm : Window
    {
        //GlobalClass glo = new GlobalClass();
        private static string recall_id = null;
        public RecallInvoiceForm() //Recall_Invoice_Frm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //if (glo.con.State == ConnectionState.Closed)
                //{
                //    glo.con.Open();
                //}
                //SqlCommand cmd_count_onhold = new SqlCommand("SELECT COUNT(*) FROM Invoice_Totals", glo.con);
                //if (Convert.ToInt32(cmd_count_onhold.ExecuteScalar()) != 0)
                //{
                //    SqlCommand cmd_recall_invoice = new SqlCommand("SELECT Invoice_Totals.Invoice_Number AS Invoice, Invoice_Totals.Payment_Method AS Pay_Method, ROUND(Invoice_Totals.Grand_Total, 2) AS Total, (CASE WHEN Employee.EmpName IS NULL THEN Invoice_Totals.Cashier_ID ELSE (Invoice_Totals.Cashier_ID + ':' + Employee.EmpName) END)  AS Employee, Invoice_Totals.DateTime, (Invoice_Totals.CustNum  COLLATE DATABASE_DEFAULT + ':' + Customer.First_Name  COLLATE DATABASE_DEFAULT + ' ' + Customer.Last_Name  COLLATE DATABASE_DEFAULT + (case isnull(Customer.Phone_1,'' ) when '' then '' else ':' + Customer.Phone_1  COLLATE DATABASE_DEFAULT end)) AS Customer, ISNULL(Invoice_Totals.[OrderSource],'0') as OrderSource  FROM (Invoice_Totals INNER JOIN Customer ON Invoice_Totals.CustNum = Customer.CustNum)  INNER JOIN Employee ON Invoice_Totals.Cashier_ID = Employee.Cashier_ID  WHERE DateTime >= '"+DateTime.Now.Date.AddDays(-1)+"' AND Invoice_Totals.Store_ID = '1002'  ORDER BY  [OrderSource],  Invoice_Totals.[Invoice_Number] DESC", glo.con);
                //    cmd_recall_invoice.ExecuteNonQuery();
                //    DataSet _Bind = new DataSet();

                //    SqlDataAdapter sda = new SqlDataAdapter(cmd_recall_invoice);
                //    sda.Fill(_Bind, "MyBinding");
                //    DataTable dt = _Bind.Tables[0];

                //    dg_recall_invoices.SelectedValuePath = "Invoice";

                //    dg_recall_invoices.DataContext = _Bind;
                //    _Bind.Dispose();
                //}
                //if (glo.con.State == ConnectionState.Closed)
                //{
                //    glo.con.Open();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void check_onhold(string kb_value)
        {
            Int32 count_recalls = 0;
            //if (glo.con.State == ConnectionState.Closed)
            //{
            //    glo.con.Open();
            //}
            //SqlCommand cmd_count_onhold = new SqlCommand("Select count(*) from Invoice_Totals where Invoice_Number='" + kb_value + "'", glo.con);
            //count_recalls = Convert.ToInt32(cmd_count_onhold.ExecuteScalar());
            //if (glo.con.State == ConnectionState.Open)
            //{
            //    glo.con.Close();
            //}
            if (count_recalls == 0)
            {
                MessageBox.Show("There is no Invoice with this ID", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txt_type_holdid.Text = kb_value;
            }
            else
            {
                recall_id = kb_value;
                this.Close();
            }
        }

        private void txt_type_holdid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (txt_type_holdid.Text.Length != 0)
                {
                        check_onhold(txt_type_holdid.Text);
                }
            }
        }
        public string recall_invoice_id
        {
            get { return recall_id; }
            set { recall_id = value; }
        }
        private void dg_recall_invoices_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dg_recall_invoices.SelectedItem != null)
            {

                recall_id = dg_recall_invoices.SelectedValue.ToString();
                this.Close();
            }
        }

        private void btn_type_in_Click(object sender, RoutedEventArgs e)
        {
            Label lbl_onhold = new Label();
            lbl_onhold.Content = "Enter Invoice #";
            Keyboard kb_frm = new Keyboard(lbl_onhold);
            kb_frm.ShowDialog();
            if (kb_frm.k_b_txts != null)
            {
                check_onhold(kb_frm.k_b_txts);
            }
        }
    }
}
