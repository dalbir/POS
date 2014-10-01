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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using POS.Services.Common;
using POS.Domain.Common;

namespace POS.Retail
{
    /// <summary>
    /// Interaction logic for PurchaseOrderForm.xaml
    /// </summary>
    public partial class PurchaseOrderForm : Window
    {
     
        OrderTypeForm typ = new OrderTypeForm();
        POSManagementService objPOSManagementService = new POSManagementService();
        string otype;
        private static string vendor_name = null;
        private static string vendor_no = null;
        private static string item_no = null;
        private static List<string> itemNo = new List<string>();
        private static List<double> ls_item_qty = new List<double>();
        string status;

        int type;

        public PurchaseOrderForm()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
           
            string ven_num = lstb_ven_list.SelectedItem.ToString();
            string[] split = ven_num.Split(' ');
            string vendor_id = split[0];
            string lbl = lbl_total_cost_order.Content.ToString();
            string[] lbl1 = lbl.Split(' ');
            double total_cst = Convert.ToDouble(lbl1[4]);
            string stats = "O";
            PO_SummaryClass objPO_SummaryClass = new PO_SummaryClass();
            // getting max po number
           // int maxid = glo.maxm_id("select isnull(max(PO_Number), 0) + 1 as po_no from PO_Summary");
            objPO_SummaryClass.Store_ID = "1001";
            objPO_SummaryClass.DateTime = DateTime.Today;
            objPO_SummaryClass.Reference = txt_reference.Text;
            objPO_SummaryClass.Vendor_Number = vendor_id;
            objPO_SummaryClass.Total_Cost = total_cst;
            objPO_SummaryClass.Terms = txt_terms.Text;
            objPO_SummaryClass.Due_Date = Convert.ToDateTime(dp_po_due_date.SelectedDate);
            objPO_SummaryClass.Ship_Via = txt_ship_via.Text;
            objPO_SummaryClass.ShipTo_1 = txt_ship_to1.Text;
            objPO_SummaryClass.ShipTo_2 = txt_ship_to2.Text;
            objPO_SummaryClass.ShipTo_3 = txt_ship_to3.Text;
            objPO_SummaryClass.ShipTo_4 = txt_ship_to4.Text;
            objPO_SummaryClass.ShipTo_5 = txt_ship_to5.Text;
            objPO_SummaryClass.Instructions = txt_instructions.Text;
            objPO_SummaryClass.Status = stats;
            objPO_SummaryClass.Last_Modified = DateTime.Today;
            objPO_SummaryClass.ExpectedAmountToReceive = Convert.ToInt32(txt_expet_amont.Text);
            objPO_SummaryClass.POType = typ.set_order_type;
            objPOSManagementService.insertPOSummary(objPO_SummaryClass);
           
            //string str_qury = "insert into PO_Summary(PO_Number,Store_ID,DateTime,Reference,Vendor_Number,Total_Cost,Terms,Due_Date,Ship_Via,ShipTo_1,ShipTo_2,ShipTo_3,ShipTo_4,ShipTo_5,Instructions,Status,Last_Modified,ExpectedAmountToReceive,POType) values('" + maxid + "', '1001', '" + DateTime.Today + "','" + txt_reference.Text + "','" + vendor_id + "','" + total_cst + "','" + txt_terms.Text + "','" + dp_po_due_date.SelectedDate + "','" + txt_ship_via.Text + "','" + txt_ship_to1.Text + "','" + txt_ship_to2.Text + "','" + txt_ship_to3.Text + "','" + txt_ship_to4.Text + "','" + txt_ship_to5.Text + "','" + txt_instructions.Text + "','" + stats + "','" + DateTime.Today + "','" + Convert.ToInt32(txt_expet_amont.Text) + "','" + typ.set_order_type + "')";
            //glo.fun_insert(str_qury);
            if (objPO_SummaryClass.IsSuccessfull == true)
            {
                PO_DetailsClass objPODetailClass = new PO_DetailsClass();
                for (int i = 0; i < Dg_po_items.Rows.Count; i++)
                {
                    string item_no = Dg_po_items.Rows[i].Cells[1].Value.ToString();
                    int line_no = Convert.ToInt32(Dg_po_items.Rows[i].Cells[0].Value);
                    decimal qty_ordered = Convert.ToDecimal(Dg_po_items.Rows[i].Cells[4].Value);
                    double cost = Convert.ToDouble(Dg_po_items.Rows[i].Cells[7].Value);
                    decimal qty_received = Convert.ToDecimal(Dg_po_items.Rows[i].Cells[9].Value);
                    int per_case = Convert.ToInt32(Dg_po_items.Rows[i].Cells[5].Value);
                    decimal no_per_case = Convert.ToDecimal(Dg_po_items.Rows[i].Cells[6].Value);
                    decimal qty_demage = Convert.ToDecimal(Dg_po_items.Rows[i].Cells[10].Value);
                    objPODetailClass.PO_Number = objPO_SummaryClass.PO_Number;
                    objPODetailClass.ItemNum = item_no;
                    objPODetailClass.LineNum = line_no;
                    objPODetailClass.Quan_Ordered = qty_ordered;
                    objPODetailClass.CostPer = cost;
                    objPODetailClass.Quan_Received = qty_received;
                    objPODetailClass.CasePack = per_case;
                    objPODetailClass.Store_ID = "1001";
                    objPODetailClass.NumberPerCase = no_per_case;
                    objPODetailClass.Quan_Damaged = qty_demage;
                    objPODetailClass.destStore_ID = Convert.ToString(cmb_dest_storeid.SelectedValue);
                    objPOSManagementService.insertPoDetail(objPODetailClass);
                    //string qury_detail = "insert into PO_Details(PO_Number,ItemNum,LineNum,Quan_Ordered,CostPer,Quan_Received,CasePack,Store_ID,NumberPerCase,Quan_Damaged,destStore_ID) values('" + maxid + "', '" + item_no + "','" + line_no + "','" + qty_ordered + "','" + cost + "','" + qty_received + "','" + per_case + "','1001','" + no_per_case + "','" + qty_demage + "','" + cmb_dest_storeid.SelectedValue + "')";
                    //glo.fun_insert(qury_detail);
                }
            }
            Dg_po_items.Rows.Clear();
            Grid_po1.Visibility = Visibility.Visible;
            Grid_po2.Visibility = Visibility.Hidden;
            fun_dg_purch_order();
        }

        //function to fill the destination store id combo box
        private void fun_store_ids()
        {
            //string store = "select Store_ID, Company_Info_1, Company_Info_2,Company_Info_3 from Setup";
            DataTable dt_s = objPOSManagementService.GetStores();
            if (dt_s.Rows.Count > 0)
            {
                for (int i = 0; i < dt_s.Rows.Count; i++)
                {
                    cmb_dest_storeid.Items.Add(dt_s.Rows[i]["Store_ID"].ToString());
                }
            }
        }

