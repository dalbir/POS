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
    /// Interaction logic for DaysOfWeekForm.xaml
    /// </summary>
    public partial class DaysOfWeekForm : Window
    {
        private static  List<int> days = new List<int>();
        private static  List<string> days_name = new List<string>();
        private string str;
        public DaysOfWeekForm() //frmDaysOfWeek()
        {
            InitializeComponent();
        }

        public DaysOfWeekForm(string str)
        {
            InitializeComponent();
            this.str = str;
            if (str == "Coupon")
            {
                lbl_frm_day_heading.Content = "Which Days Would You Like to Activate The Coupon For?";
            }
        }

       
        private void enter_item(Button button)
        {
           

            if (button.Background == Brushes.DeepSkyBlue)
            {
                button.Background = Brushes.WhiteSmoke;
                button.BorderBrush = Brushes.Black;
                string id1 = button.Name.Substring(1, 1);
                int id = Convert.ToInt32(id1);
                string dayname = button.Content.ToString().Substring(0,3);
                days_name.Add(dayname);
                days.Add(id);
            }
            else
            {
                button.Background = Brushes.DeepSkyBlue;
                days.Remove(Convert.ToInt32(button.Name.Substring(1, 1)));
            }
        }
        public List<int> set_days
        {
            get { return days; }
            set { days = value; }
        }

        public List<string> set_days_name
        {
            get { return days_name; }
            set { days_name = value; }
        }
        private void d1_Click(object sender, RoutedEventArgs e)
        {
            enter_item(d1);
        }

        private void d2_Click(object sender, RoutedEventArgs e)
        {
            enter_item(d2);
        }

        private void d3_Click(object sender, RoutedEventArgs e)
        {
            enter_item(d3);
        }

        private void d4_Click(object sender, RoutedEventArgs e)
        {
            enter_item(d4);
        }

        private void d5_Click(object sender, RoutedEventArgs e)
        {
            enter_item(d5);
        }

        private void d6_Click(object sender, RoutedEventArgs e)
        {
            enter_item(d6);
        }

        private void d7_Click(object sender, RoutedEventArgs e)
        {
            enter_item(d7);
        }

        private void btn_select_days_Click(object sender, RoutedEventArgs e)
        {
            if (str == "Coupon")
            {
                TimeForm time1 = new TimeForm(str);
                this.Close();
                time1.ShowDialog();
            }
            else
            {
                TimeForm time = new TimeForm();
                this.Close();
                time.ShowDialog();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            days.Clear();
            days_name.Clear();
        }

        private void btn_cancel_days_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
