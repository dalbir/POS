using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for CalenderTimeForm.xaml
    /// </summary>
    public partial class CalenderTimeForm : Window
    {
        DateTime dt;
        bool _dp1HasKeyboardFocus;
        private static DateTime set_date;
        
        private static DateTime dat=System.DateTime.Now;
        private static string hourz = "12";
        private static string minutez = ":00";
        private static string Meridiem = "AM";
        string time_s =" "+ hourz + minutez + ":00"+Meridiem;
        public CalenderTimeForm() //frmCalender_time()
        {
            InitializeComponent();
        }

      

        private void clndr_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            dat =Convert.ToDateTime(clndr.SelectedDate);
            dt = Convert.ToDateTime(dat);
            btn_select_date.Content = "Select  " + dt.ToString("dd-MM-yyyy") + time_s;
            txt_date.Text = dt.ToString("dd/MM/yyyy") + time_s;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            set_the_date = new DateTime();
             dt = DateTime.Now;
             btn_select_date.Content = "Select  " + dt.ToString("dd-MM-yyyy") + time_s;
            txt_date.Text = dt.ToString("dd/MM/yyyy") + time_s;
            //this.Height = System.Windows.SystemParameters.PrimaryScreenHeight-20;
            //this.Width = SystemParameters.WorkArea.Width;
            //this.Height = SystemParameters.WorkArea.Height;
            //this.WindowStartupLocation = WindowStartupLocation.CenterScreen; ;
            this.SizeToContent = System.Windows.SizeToContent.WidthAndHeight;
        }

        private void lbl_select_cdate_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clndr.DisplayDate = DateTime.Today;
            
        }

       
        public DateTime set_the_date
        {
            get { return set_date; }
            set { set_date = value; }
        }
       

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
           
        }
      

        private void btn_select_date_Click(object sender, RoutedEventArgs e)
        {
           

        }

        private void btn_last_year_Click(object sender, RoutedEventArgs e)
        {
            clndr.DisplayDate = clndr.DisplayDate.AddYears(-1);
        }

        private void btn_next_year_Click(object sender, RoutedEventArgs e)
        {
            clndr.DisplayDate = clndr.DisplayDate.AddYears(1);
        }

        private void btn_last_month_Click(object sender, RoutedEventArgs e)
        {
            clndr.DisplayDate = clndr.DisplayDate.AddMonths(-1);
        }

        private void btn_next_month_Click(object sender, RoutedEventArgs e)
        {
            clndr.DisplayDate = clndr.DisplayDate.AddMonths(1);
        }

        private void txt_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (validate_date(txt_date.Text) == false && txt_date.Text.Length > 0)
                {
                    MessageBox.Show("Invalid Date Format, Use MM/dd/yyyy","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                    txt_date.Focus();
                }
                else if (validate_date(txt_date.Text) == true && txt_date.Text.Length > 0)
                {
                    set_date =Convert.ToDateTime(txt_date.Text);
                    this.Close();
                }
            }
        }
        private bool validate_date(string date_valid)
        {
            DateTime dt;
            bool validate_dt = DateTime.TryParseExact(date_valid, "MM/dd/yyyy", null, DateTimeStyles.None, out dt);
            return validate_dt;
        }

        private void btn_0_Click(object sender, RoutedEventArgs e)
        {
            hourz = "12";
            time_s = " " + hourz + minutez + ":00" + Meridiem;
            dt = Convert.ToDateTime(dat);
            btn_select_date.Content = "Select  " + dt.ToString("dd-MM-yyyy") + time_s;
            txt_date.Text = dt.ToString("dd/MM/yyyy") + time_s;
           
        }
        private void select_hour(Button hour_btn)
        {
            hourz = hour_btn.Content.ToString();
            time_s = " " + hourz + minutez + ":00" + Meridiem;
            dt = Convert.ToDateTime(dat);
            btn_select_date.Content = "Select  " + dt.ToString("dd-MM-yyyy") + time_s;
            txt_date.Text = dt.ToString("dd/MM/yyyy") + time_s;
        }

        private void btn_1_Click(object sender, RoutedEventArgs e)
        {
            Button hour_btn = (Button)sender;
            select_hour(hour_btn);
        }

        private void btn_000_Click(object sender, RoutedEventArgs e)
        {
            Button btn_minutes = (Button)sender;
            select_minutes(btn_minutes);
        }
        private void select_minutes(Button btn_minutes)
        {
            minutez = btn_minutes.Content.ToString();
            time_s = " " + hourz + minutez + ":00" + Meridiem;
            dt = Convert.ToDateTime(dat);
            btn_select_date.Content = "Select  " + dt.ToString("dd-MM-yyyy") + time_s;
            txt_date.Text = dt.ToString("dd/MM/yyyy") + time_s;
        }
        private void select_meridiem(Button btn_mer)
        {
            Meridiem = btn_mer.Content.ToString();
            time_s = " " + hourz + minutez + ":00" + Meridiem;
            dt = Convert.ToDateTime(dat);
            btn_select_date.Content = "Select  " + dt.ToString("dd-MM-yyyy") + time_s;
            txt_date.Text = dt.ToString("dd/MM/yyyy") + time_s;
        }
        private void btn_am_Click(object sender, RoutedEventArgs e)
        {
            Button btn_mer = (Button)sender;
            select_meridiem(btn_mer);
               
        }

        private void clndr_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            base.OnPreviewMouseUp(e);
            if (Mouse.Captured is DatePicker || Mouse.Captured is System.Windows.Controls.Primitives.CalendarItem)
            {
                Mouse.Capture(null);
            }
        }
    }
}
