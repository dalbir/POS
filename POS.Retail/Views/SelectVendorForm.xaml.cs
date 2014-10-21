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
using System.Data;

namespace POS.Retail
{
    /// <summary>
    /// Interaction logic for SelectVendorForm.xaml
    /// </summary>
    public partial class SelectVendorForm : Window
    {
      
        private static string vid = null;
        private static string ven_id = null;
        private int jobcode;
        public static string jobCodeId = null;
        private DataTable dtJobCodes;
        private int p;
        public SelectVendorForm() //frm_select_vendor()
        {
            InitializeComponent();
        }

        public SelectVendorForm(int jobcode)
        {
            InitializeComponent();
            this.jobcode = jobcode;
        }

        public SelectVendorForm(DataTable dt)
        {
            InitializeComponent();
            this.dtJobCodes = dt;
        }

        public SelectVendorForm(DataTable dtJobCodes, int p)
        {
            InitializeComponent();
            this.dtJobCodes = dtJobCodes;
            this.p = p;
        }
        private void fun_vendor_btn()
        {
            POSManagementService managmentService = new POSManagementService();
            VendorsClass objVendor = new VendorsClass();
            managmentService.RetriveVendor(objVendor);
            string btn_name_id;    
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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (jobcode == 1)
            {
                POSManagementService managmentService = new POSManagementService();
                JobCodeClass objVendor = new JobCodeClass();
                DataTable dt = managmentService.getJobCodes();
                string btn_name_id;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Button btn = new Button();
                    btn.Content = dt.Rows[i]["JobCodeName"].ToString();
                    btn_name_id = dt.Rows[i]["JobCodeID"].ToString();
                    btn.Name = "a" + btn_name_id;
                    btn.Height = 70;
                    btn.Width = 90;

                    wp_modifier_btn.Children.Add(btn);
                    btn.Click += new RoutedEventHandler(enter_item);
                }
            }
                else if(p == 2)
            {
                string btn_name_id;
                for (int i = 0; i < dtJobCodes.Rows.Count; i++)
                {
                    Button btn = new Button();
                    btn.Content = dtJobCodes.Rows[i]["JobCodeName"].ToString();
                    btn_name_id = dtJobCodes.Rows[i]["JobCodeID"].ToString();
                    btn.Name = "a" + btn_name_id;
                    btn.Height = 70;
                    btn.Width = 90;

                    wp_modifier_btn.Children.Add(btn);
                    btn.Click += new RoutedEventHandler(enter_item);
                }
            }
            else
            {
                fun_vendor_btn();
            }
            
        }
        private void enter_item(object sender, EventArgs e)
        {
            if (jobcode == 1 || p == 2)
            {
                Button button = sender as Button;
                string sid = button.Name.Substring(1, button.Name.Length - 1);
                jobCodeId = sid;
                this.Close();
            }
            else
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
        public string set_jobCodeId
        {
            get { return jobCodeId; }
            set { jobCodeId = value; }
        }

        private void btn_select_mitems_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_cancel_modifier_Click(object sender, RoutedEventArgs e)
        {
            vid = null;
            jobCodeId = null;
            ven_id = null;
            this.Close();
        }
    }
}
