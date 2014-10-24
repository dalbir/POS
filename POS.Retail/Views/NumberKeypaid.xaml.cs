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
using POS.Retail.Common;

namespace POS.Retail
{
    /// <summary>
    /// Interaction logic for NumberKeypaid.xaml
    /// </summary>
    public partial class NumberKeypaid : Window
    {
        string cashier_id = null;
        string curr_cash = null;
        int cr_indx = 0;
        string no_change;
        private static string inv_number = null;
        private static string name = null;
        private static string cash_reg_price = null;
        private static string percentage = "0";
        private static string quanity = "0";
        private static int key_flage_cancel = 0;
        private static string dollor;
        private int flagge;
        private string price;
        private static string num_value;
        private string p;
        private string textbox_text;
        private static string line_no = null;
        private static string qty_rec_damg = null;
        private static string change_value = null;
        private static string pricce = null;
        private static string Value = null;
        private Domain.Common.Inventory_CustPricesClass objInvCustPricesClass;
        private string lblheading;
        private int flage;
        private static string globalValue = null;
        //Regex_class regclass = new Regex_class();
        //GlobalClass glo = new GlobalClass();
        public NumberKeypaid()
        {
            InitializeComponent();
        }
        public string setglobalValue
        {
            get { return globalValue; }
            set { globalValue = value; }
        }

