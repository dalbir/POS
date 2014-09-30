using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for CheckPriceForm.xaml
    /// </summary>
    public partial class CheckPriceForm : Window
    {
        //GlobalClass glo = new GlobalClass();
        decimal price = 0;
        decimal tx1 = 0;
        decimal tx2 = 0;
        decimal tx3 = 0;
        public CheckPriceForm()
        {
            InitializeComponent();
        }

        private void txt_itemId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
            //    string qry_stock_level = "select Store_ID, In_Stock from Inventory where ItemNum = '" + txt_itemId.Text + "'";
            //    DataTable dt_stock = glo.getdata(qry_stock_level);
            //    if (dt_stock.Rows.Count == 0)
            //    {
            //        MessageBox.Show("No Item Found", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            //        txt_itemId.Text = "";
            //        txt_itemId.Focus();
            //        return;
            //    }
            //    DG_stock_level.ItemsSource = dt_stock.DefaultView;
            //    string qry_gen = "SELECT * from VIEW_CHECK_PRICE_GEN where ItemNum = '" + txt_itemId.Text + "'";
            //    DataTable dt_gen = glo.getdata(qry_gen);

            //    lsb_genral.Items.Add("Item Number: " + dt_gen.Rows[0]["ItemNum"].ToString());
            //    lsb_genral.Items.Add("Item Number: " + dt_gen.Rows[0]["ItemName"].ToString());
            //    lsb_genral.Items.Add("");
            //    price = Math.Round(Convert.ToDecimal(dt_gen.Rows[0]["Price"]), 2);
            //    lsb_genral.Items.Add("Price: 1pc/$ " + price.ToString());

            //    if (Convert.ToInt32(dt_gen.Rows[0]["Tax_1"]) == 1)
            //    {
            //        tx1 = Math.Round(Convert.ToDecimal(dt_gen.Rows[0]["Tax1_Rate"]) * Convert.ToDecimal(dt_gen.Rows[0]["Price"]));
            //        lsb_genral.Items.Add("Tax1: " + tx1.ToString());
            //    }
            //    if (Convert.ToInt32(dt_gen.Rows[0]["Tax_2"]) == 1)
            //    {
            //        tx2 = Math.Round(Convert.ToDecimal(dt_gen.Rows[0]["Tax2_Rate"]) * Convert.ToDecimal(dt_gen.Rows[0]["Price"]), 2);
            //        lsb_genral.Items.Add("Tax2: " + tx2.ToString());
            //    }
            //    if (Convert.ToInt32(dt_gen.Rows[0]["Tax_3"]) == 1)
            //    {
            //        tx3 = Math.Round(Convert.ToDecimal(dt_gen.Rows[0]["Tax3_Rate"]) * Convert.ToDecimal(dt_gen.Rows[0]["Price"]), 2);
            //        lsb_genral.Items.Add("Tax3: " + tx3.ToString());
            //    }
            //    lsb_genral.Items.Add("");
            //    lsb_genral.Items.Add("Total: " + (price + tx1 + tx2 + tx3));

            //    string bulk_qury = "select * from Inventory_Bulk_Info where ItemNum ='" + txt_itemId.Text + "'";
            //    DataTable dtbulk = glo.getdata(bulk_qury);

            //    if (dtbulk.Rows.Count > 0)
            //    {
            //        lsb_genral.Items.Add("");
            //        lsb_genral.Items.Add("Bulk Prices Avaliable");
            //        for (int bul = 0; bul < dtbulk.Rows.Count; bul++)
            //        {
            //            if (Convert.ToInt32(dtbulk.Rows[bul]["Price_Type"]).Equals(0))
            //            {
            //                lsb_bulk_prices.Items.Add(Math.Round(Convert.ToDecimal(dtbulk.Rows[bul]["Bulk_Quan"]), 2).ToString() + "  For " + "$" + Math.Round(Convert.ToDecimal(dtbulk.Rows[bul]["Bulk_Price"]), 2) / Math.Round(Convert.ToDecimal(dtbulk.Rows[bul]["Bulk_Quan"]), 2) + "/$" + (Math.Round(Convert.ToDecimal(dtbulk.Rows[bul]["Bulk_Price"]), 2)).ToString());
            //            }
            //            if (Convert.ToInt32(dtbulk.Rows[bul]["Price_Type"]).Equals(1))
            //            {
            //                lsb_bulk_prices.Items.Add(Math.Round(Convert.ToDecimal(dtbulk.Rows[bul]["Bulk_Quan"]), 2).ToString() + "  For " + "$" + (Math.Round(price, 2) - (Math.Round(Convert.ToDecimal(dtbulk.Rows[bul]["Bulk_Price"]) / 100 * price, 2)) + " / $" + (Math.Round(price, 2) * Math.Round(Convert.ToDecimal(dtbulk.Rows[bul]["Bulk_Quan"]), 2) - Math.Round(Convert.ToDecimal(dtbulk.Rows[bul]["Bulk_Price"]) / 100 * Math.Round(price, 2) * Math.Round(Convert.ToDecimal(dtbulk.Rows[bul]["Bulk_Quan"]), 2), 2))));
            //            }
            //        }
            //    }

            }
        }
    }
}
