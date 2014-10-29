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
    /// Interaction logic for Keyboard.xaml
    /// </summary>
    public partial class Keyboard : Window
    {
        public Keyboard()
        {
            InitializeComponent();
        }
        public Keyboard(Label lbl_onhold)
        {
            InitializeComponent();

            kb_heder_labl.Content = "Enter On-Hold ID:";
        }
        private static string new_value = null;
        private static string swip_id = null;
        private static string vendor_part_num = null;
        private TextBox txt;
        private static string name = null;
        private static string keyboard_txt = null;
        string no_change;
        private string lbl = "";
        private static string county = null;
        private static string descrp = null;
        private string p;
        private string p_2;
        private string heading;
        private int flage;

        public Keyboard(TextBox txt)
        {
            this.txt = txt;
            InitializeComponent();
            no_change = txt.Text.ToString();
            txt_keyboard.Text = txt.Text.ToString();

        }

        public Keyboard(string lbl)
        {
            InitializeComponent();
            this.lbl = lbl;

            kb_heder_labl.Content = lbl;

        }

        public Keyboard(string p, string lbl)
        {
            InitializeComponent();
            this.p = p;
            this.lbl = lbl;
            kb_heder_labl.Content = lbl;
            txt_keyboard.Text = "Received Inventory";
            txt_keyboard.SelectAll();
            if (p == "Enter New Value")
            {
                kb_heder_labl.Content = p;
                txt_keyboard.Text = lbl;
            }
            if (p == "Enter Description")
            {
                kb_heder_labl.Content = p;
                txt_keyboard.Text = lbl;
            }
        }

        public Keyboard(string heading, int flage)
        {
            InitializeComponent();
            this.heading = heading;
            this.flage = flage;
            kb_heder_labl.Content = heading;
        }

        private void btn_kb_cancel_Click(object sender, RoutedEventArgs e)
        {
            if (kb_heder_labl.Content == "Please Enter the new swipe ID you would like to use for this customer")
            {
                k_b_swipeid = null;
                this.Close();
            }
            else if (kb_heder_labl.Content == "Enter New Value")
            {
                new_value = null;
                this.Close();
            }
            else if (kb_heder_labl.Content == "Enter On-Hold ID:")
            {
                k_b_txts = null;
                this.Close();
            }
            else if (kb_heder_labl.Content.ToString().Contains("Enter Description for "))
            {
                set_decrep = null;
                this.Close();
            }
            else if (kb_heder_labl.Content.ToString().Contains("Enter the new Authorized member's name") || kb_heder_labl.Content.ToString().Contains("Enter Reference Code")
                || kb_heder_labl.Content.ToString().Contains("Scan, Swipe or Type Gift Card ID:") || kb_heder_labl.Content.ToString().Contains("Enter Approval Code"))
            {
                set_decrep = null;
                this.Close();
            }
            else
            {
                descrp = null;
                name = no_change;
                this.Close();
            }
        }
        #region shift content change
        private void btn_kb_shift_Click(object sender, RoutedEventArgs e)
        {
            if (btn_kb_shift.Content.Equals("Shift"))
            {
                btn_n1.Content = '!';
                btn_n2.Content = '@';
                btn_n3.Content = '#';
                btn_n4.Content = '$';
                btn_n5.Content = '%';
                btn_n6.Content = '^';
                btn_n7.Content = '&';
                btn_n8.Content = '*';
                btn_n9.Content = '(';
                btn_n0.Content = ')';

                btn_a.Content = 'a';
                btn_b.Content = 'b';
                btn_c.Content = 'c';
                btn_d.Content = 'd';
                btn_e.Content = 'e';
                btn_f.Content = 'f';
                btn_g.Content = 'g';
                btn_h.Content = 'h';
                btn_i.Content = 'i';
                btn_j.Content = 'j';
                btn_k.Content = 'k';
                btn_l.Content = 'l';
                btn_m.Content = 'm';
                btn_n.Content = 'n';
                btn_o.Content = 'o';
                btn_p.Content = 'p';
                btn_q.Content = 'q';
                btn_r.Content = 'r';
                btn_s.Content = 's';
                btn_t.Content = 't';
                btn_u.Content = 'u';
                btn_v.Content = 'v';
                btn_w.Content = 'w';
                btn_x.Content = 'x';
                btn_y.Content = 'y';
                btn_z.Content = 'z';
                btn_kb_shift.Content = "Shift Down";
            }
            else if (btn_kb_shift.Content.Equals("Shift Down"))
            {
                btn_n1.Content = '1';
                btn_n2.Content = '2';
                btn_n3.Content = '3';
                btn_n4.Content = '4';
                btn_n5.Content = '5';
                btn_n6.Content = '6';
                btn_n7.Content = '7';
                btn_n8.Content = '8';
                btn_n9.Content = '9';
                btn_n0.Content = '0';

                btn_a.Content = 'A';
                btn_b.Content = 'B';
                btn_c.Content = 'C';
                btn_d.Content = 'D';
                btn_e.Content = 'E';
                btn_f.Content = 'F';
                btn_g.Content = 'G';
                btn_h.Content = 'H';
                btn_i.Content = 'I';
                btn_j.Content = 'J';
                btn_k.Content = 'K';
                btn_l.Content = 'L';
                btn_m.Content = 'M';
                btn_n.Content = 'N';
                btn_o.Content = 'O';
                btn_p.Content = 'P';
                btn_q.Content = 'Q';
                btn_r.Content = 'R';
                btn_s.Content = 'S';
                btn_t.Content = 'T';
                btn_u.Content = 'U';
                btn_v.Content = 'V';
                btn_w.Content = 'W';
                btn_x.Content = 'X';
                btn_y.Content = 'Y';
                btn_z.Content = 'Z';
                btn_kb_shift.Content = "Shift";

            }
        }
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

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + button4.Content.ToString();
        }

        private void btn_kb_comma_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_kb_comma.Content.ToString();
        }

        private void btn_dot_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_dot.Content.ToString();
        }

        private void btn_slash_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_slash.Content.ToString();
        }
        private void btn_kb_space_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + ' ';
        }
        #endregion

        public string k_b_txts
        {
            get { return keyboard_txt; }
            set { keyboard_txt = value; }
        }
        public string k_b_swipeid
        {
            get { return swip_id; }
            set { swip_id = value; }
        }
        private void btn_kb_enter_Click(object sender, RoutedEventArgs e)
        {
            if(flage == 500)
            {
                descrp = txt_keyboard.Text;
                this.Close();
            }
             else if (kb_heder_labl.Content == "Please Enter the new swipe ID you would like to use for this customer")
            {
                swip_id = txt_keyboard.Text;
                this.Close();
            }
            else if (kb_heder_labl.Content == "Enter New Value")
            {
                new_value = txt_keyboard.Text;
                this.Close();
            }
            else if (kb_heder_labl.Content == "Enter On-Hold ID:")
            {
                keyboard_txt = txt_keyboard.Text;
                this.Close();
            }
            else if (kb_heder_labl.Content.ToString().Contains("Enter Description for ") || kb_heder_labl.Content.ToString().Contains("Enter the new Authorized member's name")
                || kb_heder_labl.Content.ToString().Contains("Scan, Swipe or Type Gift Card ID:") || kb_heder_labl.Content.ToString().Contains("Enter Approval Code") || kb_heder_labl.Content.ToString().Contains("Enter Reference Code"))
            {
                descrp = txt_keyboard.Text;
                this.Close();
            }
            if (kb_heder_labl.Content.Equals("Enter Description For This Adjustment"))
            {
                descrp = txt_keyboard.Text;
                //NumberKeypaid po = new NumberKeypaid(11, p);
                //this.Close();
                //po.ShowDialog();
            }
            else if (kb_heder_labl.Content.Equals("Enter Description"))
            {
                if (txt_keyboard.Text == "")
                {
                    MessageBox.Show("Enter Some Text Or Press Cancel", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    descrp = txt_keyboard.Text;
                    this.Close();
                }
            }
            else if (kb_heder_labl.Content.Equals("Enter Contry Name"))
            {
                county = txt_keyboard.Text;
                this.Close();
            }
            else if (kb_heder_labl.Content.Equals("Enter Description of Tax Rate"))
            {
                descrp = txt_keyboard.Text;
                this.Close();
            }
            else if (kb_heder_labl.Content.Equals("Enter The Item Number You Would Like To Search For") || kb_heder_labl.Content.Equals("Enter The Part Number You Would Like To Search For"))
            {
                descrp = txt_keyboard.Text;
                this.Close();
            }
            else if (kb_heder_labl.Content.Equals("Enter Password"))
            {
                descrp = txt_keyboard.Text;
                this.Close();
            }
            else if (kb_heder_labl.Content.Equals("Ener a New Station ID (Example: 01, 02, 99, etc)"))
            {
                descrp = txt_keyboard.Text;
                this.Close();
            }
            else
            {
                name = txt_keyboard.Text;
                if (kb_heder_labl.Content.Equals("Enter SKUs for Item"))
                {
                    name = txt_keyboard.Text;
                    this.Close();
                }
                else if (kb_heder_labl.Content.Equals("Enter SKUs for Item"))
                {
                    county = txt_keyboard.Text;
                    kb_heder_labl.Content = "Enter Description";
                }
                if (kb_heder_labl.Content.Equals("Enter Description"))
                {
                    descrp = txt_keyboard.Text;
                    this.Close();
                }
                if (kb_heder_labl.Content.Equals("Enter The Vendor Part Number"))
                {
                    vendor_part_num = txt_keyboard.Text;
                    this.Close();
                }
            }
        }
        public string set_new_value
        {
            get { return new_value; }
            set { new_value = value; }
        }
        public string set_name
        {
            get { return name; }
            set { name = value; }
        }

        public string set_county
        {
            get { return county; }
            set { county = value; }
        }

        public string set_decrep
        {
            get { return descrp; }
            set { descrp = value; }
        }

        public string set_ven_part_num
        {
            get { return vendor_part_num; }
            set { vendor_part_num = value; }
        }

        private void btn_kb_backspace_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txt_keyboard.SelectedText = "";
                if (txt_keyboard.Text.Length != 0)
                {
                    string texxt = txt_keyboard.Text.Substring(0, txt_keyboard.Text.Length - 1);
                    txt_keyboard.Text = texxt;
                }

            }
            catch (Exception)
            { }

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            k_b_txts = null;
            set_new_value = null;
        }
    }
}
