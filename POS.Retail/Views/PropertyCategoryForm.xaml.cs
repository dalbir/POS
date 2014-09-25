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
    /// Interaction logic for PropertyCategoryForm.xaml
    /// </summary>
    public partial class PropertyCategoryForm : Window
    {
        //GlobalClass glo = new GlobalClass();
        private static string property_id;
        private static string value_id;
        int flage = 0;
        string btn_name_id;
        public PropertyCategoryForm() //frmPropertycategory()
        {
            InitializeComponent();
        }
        private void fun_properties()
        {
            
            if (flage == 0)
            {
                //string qury = "select Property_ID, [Description] from Properties";
                //glo.fun_search(qury);
            }
            else if (flage == 1)
            {
                wp_modifier_btn.Children.Clear();
                //string qury = "select Value_ID, Description from Property_Values where Property_ID = '"+ property_id +"'";
                //glo.fun_search(qury);
            }
            //while (glo.dr.Read())
            //{
            //    Button btn = new Button();
            //    if (flage == 0)
            //    {
            //        btn.Content = glo.dr["Description"].ToString();
            //        btn_name_id = glo.dr["Property_ID"].ToString();
            //    }
            //    else if (flage == 1)
            //    {
            //        btn.Content = glo.dr["Description"].ToString();
            //        btn_name_id = glo.dr["Value_ID"].ToString();
            //    }
            //    btn.Name = "a" + btn_name_id;
            //    btn.Height = 70;
            //    btn.Width = 90;
            //    btn.FontSize = 14;

            //    wp_modifier_btn.Children.Add(btn);
            //    btn.Click += new RoutedEventHandler(enter_item);
            //}
            //glo.dr.Close();
        }
        private void enter_item(object sender, EventArgs e)
        {
           
            Button button = sender as Button;
            string id = button.Name.Substring(1, button.Name.Length - 1);
            if (flage == 0)
            {
                property_id = id;
                flage = 1;
                fun_properties();
            }
            else if (flage == 1)
            {
                value_id = id;
                this.Close();
            }
        }
        public string set_property_id
        {
            get { return property_id; }
            set { property_id = value; }
        }
        public string set_value_id
        {
            get { return value_id; }
            set { value_id = value; }
        }

        private void btn_select_property_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            property_id = null;
            value_id = null;
            flage = 0;
            fun_properties();
        }
    }
}
