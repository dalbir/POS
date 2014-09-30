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
    /// Interaction logic for TimeForm.xaml
    /// </summary>
    public partial class TimeForm : Window
    {
        string hour = "12";
        string min = "00";
        string am_pm = "AM";
        private static string start_time;
        private static string end_time;
        private string str;
        
       
        public TimeForm() //frmTime()
        {
            InitializeComponent();   
            btn_time_select.Content = "Select " + hour + ":" + min + ":00 " + am_pm;
        }

        public TimeForm(string str)
        {
            InitializeComponent();
            btn_time_select.Content = "Select " + hour + ":" + min + ":00 " + am_pm;
            this.str = str;
        }
        private void fun_time(Button button)
        {
            if (button.Content.Equals("1") || button.Content.Equals("2") || button.Content.Equals("3") || button.Content.Equals("4") || button.Content.Equals("5") || button.Content.Equals("6") || button.Content.Equals("7") || button.Content.Equals("8") || button.Content.Equals("9") || button.Content.Equals("10") || button.Content.Equals("11") || button.Content.Equals("12") )
            {
                hour = button.Name.ToString().Substring(1,button.Name.ToString().Length -1);
                btn_time_select.Content = "Select " + hour + ":" + min + ":00 " + am_pm;

            }
            else if (button.Content.Equals(":00") || button.Content.Equals(":05") || button.Content.Equals(":10") || button.Content.Equals(":15") || button.Content.Equals(":20") || button.Content.Equals(":25") || button.Content.Equals(":30") || button.Content.Equals(":35") || button.Content.Equals(":40") || button.Content.Equals(":45") || button.Content.Equals(":50") || button.Content.Equals(":55")) 
            {
                min = button.Content.ToString().Substring(1, button.Name.ToString().Length - 1);
                btn_time_select.Content = "Select " + hour + ":" + min + ":00 " + am_pm; 
            }
           
        }

        private void h1_Click(object sender, RoutedEventArgs e)
        {
            fun_time(h1);
        }

        private void h2_Click(object sender, RoutedEventArgs e)
        {
            fun_time(h2);
        }

        private void h3_Click(object sender, RoutedEventArgs e)
        {
            fun_time(h3);
        }

        private void h4_Click(object sender, RoutedEventArgs e)
        {
            fun_time(h4);
        }

        private void h5_Click(object sender, RoutedEventArgs e)
        {
            fun_time(h5);
        }

        private void h6_Click(object sender, RoutedEventArgs e)
        {
            fun_time(h6);
        }

        private void h7_Click(object sender, RoutedEventArgs e)
        {
            fun_time(h7);
        }

        private void h8_Click(object sender, RoutedEventArgs e)
        {
            fun_time(h8);
        }

        private void h9_Click(object sender, RoutedEventArgs e)
        {
            fun_time(h9);
        }

        private void h10_Click(object sender, RoutedEventArgs e)
        {
            fun_time(h10);
        }

        private void h11_Click(object sender, RoutedEventArgs e)
        {
            fun_time(h11);
        }

        private void h12_Click(object sender, RoutedEventArgs e)
        {
            fun_time(h12);
        }

        private void m05_Click(object sender, RoutedEventArgs e)
        {
            fun_time(m05);
        }

        private void m10_Click(object sender, RoutedEventArgs e)
        {
            fun_time(m10);
        }

        private void m15_Click(object sender, RoutedEventArgs e)
        {
            fun_time(m15);
        }

        private void m20_Click(object sender, RoutedEventArgs e)
        {
            fun_time(m20);
        }

        private void m25_Click(object sender, RoutedEventArgs e)
        {
            fun_time(m25);
        }

        private void m30_Click(object sender, RoutedEventArgs e)
        {
            fun_time(m30);
        }

        private void m35_Click(object sender, RoutedEventArgs e)
        {
            fun_time(m35);
        }

        private void m40_Click(object sender, RoutedEventArgs e)
        {
            fun_time(m40);
        }

        private void m45_Click(object sender, RoutedEventArgs e)
        {
            fun_time(m45);
        }

        private void m50_Click(object sender, RoutedEventArgs e)
        {
            fun_time(m50);
        }

        private void m55_Click(object sender, RoutedEventArgs e)
        {
            fun_time(m55);
        }

        private void m00_Click(object sender, RoutedEventArgs e)
        {
            fun_time(m00);
        }

        private void btn_plus1_Click(object sender, RoutedEventArgs e)
        {
            int min_plus = Convert.ToInt32(min) + 1;
            if (min_plus > 59)
            {
                min = "00";
                btn_time_select.Content = "Select " + hour + ":" + min + ":00 " + am_pm;
            }
            else
            {
                min = min_plus.ToString();
                btn_time_select.Content = "Select " + hour + ":" + min + ":00 " + am_pm;
            }

        }

        private void btn_am_Click(object sender, RoutedEventArgs e)
        {
            am_pm = "AM";
            btn_time_select.Content = "Select " + hour + ":" + min + ":00 " + am_pm;
        }

        private void btn_pm_Click(object sender, RoutedEventArgs e)
        {
            am_pm = "PM";
            btn_time_select.Content = "Select " + hour + ":" + min + ":00 " + am_pm;
        }

        private void btn_time_select_Click(object sender, RoutedEventArgs e)
        {
            if (lbl_heading_time.Content.Equals("Select Start Time"))
            {
                start_time = hour + ":" + min + ":00" + am_pm;
                hour = "12";
                min = "00";
                am_pm = "AM";
                btn_time_select.Content = "Select " + hour + ":" + min + ":00 " + am_pm;
                lbl_heading_time.Content = "Select End Time";
            }
            else if (lbl_heading_time.Content.Equals("Select End Time"))
            {
                if (str == "Coupon")
                {
                    end_time = hour + ":" + min + ":00" + am_pm;
                    this.Close();
                }
                else
                {
                    end_time = hour + ":" + min + ":00" + am_pm;
                    this.Close();
                    NumberKeypaid kkb = new NumberKeypaid(6);
                    kkb.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                    kkb.ShowDialog();
                }
            }
        }
        public string set_start_time
        {
            get { return start_time; }
            set { start_time = value; }
        }
        public string set_end_time
        {
            get { return end_time; }
            set { end_time = value; }
        }
       

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            start_time = null;
            end_time = null;
        }
    }
}
