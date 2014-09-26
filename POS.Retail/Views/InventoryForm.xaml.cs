using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using POS.Domain.Common;

using POS.Services.Common;
using System.Globalization;

namespace POS.Retail
{
    /// <summary>
    /// Interaction logic for InventoryForm.xaml
    /// </summary>
    public partial class InventoryForm : Window
    {
        POSManagementService objPOSManagementService = new POSManagementService();
        //GlobalClass glo = new GlobalClass();
        SearchInventoryForm ob = new SearchInventoryForm();
        Keyboard kb = new Keyboard();
        NumberKeypaid nkb = new NumberKeypaid();
        SelectItemTypesForm types = new SelectItemTypesForm();
        //Frm_MG_Qb_Charge charg = new Frm_MG_Qb_Charge();
        CalenderForm caln = new CalenderForm();
        TimeForm tm = new TimeForm();
        //frmDaysOfWeek frm_day = new frmDaysOfWeek();
        //frmDaysOfWeek day = new frmDaysOfWeek();
        //frmPropertycategory propty = new frmPropertycategory();
        TypeofRuleCoupon dept_rule = new TypeofRuleCoupon();
        SelectDepartCoponForm selct_dep = new SelectDepartCoponForm();
        CategorySelectForm cat = new CategorySelectForm();
        private static string item_id = null;
        int itmflage = 0;
        double persent;
        double price;
        int pric_type;
        int copon_flat_per;
        double bulk_price;
        double bulk_quantity;
        int bulk_price_type;
        int type; /* variable define for copon rule restriction */
        int allow_or_disalow; /* variable define for copon rule restriction */
        string cretria1;
        string cretiria2;
        string cretirea3;
        double timebase_price;
        string po_description = null;
        string command_type;
        string image_name = null;
        int index;
        int mindex = -1;
        int nindex = -1;
        int i;
        int j;
        int item_type;
        int img_id;
        int flage = 0;
        int flaged = 0;
        int iid;
        int cindex = -1;
        List<string> id = null;
        bool flg_chk;
        bool flg_tbvalue;
        bool flg_tbvalu_tax;
        string itemtype_heading;
        List<string> per = new List<string>();
        private static System.Windows.Controls.TextBox send_txbox = null;

        string dayofweek;
        private string p;

        public InventoryForm()
        {
            InitializeComponent();

            txt_item_number.IsReadOnly = true;
        }

        public InventoryForm(string p)
        {
            InitializeComponent();
            this.p = p;
        }

        private void fun_cal_tax(int lg)
        {
            POSManagementService objManagmentService = new POSManagementService();
            Tax_RateClass objTaxRates = new Tax_RateClass();
            objTaxRates.Store_ID = "1001";
            //string qury = "select Store_ID, Tax1_Rate,Tax1_Name,Tax2_Rate,Tax2_Name,Tax3_Rate,Tax3_Name,Tax2OnTax1,Tax2Threshold from Tax_Rate where Store_ID = '1001'";
            DataTable dt = objManagmentService.RetriveTaxRat(objTaxRates);
            double tax1;
            double tax2;
            double tax3;
            double tax4;
            double value;
            double value1;
            double vlue_withtax;
            if (chk_tax1.IsChecked == true)
            {
                tax1 = Convert.ToDouble(dt.Rows[0]["Tax1_Rate"]);
            }
            else
            {
                tax1 = 0;
            }
            if (chk_tax2.IsChecked == true)
            {
                tax2 = Convert.ToDouble(dt.Rows[0]["Tax2_Rate"]);
            }
            else
            {
                tax2 = 0;
            }
            if (chk_tax3.IsChecked == true)
            {
                tax3 = Convert.ToDouble(dt.Rows[0]["Tax3_Rate"]);
            }
            else
            {
                tax3 = 0;
            }
            if (lg == -1)
            {
                value = Convert.ToDouble(txt_price_ucharge.Text);
                vlue_withtax = Math.Round((tax1 + tax2 + tax3) * value + value);
                txt_price_withtax.Text = vlue_withtax.ToString();
            }
            if (lg == 1)
            {
                vlue_withtax = Convert.ToDouble(txt_price_withtax.Text);
                double totax = tax1 + tax2 + tax3;
                value1 = Math.Round(Convert.ToDouble(vlue_withtax / (1 + totax)), 1);
                txt_price_ucharge.Text = value1.ToString();
            }
        }
        private void fun_form_heading()
        {
            if (tabcon_inventory.Visibility == Visibility.Visible)
            {
                itemtype_heading = "Item";
            }
            else if (Grid_coupon.Visibility == Visibility.Visible)
            {
                itemtype_heading = "Coupon";
            }
            else if (Grid_kits.Visibility == Visibility.Visible)
            {
                itemtype_heading = "Kit";
            }
            else if (Grid_modifiers_groups.Visibility == Visibility.Visible)
            {
                itemtype_heading = "Modifier Group";
            }

            if (Grid_choice_item.Visibility == Visibility.Visible)
            {
                itemtype_heading = "Choice Item";
            }
            lbl_heading_inventory.Content = itemtype_heading + " : " + txt_item_descripton.Text;
        }
        private void fun_load_keyboard(System.Windows.Controls.TextBox selectedtxtbox, string txtbox_text)
        {
            Keyboard kb_frm = new Keyboard("Enter New Value", txtbox_text);
            kb_frm.ShowDialog();
            if (kb_frm.set_new_value != null)
            {
                selectedtxtbox.Text = kb_frm.set_new_value;
            }
            kb_frm.set_new_value = null;
            send_txbox = null;
        }

        private void fun_load_numkeyboard(System.Windows.Controls.TextBox selctedTexbox, string textbox_text)
        {
            NumberKeypaid nkkb = new NumberKeypaid("Enter New Value", textbox_text);
            nkkb.ShowDialog();
            if (nkkb.set_number != null)
            {
                selctedTexbox.Text = nkkb.set_number;
            }
        }

        private void fun_items_grid()
        {
            itmflage = 0;
            //string qry = "select ItemType from Inventory where ItemNum = '" + txt_item_number.Text + "'";
            //glo.fun_search(qry);
            //while (glo.dr.Read())
            //{
            //    itmflage = Convert.ToInt32(glo.dr["ItemType"]);
            //}
            //glo.dr.Close();
            POSManagementService objManagmentService = new POSManagementService();
            InventoryClass objInventory = new InventoryClass();
            objInventory.ItemNum = txt_item_number.Text;
            string flage = objManagmentService.GetItemType(objInventory);
            if(flage != "")
            itmflage = Convert.ToInt32(flage);
            if (itmflage == 0)
            {
                grid_show_hide();
                tabcon_inventory.Visibility = Visibility.Visible;
                fun_show_stan();
            }
            else if (itmflage == 4)
            {
                grid_show_hide();
                fun_hide_stan();
                Grid_modifiers_groups.Visibility = Visibility.Visible;
            }
            else if (itmflage == 3)
            {
                grid_show_hide();
                Grid_choice_item.Visibility = Visibility.Visible;
                fun_hide_stan();
            }
            else if (itmflage == 2)
            {
                grid_show_hide();
                Grid_kit_prices.Visibility = Visibility.Visible;
                Grid_kits.Visibility = Visibility.Visible;
                fun_hide_stan();
                chk_tax1.Visibility = Visibility.Visible;
                chk_tax2.Visibility = Visibility.Visible;
                chk_tax3.Visibility = Visibility.Visible;
                chk_bar_tax.Visibility = Visibility.Visible;
            }
            else if (itmflage == 7)
            {
                grid_show_hide();
                Grid_coupon_price.Visibility = Visibility.Visible;
                Grid_coupon.Visibility = Visibility.Visible;
            }

        }

        private void grid_show_hide()
        {
            tabcon_inventory.Visibility = Visibility.Hidden;
            Grid_coupon.Visibility = Visibility.Hidden;
            Grid_choice_item.Visibility = Visibility.Hidden;
            Grid_kits.Visibility = Visibility.Hidden;
            Grid_kit_prices.Visibility = Visibility.Hidden;
            Grid_modifiers_groups.Visibility = Visibility.Hidden;
            Grid_coupon_price.Visibility = Visibility.Hidden;
            fun_hide_stan();
        }

        private void fun_disable()
        {
            btn_add_item.Content = "Save";
            btn_exit_item.Content = "Cancel";

            btn_item_next.IsHitTestVisible = false;
            btn_item_prev.IsHitTestVisible = false;
            btn_savechages_item.IsHitTestVisible = false;
            txt_item_number.IsReadOnly = false;
            txt_item_number.Focus();

        }
        private void fun_enable()
        {
            btn_add_item.Content = "Add Item";
            btn_exit_item.Content = "Exit";
            txt_avg_cost.IsEnabled = false;
            txt_instock.IsEnabled = false;
            btn_item_next.IsHitTestVisible = true;
            btn_item_prev.IsHitTestVisible = true;
            btn_savechages_item.IsHitTestVisible = true;
            txt_item_number.IsReadOnly = true;
        }
        private void fun_hide_stan()
        {
            lbl_av.Visibility = Visibility.Hidden;
            lbl_pwtax.Visibility = Visibility.Hidden;
            lbl_upric.Visibility = Visibility.Hidden;
            lbl_stock.Visibility = Visibility.Hidden;
            txt_avg_cost.Visibility = Visibility.Hidden;
            txt_price_ucharge.Visibility = Visibility.Hidden;
            txt_price_withtax.Visibility = Visibility.Hidden;
            txt_instock.Visibility = Visibility.Hidden;
            chk_tax1.Visibility = Visibility.Hidden;
            chk_tax2.Visibility = Visibility.Hidden;
            chk_tax3.Visibility = Visibility.Hidden;
            chk_bar_tax.Visibility = Visibility.Hidden;
            tabcon_inventory.Visibility = Visibility.Hidden;

        }
        private void fun_show_stan()
        {
            lbl_av.Visibility = Visibility.Visible;
            lbl_pwtax.Visibility = Visibility.Visible;
            lbl_upric.Visibility = Visibility.Visible;
            lbl_stock.Visibility = Visibility.Visible;
            txt_avg_cost.Visibility = Visibility.Visible;
            txt_price_ucharge.Visibility = Visibility.Visible;
            txt_price_withtax.Visibility = Visibility.Visible;
            txt_instock.Visibility = Visibility.Visible;
            chk_tax1.Visibility = Visibility.Visible;
            chk_tax2.Visibility = Visibility.Visible;
            chk_tax3.Visibility = Visibility.Visible;
            chk_bar_tax.Visibility = Visibility.Visible;
            tabcon_inventory.Visibility = Visibility.Visible;
        }
        private void fun_fill_combo()
        {
            try
            {
                POSManagementService mangmentserv = new POSManagementService();
                InventoryClass inventoryclass = new POS.Domain.Common.InventoryClass();
                inventoryclass.dptFlage = "fillcombo";
                mangmentserv.FillDeptCmb(inventoryclass);
                cmb_select_dept.ItemsSource = inventoryclass.dtDeptCmb.DefaultView;
                cmb_select_dept.DisplayMemberPath = "dept";
                cmb_select_dept.SelectedValuePath = "Dept_ID";
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
            }
        }

