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
using POS.Domain.Common;
using POS.Services.Common;

namespace POS.Retail
{
    /// <summary>
    /// Interaction logic for SelectCustomerForm.xaml
    /// </summary>
    public partial class SelectCustomerForm : Window
    {
        CustomerClass objCustomerClass = new CustomerClass();
       string order = "CustNum";
        public SelectCustomerForm() //Select_Customer_frm()
        {
            InitializeComponent();
        }
        //GlobalClass glo = new GlobalClass();
        private TextBox txt;
       // private static string name = null;
        public static string cust_no = null;
        string no_change;
        public SelectCustomerForm(TextBox txt)
        {
            this.txt = txt;
            InitializeComponent();
            no_change = txt.Text.ToString();
            txt_keyboard.Text = txt.Text.ToString();
       
        }

        private void btn_kb_cancel_Click(object sender, RoutedEventArgs e)
        {
           // name = no_change; 
            this.Close();
        }
        #region shift content change

        #endregion

        #region key board click events

        private void btn_n1_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_n1.Content.ToString();
        }

        private void btn_n2_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_n2.Content.ToString();
        }

        private void btn_n3_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_n3.Content.ToString();
        }

        private void btn_n4_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_n4.Content.ToString();
        }

        private void btn_n5_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_n5.Content.ToString();
        }

        private void btn_n6_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_n6.Content.ToString();
        }

        private void btn_n7_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_n7.Content.ToString();
        }

        private void btn_n8_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_n8.Content.ToString();
        }

        private void btn_n9_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_n9.Content.ToString();
        }

        private void btn_n0_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_n0.Content.ToString();
        }

        private void btn_q_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_q.Content.ToString();
        }

        private void btn_w_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_w.Content.ToString();
        }

        private void btn_e_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_e.Content.ToString();
        }

        private void btn_r_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_r.Content.ToString();
        }

        private void btn_t_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_t.Content.ToString();
        }

        private void btn_y_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_y.Content.ToString();
        }

        private void btn_u_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_u.Content.ToString();
        }

        private void btn_i_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_i.Content.ToString();
        }

        private void btn_o_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_o.Content.ToString();
        }

        private void btn_p_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_p.Content.ToString();
        }

        private void btn_a_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_a.Content.ToString();
        }

        private void btn_s_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_s.Content.ToString();
        }

        private void btn_d_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_d.Content.ToString();
        }

        private void btn_f_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_f.Content.ToString();
        }

        private void btn_g_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_g.Content.ToString();
        }

        private void btn_h_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_h.Content.ToString();
        }

        private void btn_j_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_j.Content.ToString();
        }

        private void btn_k_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_k.Content.ToString();
        }

        private void btn_l_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_l.Content.ToString();
        }

        private void btn_z_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_z.Content.ToString();
        }

        private void btn_x_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_x.Content.ToString();
        }

        private void btn_c_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_c.Content.ToString();
        }

        private void btn_v_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_v.Content.ToString();
        }

        private void btn_b_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_b.Content.ToString();
        }

        private void btn_n_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_n.Content.ToString();
        }

        private void btn_m_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_m.Content.ToString();
        }

        private void btn_dash_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_dash.Content.ToString();
        }

       

       
        
       
        private void btn_kb_space_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + ' '; 
        }
        #endregion

        private void btn_kb_enter_Click(object sender, RoutedEventArgs e)
        {
            //name = txt_keyboard.Text;
            this.Close();
        }

        //public string set_name
        //{
        //    get { return name; }
        //    set { name = value; }
        //}

        private void btn_kb_backspace_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_keyboard.Text.Length != 0)
                {
                    txt_keyboard.SelectedText = "";

                    string texxt = txt_keyboard.Text.Substring(0, txt_keyboard.Text.Length - 1);
                    txt_keyboard.Text = texxt;
                }

            }
            catch (Exception)
            { }
            
        }
        private void FillCustomerGrid()
        {
            objCustomerClass.flage = "LoadCustomersToGrid";
            POSManagementService objMgtServices = new POSManagementService();
            objMgtServices.GetCustomerInfor(objCustomerClass);
            dg_customers.ItemsSource = objCustomerClass.loadCustDat.DefaultView;
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillCustomerGrid();
           // customer_search("", "CustNum");

        }
        private void customer_search(string customer,string order_by)
        {
            //if (glo.con.State == ConnectionState.Closed)
            //{
            //    glo.con.Open();
            //}
            //using (SqlCommand cmd = new SqlCommand("dbo.CUSTOMER_QUICK_SEARCH",glo.con))
            //{
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    SqlParameter param = null;
            //    SqlParameter param2 = null;
            //    if (customer.Length != 0)
            //    {
            //        param = new SqlParameter("@CUSTOMER", customer);
            //    }
            //    else
            //    {
            //        param = new SqlParameter("@CUSTOMER", "");
            //    }
            //    cmd.Parameters.Add(param);
            //    param2 = new SqlParameter("@orderby", order_by);
            //    cmd.Parameters.Add(param2);
            //    cmd.ExecuteNonQuery();
            //    DataSet _Bind = new DataSet();

            //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //    sda.Fill(_Bind, "MyBinding");
            //    DataTable dt = _Bind.Tables[0];

            //    dg_customers.SelectedValuePath = "CustNum";

            //    dg_customers.DataContext = _Bind;
            //}
            //if (glo.con.State == ConnectionState.Open)
            //{
            //    glo.con.Close();
            //}
        }

        private void txt_keyboard_TextChanged(object sender, TextChangedEventArgs e)
        {
            objCustomerClass.flage = "SearchCustomerTxtbx";
            objCustomerClass.CustNum = txt_keyboard.Text.Trim();
            objCustomerClass.First_Name = txt_keyboard.Text.Trim();
            objCustomerClass.Last_Name = txt_keyboard.Text.Trim();
            objCustomerClass.Phone_1 = txt_keyboard.Text.Trim();
            objCustomerClass.Company = txt_keyboard.Text.Trim();
            POSManagementService objPOSManagementService = new POSManagementService();
            objPOSManagementService.GetCustomerInfor(objCustomerClass);
            dg_customers.ItemsSource = objCustomerClass.loadCustDat.DefaultView;
            //customer_search(txt_keyboard.Text, "CustNum");
        }

        private void btn_change_order_Click(object sender, RoutedEventArgs e)
        {
            if (order == "CustNum")
            {
                order="First_Name";
                customer_search(txt_keyboard.Text, order);
            }
            else if (order == "First_Name")
            {
                order = "Last_Name";
                customer_search(txt_keyboard.Text, order);
            }
            else if (order == "Last_Name")
            {
                order = "Company";
                customer_search(txt_keyboard.Text, order);
            }
            else if (order == "Company")
            {
                order = "Phone_1";
                customer_search(txt_keyboard.Text, order);
            }
            else if (order == "Phone_1")
            {
                order = "CustNum";
                customer_search(txt_keyboard.Text, order);
            }
        }

        private void dg_customers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            btn_select_Click(sender, e);
            //MessageBox.Show(dg_customers.SelectedValue.ToString());
            //cust_no = dg_customers.SelectedValue.ToString();
            //this.Close();
        }
        public  string set_cust_no
        {
            get { return cust_no; }
            set { cust_no = value; }
               
        }

        private void btn_select_Click(object sender, RoutedEventArgs e)
        {
            if (dg_customers.SelectedValue == null)
            {
                MessageBox.Show("Please select Customer", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            DataGridRow rowss = (DataGridRow)dg_customers.ItemContainerGenerator.ContainerFromIndex(dg_customers.SelectedIndex);
            string a = (dg_customers.Columns[0].GetCellContent(rowss) as TextBlock).Text;

            cust_no = a;

            this.Close();
        }
    }
}
