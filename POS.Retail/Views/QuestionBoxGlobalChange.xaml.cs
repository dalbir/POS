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
    /// Interaction logic for QuestionBoxGlobalChange.xaml
    /// </summary>
    public partial class QuestionBoxGlobalChange : Window
    {
        private int p;
        private static int cancel_falge = 0;

        public QuestionBoxGlobalChange()
        {
            InitializeComponent();
        }

        public QuestionBoxGlobalChange(int p)
        {
            InitializeComponent();
            this.p = p;
            if (p == 0 || p == 1)
            {
                lbl_heading.Content = "This Will Apply for All of the Selected Items for\n the Store, Are You Sure You'd Like to Do This?";
            }
            if (p == 2)
            {
                lbl_heading.Content = "This Will Apply For All The Selected Items For The Sore, Are You Sure You'd Like to Do This?";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cancel_falge = 0;
        }

        private void btn_no_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            cancel_falge = 0;
        }

        private void btn_yes_Click(object sender, RoutedEventArgs e)
        {
            cancel_falge = 1;
            this.Close();
        }
        public int set_cancel_flage
        {
            get { return cancel_falge; }
            set { cancel_falge = value; }
        }
    }
}
