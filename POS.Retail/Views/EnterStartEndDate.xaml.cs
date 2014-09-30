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
    /// Interaction logic for EnterStartEndDate.xaml
    /// </summary>
    public partial class EnterStartEndDate : Window
    {
        private int p;
        private static string start_date = null;
        private static string end_date = null;

        public EnterStartEndDate()
        {
            InitializeComponent();
        }

        public EnterStartEndDate(int p)
        {
            InitializeComponent();
            this.p = p;
            if (p == 0)
            {
                lbl_heading.Content = "Please Enter The Start Date of The Sale";
                txt_date.Text = DateTime.Today.ToString("MM/dd/yyyy");
            }
            else if (p == 1)
            {
                lbl_heading.Content = "Please Enter The End Date of The Sale";
                txt_date.Text = DateTime.Today.AddDays(7).ToString("MM/dd/yyyy");
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            start_date = null;
            end_date = null;
            this.Close();
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            if (p == 0)
            {
                start_date = txt_date.Text;
                this.Close();
            }
            if (p == 1)
            {
                end_date = txt_date.Text;
                this.Close();
            }
        }
        public string set_start_date
        {
            get { return start_date; }
            set { start_date = value; }
        }
        public string set_end_date
        {
            get { return end_date; }
            set { end_date = value; }
        }
    }
}
