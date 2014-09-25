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
    /// Interaction logic for OnHoldForm.xaml
    /// </summary>
    public partial class OnHoldForm : Window
    {
       //GlobalClass glo = new GlobalClass();
        private static string on_hold = null;
        public OnHoldForm() //On_Hold_frm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                on_hold_id = null;
                //if (glo.con.State == ConnectionState.Closed)
                //{
                //    glo.con.Open();
                //}
                //SqlCommand cmd_count_onhold = new SqlCommand("SELECT COUNT(*) FROM Invoice_OnHold", glo.con);
                //if (Convert.ToInt32(cmd_count_onhold.ExecuteScalar()) != 0)
                //{
                //    SqlCommand cmd3 = new SqlCommand("Select distinct(a.Invoice_Number),b.DateTime,b.Grand_Total,a.OnHoldID,a.Cashier_ID,a.Store_ID,a.Occupied," +
                //     "a.Section_ID,a.Status,a.Identifier,a.PreAuthorized,a.Name,a.Station_ID," +
                //     "ISNULL(b.CustNum,'')+':'+ ISNULL(c.First_Name,'')+' '+ISNULL(c.Last_Name,'') as customer " +
                //     "from Invoice_OnHold a left outer join Invoice_Totals b on a.Invoice_Number=b.Invoice_Number " +
                //     "inner join Customer c on b.CustNum=c.CustNum  inner join Invoice_Itemized d on d.Invoice_Number=b.Invoice_Number", glo.con);
                //    cmd3.ExecuteNonQuery();
                //    DataSet _Bind = new DataSet();

                //    SqlDataAdapter sda = new SqlDataAdapter(cmd3);
                //    sda.Fill(_Bind, "MyBinding");
                //    DataTable dt = _Bind.Tables[0];

                //    dg_onhold.SelectedValuePath = "OnHoldID";

                //    dg_onhold.DataContext = _Bind;
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
        public string on_hold_id
        {
            get { return on_hold; }
            set { on_hold = value; }
        }
        private void btn_select_Click(object sender, RoutedEventArgs e)
        {
            if (dg_onhold.SelectedItem != null)
            {
                MessageBox.Show(dg_onhold.SelectedValue.ToString());
                on_hold = dg_onhold.SelectedValue.ToString();
                this.Close();
            }
        }

        private void dg_onhold_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dg_onhold.SelectedItem != null)
            {
               
                on_hold = dg_onhold.SelectedValue.ToString();
                this.Close();
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            on_hold_id = null;
            this.Close();
        }

        private void btn_type_in_Click(object sender, RoutedEventArgs e)
        {
            Label lbl_onhold = new Label();
            lbl_onhold.Content = "Enter onhold ID";
            Keyboard kb_frm = new Keyboard(lbl_onhold);
            kb_frm.ShowDialog();
            if(kb_frm.k_b_txts!=null)
            {
            check_onhold(kb_frm.k_b_txts);
            }
            
        }
        private void check_onhold(string kb_value)
        {
            Int32 count_onholds = 0;
            //if (glo.con.State == ConnectionState.Closed)
            //{
            //    glo.con.Open();
            //}
            //SqlCommand cmd_count_onhold = new SqlCommand("Select count(*) from Invoice_OnHold where OnHoldID='" + kb_value + "'", glo.con);
            //count_onholds = Convert.ToInt32(cmd_count_onhold.ExecuteScalar());
            //if (glo.con.State == ConnectionState.Open)
            //{
            //    glo.con.Close();
            //}
            //if (count_onholds == 0)
            //{
            //    MessageBox.Show("There is no Invoice with this On-hold ID", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //    txt_type_holdid.Text = kb_value;
            //}
            //else
            //{
            //    on_hold = kb_value;
            //    this.Close();
            //}
        }
        private void txt_type_holdid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                
                check_onhold(txt_type_holdid.Text);

            }
        }

        private void btn_scroll_up_Click(object sender, RoutedEventArgs e)
        {
            Int32 indx = dg_onhold.SelectedIndex;

            if (indx != 0 && dg_onhold.SelectedItem!=null)
            {
                dg_onhold.SelectedIndex = indx - 1;
            }
        }

        private void btn_scroll_down_Click(object sender, RoutedEventArgs e)
        {
            Int32 indx = dg_onhold.SelectedIndex;
            if (indx != dg_onhold.Items.Count - 1 && dg_onhold.SelectedItem != null)
            {
                dg_onhold.SelectedIndex = indx + 1;
            }
        }
    }
}
