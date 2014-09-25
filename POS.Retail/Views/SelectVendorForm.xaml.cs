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
using POS.Domain.Common;
using POS.Services.Common;

namespace POS.Retail
{
    /// <summary>
    /// Interaction logic for SelectVendorForm.xaml
    /// </summary>
    public partial class SelectVendorForm : Window
    {
      
        private static string vid = null;
        private static string ven_id = null;
        public SelectVendorForm() //frm_select_vendor()
        {
            InitializeComponent();
        }
            private void fun_vendor_btn()
        {
            POSManagementService managmentService = new POSManagementService();
            VendorsClass objVendor = new VendorsClass();
            managmentService.RetriveVendor(objVendor);
            string btn_name_id;    
            //string qury = "select Vendor_Number, First_Name + ' ' + Last_Name as Vendor_name from Vendors";
            //glo.fun_search(qury);
                for(int i = 0; i< objVendor.dtVendor.Rows.Count; i++)
                {
                    Button btn = new Button();
                    btn.Content = objVendor.dtVendor.Rows[i]["Vendor_name"].ToString();
                    btn_name_id = objVendor.dtVendor.Rows[i]["Vendor_Number"].ToString();
                    btn.Name = "a" + btn_name_id;
                    btn.Height = 70;
                    btn.Width = 90;

                    wp_modifier_btn.Children.Add(btn);
                    btn.Click += new RoutedEventHandler(enter_item);
                }
            //while (glo.dr.Read())
            //{
            //    Button btn = new Button();
            //    btn.Content = glo.dr["Vendor_name"].ToString();
            //    btn_name_id = glo.dr["Vendor_Number"].ToString();
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
            fun_vendor_btn();
            
        }
        private void enter_item(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string lbl_str = "Enter The Vendor Part Number";
            string sid = button.Name.Substring(1, button.Name.Length - 1);
            vid = sid;
            ven_id = button.Content.ToString();
            Keyboard kkb = new Keyboard(lbl_str);
            kkb.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            kkb.ShowDialog();
            this.Close();
        }
        public string set_vid
        {
            get { return vid; }
            set { vid = value; }
        }
        public string set_ven_id
        {
            get { return ven_id; }
            set { ven_id = value; }
        }

        private void btn_select_mitems_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_cancel_modifier_Click(object sender, RoutedEventArgs e)
        {
            vid = null;
            this.Close();
        }
    }
}
