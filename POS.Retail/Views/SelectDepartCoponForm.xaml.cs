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
    /// Interaction logic for SelectDepartCoponForm.xaml
    /// </summary>
    public partial class SelectDepartCoponForm : Window
    {
      // GlobalClass glo = new GlobalClass();
        private static List<string> listDeptid = new List<string>();
        private static List<string> listDeptName = new List<string>();
        public SelectDepartCoponForm() //frmSelectDepartCopon()
        {
            InitializeComponent();
        }
        private void fun_department_btn()
        {
            string btn_name_id;
            string qury = "select Dept_ID, Description from Departments";
            //glo.fun_search(qury);
            //while (glo.dr.Read())
            //{
            //    Button btn = new Button();
            //    btn.Content = glo.dr["Description"].ToString();
            //    btn_name_id = glo.dr["Dept_ID"].ToString();
            //    btn.Name = "d" + btn_name_id;
            //    btn.Height = 70;
            //    btn.Width = 90;

            //    wp_modifier_btn.Children.Add(btn);
            //    btn.Click += new RoutedEventHandler(enter_item);
            //}
            //glo.dr.Close();
        }

        public List<string> set_listDeptID
        {
            get { return listDeptid; }
            set { listDeptid = value; }
        }

        public List<string> set_lsitDeptName
        {
            get { return listDeptName; }
            set { listDeptName = value; }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fun_department_btn();
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
                listDeptName.Add(dept_name);
                listDeptid.Add(id);
            }
            else
            {
                button.Background = Brushes.DeepSkyBlue;
                listDeptid.Remove(button.Name.Substring(1, button.Name.Length - 1));
                listDeptName.Remove(button.Content.ToString());
            }
        }

        private void btn_cancel_dept_Click(object sender, RoutedEventArgs e)
        {
            listDeptid.Clear();
            listDeptName.Clear();
            this.Close();
        }

        private void btn_select_dept_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