        private void fun_rental_index()
        {
            try
            {
                POSManagementService mangmentserv = new POSManagementService();
                InventoryClass inventoryclass = new POS.Domain.Common.InventoryClass();
                inventoryclass.Dept_ID = cmb_select_dept.SelectedValue.ToString();
                inventoryclass.dptFlage = "index";
                mangmentserv.FillDeptCmb(inventoryclass);
                //string query = "select Type from Departments where Dept_ID = '" + cmb_select_dept.SelectedValue + "'";
                //DataTable dt = glo.getdata(query);
                if (Convert.ToInt32(inventoryclass.dtDeptCmb.Rows[0]["Type"]) == 0)
                {
                    rental_gbox.Visibility = Visibility.Hidden;
                    matrix_gbox.Visibility = Visibility.Visible;
                    ((TabItem)tabcon_inventory.Items[8]).Header = "Matrix";

                }
                else if (Convert.ToInt32(inventoryclass.dtDeptCmb.Rows[0]["Type"]) == 1)
                {
                    rental_gbox.Visibility = Visibility.Visible;
                    matrix_gbox.Visibility = Visibility.Hidden;
                    ((TabItem)tabcon_inventory.Items[8]).Header = "Rental";
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        public int image_id()
        {
            try
            {
                POSManagementService mangmentserv = new POSManagementService();
                Inventory_ImageClass objimage = new Domain.Common.Inventory_ImageClass();
                mangmentserv.GetMaixId(objimage);
                if (objimage.dtmaxID.Rows.Count > 0)
                {
                    img_id = Convert.ToInt32(objimage.dtmaxID.Rows[0]["ID"]);
                }
           
                return img_id;
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
                return img_id;
            }
            return img_id;
        }

        private void fun_inset_pricelevl()
        {
            //string str_delte = "delete from Inventory_DiscLevels where ItemNum = '" + txt_item_number.Text + "'";
            //glo.fun_insert(str_delte);
            POSManagementService objManagmentService = new POSManagementService();
            Inventory_DiscLevelsClass objInventoryDisLevel = new Inventory_DiscLevelsClass();
            objInventoryDisLevel.ItemNum = txt_item_number.Text;
            objInventoryDisLevel.qFlage = "delete";
            objManagmentService.ExectueInvDisLevel(objInventoryDisLevel);
            try
            {
                for (int k = 0; k <= DG_price_level.Rows.Count - 1; k++)
                {
                    if (DG_price_level.Rows[k].Cells[2].Value.Equals("0.00"))
                    {

                    }
                    else
                    {
                        string st = DG_price_level.Rows[k].Cells[2].Value.ToString();
                        string st1 = st.Substring(0, st.Length - 1);
                        double per = Convert.ToDouble(st1);
                        objInventoryDisLevel.Store_ID = "1001";
                        objInventoryDisLevel.ItemNum = txt_item_number.Text;
                        objInventoryDisLevel.Level = DG_price_level.Rows[k].Cells[0].Value.ToString();
                        objInventoryDisLevel.Perc = per;
                        objInventoryDisLevel.qFlage = "loopinsertion";
                        objManagmentService.ExectueInvDisLevel(objInventoryDisLevel);
                        //string qury = "insert into Inventory_DiscLevels(Store_ID,ItemNum,Level,Perc) values('1001','" + txt_item_number.Text + "','" + DG_price_level.Rows[k].Cells[0].Value.ToString() + "','" + per + "')";
                       // glo.fun_insert(qury);
                    }
                }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
            }
        }

        private void fun_inset_sku()
        {
            try
            {
                POSManagementService mangmentserv = new POSManagementService();
                Inventory_SKUSClass objInvSkus = new Domain.Common.Inventory_SKUSClass();
                objInvSkus.ItemNum = txt_item_number.Text;
                objInvSkus.quryFlage = "delelte";
                mangmentserv.InsertSukus(objInvSkus);
                if(objInvSkus.IsSuccessfull == true)
                {
                    objInvSkus.quryFlage = "insert";
                    for (int j = 0; j < lstbx_skus.Items.Count; j++)
                    {
                        lstbx_skus.SelectedIndex = j;
                        objInvSkus.lisBoxValue  = lstbx_skus.Items[j].ToString();
                        mangmentserv.InsertSukus(objInvSkus);
                    }
                }
               
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
            }
        }

        private void fun_isert_tag()
        {
            try
            {
                POSManagementService mangmentserv = new POSManagementService();
                Inventory_TagAlongsClass objInvTagAlongs = new Domain.Common.Inventory_TagAlongsClass();
                objInvTagAlongs.quryFlage = "delete";
                objInvTagAlongs.ItemNum = txt_item_number.Text;
                mangmentserv.insertTag(objInvTagAlongs);
                for (int n = 0; n < lstbox_tag.Items.Count; n++)
                {
                    objInvTagAlongs.ItemNum = txt_item_number.Text;
                    lstbox_tag.SelectedIndex = n;
                    objInvTagAlongs.quryFlage = "insert";
                    objInvTagAlongs.listBoxValueTag = lstbox_tag.Items[n].ToString();
                    objInvTagAlongs.Quantity = 1m;
                    mangmentserv.insertTag(objInvTagAlongs);
                }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
            }
        }

        private void fun_insert_modifier_groups()
        {
            try
            {
                POSManagementService mangmentserv = new POSManagementService();
                Kit_IndexClass objKitIndex = new Domain.Common.Kit_IndexClass();
                objKitIndex.quryFlage = "delete";
                objKitIndex.ItemNum = txt_item_number.Text;
                mangmentserv.InsertKit(objKitIndex);
            //string modgr_del = "delete from Kit_Index where ItemNum = '" + txt_item_number.Text + "'";
            //glo.fun_insert(modgr_del);
                for (i = 0; i < DG_modifier_groups.Items.Count; i++)
                {
                    objKitIndex.quryFlage = "insert";
                    DataGridRow rowss = (DataGridRow)DG_modifier_groups.ItemContainerGenerator.ContainerFromIndex(i);
                    //string a = (DG_modifier_groups.Columns[0].GetCellContent(rowss) as TextBlock).Text;
                    //string b = (DG_modifier_groups.Columns[1].GetCellContent(rowss) as TextBlock).Text;
                    //string c = (DG_modifier_groups.Columns[2].GetCellContent(rowss) as TextBlock).Text;
                    //string d = (DG_modifier_groups.Columns[3].GetCellContent(rowss) as TextBlock).Text;
                    //double r = Convert.ToDouble(c);
                    //double s = Convert.ToDouble(d);
                    objKitIndex.Kit_ID = txt_item_number.Text;
                    objKitIndex.Store_ID = "1001";
                    objKitIndex.ItemNum = (DG_modifier_groups.Columns[0].GetCellContent(rowss) as TextBlock).Text;
                    objKitIndex.Quantity = Convert.ToDouble((DG_modifier_groups.Columns[2].GetCellContent(rowss) as TextBlock).Text);
                    objKitIndex.Price = Convert.ToDouble((DG_modifier_groups.Columns[3].GetCellContent(rowss) as TextBlock).Text);
                    objKitIndex.Description = (DG_modifier_groups.Columns[1].GetCellContent(rowss) as TextBlock).Text;
                    mangmentserv.InsertKit(objKitIndex);
                    //string qrry = "insert into Kit_Index(Kit_ID,Store_ID,ItemNum,Quantity,Price,Description) values('" + txt_item_number.Text + "','1001','" + a + "','" + r + "','" + s + "','" + b + "')";
                    //glo.fun_insert(qrry);
                }
            }
        catch(Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
       }

        }

        private void fun_insert_mod_witem()
        {
            try
            {
                POSManagementService mangmentserv = new POSManagementService();
                ModifiersClass objModifiers = new Domain.Common.ModifiersClass();
                objModifiers.quryFlage = "delete";
                objModifiers.ItemNum = txt_item_number.Text;
                mangmentserv.InsertModifierWitem(objModifiers);

            //    string mod_witem_del = "delete from Modifiers where ItemNum = '" + txt_item_number.Text + "'";
            //    glo.fun_insert(mod_witem_del);
                int charg;
                int force;
                for (int x = 0; x < DG_mgroups.Rows.Count; x++)
                {
                    string itNum = txt_item_number.Text;
                    string modnum = DG_mgroups.Rows[x].Cells[5].Value.ToString();
                    string itdesc = DG_mgroups.Rows[x].Cells[0].Value.ToString();
                    string promp = DG_mgroups.Rows[x].Cells[1].Value.ToString();
                    int _index = DG_mgroups.Rows[x].Index;
                    if (DG_mgroups.Rows[x].Cells[2].Value.ToString().Equals("Yes"))
                    {
                        charg = 1;
                    }
                    else
                    {
                        charg = 0;
                    }
                    string numtoselct = DG_mgroups.Rows[x].Cells[3].Value.ToString();
                    if (DG_mgroups.Rows[x].Cells[4].Value.ToString().Equals("Yes"))
                    {
                        force = 1;
                    }
                    else
                    {
                        force = 0;
                    }
                    objModifiers.quryFlage = "insert";
                    objModifiers.ItemNum = txt_item_number.Text;
                    objModifiers.Store_ID = "1001";
                    objModifiers.ModNum = modnum;
                    objModifiers.ModName = itdesc;
                    objModifiers.Group_Or_Individual = Convert.ToInt32("1");
                    objModifiers.ChargePrice = charg;
                    objModifiers.NumToSelect = numtoselct;
                    objModifiers.Prompt = promp;
                    objModifiers.Index = index;
                    objModifiers.Forced = force;
                    mangmentserv.InsertModifierWitem(objModifiers);
            //        string qrry = "insert into Modifiers(ItemNum,Store_ID,ModNum,ModName,Group_Or_Individual,ChargePrice,NumToSelect,Prompt,[Index],Forced) values('" + txt_item_number.Text + "','1001','" + modnum + "','" + itdesc + "','1','" + charg + "','" + numtoselct + "','" + promp + "','" + _index + "','" + force + "')";
            //        glo.fun_insert(qrry);
                }
                for (i = 0; i < DG_indv_items.Items.Count; i++)
                {
                    
                    DataGridRow rowss = (DataGridRow)DG_indv_items.ItemContainerGenerator.ContainerFromIndex(i);
                    //string a = (DG_indv_items.Columns[0].GetCellContent(rowss) as TextBlock).Text;
                    //string b = (DG_indv_items.Columns[1].GetCellContent(rowss) as TextBlock).Text;
                    objModifiers.quryFlage = "loopinsertion";
                    objModifiers.ItemNum = txt_item_number.Text;
                    objModifiers.Store_ID = "1001";
                    objModifiers.ModNum = (DG_indv_items.Columns[0].GetCellContent(rowss) as TextBlock).Text;
                    objModifiers.ModName = (DG_indv_items.Columns[1].GetCellContent(rowss) as TextBlock).Text;
                    objModifiers.Group_Or_Individual = Convert.ToInt32("0");
                    //int Lindex = i;
                    objModifiers.Index = i;
                    mangmentserv.InsertModifierWitem(objModifiers);
                    //string qrry = "insert into Modifiers(ItemNum,Store_ID,ModNum,ModName,Group_Or_Individual,[Index]) values('" + txt_item_number.Text + "','1001','" + a + "','" + b + "','0','" + Lindex + "')";
                    //glo.fun_insert(qrry);
                }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
            }
        }

        private void fun_insert_ordering_info()
        {
            try
            {
                POSManagementService objManagmentService = new POSManagementService();
                Inventory_VendorsClass objInventoryVendor = new Inventory_VendorsClass();
                objInventoryVendor.qryFlage = "delete";
                objInventoryVendor.ItemNum = txt_item_number.Text;
                objManagmentService.ExecuteOredringInfo(objInventoryVendor);
                //string ord_inf_del = "delete from Inventory_Vendors where ItemNum = '" + txt_item_number.Text + "'";
                //glo.fun_insert(ord_inf_del);
                for (int f = 0; f < DG_ordering_info.Rows.Count; f++)
                {
                    double cost_per = Convert.ToDouble(DG_ordering_info.Rows[f].Cells[1].Value);
                    string ven_part = DG_ordering_info.Rows[f].Cells[3].Value.ToString();
                    double cse_cost = Convert.ToDouble(DG_ordering_info.Rows[f].Cells[4].Value);
                    double number_per = Convert.ToDouble(DG_ordering_info.Rows[f].Cells[5].Value);
                    string ven_id = DG_ordering_info.Rows[f].Cells[6].Value.ToString();
                    objInventoryVendor.ItemNum = txt_item_number.Text;
                    objInventoryVendor.Store_ID = "1001";
                    objInventoryVendor.Vendor_Number = ven_id;
                    objInventoryVendor.CostPer = cost_per;
                    objInventoryVendor.Case_Cost = cse_cost;
                    objInventoryVendor.NumPerVenCase = number_per;
                    objInventoryVendor.Vendor_Part_Num = ven_part;
                    objInventoryVendor.qryFlage = "loopinsertion";
                    objManagmentService.ExecuteOredringInfo(objInventoryVendor);
                    //string qurry = "insert into Inventory_Vendors(ItemNum,Store_ID,Vendor_Number,CostPer,Case_Cost,NumPerVenCase,Vendor_Part_Num) values('" + txt_item_number.Text + "','1001','" + ven_id + "','" + cost_per + "','" + cse_cost + "','" + number_per + "','" + ven_part + "')";
                    //glo.fun_insert(qurry);
                    if (DG_ordering_info.Rows[f].Cells[2].Value.Equals("True"))
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQServerRepository:(Initialization)]", ex.Message);
            }
        }

        private void fun_insert_sale_price()
        {
            try
            {
                //string sale_pric_del = "delete from Inventory_OnSale_Info where ItemNum = '" + txt_item_number.Text + "'";
                //glo.fun_insert(sale_pric_del);
                POSManagementService objManagmentService = new POSManagementService();
                Inventory_OnSale_InfoClass objInventoryOnsaleInfo = new Inventory_OnSale_InfoClass();
                objInventoryOnsaleInfo.qurryFlage = "delete";
                objInventoryOnsaleInfo.ItemNum = txt_item_number.Text;
                objManagmentService.ExecuteInventoryOnsaleInfo(objInventoryOnsaleInfo);
                for (int p = 0; p < lsb_sale_pricing.Items.Count; p++)
                {
                    string st1 = lsb_sale_pricing.Items[p].ToString();
                    if (st1.Contains("%"))
                    {
                        string[] splitstring2 = st1.Split('%');
                        string first = splitstring2[0];
                        persent = Convert.ToDouble(first);
                        price = 0;
                        pric_type = 0;
                    }
                    else if (st1.Contains("$"))
                    {
                        string[] splitstrin3 = st1.Split(' ');
                        string second = splitstrin3[0].Substring(1);
                        price = Convert.ToDouble(second);
                        persent = 0;
                        pric_type = 1;
                    }
                    int startIndex = st1.IndexOf("b/w ") + "b/w ".Length;
                    int endIndex = st1.IndexOf(" - ", startIndex);
                    string start_Date = st1.Substring(startIndex + 1, endIndex - startIndex - 2);
                    string end_date = st1.Substring(endIndex + 4, st1.Length - endIndex - 4);
                    objInventoryOnsaleInfo.qurryFlage = "loopinsertion";
                    objInventoryOnsaleInfo.Store_ID = "1001";
                    objInventoryOnsaleInfo.ItemNum = txt_item_number.Text;
                    objInventoryOnsaleInfo.Sale_Start = Convert.ToDateTime(start_Date);
                    objInventoryOnsaleInfo.Sale_End = Convert.ToDateTime(end_date);
                    objInventoryOnsaleInfo.Percent = persent;
                    objInventoryOnsaleInfo.Price = pric_type;
                    objInventoryOnsaleInfo.SalePriceType = 0;
                    objManagmentService.ExecuteInventoryOnsaleInfo(objInventoryOnsaleInfo);
                    //string qury = "insert into Inventory_OnSale_Info(ItemNum,Store_ID,Sale_Start,Sale_End,[Percent],Price,SalePriceType) values('" + txt_item_number.Text + "','1001','" + Convert.ToDateTime(start_Date) + "','" + Convert.ToDateTime(end_date) + "','" + persent + "','" + pric_type + "','0')";
                    //glo.fun_insert(qury);
                }
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
            }

        }

        private void fun_insert_bulk_price()
        {
            try
            {
                string description = "";
                Inventory_Bulk_InfoClass objInventory_Bulk_InfoClass = new Inventory_Bulk_InfoClass();
                objInventory_Bulk_InfoClass.ItemNum = txt_item_number.Text;
                objInventory_Bulk_InfoClass.quryFlg = "delete";
                objPOSManagementService.ExecuteInvBulkInfor(objInventory_Bulk_InfoClass);
                //string bulkp_del = "delete from Inventory_Bulk_Info where ItemNum = '" + txt_item_number.Text + "'";
                //glo.fun_insert(bulkp_del);
                for (int bul_list = 0; bul_list < lsb_bulk_pricing.Items.Count; bul_list++)
                {
                    string string1 = lsb_bulk_pricing.Items[bul_list].ToString();
                    if (string1.Contains("%"))
                    {
                        string[] fst = string1.Split(' ');
                        bulk_quantity = Convert.ToDouble(fst[0]);
                        bulk_price = Convert.ToDouble(fst[2]);
                        bulk_price_type = 1;
                    }
                    else if (string1.Contains("$"))
                    {
                        string[] scnd = string1.Split(' ');
                        bulk_quantity = Convert.ToDouble(scnd[0]);
                        string str2 = scnd[3].Substring(1, scnd[3].Length - 1);
                        bulk_price = Convert.ToDouble(str2);
                        bulk_price_type = 0;
                    }
                    if (string1.Contains('-'))
                    {
                        string[] split1 = lsb_bulk_pricing.Items[bul_list].ToString().Split('-');
                        description = split1[1];
                    }
                    objInventory_Bulk_InfoClass.quryFlg = "loopinsertion";
                    objInventory_Bulk_InfoClass.ItemNum = txt_item_number.Text;
                    objInventory_Bulk_InfoClass.Store_ID = "1001";
                    objInventory_Bulk_InfoClass.Bulk_Price = bulk_price;
                    objInventory_Bulk_InfoClass.Bulk_Quan = bulk_quantity;
                    objInventory_Bulk_InfoClass.Price_Type = bulk_price_type;
                    objInventory_Bulk_InfoClass.Description = description;
                    objPOSManagementService.ExecuteInvBulkInfor(objInventory_Bulk_InfoClass);
                    //string bulk_qury = "insert into Inventory_Bulk_Info(ItemNum,Store_ID,Bulk_Price,Bulk_Quan,Price_Type,Description) values('" + txt_item_number.Text + "','1001','" + bulk_price + "','" + bulk_quantity + "','" + bulk_price_type + "','" + description + "')";
                    //glo.fun_insert(bulk_qury);
                    description = "";
                }
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[SQServerRepository:(Initialization)]", ex.Message);
            }
        }

        private void fun_insert_time_price()
        {
            try
            {
                Inventory_PricesClass objInventory_PricesClass = new Inventory_PricesClass();
                objInventory_PricesClass.quryFlage = "delete";
                objInventory_PricesClass.ItemNum = txt_item_number.Text;
                objPOSManagementService.ExecuteInvnPrice(objInventory_PricesClass);
                //string timeb_price_del = "delete from Inventory_Prices where ItemNum = '" + txt_item_number.Text + "'";
                //glo.fun_insert(timeb_price_del);
                for (int tbp = 0; tbp < lsb_time_base.Items.Count; tbp++)
                {
                    string strr1 = lsb_time_base.Items[tbp].ToString();
                    string[] splitt = strr1.Split(' ');
                    string[] strsplt2 = splitt[0].Split(',');
                    string fisst = strsplt2[0].Substring(1);
                    timebase_price = Convert.ToDouble(fisst);
                    cretria1 = splitt[2];
                    cretiria2 = splitt[4];
                    if (splitt[1].Equals("Sun"))
                    {
                        cretirea3 = "1";
                    }
                    if (splitt[1].Equals("Mon"))
                    {
                        cretirea3 = "2";
                    }
                    if (splitt[1].Equals("Tue"))
                    {
                        cretirea3 = "3";
                    }
                    if (splitt[1].Equals("Wed"))
                    {
                        cretirea3 = "4";
                    }
                    if (splitt[1].Equals("Thu"))
                    {
                        cretirea3 = "5";
                    }
                    if (splitt[1].Equals("Fri"))
                    {
                        cretirea3 = "6";
                    }
                    if (splitt[1].Equals("Sat"))
                    {
                        cretirea3 = "7";
                    }
                    objInventory_PricesClass.quryFlage = "loopinsertion";
                    objInventory_PricesClass.ItemNum = txt_item_number.Text;
                    objInventory_PricesClass.Store_ID = "1001";
                    objInventory_PricesClass.Price = timebase_price;
                    objInventory_PricesClass.Criteria1 = cretria1;
                    objInventory_PricesClass.Criteria2 = cretiria2;
                    objInventory_PricesClass.Criteria3 = cretirea3;
                    objInventory_PricesClass.Enabled = 1;
                    objInventory_PricesClass.PriceType = 3;
                    objPOSManagementService.ExecuteInvnPrice(objInventory_PricesClass);
                    //string timebase_qury = "insert into Inventory_Prices(ItemNum,Store_ID,Price,Criteria1,Criteria2,Criteria3,Enabled,PriceType) values('" + txt_item_number.Text + "','1001','" + timebase_price + "','" + cretria1 + "','" + cretiria2 + "','" + cretirea3 + "', 1,3)";
                    //glo.fun_insert(timebase_qury);
                }
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[SQServerRepository:(Initialization)]", ex.Message);
            }
        }

        private void fun_insert_choice_item()
        {
            try
            {
                Kit_IndexClass objKit_IndexClass = new Kit_IndexClass();
                objKit_IndexClass.quryFlage = "delete";
                objPOSManagementService.InsertKit(objKit_IndexClass);
                //string choic_delete = "delete from Kit_Index where ItemNum = '" + txt_item_number.Text + "'";
                //glo.fun_insert(choic_delete);
                ChoiceItemsPropertyClass objChoiceItemsPropertyClass = new ChoiceItemsPropertyClass();
                objChoiceItemsPropertyClass.quryFlage = "delete";
                objChoiceItemsPropertyClass.ItemNum = txt_item_number.Text;
                objPOSManagementService.ExecuteChoiceItemsProperties(objChoiceItemsPropertyClass);
                //string choic_pro_del = "delete from ChoiceItems_Properties where ItemNum = '" + txt_item_number.Text + "'";
                //glo.fun_insert(choic_pro_del);
                foreach (DataGridViewRow row in DG_choice_items.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[3] as DataGridViewCheckBoxCell;
                    if (Convert.ToBoolean(chk.Value) == false)
                    {
                        objKit_IndexClass.quryFlage = "insert";
                        objKit_IndexClass.Kit_ID = txt_item_number.Text;
                        objKit_IndexClass.Store_ID = "1001";
                        objKit_IndexClass.ItemNum = row.Cells[0].Value.ToString();
                        objKit_IndexClass.Description = row.Cells[1].Value.ToString();
                        objKit_IndexClass.Quantity = Convert.ToDouble(row.Cells[2].Value);
                        objKit_IndexClass.Price = Convert.ToDouble(row.Cells[4].Value);
                        objPOSManagementService.InsertKit(objKit_IndexClass);
                        //string qrry = "insert into Kit_Index(Kit_ID,Store_ID,ItemNum,Description,Quantity,Price) values('" + txt_item_number.Text + "','1001','" + row.Cells[0].Value + "','" + row.Cells[1].Value + "','" + Convert.ToDouble(row.Cells[2].Value) + "','" + Convert.ToDecimal(row.Cells[4].Value) + "')";
                        //glo.fun_insert(qrry);
                    }
                    else if (Convert.ToBoolean(chk.Value) == true)
                    {
                        objChoiceItemsPropertyClass.quryFlage = "loopinsertion";
                        objChoiceItemsPropertyClass.Store_ID = "1001";
                        objChoiceItemsPropertyClass.ItemNum = txt_item_number.Text;
                        objChoiceItemsPropertyClass.Value_ID = Convert.ToInt32(row.Cells[0].Value);
                        objPOSManagementService.ExecuteChoiceItemsProperties(objChoiceItemsPropertyClass);
                        //string pro_qry = "insert into ChoiceItems_Properties(Store_ID,ItemNum,Value_ID) values('1001','" + txt_item_number.Text + "','" + Convert.ToInt32(row.Cells[0].Value) + "')";
                        //glo.fun_insert(pro_qry);
                    }
                }
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
            }
        }

        private void fun_insert_kit()
        {
            try
            {
                Kit_IndexClass objKitIndexClass = new Kit_IndexClass();
                objKitIndexClass.quryFlage = "delete";
                objKitIndexClass.ItemNum = txt_item_number.Text;
                objPOSManagementService.InsertKit(objKitIndexClass);
                //string kit_delete = "delete from Kit_Index where ItemNum = '" + txt_item_number.Text + "'";
                //glo.fun_insert(kit_delete);
                foreach (DataGridViewRow rrow in DG_kits.Rows)
                {
                    objKitIndexClass.quryFlage = "insert";
                    objKitIndexClass.Kit_ID = txt_item_number.Text;
                    objKitIndexClass.Store_ID = "1001";
                    objKitIndexClass.ItemNum = rrow.Cells[0].Value.ToString();
                    objKitIndexClass.Quantity = Convert.ToDouble(rrow.Cells[2].Value);
                    objKitIndexClass.Price = Convert.ToDouble(rrow.Cells[3].Value);
                    objKitIndexClass.Description = rrow.Cells[1].Value.ToString(); 
                    //string kitqury = "insert into Kit_Index(Kit_ID,Store_ID,ItemNum,Quantity,Price,Description) values('" + txt_item_number.Text + "','1001','" + rrow.Cells[0].Value + "','" + Convert.ToDouble(rrow.Cells[2].Value) + "','" + Convert.ToDouble(rrow.Cells[3].Value) + "','" + rrow.Cells[1].Value.ToString() + "')";
                    //glo.fun_insert(kitqury);
                }
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[SQLServerRepository:(Initialization)]", ex.Message);
            }
        }

        private void fun_insert_coupon()
        {
            try
            {
                DateTime? exp_date;
                exp_date = null;

                //string del = "delete from Inventory_Prices where ItemNum = '" + txt_item_number.Text + "'";
                //glo.fun_insert(del);
                Inventory_PricesClass objInventory_PricesClass = new Inventory_PricesClass();
                objInventory_PricesClass.quryFlage = "delete";
                objInventory_PricesClass.ItemNum = txt_item_number.Text;
                objPOSManagementService.ExecuteInvnPrice(objInventory_PricesClass);
                for (int r = 0; r < DG_coupon.Rows.Count; r++)
                {
                    for (int c = 1; c < DG_coupon.ColumnCount; c++)
                    {
                        if (DG_coupon.Rows[r].Cells[c].Value != null)
                        {
                            int day_indesx = Convert.ToInt32(DG_coupon.Rows[r].Cells[0].RowIndex) + 1;
                            string[] str = DG_coupon.Rows[r].Cells[c].Value.ToString().Split('-');
                            string cate1 = str[0].ToString();
                            string cate2 = str[1].ToString();
                            objInventory_PricesClass.quryFlage = "loopinsertion";
                            objInventory_PricesClass.ItemNum = txt_item_number.Text;
                            objInventory_PricesClass.Store_ID = "1001";
                            objInventory_PricesClass.Price = 0;
                            objInventory_PricesClass.Criteria1 = cate1;
                            objInventory_PricesClass.Criteria2 = cate2;
                            objInventory_PricesClass.Criteria3 = day_indesx.ToString();
                            objInventory_PricesClass.Enabled = 1;
                            objInventory_PricesClass.PriceType = 3;
                            //string qruy = "insert into Inventory_Prices(ItemNum,Store_ID,Criteria1,Criteria2,Criteria3,Enabled,PriceType) values('" + txt_item_number.Text + "','1001', '" + cate1 + "','" + cate2 + "','" + day_indesx + "','1','3')";
                            //glo.fun_insert(qruy);
                        }
                    }
                }
                Inventory_CouponClass objInventory_CouponClass = new Inventory_CouponClass();
                objInventory_CouponClass.qruyFalge = "delete";
                objInventory_CouponClass.ItemNum = txt_item_number.Text;
                objPOSManagementService.ExecuteCoupon(objInventory_CouponClass);
                //string del_inventory_copon = "delete from Inventory_Coupon where ItemNum = '" + txt_item_number.Text + "'";
                //glo.fun_insert(del_inventory_copon);
                if (rdb_flat_amount.IsChecked == true)
                {
                    copon_flat_per = 0;
                }
                else if (rdb_discount_amt.IsChecked == true)
                {
                    copon_flat_per = 1;
                }
                if (chk_coupon_expire.IsChecked == true)
                {
                    try
                    {
                        exp_date = Convert.ToDateTime(txt_copon_expir_date.Text);
                    }
                    catch (Exception)
                    { }
                }
                objInventory_CouponClass.qruyFalge = "insert";
                objInventory_CouponClass.Store_ID = "1001";
                objInventory_CouponClass.ItemNum = txt_item_number.Text;
                objInventory_CouponClass.Exp_Date = Convert.ToDateTime(exp_date);
                objInventory_CouponClass.Enforce_Exp = Convert.ToByte(chk_coupon_expire.IsChecked);
                objInventory_CouponClass.Include_All_Except = Convert.ToByte(chk_exeption.IsChecked);
                objInventory_CouponClass.Coupon_Flat_Percent = copon_flat_per;
                objInventory_CouponClass.Coupon_Bonus_Only = Convert.ToByte(chk_allow_through_bonus.IsChecked);
                objInventory_CouponClass.Apply_To_Parent = Convert.ToByte(chk_parent_items.IsChecked);
                objInventory_CouponClass.Suppress_Bonus = Convert.ToByte(chk_supress_bonus.IsChecked);
                objInventory_CouponClass.Minimum_Amount_Restriction = Convert.ToDouble(txt_max_amount.Text);
                objInventory_CouponClass.NumDays_Restriction = Convert.ToInt32(txt_days_bet.Text);
                objInventory_CouponClass.ApplyOnDiscountedItems = Convert.ToByte(chk_discounted_items.IsChecked);
                objInventory_CouponClass.ApplyOnSpecialPricing = Convert.ToByte(chk_special_pricing.IsChecked);

                objPOSManagementService.ExecuteCoupon(objInventory_CouponClass);
                //string qury = "insert into Inventory_Coupon(Store_ID,ItemNum,Exp_Date,Enforce_Exp,Include_All_Except,Coupon_Flat_Percent,Coupon_Bonus_Only,Apply_To_Parent,Suppress_Bonus,Minimum_Amount_Restriction,NumDays_Restriction,ApplyOnDiscountedItems,ApplyOnSpecialPricing) values('1001','" + txt_item_number.Text + "','" + exp_date + "','" + Convert.ToByte(chk_coupon_expire.IsChecked) + "','" + Convert.ToByte(chk_exeption.IsChecked) + "','" + copon_flat_per + "','" + Convert.ToByte(chk_allow_through_bonus.IsChecked) + "','" + Convert.ToByte(chk_parent_items.IsChecked) + "','" + Convert.ToByte(chk_supress_bonus.IsChecked) + "','" + Convert.ToDouble(txt_max_amount.Text) + "','" + Convert.ToInt32(txt_days_bet.Text) + "','" + Convert.ToByte(chk_discounted_items.IsChecked) + "','" + Convert.ToByte(chk_special_pricing.IsChecked) + "')";
                //glo.fun_insert(qury);
                Inventory_Coupon_RulesClass objInventoryCoupnRules = new Inventory_Coupon_RulesClass();
                objInventoryCoupnRules.qruFlage = "delete";
                objInventoryCoupnRules.ItemNum = txt_item_number.Text;
                objPOSManagementService.ExectueInvCouponRules(objInventoryCoupnRules);
               // string del_copon_rules = "delete from Inventory_Coupon_Rules where ItemNum = '" + txt_item_number.Text + "'";
                //glo.fun_insert(del_copon_rules);
                foreach (DataGridViewRow rr in DG_restriction.Rows)
                {
                    if (rr.Cells[1].Value.ToString().Equals("Item"))
                    {
                        type = 0;
                    }
                    if (rr.Cells[1].Value.ToString().Equals("Department"))
                    {
                        type = 1;
                    }
                    else if (rr.Cells[1].Value.ToString().Equals("Category"))
                    {
                        type = 2;
                    }
                    if (rr.Cells[0].Value.ToString().Equals("Include"))
                    {
                        allow_or_disalow = 0;
                    }
                    else if (rr.Cells[0].Value.ToString().Equals("Exclude"))
                    {
                        allow_or_disalow = 1;
                    }
                    else if (rr.Cells[0].Value.ToString().Equals("Exclusive"))
                    {
                        allow_or_disalow = 1;
                    }
                    objInventoryCoupnRules.qruFlage = "insert";
                    objInventoryCoupnRules.Store_ID = "1001";
                    objInventoryCoupnRules.ItemNum = txt_item_number.Text;
                    objInventoryCoupnRules.Type = type;
                    objInventoryCoupnRules.ID = rr.Cells[3].Value.ToString();
                    objInventoryCoupnRules.Allow_Or_Disallow = allow_or_disalow;
                    objPOSManagementService.ExectueInvCouponRules(objInventoryCoupnRules);
                   // string res_qruy = "insert into Inventory_Coupon_Rules(Store_ID,ItemNum,Type,ID,Allow_Or_Disallow) values('1001','" + txt_item_number.Text + "','" + type + "','" + rr.Cells[3].Value + "','" + allow_or_disalow + "')";
                    //glo.fun_insert(res_qruy);
                }
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
            }
        }

        private void fun_insert_rental()
        {
            try
            {
                Inventory_Rental_InfoClasss objRentalInfo = new Inventory_Rental_InfoClasss();
                //delete from inventory_rental_info
                objRentalInfo.quryFlage = "delete";
                objRentalInfo.ItemNum = txt_item_number.Text;
                objPOSManagementService.ExecuteRentalInfo(objRentalInfo);
                // insertion into inventory_rental_info
                objRentalInfo.quryFlage = "insert";
                objRentalInfo.Store_ID = "1001";
                objRentalInfo.Late_Charge = Convert.ToDouble(txt_daily_late_charge.Text);
                objRentalInfo.Days_Rent = Convert.ToInt32(txt_days.Text);
                objRentalInfo.Rating = txt_rating.Text;
                objRentalInfo.Inv_Approval_Code = txt_item_appr_code.Text;
                objRentalInfo.Actor_Last_Name = txt_actor_name.Text;
                objRentalInfo.Actress_Last_Name = txt_actress_name.Text;
                objPOSManagementService.ExecuteRentalInfo(objRentalInfo);
                //string del_rental = "delete from Inventory_Rental_Info where ItemNum = '" + txt_item_number.Text + "'";
                //glo.fun_insert(del_rental);
                //string rental_qury = "insert into Inventory_Rental_Info(ItemNum,Store_ID,Late_Charge,Days_Rent,Rating,Inv_Approval_Code,Actor_Last_Name,Actress_Last_Name) values('" + txt_item_number.Text + "','1001','" + Convert.ToDouble(txt_daily_late_charge.Text) + "','" + Convert.ToInt32(txt_days.Text) + "','" + txt_rating.Text + "','" + txt_item_appr_code.Text + "','" + txt_actor_name.Text + "','" + txt_actress_name.Text + "')";
                //glo.fun_insert(rental_qury);

                Inventory_PricesClass objInventoryPrice = new Inventory_PricesClass();
                objInventoryPrice.quryFlage = "delete";
                objInventoryPrice.ItemNum = txt_item_number.Text;
                objPOSManagementService.ExecuteInvnPrice(objInventoryPrice);
                //string del_ren_price = "delete from Inventory_Prices where ItemNum = '" + txt_item_number.Text + "'";
                //glo.fun_insert(del_ren_price);
                for (int r = 0; r < dg_rent.Rows.Count; r++)
                {

                    string str1 = dg_rent.Rows[r].Cells[1].Value.ToString();
                    string str2 = str1.Substring(1, str1.Length - 1);
                    double price_vale = Convert.ToDouble(str2);
                    objInventoryPrice.quryFlage = "insert";
                    objInventoryPrice.ItemNum = txt_item_number.Text;
                    objInventoryPrice.Store_ID = "1001";
                    objInventoryPrice.Price = price_vale;
                    objInventoryPrice.Criteria1 = dg_rent.Rows[r].Cells[0].Value.ToString();
                    objInventoryPrice.Enabled = 1;
                    objInventoryPrice.PriceType = 2;
                    objPOSManagementService.ExecuteInvnPrice(objInventoryPrice);
                    //string rental_price_qry = "insert into Inventory_Prices(ItemNum,Store_ID,Price,Criteria1,Enabled,PriceType) values('" + txt_item_number.Text + "','1001','" + price_vale + "','" + dg_rent.Rows[r].Cells[0].Value.ToString() + "', 1,2)";
                    //glo.fun_insert(rental_price_qry);
                }
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[SQServerRepository:(Initialization)]", ex.Message);
            }

        }

        private void fun_fill_price_level()
        {
            double am1 = Convert.ToDouble(txt_price_ucharge.Text);
            string am = "$" + am1.ToString();
            DG_price_level.Rows.Clear();

            var data = new string[26, 4]
            {
				  { "A",am,"0.00","No",},
                  { "B",am,"0.00","No",},
                  { "C",am,"0.00","No",},
                  { "D",am,"0.00","No",},
                  { "E",am,"0.00","No",},
                  { "F",am,"0.00","No",},
                  { "G",am,"0.00","No",},
                  { "H",am,"0.00","No",},
                  { "I",am,"0.00","No",},
                  { "J",am,"0.00","No",},
                  { "K",am,"0.00","No",},
                  { "L",am,"0.00","No",},
                  { "M",am,"0.00","No",},
                  { "N",am,"0.00","No",},
                  { "O",am,"0.00","No",},
                  { "P",am,"0.00","No",},
                  { "Q",am,"0.00","No",},
                  { "R",am,"0.00","No",},
                  { "S",am,"0.00","No",},
                  { "T",am,"0.00","No",},
                  { "U",am,"0.00","No",},
                  { "V",am,"0.00","No",},
                  { "W",am,"0.00","No",},
                  { "X",am,"0.00","No",},
                  { "Y",am,"0.00","No",},
                  { "Z",am,"0.00","No",},
            };

            var rowCount = data.GetLength(0);
            var rowLength = data.GetLength(1);
            for (int rowIndex = 0; rowIndex < rowCount; ++rowIndex)
            {
                var row = new DataGridViewRow();
                for (int columnIndex = 0; columnIndex < rowLength; ++columnIndex)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell()
                    {
                        Value = data[rowIndex, columnIndex]
                    });
                }
                DG_price_level.Rows.Add(row);
            }
        }

        private void fun_coupon_apply_rule(string type)
        {
            TypeofRuleCoupon tor = new TypeofRuleCoupon();
            tor.ShowDialog();
            if (dept_rule.set_rul_type_flage != null)
            {
                if (dept_rule.set_rul_type_flage == "Item")
                {
                    if (ob.set_item_id != null)
                    {
                        //string qury = "select ItemNum, ItemName from inventory where ItemNum = '" + ob.set_item_id + "'";
                        //DataTable dt_rule = glo.getdata(qury);
                        DataTable dt_rule = objPOSManagementService.getIventory(ob.set_item_id);
                        for (int i = 0; i < DG_restriction.Rows.Count; i++)
                        {
                            if (DG_restriction.Rows[i].Cells[3].Value.Equals(dt_rule.Rows[0]["ItemNum"].ToString()))
                            {
                                return;
                            }
                        }
                        DG_restriction.Rows.Add();
                        DG_restriction.Rows[DG_restriction.Rows.Count - 1].Cells[0].Value = type;
                        DG_restriction.Rows[DG_restriction.Rows.Count - 1].Cells[1].Value = "Item";
                        DG_restriction.Rows[DG_restriction.Rows.Count - 1].Cells[2].Value = dt_rule.Rows[0]["ItemName"].ToString();
                        DG_restriction.Rows[DG_restriction.Rows.Count - 1].Cells[3].Value = dt_rule.Rows[0]["ItemNum"].ToString();
                        ob.set_item_id = null;
                    }
                }
                else if (dept_rule.set_rul_type_flage == "Department")
                {
                    for (int x = 0; x < selct_dep.set_listDeptID.Count; x++)
                    {
                        int flg = 0;
                        for (int i = 0; i < DG_restriction.Rows.Count; i++)
                        {
                            if (DG_restriction.Rows[i].Cells[3].Value.Equals(selct_dep.set_listDeptID[x].ToString()))
                            {
                                flg = 1;
                            }
                        }
                        if (flg == 0)
                        {
                            DG_restriction.Rows.Add();
                            DG_restriction.Rows[DG_restriction.Rows.Count - 1].Cells[0].Value = type;
                            DG_restriction.Rows[DG_restriction.Rows.Count - 1].Cells[1].Value = "Department";
                            DG_restriction.Rows[DG_restriction.Rows.Count - 1].Cells[2].Value = selct_dep.set_lsitDeptName[x].ToString();
                            DG_restriction.Rows[DG_restriction.Rows.Count - 1].Cells[3].Value = selct_dep.set_listDeptID[x].ToString();
                        }
                    }
                    selct_dep.set_listDeptID.Clear();
                    selct_dep.set_lsitDeptName.Clear();
                }
                else if (dept_rule.set_rul_type_flage == "Category")
                {
                    for (int y = 0; y < cat.set_listCatID.Count; y++)
                    {
                        int fllg = 0;
                        for (int i = 0; i < DG_restriction.Rows.Count; i++)
                        {
                            if (DG_restriction.Rows[i].Cells[3].Value.Equals(cat.set_listCatID[y].ToString()))
                            {
                                fllg = 1;
                            }
                        }
                        if (fllg == 0)
                        {
                            DG_restriction.Rows.Add();
                            DG_restriction.Rows[DG_restriction.Rows.Count - 1].Cells[0].Value = type;
                            DG_restriction.Rows[DG_restriction.Rows.Count - 1].Cells[1].Value = "Category";
                            DG_restriction.Rows[DG_restriction.Rows.Count - 1].Cells[2].Value = cat.set_lsitCattName[y].ToString();
                            DG_restriction.Rows[DG_restriction.Rows.Count - 1].Cells[3].Value = cat.set_listCatID[y].ToString();
                        }
                    }
                    cat.set_lsitCattName.Clear();
                    cat.set_listCatID.Clear();
                }
            }
            dept_rule.set_rul_type_flage = null;
        }

        private void fun_add_days_to_coupon_gird()
        {
            try
            {
                for (int i = 0; i < 7; i++)
                {
                    DG_coupon.Rows.Add();
                }
                DG_coupon.Rows[0].Cells[0].Value = "Sunday";
                DG_coupon.Rows[1].Cells[0].Value = "Monday";
                DG_coupon.Rows[2].Cells[0].Value = "Tuesday";
                DG_coupon.Rows[3].Cells[0].Value = "Wednesday";
                DG_coupon.Rows[4].Cells[0].Value = "Thirsday";
                DG_coupon.Rows[5].Cells[0].Value = "Friday";
                DG_coupon.Rows[6].Cells[0].Value = "Satuarday";
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
            }
        }

        private void fun_retrive_inventory(int index)
        {

            //this.index = index;
            //string quray;

            //for (int rr = 0; rr < DG_coupon.Rows.Count; rr++)
            //{
            //    DG_coupon.Rows[rr].Cells[1].Value = null;
            //}
            //for (int cc = 2; cc < DG_coupon.ColumnCount; cc++)
            //{
            //    DG_coupon.Columns.RemoveAt(cc);
            //}

            //int sitemype = 0;
            //try
            //{
            //    if (index == -2)
            //    {
            //        quray = "select * from Inventory where ItemNum = '" + ob.set_item_id.ToString() + "' and IsDeleted = 0";
            //        index = 0;
            //    }
            //    else if (index == -1)
            //    {
            //        quray = "select * from Inventory where ItemNum = '" + txt_search_item_by_num.Text.ToString() + "' and IsDeleted = 0";
            //        index = 0;
            //        DataTable flag = glo.getdata(quray);
            //        if (flag.Rows.Count == 0)
            //        {
            //            System.Windows.Forms.MessageBox.Show("No Record Found", "Stop", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
            //            txt_search_item_by_num.Clear();
            //            txt_search_item_by_num.Focus();
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        quray = "select * from Inventory where IsDeleted = 0";
            //    }
            //    DataTable dt = glo.getdata(quray);
            //    string qury = "select * from Inventory_Image where ItemNum = '" + dt.Rows[index]["ItemNum"] + "'";
            //    DataTable dti = glo.getdata(qury);
            //    string squry = "select * from Inventory_SKUS where ItemNum ='" + dt.Rows[index]["ItemNum"] + "'";
            //    DataTable dts = glo.getdata(squry);
            //    string nqury = "select * from Inventory_Notes where ItemNum ='" + dt.Rows[index]["ItemNum"] + "'";
            //    DataTable dtn = glo.getdata(nqury);
            //    string tqury = "select * from Inventory_TagAlongs where ItemNum ='" + dt.Rows[index]["ItemNum"] + "'";
            //    DataTable dtt = glo.getdata(tqury);
            //    string pqury = "select * from Inventory_DiscLevels where ItemNum ='" + dt.Rows[index]["ItemNum"] + "'";
            //    DataTable dtp = glo.getdata(pqury);
            //    string vqury = "select * from VIEW_INVENTORY_VENDOR where ItemNum ='" + dt.Rows[index]["ItemNum"] + "'";
            //    DataTable dtv = glo.getdata(vqury);
            //    string mg_qury = "select Kit_ID as ItemNum, Quantity as In_Stock, Price, [Description] as ItemName from Kit_Index where Kit_ID ='" + dt.Rows[index]["ItemNum"] + "'";
            //    DataTable mgdt = glo.getdata(mg_qury);
            //    string grpsitem_qury = "select * from Modifiers where ItemNum ='" + dt.Rows[index]["ItemNum"] + "' and Group_Or_Individual = 1";
            //    DataTable dt_gi = glo.getdata(grpsitem_qury);
            //    string inv_item = "select ItemNum, ModName as ItemName from Modifiers where ItemNum ='" + dt.Rows[index]["ItemNum"] + "' and Group_Or_Individual = 0";
            //    DataTable dtinitem = glo.getdata(inv_item);
            //    string pri_qruy = "select * from Inventory_OnSale_Info where ItemNum ='" + dt.Rows[index]["ItemNum"] + "'";
            //    DataTable prdt = glo.getdata(pri_qruy);
            //    string bulk_qury = "select * from Inventory_Bulk_Info where ItemNum ='" + dt.Rows[index]["ItemNum"] + "'";
            //    DataTable dtbulk = glo.getdata(bulk_qury);
            //    string btp_qruy = "select * from Inventory_Prices where ItemNum ='" + dt.Rows[index]["ItemNum"] + "'";
            //    DataTable dttbae = glo.getdata(btp_qruy);
            //    string choic = "select ItemNum, [Description], Quantity, Price from Kit_Index where ItemNum ='" + dt.Rows[index]["ItemNum"] + "'";
            //    DataTable choice_dt = glo.getdata(choic);
            //    string choic_properteis = "select Value_ID, Description + ':' + Expr1 as descrip from VIEW_CHOICE_PROPERTY where ItemNum ='" + dt.Rows[index]["ItemNum"] + "'";
            //    DataTable dt_chice_prop = glo.getdata(choic_properteis);
            //    string copon_prices = "select * from Inventory_Prices where ItemNum ='" + dt.Rows[index]["ItemNum"] + "'";
            //    DataTable dt_copon_prices = glo.getdata(copon_prices);
            //    string copon = "select * from Inventory_Coupon where ItemNum ='" + dt.Rows[index]["ItemNum"] + "'";
            //    DataTable dt_copon = glo.getdata(copon);
            //    string copon_rule = "select * from VIEW_COPON_RULE where ItemNum ='" + dt.Rows[index]["ItemNum"] + "'";
            //    DataTable dt_crule = glo.getdata(copon_rule);
            //    string sale_history = "SELECT * from VIEW_ITEM_SLAE_HISTORY where ItemNum ='" + dt.Rows[index]["ItemNum"] + "'";
            //    DataTable dt_sale_history = glo.getdata(sale_history);
            //    int flage = dt.Rows.Count;
            //    clear_fields();
            //    item_image.Source = null;
            //    lstbx_skus.Items.Clear();
            //    lstbox_tag.Items.Clear();
            //    txt_inventory_notes.Clear();
            //    DG_ordering_info.Rows.Clear();
            //    DG_mgroups.Rows.Clear();
            //    DG_modifier_groups.ItemsSource = null;
            //    DG_modifier_groups.Items.Clear();
            //    DG_indv_items.ItemsSource = null;
            //    DG_indv_items.Items.Clear();
            //    DG_choice_items.Rows.Clear();
            //    DG_sale_history.Rows.Clear();
            //    DG_kits.Rows.Clear();
            //    if (index >= 0)
            //    {
            //        sitemype = Convert.ToInt32(dt.Rows[index]["ScaleItemType"]);
            //        if (sitemype == 1)
            //        {
            //            rb_sold_by_price.IsChecked = true;
            //        }
            //        else if (sitemype == 2)
            //        {
            //            rb_weighed_onsclae.IsChecked = true;
            //        }
            //        else if (sitemype == 3)
            //        {
            //            rb_weighed_with.IsChecked = true;
            //        }
            //        else if (sitemype == 4)
            //        {
            //            rb_barcoded.IsChecked = true;
            //        }
            //        else if (sitemype == 0)
            //        {
            //            rb_barcoded.IsChecked = false;
            //            rb_sold_by_price.IsChecked = false;
            //            rb_weighed_onsclae.IsChecked = false;
            //            rb_weighed_with.IsChecked = false;
            //        }

            //        txt_item_number.Text = dt.Rows[index]["ItemNum"].ToString();
            //        txt_item_descripton.Text = dt.Rows[index]["ItemName"].ToString();
            //fun_items_grid();
            //        txt_avg_cost.Text = Math.Round(Convert.ToDouble(dt.Rows[index]["Cost"]), 3).ToString();
            //        if (itmflage == 7)
            //        {
            //            txt_coupon_discounted_price.Text = Convert.ToDouble(dt.Rows[index]["Price"]).ToString();
            //        }
            //        else
            //        {
            //            txt_price_ucharge.Text = Convert.ToDouble(dt.Rows[index]["Price"]).ToString();
            //        }
            //        txt_retail_price.Text = Convert.ToDouble(dt.Rows[index]["Retail_Price"]).ToString();
            //        txt_instock.Text = Convert.ToDouble(dt.Rows[index]["In_Stock"]).ToString();
            //        txt_reorder_level.Text = dt.Rows[index]["Reorder_Level"].ToString();
            //        txt_reorder_qty.Text = dt.Rows[index]["Reorder_Quantity"].ToString();
            //        chk_tax1.IsChecked = Convert.ToBoolean(dt.Rows[index]["Tax_1"]);
            //        chk_tax2.IsChecked = Convert.ToBoolean(dt.Rows[index]["Tax_2"]);
            //        chk_tax3.IsChecked = Convert.ToBoolean(dt.Rows[index]["Tax_3"]);
            //        cmb_select_dept.SelectedValue = dt.Rows[index]["Dept_ID"].ToString();
            //        chk_modfier_item.IsChecked = Convert.ToBoolean(dt.Rows[index]["IsModifier"]);
            //        txt_barcodes.Text = dt.Rows[index]["Inv_Num_Barcode_Labels"].ToString();
            //        chk_use_serial.IsChecked = Convert.ToBoolean(dt.Rows[index]["Use_Serial_Numbers"]);
            //        txt_bonus.Text = dt.Rows[index]["Num_Bonus_Points"].ToString();
            //        chk_print_ticket.IsChecked = Convert.ToBoolean(dt.Rows[index]["Print_Ticket"]);
            //        txt_days_valid.Text = dt.Rows[index]["Num_Days_Valid"].ToString();
            //        vendor_part_txt.Text = dt.Rows[index]["Vendor_Part_Num"].ToString();
            //        txt_location.Text = dt.Rows[index]["Location"].ToString();
            //        chk_auto_wiegh.IsChecked = Convert.ToBoolean(dt.Rows[index]["AutoWeigh"]);
            //        number_incase_txt.Text = dt.Rows[index]["NumPerCase"].ToString();
            //        chk_food_stamp.IsChecked = Convert.ToBoolean(dt.Rows[index]["FoodStampable"]);
            //        txt_reorder_cost.Text = dt.Rows[index]["ReOrder_Cost"].ToString();
            //        txt_item_description2.Text = dt.Rows[index]["ItemName_Extra"].ToString();
            //        chk_chek_id.IsChecked = Convert.ToBoolean(dt.Rows[index]["Check_ID"]);
            //        chk_prmpt_price.IsChecked = Convert.ToBoolean(dt.Rows[index]["Prompt_Price"]);
            //        chk_prmt_qty.IsChecked = Convert.ToBoolean(dt.Rows[index]["Prompt_Quantity"]);
            //        chk_disable_itm.IsChecked = Convert.ToBoolean(dt.Rows[index]["Inactive"]);
            //        chk_allow_buyback.IsChecked = Convert.ToBoolean(dt.Rows[index]["Allow_BuyBack"]);
            //        txt_unit_type.Text = dt.Rows[index]["Unit_Type"].ToString();
            //        txt_unit_size.Text = dt.Rows[index]["Unit_Size"].ToString();
            //        chk_special_permission.IsChecked = Convert.ToBoolean(dt.Rows[index]["Special_Permission"]);
            //        chk_prompt_descrip.IsChecked = Convert.ToBoolean(dt.Rows[index]["Prompt_Description"]);
            //        chk_check2.IsChecked = Convert.ToBoolean(dt.Rows[index]["Check_ID2"]);
            //        chk_count_item.IsChecked = Convert.ToBoolean(dt.Rows[index]["Count_This_Item"]);
            //        txt_cost_marku.Text = dt.Rows[index]["Transfer_Cost_Markup"].ToString();
            //        chk_print_reciept.IsChecked = Convert.ToBoolean(dt.Rows[index]["Print_On_Receipt"]);
            //        chk_enable_markup.IsChecked = Convert.ToBoolean(dt.Rows[index]["Transfer_Markup_Enabled"]);
            //        chk_sell_asls.IsChecked = Convert.ToBoolean(dt.Rows[index]["As_Is"]);
            //        chk_require_customer.IsChecked = Convert.ToBoolean(dt.Rows[index]["RequireCustomer"]);
            //        chk_prompt_comp_date.IsChecked = Convert.ToBoolean(dt.Rows[index]["PromptCompletionDate"]);
            //        chk_prompt_invoice.IsChecked = Convert.ToBoolean(dt.Rows[index]["PromptInvoiceNotes"]);
            //        txt_prmp_todescrp.Text = dt.Rows[index]["Prompt_DescriptionOverDollarAmt"].ToString();
            //        chk_exclude_loyalty.IsChecked = Convert.ToBoolean(dt.Rows[index]["Exclude_From_Loyalty"]);
            //        chk_bar_tax.IsChecked = Convert.ToBoolean(dt.Rows[index]["BarTaxInclusive"]);
            //        chk_scale_deduct.IsChecked = Convert.ToBoolean(dt.Rows[index]["ScaleSingleDeduct"]);
            //        txt_glnumber.Text = dt.Rows[index]["GLNumber"].ToString();
            //        //cmb_discountype.SelectedIndex
            //        chk_allow_return.IsChecked = Convert.ToBoolean(dt.Rows[index]["AllowReturns"]);
            //        txt_sugested_deposit.Text = dt.Rows[index]["SuggestedDeposit"].ToString();
            //        chk_liablity_item.IsChecked = Convert.ToBoolean(dt.Rows[index]["Liability"]);
            //        chk_allow_depsit_invo.IsChecked = Convert.ToBoolean(dt.Rows[index]["AllowOnDepositInvoices"]);
            //        chk_allow_fleet.IsChecked = Convert.ToBoolean(dt.Rows[index]["AllowOnFleetCard"]);
            //        chk_display_tax.IsChecked = Convert.ToBoolean(dt.Rows[index]["DisplayTaxInPrice"]);
            //        chk_kichen.IsChecked = Convert.ToBoolean(dt.Rows[index]["NeverPrintInKitchen"]);
            //        fun_fill_price_level();
            //        fun_rental_index();
            //        fun_form_heading();
            //        //fun_items_grid();
            //        ImageSourceConverter isc = new ImageSourceConverter();
            //        if (dti.Rows.Count > 0)
            //        {
            //            item_image.SetValue(Image.SourceProperty, isc.ConvertFromString(dti.Rows[0]["ImageLocation"].ToString()));
            //        }
            //        if (dts.Rows.Count > 0)
            //        {
            //            for (int i = 0; i <= dts.Rows.Count - 1; i++)
            //            {
            //                lstbx_skus.Items.Add(dts.Rows[i]["AltSKU"].ToString());
            //            }
            //        }
            //        if (dtt.Rows.Count > 0)
            //        {
            //            for (int y = 0; y <= dtt.Rows.Count - 1; y++)
            //            {
            //                lstbox_tag.Items.Add(dtt.Rows[y]["TagAlong_ItemNum"].ToString());
            //            }
            //        }
            //        if (dtp.Rows.Count > 0)
            //        {
            //            for (int p = 0; p < dtp.Rows.Count; p++)
            //            {
            //                DG_price_level.Rows[p].Cells[2].Value = Math.Round(Convert.ToDecimal(dtp.Rows[p]["Perc"]), 2).ToString() + "%";
            //            }
            //        }
            //        if (dtn.Rows.Count > 0)
            //        {
            //            txt_inventory_notes.Text = dtn.Rows[0]["Notes"].ToString();
            //        }
            //        if (dtv.Rows.Count > 0)
            //        {
            //            cost_per_txt.IsEnabled = true;
            //            case_cost_txt.IsEnabled = true;
            //            number_incase_txt.IsEnabled = true;
            //            txt_cost_marku.IsEnabled = true;
            //            chk_enable_markup.IsEnabled = true;
            //            vendor_part_txt.IsEnabled = true;
            //            for (int v = 0; v < dtv.Rows.Count; v++)
            //            {
            //                DG_ordering_info.Rows.Add();
            //                DG_ordering_info.Rows[v].Cells[0].Value = dtv.Rows[v]["vendor_name"].ToString();
            //                DG_ordering_info.Rows[v].Cells[1].Value = dtv.Rows[v]["CostPer"].ToString();
            //                DG_ordering_info.Rows[v].Cells[2].Value = "False";
            //                DG_ordering_info.Rows[v].Cells[3].Value = dtv.Rows[v]["Vendor_Part_Num"].ToString();
            //                DG_ordering_info.Rows[v].Cells[4].Value = dtv.Rows[v]["Case_Cost"].ToString();
            //                DG_ordering_info.Rows[v].Cells[5].Value = dtv.Rows[v]["NumPerVenCase"].ToString();
            //                DG_ordering_info.Rows[v].Cells[6].Value = dtv.Rows[v]["Vendor_Number"].ToString();
            //            }
            //            string st = "select Vendor_Part_Num from Inventory where ItemNum ='" + dt.Rows[index]["ItemNum"] + "'";
            //            DataTable vdtv = glo.getdata(st);
            //            foreach (DataGridViewRow row in DG_ordering_info.Rows)
            //            {
            //                if (row.Cells[3].Value.Equals(vdtv.Rows[0]["Vendor_Part_Num"].ToString()))
            //                {
            //                    row.Cells[2].Value = "True";
            //                }
            //            }
            //        }
            //        else
            //        {
            //            cost_per_txt.IsEnabled = false;
            //            case_cost_txt.IsEnabled = false;
            //            number_incase_txt.IsEnabled = false;
            //            txt_cost_marku.IsEnabled = false;
            //            //chk_enable_markup.IsEnabled = false;
            //            //vendor_part_txt.IsEnabled = false;
            //        }
            //        if (mgdt.Rows.Count > 0)
            //        {
            //            DG_modifier_groups.Items.Add(mgdt.DefaultView);
            //        }
            //        if (dt_gi.Rows.Count > 0)
            //        {
            //            for (int gi = 0; gi < dt_gi.Rows.Count; gi++)
            //            {
            //                DG_mgroups.Rows.Add();
            //                DG_mgroups.Rows[gi].Cells[0].Value = dt_gi.Rows[gi]["ModName"].ToString();
            //                DG_mgroups.Rows[gi].Cells[1].Value = dt_gi.Rows[gi]["Prompt"].ToString();
            //                if (Convert.ToByte(dt_gi.Rows[gi]["ChargePrice"]).Equals(1))
            //                {
            //                    DG_mgroups.Rows[gi].Cells[2].Value = "Yes";
            //                }
            //                else
            //                {
            //                    DG_mgroups.Rows[gi].Cells[2].Value = "No";
            //                }
            //                DG_mgroups.Rows[gi].Cells[3].Value = dt_gi.Rows[gi]["NumToSelect"].ToString();
            //                if (Convert.ToByte(dt_gi.Rows[gi]["Forced"]).Equals(1))
            //                {
            //                    DG_mgroups.Rows[gi].Cells[4].Value = "Yes";
            //                }
            //                else
            //                {
            //                    DG_mgroups.Rows[gi].Cells[4].Value = "No";
            //                }
            //            }
            //        }
            //        if (dtinitem.Rows.Count > 0)
            //        {
            //            for (int it = 0; it < dtinitem.Rows.Count; it++)
            //            {
            //                DG_indv_items.Items.Add(dtinitem.DefaultView);
            //            }
            //        }
            //        if (prdt.Rows.Count > 0)
            //        {
            //            for (int pr = 0; pr < prdt.Rows.Count; pr++)
            //            {
            //                if (prdt.Rows[pr]["SalePriceType"].ToString().Equals("1"))
            //                {
            //                    lsb_sale_pricing.Items.Add("$" + Math.Round(Convert.ToDecimal(prdt.Rows[pr]["Price"]), 2).ToString() + " b/w  " + Convert.ToDateTime(prdt.Rows[pr]["Sale_Start"]).ToString("MM/dd/yyyy") + "  -  " + Convert.ToDateTime(prdt.Rows[pr]["Sale_End"]).ToString("MM/dd/yyyy"));
            //                    per.Add(prdt.Rows[pr]["Price"].ToString());
            //                }
            //                if (prdt.Rows[pr]["SalePriceType"].ToString().Equals("0"))
            //                {
            //                    lsb_sale_pricing.Items.Add(Math.Round(Convert.ToDecimal(prdt.Rows[pr]["Percent"]), 2).ToString() + "%" + " b/w  " + Convert.ToDateTime(prdt.Rows[pr]["Sale_Start"]).ToString("MM/dd/yyyy") + "  -  " + Convert.ToDateTime(prdt.Rows[pr]["Sale_End"]).ToString("MM/dd/yyyy"));
            //                    per.Add(prdt.Rows[pr]["SalePriceType"].ToString());
            //                }
            //            }
            //        }
            //        if (dtbulk.Rows.Count > 0)
            //        {
            //            for (int bul = 0; bul < dtbulk.Rows.Count; bul++)
            //            {
            //                if (Convert.ToInt32(dtbulk.Rows[bul]["Price_Type"]).Equals(0))
            //                {
            //                    if (dtbulk.Rows[bul]["Description"].ToString() != "")
            //                    {
            //                        lsb_bulk_pricing.Items.Add(Math.Round(Convert.ToDecimal(dtbulk.Rows[bul]["Bulk_Quan"]), 2).ToString() + "  For " + "$" + Math.Round(Convert.ToDecimal(dtbulk.Rows[bul]["Bulk_Price"]), 2) + " -" + dtbulk.Rows[bul]["Description"].ToString());
            //                    }
            //                    else
            //                    {
            //                        lsb_bulk_pricing.Items.Add(Math.Round(Convert.ToDecimal(dtbulk.Rows[bul]["Bulk_Quan"]), 2).ToString() + "  For " + "$" + Math.Round(Convert.ToDecimal(dtbulk.Rows[bul]["Bulk_Price"]), 2));
            //                    }

            //                }
            //                if (Convert.ToInt32(dtbulk.Rows[bul]["Price_Type"]).Equals(1))
            //                {
            //                    if (dtbulk.Rows[bul]["Description"].ToString() != "")
            //                    {
            //                        lsb_bulk_pricing.Items.Add(Math.Round(Convert.ToDecimal(dtbulk.Rows[bul]["Bulk_Quan"]), 2).ToString() + " For " + Math.Round(Convert.ToDecimal(dtbulk.Rows[bul]["Bulk_Price"]), 2) + " % " + " -" + dtbulk.Rows[bul]["Description"].ToString());
            //                    }
            //                    else
            //                    {
            //                        lsb_bulk_pricing.Items.Add(Math.Round(Convert.ToDecimal(dtbulk.Rows[bul]["Bulk_Quan"]), 2).ToString() + " For " + Math.Round(Convert.ToDecimal(dtbulk.Rows[bul]["Bulk_Price"]), 2) + " % ");
            //                    }
            //                }
            //            }
            //        }
            //        if (dttbae.Rows.Count > 0)
            //        {
            //            for (int tb = 0; tb < dttbae.Rows.Count; tb++)
            //            {
            //                if (Convert.ToInt32(dttbae.Rows[tb]["PriceType"]) != 2)
            //                {
            //                    day.set_days.Add(Convert.ToInt32(dttbae.Rows[tb]["Criteria3"]));

            //                    if (dttbae.Rows[tb]["Criteria3"].ToString().Equals("1"))
            //                    {
            //                        dayofweek = "Sun";
            //                    }
            //                    if (dttbae.Rows[tb]["Criteria3"].ToString().Equals("2"))
            //                    {
            //                        dayofweek = "Mon";
            //                    }
            //                    if (dttbae.Rows[tb]["Criteria3"].ToString().Equals("3"))
            //                    {
            //                        dayofweek = "Tue";
            //                    }
            //                    if (dttbae.Rows[tb]["Criteria3"].ToString().Equals("4"))
            //                    {
            //                        dayofweek = "Wed";
            //                    }
            //                    if (dttbae.Rows[tb]["Criteria3"].ToString().Equals("5"))
            //                    {
            //                        dayofweek = "Thu";
            //                    }
            //                    if (dttbae.Rows[tb]["Criteria3"].ToString().Equals("6"))
            //                    {
            //                        dayofweek = "Fri";
            //                    }
            //                    if (dttbae.Rows[tb]["Criteria3"].ToString().Equals("7"))
            //                    {
            //                        dayofweek = "Sat";
            //                    }

            //                    lsb_time_base.Items.Add("$" + Math.Round(Convert.ToDecimal(dttbae.Rows[tb]["Price"]), 2).ToString() + ", " + dayofweek + " " + dttbae.Rows[tb]["Criteria1"].ToString() + " - " + dttbae.Rows[tb]["Criteria1"].ToString());
            //                }
            //            }
            //        }
            //        if (choice_dt.Rows.Count > 0)
            //        {
            //            for (int ch = 0; ch < choice_dt.Rows.Count; ch++)
            //            {
            //                DG_choice_items.Rows.Add();
            //                DG_choice_items.Rows[DG_choice_items.Rows.Count - 1].Cells[0].Value = choice_dt.Rows[ch]["ItemNum"].ToString();
            //                DG_choice_items.Rows[DG_choice_items.Rows.Count - 1].Cells[1].Value = choice_dt.Rows[ch]["Description"].ToString();
            //                DG_choice_items.Rows[DG_choice_items.Rows.Count - 1].Cells[2].Value = choice_dt.Rows[ch]["Quantity"].ToString();
            //                DG_choice_items.Rows[DG_choice_items.Rows.Count - 1].Cells[3].Value = 0;
            //                DG_choice_items.Rows[DG_choice_items.Rows.Count - 1].Cells[4].Value = choice_dt.Rows[ch]["Price"].ToString();
            //            }
            //        }
            //        if (dt_chice_prop.Rows.Count > 0)
            //        {
            //            for (int ch = 0; ch < dt_chice_prop.Rows.Count; ch++)
            //            {
            //                DG_choice_items.Rows.Add();
            //                DG_choice_items.Rows[DG_choice_items.Rows.Count - 1].Cells[0].Value = dt_chice_prop.Rows[ch]["Value_ID"].ToString();
            //                DG_choice_items.Rows[DG_choice_items.Rows.Count - 1].Cells[1].Value = dt_chice_prop.Rows[ch]["descrip"].ToString();
            //                DG_choice_items.Rows[DG_choice_items.Rows.Count - 1].Cells[2].Value = "1";
            //                DG_choice_items.Rows[DG_choice_items.Rows.Count - 1].Cells[3].Value = 1;
            //                //DG_choice_items.Rows[DG_choice_items.Rows.Count - 1].Cells[4].Value = choice_dt.Rows[ch]["Price"].ToString();
            //            }
            //        }
            //        if (dt_copon_prices.Rows.Count > 0)
            //        {
            //            for (int cop = 0; cop < dt_copon_prices.Rows.Count; cop++)
            //            {
            //                if (Convert.ToInt32(dt_copon_prices.Rows[cop]["PriceType"]) != 2)
            //                {
            //                    int dup = 0;
            //                    int flag = 0;
            //                    int c = 1;
            //                    {
            //                        c = 1;
            //                        int day_id = Convert.ToInt32(dt_copon_prices.Rows[cop]["Criteria3"]);
            //                        int ccount = DG_coupon.ColumnCount;
            //                        for (c = 1; c < ccount; c++)
            //                        {
            //                            if (DG_coupon.Rows[day_id - 1].Cells[c].Value == null)
            //                            {
            //                                for (int x = 1; x < DG_coupon.ColumnCount; x++)
            //                                {
            //                                    try
            //                                    {
            //                                        if (DG_coupon.Rows[day_id - 1].Cells[x].Value.Equals(dt_copon_prices.Rows[cop]["Criteria1"].ToString() + "-" + dt_copon_prices.Rows[cop]["Criteria2"].ToString()))
            //                                        {
            //                                            dup = 1;
            //                                        }
            //                                    }
            //                                    catch (Exception)
            //                                    { }
            //                                }
            //                                if (dup != 1)
            //                                {
            //                                    DG_coupon.Rows[day_id - 1].Cells[c].Value = dt_copon_prices.Rows[cop]["Criteria1"].ToString() + "-" + dt_copon_prices.Rows[cop]["Criteria2"].ToString();
            //                                    c = ccount;
            //                                    flag = 1;
            //                                    dup = 0;
            //                                }
            //                            }
            //                        }
            //                        if (flag == 0)
            //                        {
            //                            for (int x = 1; x < DG_coupon.ColumnCount; x++)
            //                            {
            //                                try
            //                                {
            //                                    if (DG_coupon.Rows[day_id - 1].Cells[x].Value.Equals(dt_copon_prices.Rows[cop]["Criteria1"].ToString() + "-" + dt_copon_prices.Rows[cop]["Criteria1"].ToString()))
            //                                    {
            //                                        dup = 1;
            //                                    }
            //                                }
            //                                catch (Exception ex)
            //                                {
            //                                }
            //                            }
            //                            if (dup != 1)
            //                            {
            //                                DataGridViewColumn coll = new DataGridViewTextBoxColumn();
            //                                coll.Width = 140;
            //                                DG_coupon.Columns.Add(coll);
            //                                int ccc = coll.Index;
            //                                DG_coupon.Rows[day_id - 1].Cells[ccc].Value = dt_copon_prices.Rows[cop]["Criteria1"].ToString() + "-" + dt_copon_prices.Rows[cop]["Criteria1"].ToString();
            //                                c = ccount;
            //                                dup = 0;
            //                            }
            //                        }
            //                        dup = 0;
            //                    }
            //                }
            //            }
            //        }
            //        if (dt_copon.Rows.Count > 0)
            //        {
            //            txt_copon_expir_date.Text = Convert.ToDateTime(dt_copon.Rows[0]["Exp_Date"]).ToString("MM/dd/yyyy");
            //            txt_max_amount.Text = dt_copon.Rows[0]["Minimum_Amount_Restriction"].ToString();
            //            txt_days_bet.Text = dt_copon.Rows[0]["NumDays_Restriction"].ToString();
            //            chk_coupon_expire.IsChecked = Convert.ToBoolean(dt_copon.Rows[0]["Enforce_Exp"]);
            //            chk_exeption.IsChecked = Convert.ToBoolean(dt_copon.Rows[0]["Include_All_Except"]);
            //            chk_special_pricing.IsChecked = Convert.ToBoolean(dt_copon.Rows[0]["ApplyOnSpecialPricing"]);
            //            chk_parent_items.IsChecked = Convert.ToBoolean(dt_copon.Rows[0]["Apply_To_Parent"]);
            //            chk_allow_through_bonus.IsChecked = Convert.ToBoolean(dt_copon.Rows[0]["Coupon_Bonus_Only"]);
            //            chk_supress_bonus.IsChecked = Convert.ToBoolean(dt_copon.Rows[0]["Suppress_Bonus"]);
            //            chk_discounted_items.IsChecked = Convert.ToBoolean(dt_copon.Rows[0]["ApplyOnDiscountedItems"]);
            //            if (Convert.ToInt32(dt_copon.Rows[0]["Coupon_Flat_Percent"]) == 0)
            //            {
            //                rdb_flat_amount.IsChecked = true;
            //            }
            //            else if (Convert.ToInt32(dt_copon.Rows[0]["Coupon_Flat_Percent"]) == 1)
            //            {
            //                rdb_discount_amt.IsChecked = true;
            //            }
            //        }
            //        if (dt_crule.Rows.Count > 0)
            //        {
            //            for (int cr = 0; cr < dt_crule.Rows.Count; cr++)
            //            {
            //                DG_restriction.Rows.Add();
            //                if (Convert.ToInt32(dt_crule.Rows[cr]["Type"]).Equals(0))
            //                {
            //                    DG_restriction.Rows[cr].Cells[1].Value = "Item";
            //                }
            //                else if (Convert.ToInt32(dt_crule.Rows[cr]["Type"]).Equals(1))
            //                {
            //                    DG_restriction.Rows[cr].Cells[1].Value = "Department";
            //                }
            //                else if (Convert.ToInt32(dt_crule.Rows[cr]["Type"]).Equals(2))
            //                {
            //                    DG_restriction.Rows[cr].Cells[1].Value = "Category";
            //                }
            //                if (Convert.ToInt32(dt_crule.Rows[cr]["Allow_Or_Disallow"]).Equals(0))
            //                {
            //                    DG_restriction.Rows[cr].Cells[0].Value = "Include";
            //                }
            //                if (Convert.ToInt32(dt_crule.Rows[cr]["Allow_Or_Disallow"]).Equals(1))
            //                {
            //                    DG_restriction.Rows[cr].Cells[0].Value = "Exclude";
            //                }
            //                if (Convert.ToInt32(dt_crule.Rows[cr]["Allow_Or_Disallow"]).Equals(2))
            //                {
            //                    DG_restriction.Rows[cr].Cells[0].Value = "Exclusive";
            //                }
            //                DG_restriction.Rows[cr].Cells[3].Value = dt_crule.Rows[cr]["ID"].ToString();
            //                DG_restriction.Rows[cr].Cells[2].Value = dt_crule.Rows[cr]["Descrip"].ToString();
            //            }
            //        }
            //        if (dt_sale_history.Rows.Count > 0)
            //        {
            //            for (int sale = 0; sale < dt_sale_history.Rows.Count; sale++)
            //            {
            //                DG_sale_history.Rows.Add();
            //                DG_sale_history.Rows[sale].Cells[0].Value = Convert.ToDateTime(dt_sale_history.Rows[sale]["DateTime"]);
            //                DG_sale_history.Rows[sale].Cells[1].Value = dt_sale_history.Rows[sale]["Store_ID"].ToString();
            //                DG_sale_history.Rows[sale].Cells[2].Value = dt_sale_history.Rows[sale]["Invoice_Number"].ToString();
            //                DG_sale_history.Rows[sale].Cells[3].Value = Math.Round(Convert.ToDecimal(dt_sale_history.Rows[sale]["Quantity"]), 2).ToString();
            //                DG_sale_history.Rows[sale].Cells[4].Value = Math.Round(Convert.ToDecimal(dt_sale_history.Rows[sale]["PricePer"]), 2).ToString();
            //                DG_sale_history.Rows[sale].Cells[5].Value = Math.Round(Convert.ToDecimal(dt_sale_history.Rows[sale]["CostPer"]), 2).ToString();
            //                DG_sale_history.Rows[sale].Cells[6].Value = dt_sale_history.Rows[sale]["CustNum"].ToString();
            //                //  DG_sale_history.Rows[sale].Cells[7].Value = dt_sale_history.Rows[sale]["ItemNum"].ToString();
            //            }
            //        }
            //        fun_rental_index();
            //        fun_pending_order(0);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message);
            //}
        }
        private void clear_fields()
        {
            //DG_modifier_groups.ItemsSource = null;
            //DG_modifier_groups.Items.Clear();
            cmb_select_dept.SelectedIndex = -1;
            txt_item_number.Text = "";
            txt_item_descripton.Text = "";
            txt_item_description2.Text = "";
            txt_location.Clear();
            txt_days.Text = "0";
            txt_instock.Text = "1";
            txt_avg_cost.Text = "0.00";
            txt_price_ucharge.Text = "0.00";
            txt_price_withtax.Text = "0.00";
            txt_bonus.Text = "0";
            txt_barcodes.Text = "0";
            cmb_commission.SelectedIndex = 0;
            txt_comission.Text = "0.00";
            txt_unit_size.Text = "0";
            txt_unit_type.Clear();
            txt_prmp_todescrp.Text = "0";
            txt_glnumber.Text = "0";
            cmb_discountype.SelectedIndex = 0;
            txt_glnumber.Clear();
            rb_sold_by_price.IsChecked = true;
            chk_allow_buyback.IsChecked = false;
            chk_allow_depsit_invo.IsChecked = false;
            chk_allow_fleet.IsChecked = false;
            chk_allow_return.IsChecked = false;
            chk_auto_wiegh.IsChecked = false;
            chk_bar_tax.IsChecked = false;
            chk_change_modifier.IsChecked = false;
            chk_check2.IsChecked = false;
            chk_chek_id.IsChecked = false;
            chk_count_item.IsChecked = false;
            chk_disable_itm.IsChecked = false;
            chk_display_tax.IsChecked = false;
            chk_enable_markup.IsChecked = false;
            chk_exclude.IsChecked = false;
            chk_exclude_loyalty.IsChecked = false;
            chk_food_stamp.IsChecked = false;
            chk_forced.IsChecked = false;
            chk_kichen.IsChecked = false;
            chk_liablity_item.IsChecked = false;
            chk_modfier_item.IsChecked = false;
            chk_print_reciept.IsChecked = false;
            chk_print_ticket.IsChecked = false;
            chk_prmpt_price.IsChecked = false;
            chk_prmt_qty.IsChecked = false;
            chk_prompt_comp_date.IsChecked = false;
            chk_prompt_descrip.IsChecked = false;
            chk_prompt_invoice.IsChecked = false;
            chk_require_customer.IsChecked = false;
            chk_scale_deduct.IsChecked = false;
            chk_sell_asls.IsChecked = false;
            chk_special_permission.IsChecked = false;
            chk_tax1.IsChecked = false;
            chk_tax2.IsChecked = false;
            chk_tax3.IsChecked = false;
            chk_use_serial.IsChecked = false;
            item_image.Source = null;
            lstbx_skus.Items.Clear();
            lstbox_tag.Items.Clear();
            txt_inventory_notes.Clear();
            fun_fill_price_level();
            lsb_time_base.Items.Clear();
            lsb_sale_pricing.Items.Clear();
            lsb_bulk_pricing.Items.Clear();
            txt_copon_expir_date.Text = "";
            txt_days_valid.Text = "0";
            txt_coupon_discounted_price.Text = "0";
            txt_max_amount.Text = "0";

            //day.set_days.Clear();
            //day.set_days_name.Clear();
            per.Clear();
            DG_restriction.Rows.Clear();


        }
        private void fun_insert_update_inventory(string command_type)
        {

            int sale_item_type = 0;

            if (rb_sold_by_price.IsChecked.Value == true)
            {
                sale_item_type = 1;
            }
            if (rb_weighed_onsclae.IsChecked.Value == true)
            {
                sale_item_type = 2;
            }
            if (rb_weighed_with.IsChecked.Value == true)
            {
                sale_item_type = 3;
            }
            if (rb_barcoded.IsChecked.Value == true)
            {
                sale_item_type = 4;
            }
            try
            {
                //SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "inventory_insert_update_delete_pro";
                //cmd.Connection = glo.con;
                //cmd.CommandType = CommandType.StoredProcedure;
                //// the below data goes to inventory table
                //cmd.Parameters.Add("@ItemNum", SqlDbType.NVarChar).Value = txt_item_number.Text;
                //cmd.Parameters.Add("@ItemName", SqlDbType.NVarChar).Value = txt_item_descripton.Text;
                //cmd.Parameters.Add("@Store_ID", SqlDbType.NVarChar).Value = "1001";
                //cmd.Parameters.Add("@Cost", SqlDbType.Decimal).Value = txt_avg_cost.Text;
                //if (Grid_coupon.Visibility == Visibility.Visible)
                //{
                //    cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = txt_coupon_discounted_price.Text;
                //}
                //else
                //{
                //    cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = txt_price_ucharge.Text;
                //}
                //cmd.Parameters.Add("@Retail_Price", SqlDbType.Decimal).Value = txt_retail_price.Text;
                //cmd.Parameters.Add("@In_Stock", SqlDbType.Decimal).Value = txt_instock.Text;
                //cmd.Parameters.Add("@Reorder_Level", SqlDbType.Float).Value = txt_reorder_level.Text;
                //cmd.Parameters.Add("@Reorder_Quantity", SqlDbType.Float).Value = txt_reorder_qty.Text;
                //cmd.Parameters.Add("@Tax_1", SqlDbType.Bit).Value = Convert.ToByte(chk_tax1.IsChecked);
                //cmd.Parameters.Add("@Tax_2", SqlDbType.Bit).Value = Convert.ToByte(chk_tax2.IsChecked);
                //cmd.Parameters.Add("@Tax_3", SqlDbType.Bit).Value = Convert.ToByte(chk_tax3.IsChecked);
                //if (DG_ordering_info.Rows.Count > 0)
                //{
                //    for (int q = 0; q < DG_ordering_info.Rows.Count; q++)
                //    {
                //        if (DG_ordering_info.Rows[q].Cells[2].Value.Equals("True"))
                //        {
                //            cmd.Parameters.Add("@Vendor_Number", SqlDbType.NVarChar).Value = DG_ordering_info.Rows[q].Cells[6].Value.ToString();
                //            cmd.Parameters.Add("@Vendor_Part_Num", SqlDbType.NVarChar).Value = DG_ordering_info.Rows[q].Cells[3].Value.ToString();
                //        }
                //    }
                //}
                //else
                //{
                //    cmd.Parameters.Add("@Vendor_Number", SqlDbType.NVarChar).Value = null;
                //    cmd.Parameters.Add("@Vendor_Part_Num", SqlDbType.NVarChar).Value = null;
                //}
                //cmd.Parameters.Add("@Dept_ID", SqlDbType.NVarChar).Value = cmb_select_dept.SelectedValue;
                //cmd.Parameters.Add("@IsKit", SqlDbType.Bit).Value = 1;
                //cmd.Parameters.Add("@IsModifier", SqlDbType.Bit).Value = Convert.ToByte(chk_modfier_item.IsChecked);
                //if (Grid_kit_prices.IsVisible == true)
                //{
                //    cmd.Parameters.Add("@Kit_Override", SqlDbType.Money).Value = Convert.ToDouble(txt_overide_price.Text);
                //}
                //else
                //{
                //    cmd.Parameters.Add("@Kit_Override", SqlDbType.Money).Value = 0.00;
                //}
                //cmd.Parameters.Add("@Inv_Num_Barcode_Labels", SqlDbType.Int).Value = txt_barcodes.Text;
                //cmd.Parameters.Add("@Use_Serial_Numbers", SqlDbType.Bit).Value = Convert.ToByte(chk_use_serial.IsChecked);
                //cmd.Parameters.Add("@Num_Bonus_Points", SqlDbType.Int).Value = txt_bonus.Text;
                //if (((TabItem)tabcon_inventory.Items[8]).Header.Equals("Rental"))
                //{
                //    cmd.Parameters.Add("@IsRental", SqlDbType.Bit).Value = 1;
                //}
                //else
                //{
                //    cmd.Parameters.Add("@IsRental", SqlDbType.Bit).Value = 0;
                //}
                //cmd.Parameters.Add("@Use_Bulk_Pricing", SqlDbType.Bit).Value = 1;
                //cmd.Parameters.Add("@Print_Ticket", SqlDbType.Bit).Value = Convert.ToByte(chk_print_ticket.IsChecked);
                //cmd.Parameters.Add("@Print_Voucher", SqlDbType.Bit).Value = 1;
                //cmd.Parameters.Add("@Num_Days_Valid", SqlDbType.Int).Value = txt_days_valid.Text;
                //cmd.Parameters.Add("@IsMatrixItem", SqlDbType.Bit).Value = 1;
                //cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = txt_location.Text;
                //cmd.Parameters.Add("@AutoWeigh", SqlDbType.Bit).Value = Convert.ToByte(chk_auto_wiegh.IsChecked);
                //cmd.Parameters.Add("@numBoxes", SqlDbType.Int).Value = 1;
                //cmd.Parameters.Add("@Dirty", SqlDbType.Bit).Value = 1;
                //cmd.Parameters.Add("@Tear", SqlDbType.Real).Value = 2;
                //cmd.Parameters.Add("@NumPerCase", SqlDbType.Int).Value = number_incase_txt.Text;
                //cmd.Parameters.Add("@FoodStampable", SqlDbType.Bit).Value = Convert.ToByte(chk_food_stamp.IsChecked);
                //cmd.Parameters.Add("@ReOrder_Cost", SqlDbType.Money).Value = txt_reorder_cost.Text;
                //cmd.Parameters.Add("@Helper_ItemNum", SqlDbType.NVarChar).Value = "v1001";
                //cmd.Parameters.Add("@ItemName_Extra", SqlDbType.NVarChar).Value = txt_item_description2.Text;
                //cmd.Parameters.Add("@Exclude_Acct_Limit", SqlDbType.Bit).Value = 1;
                //if (Grid_kit_prices.IsVisible == true)
                //{
                //    cmd.Parameters.Add("@Check_ID", SqlDbType.Bit).Value = Convert.ToByte(chk_chek_id.IsChecked);
                //}
                //else
                //{
                //    cmd.Parameters.Add("@Check_ID", SqlDbType.Bit).Value = Convert.ToByte(chk_chek_id_before.IsChecked);
                //}
                //cmd.Parameters.Add("@Old_InStock", SqlDbType.Decimal).Value = 2.2;
                //cmd.Parameters.Add("@Date_Created", SqlDbType.DateTime).Value = DateTime.Now;
                //cmd.Parameters.Add("@ItemType", SqlDbType.SmallInt).Value = item_type;
                //cmd.Parameters.Add("@Prompt_Price", SqlDbType.Bit).Value = Convert.ToByte(chk_prmpt_price.IsChecked);
                //cmd.Parameters.Add("@Prompt_Quantity", SqlDbType.Bit).Value = Convert.ToByte(chk_prmt_qty.IsChecked);
                //cmd.Parameters.Add("@Inactive", SqlDbType.SmallInt).Value = Convert.ToByte(chk_disable_itm.IsChecked);
                //cmd.Parameters.Add("@Allow_BuyBack", SqlDbType.Bit).Value = Convert.ToByte(chk_allow_buyback.IsChecked);
                //cmd.Parameters.Add("@Last_Sold", SqlDbType.DateTime).Value = Convert.ToDateTime("12-12-2012");
                //cmd.Parameters.Add("@Unit_Type", SqlDbType.NVarChar).Value = txt_unit_type.Text;
                //cmd.Parameters.Add("@Unit_Size", SqlDbType.Float).Value = txt_unit_size.Text;
                //cmd.Parameters.Add("@Fixed_Tax", SqlDbType.Money).Value = 1200;
                //cmd.Parameters.Add("@DOB", SqlDbType.Money).Value = 1200;
                //cmd.Parameters.Add("@Special_Permission", SqlDbType.Bit).Value = Convert.ToByte(chk_special_permission.IsChecked);
                //cmd.Parameters.Add("@Prompt_Description", SqlDbType.Bit).Value = Convert.ToByte(chk_prompt_descrip.IsChecked);
                //cmd.Parameters.Add("@Check_ID2", SqlDbType.Bit).Value = Convert.ToByte(chk_check2.IsChecked);
                //cmd.Parameters.Add("@Count_This_Item", SqlDbType.Bit).Value = Convert.ToByte(chk_count_item.IsChecked);
                //cmd.Parameters.Add("@Transfer_Markup_Enabled", SqlDbType.Bit).Value = Convert.ToByte(chk_enable_markup.IsChecked);
                //if (chk_enable_markup.IsChecked == true)
                //{
                //    cmd.Parameters.Add("@Transfer_Cost_Markup", SqlDbType.Real).Value = Convert.ToDouble(txt_cost_marku.Text);
                //}
                //else if (chk_enable_markup.IsChecked == false)
                //{
                //    cmd.Parameters.Add("@Transfer_Cost_Markup", SqlDbType.Bit).Value = 0;
                //}
                //cmd.Parameters.Add("@Print_On_Receipt", SqlDbType.Bit).Value = Convert.ToByte(chk_print_reciept.IsChecked);
                //cmd.Parameters.Add("@As_Is", SqlDbType.Bit).Value = Convert.ToByte(chk_sell_asls.IsChecked);
                //cmd.Parameters.Add("@InStock_Committed", SqlDbType.SmallInt).Value = 1;
                //cmd.Parameters.Add("@RequireCustomer", SqlDbType.Bit).Value = Convert.ToByte(chk_require_customer.IsChecked);
                //cmd.Parameters.Add("@PromptCompletionDate", SqlDbType.Bit).Value = Convert.ToByte(chk_prompt_comp_date.IsChecked);
                //cmd.Parameters.Add("@PromptInvoiceNotes", SqlDbType.Bit).Value = Convert.ToByte(chk_prompt_invoice.IsChecked);
                //cmd.Parameters.Add("@Prompt_DescriptionOverDollarAmt", SqlDbType.Money).Value = txt_prmp_todescrp.Text;
                //cmd.Parameters.Add("@Exclude_From_Loyalty", SqlDbType.Bit).Value = Convert.ToByte(chk_exclude_loyalty.IsChecked);
                //cmd.Parameters.Add("@BarTaxInclusive", SqlDbType.Bit).Value = Convert.ToByte(chk_bar_tax.IsChecked);
                //cmd.Parameters.Add("@ScaleSingleDeduct", SqlDbType.Bit).Value = Convert.ToByte(chk_scale_deduct.IsChecked);
                //cmd.Parameters.Add("@GLNumber", SqlDbType.NVarChar).Value = txt_glnumber.Text;
                //cmd.Parameters.Add("@ModifierType", SqlDbType.Int).Value = 1;
                //cmd.Parameters.Add("@Position", SqlDbType.Int).Value = 1;
                //cmd.Parameters.Add("@numberOfFreeToppings", SqlDbType.Float).Value = 12.2;
                //cmd.Parameters.Add("@ScaleItemType", SqlDbType.Int).Value = sale_item_type;
                //cmd.Parameters.Add("@DiscountType", SqlDbType.Int).Value = cmb_discountype.SelectedIndex;
                //cmd.Parameters.Add("@AllowReturns", SqlDbType.Bit).Value = Convert.ToByte(chk_allow_return.IsChecked);
                //cmd.Parameters.Add("@SuggestedDeposit", SqlDbType.Money).Value = txt_sugested_deposit.Text;
                //cmd.Parameters.Add("@Liability", SqlDbType.Bit).Value = Convert.ToByte(chk_liablity_item.IsChecked);
                //cmd.Parameters.Add("@IsDeleted", SqlDbType.Bit).Value = 0;
                //cmd.Parameters.Add("@ItemLocale", SqlDbType.Int).Value = 1;
                //cmd.Parameters.Add("@QuantityRequired", SqlDbType.Decimal).Value = 12.2;
                //cmd.Parameters.Add("@AllowOnDepositInvoices", SqlDbType.Bit).Value = Convert.ToByte(chk_allow_depsit_invo.IsChecked);
                //cmd.Parameters.Add("@Import_Markup", SqlDbType.Real).Value = 12;
                //cmd.Parameters.Add("@PricePerMeasure", SqlDbType.Money).Value = 1200;
                //cmd.Parameters.Add("@UnitMeasure", SqlDbType.Float).Value = 12;
                //cmd.Parameters.Add("@ShipCompliantProductType", SqlDbType.NVarChar).Value = "pp";
                //cmd.Parameters.Add("@AlcoholContent", SqlDbType.Real).Value = 1200;
                //cmd.Parameters.Add("@AvailableOnline", SqlDbType.Bit).Value = 1;
                //cmd.Parameters.Add("@AllowOnFleetCard", SqlDbType.Bit).Value = Convert.ToByte(chk_allow_fleet.IsChecked);
                //cmd.Parameters.Add("@DoughnutTax", SqlDbType.Bit).Value = 1;
                //cmd.Parameters.Add("@DisplayTaxInPrice", SqlDbType.Bit).Value = Convert.ToByte(chk_display_tax.IsChecked);
                //cmd.Parameters.Add("@NeverPrintInKitchen", SqlDbType.Bit).Value = Convert.ToByte(chk_kichen.IsChecked);
                //// cmd.Parameters.Add("@DateTime", SqlDbType.DateTime).Value = DateTime.Now;
                //if (txt_inventory_notes.Text != "")
                //{
                //    cmd.Parameters.Add("@Notes", SqlDbType.NText).Value = txt_inventory_notes.Text;
                //}
                //// the below data goes to inventory_image table
                //if (item_image.Source != null)
                //{
                //    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = image_id();
                //    cmd.Parameters.Add("@ImageLocation", SqlDbType.NVarChar).Value = image_name;
                //}
                //// below is the parameter for command type
                //cmd.Parameters.Add("@StatementType", SqlDbType.VarChar).Value = command_type;
                //if (glo.con.State == ConnectionState.Closed)
                //{
                //    glo.con.Open();
                //}
                //cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            //glo.con.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (p == "PO")
            {
                SelectItemTypesForm obj = new SelectItemTypesForm();
                obj.ShowDialog();
                if (obj.set_item_flage != null)
                {
                    if (obj.set_item_flage.Equals("Standard"))
                    {
                        item_type = 0;
                        fun_disable();
                        txt_avg_cost.IsEnabled = true;
                        txt_instock.IsEnabled = true;
                        clear_fields();
                        grid_show_hide();
                        tabcon_inventory.Visibility = Visibility.Visible;
                        fun_show_stan();
                        image_name = null;
                    }
                    else if (obj.set_item_flage.Equals("modifier"))
                    {
                        item_type = 4;
                        fun_disable();
                        fun_hide_stan();
                        clear_fields();
                        image_name = null;
                        grid_show_hide();
                        Grid_modifiers_groups.Visibility = Visibility.Visible;
                    }
                    else if (obj.set_item_flage.Equals("Choice"))
                    {
                        item_type = 3;
                        fun_disable();
                        fun_hide_stan();
                        clear_fields();
                        image_name = null;
                        grid_show_hide();
                        Grid_choice_item.Visibility = Visibility.Visible;
                    }
                    else if (obj.set_item_flage.Equals("Kit"))
                    {
                        item_type = 2;
                        fun_disable();
                        fun_hide_stan();
                        clear_fields();
                        image_name = null;
                        grid_show_hide();
                        Grid_kit_prices.Visibility = Visibility.Visible;
                        Grid_kits.Visibility = Visibility.Visible;
                        chk_tax1.Visibility = Visibility.Visible;
                        chk_tax2.Visibility = Visibility.Visible;
                        chk_tax3.Visibility = Visibility.Visible;
                        chk_bar_tax.Visibility = Visibility.Visible;
                    }
                    else if (obj.set_item_flage.Equals("coupon"))
                    {
                        item_type = 7;
                        fun_disable();
                        fun_hide_stan();
                        clear_fields();
                        grid_show_hide();
                        Grid_coupon.Visibility = Visibility.Visible;
                        Grid_coupon_price.Visibility = Visibility.Visible;
                    }
                    lbl_heading_inventory.Content = "Enter Information For the Item and Touch Save";
                    obj.set_item_flage = null;
                    txt_item_descripton.Text = "New Item";
                    btn_add_item.Content = "Save";
                }
            }
            else
            {
                index = 0;
                tabcon_inventory.Visibility = Visibility.Visible;
                Grid_modifiers_groups.Visibility = Visibility.Hidden;
                Grid_choice_item.Visibility = Visibility.Hidden;
                txt_copon_expir_date.IsEnabled = false;
                fun_fill_combo();

                fun_add_days_to_coupon_gird();
                fun_fill_price_level();
                rb_pend_open.IsChecked = true;
                fun_retrive_inventory(index);
                txt_search_item_by_num.Focus();
                fun_pending_order(0);
            }
            fun_fill_combo();
            //fun_add_days_to_coupon_gird();
            //fun_fill_price_level();
            //fun_retrive_inventory(index);
        }

        private void fun_pending_order(int stat)
        {
            //DG_pending_orders.Rows.Clear();
            //string status = "";
            //string qury = "Select * from Inventory_PendingOrders where status = '" + stat + "' and ItemNum = '" + txt_item_number.Text + "'";
            //DataTable dt = glo.getdata(qury);
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    int sta = Convert.ToInt32(dt.Rows[i]["Status"]);
            //    if (sta == 0)
            //    {
            //        status = "Incomplete";
            //    }
            //    else if (sta == 1)
            //    {
            //        status = "Complete";
            //    }
            //    else if (sta == 2)
            //    {
            //        status = "Cancel";
            //    }
            //    DG_pending_orders.Rows.Add();
            //    DG_pending_orders.Rows[i].Cells[0].Value = dt.Rows[i]["Invoice_Number"].ToString();
            //    DG_pending_orders.Rows[i].Cells[1].Value = dt.Rows[i]["LineNum"].ToString();
            //    DG_pending_orders.Rows[i].Cells[2].Value = dt.Rows[i]["DueDate"].ToString();
            //    DG_pending_orders.Rows[i].Cells[3].Value = dt.Rows[i]["PickupType"].ToString();
            //    DG_pending_orders.Rows[i].Cells[4].Value = status.ToString();
            //    DG_pending_orders.Rows[i].Cells[5].Value = dt.Rows[i]["Store_ID"].ToString();
            //}


        }

        private void btn_exit_item_Click(object sender, RoutedEventArgs e)
        {
            if (btn_exit_item.Content.Equals("Exit"))
            {
                this.Close();
            }
            else if (btn_exit_item.Content.Equals("Cancel"))
            {
                fun_enable();
                fun_retrive_inventory(0);
            }
        }

        private void btn_add_item_Click(object sender, RoutedEventArgs e)
        {

            if (btn_add_item.Content.Equals("Add Item"))
            {
                SelectItemTypesForm obj = new SelectItemTypesForm();
                obj.ShowDialog();
                if (types.set_item_flage != null)
                {
                    if (types.set_item_flage.Equals("Standard"))
                    {
                        item_type = 0;
                        fun_disable();
                        txt_avg_cost.IsEnabled = true;
                        txt_instock.IsEnabled = true;
                        clear_fields();
                        grid_show_hide();
                        tabcon_inventory.Visibility = Visibility.Visible;
                        fun_show_stan();
                        image_name = null;
                    }
                    else if (types.set_item_flage.Equals("modifier"))
                    {
                        item_type = 4;
                        fun_disable();
                        fun_hide_stan();
                        clear_fields();
                        image_name = null;
                        grid_show_hide();
                        Grid_modifiers_groups.Visibility = Visibility.Visible;
                    }
                    else if (types.set_item_flage.Equals("Choice"))
                    {
                        item_type = 3;
                        fun_disable();
                        fun_hide_stan();
                        clear_fields();
                        image_name = null;
                        grid_show_hide();
                        Grid_choice_item.Visibility = Visibility.Visible;
                    }
                    else if (types.set_item_flage.Equals("Kit"))
                    {
                        item_type = 2;
                        fun_disable();
                        fun_hide_stan();
                        clear_fields();
                        image_name = null;
                        grid_show_hide();
                        Grid_kit_prices.Visibility = Visibility.Visible;
                        Grid_kits.Visibility = Visibility.Visible;
                        chk_tax1.Visibility = Visibility.Visible;
                        chk_tax2.Visibility = Visibility.Visible;
                        chk_tax3.Visibility = Visibility.Visible;
                        chk_bar_tax.Visibility = Visibility.Visible;
                    }
                    else if (types.set_item_flage.Equals("coupon"))
                    {
                        item_type = 7;
                        fun_disable();
                        fun_hide_stan();
                        clear_fields();
                        grid_show_hide();
                        Grid_coupon.Visibility = Visibility.Visible;
                        Grid_coupon_price.Visibility = Visibility.Visible;
                    }
                    lbl_heading_inventory.Content = "Enter Information For the Item and Touch Save";
                    types.set_item_flage = null;
                }
            }
            else if (btn_add_item.Content.Equals("Save"))
            {

                if (cmb_select_dept.SelectedIndex == -1 || txt_item_number.Text == "" || txt_item_descripton.Text == "")
                {
                    System.Windows.Forms.MessageBox.Show("Please Fill the Mandatory Fields", "Mandatory Fields?", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    cmb_select_dept.Focus();
                    return;
                }
                else
                {
                    InventoryClass objInventoryClass = new InventoryClass();
                    //command_type = "Insert";
                    //fun_insert_update_inventory(command_type);
                    int sale_item_type = 0;

                    if (rb_sold_by_price.IsChecked.Value == true)
                    {
                        sale_item_type = 1;
                    }
                    if (rb_weighed_onsclae.IsChecked.Value == true)
                    {
                        sale_item_type = 2;
                    }
                    if (rb_weighed_with.IsChecked.Value == true)
                    {
                        sale_item_type = 3;
                    }
                    if (rb_barcoded.IsChecked.Value == true)
                    {
                        sale_item_type = 4;
                    }

                    objInventoryClass.ItemNum = txt_item_number.Text;
                    objInventoryClass.ItemName = txt_item_descripton.Text;
                    objInventoryClass.Store_ID = "1001";
                    objInventoryClass.Cost = Convert.ToDecimal(txt_avg_cost.Text);
                    if (Grid_coupon.Visibility == Visibility.Visible)
                    {
                        objInventoryClass.Price = Convert.ToDecimal(txt_coupon_discounted_price.Text);
                    }
                    else
                    {
                        objInventoryClass.Price = Convert.ToDecimal(txt_price_ucharge.Text);
                    }
                    objInventoryClass.Retail_Price = Convert.ToDecimal(txt_retail_price.Text);
                    objInventoryClass.In_Stock = Convert.ToDecimal(txt_instock.Text);
                    objInventoryClass.Reorder_Level = Convert.ToDouble(txt_reorder_level.Text);
                    objInventoryClass.Reorder_Quantity = Convert.ToDouble(txt_reorder_qty.Text);
                    objInventoryClass.Tax_1 = Convert.ToByte(chk_tax1.IsChecked);
                    objInventoryClass.Tax_2 = Convert.ToByte(chk_tax2.IsChecked);
                    objInventoryClass.Tax_3 = Convert.ToByte(chk_tax3.IsChecked);
                    if (DG_ordering_info.Rows.Count > 0)
                    {
                        for (int q = 0; q < DG_ordering_info.Rows.Count; q++)
                        {
                            if (DG_ordering_info.Rows[q].Cells[2].Value.Equals("True"))
                            {
                                objInventoryClass.Vendor_Number = DG_ordering_info.Rows[q].Cells[6].Value.ToString();
                                objInventoryClass.Vendor_Part_Num = DG_ordering_info.Rows[q].Cells[3].Value.ToString();
                            }
                        }
                    }
                    else
                    {
                        objInventoryClass.Vendor_Number = null;
                        objInventoryClass.Vendor_Part_Num = null;
                    }
                    objInventoryClass.Dept_ID = cmb_select_dept.SelectedValue.ToString();
                    objInventoryClass.IsKit = 1;
                    objInventoryClass.IsModifier = Convert.ToByte(chk_modfier_item.IsChecked);
                    if (Grid_kit_prices.IsVisible == true)
                    {
                        objInventoryClass.Kit_Override = Convert.ToDouble(txt_overide_price.Text);
                    }
                    else
                    {
                        objInventoryClass.Kit_Override = 0.00;
                    }
                    objInventoryClass.Inv_Num_Barcode_Labels = Convert.ToInt32(txt_barcodes.Text);
                    objInventoryClass.Use_Serial_Numbers = Convert.ToByte(chk_use_serial.IsChecked);
                    objInventoryClass.Num_Bonus_Points = Convert.ToInt32(txt_bonus.Text);
                    if (((TabItem)tabcon_inventory.Items[8]).Header.Equals("Rental"))
                    {
                        objInventoryClass.IsRental = 1;
                    }
                    else
                    {
                        objInventoryClass.IsRental = 0;
                    }
                    objInventoryClass.Use_Bulk_Pricing = 1;
                    objInventoryClass.Print_Ticket = Convert.ToByte(chk_print_ticket.IsChecked);
                    objInventoryClass.Print_Voucher = 1;
                    objInventoryClass.Num_Days_Valid = Convert.ToInt32(txt_days_valid.Text);
                    objInventoryClass.IsMatrixItem = 1;
                    objInventoryClass.Location = txt_location.Text;
                    objInventoryClass.AutoWeigh = Convert.ToByte(chk_auto_wiegh.IsChecked);
                    objInventoryClass.numBoxes = 1;
                    objInventoryClass.Dirty = 1;
                    objInventoryClass.Tear = "2";
                    objInventoryClass.NumPerCase = Convert.ToInt32(number_incase_txt.Text);
                    objInventoryClass.FoodStampable = Convert.ToByte(chk_food_stamp.IsChecked);
                    objInventoryClass.ReOrder_Cost = Convert.ToDecimal(txt_reorder_cost.Text);
                    objInventoryClass.Helper_ItemNum = "v1001";
                    objInventoryClass.ItemName_Extra = txt_item_description2.Text;
                    objInventoryClass.Exclude_Acct_Limit = 1;
                    if (Grid_kit_prices.IsVisible == true)
                    {
                        objInventoryClass.Check_ID = Convert.ToByte(chk_chek_id.IsChecked);
                    }
                    else
                    {
                        objInventoryClass.Check_ID = Convert.ToByte(chk_chek_id_before.IsChecked);
                    }
                    objInventoryClass.Old_InStock = 2.2M;
                    objInventoryClass.Date_Created = DateTime.Now;
                    objInventoryClass.ItemType = item_type;
                    objInventoryClass.Prompt_Price = Convert.ToByte(chk_prmpt_price.IsChecked);
                    objInventoryClass.Prompt_Quantity = Convert.ToByte(chk_prmt_qty.IsChecked);
                    objInventoryClass.Inactive = Convert.ToByte(chk_disable_itm.IsChecked);
                    objInventoryClass.Allow_BuyBack = Convert.ToByte(chk_allow_buyback.IsChecked);
                    objInventoryClass.Last_Sold = Convert.ToDateTime("12-12-2012");
                    objInventoryClass.Unit_Type = txt_unit_type.Text;
                    objInventoryClass.Unit_Size = Convert.ToDouble(txt_unit_size.Text);
                    objInventoryClass.Fixed_Tax = 1200;
                    objInventoryClass.DOB = 1200;
                    objInventoryClass.Special_Permission = Convert.ToByte(chk_special_permission.IsChecked);
                    objInventoryClass.Prompt_Description = Convert.ToByte(chk_prompt_descrip.IsChecked);
                    objInventoryClass.Check_ID2 = Convert.ToByte(chk_check2.IsChecked);
                    objInventoryClass.Count_This_Item = Convert.ToByte(chk_count_item.IsChecked);
                    objInventoryClass.Transfer_Markup_Enabled = Convert.ToByte(chk_enable_markup.IsChecked);
                    if (chk_enable_markup.IsChecked == true)
                    {
                        objInventoryClass.Transfer_Cost_Markup = Convert.ToDouble(txt_cost_marku.Text);
                    }
                    else if (chk_enable_markup.IsChecked == false)
                    {
                        objInventoryClass.Transfer_Cost_Markup = 0;
                    }
                    objInventoryClass.Print_On_Receipt = Convert.ToByte(chk_print_reciept.IsChecked);
                    objInventoryClass.As_Is = Convert.ToByte(chk_sell_asls.IsChecked);
                    objInventoryClass.InStock_Committed = 1;
                    objInventoryClass.RequireCustomer = Convert.ToByte(chk_require_customer.IsChecked);
                    objInventoryClass.PromptCompletionDate = Convert.ToByte(chk_prompt_comp_date.IsChecked);
                    objInventoryClass.PromptInvoiceNotes = Convert.ToByte(chk_prompt_invoice.IsChecked);
                    objInventoryClass.Prompt_DescriptionOverDollarAmt = Convert.ToDecimal(txt_prmp_todescrp.Text);
                    objInventoryClass.Exclude_From_Loyalty = Convert.ToByte(chk_exclude_loyalty.IsChecked);
                    objInventoryClass.BarTaxInclusive = Convert.ToByte(chk_bar_tax.IsChecked);
                    objInventoryClass.ScaleSingleDeduct = Convert.ToByte(chk_scale_deduct.IsChecked);
                    objInventoryClass.GLNumber = txt_glnumber.Text;
                    objInventoryClass.ModifierType = 1;
                    objInventoryClass.Position = 1;
                    objInventoryClass.numberOfFreeToppings = 12.2;
                    objInventoryClass.ScaleItemType = sale_item_type;
                    objInventoryClass.DiscountType = cmb_discountype.SelectedIndex;
                    objInventoryClass.AllowReturns = Convert.ToByte(chk_allow_return.IsChecked);
                    objInventoryClass.SuggestedDeposit = Convert.ToDecimal(txt_sugested_deposit.Text);
                    objInventoryClass.Liability = Convert.ToByte(chk_liablity_item.IsChecked);
                    objInventoryClass.IsDeleted = 0;
                    objInventoryClass.ItemLocale = 1;
                    objInventoryClass.QuantityRequired = 12.2M;
                    objInventoryClass.AllowOnDepositInvoices = Convert.ToByte(chk_allow_depsit_invo.IsChecked);
                    objInventoryClass.Import_Markup = 12;
                    objInventoryClass.PricePerMeasure = 1200;
                    objInventoryClass.UnitMeasure = 12;
                    objInventoryClass.ShipCompliantProductType = "pp";
                    objInventoryClass.AlcoholContent = 1200;
                    objInventoryClass.AvailableOnline = 1;
                    objInventoryClass.AllowOnFleetCard = Convert.ToByte(chk_allow_fleet.IsChecked);
                    objInventoryClass.DoughnutTax = 1;
                    objInventoryClass.DisplayTaxInPrice = Convert.ToByte(chk_display_tax.IsChecked);
                    objInventoryClass.NeverPrintInKitchen = Convert.ToByte(chk_kichen.IsChecked);
                    // objInventoryClass.DateTime = DateTime.Now;
                    if (txt_inventory_notes.Text != "")
                    {
                       // objInventoryClass.Notes = txt_inventory_notes.Text;
                    }
                    objPOSManagementService.insertInventory(objInventoryClass);

                    if (tabcon_inventory.Visibility == Visibility.Visible)
                    {
                        fun_inset_pricelevl();
                        fun_inset_sku();
                        fun_isert_tag();
                        fun_insert_mod_witem();
                        fun_insert_ordering_info();
                        fun_insert_sale_price();
                        fun_insert_bulk_price();
                        fun_insert_time_price();
                    }
                    if (((TabItem)tabcon_inventory.Items[8]).Header.Equals("Rental"))
                    {
                        fun_insert_rental();
                    }
                    if (Grid_modifiers_groups.Visibility == Visibility.Visible)
                    {
                        fun_insert_modifier_groups();
                    }
                    if (Grid_choice_item.Visibility == Visibility.Visible)
                    {
                        fun_insert_choice_item();
                    }
                    if (Grid_kits.Visibility == Visibility.Visible)
                    {
                        fun_insert_kit();
                    }

                    if (Grid_coupon.Visibility == Visibility.Visible)
                    {
                        fun_insert_coupon();
                    }
                    var result = System.Windows.Forms.MessageBox.Show("Item Added Successfully, Do You Want to Add Another", "Information", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Information);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        fun_disable();
                        clear_fields();
                        image_name = null;
                    }
                    else
                    {
                        fun_enable();
                    }
                }
                if (p == "PO")
                {
                    item_id = txt_item_number.Text;
                    this.Close();
                }
            }
        }

        public string set_item_id
        {
            get { return item_id; }
            set { item_id = value; }
        }

        private void lbl_imge_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                fldlg.ShowDialog();
                {
                    image_name = fldlg.FileName;
                    ImageSourceConverter isc = new ImageSourceConverter();
                    item_image.SetValue(Image.SourceProperty, isc.ConvertFromString(image_name));
                }

                fldlg = null;
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
            }
        }

