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
    /// Interaction logic for TypeofRuleCoupon.xaml
    /// </summary>
    public partial class TypeofRuleCoupon : Window
    {
       
        private static string rul_type_flage = null;
        public TypeofRuleCoupon()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            rul_type_flage = null;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rul_type_flage = null;
        }

        private void btn_rule_item_Click(object sender, RoutedEventArgs e)
        {
            rul_type_flage = "Item";
            SearchInventoryForm selctitem = new SearchInventoryForm();
            selctitem.ShowDialog();
            this.Close();
        }

        private void btn_rule_depat_Click(object sender, RoutedEventArgs e)
        {
            rul_type_flage = "Department";
            SelectDepartCoponForm frmDepCopon = new SelectDepartCoponForm();
            frmDepCopon.ShowDialog();
            this.Close();
        }
        public string set_rul_type_flage
        {
            get { return rul_type_flage; }
            set { rul_type_flage = value; }
        }

        private void btn_rule_category_Click(object sender, RoutedEventArgs e)
        {
            rul_type_flage = "Category";
            CategorySelectForm cat = new CategorySelectForm();
            cat.ShowDialog();
            this.Close();
        }
    }
}