        //function to retrive data from po_detail
        private void fun_retrive_po_detail(int po_id)
        {
            lbl_po_no.Content = "PO# " + po_id.ToString();
           // string qrry = "select * from PO_Details where PO_Number = '" + po_id + "' order by LineNum";
            DataTable dt_po_detail = objPOSManagementService.getPoDetail(po_id);
            cmb_dest_storeid.SelectedItem = dt_po_detail.Rows[0]["destStore_ID"].ToString();
            for (int j = 0; j < dt_po_detail.Rows.Count; j++)
            {
                Dg_po_items.Rows.Add();
                Dg_po_items.Rows[j].Cells[0].Value = dt_po_detail.Rows[j]["LineNum"].ToString();
                Dg_po_items.Rows[j].Cells[1].Value = dt_po_detail.Rows[j]["ItemNum"].ToString();

                Dg_po_items.Rows[j].Cells[3].Value = dt_po_detail.Rows[j]["Store_ID"].ToString();
                Dg_po_items.Rows[j].Cells[4].Value = dt_po_detail.Rows[j]["Quan_Ordered"].ToString();
                Dg_po_items.Rows[j].Cells[5].Value = dt_po_detail.Rows[j]["CasePack"].ToString();
                Dg_po_items.Rows[j].Cells[6].Value = dt_po_detail.Rows[j]["NumberPerCase"].ToString();
                Dg_po_items.Rows[j].Cells[7].Value = dt_po_detail.Rows[j]["CostPer"].ToString();

                Dg_po_items.Rows[j].Cells[9].Value = dt_po_detail.Rows[j]["Quan_Received"].ToString();
                Dg_po_items.Rows[j].Cells[10].Value = dt_po_detail.Rows[j]["Quan_Damaged"].ToString();
            }
            Grid_po1.Visibility = Visibility.Hidden;
            Grid_po2.Visibility = Visibility.Visible;
            btn_print.Visibility = Visibility.Visible;
            btn_print_history.Visibility = Visibility.Visible;
            btn_receive_all.Visibility = Visibility.Visible;
            btn_receive_item.Visibility = Visibility.Visible;
            btn_receive_damage.Visibility = Visibility.Visible;
            btn_receving_screen.Visibility = Visibility.Visible;
            btn_save.IsEnabled = false;
            btn_update.IsEnabled = true;

            //string qury = "select * from PO_Summary where PO_Number = '" + po_id + "'";
            DataTable dtt = objPOSManagementService.getPoSummary(po_id);

            if (Convert.ToInt32(dtt.Rows[0]["POType"]).Equals(0))
            {
                otype = "Standard";
            }
            else if (Convert.ToInt32(dtt.Rows[0]["POType"]).Equals(1))
            {
                otype = "ReturnToVendor";
            }
            txt_order_type.Text = otype;
            txt_ship_via.Text = dtt.Rows[0]["Ship_Via"].ToString();
            txt_reference.Text = dtt.Rows[0]["Reference"].ToString();
            txt_terms.Text = dtt.Rows[0]["Terms"].ToString();
            dp_po_due_date.SelectedDate = Convert.ToDateTime(dtt.Rows[0]["Due_Date"]);
            txt_ship_to1.Text = dtt.Rows[0]["ShipTo_1"].ToString();
            txt_ship_to2.Text = dtt.Rows[0]["ShipTo_2"].ToString();
            txt_ship_to3.Text = dtt.Rows[0]["ShipTo_3"].ToString();
            txt_ship_to4.Text = dtt.Rows[0]["ShipTo_4"].ToString();
            txt_ship_to5.Text = dtt.Rows[0]["ShipTo_5"].ToString();
            txt_instructions.Text = dtt.Rows[0]["Instructions"].ToString();

            for (int t = 0; t < lstb_ven_list.Items.Count; t++)
            {
                string[] st_split = lstb_ven_list.Items[t].ToString().Split(' ');
                if (st_split[0].ToString() == dtt.Rows[0]["Vendor_Number"].ToString())
                {
                    lstb_ven_list.SelectedIndex = t;
                }
            }
            if (rb_close.IsChecked == true)
            {
                btn_save.IsEnabled = false;
                btn_update.IsEnabled = false;
                btn_close.IsEnabled = false;
                btn_order_item.IsEnabled = false;
                btn_add_new_itm.IsEnabled = false;
                btn_add_sel_item.IsEnabled = false;
                btn_receive_all.Visibility = Visibility.Hidden;
                btn_receive_item.Visibility = Visibility.Hidden;
                btn_receive_damage.Visibility = Visibility.Hidden;
                btn_print.Visibility = Visibility.Visible;
                btn_print_history.Visibility = Visibility.Visible;

            }
            fun_cal_row_total();
        }

        private void fun_clear_field()
        {
            txt_enter_item.Clear();
            txt_expet_amont.Clear();
            txt_instructions.Clear();
            txt_order_type.Clear();
            txt_reference.Clear();
            txt_ship_to1.Clear();
            txt_ship_to2.Clear();
            txt_ship_to3.Clear();
            txt_ship_to4.Clear();
            txt_ship_to5.Clear();
            txt_ship_via.Clear();
            txt_terms.Clear();
            dp_po_due_date.SelectedDate = DateTime.Today;
            Dg_po_items.Rows.Clear();

        }


        private void btn_add_save_Click(object sender, RoutedEventArgs e)
        {
            OrderTypeForm type = new OrderTypeForm();
            type.ShowDialog();
            if (type.set_order_type.Equals(-1))
            {
                return;
            }
            fun_clear_field();
            if (type.set_order_type.Equals(1))
            {
                DataGridViewColumn coll = new DataGridViewTextBoxColumn();
                coll.Width = 100;
                Dg_po_items.Columns.Add(coll);
                coll.HeaderText = "Reason";
                txt_order_type.Text = "ReturnToVendor";
            }
            else if (type.set_order_type.Equals(0))
            {
                txt_order_type.Text = "Standard";
            }

            Grid_po1.Visibility = Visibility.Hidden;
            Grid_po2.Visibility = Visibility.Visible;
            btn_print.Visibility = Visibility.Hidden;
            btn_print_history.Visibility = Visibility.Hidden;
            btn_receive_all.Visibility = Visibility.Visible;
            btn_receive_item.Visibility = Visibility.Visible;
            btn_receive_damage.Visibility = Visibility.Visible;
            btn_save.IsEnabled = true;
            btn_update.IsEnabled = false;
        }

