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
    /// Interaction logic for GlobalPriceChangeForm.xaml
    /// </summary>
    public partial class GlobalPriceChangeForm : Window
    {
       // GlobalClass glo = new GlobalClass();
       // NumberKeypaid num = new NumberKeypaid();
        EnterStartEndDate starend = new EnterStartEndDate();

        public GlobalPriceChangeForm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Height = 318;
            cmb_ids.Visibility = Visibility.Hidden;
            btn_remove_item.IsEnabled = false;
            rb_all_items.IsChecked = true;
        }

        private void rb_all_items_Checked(object sender, RoutedEventArgs e)
        {
            this.Height = 318;
            cmb_ids.Visibility = Visibility.Hidden;
            btn_remove_item.IsEnabled = false;
            lbl.Content = "";
        }

        private void rb_items_in_depat_Checked(object sender, RoutedEventArgs e)
        {
            this.Height = 533;
            cmb_ids.Visibility = Visibility.Visible;
            lbl.Content = "Select Department";
            btn_remove_item.IsEnabled = false;
            DG_items.Rows.Clear();
            string qury_dept = "SELECT DISTINCT Dept_ID  FROM Departments WHERE (Store_ID = '1001')";
            //DataTable dt_deprt = glo.getdata(qury_dept);
            //cmb_ids.ItemsSource = dt_deprt.DefaultView;
            //cmb_ids.DisplayMemberPath = "Dept_ID";
            //cmb_ids.SelectedIndex = 0;
        }

        private void rb_select_items_Checked(object sender, RoutedEventArgs e)
        {
            this.Height = 533;
            cmb_ids.Visibility = Visibility.Visible;
            lbl.Content = "Select Item";

            btn_remove_item.IsEnabled = true;
            DG_items.Rows.Clear();

            string qury_dept = "SELECT DISTINCT Inventory.ItemNum, Inventory.ItemName FROM Inventory WHERE IsDeleted = 0 AND ItemType IN (0,2) AND (Store_ID = '1001')";
            //DataTable dt_deprt = glo.getdata(qury_dept);
            //cmb_ids.ItemsSource = dt_deprt.DefaultView;
            //cmb_ids.DisplayMemberPath = "ItemNum";
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmb_ids_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_ids.Text != "")
            {
                if (rb_items_in_depat.IsChecked == true)
                {
                    DG_items.Rows.Clear();
                    //string qry_item_indeprt = "SELECT ItemNum, ItemName, Price, 0.00 AS [Sale Price] FROM Inventory WHERE IsDeleted = 0 AND ItemType IN (0,2) AND Dept_ID = '" + cmb_ids.Text.ToString() + "' AND (Store_ID = '1001')";
                    //DataTable dt_item_in_dept = glo.getdata(qry_item_indeprt);
                    //for (int i = 0; i < dt_item_in_dept.Rows.Count; i++)
                    //{
                    //    DG_items.Rows.Add();
                    //    DG_items.Rows[i].Cells[0].Value = dt_item_in_dept.Rows[i]["ItemNum"].ToString();
                    //    DG_items.Rows[i].Cells[1].Value = dt_item_in_dept.Rows[i]["ItemName"].ToString();
                    //    DG_items.Rows[i].Cells[2].Value = dt_item_in_dept.Rows[i]["Price"].ToString();
                    //    //DG_items.Rows[i].Cells[3].Value = dt_item_in_dept.Rows[i]["Cost"].ToString();
                    //}
                }
                if (rb_select_items.IsChecked == true)
                {
                    //string qruy_select_item = "select ItemNum, ItemName, Price, Cost from Inventory where Store_ID = '1001' and ItemNum = '" + cmb_ids.Text.ToString() + "'";
                    //DataTable dt_selct_itm = glo.getdata(qruy_select_item);
                    try
                    {
                    //    DG_items.Rows.Add();
                    //    DG_items.Rows[DG_items.Rows.Count - 1].Cells[0].Value = dt_selct_itm.Rows[0]["ItemNum"].ToString();
                    //    DG_items.Rows[DG_items.Rows.Count - 1].Cells[1].Value = dt_selct_itm.Rows[0]["ItemName"].ToString();
                    //    DG_items.Rows[DG_items.Rows.Count - 1].Cells[2].Value = dt_selct_itm.Rows[0]["Price"].ToString();
                    //    // DG_items.Rows[DG_items.Rows.Count - 1].Cells[3].Value = dt_selct_itm.Rows[0]["Cost"].ToString();
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        private void btn_price_change_Click(object sender, RoutedEventArgs e)
        {
            if (rb_select_items.IsChecked == true)
            {
                if (DG_items.Rows.Count == 0)
                {
                    System.Windows.MessageBox.Show("Threre are No Items Selected. Select Items First and Try Again", "Run Time Support", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            //QuestionBoxGlobalChange change_price = new QuestionBoxGlobalChange(0);
            //change_price.ShowDialog();
            //if (change_price.set_cancel_flage == 1)
            //{
            //    NumberKeypaid kp_price_for_all = new NumberKeypaid(25);
            //    kp_price_for_all.ShowDialog();
            //    if (rb_all_items.IsChecked == true)
            //    {
            //        if (num.set_change_value != null)
            //        {
            //            string qruy_chg_price_all = "UPDATE Inventory SET Price = '" + Convert.ToDouble(num.set_change_value) + "', Dirty = 1 WHERE (Store_ID = '1001')";
            //            glo.fun_insert(qruy_chg_price_all);
            //            System.Windows.MessageBox.Show("Your Price Changes have been Applied", "Run Time Support", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //        }
            //    }
            //    else if (rb_items_in_depat.IsChecked == true)
            //    {
            //        if (num.set_change_value != null)
            //        {
            //            string qry_change_price_bydept = "UPDATE Inventory SET Price = '" + num.set_change_value + "', Dirty = 1 WHERE (Store_ID = '1001') and Dept_ID = ''";
            //            glo.fun_insert(qry_change_price_bydept);
            //            System.Windows.MessageBox.Show("Your Price Changes have been Applied", "Run Time Support", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //        }
            //    }
            //    else if (rb_select_items.IsChecked == true)
            //    {
            //        if (num.set_change_value != null)
            //        {
            //            for (int j = 0; j < DG_items.Rows.Count; j++)
            //            {
            //                string qry_change_byitems = "update Inventory set Price = '" + num.set_change_value + "', Dirty = 1 WHERE (Store_ID = '1001') and ItemNum = '" + DG_items.Rows[j].Cells[0].Value.ToString() + "'";
            //                glo.fun_insert(qry_change_byitems);
            //            }
            //            System.Windows.MessageBox.Show("Your Price Changes have been Applied", "Run Time Support", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //        }
            //    }
            //}
        }

        private void btn_set_sale_price_Click(object sender, RoutedEventArgs e)
        {
            if (rb_select_items.IsChecked == true)
            {
                if (DG_items.Rows.Count == 0)
                {
                    System.Windows.MessageBox.Show("Threre are No Items Selected. Select Items First and Try Again", "Run Time Support", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            //QuestionBoxGlobalChange change_price = new QuestionBoxGlobalChange(1);
            //change_price.ShowDialog();
            //if (change_price.set_cancel_flage == 1)
            //{
            //    NumberKeypaid kp_price_for_all = new NumberKeypaid(25);
            //    kp_price_for_all.ShowDialog();
            //    if (num.set_change_value != null)
            //    {
            //        EnterStartEndDate start = new EnterStartEndDate(0);
            //        start.ShowDialog();
            //        if (starend.set_start_date != null)
            //        {
            //            EnterStartEndDate end = new EnterStartEndDate(1);
            //            end.ShowDialog();
            //            if (starend.set_end_date != null)
            //            {
            //                if (rb_all_items.IsChecked == true)
            //                {
            //                    string delte = "delete from Inventory_OnSale_Info where Store_ID = '1001'";
            //                    glo.fun_insert(delte);
            //                    string qruy_chg_prce_all = "INSERT INTO Inventory_OnSale_Info (ItemNum, Store_ID, Sale_Start, Sale_End, [Percent], [Price], SalePriceType) SELECT Inventory.ItemNum, '1001' AS Store_ID, '" + Convert.ToDateTime(starend.set_start_date) + "' AS Sale_Start, '" + Convert.ToDateTime(starend.set_end_date) + "' AS Sale_End,  0 As [Percent], '" + Convert.ToDouble(num.set_change_value) + "' AS [Price], 1 As SalePriceType FROM Inventory WHERE Inventory.ItemType IN (0,2) AND Inventory.Store_ID = '1001'";
            //                    glo.fun_insert(qruy_chg_prce_all);
            //                    System.Windows.MessageBox.Show("Your Price Changes have been Applied", "Run Time Support", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //                }
            //                else if (rb_items_in_depat.IsChecked == true)
            //                {
            //                    string del = "DELETE FROM Inventory_OnSale_Info WHERE (Store_ID = '1001') AND  EXISTS (Select ItemNum FROM Inventory WHERE Inventory.ItemNum = Inventory_OnSale_Info.ItemNum AND Inventory.Store_ID = Inventory_OnSale_Info.Store_ID AND Inventory.ItemType IN (0,2) AND Inventory.Dept_ID = '" + cmb_ids.Text.ToString() + "')";
            //                    glo.fun_insert(del);
            //                    string qry = "INSERT INTO Inventory_OnSale_Info (ItemNum, Store_ID, Sale_Start, Sale_End, [Percent], [Price], SalePriceType) SELECT Inventory.ItemNum, '1001' AS Store_ID, '" + Convert.ToDateTime(starend.set_start_date) + "' AS Sale_Start, '" + Convert.ToDateTime(starend.set_end_date) + "' AS Sale_End, 0 As [Percent], '" + Convert.ToDouble(num.set_change_value) + "' AS [Price], 1 As SalePriceType FROM Inventory WHERE Inventory.ItemType IN (0,2) AND Inventory.Store_ID = '1001' AND Dept_ID = '" + cmb_ids.Text + "'";
            //                    glo.fun_insert(qry);
            //                    System.Windows.MessageBox.Show("Your Price Changes have been Applied", "Run Time Support", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //                }
            //                else if (rb_select_items.IsChecked == true)
            //                {
            //                    for (int j = 0; j < DG_items.Rows.Count; j++)
            //                    {
            //                        string qrry = "DELETE FROM Inventory_OnSale_Info WHERE (Store_ID = '1001') AND ItemNum = '" + DG_items.Rows[j].Cells[0].Value.ToString() + "'";
            //                        glo.fun_insert(qrry);
            //                    }
            //                    for (int k = 0; k < DG_items.Rows.Count; k++)
            //                    {
            //                        string qry_insert = "INSERT INTO Inventory_OnSale_Info (ItemNum, Store_ID, Sale_Start, Sale_End, [Percent], [Price], SalePriceType) SELECT Inventory.ItemNum, '1001' AS Store_ID, '" + Convert.ToDateTime(starend.set_start_date) + "' AS Sale_Start, '" + Convert.ToDateTime(starend.set_end_date) + "' AS Sale_End, 0 As [Percent], '" + Convert.ToDouble(num.set_change_value) + "' AS [Price], 1 As SalePriceType FROM Inventory WHERE Inventory.ItemType IN (0,2) AND Inventory.Store_ID = '1001' and Inventory.ItemNum ='" + DG_items.Rows[k].Cells[0].Value.ToString() + "'";
            //                        glo.fun_insert(qry_insert);
            //                    }
            //                    System.Windows.MessageBox.Show("Your Price Changes have been Applied", "Run Time Support", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //                }
            //            }
            //        }
            //    }
            //}
        }

        private void btn_remove_item_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //foreach (DataGridViewRow item in this.DG_items.SelectedRows)
                //{
                //    if (DG_items.Rows.Count > 0)
                //    {
                //        DG_items.Rows.RemoveAt(this.DG_items.SelectedRows[0].Index);
                //    }

                //}
            }
            catch (Exception)
            { }
        }

        private void btn_price_increase_Click(object sender, RoutedEventArgs e)
        {
            if (rb_select_items.IsChecked == true)
            {
                if (DG_items.Rows.Count == 0)
                {
                    System.Windows.MessageBox.Show("Threre are No Items Selected. Select Items First and Try Again", "Run Time Support", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            //QuestionBoxGlobalChange change_price = new QuestionBoxGlobalChange(2);
            //change_price.ShowDialog();
            //if (change_price.set_cancel_flage == 1)
            //{
            //    NumberKeypaid kp_price_for_all = new NumberKeypaid(26);
            //    kp_price_for_all.ShowDialog();
            //    if (num.set_change_value != null)
            //    {
            //        if (rb_all_items.IsChecked == true)
            //        {

            //            string qry = "UPDATE Inventory SET Price = Price * (1 + .05), Dirty = 1 WHERE Store_ID = '1001'";
            //            glo.fun_insert(qry);
            //            System.Windows.MessageBox.Show("Your Price Changes have been Applied", "Run Time Support", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //        }
            //        else if (rb_items_in_depat.IsChecked == true)
            //        {
            //            System.Windows.MessageBox.Show("Your Price Changes have been Applied", "Run Time Support", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //        }
            //        else if (rb_select_items.IsChecked == true)
            //        {
            //            System.Windows.MessageBox.Show("Your Price Changes have been Applied", "Run Time Support", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //        }
            //    }
            //}
        }
    }
}