        public NumberKeypaid(TextBox txt)
        {
            InitializeComponent();
            no_change = txt.Text.ToString();
            //double b = Convert.ToDouble(txt.Text);
            if (txt.Text.Contains("-"))
            {
                string st = txt.Text.Substring(1, txt.Text.Length - 1);
                st = st + "-";
                txt_numbers.Text = st;
            }
            else
            {
                txt_numbers.Text = txt.Text;
            }
        }
        public NumberKeypaid(int flagge, string price)
        {
            InitializeComponent();
            this.flagge = flagge;
            this.price = price;
            if (flagge == 8)
            {
                txt_numbers.Text = price;
                lbl_keypaid.Content = "Enter New Price";
            }
            else if (flagge == 9)
            {
                txt_numbers.Text = price;
                lbl_keypaid.Content = "Enter  Quantity";
            }
            else if (flagge == 10)
            {
                txt_numbers.Text = price;
                lbl_keypaid.Content = "Enter Percentage off";
            }
            else if (flagge == 11)
            {
                lbl_keypaid.Content = "Enter # Received";
                txt_numbers.Text = "1";
                txt_numbers.Focus();
            }
            else if (flagge == 17)
            {
                txt_numbers.Text = price;
                lbl_keypaid.Content = "Payment Amount:";
            }
            else if (flagge == 18)
            {
                txt_numbers.Text = price;
                lbl_keypaid.Content = "Enter Gift Card Amount:";
            }
            else if (flagge == 21)
            {
                lbl_keypaid.Content = "Enter Line Number To Receive";
                txt_numbers.Text = price;
                txt_numbers.SelectAll();
                txt_numbers.Focus();
            }
            else if (flagge == 22)
            {
                lbl_keypaid.Content = "Enter the Quantity Received";
                txt_numbers.Text = price;
                txt_numbers.SelectAll();
                txt_numbers.Focus();
            }
            else if (flagge == 23)
            {
                lbl_keypaid.Content = "Enter Line Number to Receive Damaged";
                txt_numbers.Text = price;
                txt_numbers.SelectAll();
                txt_numbers.Focus();
            }
            else if (flagge == 24)
            {
                lbl_keypaid.Content = "Enter Quantity to Receive Damaged";
                txt_numbers.Text = price;
                txt_numbers.SelectAll();
                txt_numbers.Focus();
            }
            else if (flagge == 28)
            {
                lbl_keypaid.Content = "How many days would you like to rent this item for?";
                txt_numbers.Text = price;
                txt_numbers.SelectAll();
                txt_numbers.Focus();
            }
            else if (flagge == 32)
            {
                lbl_keypaid.Content = "Enter Invoice Discount";
                txt_numbers.Text = price;
                txt_numbers.SelectAll();
                txt_numbers.Focus();
            }
            else if (flagge == 33)
            {
                lbl_keypaid.Content = "Enter New Price";
                txt_numbers.Text = price;
                txt_numbers.SelectAll();
                txt_numbers.Focus();
            }

            else if (flagge == 34)
            {
                MainWindow mw = new MainWindow();
                //if (glo.con.State == ConnectionState.Closed)
                //{
                //    glo.con.Open();
                //}
                //cashier_id = mw.set_cashier_id;
                //SqlCommand cmd_employe_currcash = new SqlCommand("select Current_Cash from Employee where Cashier_ID='" + cashier_id + "'", glo.con);
                //SqlDataReader rdr_employe_currcash = cmd_employe_currcash.ExecuteReader();
                //rdr_employe_currcash.Read();
                //curr_cash = rdr_employe_currcash["Current_Cash"].ToString();
                //rdr_employe_currcash.Close();
                //if (glo.con.State == ConnectionState.Open)
                //{
                //    glo.con.Close();
                //}
                lbl_keypaid.Content = "ENTER PICKUP AMOUNT--MINIMUM\n" + curr_cash;
                txt_numbers.Text = price;
                txt_numbers.SelectAll();
                txt_numbers.Focus();
            }
            else if (flagge == 35)
            {
                lbl_keypaid.Content = "Enter Invoice Number";
                txt_numbers.Text = price;
                txt_numbers.SelectAll();
                txt_numbers.Focus();
            }
            else if (flagge == 36)
            {
                lbl_keypaid.Content = "Enter Tip Amount";
                txt_numbers.Text = price;
                txt_numbers.SelectAll();
                txt_numbers.Focus();
            }
            else if(flagge == 103)
            {
                txt_numbers.Text = pricce;
                lbl_keypaid.Content = "Enter New Overtime Vage";
            }

        }
        public NumberKeypaid(int flagge)
        {

            InitializeComponent();
            this.flagge = flagge;

            if (flagge == 1)
            {
                lbl_keypaid.Content = "Enter Tax in Percentage";
            }
            else if (flagge == 2)
            {
                lbl_keypaid.Content = "Enter Percentage";
            }
            else if (flagge == 3 || flagge == 31)
            {
                lbl_keypaid.Content = "Enter Price";
            }
            else if (flagge == 4)
            {
                lbl_keypaid.Content = "Enter Quantity";
            }
            else if (flagge == 5 || flagge == 30)
            {
                lbl_keypaid.Content = "Enter Quantity";
                txt_numbers.Text = "0";
                txt_numbers.SelectAll();
            }
            else if (flagge == 6)
            {
                lbl_keypaid.Content = "Enter Time-Base Price";
                txt_numbers.Focus();
                txt_numbers.Text = "$50.00";
                txt_numbers.SelectAll();
            }
            else if (flagge == 7)
            {
                lbl_keypaid.Content = "Enter Number";
            }
            else if (flagge == 12)
            {
                lbl_keypaid.Content = "How Many Days For This Price Level";
                txt_numbers.Text = "1";
                txt_numbers.Focus();
            }
            else if (flagge == 13)
            {
                lbl_keypaid.Content = "How much will it Cost to Rent This Item For Days";
                txt_numbers.Text = "$0.00";
                txt_numbers.SelectAll();
            }
            else if (flagge == 14)
            {
                lbl_keypaid.Content = "Enter New Rate";
                txt_numbers.Text = "0";
                txt_numbers.SelectAll();
            }
            else if (flagge == 15)
            {
                lbl_keypaid.Content = "Enter CC Exp Year";
            }
            else if (flagge == 19)
            {
                lbl_keypaid.Content = "Enter Credit Card Number";
            }
            else if (flagge == 20)
            {
                lbl_keypaid.Content = "Enter CC Exp Month";
            }
            else if (flagge == 25)
            {
                lbl_keypaid.Content = "Enter New Price";
            }
            else if(flagge == 101)
            {
                lbl_keypaid.Content = "Enter A Quantity";
            }
            else if(flagge == 102)
            {
                lbl_keypaid.Content = "Enter A Price";
            }
            else if(flagge == 103)
            {
                lbl_keypaid.Content = "Enter Hourly Wage";
            }
            else if (flagge == 104)
            {
                lbl_keypaid.Content = "Enter Hourly overtime Wage";
            }
            else if(flagge == 501)
            {
                lbl_keypaid.Content = "Enter Cash tips";
            }

        }

        public NumberKeypaid(string p, string textbox_text)
        {
            InitializeComponent();
            this.p = p;
            this.textbox_text = textbox_text;
            lbl_keypaid.Content = p;
            txt_numbers.Text = textbox_text.ToString();
        }