        private void cmb_select_dept_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void btn_tag_along_item_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SearchInventoryForm search_inventory = new SearchInventoryForm();
                search_inventory.ShowDialog();
                if (search_inventory.set_item_id != null)
                {
                    if (lstbox_tag.Items.Contains(search_inventory.set_item_id))
                    {
                        System.Windows.Forms.MessageBox.Show("This Tag_Along is Already in Your List of Tag_alongs for This Item", "Warning", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    }
                    else if (search_inventory.set_item_id == txt_item_number.Text)
                    {
                        System.Windows.Forms.MessageBox.Show("The Tag-Along May not be The Same as the Item Number", "Warning", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    }
                    else
                    {
                        lstbox_tag.Items.Add(search_inventory.set_item_id);
                    }
                }
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
            }
        }

        private void btn_item_next_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //if (i == 0)
                //{
                //    string quray = "select * from Inventory where IsDeleted = 0";
                //    DataTable dt = glo.getdata(quray);
                //    id = new List<string>();
                //    foreach (DataRow row in dt.Rows)
                //    {
                //        id.Add(row["ItemNum"].ToString());
                //    }

                //    i = 1;
                //    index = id.IndexOf(txt_item_number.Text);
                //}

                //if (index < id.Count - 1)
                //{
                //    index = index + 1;
                //    fun_retrive_inventory(index);
                //}
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
            }
        }

        private void btn_item_prev_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //if (j == 0)
                //{
                //    string quray = "select * from Inventory where IsDeleted = 0";
                //    DataTable dt = glo.getdata(quray);
                //    id = new List<string>();
                //    foreach (DataRow row in dt.Rows)
                //    {
                //        id.Add(row["ItemNum"].ToString());
                //    }
                //    j = 1;
                //    index = id.IndexOf(txt_item_number.Text);
                //}
                //if (index > 0)
                //{
                //    index = index - 1;
                //    fun_retrive_inventory(index);
                //}
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
            }
        }

        private void cmb_select_dept_DropDownClosed(object sender, EventArgs e)
        {
            fun_rental_index();
        }

        private void btn_savechages_item_Click(object sender, RoutedEventArgs e)
        {
            command_type = "Update";
            fun_insert_update_inventory(command_type);
            if (tabcon_inventory.Visibility == Visibility.Visible)
            {
                fun_inset_pricelevl();
                fun_inset_sku();
                fun_isert_tag();
                fun_insert_mod_witem();
                fun_insert_ordering_info();
                fun_insert_sale_price();
                fun_insert_bulk_price();
                fun_insert_time_price();
            }
            if (((TabItem)tabcon_inventory.Items[8]).Header.Equals("Rental"))
            {
                fun_insert_rental();
            }
            if (Grid_modifiers_groups.Visibility == Visibility.Visible)
            {
                fun_insert_modifier_groups();
            }
            if (Grid_choice_item.Visibility == Visibility.Visible)
            {
                fun_insert_choice_item();
            }
            if (Grid_kits.Visibility == Visibility.Visible)
            {
                fun_insert_kit();
            }
            if (Grid_coupon.Visibility == Visibility.Visible)
            {
                fun_insert_coupon();
            }

            System.Windows.Forms.MessageBox.Show("Changes Saved Successfully", "Save Changes", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
        }

        private void btn_delete_tag_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lstbox_tag.Items.RemoveAt(lstbox_tag.SelectedIndex);
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
            }
        }

        private void btn_remove_job_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lstbx_skus.Items.RemoveAt(lstbx_skus.SelectedIndex);
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
            }
        }

        private void btn_keyboard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                fun_load_keyboard(send_txbox, send_txbox.Text);
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
            }
        }

        private void txt_item_number_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Controls.TextBox focusedTextbox = (System.Windows.Controls.TextBox)sender;
            fun_load_keyboard(focusedTextbox, focusedTextbox.Text);
        }

        private void txt_item_descripton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Keyboard kye = new Keyboard(txt_item_descripton);
            //kye.ShowDialog();
            //txt_item_descripton.Text = kb.set_name.ToString();
        }

        private void txt_item_description2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Keyboard kye = new Keyboard(txt_item_description2);
            //kye.ShowDialog();
            //txt_item_description2.Text = kb.set_name.ToString();
        }

        private void btn_skus_Click(object sender, RoutedEventArgs e)
        {
            int fl = 0;
            int fg = 0;
            string lbl = "Enter SKUs for Item";
            Keyboard kyb = new Keyboard(lbl);
            kyb.ShowDialog();
            if (kyb.set_name != null)
            {
                POSManagementService managmentService = new POSManagementService();
                Inventory_SKUSClass objinventorySku = new Domain.Common.Inventory_SKUSClass();
                managmentService.getSku(objinventorySku);
                //string duplicate = "Select AltSKU from Inventory_SKUS";
                //glo.fun_search(duplicate);
                
                if (lstbx_skus.Items.Contains(kyb.set_name))
                {
                    System.Windows.Forms.MessageBox.Show("The SKU May not be Used More Than Once", "Warning", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    fg = 1;
                }
                if (fg != 1)
                {
                    //while (glo.dr.Read())
                    //{
                    for (int i = 0; i < objinventorySku.dtSku.Rows.Count; i++)
                    {
                        //if (glo.dr.GetString(0) == kyb.set_name)
                        if (objinventorySku.dtSku.Rows[i]["AltSKU"].ToString() == kyb.set_name)
                        {
                            System.Windows.Forms.MessageBox.Show("This SKU is already being Used by another Item", "Warning", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                            fg = 1;
                        }
                    }
                    //}
                }
                if (fl != 1 && fg != 1)
                {
                    lstbx_skus.Items.Add(kyb.set_name);
                }
            }
            //glo.dr.Close();
        }

        private void txt_search_item_by_num_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                fun_retrive_inventory(-1);
            }
        }

        private void btn_lookup_Click(object sender, RoutedEventArgs e)
        {
            //SearchInventory search = new SearchInventory();
            //search.ShowDialog();
            //fun_retrive_inventory(-2);
        }

        private void txt_bonus_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Controls.TextBox focusedTextbox = (System.Windows.Controls.TextBox)sender;
            fun_load_numkeyboard(focusedTextbox, focusedTextbox.Text);
        }

        private void btn_price_level_enable_Click(object sender, RoutedEventArgs e)
        {
            DG_price_level.CurrentRow.Cells[3].Value = "Yes";
        }

        private void btn_price_level_disable_Click(object sender, RoutedEventArgs e)
        {
            DG_price_level.CurrentRow.Cells[3].Value = "No";
        }

        private void DG_price_level_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)
                {
                    decimal amt;
                    decimal per = Convert.ToDecimal(DG_price_level.CurrentRow.Cells[2].Value);
                    decimal txt_value = Convert.ToDecimal(txt_price_ucharge.Text);
                    amt = txt_value - (per * txt_value) / 100;
                    DG_price_level.CurrentRow.Cells[1].Value = "$" + amt;
                    DG_price_level.CurrentRow.Cells[2].Value = DG_price_level.CurrentRow.Cells[2].Value + "%";
                }
                else if (e.ColumnIndex == 1)
                {
                    decimal per;
                    decimal amt = Convert.ToDecimal(DG_price_level.CurrentRow.Cells[1].Value);
                    decimal txt_value = Convert.ToDecimal(txt_price_ucharge.Text);
                    per = (txt_value - amt) / txt_value * 100;
                    DG_price_level.CurrentRow.Cells[2].Value = per.ToString() + "%";
                    DG_price_level.CurrentRow.Cells[1].Value = "$" + DG_price_level.CurrentRow.Cells[1].Value;
                }
            }
            catch (Exception)
            { }
        }

        private void btn_transfer_item_Click(object sender, RoutedEventArgs e)
        {
            fun_insert_rental();
        }

        private void chk_liablity_item_Checked(object sender, RoutedEventArgs e)
        {
            chk_tax1.IsChecked = false;
            chk_tax2.IsChecked = false;
            chk_tax3.IsChecked = false;
            chk_bar_tax.IsChecked = false;
            chk_display_tax.IsChecked = false;

            chk_tax1.IsEnabled = false;
            chk_tax2.IsEnabled = false;
            chk_tax3.IsEnabled = false;
            chk_bar_tax.IsEnabled = false;
            chk_display_tax.IsEnabled = false;
        }

        private void chk_liablity_item_Unchecked(object sender, RoutedEventArgs e)
        {

            chk_tax1.IsEnabled = true;
            chk_tax2.IsEnabled = true;
            chk_tax3.IsEnabled = true;
            chk_bar_tax.IsEnabled = true;
            chk_display_tax.IsEnabled = true;
        }

        private void DG_price_level_SelectionChanged(object sender, EventArgs e)
        {
            if (DG_price_level.CurrentRow.Cells[0].Value != null)
            {
                lbl_selected_level.Content = "Price Level: " + DG_price_level.CurrentRow.Cells[0].Value.ToString();
            }
        }

        private void chk_tax1_Checked(object sender, RoutedEventArgs e)
        {
            flg_chk = true;
        }

        private void chk_tax2_Checked(object sender, RoutedEventArgs e)
        {
            flg_chk = true;
        }

        private void chk_tax3_Checked(object sender, RoutedEventArgs e)
        {
            flg_chk = true;
        }

        private void chk_bar_tax_Checked(object sender, RoutedEventArgs e)
        {
            flg_chk = true;
        }

        private void chk_tax1_Unchecked(object sender, RoutedEventArgs e)
        {
            flg_chk = true;
        }

        private void chk_tax2_Unchecked(object sender, RoutedEventArgs e)
        {
            flg_chk = true;
        }

        private void chk_tax3_Unchecked(object sender, RoutedEventArgs e)
        {
            flg_chk = true;
        }

        private void txt_price_ucharge_GotFocus(object sender, RoutedEventArgs e)
        {
            if (flg_chk.Equals(true))
            {
                if (flg_tbvalu_tax.Equals(true))
                {
                    fun_cal_tax(1);
                    flg_chk = false;
                    flg_tbvalu_tax = false;
                }
                else
                {
                    flg_tbvalue = true;
                }
            }
        }

        private void txt_price_withtax_GotFocus(object sender, RoutedEventArgs e)
        {
            if (flg_chk.Equals(true))
            {
                if (flg_tbvalue.Equals(true))
                {
                    fun_cal_tax(-1);
                    flg_chk = false;
                    flg_tbvalue = false;
                }
                else
                {
                    flg_tbvalu_tax = true;
                }
            }
        }

        private void txt_price_ucharge_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                fun_fill_price_level();
                fun_cal_tax(-1);
            }
        }

        private void btn_add_modifers_Click(object sender, RoutedEventArgs e)
        {
            POSManagementService objManagmentService = new POSManagementService();
            ModiferGroupsForm mg = new ModiferGroupsForm();
            mg.ShowDialog();
          
            for (int i = 0; i < mg.mst.Count; i++)
            {
                string id_item = mg.mst[i].ToString();
                //string qry = "select ItemNum, ItemName, In_Stock,Price from Inventory where ItemNum = '" + id_item + "'";
                DataTable dt = objManagmentService.getIventory(id_item);
                DG_modifier_groups.Items.Add(dt.DefaultView);
            }
            mg.mst.Clear();

        }

        private void btn_remove_modifier_item_Click(object sender, RoutedEventArgs e)
        {
            while (DG_modifier_groups.SelectedItems.Count > 0)
            {
                DG_modifier_groups.Items.RemoveAt(DG_modifier_groups.SelectedIndex);
            }
        }

        private void rdb_groups_Checked(object sender, RoutedEventArgs e)
        {
            Wfh_mod_groups.Visibility = Visibility.Visible;
            //  DG_mgroups.Visibility = Visibility.Visible;
            DG_indv_items.Visibility = Visibility.Hidden;
            cmb_oprator.Visibility = Visibility.Visible;
            txt_select.Visibility = Visibility.Visible;
            txt_modi_descrip.Visibility = Visibility.Visible;
            txt_modi_pormpt.Visibility = Visibility.Visible;
            lbl1.Visibility = Visibility.Visible;
            lbl_d.Visibility = Visibility.Visible;
            lbl_p.Visibility = Visibility.Visible;
            tbmg.Text = "Add Modifier Group";
        }

        private void rdb_indivl_item_Checked(object sender, RoutedEventArgs e)
        {
            Wfh_mod_groups.Visibility = Visibility.Hidden;
            //  DG_mgroups.Visibility = Visibility.Hidden;
            DG_indv_items.Visibility = Visibility.Visible;
            cmb_oprator.Visibility = Visibility.Hidden;
            txt_select.Visibility = Visibility.Hidden;
            txt_modi_descrip.Visibility = Visibility.Hidden;
            txt_modi_pormpt.Visibility = Visibility.Hidden;
            lbl1.Visibility = Visibility.Hidden;
            lbl_d.Visibility = Visibility.Hidden;
            lbl_p.Visibility = Visibility.Hidden;
            tbmg.Text = "     Add Modifier";
        }

        private void btn_add_modifier_grp_Click(object sender, RoutedEventArgs e)
        {
            POSManagementService objManagmentService = new POSManagementService();
            if (DG_mgroups.Visible.Equals(true))
            {
               
                ModiferGroups2Form obj_mg = new ModiferGroups2Form();
                obj_mg.ShowDialog();
                if (obj_mg.set_id != null)
                {
                    try
                    {
                        DG_mgroups.Rows.Add();
                        mindex = DG_mgroups.Rows.Count - 1;
                       // string qry = "select ItemNum, ItemName,ItemName_Extra from Inventory where ItemNum = '" + obj_mg.set_id + "'";
                        DataTable dt = objManagmentService.getIventory(obj_mg.set_id);
                        DG_mgroups.Rows[mindex].Cells[0].Value = dt.Rows[0]["ItemName"].ToString();
                        DG_mgroups.Rows[mindex].Cells[1].Value = dt.Rows[0]["ItemName_Extra"].ToString();
                       // DG_mgroups.Rows[mindex].Cells[2].Value = charg.set_charge;
                        DG_mgroups.Rows[mindex].Cells[3].Value = cmb_oprator.Text.ToString() + "1";
                        DG_mgroups.Rows[mindex].Cells[4].Value = "Yes";
                        DG_mgroups.Rows[mindex].Cells[5].Value = dt.Rows[0]["ItemNum"].ToString();
                        txt_select.Text = "1";
                        txt_modi_descrip.Text = dt.Rows[0]["ItemName"].ToString();
                        txt_modi_pormpt.Text = dt.Rows[0]["ItemName_Extra"].ToString();
                        chk_forced.IsChecked = true;
                    }
                    catch (Exception)
                    {
                        // System.Windows.Forms.MessageBox.Show(ex.Message);
                    }
                }
            }
            if (DG_indv_items.Visibility == Visibility.Visible)
            {
                try
                {
                    ModiferGroupsForm mg = new ModiferGroupsForm();
                    mg.mst.Clear();
                    mg.ShowDialog();

                    for (int i = 0; i < mg.mst.Count; i++)
                    {
                        string id_item = mg.mst[i].ToString();
                       // string qry = "select ItemNum, ItemName from Inventory where ItemNum = '" + id_item + "'";
                        DataTable dt = objManagmentService.getIventory(id_item);
                        DG_indv_items.Items.Add(dt.DefaultView);
                    }
                    mg.mst.Clear();
                }
                catch (Exception)
                {
                }
            }
        }

        private void txt_select_GotFocus(object sender, RoutedEventArgs e)
        {
            if (DG_mgroups.Rows.Count > 0)
            {
                DG_mgroups.CurrentRow.Cells[3].Value = cmb_oprator.Text.ToString() + txt_select.Text;
            }
        }

        private void txt_select_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DG_mgroups.Rows.Count > 0)
            {
                DG_mgroups.CurrentRow.Cells[3].Value = cmb_oprator.Text.ToString() + txt_select.Text;
            }
        }

        private void DG_mgroups_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txt_modi_descrip.Text = DG_mgroups.CurrentRow.Cells[0].Value.ToString();
                txt_modi_pormpt.Text = DG_mgroups.CurrentRow.Cells[1].Value.ToString();
                string replacedString = Regex.Replace(DG_mgroups.CurrentRow.Cells[3].Value.ToString(), "[^=<]", "");
                string replacedString1 = Regex.Replace(DG_mgroups.CurrentRow.Cells[3].Value.ToString(), "[^0-9]", "");
                cmb_oprator.Text = replacedString.ToString();
                txt_select.Text = replacedString1.ToString();

                if (DG_mgroups.CurrentRow.Cells[4].Value.ToString().Equals("Yes"))
                {
                    chk_forced.IsChecked = true;
                }
                else if (DG_mgroups.CurrentRow.Cells[3].Value.ToString().Equals("No"))
                {
                    chk_forced.IsChecked = false;
                }
                if (DG_mgroups.CurrentRow.Cells[2].Value.ToString().Equals("Yes"))
                {
                    chk_change_modifier.IsChecked = true;
                }
                else if (DG_mgroups.CurrentRow.Cells[2].Value.ToString().Equals("No"))
                {
                    chk_change_modifier.IsChecked = false;
                }
            }
            catch (Exception)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void chk_change_modifier_Checked(object sender, RoutedEventArgs e)
        {
            if (DG_mgroups.Rows.Count > 0)
            {
                DG_mgroups.CurrentRow.Cells[2].Value = "Yes";
            }
        }

        private void chk_forced_Checked(object sender, RoutedEventArgs e)
        {
            if (DG_mgroups.Rows.Count > 0)
            {
                DG_mgroups.CurrentRow.Cells[4].Value = "Yes";
            }
        }

        private void chk_change_modifier_Unchecked(object sender, RoutedEventArgs e)
        {
            if (DG_mgroups.Rows.Count > 0)
            {
                DG_mgroups.CurrentRow.Cells[2].Value = "No";
            }
        }

        private void chk_forced_Unchecked(object sender, RoutedEventArgs e)
        {
            if (DG_mgroups.Rows.Count > 0)
            {
                DG_mgroups.CurrentRow.Cells[4].Value = "No";
            }
        }

        private void txt_modi_descrip_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DG_mgroups.Rows.Count > 0)
            {
                DG_mgroups.CurrentRow.Cells[0].Value = txt_modi_descrip.Text;
            }
        }

        private void txt_modi_pormpt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DG_mgroups.Rows.Count > 0)
            {
                DG_mgroups.CurrentRow.Cells[1].Value = txt_modi_pormpt.Text;
            }
        }

        private void add_pricing_btn_Click(object sender, RoutedEventArgs e)
        {
            int fgl = 0;
            SelectVendorForm v = new SelectVendorForm();

            v.ShowDialog();
            if (v.set_vid != null && kb.set_ven_part_num != null)
            {
                foreach (DataGridViewRow rr in DG_ordering_info.Rows)
                {
                    if (rr.Cells[3].Value.Equals(kb.set_ven_part_num))
                    {
                        fgl = 1;
                    }
                }
                if (fgl == 0)
                {
                    cost_per_txt.IsEnabled = true;
                    case_cost_txt.IsEnabled = true;
                    number_incase_txt.IsEnabled = true;
                    txt_cost_marku.IsEnabled = true;
                    chk_enable_markup.IsEnabled = true;
                    vendor_part_txt.IsEnabled = true;
                    DG_ordering_info.Rows.Add();
                    nindex = DG_ordering_info.Rows.Count - 1;
                    DG_ordering_info.Rows[nindex].Cells[0].Value = v.set_ven_id.ToString();
                    DG_ordering_info.Rows[nindex].Cells[1].Value = "0.00";
                    DG_ordering_info.Rows[nindex].Cells[2].Value = "False";
                    DG_ordering_info.Rows[nindex].Cells[3].Value = kb.set_ven_part_num.ToString();
                    DG_ordering_info.Rows[nindex].Cells[4].Value = "0.00";
                    DG_ordering_info.Rows[nindex].Cells[5].Value = "0";
                    DG_ordering_info.Rows[nindex].Cells[6].Value = v.set_vid.ToString();
                    vendor_part_txt.Text = kb.set_ven_part_num.ToString();
                    cost_per_txt.Text = "0.00";
                    case_cost_txt.Text = "0.00";
                    number_incase_txt.Text = "0";
                }
                else
                {

                }
            }
            v.set_ven_id = null;
        }

        private void set_ven_pref_btn_Click(object sender, RoutedEventArgs e)
        {
            if (DG_ordering_info.Rows.Count > 0)
            {
                for (int p = 0; p < DG_ordering_info.Rows.Count; p++)
                {
                    DG_ordering_info.Rows[p].Cells[2].Value = "False";
                }
                DG_ordering_info.CurrentRow.Cells[2].Value = "True";
            }
        }

        private void DG_ordering_info_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                cost_per_txt.Text = DG_ordering_info.CurrentRow.Cells[1].Value.ToString();
                case_cost_txt.Text = DG_ordering_info.CurrentRow.Cells[4].Value.ToString();
                number_incase_txt.Text = DG_ordering_info.CurrentRow.Cells[5].Value.ToString();
                vendor_part_txt.Text = DG_ordering_info.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception)
            { }
        }

        private void cost_per_txt_LostFocus(object sender, RoutedEventArgs e)
        {
            DG_ordering_info.CurrentRow.Cells[1].Value = cost_per_txt.Text;
        }

        private void case_cost_txt_LostFocus(object sender, RoutedEventArgs e)
        {
            DG_ordering_info.CurrentRow.Cells[4].Value = case_cost_txt.Text;
        }

        private void number_incase_txt_LostFocus(object sender, RoutedEventArgs e)
        {
            DG_ordering_info.CurrentRow.Cells[5].Value = number_incase_txt.Text;
        }

        private void vendor_part_txt_LostFocus(object sender, RoutedEventArgs e)
        {
            DG_ordering_info.CurrentRow.Cells[3].Value = vendor_part_txt.Text;
        }

        private void remove_pricing_btn_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataGridViewRow item in this.DG_ordering_info.SelectedRows)
            {
                if (DG_ordering_info.Rows.Count > 0)
                {
                    DG_ordering_info.Rows.RemoveAt(this.DG_ordering_info.SelectedRows[0].Index);
                }

            }
            if (DG_ordering_info.Rows.Count == 0)
            {
                //cost_per_txt.Text = "";
                //case_cost_txt.Text = "";
                //number_incase_txt.Text = "";
                // txt_cost_marku.Text = "";
                chk_enable_markup.IsChecked = false;
                // vendor_part_txt.Text = "";
                cost_per_txt.IsEnabled = false;
                case_cost_txt.IsEnabled = false;
                number_incase_txt.IsEnabled = false;
                // txt_cost_marku.IsEnabled = false;
                // chk_enable_markup.IsEnabled = false;
                vendor_part_txt.IsEnabled = false;
            }
        }

        private void btn_remove_modifier_Click(object sender, RoutedEventArgs e)
        {
            if (DG_mgroups.Visible.Equals(true))
            {

                foreach (DataGridViewRow item in this.DG_mgroups.SelectedRows)
                {
                    if (DG_mgroups.Rows.Count > 0)
                    {
                        DG_mgroups.Rows.RemoveAt(this.DG_mgroups.SelectedRows[0].Index);
                    }
                }
            }
            if (DG_indv_items.Visibility.Equals(Visibility.Visible))
            {
                while (DG_indv_items.SelectedItems.Count > 0)
                {
                    DG_indv_items.Items.RemoveAt(DG_indv_items.SelectedIndex);
                }
            }
        }

        private void add_salePrcie_btn_Click(object sender, RoutedEventArgs e)
        {
            int flg_price = 2;
            int ff = 0;
            SelectPriceTypeForm s = new SelectPriceTypeForm(flg_price);
            s.ShowDialog();
            CalenderForm caln = new CalenderForm(1);
            caln.ShowDialog();
            if (nkb.set_percentage != null && caln.set_end_date != Convert.ToDateTime("01/01/0001") && caln.set_start_date != Convert.ToDateTime("01/01/0001"))
            {

                for (int c = 0; c < lsb_sale_pricing.Items.Count; c++)
                {
                    string st1 = lsb_sale_pricing.Items[c].ToString();
                    int startIndex = st1.IndexOf("b/w ") + "b/w ".Length;
                    int endIndex = st1.IndexOf(" - ", startIndex);
                    string start_Date = st1.Substring(startIndex + 1, endIndex - startIndex - 2);
                    string end_date = st1.Substring(endIndex + 4, st1.Length - endIndex - 4);
                    if (Convert.ToDateTime(start_Date) == caln.set_start_date || Convert.ToDateTime(end_date) == caln.set_end_date)
                    {
                        ff = 1;
                    }
                }
                if (ff == 0)
                {
                    per.Add(nkb.set_percentage.ToString());
                    if (s.set_price_type == 1)
                    {
                        lsb_sale_pricing.Items.Add(nkb.set_percentage + "% " + " b/w  " + caln.set_start_date.ToString("MM/dd/yyyy") + "  -  " + caln.set_end_date.ToString("MM/dd/yyyy"));
                    }
                    else if (s.set_price_type == 0)
                    {
                        lsb_sale_pricing.Items.Add("$" + nkb.set_percentage + " b/w  " + caln.set_start_date.ToString("MM/dd/yyyy") + "  -  " + caln.set_end_date.ToString("MM/dd/yyyy"));
                    }
                }
                else
                {

                }
            }
            s.set_price_type = -1;
            flg_price = -1;
            ff = 0;
        }

        private void remove_saleprice_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                per.RemoveAt(lsb_sale_pricing.SelectedIndex);
                lsb_sale_pricing.Items.RemoveAt(lsb_sale_pricing.SelectedIndex);
            }
            catch (Exception)
            { }
        }

        private void add_bulkprice_btn_Click(object sender, RoutedEventArgs e)
        {
            int duplicate = 0;
            int flg_bulk = 1;
            SelectPriceTypeForm bulk = new SelectPriceTypeForm(flg_bulk);
            bulk.ShowDialog();
            if (nkb.set_percentage != null && nkb.set_quantity != null)
            {
                for (int chk = 0; chk < lsb_bulk_pricing.Items.Count; chk++)
                {
                    if (lsb_bulk_pricing.Items[chk].ToString().Substring(0, 2).Equals(nkb.set_quantity))
                    {
                        duplicate = 1;
                    }
                }
                if (duplicate == 0)
                {
                    if (bulk.set_price_type == 0)
                    {
                        lsb_bulk_pricing.Items.Add(Math.Round(Convert.ToDecimal(nkb.set_quantity), 2) + "  For " + "$" + Math.Round(Convert.ToDecimal(nkb.set_percentage), 2));
                    }
                    else if (bulk.set_price_type == 1)
                    {
                        lsb_bulk_pricing.Items.Add(nkb.set_quantity + " For " + nkb.set_percentage + " % ");
                    }
                }
            }
            bulk.set_price_type = -1;
            flg_bulk = -1;
            nkb.set_percentage = null;
            nkb.set_quantity = null;
            duplicate = 0;
        }

        private void remove_bulkpric_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lsb_bulk_pricing.Items.RemoveAt(lsb_bulk_pricing.SelectedIndex);
            }
            catch (Exception)
            {
            }
        }

        private void add_timebase_pric_btn_Click(object sender, RoutedEventArgs e)
        {
            DaysOfWeekForm day = new DaysOfWeekForm();
            day.ShowDialog();
            try
            {
                if (nkb.set_percentage != null && tm.set_start_time != null && tm.set_end_time != null)
                {
                    for (int t = 0; t < day.set_days.Count; t++)
                    {
                        lsb_time_base.Items.Add("$" + (Math.Round(Convert.ToDecimal(nkb.set_percentage), 2)).ToString() + ", " + day.set_days_name[t] + " " + tm.set_start_time + " - " + tm.set_end_time);
                    }
                    day.set_days.Clear();
                }
                else
                {
                }
                day.set_days.Clear();
            }
            catch (Exception)
            {
            }
        }

        private void remove_timebase_price_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lsb_time_base.Items.RemoveAt(lsb_time_base.SelectedIndex);
            }
            catch (Exception)
            {

            }
        }

        private void btn_dup_item_Click(object sender, RoutedEventArgs e)
        {
            txt_item_number.IsReadOnly = false;
            try
            {
                int no = Convert.ToInt32(txt_item_number.Text) + 1;
                txt_item_number.Text = no.ToString();
                txt_item_number.SelectAll();
            }
            catch (Exception)
            {
                txt_item_number.Text = txt_item_number.Text + "1";
            }
            fun_disable();
        }

        private void btn_add_chitem_Click(object sender, RoutedEventArgs e)
        {
            POSManagementService objPOSManagementService = new POSManagementService();
            int fll = 0;
            SearchInventoryForm choicItem = new SearchInventoryForm();
            choicItem.ShowDialog();
            if (choicItem.set_item_id != null)
            {
                foreach (DataGridViewRow rr in DG_choice_items.Rows)
                {
                    if (rr.Cells[0].Value.Equals(choicItem.set_item_id))
                    {
                        fll = 1;
                    }
                }
                if (fll == 0)
                {
                    //string str = "select ItemNum, ItemName,Price from Inventory where ItemNum = '" + choicItem.set_item_id + "'";
                    DataTable chocItem = objPOSManagementService.getIventory(choicItem.set_item_id);
                    DG_choice_items.Rows.Add();
                    DG_choice_items.Rows[DG_choice_items.Rows.Count - 1].Cells[0].Value = chocItem.Rows[0]["ItemNum"].ToString();
                    DG_choice_items.Rows[DG_choice_items.Rows.Count - 1].Cells[1].Value = chocItem.Rows[0]["ItemName"].ToString();
                    DG_choice_items.Rows[DG_choice_items.Rows.Count - 1].Cells[2].Value = "1";
                    DG_choice_items.Rows[DG_choice_items.Rows.Count - 1].Cells[3].Value = 0;
                    DG_choice_items.Rows[DG_choice_items.Rows.Count - 1].Cells[4].Value = chocItem.Rows[0]["Price"].ToString();
                    chocItem.Clear();
                }
                else
                {

                }
            }
        }

        private void btn_remove_chitm_Click(object sender, RoutedEventArgs e)
        {
            if (DG_choice_items.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow item in this.DG_choice_items.SelectedRows)
                {
                    DG_choice_items.Rows.RemoveAt(item.Index);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please First Select The Row(s)", "Warning", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_add_chitm_prop_Click(object sender, RoutedEventArgs e)
        {
            int fgg = 0;
            PropertyCategoryForm property = new PropertyCategoryForm();
            property.ShowDialog();
            if (property.set_property_id != null && property.set_value_id != null)
            {
                foreach (DataGridViewRow rrow in DG_choice_items.Rows)
                {
                    if (rrow.Cells[0].Value.Equals(property.set_value_id))
                    {
                        fgg = 1;
                    }
                }
                if (fgg == 0)
                {
                    //string proStr = "select Property_ID, Description +' : ' + Value_Description as Desrpt from VIEW_INVENTORY_PROPERTY where Value_ID = '" + property.set_value_id + "'";
                    ////DataTable pro_dt = glo.getdata(proStr);
                    //DG_choice_items.Rows.Add();
                    //DG_choice_items.Rows[DG_choice_items.Rows.Count - 1].Cells[0].Value = property.set_value_id;
                    //DG_choice_items.Rows[DG_choice_items.Rows.Count - 1].Cells[1].Value = pro_dt.Rows[0]["Desrpt"].ToString();
                    //DG_choice_items.Rows[DG_choice_items.Rows.Count - 1].Cells[2].Value = "1";
                    //DG_choice_items.Rows[DG_choice_items.Rows.Count - 1].Cells[3].Value = 1;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("This Value is Already associated With This Item", "Invalid", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                }
            }
        }

        private void btn_add_kit_Click(object sender, RoutedEventArgs e)
        {
            int kflg = 0;
            SearchInventoryForm kit_item = new SearchInventoryForm();
            kit_item.ShowDialog();
            if (ob.set_item_id != null)
            {
               // string chek = "select ItemNum, ItemType from Inventory where ItemType = 2";
                string chek = objPOSManagementService.getInventoryId("2");
                glo.fun_search(chek);
                while (glo.dr.Read())
                {
                    if (glo.dr.GetString(0) == ob.set_item_id)
                    {
                        kflg = 1;
                    }
                }
                glo.dr.Close();
                if (kflg != 1)
                {
                    string str_kit = "select ItemNum, ItemName, Price from Inventory where ItemNum = '" + ob.set_item_id + "'";
                    DataTable dt_kitt = glo.getdata(str_kit);
                    DG_kits.Rows.Add();
                    DG_kits.Rows[DG_kits.Rows.Count - 1].Cells[0].Value = dt_kitt.Rows[0]["ItemNum"].ToString();
                    DG_kits.Rows[DG_kits.Rows.Count - 1].Cells[1].Value = dt_kitt.Rows[0]["ItemName"].ToString();
                    DG_kits.Rows[DG_kits.Rows.Count - 1].Cells[2].Value = "1";
                    DG_kits.Rows[DG_kits.Rows.Count - 1].Cells[3].Value = dt_kitt.Rows[0]["Price"].ToString();
                    double pric = Convert.ToDouble(dt_kitt.Rows[0]["Price"]);
                    double totl = Convert.ToDouble(txt_kit_calcu_price.Text) + pric;
                    txt_kit_calcu_price.Text = totl.ToString();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Cann't Add a Kit to a Kit", "Warning", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                }
            }
        }

        private void btn_remove_kit_Click(object sender, RoutedEventArgs e)
        {
            if (DG_kits.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow item in this.DG_kits.SelectedRows)
                {
                    double pr = Convert.ToDouble(item.Cells[3].Value);
                    double sub = Convert.ToDouble(txt_kit_calcu_price.Text) - pr;
                    txt_kit_calcu_price.Text = sub.ToString();
                    DG_kits.Rows.RemoveAt(item.Index);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please First Select The Row", "Warning", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void rdb_overid_price_Checked(object sender, RoutedEventArgs e)
        {
            txt_overide_price.IsEnabled = true;
        }

        private void rdb_grid_price_Checked(object sender, RoutedEventArgs e)
        {
            txt_overide_price.IsEnabled = false;
        }

        private void rdb_cal_price_Checked(object sender, RoutedEventArgs e)
        {
            txt_overide_price.IsEnabled = false;
        }

        private void btn_delete_item_Click(object sender, RoutedEventArgs e)
        {
            var result = System.Windows.Forms.MessageBox.Show("Are You Sure You Want to Permenant Delete the Item No: " + txt_item_number.Text + "", "Run Time Support", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                InventoryClass objInventory = new InventoryClass();
                objInventory.IsDeleted = 1;
                objInventory.ItemNum = txt_item_number.Text;
                objPOSManagementService.updateImnventory(objInventory);
                //string delete_item = "update Inventory set IsDeleted = 1 where ItemNum = '" + txt_item_number.Text + "'";
                //glo.fun_insert(delete_item);

                //string quray = "select * from Inventory where IsDeleted = 0";
                DataTable dt = objPOSManagementService.GetInventoryFullInfo();
                id = new List<string>();
                foreach (DataRow row in dt.Rows)
                {
                    id.Add(row["ItemNum"].ToString());
                }

                i = 1;
                index = id.IndexOf(txt_item_number.Text);


                if (index < id.Count - 1)
                {
                    index = index + 1;
                    fun_retrive_inventory(index);
                }
            }
            else
            {
            }
        }

        private void btn_add_coupon_Click(object sender, RoutedEventArgs e)
        {
            int dup = 0;
            int flag = 0;
            int c = 1;
            string str = "Coupon";
            DaysOfWeekForm day = new DaysOfWeekForm(str);
            day.ShowDialog();
            if (tm.set_start_time != null && tm.set_end_time != null)
            {
                for (int d = 0; d < day.set_days.Count; d++)
                {
                    c = 1;
                    int day_id = Convert.ToInt32(day.set_days[d]);
                    int ccount = DG_coupon.ColumnCount;
                    for (c = 1; c < ccount; c++)
                    {
                        if (DG_coupon.Rows[day_id - 1].Cells[c].Value == null)
                        {
                            for (int x = 1; x < DG_coupon.ColumnCount; x++)
                            {
                                try
                                {
                                    if (DG_coupon.Rows[day_id - 1].Cells[x].Value.Equals(tm.set_start_time + " - " + tm.set_end_time))
                                    {
                                        dup = 1;
                                    }
                                }
                                catch (Exception)
                                { }
                            }
                            if (dup != 1)
                            {
                                DG_coupon.Rows[day_id - 1].Cells[c].Value = tm.set_start_time + " - " + tm.set_end_time;
                                c = ccount;
                                flag = 1;
                                dup = 0;
                            }
                        }
                    }
                    if (flag == 0)
                    {

                        for (int x = 1; x < DG_coupon.ColumnCount; x++)
                        {
                            try
                            {
                                if (DG_coupon.Rows[day_id - 1].Cells[x].Value.Equals(tm.set_start_time + " - " + tm.set_end_time))
                                {
                                    dup = 1;
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                        if (dup != 1)
                        {
                            DataGridViewColumn coll = new DataGridViewTextBoxColumn();
                            coll.Width = 140;
                            DG_coupon.Columns.Add(coll);
                            int ccc = coll.Index;
                            DG_coupon.Rows[day_id - 1].Cells[ccc].Value = tm.set_start_time + " - " + tm.set_end_time;
                            c = ccount;
                            dup = 0;
                        }
                    }
                    dup = 0;
                }
                day.set_days.Clear();
            }
        }

        private void btn_remove_coupon_Click(object sender, RoutedEventArgs e)
        {
            int flag = 0;
            foreach (DataGridViewCell c in DG_coupon.SelectedCells)
            {
                if (c.ColumnIndex != 0)
                {
                    if (c.ColumnIndex != 0)
                    {
                        c.Value = null;
                    }
                    try
                    {
                        if (DG_coupon.ColumnCount > c.ColumnIndex)
                        {
                            for (int i = c.ColumnIndex + 1; i < DG_coupon.ColumnCount; i++)
                            {
                                string n = DG_coupon.Rows[c.RowIndex].Cells[i].Value.ToString();
                                DG_coupon.Rows[c.RowIndex].Cells[i].Value = null;
                                DG_coupon.Rows[c.RowIndex].Cells[i - 1].Value = n;
                            }
                        }
                        for (int cc = 2; cc < DG_coupon.ColumnCount; cc++)
                        {
                            flag = 0;
                            for (int rr = 0; rr < DG_coupon.Rows.Count; rr++)
                            {
                                if (DG_coupon.Rows[rr].Cells[cc].Value != null)
                                {
                                    flag = 1;
                                }
                                else
                                {
                                    cindex = cc;
                                }
                            }
                            if (flag == 0)
                            {
                                DG_coupon.Columns.RemoveAt(cindex);
                            }
                        }

                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void chk_coupon_expire_Checked(object sender, RoutedEventArgs e)
        {
            txt_copon_expir_date.IsEnabled = true;
        }

        private void chk_coupon_expire_Unchecked(object sender, RoutedEventArgs e)
        {
            txt_copon_expir_date.IsEnabled = false;
        }

        private void btn_include_Click(object sender, RoutedEventArgs e)
        {
            fun_coupon_apply_rule(this.btn_include.Content.ToString());
        }

        private void btn_copon_exclude_Click(object sender, RoutedEventArgs e)
        {
            fun_coupon_apply_rule(this.btn_copon_exclude.Content.ToString());
        }

        private void btn_copon_exclusive_Click(object sender, RoutedEventArgs e)
        {
            fun_coupon_apply_rule(this.btn_copon_exclusive.Content.ToString());
        }

        private void btn_delete_copon_rule_Click(object sender, RoutedEventArgs e)
        {
            if (DG_restriction.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow item in this.DG_restriction.SelectedRows)
                {
                    DG_restriction.Rows.RemoveAt(item.Index);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please First Select The Row(s)", "Warning", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (Grid_coupon.Visibility == Visibility.Visible)
            {
                System.Windows.Forms.MessageBox.Show("You May not Create an Instant PO For This Type of Item", "Invalid Action", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
            }
            if (Grid_choice_item.Visibility == Visibility.Visible)
            {
                System.Windows.Forms.MessageBox.Show("You May not Create an Instant PO For This Type of Item", "Invalid Action", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
            }
            if (Grid_kits.Visibility == Visibility.Visible)
            {
                System.Windows.Forms.MessageBox.Show("You May not Create an Instant PO For This Type of Item", "Invalid Action", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
            }
            if (Grid_modifiers_groups.Visibility == Visibility.Visible)
            {
                System.Windows.Forms.MessageBox.Show("You May not Create an Instant PO For This Type of Item", "Invalid Action", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
            }
            if (tabcon_inventory.Visibility == Visibility.Visible)
            {
                Keyboard kbb = new Keyboard(txt_avg_cost.Text, "Enter Description For This Adjustment");
                kbb.ShowDialog();
                po_description = kb.set_decrep;
                double old_qty = Convert.ToDouble(txt_instock.Text);
                double old_cost = Convert.ToDouble(txt_avg_cost.Text);
                double new_qty = Convert.ToDouble(nkb.set_quantity);
                double new_cost = Convert.ToDouble(nkb.set_percentage);
                double new_ave1 = (old_qty * old_cost) + (new_qty * new_cost);
                double new_ave = new_ave1 / (old_qty + new_qty);
                txt_avg_cost.Text = Math.Round(new_ave, 4).ToString();
                txt_instock.Text = (old_qty + new_qty).ToString();

            }
        }

        private void txt_bonus_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                if (i == 0)
                {
                    InventoryClass objInventoryClass = new InventoryClass();
                    //string quray = "select * from Inventory where IsDeleted = 0";
                    //DataTable dt = glo.getdata(quray);
                    DataTable dt = objPOSManagementService.GetInventoryFullInfo();
                    id = new List<string>();
                    foreach (DataRow row in dt.Rows)
                    {
                        id.Add(row["ItemNum"].ToString());
                    }

                    i = 1;
                    index = id.IndexOf(txt_item_number.Text);
                }

                if (index < id.Count - 1)
                {
                    index = index + 1;
                    fun_retrive_inventory(index);
                }
            }
            if (e.Key == Key.Left)
            {
                if (j == 0)
                {
                    //string quray = "select * from Inventory where IsDeleted = 0";
                    DataTable dt = objPOSManagementService.GetInventoryFullInfo();
                    id = new List<string>();
                    foreach (DataRow row in dt.Rows)
                    {
                        id.Add(row["ItemNum"].ToString());
                    }
                    j = 1;
                    index = id.IndexOf(txt_item_number.Text);
                }
                if (index > 0)
                {
                    index = index - 1;
                    fun_retrive_inventory(index);
                }
            }

        }

        private void txt_copon_expir_date_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CalenderForm calnder = new CalenderForm("Select Expiration Date");
            calnder.ShowDialog();
            txt_copon_expir_date.Text = caln.set_the_date.ToString("MM/dd/yyyy");
        }

        private void btn_add_rental_price_Click(object sender, RoutedEventArgs e)
        {
            NumberKeypaid objj = new NumberKeypaid(12);
            objj.ShowDialog();
            NumberKeypaid ojj = new NumberKeypaid(13);
            ojj.ShowDialog();
            if (nkb.set_quantity != null && nkb.set_percentage != null)
            {
                for (int dup = 0; dup < dg_rent.Rows.Count; dup++)
                {
                    if (dg_rent.Rows[dup].Cells[0].Value.ToString().Equals(nkb.set_quantity))
                    {
                        return;
                    }
                }
                dg_rent.Rows.Add();
                dg_rent.Rows[dg_rent.Rows.Count - 1].Cells[0].Value = nkb.set_quantity.ToString();
                dg_rent.Rows[dg_rent.Rows.Count - 1].Cells[1].Value = "$" + nkb.set_percentage.ToString();
            }
            nkb.set_quantity = null;
            nkb.set_percentage = null;
        }

        private void btn_remove_rental_price_Click(object sender, RoutedEventArgs e)
        {
            if (dg_rent.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow item in this.dg_rent.SelectedRows)
                {
                    dg_rent.Rows.RemoveAt(item.Index);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please First Select The Row(s)", "Warning", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_set_description_Click(object sender, RoutedEventArgs e)
        {
            string txt_value = "";
            if (lsb_bulk_pricing.SelectedItems.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("You Must Select a Bulk Price To Set a Description", "Warning", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
            }
            else
            {
                if (lsb_bulk_pricing.SelectedItem.ToString().Contains('-'))
                {
                    string[] split_str = lsb_bulk_pricing.SelectedItem.ToString().Split('-');
                    string str = split_str[1];
                    txt_value = str;
                }
                else
                {
                    txt_value = "";
                }
                Keyboard kkb = new Keyboard("Enter Description", txt_value);
                kkb.ShowDialog();
                if (kkb.set_decrep != null)
                {
                    if (lsb_bulk_pricing.SelectedItem.ToString().Contains('-'))
                    {
                        string[] value = lsb_bulk_pricing.SelectedItem.ToString().Split('-');
                        string str2 = value[0];
                        lsb_bulk_pricing.Items.RemoveAt(lsb_bulk_pricing.SelectedIndex);
                        lsb_bulk_pricing.Items.Add(str2 + " -" + kkb.set_decrep.ToString());
                    }
                    else
                    {
                        string str1 = lsb_bulk_pricing.SelectedItem.ToString();
                        lsb_bulk_pricing.Items.RemoveAt(lsb_bulk_pricing.SelectedIndex);
                        lsb_bulk_pricing.Items.Add(str1 + " -" + kkb.set_decrep.ToString());
                    }
                }
            }
            kb.set_decrep = null;
        }

        private void txt_copon_expir_date_LostFocus(object sender, RoutedEventArgs e)
        {
            if (check_date(txt_copon_expir_date).Equals(false))
            {
                System.Windows.Forms.MessageBox.Show("You have Entered an Invalid Expiration Date, Try again ", "Warning", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                txt_copon_expir_date.Clear();
                txt_copon_expir_date.Focus();
            }
        }
        public bool check_date(System.Windows.Controls.TextBox ctrl)
        {
            if (!string.IsNullOrEmpty(ctrl.Text))
            {
                string[] formats = { "M/d/yyyy", "M/d/yy" };
                DateTime value;

                if (!DateTime.TryParseExact(ctrl.Text, formats, new CultureInfo("en-US"), DateTimeStyles.None, out value))
                {
                    return false;
                }
            }
            return true;
        }

        private void txt_item_number_GotFocus(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TextBox focusedTextbox = (System.Windows.Controls.TextBox)sender;
            send_txbox = focusedTextbox;
        }

        public System.Windows.Controls.TextBox set_textbox
        {
            get { return send_txbox; }
            set { send_txbox = value; }
        }

        private void rb_pend_open_Checked(object sender, RoutedEventArgs e)
        {
            fun_pending_order(0);

        }

        private void rb_pend_comp_Checked(object sender, RoutedEventArgs e)
        {
            fun_pending_order(1);
        }

        private void rb_pend_cancel_Checked(object sender, RoutedEventArgs e)
        {
            fun_pending_order(2);
        }

        private void btn_comlete_order_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (rb_pend_open.IsChecked == true)
                {
                    Inventory_PendingOrdersClass objInvPendingOrders = new Inventory_PendingOrdersClass();
                    objInvPendingOrders.Status = 1;
                    objInvPendingOrders.ItemNum = txt_item_number.Text;
                    objInvPendingOrders.Invoice_Number = Convert.ToInt32(DG_pending_orders.CurrentRow.Cells[0].Value);
                    objPOSManagementService.updatePendingOreders(objInvPendingOrders);
                    DG_pending_orders.Rows.Clear();
                    fun_pending_order(0);
                }
            }
            catch (Exception)
            { }
        }

        private void btn_cancel_order_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (rb_pend_open.IsChecked == true)
                {
                    Inventory_PendingOrdersClass objInvPendingOrders = new Inventory_PendingOrdersClass();
                    objInvPendingOrders.Status = 2;
                    objInvPendingOrders.ItemNum = txt_item_number.Text;
                    objInvPendingOrders.Invoice_Number = Convert.ToInt32(DG_pending_orders.CurrentRow.Cells[0].Value);
                    objPOSManagementService.updatePendingOreders(objInvPendingOrders);
                    DG_pending_orders.Rows.Clear();
                    fun_pending_order(0);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
