using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using POS.Retail.Common;

namespace POS.Retail
{
    /// <summary>
    /// Interaction logic for PayTypeForm.xaml
    /// </summary>
    public partial class PayTypeForm : Window
    {
        RegexClass regclass = new RegexClass();
        private const int Style = -16;
        private const int MaximizeIcon = 0x10000;
        private const int MinimizeIcon = 0x20000;
        bool cancel = false;
        private static List<string> card_ids = new List<string>();
        private static List<string> card_balances = new List<string>();
        private static List<string> card_amounts = new List<string>();
        //GlobalClass glo = new GlobalClass();
        int cr_indx = 0;
        private static Double amt;
        private static string p_type=null;
        string g_total = null;
        string btn_cliked = null;
        string custnum = null;
        public PayTypeForm() //Pay_Type_frm()
        {
            InitializeComponent();
        }
        public List<string> set_card_ids
        {
            get { return card_ids; }
            set { value = card_ids; }
        }
        public List<string> set_card_balances
        {
            get { return card_balances; }
            set { value = card_balances; }
        }
        public List<string> set_card_amounts
        {
            get { return card_amounts; }
            set { value = card_amounts; }
        }
        public PayTypeForm(string grandtotal)
        {            
            InitializeComponent();
            this.g_total = grandtotal;
            txt_keyboard.Text = g_total;
        }
        public PayTypeForm(string grandtotal,string btn_clcked)
        {
            InitializeComponent();
            this.g_total = grandtotal;
            txt_keyboard.Text = g_total;
            this.btn_cliked = btn_clcked;
        }
        public PayTypeForm(string grandtotal, string btn_clcked, string cust_num)
        {
            InitializeComponent();
            this.g_total = grandtotal;
            txt_keyboard.Text = g_total;
            this.btn_cliked = btn_clcked;
            this.custnum = cust_num;
        }
        private void enter_number_value(Button btn_clckd)
        {
            cr_indx = txt_keyboard.CaretIndex;
            //if (cr_indx != txt_numbers.Text.Length)
            //{
            cr_indx = txt_keyboard.CaretIndex;
            if (txt_keyboard.SelectedText.Length != 0)
            {
                txt_keyboard.SelectedText = btn_clckd.Content.ToString();
            }
            else
            {
                txt_keyboard.Text = txt_keyboard.Text.Insert(txt_keyboard.CaretIndex, btn_clckd.Content.ToString());
            }
            txt_keyboard.Focus();
            //int startIndex = txt_numbers.Text.IndexOf(btn_n7.Content.ToString());

            txt_keyboard.Select(cr_indx + 1, 0);

            //}
            //else
            //{
            //   txt_numbers.Text= txt_numbers.Text + btn_clckd.Content.ToString();

            //}
        }
        private void btn_n1_Click(object sender, RoutedEventArgs e)
        {
            Button btn_clckd = (Button)sender;
            enter_number_value(btn_clckd);
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

        private void btn_dot_Click(object sender, RoutedEventArgs e)
        {


            if (!txt_keyboard.Text.Contains("."))
            {
                cr_indx = txt_keyboard.CaretIndex;
                //if (cr_indx != txt_numbers.Text.Length)
                //{
                cr_indx = txt_keyboard.CaretIndex;
                if (txt_keyboard.SelectedText.Length != 0)
                {
                    txt_keyboard.SelectedText = btn_dot.Content.ToString();
                }
                else
                {
                    txt_keyboard.Text = txt_keyboard.Text.Insert(txt_keyboard.CaretIndex, btn_dot.Content.ToString());
                }
                txt_keyboard.Focus();
                //int startIndex = txt_numbers.Text.IndexOf(btn_n7.Content.ToString());

                txt_keyboard.Select(cr_indx + 1, 0);

            }
        }

        private void btn_minus_plus_Click(object sender, RoutedEventArgs e)
        {
            double oper1 = 0;
            string s = txt_keyboard.Text;
            oper1 = Convert.ToDouble(txt_keyboard.Text);
            oper1 = -oper1;
            txt_keyboard.Text = oper1.ToString();
            //string txt = txt_keyboard.Text;
            //if (txt_keyboard.Text.Contains("("))
            //{
            //    txt_keyboard.Text = txt.Substring(1, txt.Length -2);
                
            //}
            //else
            //{
            //    txt_keyboard.Text = "(" + txt_keyboard.Text + ")";
            //}
        }
        public  Double cash_Amt
        {
            get { return amt; }
            set{amt=value;}
        }
        public string paymnt_typ
        {
            get { return p_type; }
            set { p_type = value; }
        }
        private void btn_cash_Click(object sender, RoutedEventArgs e)
        {
            get_values("Cash");
        }

        private void btn_external_card_Click(object sender, RoutedEventArgs e)
        {
            //Credit_Card_trans_frm cc_form = new Credit_Card_trans_frm();
            //cc_form.ShowDialog();
            //if (cc_form.set_cc_number != null)
            //{
            //    cancel = true;
            //    get_values("External_card");
            //}
        }

        private void btn_check_Click(object sender, RoutedEventArgs e)
        {
            //Check_number_frm chk_frm = new Check_number_frm();
            //chk_frm.ShowDialog();
            //if (chk_frm.chknum != 0)
            //{
            //    get_values("Check");
            //}
           
        }

        private void btn_gift_card_Click(object sender, RoutedEventArgs e)
        {
             MyDialog dialog = new MyDialog("Scan, Swipe or Type Gift Card ID:", "");
                     dialog.ShowDialog();

                    //if (dialog.InputText1.Length != 0)
                    //{
                    //    if (glo.con.State == ConnectionState.Closed)
                    //    {
                    //        glo.con.Open();
                    //    }
                    //    double balance=0;
                       
                    //    SqlCommand cmd_count_gc = new SqlCommand("select count(*) from Gift_Cards where Card_ID='" + dialog.InputText1 + "'", glo.con);
                    //    if (Convert.ToInt32(cmd_count_gc.ExecuteScalar()) != 0)
                    //    {
                    //        SqlCommand cmd_check_gc = new SqlCommand("select Balance from Gift_Cards where Card_ID='" + dialog.InputText1 + "'", glo.con);
                    //        SqlDataReader rdr_check_gc = cmd_check_gc.ExecuteReader();
                    //        rdr_check_gc.Read();
                    //        balance = Convert.ToDouble(rdr_check_gc["Balance"]);
                    //        rdr_check_gc.Close();

                    //        if (balance <= 0 || card_ids.Contains(dialog.InputText1))
                    //        {
                    //            MessageBox.Show("This Gift Card has zero balance", "No Balance", MessageBoxButton.OK, MessageBoxImage.Stop);

                    //        }
                    //        else
                    //        {
                    //            card_ids.Add(dialog.InputText1);
                    //            if (balance >= Convert.ToDouble(txt_keyboard.Text))
                    //            {
                    //                double new_balance = balance - Convert.ToDouble(txt_keyboard.Text);
                    //                card_balances.Add(new_balance.ToString());
                    //                get_values("Gift_card");
                    //                card_amounts.Add(txt_keyboard.Text);
                    //            }
                    //            else if (balance < Convert.ToDouble(txt_keyboard.Text))
                    //            {
                    //                double org_value = Convert.ToDouble(txt_keyboard.Text);
                    //                double new_value = Convert.ToDouble(txt_keyboard.Text) - balance;
                    //                txt_keyboard.Text = new_value.ToString();
                    //                card_amounts.Add((org_value - new_value).ToString());
                    //                card_balances.Add("0");

                    //            }
                    //        }

                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Gift Card not entered yet","Gift Card Failed",MessageBoxButton.OK,MessageBoxImage.Error);
                    //    }

                    //    if (glo.con.State == ConnectionState.Open)
                    //    {
                    //        glo.con.Close();
                    //    }
                    //}
            
        }

        private void btn_on_account_Click(object sender, RoutedEventArgs e)
        {
            On_account_transaction();
        }
        private void get_values(string pay_typ)
        {
            if (txt_keyboard.Text.Length != 0)
            {
                
                    p_type = pay_typ;
                
                amt = Convert.ToDouble(txt_keyboard.Text);
                this.Close();
            }
        }

        private void btn_debit_Click(object sender, RoutedEventArgs e)
        {
            get_values("Debit");
        }
        public static class NativeMethods
        {
            [DllImport("user32.dll")]
            internal static extern int GetWindowLong(IntPtr hWnd, int index);

            [DllImport("user32.dll")]
            internal static extern int SetWindowLong(IntPtr hWnd, int index, int newLong);
           
        }
        private static void OnSourceInitialized(object sender, EventArgs e)
        {
            var window = (Window)sender;

            var hWnd = new WindowInteropHelper(window).Handle;
            UpdateWindowStyle(window, hWnd);

            window.SourceInitialized -= OnSourceInitialized;
        }
        private static void UpdateWindowStyle(Window window, IntPtr hWnd)
        {
            var style = NativeMethods.GetWindowLong(hWnd, Style);
                
            style &= ~MinimizeIcon;
            style &= ~MaximizeIcon;
            
            NativeMethods.SetWindowLong(hWnd, Style, style);
             //const int GWL_STYLE = -16;
             const int WS_SYSMENU = 0x80000;
 IntPtr hwnd = new System.Windows.Interop.WindowInteropHelper(window).Handle;
 NativeMethods.SetWindowLong(hwnd, Style, NativeMethods.GetWindowLong(hwnd, Style) & ~WS_SYSMENU);
            //NativeMethods.RemoveMenu(hWnd, 0xF060, 0x0000);
            
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var window = this;
            if (window != null)
            {
                var hWnd = new WindowInteropHelper(window).Handle;
                if (hWnd == IntPtr.Zero)
                {
                    window.SourceInitialized += OnSourceInitialized;
                }
                else
                {
                    UpdateWindowStyle(window, hWnd);
                }
            }
            set_card_balances = null;
            set_card_ids = null;
            paymnt_typ = null;
            cash_Amt = 0;
            if (btn_cliked == "On_check")
            {
                CheckNumberForm chk_frm = new CheckNumberForm();
                chk_frm.ShowDialog();
                if (chk_frm.chknum != 0)
                {
                    get_values("Check");
                }
            }
            else if (btn_cliked == "On_CC")
            {
                //Credit_Card_trans_frm cc_frm = new Credit_Card_trans_frm();
                //cc_frm.ShowDialog();
                //if (cc_frm.set_cc_number != null)
                //{
                //    cancel = true;
                //    get_values("External_card");
                //}
            }
            else if (btn_cliked == "On_Account")
            {
                On_account_transaction();
                
            }
            txt_keyboard.SelectAll();
        }
        private void On_account_transaction()
        {
            //if (glo.con.State == ConnectionState.Closed)
            //{
            //    glo.con.Open();
            //}
            //SqlCommand cmd_max_charge_amt = new SqlCommand("select Max_Charge_Amount from Customer where CustNum='" + custnum + "'", glo.con);

            //double amt = 0;
            //SqlDataReader rdr_max_charge_amt = cmd_max_charge_amt.ExecuteReader();
            //rdr_max_charge_amt.Read();
            //amt = Convert.ToDouble(rdr_max_charge_amt["Max_Charge_Amount"]);
            //rdr_max_charge_amt.Close();
            //if (glo.con.State == ConnectionState.Open)
            //{
            //    glo.con.Close();
            //}
            //MessageBox.Show("" + amt);
            //if (Convert.ToDouble(txt_keyboard.Text) > amt)
            //{
            //    double rem_amt = Convert.ToDouble(txt_keyboard.Text) - amt;
            //    MessageBox.Show("This purchase would exceed the amount you are allowed to charge by \n" + rem_amt + "with in 30 days.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            //    MyDialog showdialog = new MyDialog("Enter Administrator Password", "");
            //    showdialog.ShowDialog();
            //    if (showdialog.InputText == "admin")
            //    {
            //        get_values("On_account");
            //    }
            //}
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cancel == true)
            {
                set_card_amounts = null;
                set_card_balances = null;
                card_ids = null;
                set_card_ids = null;
            }
            //var window = this;
            ////const int WS_SYSMENU = 0x80000;
            ////IntPtr hwnd = new System.Windows.Interop.WindowInteropHelper(window).Handle;
            ////NativeMethods.SetWindowLong(hwnd, Style, NativeMethods.GetWindowLong(hwnd, Style) & WS_SYSMENU);
            ////this.Close();
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            cancel = true;
            this.Close();
        }

        private void txt_keyboard_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //regclass.checkForNumericWithDotDash(e);
        }
    }
}
