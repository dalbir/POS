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
using POS.Retail.Views;
using POS.Domain.Common;
using POS.Services.Common;
using System.Data;
using POS.Retail.Common;

namespace POS.Retail.Views
{
    /// <summary>
    /// Interaction logic for Mix_NMatch.xaml
    /// </summary>
    public partial class Mix_NMatch : Window
    {
        public Mix_NMatch()
        {
            InitializeComponent();
        }
        RegexClass objRegix = new RegexClass();
        POSManagementService objPosManagementService = new POSManagementService();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                cmbPriceGroup.Items.Add("Discount Amount");
                cmbPriceGroup.Items.Add("Bulk Price");
                cmbPriceGroup.Items.Add("Discount %");
                DepartmentClass objDept = new DepartmentClass();
                objDept.Store_ID = "1001";
                DataTable dt = objPosManagementService.getDepartment(objDept);
                if (dt.Rows.Count > 0)
                {
                    cmbDepartment.ItemsSource = dt.DefaultView;
                    cmbDepartment.DisplayMemberPath = "Description";
                    cmbDepartment.SelectedValuePath = "Dept_ID";
                }
                txtPriceGroupID.IsEnabled = false;
                FillSearchCombo();
                RetriveingRecords();
            }
            catch (Exception ex)
            {               
               CustomLogging.Log("[Error:]", ex.Message);
            }
        }

        private void cmbPriceGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (this.cmbPriceGroup.SelectedIndex == 0)
                {
                    lblAmount.Content = "Amount to Discount";
                    dgDiscountLevel.Visibility = Visibility.Hidden;
                    lblDiscountLevel.Visibility = Visibility.Hidden;
                    chkbLocalPrice.Visibility = Visibility.Hidden;
                    chkbTax2.Visibility = Visibility.Visible;
                    grdTax.Visibility = Visibility.Visible;
                    btnAddDiscountLevel.Visibility = Visibility.Hidden;
                    btnDeleteDiscount.Visibility = Visibility.Hidden;
                }
                else if (this.cmbPriceGroup.SelectedIndex == 1)
                {
                    lblAmount.Content = "Bulk Price";
                    dgDiscountLevel.Visibility = Visibility.Visible;
                    lblDiscountLevel.Visibility = Visibility.Visible;
                    chkbLocalPrice.Visibility = Visibility.Visible;
                    chkbTax2.Visibility = Visibility.Hidden;
                    grdTax.Visibility = Visibility.Hidden;
                    btnAddDiscountLevel.Visibility = Visibility.Visible;
                    btnDeleteDiscount.Visibility = Visibility.Visible;
                }
                else if (this.cmbPriceGroup.SelectedIndex == 2)
                {
                    lblAmount.Content = "Discount Percentage";
                    dgDiscountLevel.Visibility = Visibility.Visible;
                    lblDiscountLevel.Visibility = Visibility.Visible;
                    chkbLocalPrice.Visibility = Visibility.Visible;
                    chkbTax2.Visibility = Visibility.Hidden;
                    grdTax.Visibility = Visibility.Hidden;
                    btnAddDiscountLevel.Visibility = Visibility.Visible;
                    btnDeleteDiscount.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Error:]", ex.Message);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            // insertion in inventory table
                if(txtPriceGroupID.Text == "")
                {
                    MessageBox.Show("A Group ID is required in order to add a Group.", "Run Time Support", MessageBoxButton.OK, MessageBoxImage.Stop);
                    txtPriceGroupID.Background = Brushes.Yellow;
                    txtPriceGroupID.Focus();
                    return;
                }
                else
                {
                    txtPriceGroupID.Background = Brushes.White;
                }
                if(txtDescription.Text == "")
                {
                    MessageBox.Show("A description is required in order to add a Group.", "Run Time Support", MessageBoxButton.OK, MessageBoxImage.Stop);
                    txtDescription.Background = Brushes.Yellow;
                    txtDescription.Focus();
                    return;                   
                }
                else
                {
                    txtDescription.Background = Brushes.White;
                }
                InventoryClass objInventoryClass = new InventoryClass();
                objInventoryClass.Store_ID = "1001";
                objInventoryClass.ItemNum = txtPriceGroupID.Text;
                objInventoryClass.ItemName = txtDescription.Text;
                if (txtAmount.Text == "")
                    objInventoryClass.Price = 0;
                else
                {
                    if (cmbPriceGroup.SelectedIndex == 2)
                    {
                        objInventoryClass.Price = Convert.ToDecimal(txtAmount.Text) / 100;
                    }
                    else
                    {
                        objInventoryClass.Price = Convert.ToDecimal(txtAmount.Text);
                    }
                }
                objInventoryClass.Tax_1 = Convert.ToByte(chkTax1.IsChecked);
                objInventoryClass.Tax_2 = Convert.ToByte(chkbTax2.IsChecked);
                objInventoryClass.Tax_3 = Convert.ToByte(chkbTax3.IsChecked);
                objInventoryClass.Date_Created = Convert.ToDateTime(DateTime.Today);
                objInventoryClass.Last_Sold = Convert.ToDateTime(DateTime.Today);
                objInventoryClass.FoodStampable = Convert.ToByte(chkbFoodstampable.IsChecked);
                objInventoryClass.Dept_ID = Convert.ToString(cmbDepartment.SelectedValue);
                if (cmbPriceGroup.SelectedIndex == 0)
                {
                    objInventoryClass.ItemType = 1;
                }
                else if (cmbPriceGroup.SelectedIndex == 1)
                {
                    objInventoryClass.ItemType = 5;
                }
                else if (cmbPriceGroup.SelectedIndex == 0)
                {
                    objInventoryClass.ItemType = 6;
                }
                objInventoryClass.Dirty = 1;
                if (txtQuantity.Text == "")
                    objInventoryClass.QuantityRequired = 0;
                else
                objInventoryClass.QuantityRequired = Convert.ToDecimal(txtQuantity.Text);
                objInventoryClass.AllowReturns = 1;
                objInventoryClass.Print_On_Receipt = 1;
                objInventoryClass.Count_This_Item = 1;
                objPosManagementService.checkItemExist(objInventoryClass);
                if (objInventoryClass.checkItemExist == "")
                {
                    objPosManagementService.insertInventory(objInventoryClass);
                }
                else
                {
                    objPosManagementService.SaveChangesInventory(objInventoryClass);
                }
                if(objInventoryClass.IsSuccessfull == true)
                {
                    //insertion in onsale info and inventory_reference
                    Inventory_OnSale_InfoClass objIvnOnsaleInfo = new Inventory_OnSale_InfoClass();
                    objIvnOnsaleInfo.Store_ID = "1001";
                    objIvnOnsaleInfo.ItemNum = txtPriceGroupID.Text;
                    objIvnOnsaleInfo.Sale_Start = Convert.ToDateTime(txtStartDate.SelectedDate);
                    objIvnOnsaleInfo.Sale_End = Convert.ToDateTime(txtEndDate.SelectedDate);
                    objPosManagementService.insertOnSaleInfo(objIvnOnsaleInfo);

                    // insertion of items in kit index from dgItems
                    Kit_IndexClass objKitIndex = new Kit_IndexClass();
                    objKitIndex.Store_ID = "1001";
                    objKitIndex.Kit_ID = txtPriceGroupID.Text;
                    objKitIndex.Discount = 0;
                    objKitIndex.Quantity = 0;
                    objKitIndex.quryFlage = "delete";
                    for(int i =0; i<dgItems.Items.Count; i++)
                    {
                        DataGridRow rowss = (DataGridRow)dgItems.ItemContainerGenerator.ContainerFromIndex(i);
                        objKitIndex.ItemNum = (dgItems.Columns[0].GetCellContent(rowss) as TextBlock).Text;
                        objPosManagementService.InsertItemsinKitindex(objKitIndex);
                    }

                    // insertion of discount level in table: inventory_mixnMatch_level
                    if(dgDiscountLevel.Visibility == Visibility.Visible)
                    {
                        Inventory_MixNMatch_LevelsClass objMixNMatchLevel = new Inventory_MixNMatch_LevelsClass();
                        objMixNMatchLevel.Store_ID = "1001";
                        objMixNMatchLevel.ItemNum = txtPriceGroupID.Text;
                        objMixNMatchLevel.qryFlage = "delete";
                        for(int i=0; i< dgDiscountLevel.Items.Count; i++)
                        {
                            DataGridRow rowss = (DataGridRow)dgDiscountLevel.ItemContainerGenerator.ContainerFromIndex(i);
                            objMixNMatchLevel.Quantity = Convert.ToDouble((dgDiscountLevel.Columns[0].GetCellContent(rowss) as TextBlock).Text);
                            objMixNMatchLevel.Amount = Convert.ToDouble((dgDiscountLevel.Columns[1].GetCellContent(rowss) as TextBlock).Text);
                            objPosManagementService.insertDiscountLevels(objMixNMatchLevel);
                        } 
                    }
                    // insertion in inventory Bump bar setting Table: Inventory_BumpBarSettings
                    Inventory_BumpBarSettingsClass objBumpBarSetting = new Inventory_BumpBarSettingsClass();
                    objBumpBarSetting.Store_ID = "1001";
                    objBumpBarSetting.ItemNum = txtPriceGroupID.Text;
                    objBumpBarSetting.Backcolor = 0;
                    objBumpBarSetting.Forecolor = 2;
                    objPosManagementService.insertBumpBarSetting(objBumpBarSetting);

                    // insertion of additional infor Table: Inventory_AdditionalInfo
                    Inventory_AdditionalInfoClass objinvAdditionalInfo = new Inventory_AdditionalInfoClass();
                    objinvAdditionalInfo.Store_ID = "1001";
                    objinvAdditionalInfo.ItemNum = txtPriceGroupID.Text;              
                    objinvAdditionalInfo.ReleaseDate = Convert.ToDateTime(DateTime.Today);
                    objPosManagementService.insertAdditionalInfo(objinvAdditionalInfo);

                    // insetion of Setup Ts Buttons Table: Setup_TS_Buttons
                    Setup_TS_ButtonsClass objSetupTsButtons = new Setup_TS_ButtonsClass();
                    objSetupTsButtons.Store_ID = "1001";
                    objSetupTsButtons.Caption = txtDescription.Text;
                    objSetupTsButtons.Ident = txtPriceGroupID.Text;
                    objPosManagementService.insertSetupTsButtons(objSetupTsButtons);

                    //
                    btnExit.Content = "Exit";                 
                    txtPriceGroupID.IsEnabled = false;
                    cmbSearchPriceGroup.Visibility = Visibility.Visible;
                    lblSearchPriceGroup.Visibility = Visibility.Visible;
                    txtPriceGroupID.Background = Brushes.White;
                    this.btnAdd.IsEnabled = true;
                    FillSearchCombo();
                    RetriveingRecords();
                }


            }
            catch(Exception ex)
            {
                CustomLogging.Log("[Error:]", ex.Message);
            }
        }

        private void btnAddItems_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SearchInventoryForm objSearchInventory = new SearchInventoryForm();
                InventoryClass objInventory = new InventoryClass();
                objSearchInventory.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                objSearchInventory.ShowDialog();
                if(objSearchInventory.set_item_id != null)
                {
                    for (int j = 0; j < dgItems.Items.Count; j++)
                    {
                        DataGridRow rowss = (DataGridRow)dgItems.ItemContainerGenerator.ContainerFromIndex(j);
                        string id = (dgDiscountLevel.Columns[0].GetCellContent(rowss) as TextBlock).Text;
                        if(objSearchInventory.set_item_id == id)
                        {
                            MessageBox.Show("This Item is already included in this Price Group","Run Time Support",MessageBoxButton.OK,MessageBoxImage.Stop);
                            return;
                        }
                    }
                    objInventory.ItemNum = objSearchInventory.set_item_id;
                    DataTable dt = objPosManagementService.getInventoryId(objInventory);
                    var data = new item { ItemNum = dt.Rows[0]["ItemNum"].ToString(), ItemName = dt.Rows[0]["ItemName"].ToString(), Price = Math.Round(Convert.ToDouble(dt.Rows[0]["Price"]), 2).ToString() };
                    dgItems.Items.Add(data);          
                }
                
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[Error:]", ex.Message);
            }
        }
        public class item
        {
            public string ItemNum { get; set; }
            public string ItemName { get; set; }
            public string Price { get; set; }
        }

        private void btnAddDiscountLevel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NumberKeypaid objkepaid = new NumberKeypaid(101);
                objkepaid.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                objkepaid.ShowDialog();
                if(objkepaid.set_quantity != null)
                {
                    NumberKeypaid objkpaid = new NumberKeypaid(102);
                    objkpaid.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                    objkpaid.ShowDialog();
                    if(objkpaid.set_price != null)
                    {
                        var data = new level { Quantity = objkepaid.set_quantity, amount = objkpaid.set_price};
                        dgDiscountLevel.Items.Add(data); 
                    }
                }
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[Error:]", ex.Message);
            }
        }
        public class level
        {
            public string Quantity { get; set; }
            public string amount { get; set; }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnExit.Content = "Cancel";
                cmbPriceGroup.SelectedIndex = 0;
                txtPriceGroupID.IsEnabled = true;
                txtPriceGroupID.Clear();
                txtDescription.Clear();
                cmbSearchPriceGroup.Visibility = Visibility.Hidden;
                lblSearchPriceGroup.Visibility = Visibility.Hidden;
                txtPriceGroupID.Background = Brushes.Yellow;
                cmbDepartment.SelectedIndex = 0;
                txtStartDate.SelectedDate = DateTime.Today;
                txtEndDate.SelectedDate = DateTime.Today;
                this.btnAdd.IsEnabled = false;
                dgItems.Items.Clear();
                dgDiscountLevel.Items.Clear();
                txtAmount.Text = "0";
                txtQuantity.Text = "0";
            }
            catch (Exception ex)
            {
                
               CustomLogging.Log("[Error:]", ex.Message);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnExit.Content.Equals("Exit"))
                {
                    this.Close();
                }
                else
                {
                    btnExit.Content = "Exit";
                    // cmbPriceGroup.SelectedIndex = 0;
                    txtPriceGroupID.IsEnabled = false;
                    //txtPriceGroupID.Clear();
                    //txtDescription.Clear();
                    cmbSearchPriceGroup.Visibility = Visibility.Visible;
                    lblSearchPriceGroup.Visibility = Visibility.Visible;
                    txtPriceGroupID.Background = Brushes.White;
                    this.btnAdd.IsEnabled = true;
                    FillSearchCombo();
                    RetriveingRecords();
                }
            }
            catch (Exception ex)
            {
                
               CustomLogging.Log("[Error:]", ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InventoryClass objInvenoryClass = new InventoryClass();
                var result = MessageBox.Show("Are you sure would like to permanently delete this price group?", "Run Time Support", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if(result == MessageBoxResult.Yes)
                {
                    objInvenoryClass.IsDeleted = 1;
                    objInvenoryClass.Store_ID = "1001";
                    objInvenoryClass.ItemNum = txtPriceGroupID.Text;
                    objPosManagementService.deleteItem(objInvenoryClass);
                    if(objInvenoryClass.IsSuccessfull == true)
                    {
                        FillSearchCombo();
                        RetriveingRecords();
                    }
                }

            }
            catch (Exception ex)
            {
            CustomLogging.Log("[Error:]", ex.Message);    
            }           
        }

        private void btnDeleteDiscount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgDiscountLevel.SelectedIndex >= 0)
                {
                    for (int i = 0; i < dgDiscountLevel.SelectedItems.Count; i++)
                    {
                        dgDiscountLevel.Items.Remove(dgDiscountLevel.SelectedItems[i]);
                    };
                }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Error:]", ex.Message);
            }
        }
        public void FillSearchCombo()
        {
            try
            {
                DataTable dt = objPosManagementService.getMixnMatch(5);
                if(dt.Rows.Count > 0)
                {
                    cmbSearchPriceGroup.ItemsSource = dt.DefaultView;
                    cmbSearchPriceGroup.SelectedValuePath = "ItemNum";
                    cmbSearchPriceGroup.DisplayMemberPath = "ItemName";
                }
                cmbSearchPriceGroup.SelectedIndex = 0;
            }
            catch (Exception)
            {
 
            }
        }

        private void txtQuantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
          
            objRegix.checkForNumericWithDotDash(e);
        }

        private void txtAmount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            objRegix.checkForNumericWithDotDash(e);
        }
        public void RetriveingRecords()
        {
            try
            {
                dgDiscountLevel.Items.Clear();
                dgItems.Items.Clear();
                string[] str = cmbSearchPriceGroup.Text.ToString().Split('-');
                string ItemNum = str[0];

                DataTable dt = objPosManagementService.RetriveData(ItemNum);
                if (dt.Rows.Count > 0)
                {
                    cmbDepartment.SelectedValue = dt.Rows[0]["Dept_ID"].ToString();
                    txtPriceGroupID.Text = dt.Rows[0]["ItemNum"].ToString();
                    txtQuantity.Text = dt.Rows[0]["QuantityRequired"].ToString();
                    txtStartDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["Sale_Start"]);
                    txtEndDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["Sale_End"]);
                    txtDescription.Text = dt.Rows[0]["ItemName"].ToString();
                    txtAmount.Text = dt.Rows[0]["Price"].ToString();
                    chkTax1.IsChecked = Convert.ToBoolean(dt.Rows[0]["Tax_1"]);
                    chkbTax2.IsChecked = Convert.ToBoolean(dt.Rows[0]["Tax_2"]);
                    chkbTax3.IsChecked = Convert.ToBoolean(dt.Rows[0]["Tax_3"]);
                    chkbFoodstampable.IsChecked = Convert.ToBoolean(dt.Rows[0]["FoodStampable"]);
                    if (dt.Rows[0]["ItemType"].ToString() == "1")
                    {
                        cmbPriceGroup.SelectedIndex = 0;
                    }
                    else if (dt.Rows[0]["ItemType"].ToString() == "5")
                    {
                        cmbPriceGroup.SelectedIndex = 1;
                    }
                    else if (dt.Rows[0]["ItemType"].ToString() == "6")
                    {
                        cmbPriceGroup.SelectedIndex = 2;
                    }
                    DataTable dtSubItems = objPosManagementService.retriveSubItems(ItemNum, "1001");
                    for (int i = 0; i < dtSubItems.Rows.Count; i++)
                    {
                        var data = new item { ItemNum = dtSubItems.Rows[i]["ItemNum"].ToString(), ItemName = dtSubItems.Rows[i]["ItemName"].ToString(), Price = Math.Round(Convert.ToDouble(dtSubItems.Rows[i]["Price"]), 2).ToString() };
                        dgItems.Items.Add(data);
                    }
                    DataTable dtDiscountLevel = objPosManagementService.retriveDiscountLevel(ItemNum, "1001");
                    for (int j = 0; j < dtDiscountLevel.Rows.Count; j++)
                    {
                        var data = new level { Quantity = dtDiscountLevel.Rows[j]["Quantity"].ToString(), amount = dtDiscountLevel.Rows[j]["Amount"].ToString() };
                        dgDiscountLevel.Items.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void cmbSearchPriceGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //e.Handled = true;
            //RetriveingRecords();
        }

        private void cmbSearchPriceGroup_DropDownClosed(object sender, EventArgs e)
        {
            RetriveingRecords();
        }

        private void btnDeleteItems_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgItems.SelectedIndex >= 0)
                {
                    for (int i = 0; i < dgItems.SelectedItems.Count; i++)
                    {
                        dgItems.Items.Remove(dgItems.SelectedItems[i]);
                    };
                }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Error:]", ex.Message);
            }
        }
    }
}