        public NumberKeypaid(Domain.Common.Inventory_CustPricesClass objInvCustPricesClass)
        {
            InitializeComponent();
            this.objInvCustPricesClass = objInvCustPricesClass;
            lbl_keypaid.Content = objInvCustPricesClass.message;
        }

        public NumberKeypaid(string lblheading, int flage)
        {
            InitializeComponent();
            this.lblheading = lblheading;
            this.flage = flage;
            lbl_keypaid.Content = lblheading;
        }


        #region
        private void btn_n1_Click(object sender, RoutedEventArgs e)
        {
            txt_numbers.Text = txt_numbers.Text + btn_n1.Content.ToString();
        }

        private void btn_n2_Click(object sender, RoutedEventArgs e)
        {
            txt_numbers.Text = txt_numbers.Text + btn_n2.Content.ToString();
        }

        private void btn_n3_Click(object sender, RoutedEventArgs e)
        {
            txt_numbers.Text = txt_numbers.Text + btn_n3.Content.ToString();
        }

        private void btn_n4_Click(object sender, RoutedEventArgs e)
        {
            txt_numbers.Text = txt_numbers.Text + btn_n4.Content.ToString();
        }

        private void btn_n5_Click(object sender, RoutedEventArgs e)
        {
            txt_numbers.Text = txt_numbers.Text + btn_n5.Content.ToString();
        }

        private void btn_n6_Click(object sender, RoutedEventArgs e)
        {
            txt_numbers.Text = txt_numbers.Text + btn_n6.Content.ToString();
        }

        private void btn_n7_Click(object sender, RoutedEventArgs e)
        {
            //txt_numbers.Text = txt_numbers.Text + btn_n7.Content.ToString();
            //TextBox focusedTextbox = (TextBox)sender;
            //set_number_textbox(focusedTextbox);
            Button btn_clckd = (Button)sender;
            enter_number_value(btn_clckd);
        }
        private void enter_number_value(Button btn_clckd)
        {
            cr_indx = txt_numbers.CaretIndex;
            //if (cr_indx != txt_numbers.Text.Length)
            //{
            cr_indx = txt_numbers.CaretIndex;
            if (txt_numbers.SelectedText.Length != 0)
            {
                txt_numbers.SelectedText = btn_clckd.Content.ToString();
            }
            else
            {
                txt_numbers.Text = txt_numbers.Text.Insert(txt_numbers.CaretIndex, btn_clckd.Content.ToString());
            }
            txt_numbers.Focus();
            //int startIndex = txt_numbers.Text.IndexOf(btn_n7.Content.ToString());

            txt_numbers.Select(cr_indx + 1, 0);
            //}
            //else
            //{
            //   txt_numbers.Text= txt_numbers.Text + btn_clckd.Content.ToString();

            //}
        }

        private void btn_n8_Click(object sender, RoutedEventArgs e)
        {
            txt_numbers.Text = txt_numbers.Text + btn_n8.Content.ToString();
        }

        private void btn_n9_Click(object sender, RoutedEventArgs e)
        {
            txt_numbers.Text = txt_numbers.Text + btn_n9.Content.ToString();
        }

        private void btn_dot_Click(object sender, RoutedEventArgs e)
        {
            if (!txt_numbers.Text.Contains("."))
            {
                cr_indx = txt_numbers.CaretIndex;
                //if (cr_indx != txt_numbers.Text.Length)
                //{
                cr_indx = txt_numbers.CaretIndex;
                if (txt_numbers.SelectedText.Length != 0)
                {
                    txt_numbers.SelectedText = btn_dot.Content.ToString();
                }
                else
                {
                    txt_numbers.Text = txt_numbers.Text.Insert(txt_numbers.CaretIndex, btn_dot.Content.ToString());
                }
                txt_numbers.Focus();
                //int startIndex = txt_numbers.Text.IndexOf(btn_n7.Content.ToString());

                txt_numbers.Select(cr_indx + 1, 0);

            }

        }

        private void btn_n0_Click(object sender, RoutedEventArgs e)
        {
            txt_numbers.Text = txt_numbers.Text + btn_n0.Content.ToString();
        }

        private void btn_plus_minus_Click(object sender, RoutedEventArgs e)
        {

            string a = txt_numbers.Text.Substring(txt_numbers.Text.Length - 1, 1);

            if (a != "-")
            {
                string valu = txt_numbers.Text;
                valu = valu + "-";
                txt_numbers.Text = valu;

            }
            else if (a == "-")
            {
                string value = txt_numbers.Text.Substring(0, txt_numbers.Text.Length - 1);
                txt_numbers.Text = value;
            }
        }
        #endregion

