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
    /// Interaction logic for CalenderForm.xaml
    /// </summary>
    public partial class CalenderForm : Window
    {
         DateTime dt;
        private static DateTime star_date;
        private static DateTime set_date;
        private static DateTime end_date;
        private static int flage_cancel = 0;
        private int p;
        private string p_2;
        public CalenderForm() //frmCalender()
        {
            InitializeComponent();
        }

        public CalenderForm(int p)
        {
            InitializeComponent();
            this.p = p;
            if (p == 2)
            {
                lbl_heading.Content = "Select Date:" ;
            }
            else if (p == 1)
            {
                lbl_heading.Content = "Enter Start Date";
            }
        }

        public CalenderForm(string p_2)
        {
            InitializeComponent();
            this.p_2 = p_2;
            lbl_heading.Content = p_2;
        }

        private void clndr_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            dt = Convert.ToDateTime(clndr.SelectedDate);
            btn_select_date.Content = "Select  " + dt.ToString("dd-MM-yyyy");
            txt_date.Text =  dt.ToString("dd/MM/yyyy");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            set_the_date = new DateTime();
             dt = DateTime.Now;
            btn_select_date.Content = "Select  " + dt.ToString("dd-MM-yyyy");
            txt_date.Text =  dt.ToString("dd/MM/yyyy");
            lbl_current_date.Content = dt.ToString("dd-MM-yyyy");
            set_end_date = Convert.ToDateTime("01/01/0001");
            set_start_date = Convert.ToDateTime("01/01/0001");
        }

        private void lbl_select_cdate_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clndr.DisplayDate = DateTime.Today;
            
        }

        public DateTime set_start_date
        {
            get { return star_date; }
            set { star_date = value; }
        }
        public DateTime set_the_date
        {
            get { return set_date; }
            set { set_date = value; }
        }
        public DateTime set_end_date
        {
            get { return end_date; }
            set { end_date = value; }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            if (p == 2)
            {
                this.Close();
            }
            else if (p==1)
            {
            flage_cancel = 1;
            this.Close();
            }
        }
        public int set_flage_cancle
        {
            get { return flage_cancel; }
            set { flage_cancel = value; }
        }

        private void btn_select_date_Click(object sender, RoutedEventArgs e)
        {
            if (p == 2)
            {
                set_date =Convert.ToDateTime(clndr.SelectedDate).Date;
                this.Close();
            }
            else if (p == 1)
            {
                if (lbl_heading.Content.Equals("Enter Start Date"))
                {
                    star_date = Convert.ToDateTime(clndr.SelectedDate);
                    lbl_heading.Content = "Enter End Date";
                }

                else if (lbl_heading.Content.Equals("Enter End Date"))
                {
                    end_date = Convert.ToDateTime(clndr.SelectedDate);
                    this.Close();
                    p = 0;
                }
            }
            else if (lbl_heading.Content.Equals("Select Expiration Date"))
            {
                set_date = Convert.ToDateTime(clndr.SelectedDate);
                this.Close();
            }

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
