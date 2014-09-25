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
using System.Windows.Navigation;
using System.Windows.Shapes;
using POS.Repository.SQLServer;


namespace POS.Retail
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SQLServerRepository sqlreposetory = new SQLServerRepository();
        private static string flage_position = null;
        private static string cashier_id = null;

        string position;
        public MainWindow()
        {
            InitializeComponent();
        }
        public string set_cashier_id
        {
            get { return cashier_id; }
            set { cashier_id = value; }
        }
        private void btn_exit_main_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btn_main_manager_Click(object sender, RoutedEventArgs e)
        {
            position = "manager";
            if (grid_password.Visibility == System.Windows.Visibility.Hidden)
            {
                Grid_id.Visibility = Visibility.Visible;
                lbl_id.Content = "(Manager)";
                btn_main_manager.Background = Brushes.Blue;
                btn_main_manager.Foreground = Brushes.White;
                btn_cashier.Background = Brushes.Yellow;
                btn_cashier.Foreground = Brushes.Black;
                psd_login_id.Focus();
            }
        }
        private void fun_btn_id_enter()
        {
            if (position == "cashier")
            {
                if (psd_login_id.Password != "")
                {
                    Grid_id.Visibility = Visibility.Hidden;
                    grid_password.Visibility = Visibility.Visible;
                    psdbox_password.Focus();
                    btn_pas_delete.Content = "Cancel";
                }
            }
            else if (position == "manager")
            {
                if (psd_login_id.Password != "")
                {
                    Grid_id.Visibility = Visibility.Hidden;
                    grid_password.Visibility = Visibility.Visible;
                    psdbox_password.Focus();
                    btn_pas_delete.Content = "Cancel";
                }
            }
        }
        private void fun_login_btn()
        {
            if (position == "cashier")
            {
                if (psd_login_id.Password == "02" && psdbox_password.Password == "john")
                {
                    cashier_id = psd_login_id.Password;
                    psdbox_password.Password = "";
                    psd_login_id.Password = "";
                    //CashRegisterForm cashform = new CashRegisterForm();
                    //cashform.ShowDialog();
                    grid_password.Visibility = Visibility.Hidden;
                    Grid_id.Visibility = Visibility.Visible;
                    psd_login_id.Focus();
                }
                else
                {
                    MessageBox.Show("You have Entered an invalid Cashier ID OR Password, Try Again", "ID OR Password Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    psd_login_id.Password = "";
                    psdbox_password.Password = "";
                    grid_password.Visibility = Visibility.Hidden;
                    Grid_id.Visibility = Visibility.Visible;
                    psd_login_id.Focus();
                }
            }
            else if (position == "manager")
            {
                if (psd_login_id.Password == "01" && psdbox_password.Password == "admin")
                {
                    psdbox_password.Password = "";
                    psd_login_id.Password = "";
                    ManagerForm objman = new ManagerForm();
                    grid_password.Visibility = Visibility.Hidden;
                    objman.ShowDialog();
                    Grid_id.Visibility = Visibility.Visible;
                    psd_login_id.Focus();
                }
                else
                {
                    MessageBox.Show("You have Entered an invalid Cashier ID OR Password, Try Again", "ID OR Password Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    psd_login_id.Password = "";
                    psdbox_password.Password = "";
                    grid_password.Visibility = Visibility.Hidden;
                    Grid_id.Visibility = Visibility.Visible;
                    psd_login_id.Focus();
                }
            }
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void btn_log_id_enter_Click(object sender, RoutedEventArgs e)
        {
            fun_btn_id_enter();
        }

        private void btn_pas_delete_Click(object sender, RoutedEventArgs e)
        {

            Grid_id.Visibility = Visibility.Visible;
            grid_password.Visibility = Visibility.Hidden;
            psdbox_password.Password = "";
            psd_login_id.Password = "";
            psd_login_id.Focus();

        }

        #region keypad click events to  enter the numbers in password box

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            psd_login_id.Password = psd_login_id.Password + "0";
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            psd_login_id.Password = psd_login_id.Password + "1";
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            psd_login_id.Password = psd_login_id.Password + "2";
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            psd_login_id.Password = psd_login_id.Password + "3";
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            psd_login_id.Password = psd_login_id.Password + "4";
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            psd_login_id.Password = psd_login_id.Password + "5";
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            psd_login_id.Password = psd_login_id.Password + "6";
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            psd_login_id.Password = psd_login_id.Password + "7";
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            psd_login_id.Password = psd_login_id.Password + "8";
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            psd_login_id.Password = psd_login_id.Password + "9";
        }


        private void btn_n1_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "1";
        }

        private void btn_n2_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "2";
        }

        private void btn_n3_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "3";
        }

        private void btn_n4_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "4";
        }

        private void btn_n5_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "5";
        }

        private void btn_n6_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "6";
        }

        private void btn_n7_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "7";
        }

        private void btn_n8_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "8";
        }

        private void btn_n9_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "9";
        }

        private void btn_n0_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "0";
        }

        private void btn_a_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "a";
        }

        private void btn_b_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "b";
        }

        private void btn_c_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "c";
        }

        private void btn_d_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "d";
        }

        private void btn_e_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "e";
        }

        private void btn_f_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "f";
        }

        private void btn_g_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "g";
        }

        private void btn_h_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "h";
        }

        private void btn_i_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "i";
        }

        private void btn_j_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "j";
        }

        private void btn_k_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "k";
        }

        private void btn_l_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "l";
        }

        private void btn_m_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "m";
        }

        private void btn_n_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "n";
        }

        private void btn_o_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "o";
        }

        private void btn_p_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "p";
        }

        private void btn_q_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "q";
        }

        private void btn_r_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "r";
        }

        private void btn_s_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "s";
        }

        private void btn_t_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "t";
        }

        private void btn_u_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "u";
        }

        private void btn_v_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "v";
        }

        private void btn_w_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "w";
        }

        private void btn_x_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "x";
        }

        private void btn_y_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "y";
        }

        private void btn_z_Click(object sender, RoutedEventArgs e)
        {
            psdbox_password.Password = psdbox_password.Password + "z";
        }
        #endregion
        private void btn_login_pos_Click(object sender, RoutedEventArgs e)
        {
            fun_login_btn();
        }

        private bool f_check_expiry(DateTime p_date)
        {
        //    DateTime l_date_end = p_date.AddDays(30);
        //    DateTime l_date_max;
        //    string qruy = "select MAX(datetime) as date_max from Invoice_Totals";
        //    glo.con.Open();
        //    SqlCommand cmd_read = new SqlCommand(qruy, glo.con);
        //    SqlDataReader rdr = cmd_read.ExecuteReader();
        //    rdr.Read();
        //    l_date_max = Convert.ToDateTime(rdr["date_max"]);
        //    rdr.Close();
        //    glo.con.Close();
        //    if (l_date_max > l_date_end)
        //    {
        //        return false;
        //    }
        //    else
            return true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            if (sqlreposetory.isServerConnected() == true)
            {
                Grid_id.Visibility = Visibility.Hidden;
                grid_password.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Database Cannot Connect Please Configure Your Database", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                DataBaseSettingForm db = new DataBaseSettingForm();
                this.Close();
                db.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                db.ShowDialog();
            }      
        }

        private void btn_cashier_Click(object sender, RoutedEventArgs e)
        {
            position = "cashier";
            if (grid_password.Visibility == System.Windows.Visibility.Hidden)
            {
                Grid_id.Visibility = Visibility.Visible;
                lbl_id.Content = "(Cashier)";
                btn_cashier.Background = Brushes.Blue;
                btn_cashier.Foreground = Brushes.White;
                btn_main_manager.Background = Brushes.Yellow;
                btn_main_manager.Foreground = Brushes.Black;
                psd_login_id.Focus();
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            //StoreStation s_obj = new StoreStation();
            //s_obj.ShowDialog();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {

        }
        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                MinWidth = 0;
                MinHeight = 0;
                MaxWidth = int.MaxValue;
                MaxHeight = int.MaxValue;

                if (!m_isDuringMaximizing)
                {
                    m_isDuringMaximizing = true;
                    WindowState = WindowState.Normal;
                    WindowState = WindowState.Maximized;
                    m_isDuringMaximizing = false;
                }
            }
            else if (!m_isDuringMaximizing)
            {
                MinWidth = 1024;
                MinHeight = 768;
                MaxWidth = 1024;
                MaxHeight = 768;
            }

            base.OnStateChanged(e);
        }

        public bool m_isDuringMaximizing { get; set; }

        private void psd_login_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                fun_btn_id_enter();
            }
        }

        private void button14_Click(object sender, RoutedEventArgs e)
        {
            psd_login_id.Password = "";
        }

        private void btn_back_space_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string st = psd_login_id.Password.ToString().Substring(0, psd_login_id.Password.Length - 1);
                psd_login_id.Password = st;
            }
            catch (Exception)
            { }

        }

        private void psdbox_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                fun_login_btn();
            }
        }

        private void btn_backspace_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string st = psdbox_password.Password.ToString().Substring(0, psdbox_password.Password.Length - 1);
                psdbox_password.Password = st;
            }
            catch (Exception)
            { }
        }
        public string set_flage_position
        {
            get { return flage_position; }
            set { flage_position = value; }
        }
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            //StoreStation s_obj = new StoreStation(1);
            //s_obj.ShowDialog();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            //CorporateSetup corp = new CorporateSetup();
            //corp.ShowDialog();
        }
    }
}
