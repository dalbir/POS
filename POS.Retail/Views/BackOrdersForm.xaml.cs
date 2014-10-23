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
using POS.Domain.Common;
using POS.Services.Common;
using System.Data;
using POS.Retail.Views;
using POS.Domain;
using POS.Services;

namespace POS.Retail
{
    /// <summary>
    /// Interaction logic for BackOrdersForm.xaml
    /// </summary>
    public partial class BackOrdersForm : Window
    {
        public BackOrdersForm()
        {
            InitializeComponent();
        }
        string strType;
        private static string Content;
        private static string lineNumber;
        BackOrdersClass objBackOrdersClass = new BackOrdersClass();
        private void FillBackOrderesGrid()
        {
            DgBackOrderes.Items.Clear();
            //objBackOrdersClass.flage = "LoadBackOrderesGrid";
            POSManagementService objPOSManagementService = new POSManagementService();
            objBackOrdersClass = objPOSManagementService.LoadBackOrderesInfo(objBackOrdersClass);
           // DgBackOrderes.ItemsSource = objBackOrdersClass.LoadOrderes.DefaultView;
            DataTable dt = objBackOrdersClass.LoadOrderes;
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                if (dt.Rows[j]["Type"].ToString() == "BP")
                {
                    strType = "Yes";
                }
                else if (dt.Rows[j]["Type"].ToString() == "BO")
                {
                    strType = "No";
                }
                var data = new item
                {
                    lineNumber = dt.Rows[j]["Line_number"].ToString(),
                    BONum = dt.Rows[j]["BONum"].ToString(),
                    Date = dt.Rows[j]["DateTime"].ToString(),
                    CustNum = dt.Rows[j]["CustNum"].ToString(),
                    ItemNum = dt.Rows[j]["ItemNum"].ToString(),
                    ItemName = dt.Rows[j]["ItemName"].ToString(),
                    Quan = Math.Round(Convert.ToDouble(dt.Rows[j]["Quan"]), 2).ToString(),
                    Instock = Math.Round(Convert.ToDouble(dt.Rows[j]["In_Stock"]), 2).ToString(),
                    Prepaid = strType,
                    Invoice_Number = dt.Rows[j]["Invoice_Number"].ToString(),
                    status = dt.Rows[j]["Status"].ToString(),
                };
                DgBackOrderes.Items.Add(data);
            }
        }
        public class item
        {
            public string lineNumber { get; set; }
            public string BONum { get; set; }
            public string Date { get; set; }
            public string CustNum { get; set; }
            public string ItemNum { get; set; }
            public string ItemName { get; set; }
            public string Quan { get; set; }
            public string Instock { get; set; }
            public string Prepaid { get; set; }
            public string Invoice_Number { get; set; }
            public string status { get; set; }
        }
        public string setContent
        {
            get { return Content; }
            set { Content = value; }
        }
        public string setLineNumber
        {
            get { return lineNumber; }
            set { lineNumber = value; }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //DgBackOrderes.Items.Clear();
               FillBackOrderesGrid();
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Error]", ex.Message);
            }
        }
        private void btnFillBO_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DgBackOrderes.SelectedValue != null)
                {
                    DataGridRow rowss = (DataGridRow)DgBackOrderes.ItemContainerGenerator.ContainerFromIndex(DgBackOrderes.SelectedIndex);
                    string a = (DgBackOrderes.Columns[0].GetCellContent(rowss) as TextBlock).Text;
                    lineNumber = a;
                    //DataGridRow rowss2 = (DataGridRow)DgBackOrderes.ItemContainerGenerator.ContainerFromIndex(DgBackOrderes.SelectedIndex);
                    //string quan = (DgBackOrderes.Columns[6].GetCellContent(rowss2) as TextBlock).Text;
                    //DataGridRow rowss3 = (DataGridRow)DgBackOrderes.ItemContainerGenerator.ContainerFromIndex(DgBackOrderes.SelectedIndex);
                    //string instock = (DgBackOrderes.Columns[7].GetCellContent(rowss3) as TextBlock).Text;
                }
                BackOrdersClass objBackOrdersClass = new BackOrdersClass();
                Content = "Enter Line number you would like to fill";
                objBackOrdersClass.flage = "FillOrders";
                SelectBackOrderForm objSelectBackOrderForm = new SelectBackOrderForm(objBackOrdersClass);
                objSelectBackOrderForm.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                objSelectBackOrderForm.ShowDialog();     
                if (objBackOrdersClass.flage == "FillOrders")
                {
                    int getLineNo = Convert.ToInt32(objSelectBackOrderForm.setLineNo);
                    DataGridRow row = (DataGridRow)DgBackOrderes.ItemContainerGenerator.ContainerFromIndex(getLineNo-1);
                    string abc = ((POS.Retail.BackOrdersForm.item)(row.Item)).BONum;
                    DataGridRow row2 = (DataGridRow)DgBackOrderes.ItemContainerGenerator.ContainerFromIndex(getLineNo - 1);
                    string quantity = ((POS.Retail.BackOrdersForm.item)(row.Item)).Quan;
                    DataGridRow row3 = (DataGridRow)DgBackOrderes.ItemContainerGenerator.ContainerFromIndex(getLineNo - 1);
                    string stock = ((POS.Retail.BackOrdersForm.item)(row.Item)).Instock;
                    DataGridRow row4 = (DataGridRow)DgBackOrderes.ItemContainerGenerator.ContainerFromIndex(getLineNo - 1);
                    string itemNo = ((POS.Retail.BackOrdersForm.item)(row.Item)).ItemNum;
                    DataGridRow row5 = (DataGridRow)DgBackOrderes.ItemContainerGenerator.ContainerFromIndex(getLineNo - 1);
                    string instockquan = ((POS.Retail.BackOrdersForm.item)(row.Item)).Instock;

                    if (getLineNo.ToString() != null)
                    {
                        var result = MessageBox.Show("Are You Sure You would like to fill this Backorders?","Run Time Support", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (result == MessageBoxResult.Yes)
                        {
                            if (Convert.ToDecimal(quantity) > Convert.ToDecimal(stock))
                            {
                                MessageBox.Show("This backorder can not be filled by the quantity in stock", "Run Time Support", MessageBoxButton.OK, MessageBoxImage.Information);
                                return;
                            }
                            objBackOrdersClass.flage = "updateStatus";
                            objBackOrdersClass.BONum = Convert.ToInt32(abc);
                            objBackOrdersClass.Status = "F";
                            objBackOrdersClass.FillDate = Convert.ToDateTime(DateTime.Now.ToString());
                            POSManagementService objPOSManagementService = new POSManagementService();
                            objPOSManagementService.GetBackOrders(objBackOrdersClass);
                           // objBackOrdersClass.flage = "getStock";
                            //objBackOrdersClass.ItemNum = itemNo;
                            //string getinstockquantity = objPOSManagementService.GetStatusAndType(objBackOrdersClass);
                            double newquantity = Convert.ToDouble(instockquan) - Convert.ToDouble(quantity);
                            objBackOrdersClass.Quan =Convert.ToDouble(newquantity);
                            objBackOrdersClass.ItemNum = itemNo;
                            objBackOrdersClass.flage = "UpdateInstock";
                            objPOSManagementService.GetBackOrders(objBackOrdersClass);
                        }
                        else if (result == MessageBoxResult.No)
                        {
                            return;
                        }
                    }
                    else if (getLineNo.ToString() == null)
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Error]", ex.Message);
            }
        }
        private void btnDltBO_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DgBackOrderes.SelectedValue != null)
                {
                    DataGridRow rowss = (DataGridRow)DgBackOrderes.ItemContainerGenerator.ContainerFromIndex(DgBackOrderes.SelectedIndex);
                    string a = (DgBackOrderes.Columns[0].GetCellContent(rowss) as TextBlock).Text;
                    lineNumber = a;
                }
                   Content = "Enter Line number you would like to delete";
                   
                   SelectBackOrderForm objSelectBackOrderForm = new SelectBackOrderForm();
                   objSelectBackOrderForm.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                   objSelectBackOrderForm.ShowDialog();
                   int getLineNo = Convert.ToInt32(objSelectBackOrderForm.setLineNo);
                   DataGridRow row = (DataGridRow)DgBackOrderes.ItemContainerGenerator.ContainerFromIndex(getLineNo - 1);
                   string abc = ((POS.Retail.BackOrdersForm.item)(row.Item)).BONum;
                   if (getLineNo.ToString() != null)
                   {
                       var result = MessageBox.Show("Are You Sure You would like to delete this Backorders?", "Run Time Support", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                       if (result == MessageBoxResult.Yes)
                       {
                           objBackOrdersClass.BONum = Convert.ToInt32(abc);
                           
                           POSManagementService objPOSManagementService = new POSManagementService();
                           objBackOrdersClass.flage = "gettype";
                           string vtype = objPOSManagementService.GetStatusAndType(objBackOrdersClass);
                           objBackOrdersClass.flage = "getstatus";
                           string strStatus = objPOSManagementService.GetStatusAndType(objBackOrdersClass);
                           if (vtype == "BP" && strStatus == "O")
                           {
                               MessageBox.Show("You can not delete a backorder that has been prepaid", "Run Time Support", MessageBoxButton.OK, MessageBoxImage.Information);
                               return;
                           }
                           else
                           {
                               objBackOrdersClass.flage = "DeleteOrders";
                               objPOSManagementService.DeleteBackOrders(objBackOrdersClass);
                           }
                       }
                       else if (result == MessageBoxResult.No)
                       {
                           return;
                       }
                   }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Error]", ex.Message);
            }
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void RbCovrdByStock_Checked(object sender, RoutedEventArgs e)
        {
           if (RbCovrdByStock.IsChecked == true)
            {
                objBackOrdersClass.flage = "LoadFBOrders";
                objBackOrdersClass.Status = "F";
            }
            DgBackOrderes.Items.Clear();
            FillBackOrderesGrid();
        }
        private void RbNotCoveredByStock_Checked(object sender, RoutedEventArgs e)
        {
           if (RbNotCoveredByStock.IsChecked == true)
            {
                objBackOrdersClass.flage = "LoadFBOrders";
                objBackOrdersClass.Status = "O";
            }
            DgBackOrderes.Items.Clear();
            FillBackOrderesGrid();
        }
        private void txtItemNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            objBackOrdersClass.flage = "SearchBObyItem";
            objBackOrdersClass.ItemNum = txtItemNo.Text.Trim();
            DgBackOrderes.Items.Clear();
            FillBackOrderesGrid();
        }
        private void txtCustNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            objBackOrdersClass.flage = "SearchBObyCustomer";
            objBackOrdersClass.CustNum = txtCustNo.Text.Trim();
            DgBackOrderes.Items.Clear();
            FillBackOrderesGrid();
        }
        private void RbAllOpen_Click(object sender, RoutedEventArgs e)
        {
        }
        private void RbAllOpen_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (RbAllOpen.IsChecked == true)
                {
                    objBackOrdersClass.flage = "LoadBackOrderesGrid";
                    objBackOrdersClass.Status = "O";
                    //DgBackOrderes.Items.Clear();
                    //Window_Loaded(sender, e);
                    FillBackOrderesGrid();
                }
            }
            catch (Exception ex)
            {
 
            }
        }

    }
}