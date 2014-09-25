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
    /// Interaction logic for CreditCardTransFrm.xaml
    /// </summary>
    public partial class CreditCardTransFrm : Window
    {
       //Regex_class regclass = new Regex_class();
        private static string cc_type = null;
        private static string cc_number = null;
        private static string cc_trimmed_num = null;
        private static string expiry = null;
        private static string ref_code = null;
        private static string approv_code = null;
        public CreditCardTransFrm()
        {
            InitializeComponent();
        }
        public string set_cc_type
        {
            get { return cc_type; }
            set { cc_type = value; }
        }
        public string set_cc_number
        {
            get { return cc_number; }
            set { cc_number = value; }
        }
        public string set_cc_trimmed_num
        {
            get { return cc_trimmed_num; }
            set { cc_trimmed_num = value; }
        }
        public string set_expiry
        {
            get { return expiry; }
            set { expiry = value; }
        }
        public string set_ref_code
        {
            get { return ref_code; }
            set { ref_code = value; }
        }
        public string set_approv_code
        {
            get { return approv_code; }
            set { approv_code = value; }
        }
        private void btn_cc_num_Click(object sender, RoutedEventArgs e)
        {
            //NumberKeypaid num_paid = new NumberKeypaid(13);
            //num_paid.ShowDialog();
            //if (num_paid.set_cash_reg_price != null)
            //{
            //    pwd_cc_num.Password = num_paid.set_cash_reg_price;
            //}
        }

        private void btn_approval_code_Click(object sender, RoutedEventArgs e)
        {
            //Keyboard kb_frm = new Keyboard("Enter Approval Code");
            //kb_frm.ShowDialog();
            //if (kb_frm.set_decrep != null)
            //{
            //    txt_approval_code.Text = kb_frm.set_decrep;
            //}
            
        }
        private void btn_exp_month_Click(object sender, RoutedEventArgs e)
        {
        top:
            { }
            //NumberKeypaid num_paid = new NumberKeypaid(14);
            //num_paid.ShowDialog();
            //if (num_paid.set_cash_reg_price != null)
            //{
            //    string mont = num_paid.set_cash_reg_price;
            //    if(mont.Contains("."))
            //    {
            //        string[] mnt = mont.Split('.');
            //         mont = mnt[0].ToString();
            //    }
            //    if (mont.Contains("-"))
            //    {
            //        mont = mont.Replace("-", "");
            //    }
            //    if (mont.Length == 1)
            //    {
            //        txt_exp_month.Text = "0" + mont;
            //    }
            //    else if (mont.Length > 1 && mont.Length < 8)
            //    {
            //        string mnth = mont;
            //        txt_exp_month.Text = mnth.Substring(mnth.Length - 2, 2);
            //    }
            //    else
            //    {
            //        MessageBox.Show("The Value you entered is too high, Please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
            //        goto top;
            //    }
            //}
        }

        private void btn_exp_year_Click(object sender, RoutedEventArgs e)
        {
        //top1:
        //    { }
        //    NumberKeypaid num_paid = new NumberKeypaid(15);
        //    num_paid.ShowDialog();
        //    if (num_paid.set_cash_reg_price != null)
        //    {
        //        string mont = num_paid.set_cash_reg_price;
        //        if (mont.Contains("."))
        //        {
        //            string[] mnt = mont.Split('.');
        //            mont = mnt[0].ToString();
        //        }
        //        if (mont.Contains("-"))
        //        {
        //            mont = mont.Replace("-", "");
        //        }
        //        if (mont.Length == 1)
        //        {
        //            txt_exp_year.Text = "0" + mont;
        //        }
        //        else if (mont.Length > 1 && mont.Length < 8)
        //        {
        //            string yr = mont;
        //            txt_exp_year.Text = yr.Substring(yr.Length - 2, 2);
        //        }
        //        else
        //        {
        //            MessageBox.Show("The Value you entered is too high, Please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
        //            goto top1;
        //        }
        //    }
        }

        private void btn_reference_code_Click(object sender, RoutedEventArgs e)
        {
            //Keyboard kb_frm = new Keyboard("Enter Reference Code");
            //kb_frm.ShowDialog();
            //if (kb_frm.set_decrep != null)
            //{
            //    txt_reference_code.Text = kb_frm.set_decrep;
            //}
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            //string today_date = System.DateTime.Now.Day.ToString();
            //string mnth = System.DateTime.Now.Month.ToString();
            //string yrs = System.DateTime.Now.Year.ToString();
            //string year = yrs.Substring(yrs.Length - 2, 2 );
            //string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            //string input_mnth = null;
            //string input_yr = null;
            //if (cmb_creditcard_type.SelectedItem == null || pwd_cc_num.Password.Length == 0)
            //{
            //    MessageBox.Show("Invalid cardnumber", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            ////MessageBox.Show(today_date.ToString() + " " + mnth.ToString() + " " + yrs.ToString()+" "+sysFormat);
            //else if ((GetCardType(pwd_cc_num.Password).ToString() != cmb_creditcard_type.SelectedItem.ToString() || IsCardNumberValid(NormalizeCardNumber(pwd_cc_num.Password)) == false))
            //{
            //    MessageBox.Show("In valid","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            //}
            //else if (txt_exp_month.Text.Length == 0)
            //{
            //    MessageBox.Show("Invalid Month", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            //else if ( txt_exp_month.Text.Contains(".") || Convert.ToDouble(txt_exp_month.Text) > 12)
            //{
            //    MessageBox.Show("Invalid Month", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            ////else if (txt_exp_month.Text.Length != 0 || !txt_exp_month.Text.Contains(".") || Convert.ToDouble(txt_exp_month.Text) <= 12)
            ////{
            ////    
            ////}
            //else if (txt_exp_year.Text.Length == 0)
            //{
            //    MessageBox.Show("Invalid Year", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            //else if (txt_exp_year.Text.Contains("."))
            //{
            //    MessageBox.Show("Invalid Year", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            //else if (txt_approval_code.Text.Length==0)
            //{
            //    MessageBox.Show("Please Enter approval code", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            //else if (txt_reference_code.Text.Length == 0)
            //{
            //    MessageBox.Show("Please Enter reference code", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            //else
            //{
            //    input_yr = txt_exp_year.Text;
            //    input_mnth = txt_exp_month.Text;
            //    string input_date1 = sysFormat.Replace("M", txt_exp_month.Text);
            //    string input_date2 = input_date1.Replace("d", today_date);
            //    string input_date3 = input_date2.Replace("yyyy", txt_exp_year.Text);
            //    if (Convert.ToDateTime(input_date3) < System.DateTime.Now.Date)
            //    {
            //        MessageBox.Show("Expired Date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //    else
            //    {
            //        clsCrypto aes = new clsCrypto();
            //        aes.IV = "POS";     // your IV
            //        aes.KEY = "precise key";    // your KEY      
            //        cc_number = aes.Encrypt(pwd_cc_num.Password, CipherMode.CBC);    // your cipher mode
            //        cc_trimmed_num = pwd_cc_num.Password.Substring(0, 1) + "****" + pwd_cc_num.Password.Substring(pwd_cc_num.Password.Length - 4, 4);
            //        expiry = txt_exp_month.Text + txt_exp_year.Text;
            //        ref_code = txt_reference_code.Text;
            //        approv_code = txt_approval_code.Text;
            //        cc_type = cmb_creditcard_type.SelectedItem.ToString();
            //        this.Close();
            //    }
            //    //if (sysFormat == "M/d/yyyy")
            //    //{
            //    //    DateTime dt= Convert.ToDateTime(txt_exp_month.Text+"/"+today_date+"/"+txt_exp_year.Text);

            //    //}
            //    // else if (sysFormat == "M/d/yyyy")
            //    //{
            //}
           
        }
        ////private static bool IsValidNumber(string number)
        ////{
        ////    try
        ////    {
        ////        int[] DELTAS = new int[] { 0, 1, 2, 3, 4, -4, -3, -2, -1, 0 };
        ////        int checksum = 0;
        ////        char[] chars = number.ToCharArray();
        ////        for (int i = chars.Length - 1; i > -1; i--)
        ////        {
        ////            int j = ((int)chars[i]) - 48;
        ////            checksum += j;
        ////            if (((i - chars.Length) % 2) == 0)
        ////                checksum += DELTAS[j];
        ////        }

        ////        return ((checksum % 10) == 0);
        ////    }
        ////    catch (Exception )
        ////    {
        ////        return false;
        ////    }
        ////}
        public static bool IsCardNumberValid(string cardNumber)
        {
            int i, checkSum = 0;

            // Compute checksum of every other digit starting from right-most digit
            for (i = cardNumber.Length - 1; i >= 0; i -= 2)
                checkSum += (cardNumber[i] - '0');

            // Now take digits not included in first checksum, multiple by two,
            // and compute checksum of resulting digits
            for (i = cardNumber.Length - 2; i >= 0; i -= 2)
            {
                int val = ((cardNumber[i] - '0') * 2);
                while (val > 0)
                {
                    checkSum += (val % 10);
                    val /= 10;
                }
            }

            // Number is valid if sum of both checksums MOD 10 equals 0
            return ((checkSum % 10) == 0);
        }
        public static string NormalizeCardNumber(string cardNumber)
        {
            if (cardNumber == null)
                cardNumber = String.Empty;

            StringBuilder sb = new StringBuilder();

            foreach (char c in cardNumber)
            {
                if (Char.IsDigit(c))
                    sb.Append(c);
            }

            return sb.ToString();
        }
        public enum CardType
        {
            Unknown = 0,
            MasterCard = 1,
            VISA = 2,
            Amex = 3,
            Discover = 4,
            DinersClub = 5,
            JCB = 6,
            enRoute = 7
        }

        // Class to hold credit card type information
        private class CardTypeInfo
        {
            public CardTypeInfo(string regEx, int length, CardType type)
            {
                RegEx = regEx;
                Length = length;
                Type = type;
            }

            public string RegEx { get; set; }
            public int Length { get; set; }
            public CardType Type { get; set; }
        }

        // Array of CardTypeInfo objects.
        // Used by GetCardType() to identify credit card types.
        private static CardTypeInfo[] _cardTypeInfo =
{
  new CardTypeInfo("^(51|52|53|54|55)", 16, CardType.MasterCard),
  new CardTypeInfo("^(4)", 16, CardType.VISA),
  new CardTypeInfo("^(4)", 13, CardType.VISA),
  new CardTypeInfo("^(34|37)", 15, CardType.Amex),
  new CardTypeInfo("^(6011)", 16, CardType.Discover),
  new CardTypeInfo("^(300|301|302|303|304|305|36|38)", 
                   14, CardType.DinersClub),
  new CardTypeInfo("^(3)", 16, CardType.JCB),
  new CardTypeInfo("^(2131|1800)", 15, CardType.JCB),
  new CardTypeInfo("^(2014|2149)", 15, CardType.enRoute),
};

        //public static CardType GetCardType(string cardNumber)
        //{
        //    foreach (CardTypeInfo info in _cardTypeInfo)
        //    {
        //        if (cardNumber.Length == info.Length &&
        //            Regex.IsMatch(cardNumber, info.RegEx))
        //            return info.Type;
        //    }

        //    return CardType.Unknown;
        //}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //cmb_creditcard_type.Items.Add("Unknown");
            cmb_creditcard_type.Items.Add("MasterCard");
            cmb_creditcard_type.Items.Add("VISA");
            cmb_creditcard_type.Items.Add("Amex");
            cmb_creditcard_type.Items.Add("Discover");
            cmb_creditcard_type.Items.Add("DinersClub");
            cmb_creditcard_type.Items.Add("JCB");
            cmb_creditcard_type.Items.Add("enRoute");
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txt_exp_month_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //regclass.checkForNumericWithDotDash(e);
        }

        private void txt_exp_month_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox focusedTextbox = (TextBox)sender;
            if (focusedTextbox.Text.Length > 0)
            {

                correct_input(focusedTextbox.Text, focusedTextbox);
            }
        }
        private void correct_input(string txt,TextBox txtbox)
        {
            string mont = txt;
            if (mont.Contains("."))
            {
                string[] mnt = mont.Split('.');
                mont = mnt[0].ToString();
            }
            if (mont.Contains("-"))
            {
                mont = mont.Replace("-", "");
            }
            if (mont.Length == 1)
            {
                txtbox.Text = "0" + mont;
            }
           
        }
    }
}
