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
    /// Interaction logic for LookUplayawayForm.xaml
    /// </summary>
    public partial class LookUplayawayForm : Window
    {
       //GlobalClass glo = new GlobalClass();
        int infocus = 0;
        private static string inv_nums = null;
        public LookUplayawayForm() //Look_Up_layaway()
        {
            InitializeComponent();
        }
        public LookUplayawayForm(string cust_no)
        {
            InitializeComponent();
            search(cust_no, "", "", "");
        }

        private void txt_customer_no_GotFocus(object sender, RoutedEventArgs e)
        {
            infocus = 0;
            txt_customer_no.Background = Brushes.Yellow;
            txt_firstname.Background = Brushes.White;
            txt_lastname.Background = Brushes.White;
            txt_phone_no.Background = Brushes.White;
            txt_start_date.Background = Brushes.White;
            txt_end_date.Background = Brushes.White;
        }

        private void txt_phone_no_GotFocus(object sender, RoutedEventArgs e)
        {
            infocus = 1;
            txt_customer_no.Background = Brushes.White;
            txt_firstname.Background = Brushes.White;
            txt_lastname.Background = Brushes.White;
            txt_phone_no.Background = Brushes.Yellow;
            txt_start_date.Background = Brushes.White;
            txt_end_date.Background = Brushes.White;
        }

        private void txt_firstname_GotFocus(object sender, RoutedEventArgs e)
        {
            infocus = 2;
            txt_customer_no.Background = Brushes.White;
            txt_firstname.Background = Brushes.Yellow;
            txt_lastname.Background = Brushes.White;
            txt_phone_no.Background = Brushes.White;
            txt_start_date.Background = Brushes.White;
            txt_end_date.Background = Brushes.White;
        }

        private void txt_lastname_GotFocus(object sender, RoutedEventArgs e)
        {
            infocus = 3;
            txt_customer_no.Background = Brushes.White;
            txt_firstname.Background = Brushes.White;
            txt_lastname.Background = Brushes.Yellow;
            txt_phone_no.Background = Brushes.White;
            txt_start_date.Background = Brushes.White;
            txt_end_date.Background = Brushes.White;
        }

        private void txt_start_date_GotFocus(object sender, RoutedEventArgs e)
        {
            infocus = 4;
            txt_customer_no.Background = Brushes.White;
            txt_firstname.Background = Brushes.White;
            txt_lastname.Background = Brushes.White;
            txt_phone_no.Background = Brushes.White;
            txt_start_date.Background = Brushes.Yellow;
            txt_end_date.Background = Brushes.White;
        }

        private void txt_end_date_GotFocus(object sender, RoutedEventArgs e)
        {
            infocus = 5;
            txt_customer_no.Background = Brushes.White;
            txt_firstname.Background = Brushes.White;
            txt_lastname.Background = Brushes.White;
            txt_phone_no.Background = Brushes.White;
            txt_start_date.Background = Brushes.White;
            txt_end_date.Background = Brushes.Yellow;
        }

        private void btn_n1_Click(object sender, RoutedEventArgs e)
        {
            Button btn_clcked = (Button)sender;
            inpu_textbox(btn_clcked);

        }

        private void inpu_textbox(Button btn_clcked)
        {
            if (infocus == 0)
            {
                txt_customer_no.Text = txt_customer_no.Text + btn_clcked.Content.ToString();
            }
            else if (infocus == 1)
            {
                txt_phone_no.Text = txt_phone_no.Text + btn_clcked.Content.ToString();
            }
            else if (infocus == 2)
            {
                txt_firstname.Text = txt_firstname.Text + btn_clcked.Content.ToString();
            }
            else if (infocus == 3)
            {
                txt_lastname.Text = txt_lastname.Text + btn_clcked.Content.ToString();
            }
            else if (infocus == 4)
            {
                txt_start_date.Text = txt_start_date.Text + btn_clcked.Content.ToString();
            }
            else if (infocus == 5)
            {
                txt_end_date.Text = txt_end_date.Text + btn_clcked.Content.ToString();
            }
        }

        private void btn_space_Click(object sender, RoutedEventArgs e)
        {
            if (infocus == 0)
            {
                txt_customer_no.Text = txt_customer_no.Text + " ".ToString();
            }
            else if (infocus == 1)
            {
                txt_phone_no.Text = txt_phone_no.Text + " ".ToString();
            }
            else if (infocus == 2)
            {
                txt_firstname.Text = txt_firstname.Text + " ".ToString();
            }
            else if (infocus == 3)
            {
                txt_lastname.Text = txt_lastname.Text + " ".ToString();
            }
            else if (infocus == 4)
            {
                txt_start_date.Text = txt_start_date.Text + " ".ToString();
            }
            else if (infocus == 5)
            {
                txt_end_date.Text = txt_end_date.Text + " ".ToString();
            }
        }

        private void btn_backspace_Click(object sender, RoutedEventArgs e)
        {
            if (infocus == 0)
            {
                if (txt_customer_no.Text.Length != 0)
                {
                    string s = txt_customer_no.Text;

                    string s2 = s.Substring(0, s.Length - 1);
                    txt_customer_no.Text = s2;
                }
            }
            else if (infocus == 1)
            {                
                if (txt_phone_no.Text.Length != 0)
                {
                    string s = txt_phone_no.Text;

                    string s2 = s.Substring(0, s.Length - 1);
                    txt_phone_no.Text = s2;
                }
            }
            else if (infocus == 2)
            {
                if (txt_firstname.Text.Length != 0)
                {
                    string s = txt_firstname.Text;

                    string s2 = s.Substring(0, s.Length - 1);
                    txt_firstname.Text = s2;
                }
            }
            else if (infocus == 3)
            {
                if (txt_lastname.Text.Length != 0)
                {
                    string s = txt_lastname.Text;

                    string s2 = s.Substring(0, s.Length - 1);
                    txt_lastname.Text = s2;
                }
            }
            else if (infocus == 4)
            {
                if (txt_start_date.Text.Length != 0)
                {
                    string s = txt_start_date.Text;

                    string s2 = s.Substring(0, s.Length - 1);
                    txt_start_date.Text = s2;
                }
            }
            else if (infocus == 5)
            {
                if (txt_end_date.Text.Length != 0)
                {
                    string s = txt_end_date.Text;

                    string s2 = s.Substring(0, s.Length - 1);
                    txt_end_date.Text = s2;
                }
            }
            
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            set_invnum = null;
            this.Close();
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            txt_customer_no.Clear();
            txt_firstname.Clear();
            txt_lastname.Clear();
            txt_phone_no.Clear();
            txt_start_date.Clear();
            txt_end_date.Clear();
            search("","","","");
        }
        private void add_params()
        {
            string cust_no = null;
            string cust_phone = null;
            string cust_f_name = null;
            string cust_l_name = null;
            cust_no = txt_customer_no.Text;
            cust_phone = txt_phone_no.Text;
            cust_f_name = txt_firstname.Text;
            cust_l_name = txt_lastname.Text;
            search(cust_no, cust_phone, cust_f_name, cust_l_name);
        }

        private void search(string cust_no, string cust_phone, string cust_f_name, string cust_l_name)
        {
            try
            {
                if (cust_no.Length == 0 && cust_phone.Length == 0 && cust_f_name.Length == 0 && cust_l_name.Length==0)
                {
                    return;
                }
                else
                {

                    //glo.con.Open();
                    //using (SqlCommand cmd1 = new SqlCommand("SP_LAYAWAY_LOOKUP_SEARCH", glo.con))
                    //{

                    //    cmd1.CommandType = CommandType.StoredProcedure;
                    //    SqlParameter param1 = null;
                    //    SqlParameter param2 = null;
                    //    SqlParameter param3 = null;
                    //    SqlParameter param4 = null;
                    //    if (cust_no == "*" || cust_phone == "*" || cust_f_name == "*" || cust_l_name == "*")
                    //    {
                    //        param1 = new SqlParameter("@CustNum", "");
                    //        param2 = new SqlParameter("@Phone_1", "");
                    //        param3 = new SqlParameter("@First_Name", "");
                    //        param4 = new SqlParameter("@Last_Name", "");
                    //    }
                    //    else
                    //    {
                    //        param1 = new SqlParameter("@CustNum", cust_no);
                    //        param2 = new SqlParameter("@Phone_1", cust_phone);
                    //        param3 = new SqlParameter("@First_Name", cust_f_name);
                    //        param4 = new SqlParameter("@Last_Name", cust_l_name);
                    //    }

                    //    cmd1.Parameters.Add(param1);
                    //    cmd1.Parameters.Add(param2);
                    //    cmd1.Parameters.Add(param3);
                    //    cmd1.Parameters.Add(param4);

                    //    cmd1.ExecuteNonQuery();
                    //    DataSet _Bind = new DataSet();

                    //    SqlDataAdapter sda = new SqlDataAdapter(cmd1);

                    //    sda.Fill(_Bind, "MyBinding");

                    //    DataTable dt = _Bind.Tables[0];
                    //    if (dt.Rows.Count == 0)
                    //    {
                    //        dg_lookup_layaway.DataContext = null;
                    //    }
                    //    else
                    //    {

                    //        dg_lookup_layaway.SelectedValuePath = "Invoice_Number";
                    //        dg_lookup_layaway.DataContext = _Bind;
                           
                    //    }

                    //}
                    //glo.con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_customer_no_TextChanged(object sender, TextChangedEventArgs e)
        {
            add_params();
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            add_params();
        }

        private void btn_select_Click(object sender, RoutedEventArgs e)
        {
            if (dg_lookup_layaway.SelectedItem != null)
            {
                string inv_num = dg_lookup_layaway.SelectedValue.ToString();
                inv_nums = inv_num;
                this.Close();
            }
        }

        public string set_invnum
        {
            get { return inv_nums; }
            set { inv_nums = value; }
           
        }

        private void dg_lookup_layaway_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dg_lookup_layaway.SelectedItem != null)
            {
                string inv_num = dg_lookup_layaway.SelectedValue.ToString();
                inv_nums = inv_num;
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            set_invnum = null;
        }

    }
}
