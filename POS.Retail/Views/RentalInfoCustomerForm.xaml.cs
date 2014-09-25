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
    /// Interaction logic for RentalInfoCustomerForm.xaml
    /// </summary>
    public partial class RentalInfoCustomerForm : Window
    {
      // GlobalClass glo = new GlobalClass();
        string selectd_customer = null;
        string storeid = null;
        public RentalInfoCustomerForm() //Rental_Info_Customer()
        {
            InitializeComponent();
        }
        public RentalInfoCustomerForm(string selected_cust, string store_id)
        {
            InitializeComponent();
            this.selectd_customer = selected_cust;
            this.storeid = store_id;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
              
                //if (glo.con.State == ConnectionState.Closed)
                //{
                //    glo.con.Open();
                //}
                //SqlCommand cmd_count_currcust = new SqlCommand("select count(CurrCust) FROM (Inventory_Rental_Info INNER JOIN Inventory ON Inventory_Rental_Info.ItemNum = Inventory.ItemNum) WHERE Inventory.Store_ID = '"+storeid+"' AND "+
                //"Inventory_Rental_Info.Store_ID = '"+storeid+"' AND CurrCust = '"+selectd_customer+"' and Inventory_Rental_Info.Status = 'R' AND Inventory_Rental_Info.[Primary] = 0 ", glo.con);
                //if (Convert.ToInt32(cmd_count_currcust.ExecuteScalar()) != 0)
                //{
                //    SqlCommand cmd3 = new SqlCommand("SELECT ItemName AS Item_Description, Late_Charge AS Daily_Late_Charge, Due_Date AS Due_Date, " +
                //    "Inventory.ItemNum AS Item_no "+
                //     "FROM (Inventory_Rental_Info INNER JOIN Inventory ON  "+
                //     "Inventory_Rental_Info.ItemNum = Inventory.ItemNum)  "+
                //     "WHERE Inventory.Store_ID = '" + storeid + "' AND  " +
                //     "Inventory_Rental_Info.Store_ID = '" + storeid + "'  " +
                //     "AND CurrCust = '"+selectd_customer+"' and Inventory_Rental_Info.Status = 'R'  " +
                //     "AND Inventory_Rental_Info.[Primary] = 0", glo.con);
                //    cmd3.ExecuteNonQuery();
                //    DataSet _Bind = new DataSet();

                //    SqlDataAdapter sda = new SqlDataAdapter(cmd3);
                //    sda.Fill(_Bind, "MyBinding");
                //    DataTable dt = _Bind.Tables[0];

                  

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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