        private void fun_fill_vendor_list()
        {
            //string ven_qury = "select Vendor_Number +' - '+ Company as vendor from Vendors";
            DataTable dt = objPOSManagementService.getVendorRecords();
            //DataTable dt = glo.getdata(ven_qury);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lstb_ven_list.Items.Add(dt.Rows[i]["Vendor_Number"].ToString() + " - " + dt.Rows[i]["Company"].ToString());
            }
        }

        private void fun_dg_purch_order()
        {
            DG_purchase_order.Rows.Clear();

            if (rb_open.IsChecked == true)
            {
                status = "O";
            }
            else if (rb_close.IsChecked == true)
            {
                status = "C";
            }
            if (rb_standard.IsChecked == true)
            {
                type = 0;
            }
            else if (rb_return.IsChecked == true)
            {
                type = 1;
            }
            else if (rb_direct_store.IsChecked == true)
            {
                type = 2;
            }
           // string order = "select PO_Number, [DateTime], Reference, Vendor_Number, Due_Date, Total_Cost, Status, POType, Store_ID from PO_Summary where Status = '" + status + "' and POType = '" + type + "'";
            PO_SummaryClass objPoSummaryClass = new PO_SummaryClass();
            objPoSummaryClass.POType = type;
            objPoSummaryClass.Status = status;
            DataTable dt_order = objPOSManagementService.getPoSummaryByType(objPoSummaryClass);
            for (int x = 0; x < dt_order.Rows.Count; x++)
            {
                DG_purchase_order.Rows.Add();
                DG_purchase_order.Rows[x].Cells[0].Value = dt_order.Rows[x]["PO_Number"].ToString();
                DG_purchase_order.Rows[x].Cells[1].Value = dt_order.Rows[x]["DateTime"].ToString();
                DG_purchase_order.Rows[x].Cells[2].Value = dt_order.Rows[x]["Reference"].ToString();
                DG_purchase_order.Rows[x].Cells[3].Value = dt_order.Rows[x]["Vendor_Number"].ToString();
                DG_purchase_order.Rows[x].Cells[4].Value = dt_order.Rows[x]["Due_Date"].ToString();
                DG_purchase_order.Rows[x].Cells[5].Value = dt_order.Rows[x]["Total_Cost"].ToString();
                DG_purchase_order.Rows[x].Cells[6].Value = dt_order.Rows[x]["Status"].ToString();
                DG_purchase_order.Rows[x].Cells[7].Value = dt_order.Rows[x]["POType"].ToString();
                DG_purchase_order.Rows[x].Cells[8].Value = dt_order.Rows[x]["Store_ID"].ToString();
            }

        }

        private void fun_fill_inventory_dg(string flage, string str)
        {

            //DataTable dtt = glo.getdata(str);
            DataTable dtt = objPOSManagementService.FilterData("", str);
            for (int c = 0; c < dtt.Rows.Count; c++)
            {
                DG_itemlist.Rows.Add();
                DG_itemlist.Rows[c].Cells[0].Value = dtt.Rows[c]["ItemNum"].ToString();
                DG_itemlist.Rows[c].Cells[1].Value = dtt.Rows[c]["ItemName"].ToString();
                DG_itemlist.Rows[c].Cells[2].Value = dtt.Rows[c]["Vendor_Part_Num"].ToString();
                DG_itemlist.Rows[c].Cells[3].Value = dtt.Rows[c]["In_Stock"].ToString();
                DG_itemlist.Rows[c].Cells[4].Value = dtt.Rows[c]["Reorder_Level"].ToString();
                DG_itemlist.Rows[c].Cells[5].Value = dtt.Rows[c]["Reorder_Quantity"].ToString();
                DG_itemlist.Rows[c].Cells[6].Value = dtt.Rows[c]["Cost"].ToString();
                DG_itemlist.Rows[c].Cells[7].Value = dtt.Rows[c]["CostPer"].ToString();
                DG_itemlist.Rows[c].Cells[8].Value = dtt.Rows[c]["Case_Cost"].ToString();
                DG_itemlist.Rows[c].Cells[9].Value = dtt.Rows[c]["NumPerVenCase"].ToString();
                DG_itemlist.Rows[c].Cells[10].Value = dtt.Rows[c]["Vendor_Number"].ToString();

            }
        }

        private void fun_fill_vender_combo()
        {
            //string str_ven = "select Vendor_Number+'-'+Company as vendorr from Vendors";
            DataTable ven_dt = objPOSManagementService.getVendorRecords();
            for (int v = 0; v < ven_dt.Rows.Count; v++)
            {
                //cmb_select_vendor.Items.Add(ven_dt.Rows[v]["vendorr"].ToString());
                cmb_select_vendor.Items.Add(ven_dt.Rows[v]["Vendor_Number"].ToString() + "-" + ven_dt.Rows[v]["Company"]);
            }
        }

        private void fun_cal_row_total()
        {
            double total_cost_orderd = 0;
            double total_amnt_receive = 0;
            double cost_rec_rowise = 0;
            for (int x = 0; x < Dg_po_items.Rows.Count; x++)
            {
                double ordered_qty = Convert.ToDouble(Dg_po_items.Rows[x].Cells[4].Value);
                double cases_ordered = Convert.ToDouble(Dg_po_items.Rows[x].Cells[5].Value);
                double percase = Convert.ToDouble(Dg_po_items.Rows[x].Cells[6].Value);
                double cost = Convert.ToDouble(Dg_po_items.Rows[x].Cells[7].Value);
                if (cases_ordered == 0 && percase == 0)
                {
                    Dg_po_items.Rows[x].Cells[8].Value = (ordered_qty * cost).ToString();
                }
                else
                {
                    Dg_po_items.Rows[x].Cells[4].Value = (cases_ordered * percase).ToString();
                    Dg_po_items.Rows[x].Cells[8].Value = (cases_ordered * cost).ToString();
                }
            }

            for (int sum = 0; sum < Dg_po_items.Rows.Count; sum++)
            {
                total_cost_orderd = total_cost_orderd + Convert.ToDouble(Dg_po_items.Rows[sum].Cells[8].Value);
            }
            lbl_total_cost_order.Content = "Total Cost Ordered = " + (total_cost_orderd).ToString();
            for (int am = 0; am < Dg_po_items.Rows.Count; am++)
            {
                total_amnt_receive = total_amnt_receive + Convert.ToDouble(Dg_po_items.Rows[am].Cells[9].Value);
            }
            if (txt_expet_amont.Text == "")
            {
                txt_expet_amont.Text = "0";
            }
            double amount_balance = Convert.ToDouble(txt_expet_amont.Text) - total_amnt_receive;
            lbl_amount_remaning.Content = "Amount Remaining: " + amount_balance.ToString();

            for (int cost = 0; cost < Dg_po_items.Rows.Count; cost++)
            {
                if (Convert.ToDouble(Dg_po_items.Rows[cost].Cells[5].Value) == 0 || Convert.ToDouble(Dg_po_items.Rows[cost].Cells[6].Value) == 0)
                {
                    cost_rec_rowise = cost_rec_rowise + (Convert.ToDouble(Dg_po_items.Rows[cost].Cells[7].Value) * Convert.ToDouble(Dg_po_items.Rows[cost].Cells[9].Value));
                }
                else
                {
                    cost_rec_rowise = cost_rec_rowise + ((Convert.ToDouble(Dg_po_items.Rows[cost].Cells[9].Value) / Convert.ToDouble(Dg_po_items.Rows[cost].Cells[6].Value)) * Convert.ToDouble(Dg_po_items.Rows[cost].Cells[7].Value));
                }
            }

            lbl_total_cost_received.Content = "Total Cost Received: " + cost_rec_rowise.ToString();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rb_open.IsChecked = true;
            rb_standard.IsChecked = true;
            fun_fill_vendor_list();
            fun_dg_purch_order();
            fun_store_ids();
           // fun_fill_inventory_dg("select * from VIEW_INVEN_PURCH_ORDER");
            fun_fill_inventory_dg("", "");
            fun_fill_vender_combo();
            Grid_po1.Visibility = Visibility.Visible;
            Grid_po2.Visibility = Visibility.Hidden;
            btn_print.Visibility = Visibility.Hidden;
            btn_print_history.Visibility = Visibility.Hidden;
            btn_receive_all.Visibility = Visibility.Hidden;
            btn_receive_item.Visibility = Visibility.Hidden;
            btn_receive_damage.Visibility = Visibility.Hidden;
            btn_receving_screen.Visibility = Visibility.Hidden;
        }

        private void rb_open_Checked(object sender, RoutedEventArgs e)
        {
            DG_purchase_order.Rows.Clear();
            fun_dg_purch_order();
        }

        private void rb_close_Checked(object sender, RoutedEventArgs e)
        {
            DG_purchase_order.Rows.Clear();
            fun_dg_purch_order();
        }

        private void rb_standard_Checked(object sender, RoutedEventArgs e)
        {
            DG_purchase_order.Rows.Clear();
            fun_dg_purch_order();
        }

        private void rb_direct_store_Checked(object sender, RoutedEventArgs e)
        {
            DG_purchase_order.Rows.Clear();
            fun_dg_purch_order();
        }

        private void rb_return_Checked(object sender, RoutedEventArgs e)
        {
            DG_purchase_order.Rows.Clear();
            fun_dg_purch_order();
        }

        private void Dg_po_items_DoubleClick(object sender, EventArgs e)
        {

        }

        private void fun_selct_item_po(string id)
        {
           // string stadard = "select * from Inventory where ItemNum = '" + id + "' and ItemType = 0";
            InventoryClass objInventoryClass = new InventoryClass();
            objInventoryClass.ItemNum = id;
            objInventoryClass.ItemType = 0;
            DataTable dt_chek = objPOSManagementService.CheckStandardItem(objInventoryClass);
            if (dt_chek.Rows.Count == 0)
            {
                System.Windows.MessageBox.Show("You Can Add only Standard Items For Purchase Order", "Warning", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
                return;
            }
            string[] spl_str = lstb_ven_list.SelectedItem.ToString().Split(' ');
            string ven_id = spl_str[0];
        end: { }
           // string qruy = "SELECT * FROM VIEW_DETAIL_PO WHERE ItemNum = '" + id + "' and Vendor_Number = '" + ven_id + "'";
            //DataTable dt_po = glo.getdata(qruy);
            //if (dt_po.Rows.Count > 0)
            //{
            //    Dg_po_items.Rows.Add();
            //    Dg_po_items.Rows[Dg_po_items.Rows.Count - 1].Cells[0].Value = Dg_po_items.Rows.Count.ToString();
            //    Dg_po_items.Rows[Dg_po_items.Rows.Count - 1].Cells[1].Value = dt_po.Rows[0]["ItemNum"].ToString();
            //    Dg_po_items.Rows[Dg_po_items.Rows.Count - 1].Cells[2].Value = dt_po.Rows[0]["ItemName"].ToString();
            //    Dg_po_items.Rows[Dg_po_items.Rows.Count - 1].Cells[3].Value = dt_po.Rows[0]["Store_ID"].ToString();
            //    Dg_po_items.Rows[Dg_po_items.Rows.Count - 1].Cells[4].Value = dt_po.Rows[0]["Reorder_Quantity"].ToString();
            //    Dg_po_items.Rows[Dg_po_items.Rows.Count - 1].Cells[5].Value = dt_po.Rows[0]["NumPerVenCase"].ToString();
            //    Dg_po_items.Rows[Dg_po_items.Rows.Count - 1].Cells[6].Value = "0";
            //    Dg_po_items.Rows[Dg_po_items.Rows.Count - 1].Cells[7].Value = dt_po.Rows[0]["Case_Cost"].ToString();
            //    Dg_po_items.Rows[Dg_po_items.Rows.Count - 1].Cells[9].Value = "0";
            //    Dg_po_items.Rows[Dg_po_items.Rows.Count - 1].Cells[10].Value = "0";
            //}
            //else
            //{
            //    vendor_no = spl_str[0];
            //    vendor_name = spl_str[2];
            //    item_no = id;
            //    MsgForm obj = new MsgForm();
            //    obj.ShowDialog();
            //    EnterVendorFrm v = new EnterVendorFrm();
            //    if (v.set_cancel == 1 || obj.set_cancl == 1)
            //    {
            //        string qry = "select ItemNum, ItemName,Store_ID, Cost from inventory where ItemNum = '" + id + "'";
            //        DataTable dt_item = glo.getdata(qry);
            //        Dg_po_items.Rows.Add();
            //        Dg_po_items.Rows[Dg_po_items.Rows.Count - 1].Cells[0].Value = Dg_po_items.Rows.Count.ToString();
            //        Dg_po_items.Rows[Dg_po_items.Rows.Count - 1].Cells[1].Value = dt_item.Rows[0]["ItemNum"].ToString();
            //        Dg_po_items.Rows[Dg_po_items.Rows.Count - 1].Cells[2].Value = dt_item.Rows[0]["ItemName"].ToString();
            //        Dg_po_items.Rows[Dg_po_items.Rows.Count - 1].Cells[3].Value = dt_item.Rows[0]["Store_ID"].ToString();
            //        Dg_po_items.Rows[Dg_po_items.Rows.Count - 1].Cells[4].Value = "1";
            //        Dg_po_items.Rows[Dg_po_items.Rows.Count - 1].Cells[5].Value = "0";
            //        Dg_po_items.Rows[Dg_po_items.Rows.Count - 1].Cells[6].Value = "0";
            //        Dg_po_items.Rows[Dg_po_items.Rows.Count - 1].Cells[7].Value = dt_item.Rows[0]["Cost"].ToString();
            //        Dg_po_items.Rows[Dg_po_items.Rows.Count - 1].Cells[9].Value = "0";
            //        Dg_po_items.Rows[Dg_po_items.Rows.Count - 1].Cells[10].Value = "0";
            //    }
            //    else
            //    {
            //        goto end;
            //    }
            //}
            fun_cal_row_total();
        }

        private void DG_itemlist_DoubleClick(object sender, EventArgs e)
        {
            if (lstb_ven_list.SelectedItem == null)
            {
                System.Windows.MessageBox.Show("Please Select a Vendor Before Ordering the Item", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string id = DG_itemlist.CurrentRow.Cells[0].Value.ToString();
            fun_selct_item_po(id);
        }

        public string set_vendor_name
        {
            get { return vendor_name; }
            set { vendor_name = value; }
        }

        public string set_vendor_no
        {
            get { return vendor_no; }
            set { vendor_no = value; }
        }

        public string set_item_no
        {
            get { return item_no; }
            set { item_no = value; }
        }

        private void cmb_select_vendor_DropDownClosed(object sender, EventArgs e)
        {
            string[] str = cmb_select_vendor.Text.Split('-');
            string str1 = str[0];
            DG_itemlist.Rows.Clear();
            //fun_fill_inventory_dg("select * from VIEW_INVEN_PURCH_ORDER where Vendor_Number = '" + str1 + "'");
            fun_fill_inventory_dg("Vendor_Number", str1);
        }

        private void btn_search_item_Click(object sender, RoutedEventArgs e)
        {
            if (lstb_ven_list.SelectedItem == null)
            {
                System.Windows.MessageBox.Show("Please Select a Vendor Before Ordering the Item", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DG_itemlist.Rows.Clear();
            SearchInventoryForm search = new SearchInventoryForm();
            search.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            search.ShowDialog();
            if (search.set_item_id != null)
            {
                fun_selct_item_po(search.set_item_id);
            }
            search.set_item_id = null;
        }

        private void btn_filter_itm_Click(object sender, RoutedEventArgs e)
        {
            DG_itemlist.Rows.Clear();
            Keyboard kb = new Keyboard("Enter The Item Number You Would Like To Search For");
            kb.ShowDialog();
            if (kb.set_decrep != null)
            {
                //fun_fill_inventory_dg("select * from VIEW_INVEN_PURCH_ORDER where ItemNum = '" + kb.set_decrep + "'");
                fun_fill_inventory_dg("ItemNum", kb.set_decrep);
            }
            kb.set_decrep = null;
        }

        private void btn_find_part_Click(object sender, RoutedEventArgs e)
        {
            DG_itemlist.Rows.Clear();
            Keyboard kb = new Keyboard("Enter The Part Number You Would Like To Search For");
            kb.ShowDialog();
            if (kb.set_decrep != null)
            {
               // fun_fill_inventory_dg("select * from VIEW_INVEN_PURCH_ORDER where Vendor_Part_Num = '" + kb.set_decrep + "'");
                fun_fill_inventory_dg("Vendor_Part_Num", kb.set_decrep);
            }
            kb.set_decrep = null;

        }

        private void btn_show_all_Click(object sender, RoutedEventArgs e)
        {
            DG_itemlist.Rows.Clear();
           // fun_fill_inventory_dg("select * from VIEW_INVEN_PURCH_ORDER");
            fun_fill_inventory_dg("", "");
        }

        private void Dg_po_items_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(4))
            {
                if (Dg_po_items.CurrentRow.Cells[5].Value.Equals("0") && Dg_po_items.CurrentRow.Cells[6].Value.Equals("0"))
                {
                    NumberKeypaid kp = new NumberKeypaid(9, Dg_po_items.CurrentRow.Cells[4].Value.ToString());
                    kp.ShowDialog();
                    if (kp.set_cash_reg_price != null)
                    {
                        Dg_po_items.CurrentRow.Cells[4].Value = kp.set_cash_reg_price.ToString();
                    }
                    kp.set_cash_reg_price = null;
                    fun_cal_row_total();
                }
            }
            if (e.ColumnIndex.Equals(5))
            {
                if (!Dg_po_items.CurrentRow.Cells[5].Value.Equals("0") || !Dg_po_items.CurrentRow.Cells[6].Value.Equals("0"))
                {
                    NumberKeypaid kp = new NumberKeypaid(9, Dg_po_items.CurrentRow.Cells[5].Value.ToString());
                    kp.ShowDialog();
                    if (kp.set_cash_reg_price != null)
                    {
                        Dg_po_items.CurrentRow.Cells[5].Value = kp.set_cash_reg_price.ToString();
                    }
                    kp.set_cash_reg_price = null;
                    fun_cal_row_total();
                }
            }
            if (e.ColumnIndex.Equals(6))
            {
                if (!Dg_po_items.CurrentRow.Cells[5].Value.Equals("0") || !Dg_po_items.CurrentRow.Cells[6].Value.Equals("0"))
                {
                    NumberKeypaid kp = new NumberKeypaid(9, Dg_po_items.CurrentRow.Cells[6].Value.ToString());
                    kp.ShowDialog();
                    if (kp.set_cash_reg_price != null)
                    {
                        Dg_po_items.CurrentRow.Cells[6].Value = kp.set_cash_reg_price.ToString();
                    }
                    kp.set_cash_reg_price = null;
                    fun_cal_row_total();
                }
            }
            fun_cal_row_total();
        }

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int id = Convert.ToInt32(DG_purchase_order.CurrentRow.Cells[0].Value);
                fun_retrive_po_detail(id);

            }
            catch (Exception)
            { }
        }

        private void DG_purchase_order_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int id = Convert.ToInt32(DG_purchase_order.CurrentRow.Cells[0].Value);
                fun_retrive_po_detail(id);
            }
            catch (Exception)
            { }
        }

        private void btn_add_new_itm_Click(object sender, RoutedEventArgs e)
        {
            InventoryForm ifrm = new InventoryForm("PO");
            ifrm.ShowDialog();
            if (lstb_ven_list.SelectedItems.Count == 0)
            {
                System.Windows.MessageBox.Show("Please Select a Vendor Before Ordering the Item", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (ifrm.set_item_id != null)
            {
                fun_selct_item_po(ifrm.set_item_id);
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            Grid_po2.Visibility = Visibility.Hidden;
            Grid_po1.Visibility = Visibility.Visible;
            btn_print.Visibility = Visibility.Hidden;
            btn_print_history.Visibility = Visibility.Hidden;
            btn_receive_all.Visibility = Visibility.Hidden;
            btn_receive_item.Visibility = Visibility.Hidden;
            btn_receive_damage.Visibility = Visibility.Hidden;
            btn_receving_screen.Visibility = Visibility.Hidden;
            btn_save.IsEnabled = true;
            btn_update.IsEnabled = true;
            btn_close.IsEnabled = true;
            btn_order_item.IsEnabled = true;
            btn_add_new_itm.IsEnabled = true;
            btn_add_sel_item.IsEnabled = true;
            fun_clear_field();
            lbl_po_no.Content = "";
            lbl_total_cost_received.Content = "";
            lbl_total_cost_order.Content = "";
            lbl_amount_remaning.Content = "";
            lstb_ven_list.SelectedItem = null;
        }

        private void txt_enter_item_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (lstb_ven_list.SelectedItem == null)
                {
                    System.Windows.MessageBox.Show("Please Select a Vendor Before Ordering the Item", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (txt_enter_item.Text == "")
                {
                    System.Windows.MessageBox.Show("Please Enter Item Number", "Warning", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
                    return;
                }
                string item_id = txt_enter_item.Text;
              //  string str = "select * from Inventory where ItemNum ='" + item_id + "'";
                DataTable dtt = objPOSManagementService.getIventory(item_id);
                if (dtt.Rows.Count == 0)
                {
                    System.Windows.MessageBox.Show("This Item Not Found Please Try Again", "Warning", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
                    txt_enter_item.Clear();
                    txt_enter_item.Focus();
                    return;
                }
                fun_selct_item_po(item_id);
            }
        }

        private void btn_add_sel_item_Click(object sender, RoutedEventArgs e)
        {
            if (lstb_ven_list.SelectedItem == null)
            {
                System.Windows.MessageBox.Show("Please Select a Vendor Before Ordering the Item", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (DG_itemlist.SelectedRows.Count > 0)
            {
                string id = DG_itemlist.CurrentRow.Cells[0].Value.ToString();
                fun_selct_item_po(id);
            }
        }

        private void btn_receive_item_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selected_line = Dg_po_items.CurrentRow.Cells[0].Value.ToString();
                NumberKeypaid kb = new NumberKeypaid(21, selected_line);
                kb.ShowDialog();
                if (kb.set_line_no != null)
                {
                    if (Convert.ToInt32(kb.set_line_no) > Dg_po_items.Rows.Count)
                    {
                        System.Windows.MessageBox.Show("You Have Entered an invalid Line number, Try again", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        kb.set_line_no = null;
                        return;
                    }
                    if (Dg_po_items.Rows[Convert.ToInt32(kb.set_line_no) - 1].Cells[5].Value.Equals("0") && Dg_po_items.Rows[Convert.ToInt32(kb.set_line_no) - 1].Cells[6].Value.Equals("0"))
                    {
                        string qty_sel = Dg_po_items.Rows[Convert.ToInt32(kb.set_line_no) - 1].Cells[4].Value.ToString();
                        NumberKeypaid kbk = new NumberKeypaid(22, qty_sel);
                        kbk.ShowDialog();
                        if (kbk.set_qty_rec_damg != null)
                        {
                            if (Convert.ToInt32(kbk.set_qty_rec_damg) > Convert.ToInt32(qty_sel))
                            {
                                System.Windows.MessageBox.Show("The Quantity Received Cannot Exceed the Quantity Ordered", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                kb.set_line_no = null;
                                kbk.set_qty_rec_damg = null;
                                return;
                            }
                            double old_sum = Convert.ToDouble(Dg_po_items.Rows[Convert.ToInt32(kb.set_line_no) - 1].Cells[9].Value);
                            double total = Convert.ToDouble(kbk.set_qty_rec_damg) + old_sum;
                            Dg_po_items.Rows[Convert.ToInt32(kb.set_line_no) - 1].Cells[9].Value = total.ToString();
                        }
                    }
                    else
                    {
                        QuestionBoxEOC eoc = new QuestionBoxEOC();
                        eoc.ShowDialog();
                        if (eoc.set_eaches_cases.Equals(0))
                        {
                            string qty_sel = Dg_po_items.Rows[Convert.ToInt32(kb.set_line_no) - 1].Cells[4].Value.ToString();
                            NumberKeypaid kbk = new NumberKeypaid(22, qty_sel);
                            kbk.ShowDialog();
                            if (kbk.set_qty_rec_damg != null)
                            {
                                if (Convert.ToInt32(kbk.set_qty_rec_damg) > Convert.ToInt32(qty_sel))
                                {
                                    System.Windows.MessageBox.Show("The Quantity Received Cannot Exceed the Quantity Ordered", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                    kb.set_line_no = null;
                                    kbk.set_qty_rec_damg = null;
                                    return;
                                }
                                double old_qty = Convert.ToDouble(Dg_po_items.Rows[Convert.ToInt32(kb.set_line_no) - 1].Cells[9].Value);
                                double sum_total = Convert.ToDouble(kbk.set_qty_rec_damg) + old_qty;
                                Dg_po_items.Rows[Convert.ToInt32(kb.set_line_no) - 1].Cells[9].Value = sum_total.ToString();
                            }
                        }
                        else if (eoc.set_eaches_cases.Equals(1))
                        {
                            string qty_cases = Dg_po_items.Rows[Convert.ToInt32(kb.set_line_no) - 1].Cells[5].Value.ToString();
                            NumberKeypaid kbk = new NumberKeypaid(22, qty_cases);
                            kbk.ShowDialog();
                            if (kbk.set_qty_rec_damg != null)
                            {
                                if (Convert.ToInt32(kbk.set_qty_rec_damg) > Convert.ToInt32(qty_cases))
                                {
                                    System.Windows.MessageBox.Show("The Quantity Received Cannot Exceed the Quantity Ordered", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                    kb.set_line_no = null;
                                    kbk.set_qty_rec_damg = null;
                                    return;
                                }
                                double old_recd = Convert.ToDouble(Dg_po_items.Rows[Convert.ToInt32(kb.set_line_no) - 1].Cells[9].Value);
                                double sum_qty = (Convert.ToDouble(kbk.set_qty_rec_damg) * Convert.ToDouble(Dg_po_items.Rows[Convert.ToInt32(kb.set_line_no) - 1].Cells[6].Value)) + old_recd;
                                Dg_po_items.Rows[Convert.ToInt32(kb.set_line_no) - 1].Cells[9].Value = sum_qty.ToString();
                            }
                        }
                    }
                }
                kb.set_line_no = null;
                kb.set_qty_rec_damg = null;
                fun_cal_row_total();
            }
            catch (Exception)
            { }
        }

        private void btn_receive_damage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selected_line = Dg_po_items.CurrentRow.Cells[0].Value.ToString();
                NumberKeypaid kb = new NumberKeypaid(23, selected_line);
                kb.ShowDialog();
                if (kb.set_line_no != null)
                {
                    if (Convert.ToInt32(kb.set_line_no) > Dg_po_items.Rows.Count)
                    {
                        System.Windows.MessageBox.Show("You Have Entered an invalid Line number, Try again", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        kb.set_line_no = null;
                        kb.set_qty_rec_damg = null;
                        return;
                    }
                    NumberKeypaid kbk = new NumberKeypaid(24, "0");
                    kbk.ShowDialog();
                    if (kbk.set_qty_rec_damg != null)
                    {
                        double qt1 = Convert.ToDouble(Dg_po_items.Rows[Convert.ToInt32(kb.set_line_no) - 1].Cells[9].Value);
                        double qt2 = Convert.ToDouble(Dg_po_items.Rows[Convert.ToInt32(kb.set_line_no) - 1].Cells[10].Value);
                        if (Convert.ToDouble(kbk.set_qty_rec_damg) + qt2 > qt1)
                        {
                            System.Windows.MessageBox.Show("The Quantity Damamaged Cannot Exceed The Quantity Received", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            kb.set_line_no = null;
                            kbk.set_qty_rec_damg = null;
                            return;
                        }
                        double sum_qty = Convert.ToDouble(kbk.set_qty_rec_damg) + qt2;
                        Dg_po_items.Rows[Convert.ToInt32(kb.set_line_no) - 1].Cells[10].Value = sum_qty.ToString();
                    }
                }
                kb.set_qty_rec_damg = null;
                kb.set_line_no = null;
                fun_cal_row_total();
            }
            catch (Exception)
            { }
        }

        private void btn_receive_all_Click(object sender, RoutedEventArgs e)
        {
            for (int r = 0; r < Dg_po_items.Rows.Count; r++)
            {
                if (Dg_po_items.Rows[r].Cells[4].Value != null)
                {
                    Dg_po_items.Rows[r].Cells[9].Value = Dg_po_items.Rows[r].Cells[4].Value;
                }
            }
            if (Dg_po_items.Rows.Count > 0)
            {
                fun_cal_row_total();
            }
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            string[] str = lbl_po_no.Content.ToString().Split(' ');
            int id = Convert.ToInt32(str[1]);
            string ven_num = lstb_ven_list.SelectedItem.ToString();
            string[] split = ven_num.Split(' ');
            string vendor_id = split[0];
            string lbl = lbl_total_cost_order.Content.ToString();
            string[] lbl1 = lbl.Split(' ');
            double total_cst = Convert.ToDouble(lbl1[4]);
            string stats = "O";

            //string update_summary = "update PO_Summary set Reference = '" + txt_reference.Text + "' ,Vendor_Number = '" + vendor_id + "',Total_Cost = '" + total_cst + "',Terms = '" + txt_terms.Text + "',Due_Date = '" + dp_po_due_date.SelectedDate + "',Ship_Via = '" + txt_ship_via.Text + "',ShipTo_1 = '" + txt_ship_to1.Text + "',ShipTo_2 = '" + txt_ship_to2.Text + "',ShipTo_3 = '" + txt_ship_to3.Text + "',ShipTo_4 = '" + txt_ship_to4.Text + "',ShipTo_5 = '" + txt_ship_to5.Text + "',Instructions = '" + txt_instructions.Text + "',Status = '" + stats + "',Last_Modified = '" + DateTime.Today + "' where PO_Number = '" + id + "'";
            //glo.fun_insert(update_summary);
            PO_SummaryClass objPoSummaryClass = new PO_SummaryClass();
            objPoSummaryClass.PO_Number = id;
            objPoSummaryClass.Vendor_Number = vendor_id;
            objPoSummaryClass.Store_ID = "1001";
            objPoSummaryClass.DateTime = DateTime.Today;
            objPoSummaryClass.Reference = txt_reference.Text;
            objPoSummaryClass.Vendor_Number = vendor_id;
            objPoSummaryClass.Total_Cost = total_cst;
            objPoSummaryClass.Terms = txt_terms.Text;
            objPoSummaryClass.Due_Date = Convert.ToDateTime(dp_po_due_date.SelectedDate);
            objPoSummaryClass.Ship_Via = txt_ship_via.Text;
            objPoSummaryClass.ShipTo_1 = txt_ship_to1.Text;
            objPoSummaryClass.ShipTo_2 = txt_ship_to2.Text;
            objPoSummaryClass.ShipTo_3 = txt_ship_to3.Text;
            objPoSummaryClass.ShipTo_4 = txt_ship_to4.Text;
            objPoSummaryClass.ShipTo_5 = txt_ship_to5.Text;
            objPoSummaryClass.Instructions = txt_instructions.Text;
            objPoSummaryClass.Status = stats;
            objPoSummaryClass.Last_Modified = DateTime.Today;
            objPoSummaryClass.ExpectedAmountToReceive = Convert.ToInt32(txt_expet_amont.Text);
            objPoSummaryClass.POType = typ.set_order_type;
            objPoSummaryClass.qryFlage = 1;
            objPOSManagementService.updatePoSummary(objPoSummaryClass);


            //string delete_detail = "delete from PO_Details where PO_Number = '" + id + "'";
            //glo.fun_insert(delete_detail);
            PO_DetailsClass objPoDetail = new PO_DetailsClass();
            objPoDetail.PO_Number = id;
            objPOSManagementService.deletePoDetails(objPoDetail);
            PO_DetailsClass objPODetailClass = new PO_DetailsClass();
            for (int i = 0; i < Dg_po_items.Rows.Count; i++)
            {
                string item_no = Dg_po_items.Rows[i].Cells[1].Value.ToString();
                int line_no = Convert.ToInt32(Dg_po_items.Rows[i].Cells[0].Value);
                decimal qty_ordered = Convert.ToDecimal(Dg_po_items.Rows[i].Cells[4].Value);
                double cost = Convert.ToDouble(Dg_po_items.Rows[i].Cells[7].Value);
                decimal qty_received = Convert.ToDecimal(Dg_po_items.Rows[i].Cells[9].Value);
                int per_case = Convert.ToInt32(Dg_po_items.Rows[i].Cells[5].Value);
                decimal no_per_case = Convert.ToDecimal(Dg_po_items.Rows[i].Cells[6].Value);
                decimal qty_demage = Convert.ToDecimal(Dg_po_items.Rows[i].Cells[10].Value);
                objPODetailClass.PO_Number = objPoSummaryClass.PO_Number;
                objPODetailClass.ItemNum = item_no;
                objPODetailClass.LineNum = line_no;
                objPODetailClass.Quan_Ordered = qty_ordered;
                objPODetailClass.CostPer = cost;
                objPODetailClass.Quan_Received = qty_received;
                objPODetailClass.CasePack = per_case;
                objPODetailClass.Store_ID = "1001";
                objPODetailClass.NumberPerCase = no_per_case;
                objPODetailClass.Quan_Damaged = qty_demage;
                objPODetailClass.destStore_ID = Convert.ToString(cmb_dest_storeid.SelectedValue);
                objPOSManagementService.insertPoDetail(objPODetailClass);
            //    string qury_detail = "insert into PO_Details(PO_Number,ItemNum,LineNum,Quan_Ordered,CostPer,Quan_Received,CasePack,Store_ID,NumberPerCase,Quan_Damaged,destStore_ID) values('" + id + "', '" + item_no + "','" + line_no + "','" + qty_ordered + "','" + cost + "','" + qty_received + "','" + per_case + "','1001','" + no_per_case + "','" + qty_demage + "','" + cmb_dest_storeid.SelectedValue + "')";
            //    glo.fun_insert(qury_detail);
            }
            Grid_po1.Visibility = Visibility.Visible;
            Grid_po2.Visibility = Visibility.Hidden;
            Dg_po_items.Rows.Clear();

            fun_dg_purch_order();
        }

        private void txt_expet_amont_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                fun_cal_row_total();
            }
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PO_SummaryClass objPoSummaryClass = new PO_SummaryClass();
                string[] split_pono = lbl_po_no.Content.ToString().Split(' ');
                string po_id = split_pono[1];
                objPoSummaryClass.qryFlage = 2;
                objPoSummaryClass.Status = "C";
                objPoSummaryClass.PO_Number = Convert.ToInt32(po_id);
                objPoSummaryClass.Last_Modified = DateTime.Today;
                objPOSManagementService.updatePoSummary(objPoSummaryClass);
                //string qury_close = "update PO_Summary set Status = 'C', Last_Modified = '" + DateTime.Today + "' where PO_Number = '" + po_id + "'";
                //glo.fun_insert(qury_close);
                Grid_po1.Visibility = Visibility.Visible;
                Grid_po2.Visibility = Visibility.Hidden;
                DG_purchase_order.Rows.Clear();
                fun_dg_purch_order();
            }
            catch (Exception)
            { }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lstb_ven_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string[] st_split = lstb_ven_list.SelectedItem.ToString().Split(' ');
               // string str = "select Vendor_Number, Vendor_Terms from Vendors where Vendor_Number = '" + st_split[0] + "'";
                VendorsClass objVendorClass = new VendorsClass();
                objVendorClass.Vendor_Number = st_split[0];
                DataTable dt = objPOSManagementService.getVendors(objVendorClass);
                for(int i= 0; i< dt.Rows.Count; i++)
                {
                    txt_terms.Text = dt.Rows[i]["Vendor_Terms"].ToString();
                }
                //glo.fun_search(str);
                //glo.dr.Read();
                //txt_terms.Text = glo.dr["Vendor_Terms"].ToString();
                //glo.dr.Close();
            }
            catch (Exception)
            { }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            InventoryForm ifrm = new InventoryForm("PO");
            ifrm.ShowDialog();
            DG_itemlist.Rows.Clear();
           // fun_fill_inventory_dg("select * from VIEW_INVEN_PURCH_ORDER");
            fun_fill_inventory_dg("", "");
            if (lstb_ven_list.SelectedItems.Count == 0)
            {
                System.Windows.MessageBox.Show("Please Select a Vendor Before Ordering the Item", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (ifrm.set_item_id != null)
            {
                fun_selct_item_po(ifrm.set_item_id);
            }
        }

        private void btn_receving_screen_Click(object sender, RoutedEventArgs e)
        {
            string[] ponsplit = lbl_po_no.Content.ToString().Split(' ');
            string pon = ponsplit[1];

            //string qry = "select ItemNum,Quan_Ordered from PO_Details where PO_Number = '" + Convert.ToInt32(pon) + "'";
            DataTable dt = objPOSManagementService.getPoDetail(Convert.ToInt32(pon));
            itemNo.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                itemNo.Add(dt.Rows[i]["ItemNum"].ToString());
                ls_item_qty.Add(Convert.ToDouble(dt.Rows[i]["Quan_Ordered"]));
            }
            ReceivingScreen rs = new ReceivingScreen();
            rs.ShowDialog();
            lbl_po_no.Content = "PO# " + pon.ToString();
            Dg_po_items.Rows.Clear();
           // string qrry = "select * from PO_Details where PO_Number = '" + pon + "' order by LineNum";
            DataTable dt_po_detail = objPOSManagementService.getPoDetail(Convert.ToInt32(pon));
            cmb_dest_storeid.SelectedItem = dt_po_detail.Rows[0]["destStore_ID"].ToString();
            for (int j = 0; j < dt_po_detail.Rows.Count; j++)
            {
                Dg_po_items.Rows.Add();
                Dg_po_items.Rows[j].Cells[0].Value = dt_po_detail.Rows[j]["LineNum"].ToString();
                Dg_po_items.Rows[j].Cells[1].Value = dt_po_detail.Rows[j]["ItemNum"].ToString();

                Dg_po_items.Rows[j].Cells[3].Value = dt_po_detail.Rows[j]["Store_ID"].ToString();
                Dg_po_items.Rows[j].Cells[4].Value = dt_po_detail.Rows[j]["Quan_Ordered"].ToString();
                Dg_po_items.Rows[j].Cells[5].Value = dt_po_detail.Rows[j]["CasePack"].ToString();
                Dg_po_items.Rows[j].Cells[6].Value = dt_po_detail.Rows[j]["NumberPerCase"].ToString();
                Dg_po_items.Rows[j].Cells[7].Value = dt_po_detail.Rows[j]["CostPer"].ToString();

                Dg_po_items.Rows[j].Cells[9].Value = dt_po_detail.Rows[j]["Quan_Received"].ToString();
                Dg_po_items.Rows[j].Cells[10].Value = dt_po_detail.Rows[j]["Quan_Damaged"].ToString();
            }
            fun_cal_row_total();
        }

        public List<string> set_itemNo
        {
            get { return itemNo; }
            set { itemNo = value; }
        }
        public List<double> set_itemQty
        {
            get { return ls_item_qty; }
            set { ls_item_qty = value; }
        }
    }
}
