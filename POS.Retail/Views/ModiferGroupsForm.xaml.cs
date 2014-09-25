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
using POS.Domain.Base;
using POS.Services.Common;
using System.Data;

namespace POS.Retail
{
    /// <summary>
    /// Interaction logic for ModiferGroupsForm.xaml
    /// </summary>
    public partial class ModiferGroupsForm : Window
    {
        public List<string> mst = new List<string>();
        public ModiferGroupsForm() // frm_modifer_groups()
        {
            InitializeComponent();
        }
        string btn_name_id;
        private void fun_modifier_btn()
        {
           
            POSManagementService objManagmentService = new POSManagementService();
            DataTable dtModifiers = objManagmentService.getModifiers();
            if(dtModifiers.Rows.Count > 0)
            {
                for(int i=0; i<dtModifiers.Rows.Count; i++)
                {
                    Button btn = new Button();
                    btn.Content = dtModifiers.Rows[i]["ItemName"].ToString();
                    btn.Content = dtModifiers.Rows[i]["ItemNum"].ToString();
                    btn.Name = "a" + btn_name_id;
                    btn.Height = 70;
                    btn.Width = 90;
                    wp_modifier_btn.Children.Add(btn);
                    btn.Click += new RoutedEventHandler(enter_item);
                }
            }
            //string qury = "select ItemNum,ItemName from Inventory where IsModifier = 1";
        //    glo.fun_search(qury);
        //    while (glo.dr.Read())
        //    {
        //        Button btn = new Button();
        //        btn.Content = glo.dr["ItemName"].ToString();
        //        btn_name_id = glo.dr["ItemNum"].ToString();
        //        btn.Name = "a" + btn_name_id;
        //        btn.Height = 70;
        //        btn.Width = 90;
             
        //        wp_modifier_btn.Children.Add(btn);
        //        btn.Click+=new RoutedEventHandler(enter_item);
        //    }
        //    glo.dr.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fun_modifier_btn();
            
        }
        private void enter_item(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button.Background == Brushes.DeepSkyBlue)
            {
                button.Background = Brushes.WhiteSmoke;
                button.BorderBrush = Brushes.Black;
                string id = button.Name.Substring(1,button.Name.Length -1);
                mst.Add(id);
            }
            else
            {
                button.Background = Brushes.DeepSkyBlue;
                mst.Remove(button.Name.Substring(1, button.Name.Length - 1));
            }
        }

        private void btn_select_mitems_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_cancel_modifier_Click(object sender, RoutedEventArgs e)
        {
            mst.Clear();
            this.Close();
        }
    }
}
