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
    /// Interaction logic for SelectItemTypesForm.xaml
    /// </summary>
    public partial class SelectItemTypesForm : Window
    {
        private static string item_type_flage = null;
        public SelectItemTypesForm() //Select_Item_Types()
        {
            InitializeComponent();
        }
        public string set_item_flage
        {
            get { return item_type_flage; }
            set { item_type_flage = value; }
        }

        private void btn_standard_item_Click(object sender, RoutedEventArgs e)
        {
            item_type_flage = "Standard";
            this.Close();
        }

        private void btn_kit_Click(object sender, RoutedEventArgs e)
        {
            item_type_flage = "Kit";
            this.Close();
        }

        private void btn_choice_item_Click(object sender, RoutedEventArgs e)
        {
            item_type_flage = "Choice";
            this.Close();
        }

        private void btn_modifier_Click(object sender, RoutedEventArgs e)
        {
            item_type_flage = "modifier";
            this.Close();
        }

        private void btn_coupon_Click(object sender, RoutedEventArgs e)
        {
            item_type_flage = "coupon";
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            set_item_flage = null;
        }
    }
}
