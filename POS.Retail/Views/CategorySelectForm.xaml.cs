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
using POS.Services.Common;
using POS.Domain.Common;

namespace POS.Retail
{
    /// <summary>
    /// Interaction logic for CategorySelectForm.xaml
    /// </summary>
    public partial class CategorySelectForm : Window
    {
        private static List<string> listCatID = new List<string>();
        private static List<string> listCattName = new List<string>();
        public CategorySelectForm() //frmCategorySelect()
        {
            InitializeComponent();
        }
        private void fun_category_btn()
        {
            try
            {
                CategoriesClass objCategory = new CategoriesClass();
                objCategory.flage = "comboFill";
                POSManagementService mangmentService = new POSManagementService();
                mangmentService.LoadCategoryInfo(objCategory);
                if (objCategory.loadCategory.Rows.Count > 0)
                {
                    string btn_name_id;          
                    for (int i = 0; i < objCategory.loadCategory.Rows.Count; i++)
                    {
                        Button btn = new Button();
                        btn_name_id = objCategory.loadCategory.Rows[i]["Cat_ID"].ToString();
                        btn.Content = objCategory.loadCategory.Rows[i]["Description"].ToString();
                        btn.Name = "c" + btn_name_id;
                        btn.Height = 70;
                        btn.Width = 9;
                        wp_modifier_btn.Children.Add(btn);
                        btn.Click += new RoutedEventHandler(enter_item);
                    }
                }
            }
            catch(Exception ex)
            { }
        }

        public List<string> set_listCatID
        {
            get { return listCatID; }
            set { listCatID = value; }
        }

        public List<string> set_lsitCattName
        {
            get { return listCattName; }
            set { listCattName = value; }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listCatID.Clear();
            listCattName.Clear();
           fun_category_btn();
        }

        private void enter_item(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button.Background == Brushes.DeepSkyBlue)
            {
                button.Background = Brushes.WhiteSmoke;
                button.BorderBrush = Brushes.Black;
                string id = button.Name.Substring(1, button.Name.Length - 1);
                string dept_name = button.Content.ToString();
                listCattName.Add(dept_name);
                listCatID.Add(id);
            }
            else
            {
                button.Background = Brushes.DeepSkyBlue;
                listCatID.Remove(button.Name.Substring(1, button.Name.Length - 1));
                listCattName.Remove(button.Content.ToString());
            }
        }

        private void btn_select_category_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void btn_cancel_category_Click(object sender, RoutedEventArgs e)
        {
            listCatID.Clear();
            listCattName.Clear();
            this.Close();
        }
    }
}
