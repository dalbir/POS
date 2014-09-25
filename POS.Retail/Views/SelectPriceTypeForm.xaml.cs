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
    /// Interaction logic for SelectPriceTypeForm.xaml
    /// </summary>
    public partial class SelectPriceTypeForm : Window
    {
         private static int price_type = -1;
        private int flage = -1;
        public SelectPriceTypeForm() //frmSelectPriceType()
        {
            InitializeComponent();
        }

        public SelectPriceTypeForm(int flage)
        {
            InitializeComponent();
            this.flage = flage;
            if (flage == 2)
            {
                lbl_heading.Content = "Which Type of Sale Price?";  
            }
            else if (flage == 1)
            {
                lbl_heading.Content = "Which Type of Bulk Price?";
            }           
        }

        private void btn_per_off_Click(object sender, RoutedEventArgs e)
        {
            if (flage == 2)
            {
                price_type = 1;
                int lbl = 2;
                NumberKeypaid nk = new NumberKeypaid(lbl);
                this.Close();
                nk.ShowDialog();
                flage = -1;
            }
            else if (flage == 1)
            {
                price_type = 1;
                int lbl = 4;
                NumberKeypaid nk = new NumberKeypaid(lbl);
                this.Close();
                nk.ShowDialog();
                flage = -1;
            }            
        }

        private void btn_sale_price_Click(object sender, RoutedEventArgs e)
        {
            if (flage == 2)
            {
                price_type = 0;
                int lbl = 3;
                NumberKeypaid nk = new NumberKeypaid(lbl);
                this.Close();
                nk.ShowDialog();
            }
            if (flage == 1)
            {
                price_type = 0;
                int lbl = 5;
                NumberKeypaid nkk = new NumberKeypaid(lbl);
                this.Close();
                nkk.ShowDialog();
            }
           
        }
        public int set_price_type
        {
            get { return price_type; }
            set { price_type = value; }
        }
    }
}
