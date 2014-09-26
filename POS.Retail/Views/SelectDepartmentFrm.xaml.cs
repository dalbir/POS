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


namespace POS.Retail.Views
{
    /// <summary>
    /// Interaction logic for SelectDepartmentFrm.xaml
    /// </summary>
    public partial class SelectDepartmentFrm : Window
    {
        DepartmentClass objDptClass = new DepartmentClass();
        private static string DeptID1=null;
        private static string DepDescription=null;
        public SelectDepartmentFrm()
        {
            InitializeComponent();
        }
        private void FillDptGrid()
        {
            objDptClass.flage = "loadDpt";
            POSManagementService objMgtServices = new POSManagementService();
            objMgtServices.LoadCatIdToDpt(objDptClass);
            DgDepartments.ItemsSource = objDptClass.LoadDept.DefaultView;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillDptGrid();
            
        }
        public string SetDptId
        {
            get { return DeptID1; }
            set { DeptID1 = value; }
        }
        public string SetDptDescription
        {
            get { return DepDescription; }
            set { DepDescription = value; }
        }
        private void btnSelectDpt_Click(object sender, RoutedEventArgs e)
        {

            DataGridRow rowss = (DataGridRow)DgDepartments.ItemContainerGenerator.ContainerFromIndex(DgDepartments.SelectedIndex);
            string a = (DgDepartments.Columns[0].GetCellContent(rowss) as TextBlock).Text;
            DataGridRow rowss2 = (DataGridRow)DgDepartments.ItemContainerGenerator.ContainerFromIndex(DgDepartments.SelectedIndex);
            string b = (DgDepartments.Columns[1].GetCellContent(rowss) as TextBlock).Text;
            DeptID1 = a;
            DepDescription = b;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
       
    }
}
