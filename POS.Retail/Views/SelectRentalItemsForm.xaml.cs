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
    /// Interaction logic for SelectRentalItemsForm.xaml
    /// </summary>
    public partial class SelectRentalItemsForm : Window
    {
       private static string dated = null;
        private static string row_id = null;
        string cust_num = null;
        string storeid = null;
        //GlobalClass glo = new GlobalClass();
        public SelectRentalItemsForm() //Select_Rental_Items_Frm()
        {
            InitializeComponent();
        }
        public SelectRentalItemsForm(string cust_no, string storeid)
        {
            InitializeComponent();
            this.cust_num = cust_no;
            this.storeid = storeid;
        }

        private void btn_scroll_down_Click(object sender, RoutedEventArgs e)
        {
            Int32 indx = dg_customer_rental_information.SelectedIndex;
            if (indx != dg_customer_rental_information.Items.Count - 1 && dg_customer_rental_information.SelectedItem != null)
            {
                dg_customer_rental_information.SelectedIndex = indx + 1;
            }
        }

        private void btn_scroll_up_Click(object sender, RoutedEventArgs e)
        {
            Int32 indx = dg_customer_rental_information.SelectedIndex;

            if (indx != 0 && dg_customer_rental_information.SelectedItem != null)
            {
                dg_customer_rental_information.SelectedIndex = indx - 1;
            }
        }

        public string selected_row_id
        {
            get { return row_id; }
            set { row_id = value; }
        }

        public string selected_date
        {
            get { return dated; }
            set { dated = value; }
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            select_rowid();
        }
        private void select_rowid()
        {
            if (dg_customer_rental_information.SelectedItem != null)
            {
                MessageBox.Show(dg_customer_rental_information.SelectedValue.ToString());
               
                row_id = dg_customer_rental_information.SelectedValue.ToString();
                TextBlock b = dg_customer_rental_information.Columns[2].GetCellContent(dg_customer_rental_information.SelectedItem) as TextBlock;
                dated = b.Text;
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //selected_row_id = null;
                //if (glo.con.State == ConnectionState.Closed)
                //{
                //    glo.con.Open();
                //}
                //SqlCommand cmd_count_currcust = new SqlCommand("select count(CurrCust) FROM (Inventory_Rental_Info INNER JOIN Inventory ON Inventory_Rental_Info.ItemNum = Inventory.ItemNum) WHERE Inventory.Store_ID = '" + storeid + "' AND " +
                //"Inventory_Rental_Info.Store_ID = '" + storeid + "' AND CurrCust = '" + cust_num + "' and Inventory_Rental_Info.Status = 'R' AND Inventory_Rental_Info.[Primary] = 0 ", glo.con);
                //if (Convert.ToInt32(cmd_count_currcust.ExecuteScalar()) != 0)
                //{
                //    SqlCommand cmd3 = new SqlCommand("SELECT ItemName AS Item_Description,RowID, Late_Charge AS Daily_Late_Charge, Due_Date AS Due_Date, " +
                //    "Inventory.ItemNum AS Item_no " +
                //     "FROM (Inventory_Rental_Info INNER JOIN Inventory ON  " +
                //     "Inventory_Rental_Info.ItemNum = Inventory.ItemNum)  " +
                //     "WHERE Inventory.Store_ID = '" + storeid + "' AND  " +
                //     "Inventory_Rental_Info.Store_ID = '" + storeid + "'  " +
                //     "AND CurrCust = '" + cust_num + "' and Inventory_Rental_Info.Status = 'R'  " +
                //     "AND Inventory_Rental_Info.[Primary] = 0", glo.con);
                //    cmd3.ExecuteNonQuery();
                //    DataSet _Bind = new DataSet();

                //    SqlDataAdapter sda = new SqlDataAdapter(cmd3);
                //    sda.Fill(_Bind, "MyBinding");
                //    DataTable dt = _Bind.Tables[0];


                //    dg_customer_rental_information.SelectedValuePath = ("RowID");
                //    dg_customer_rental_information.DataContext = _Bind;
                //    _Bind.Dispose();
                //}
                //if (glo.con.State == ConnectionState.Closed)
                //{
                //    glo.con.Open();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            selected_row_id = null;
            this.Close();
        }

        private void dg_customer_rental_information_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            select_rowid();
        }
    }
}
