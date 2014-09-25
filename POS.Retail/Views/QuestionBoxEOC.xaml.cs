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
    /// Interaction logic for QuestionBoxEOC.xaml
    /// </summary>
    public partial class QuestionBoxEOC : Window
    {
        private static int eaches_cases;
        public QuestionBoxEOC()
        {
            InitializeComponent();
        }
        public int set_eaches_cases
        {
            get { return eaches_cases; }
            set { eaches_cases = value; }
        }

        private void btn_eaches_Click(object sender, RoutedEventArgs e)
        {
            eaches_cases = 0;
            this.Close();
        }

        private void btn_cases_Click(object sender, RoutedEventArgs e)
        {
            eaches_cases = 1;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            eaches_cases = -1;
        }
    }
}
