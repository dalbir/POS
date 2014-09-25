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
    /// Interaction logic for ReceivingScreen.xaml
    /// </summary>
    public partial class ReceivingScreen : Window
    {
        PurchaseOrderForm po = new PurchaseOrderForm();
        //GlobalClass glo = new GlobalClass();
        public ReceivingScreen()
        {
            InitializeComponent();
        }

        private void fun_enter_id()
        {
            string id = txt_scan_item_code.Text;
            if (po.set_itemNo.Contains(id))
            {
                if (Convert.ToDouble(txt_qty.Text) > po.set_itemQty[po.set_itemNo.IndexOf(id)])
                {
                    var result = MessageBox.Show("This Amount will Over Receive. Is This OK?", "Question Box", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        string qury = "select ItemNum, ItemName from Inventory where ItemNum = '" + id + "'";
                        //glo.fun_search(qury);
                        //glo.dr.Read();
                        //string itemname = glo.dr["ItemName"].ToString();
                        //glo.dr.Close();
                        //lsb_po_receive_detail.Items.Add(id + " : " + itemname + " : " + txt_qty.Text);
                        txt_scan_item_code.Text = "";
                        txt_scan_item_code.Focus();

                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    string qury = "select ItemNum, ItemName from Inventory where ItemNum = '" + id + "'";
                    //glo.fun_search(qury);
                    //glo.dr.Read();
                    //string itemname = glo.dr["ItemName"].ToString();
                    //glo.dr.Close();
                    //lsb_po_receive_detail.Items.Add(id + " : " + itemname + " : " + txt_qty.Text);
                    txt_scan_item_code.Text = "";
                    txt_scan_item_code.Focus();
                }
            }
            else
            {
                txt_scan_item_code.Text = "";
                txt_scan_item_code.Focus();
            }
        }

        private void txt_scan_item_code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txt_qty.Text = "1";
                txt_qty.SelectAll();
                txt_qty.Focus();
            }
        }

        private void txt_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                fun_enter_id();
            }
        }

        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            fun_enter_id();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txt_scan_item_code.Focus();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            if (lsb_po_receive_detail.Items.Count > 0)
            {
                var result = MessageBox.Show("There are Uncommitted Items on This Batch. Are You Sure You Want To Cancel", "Question Box", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    this.Close();
                }
                else
                {
                    return;
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btn_commit_all_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_delete_all_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lsb_po_receive_detail.Items.RemoveAt(lsb_po_receive_detail.SelectedIndex);
            }
            catch (Exception)
            {
            }
        }
    }
}
