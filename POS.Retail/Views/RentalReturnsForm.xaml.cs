using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for RentalReturnsForm.xaml
    /// </summary>
    public partial class RentalReturnsForm : Window
    {
        System.Windows.Forms.DataGridView DG_itemsale = new System.Windows.Forms.DataGridView();
        //GlobalClass glo = new GlobalClass();
        string store_idd = "1001";
        public RentalReturnsForm() //Rental_Returns_Frm()
        {
            InitializeComponent();
        }
        public RentalReturnsForm(System.Windows.Forms.DataGridView dg_itemsale)
        {
            InitializeComponent();
            this.DG_itemsale = dg_itemsale;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txt_date_returned.Text = System.DateTime.Today.ToShortDateString();
        }

        private bool validate_date(string date_valid)
        {
            DateTime dt;
            bool validate_dt = DateTime.TryParseExact(date_valid, "MM/d/yyyy", null, DateTimeStyles.None, out dt);
            return validate_dt;
        }

        private void delete_fill_data(string row_id)
        {
            //if (glo.con.State == ConnectionState.Closed)
            //{
            //    glo.con.Open();
            //}

           

            //SqlCommand cmd_fill_textboxes = new SqlCommand("SELECT ItemName AS Item_Description,RowID,Inventory.ItemNum as itemnum,Inventory.Dept_ID as dept_id, Late_Charge AS Daily_Late_Charge, Due_Date AS Due_Date, " +
            //        "Inventory.ItemNum AS Item_no " +
            //         "FROM (Inventory_Rental_Info INNER JOIN Inventory ON  " +
            //         "Inventory_Rental_Info.ItemNum = Inventory.ItemNum)  " +
            //         "WHERE Inventory.Store_ID = '" + store_idd + "' AND  " +
            //         "Inventory_Rental_Info.Store_ID = '" + store_idd + "'  " +
            //         "AND RowID = '" + row_id + "' and Inventory_Rental_Info.Status = 'R'  " +
            //         "AND Inventory_Rental_Info.[Primary] = 0", glo.con);
            //SqlDataReader rdr_fill_textboxes = cmd_fill_textboxes.ExecuteReader();
            //rdr_fill_textboxes.Read();
            //txt_department.Text = rdr_fill_textboxes["dept_id"].ToString();
            //txt_item_num.Text = rdr_fill_textboxes["itemnum"].ToString();
            //txt_quantity.Text = "1";
            //txt_status.Text = "S";
            //txt_item_name.Text = rdr_fill_textboxes["Item_Description"].ToString();
            //rdr_fill_textboxes.Close();
            //SqlCommand cmd_deleted_inventory_rental = new SqlCommand("delete from Inventory_Rental_Info where RowID='" + row_id + "'", glo.con);
            //cmd_deleted_inventory_rental.ExecuteNonQuery();

            //if (glo.con.State == ConnectionState.Open)
            //{
            //    glo.con.Close();
            //}
        }

        private void txt_cust_no_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Enter)
            //{
            //    if (txt_cust_no.Text.Length != 0)
                
            //    {
            //    if (validate_date(txt_date_returned.Text) == false)
            //    {
            //        MessageBox.Show("Invalid Date Format", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //    else
            //    {
            //    if (glo.con.State == ConnectionState.Closed)
            //    {
            //        glo.con.Open();
            //    }
            //         SqlCommand cmd_count_currcust = new SqlCommand("select count(CurrCust) FROM (Inventory_Rental_Info INNER JOIN Inventory ON Inventory_Rental_Info.ItemNum = Inventory.ItemNum) WHERE Inventory.Store_ID = '" + store_idd + "' AND " +
            //    "Inventory_Rental_Info.Store_ID = '"+store_idd+"' AND CurrCust = '"+txt_cust_no.Text+"' and Inventory_Rental_Info.Status = 'R' AND Inventory_Rental_Info.[Primary] = 0 ", glo.con);

            //         if (Convert.ToInt32(cmd_count_currcust.ExecuteScalar()) != 0)
            //         {
            //             Select_Rental_Items_Frm rental_inf_cust = new Select_Rental_Items_Frm(txt_cust_no.Text, store_idd);
            //             rental_inf_cust.ShowDialog();
            //             if (rental_inf_cust.selected_row_id != null)
            //             {
            //                 if (glo.con.State == ConnectionState.Closed)
            //                 {
            //                     glo.con.Open();
            //                 }
            //                 if (Convert.ToDateTime(rental_inf_cust.selected_date) < Convert.ToDateTime(txt_date_returned.Text))
            //                 {
            //                     Late_Return_Dialog_frm late_dialog = new Late_Return_Dialog_frm();
            //                     late_dialog.ShowDialog();
            //                     if (late_dialog.value_input == "W")
            //                     { }
            //                     else if (late_dialog.value_input == "I")
            //                     {
            //                         if (glo.con.State == ConnectionState.Closed)
            //                         {
            //                             glo.con.Open();
            //                         }
            //                         int late_days = (Convert.ToDateTime(txt_date_returned.Text) - Convert.ToDateTime(rental_inf_cust.selected_date)).Days;
            //                         SqlCommand cmd_late_charge = new SqlCommand("select a.Late_Charge as late_charge,b.ItemName as item_name from Inventory_Rental_Info a inner join Inventory b on a.ItemNum=b.ItemNum where RowID='" + rental_inf_cust.selected_row_id + "'", glo.con);
            //                         double late_charge = 0;
            //                         string item_nam = null;
            //                         SqlDataReader rdr_late_charge = cmd_late_charge.ExecuteReader();
            //                         rdr_late_charge.Read();
            //                         late_charge = Convert.ToDouble(rdr_late_charge["late_charge"]);
            //                         item_nam = Convert.ToString(rdr_late_charge["item_name"]);
            //                         rdr_late_charge.Close();
            //                         late_charge = late_charge * late_days;
            //                         MessageBox.Show(late_charge.ToString());
            //                         if (glo.con.State == ConnectionState.Open)
            //                         {
            //                             glo.con.Close();
            //                         }
            //                         string item_info = "non_inventory" + "@" + late_charge + " " + "LateFee-" + item_nam;
            //                         if (DG_itemsale.Rows.Count == 0)
            //                         {
            //                             DG_itemsale.Rows.Add(0 + 1, item_info, 1, late_charge);
            //                         }
            //                         else
            //                         {
            //                             DG_itemsale.Rows.Add(Convert.ToInt32(DG_itemsale.Rows[DG_itemsale.Rows.Count - 1].Cells[0].Value) + 1, item_info, 1, late_charge);
            //                         }
            //                     }
            //                 }

            //                 delete_fill_data(rental_inf_cust.selected_row_id);

            //                 if (MessageBox.Show("Would like to return another rental from this customer", "Prompt", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            //                 {
            //                     Select_Rental_Items_Frm rent_items_select_frm = new Select_Rental_Items_Frm(txt_cust_no.Text, store_idd);
            //                     rent_items_select_frm.ShowDialog();
            //                 }
            //                 else
            //                 {
            //                     if (glo.con.State == ConnectionState.Open)
            //                     {
            //                         glo.con.Close();
            //                     }
            //                     this.Close();
            //                 }
            //                 if (glo.con.State == ConnectionState.Open)
            //                 {
            //                     glo.con.Close();
            //                 }

            //             }
            //         }
            //         else
            //         {
            //             MessageBox.Show("No Record found","Sorry",MessageBoxButton.OK,MessageBoxImage.Error);
            //         }
            //    if (glo.con.State == ConnectionState.Open)
            //    {
            //        glo.con.Close();
            //    }
            //    }

            //    }

            //}
        }
    }
}
