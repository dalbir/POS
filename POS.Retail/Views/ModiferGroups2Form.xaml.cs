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
    /// Interaction logic for ModiferGroups2Form.xaml
    /// </summary>
    public partial class ModiferGroups2Form : Window
    {
        private static string id = null;
       // GlobalClass glo = new GlobalClass();

        public ModiferGroups2Form() //frm_modifer_groups2()
        {
            InitializeComponent();
        }
             private void fun_modifier_btn()
        {
            //string btn_name_id;
            //string qury = "select ItemNum,ItemName from Inventory where ItemType = 4";
            //glo.fun_search(qury);
            //while (glo.dr.Read())
            //{
            //    Button btn = new Button();
            //    btn.Content = glo.dr["ItemName"].ToString();
            //    btn_name_id = glo.dr["ItemNum"].ToString();
            //    btn.Name = "a" + btn_name_id;
            //    btn.Height = 70;
            //    btn.Width = 90;
             
            //    wp_modifier_btn.Children.Add(btn);
            //    btn.Click+=new RoutedEventHandler(enter_item);
            //}
            //glo.dr.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fun_modifier_btn();
            
        }
        private void enter_item(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string sid = button.Name.Substring(1, button.Name.Length - 1);
            id = sid;
            MGQbChargeForm charge_yesno = new MGQbChargeForm();
            charge_yesno.ShowDialog();
            this.Close();
        }
        public string set_id
        {
            get { return id; }
            set { id = value; }
        }
     
        private void btn_cancel_modifier_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