        private void btn_kb_cancel_Click(object sender, RoutedEventArgs e)
        {
            if (flagge == 7)
            {
                set_number = null;
                this.Close();
            }
            else if (flagge == 8 || flagge == 9 || flagge == 10 || flagge == 17 || flagge == 18 || flagge == 19 || flagge == 20 || flagge == 15 || flagge == 28 || flagge == 32 || flagge == 33 || flagge == 36)
            {
                set_cash_reg_price = null;
                this.Close();
            }
            else if (flagge == 35)
            {
                inv_number = null;
                this.Close();
            }
            else
            {
                name = no_change;
                key_flage_cancel = 1;
                this.Close();
            }
            qty_rec_damg = null;
            line_no = null;
        }
        public string set_name
        {
            get { return name; }
            set { name = value; }
        }
        public string set_invoice_number
        {
            get { return inv_number; }
            set { inv_number = value; }
        }
        public string set_cash_reg_price
        {
            get { return cash_reg_price; }
            set { cash_reg_price = value; }
        }
        public string set_percentage
        {
            get { return percentage; }
            set { percentage = value; }
        }

        public int set_key_flage_cancel
        {
            get { return key_flage_cancel; }
            set { key_flage_cancel = value; }
        }
        public string set_quantity
        {
            get { return quanity; }
            set { quanity = value; }
        }
        public string set_dollor
        {
            get { return dollor; }
            set { dollor = value; }
        }
        public string set_number
        {
            get { return num_value; }
            set { num_value = value; }
        }
        public string set_change_value
        {
            get { return change_value; }
            set { change_value = value; }
        }

        public string set_price
        {
            get { return pricce; }
            set { pricce = value; }
        }
        public string set_value
        {
            get { return Value; }
            set { Value = value; }
        }

        private void btn_kb_enter_Click(object sender, RoutedEventArgs e)
        {
            enter();
        }
        private bool check_num()
        {
            bool valid = true;
            try
            {
                if (txt_numbers.Text.Contains("-"))
                {
                    string replacedString = txt_numbers.Text.Replace("-", "");
                    Convert.ToDouble(replacedString);
                    return valid;
                }
                else
                {
                    Convert.ToDouble(txt_numbers.Text);
                    return valid;
                }
            }
            catch (Exception)
            {
                valid = false;
                return valid;
            }
        }

