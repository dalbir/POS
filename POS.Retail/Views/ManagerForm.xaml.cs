using POS.Retail.Views;
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
    /// Interaction logic for ManagerForm.xaml
    /// </summary>
    public partial class ManagerForm : Window
    {
         string cashier_id = null;
        List<string> g_c_ids = new List<string>();
        System.Windows.Forms.DataGridView DG_itemsale = new System.Windows.Forms.DataGridView();
        //GlobalClass glo = new GlobalClass();
        private static string btn_clcked = null;
        string discount = null;
        string g_total = null;
        MainWindow obj = new MainWindow();
        private Domain.Common.BackOrdersClass objBackOrder;
        public ManagerForm()
        {
            InitializeComponent();
        }

        public ManagerForm(Domain.Common.BackOrdersClass objBackOrder)
        {
            InitializeComponent();
            this.objBackOrder = objBackOrder;
        }
        //public ManagerForm(System.Windows.Forms.DataGridView dg_itemsale, string discountd, string grand_total, List<string> g_c_idsz, string cashier_idz)
        //{
        //    InitializeComponent();
        //    this.cashier_id = cashier_idz;
        //    this.DG_itemsale = dg_itemsale;
        //    this.discount = discountd;
        //    this.g_total = grand_total;
        //    this.g_c_ids = g_c_idsz;
        //}
        public string set_btn_clicked
        {
            get {return btn_clcked;}
            set { btn_clcked = value; }
        }
        private void fun_select_btn_sign()
        {
            rec_admin.Visibility = Visibility.Hidden;
            rec_setup.Visibility = Visibility.Hidden;
            rec_tools.Visibility = Visibility.Hidden;
            rec_invoice.Visibility = Visibility.Hidden;
            rec_cashier.Visibility = Visibility.Hidden;
        }
        private void fun_hide_grid()
        {
            grid_admin.Visibility = Visibility.Hidden;
            grid_setup.Visibility = Visibility.Hidden;
            cahsier_grid.Visibility = Visibility.Hidden;
            invoice_properties_screen.Visibility = Visibility.Hidden;
            tools_grid.Visibility = Visibility.Hidden;
        }
      

        private void btn_manger_gird_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #region Click Events of all the main buttons on Manager gird

        private void btn_setup_grid_Click(object sender, RoutedEventArgs e)
        {
            fun_hide_grid();
            fun_select_btn_sign();
            rec_setup.Visibility = Visibility.Visible;
            grid_setup.Visibility = Visibility.Visible;
        }

        private void btn_cashier_grid_Click(object sender, RoutedEventArgs e)
        {
            fun_hide_grid();
            cahsier_grid.Visibility = Visibility.Visible;
            fun_select_btn_sign();
            rec_cashier.Visibility = Visibility.Visible;

        }

        private void btn_invoic_grid_Click(object sender, RoutedEventArgs e)
        {
            fun_hide_grid();
            fun_select_btn_sign();
            rec_invoice.Visibility = Visibility.Visible;
            invoice_properties_screen.Visibility = Visibility.Visible;
            
        }

        private void btn_tools_grid_Click(object sender, RoutedEventArgs e)
        {
            fun_hide_grid();
            fun_select_btn_sign();
            rec_tools.Visibility = Visibility.Visible;
            tools_grid.Visibility = Visibility.Visible;
        }
        private void btn_admin_gird_Click(object sender, RoutedEventArgs e)
        {
            fun_hide_grid();
            grid_admin.Visibility = Visibility.Visible;
            fun_select_btn_sign();
            rec_admin.Visibility = Visibility.Visible;
        }
        #endregion

        private void btn_dept_maintance_Click(object sender, RoutedEventArgs e)
        {
            DepartmentMaintanceForm obj = new DepartmentMaintanceForm();
            obj.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            obj.ShowDialog();
        }
        private void btn_emp_maintance_Click(object sender, RoutedEventArgs e)
        {
            EmployeeForm objemp = new EmployeeForm();
            objemp.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            objemp.ShowDialog();
        }
        private void btn_vendor_maintence_Click(object sender, RoutedEventArgs e)
        {
            VendorMaintForm objvendor = new VendorMaintForm();
            objvendor.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            objvendor.ShowDialog();
        }

        private void btn_inventory_mantence_Click(object sender, RoutedEventArgs e)
        {
            InventoryForm obj_inventory = new InventoryForm();
            obj_inventory.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            obj_inventory.ShowDialog();
        }
        private void btn_customer_maintenance_Click(object sender, RoutedEventArgs e)
        {
            CustomerForm obj_customer = new CustomerForm();
            obj_customer.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            obj_customer.ShowDialog();
            
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Grid_main_manager.Visibility == Visibility.Visible)
            {
                {
                    if (e.Key == Key.D5 || e.Key == Key.NumPad5)
                    {
                        fun_hide_grid();
                        grid_admin.Visibility = Visibility.Visible;
                        fun_select_btn_sign();
                        rec_admin.Visibility = Visibility.Visible;
                    }
                    else if (e.Key == Key.D4 || e.Key == Key.NumPad4)
                    {
                        fun_hide_grid();
                        fun_select_btn_sign();
                        rec_setup.Visibility = Visibility.Visible;
                        grid_setup.Visibility = Visibility.Visible;
                    }
                    else if (e.Key == Key.D3 || e.Key == Key.NumPad3)
                    {
                        fun_hide_grid();
                        fun_select_btn_sign();
                        rec_tools.Visibility = Visibility.Visible;
                        tools_grid.Visibility = Visibility.Visible;
                    }
                    else if (e.Key == Key.D2 || e.Key == Key.NumPad2)
                    {
                        fun_hide_grid();
                        fun_select_btn_sign();
                        rec_invoice.Visibility = Visibility.Visible;
                        invoice_properties_screen.Visibility = Visibility.Visible;
                    }
                    else if (e.Key == Key.D1 || e.Key == Key.NumPad1)
                    {
                        fun_hide_grid();
                        fun_select_btn_sign();
                        rec_cashier.Visibility = Visibility.Visible;
                        cahsier_grid.Visibility = Visibility.Visible;
                    }
                }
                if (grid_admin.Visibility == Visibility.Visible)
                {
                    if (e.Key == Key.A)
                    {
                        InventoryForm obj = new InventoryForm();
                        obj.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                        obj.ShowDialog();
                    }
                    else if (e.Key == Key.B)
                    {
                        DepartmentMaintanceForm obj = new DepartmentMaintanceForm();
                        obj.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                        obj.ShowDialog();
                    }
                    else if (e.Key == Key.C)
                    {

                    }
                    else if (e.Key == Key.D)
                    {
                        CustomerForm obj_customer = new CustomerForm();
                        obj_customer.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                        obj_customer.ShowDialog();
                    }
                    else if (e.Key == Key.E)
                    {
                        EmployeeForm eobj = new EmployeeForm();
                        eobj.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                        eobj.ShowDialog();
                    }
                    else if (e.Key == Key.F)
                    {
                        VendorMaintForm vobj = new VendorMaintForm();
                        vobj.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                        vobj.ShowDialog();
                    }
                }
                if (grid_setup.Visibility == Visibility.Visible)
                {
                    if (e.Key == Key.J)
                    {
                        TaxSetupForm frmTax = new TaxSetupForm();
                        frmTax.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                        frmTax.ShowDialog();
                    }
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btn_tax_rates_Click(object sender, RoutedEventArgs e)
        {
            TaxSetupForm frt = new TaxSetupForm();
            frt.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            frt.ShowDialog();
        }

        private void btn_purchase_order_Click(object sender, RoutedEventArgs e)
        {
            PurchaseOrderForm frm = new PurchaseOrderForm();
            frm.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            frm.ShowDialog();
        }

        private void btn_recall_invoice_Click(object sender, RoutedEventArgs e)
        {
            RecallInvoiceForm recall_frm = new RecallInvoiceForm();
            recall_frm.ShowDialog();
            if (recall_frm.recall_invoice_id != null)
            {
                this.Close();
                btn_clcked = "1C";
            }
        }

        private void btn_recall_onhold_inv_Click(object sender, RoutedEventArgs e)
        {
            OnHoldForm onhold_frm = new OnHoldForm();
            onhold_frm.ShowDialog();
            {
                if (onhold_frm.on_hold_id != null)
                {
                    this.Close();
                    btn_clcked = "1D";
                }
            }
        }

        private void btn_check_gc_balance_Click(object sender, RoutedEventArgs e)
        {
             //MyDialog dialog = new MyDialog("Scan, Swipe or Type Gift Card ID:", "",2);
             //        dialog.ShowDialog();

             //        if (dialog.InputText1.Length != 0)
             //        {
             //            if (glo.con.State == ConnectionState.Closed)
             //            {
             //                glo.con.Open();
             //            }
             //            double balance = 0;

             //            SqlCommand cmd_count_gc = new SqlCommand("select count(*) from Gift_Cards where Card_ID='" + dialog.InputText1 + "'", glo.con);
             //            if (Convert.ToInt32(cmd_count_gc.ExecuteScalar()) != 0)
             //            {
             //                SqlCommand cmd_check_gc = new SqlCommand("select Balance from Gift_Cards where Card_ID='" + dialog.InputText1 + "'", glo.con);
             //                SqlDataReader rdr_check_gc = cmd_check_gc.ExecuteReader();
             //                rdr_check_gc.Read();
             //                balance = Convert.ToDouble(rdr_check_gc["Balance"]);
             //                rdr_check_gc.Close();

             //                if (balance <= 0)
             //                {
             //                    MessageBox.Show("This Gift Card has zero balance", "No Balance", MessageBoxButton.OK, MessageBoxImage.Stop);

             //                }
             //                else
             //                {
             //                    MessageBox.Show("Remaining Balance: "+balance, "Balance", MessageBoxButton.OK, MessageBoxImage.Information);
             //                }
             //            }
             //            else
             //            {
             //                MessageBox.Show("This Gift Card has not been activated", "Gift Card not found", MessageBoxButton.OK, MessageBoxImage.Stop); 
             //            }
             //        }
        }

        private void btn_back_order_Click(object sender, RoutedEventArgs e)
        {
            //if (objBackOrder.backOrederPosition == "manager")
            //{
            //    MessageBox.Show("You Must Logged into Process Backorders", "Run Time Support", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    return;
            //}
            //else if (objBackOrder.backOrederPosition == "cashier")
            //{
            BackOrdersForm objBo = new BackOrdersForm();
            objBo.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            objBo.ShowDialog();
            //}
        }

        private void btn_price_check_Click(object sender, RoutedEventArgs e)
        {
            CheckPriceForm chk_price_frm = new CheckPriceForm();
            chk_price_frm.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            chk_price_frm.ShowDialog();
        }

        private void btn_return_rentals_Click(object sender, RoutedEventArgs e)
        {
            RentalReturnsForm return_rentals = new RentalReturnsForm(DG_itemsale);
            return_rentals.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            return_rentals.ShowDialog();
            if (DG_itemsale.Rows.Count != 0)
            {
                btn_clcked = "1G";
                this.Close();
            }
        }

        private void btn_invoice_discounts_Click(object sender, RoutedEventArgs e)
        {
            NumberKeypaid num_paid = new NumberKeypaid(32, discount);
            num_paid.ShowDialog();
            if (num_paid.set_cash_reg_price != null)
            {
                btn_clcked = "2A";
                this.Close();
            }
        }

        private void btn_desired_grant_total_Click(object sender, RoutedEventArgs e)
        {
            NumberKeypaid num_paid = new NumberKeypaid(33, g_total);
            num_paid.ShowDialog();
            if (num_paid.set_cash_reg_price != null)
            {
                btn_clcked = "2E";
                this.Close();
            }
        }

        private void btn_deactivate_cards_Click(object sender, RoutedEventArgs e)
        {
            
            //MyDialog dialog = new MyDialog();
            //Question_form_deactivate_gft_loyalty deactvate_cards_frm = new Question_form_deactivate_gft_loyalty();
            //deactvate_cards_frm.ShowDialog();
           
            //string Description = "Gift Card";

            //if (deactvate_cards_frm.gft_card_id.Length != 0)
            //{
            //    g_c_ids.Add(deactvate_cards_frm.gft_card_id);
            //    if (glo.con.State == ConnectionState.Closed)
            //    {
            //        glo.con.Open();
            //    }

            //    double balance = 0;
            //    SqlCommand cmd_check_if_gc_exists = new SqlCommand("select count(*) from Gift_Cards where Card_ID='" + deactvate_cards_frm.gft_card_id + "'", glo.con);
            //    if (Convert.ToInt16(cmd_check_if_gc_exists.ExecuteScalar()) != 0)
            //    {
            //        SqlCommand cmd_balance = new SqlCommand("select Balance from Gift_Cards where Card_ID='" + deactvate_cards_frm.gft_card_id + "'", glo.con);
            //        SqlDataReader rdr_balance = cmd_balance.ExecuteReader();
            //        rdr_balance.Read();
            //        balance = Convert.ToDouble(rdr_balance["Balance"]);
            //        balance = 0 - balance;
            //        rdr_balance.Close();
            //    }
            //    if (glo.con.State == ConnectionState.Open)
            //    {
            //        glo.con.Close();
            //    }
            //    string item_info = "GIFT_C" + "@" + balance + " " + Description;
            //    if (DG_itemsale.Rows.Count == 0)
            //    {

            //        DG_itemsale.Rows.Add(1, item_info, 1, balance);
            //        //DG_itemsale.ValueMember  = Convert.ToString(dt.Rows[0]["Price"]);
            //        // ((DataGridViewComboBoxColumn)DG_itemsale.Columns["Price"]).ValueMember = Convert.ToString(dt.Rows[i]["Price"]);
            //    }
            //    else
            //    {
            //        DG_itemsale.Rows.Add(Convert.ToInt32(DG_itemsale.Rows[DG_itemsale.Rows.Count - 1].Cells[0].Value) + 1, item_info, 1, balance);
            //    }
            //}
        }

        private void btn_cashout_gc_Click(object sender, RoutedEventArgs e)
        {
             //MyDialog dialog = new MyDialog("Scan, Swipe or Type Gift Card ID:", "");
             //        dialog.ShowDialog();
             //        string Description = "Gift Card";
             //        if (dialog.InputText1.Length != 0)
             //        {
             //            g_c_ids.Add(dialog.InputText1);
             //            if (glo.con.State == ConnectionState.Closed)
             //            {
             //                glo.con.Open();
             //            }
             //            double balance = 0;
             //            SqlCommand cmd_check_if_gc_exists = new SqlCommand("select count(*) from Gift_Cards where Card_ID='" + dialog.InputText1.Length + "'", glo.con);
             //            if (Convert.ToInt16(cmd_check_if_gc_exists.ExecuteScalar()) != 0)
             //            {
             //                SqlCommand cmd_balance = new SqlCommand("select Balance from Gift_Cards where Card_ID='" + dialog.InputText1.Length + "'", glo.con);
             //                SqlDataReader rdr_balance = cmd_balance.ExecuteReader();
             //                rdr_balance.Read();
             //                balance = Convert.ToDouble(rdr_balance["Balance"]);
             //                balance = 0 - balance;
             //                rdr_balance.Close();
             //                string item_info = "GIFT_C" + "@" + balance + " " + Description;
             //                if (DG_itemsale.Rows.Count == 0)
             //                {

             //                    DG_itemsale.Rows.Add(1, item_info, 1, balance);
             //                    //DG_itemsale.ValueMember  = Convert.ToString(dt.Rows[0]["Price"]);
             //                    // ((DataGridViewComboBoxColumn)DG_itemsale.Columns["Price"]).ValueMember = Convert.ToString(dt.Rows[i]["Price"]);
             //                }
             //                else
             //                {
             //                    DG_itemsale.Rows.Add(Convert.ToInt32(DG_itemsale.Rows[DG_itemsale.Rows.Count - 1].Cells[0].Value) + 1, item_info, 1, balance);
             //                }
             //            }
             //            if (glo.con.State == ConnectionState.Open)
             //            {
             //                glo.con.Close();
             //            }
                        
             //        }
        }

        private void btn_cash_pullout_Click(object sender, RoutedEventArgs e)
        {

            NumberKeypaid num_paid = new NumberKeypaid(34, "0.00");
            num_paid.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            num_paid.ShowDialog();
        }

        private void btn_credit_card_settlement_Click(object sender, RoutedEventArgs e)
        {
            CreditCardTipsForm crdt_tips_frm = new CreditCardTipsForm();
            crdt_tips_frm.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            crdt_tips_frm.ShowDialog();
        }

        private void btnCustomerItemPrice_Click(object sender, RoutedEventArgs e)
        {
            CustomerSpecificItemPrices obj = new CustomerSpecificItemPrices();
            obj.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            obj.ShowDialog();
        }

        private void btnGlobalPrice_Click(object sender, RoutedEventArgs e)
        {
            GlobalPriceChangeForm obj = new GlobalPriceChangeForm();
            obj.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            obj.ShowDialog();
        }

        private void btnMaxnMatch_Click(object sender, RoutedEventArgs e)
        {
            Mix_NMatch objMixNMatch = new Mix_NMatch();
            objMixNMatch.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            objMixNMatch.ShowDialog();
        }

        private void btnStyleMatrix_Click(object sender, RoutedEventArgs e)
        {
            frmStylesMatrix obj = new frmStylesMatrix();
            obj.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            obj.ShowDialog();
        }


        private void btnTimeClockManagment_Click(object sender, RoutedEventArgs e)
        {
            TimeClockManagement obj = new TimeClockManagement();
            obj.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            obj.ShowDialog();
        }
    }
}