        private void enter()
        {
            if (check_num() == false)
            {
                MessageBox.Show("Invalid Entry, Please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txt_numbers.Clear();
            }
            else
            if(flagge == 101)
            {
                quanity = txt_numbers.Text;
                this.Close();
            }
            else if(flagge == 102)
            {
                pricce = txt_numbers.Text;
                this.Close();
            }
            else if(flagge == 103)
            {
                Value = txt_numbers.Text;
                this.Close();
            }
            else if (flagge == 104)
            {
                Value = txt_numbers.Text;
                this.Close();
            }
            else if(flagge == 501)
            {
                change_value = txt_numbers.Text;
                this.Close();
            }
            else if (flage == 500)
            {
                globalValue = txt_numbers.Text;
                this.Close();
            }
            else
            {
                name = txt_numbers.Text;
                if (flagge == 1)
                {
                    if (txt_numbers.Text == "")
                    {
                        MessageBox.Show("You Must Enter the Value Or Click Cancel", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                    {
                        if (txt_numbers.Text.Contains("-"))
                        {
                            string replacedString = txt_numbers.Text.Replace("-", "");
                            replacedString = "-" + replacedString;
                            percentage = replacedString;
                            this.Close();
                        }
                        else
                        {
                            percentage = txt_numbers.Text;

                        }
                    }
                    flagge = 0;
                }
                else if (flagge == 2)
                {
                    if (txt_numbers.Text == "")
                    {
                        MessageBox.Show("You Must Enter the Value Or Click Cancel", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                    {
                        if (txt_numbers.Text.Contains("-"))
                        {
                            string replacedString = txt_numbers.Text.Replace("-", "");
                            replacedString = "-" + replacedString;
                            percentage = replacedString;
                            this.Close();
                        }
                        else
                        {
                            percentage = txt_numbers.Text;
                            this.Close();
                        }
                        //frmCalender cal = new frmCalender(1);
                        //cal.ShowDialog();
                    }
                    flagge = 0;
                }
                else if (flagge == 3)
                {
                    if (txt_numbers.Text == "")
                    {
                        MessageBox.Show("You Must Enter the Value Or Click Cancel", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                    {
                        if (txt_numbers.Text.Contains("-"))
                        {
                            string replacedString = txt_numbers.Text.Replace("-", "");
                            replacedString = "-" + replacedString;
                            percentage = replacedString;
                            this.Close();
                        }
                        else
                        {
                            percentage = txt_numbers.Text;
                            this.Close();
                        }
                        //frmCalender cal = new frmCalender(1);
                        //cal.ShowDialog();
                    }
                    flagge = 0;
                }
                else if (flagge == 4)
                {
                    if (txt_numbers.Text == "")
                    {
                        MessageBox.Show("You Must Enter the Value Or Click Cancel", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                    {
                        if (lbl_keypaid.Content.Equals("Enter Quantity"))
                        {
                            quanity = txt_numbers.Text;
                            lbl_keypaid.Content = "How Much would You Like to Charge";
                            txt_numbers.Text = "";
                        }

                        else if (lbl_keypaid.Content.Equals("How Much would You Like to Charge"))
                        {
                            if (txt_numbers.Text.Contains("-"))
                            {
                                string replacedString = txt_numbers.Text.Replace("-", "");
                                replacedString = "-" + replacedString;
                                percentage = replacedString;
                                this.Close();
                            }
                            else
                            {
                                percentage = txt_numbers.Text;
                                this.Close();
                            }
                        }
                    }
                }
                else if (flagge == 5)
                {
                    if (txt_numbers.Text == "")
                    {
                        MessageBox.Show("You Must Enter the Value Or Click Cancel", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                    {
                        if (lbl_keypaid.Content.Equals("Enter Quantity"))
                        {
                            quanity = txt_numbers.Text;
                            lbl_keypaid.Content = "What is the Percentage for This Bulk Rate";
                            txt_numbers.Text = "";
                        }

                        else if (lbl_keypaid.Content.Equals("What is the Percentage for This Bulk Rate"))
                        {
                            if (txt_numbers.Text.Contains("-"))
                            {
                                string replacedString = txt_numbers.Text.Replace("-", "");
                                replacedString = "-" + replacedString;
                                percentage = replacedString;
                                this.Close();
                            }
                            else
                            {
                                percentage = txt_numbers.Text;
                                this.Close();
                            }

                        }
                    }
                }
                else if (flagge == 6)
                {
                    if (txt_numbers.Text == "")
                    {
                        MessageBox.Show("You Must Enter the Value Or Click Cancel", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                    {
                        if (txt_numbers.Text.Contains("-"))
                        {
                            string replacedString = txt_numbers.Text.Replace("-", "");
                            replacedString = "-" + replacedString;
                            percentage = replacedString;
                            this.Close();
                        }
                        else
                        {
                            percentage = txt_numbers.Text;
                            this.Close();
                        }

                    }
                }
                else if (flagge == 7)
                {
                    if (txt_numbers.Text == "")
                    {
                        MessageBox.Show("You Must Enter the Value Or Click Cancel", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                    {
                        if (txt_numbers.Text.Contains("-"))
                        {
                            string replacedString = txt_numbers.Text.Replace("-", "");
                            replacedString = "-" + replacedString;
                            num_value = replacedString;
                            this.Close();
                        }
                        else
                        {
                            num_value = txt_numbers.Text;
                            this.Close();
                        }

                    }
                }
                else if (flagge == 8 || flagge == 9 || flagge == 10 || flagge == 17 || flagge == 18 || flagge == 19 || flagge == 20 || flagge == 15 || flagge == 28 || flagge == 32 || flagge == 33 || flagge == 33)
                {
                    if (txt_numbers.Text == "")
                    {
                        MessageBox.Show("You Must Enter the Value Or Click Cancel", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                    {
                        if (txt_numbers.Text.Contains("-"))
                        {
                            string replacedString = txt_numbers.Text.Replace("-", "");
                            replacedString = "-" + replacedString;
                            cash_reg_price = replacedString;
                            this.Close();
                        }
                        else
                        {
                            cash_reg_price = txt_numbers.Text;
                            this.Close();
                        }
                    }
                }
                else if (flagge == 34)
                {
                    if (txt_numbers.Text == "")
                    {
                        MessageBox.Show("You Must Enter the Value Or Click Cancel", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                    {
                        if (txt_numbers.Text.Contains("-"))
                        {
                            MessageBox.Show("Pickup Amount must be positive.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            txt_numbers.Text = "0.00";
                        }
                        else
                        {
                            if (Convert.ToDouble(txt_numbers.Text) > Convert.ToDouble(curr_cash))
                            {
                                MessageBox.Show("Pickup Amount is greater\n than cashier's cash.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                txt_numbers.Text = "0.00";
                            }
                            else
                            {
                                //if (glo.con.State == ConnectionState.Closed)
                                //{
                                //    glo.con.Open();
                                //}
                                //SqlCommand cmd_update_currcash_employe = new SqlCommand("UPDATE Employee SET Current_Cash = ISNull(Current_Cash,0) + -" + txt_numbers.Text + " WHERE Cashier_ID = '" + cashier_id + "'", glo.con);
                                //cmd_update_currcash_employe.ExecuteNonQuery();
                                //if (glo.con.State == ConnectionState.Open)
                                //{
                                //    glo.con.Close();
                                //}
                                //this.Close();
                                //MessageBox.Show("Amount " + txt_numbers.Text + " picked up by cashier " + cashier_id, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                    }
                }
                else if (flagge == 35)
                {
                    if (txt_numbers.Text.Length == 0)
                    {
                        MessageBox.Show("You Must Enter the Value Or Click Cancel", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        inv_number = txt_numbers.Text;
                        this.Close();
                    }
                }
                else if (flagge == 11)
                {
                    if (lbl_keypaid.Content.Equals("Enter # Received"))
                    {
                        quanity = txt_numbers.Text;
                        lbl_keypaid.Content = "Enter Cost Per";
                        txt_numbers.Text = price;

                    }
                    else if (lbl_keypaid.Content.Equals("Enter Cost Per"))
                    {
                        percentage = txt_numbers.Text;
                        this.Close();
                    }
                }
                else if (lbl_keypaid.Content.Equals("Enter New Value"))
                {
                    string str1 = txt_numbers.Text.ToString();
                    if (str1.Contains('-'))
                    {
                        string[] str2 = str1.Split('-');
                        num_value = "-" + str2[0];
                    }
                    else
                    {
                        num_value = txt_numbers.Text;
                    }
                    this.Close();
                }
                else if (flagge == 12 || flagge == 14)
                {
                    if (txt_numbers.Text == "")
                    {
                        MessageBox.Show("You Must Enter the Value Or Click Cancel", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                    {
                        quanity = txt_numbers.Text;
                        this.Close();
                    }
                }
                else if (flagge == 13)
                {
                    if (txt_numbers.Text == "")
                    {
                        MessageBox.Show("You Must Enter the Value Or Click Cancel", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                    {
                        percentage = txt_numbers.Text;
                        this.Close();
                    }
                }
                else if (flagge == 21 || flagge == 23)
                {
                    line_no = txt_numbers.Text;
                    this.Close();
                }
                else if (flagge == 22 || flagge == 24)
                {
                    qty_rec_damg = txt_numbers.Text;
                    this.Close();
                }
                else if (flagge == 25)
                {
                    change_value = txt_numbers.Text;
                    this.Close();
                }
                else if (flagge == 26)
                {
                    change_value = txt_numbers.Text;
                    this.Close();
                }
                else if (flagge == 30)
                {
                    quanity = txt_numbers.Text;
                    this.Close();
                }
                else if (flagge == 31)
                {
                    pricce = txt_numbers.Text;
                    this.Close();
                }
                else if (lbl_keypaid.Content.Equals("Enter Price"))
                {
                    objInvCustPricesClass.Price = Convert.ToDouble(txt_numbers.Text);
                    this.Close();
                }
                else if (lbl_keypaid.Content.Equals("Enter New Amount"))
                {
                    objInvCustPricesClass.Price = Convert.ToDouble(txt_numbers.Text);
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
            
        }

        public string set_line_no
        {
            get { return line_no; }
            set { line_no = value; }
        }

        public string set_qty_rec_damg
        {
            get { return qty_rec_damg; }
            set { qty_rec_damg = value; }
        }

        private void btn_kb_clear_Click(object sender, RoutedEventArgs e)
        {
            txt_numbers.SelectedText = "";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            set_number = null;
            set_cash_reg_price = null;
            num_value = null;
            txt_numbers.SelectAll();
        }

        private void txt_numbers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                enter();
            }
        }
        private void txt_numbers_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            RegexClass objRegix = new RegexClass();
            objRegix.checkForNumericWithDotDash(e);
        }
    }
}
