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
using POS.Services.Common;
using POS.Domain.Common;
using POS.Retail.Common;
using System.Data;
using POS.Domain.Common.Employee;

namespace POS.Retail.Views
{
    /// <summary>
    /// Interaction logic for TimeClockManagement.xaml
    /// </summary>
    public partial class TimeClockManagement : Window
    {
        POSManagementService objPOSManagementService = new POSManagementService();
        public TimeClockManagement()
        {
            InitializeComponent();
        }
        public void fillCashairCmb()
        {
            EmployeesDataClass objEmployeesDataClass = new EmployeesDataClass();
            DataTable dt = objPOSManagementService.getEmplyeeIds(objEmployeesDataClass);
            if(dt.Rows.Count > 0)
            {
                cmbCashier.Items.Add("All");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmbCashier.Items.Add(dt.Rows[i]["EmpName"].ToString());
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                fillCashairCmb();
                cmbCashier.SelectedIndex = 0;
                txtStartDate.SelectedDate = DateTime.Today.AddDays(-10);
                txtEndDate.SelectedDate = DateTime.Today;
                dgEmpTimeClock();
            }
            catch (Exception)
            {

            }
        }

        private void bntExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void dgEmpTimeClock()
        {
            try
            {
                Time_ClockClass objTimeClockClass = new Time_ClockClass();
                objTimeClockClass.StartDateTime = Convert.ToDateTime(txtStartDate.SelectedDate);
                objTimeClockClass.EndDateTime = Convert.ToDateTime(txtEndDate.SelectedDate);
                if(cmbCashier.Text == "All")
                {
                    objTimeClockClass.Cashier_ID = "%";
                }
                else
                {
                    string[] str = cmbCashier.Text.ToString().Split('-');
                    objTimeClockClass.Cashier_ID = str[0];
                }
                DataTable dt = objPOSManagementService.filldagaGrid(objTimeClockClass);
                dgEmployeeTimeClock.ItemsSource = dt.DefaultView;
               
            }
            catch (Exception)
            {
 
            }
        }

        private void cmbCashier_DropDownClosed(object sender, EventArgs e)
        {
            dgEmpTimeClock();
        }

        private void txtStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dgEmpTimeClock();
        }

        private void txtEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dgEmpTimeClock();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            dgEmpTimeClock();
        }

        private void btnDeleteEntry_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(dgEmployeeTimeClock.SelectedItems.Count > 0)
                {
                    var result = MessageBox.Show("Are you Sure you Want to Delete this Item?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        Time_ClockClass objTimeClockClass = new Time_ClockClass();
                        TextBlock b = (dgEmployeeTimeClock.Columns[0].GetCellContent(dgEmployeeTimeClock.SelectedItem) as TextBlock);
                        objTimeClockClass.ID = Convert.ToInt32(b.Text);
                        TextBlock c = (dgEmployeeTimeClock.Columns[1].GetCellContent(dgEmployeeTimeClock.SelectedItem) as TextBlock);
                        objTimeClockClass.Cashier_ID = c.Text;
                        objPOSManagementService.deleteItemRecord(objTimeClockClass);
                        if(objTimeClockClass.IsSuccessfull == true)
                        {
                            dgEmpTimeClock();
                            MessageBox.Show("Item Deleted Successfully.", "Infromation", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Please Select a Row to Delete","Run Time Support",MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {

            }
        }

        private void bntDeleteClockReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgEmployeeTimeClock.SelectedItems.Count > 0)
                {
                    var result = MessageBox.Show("Are you Sure you Want to delete the OutTime for this entry.", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        Time_ClockClass objTimeClockClass = new Time_ClockClass();
                        TextBlock b = (dgEmployeeTimeClock.Columns[0].GetCellContent(dgEmployeeTimeClock.SelectedItem) as TextBlock);
                        objTimeClockClass.ID = Convert.ToInt32(b.Text);
                        TextBlock c = (dgEmployeeTimeClock.Columns[1].GetCellContent(dgEmployeeTimeClock.SelectedItem) as TextBlock);
                        objTimeClockClass.Cashier_ID = c.Text;
                        objPOSManagementService.deleteTimeOut(objTimeClockClass);
                        if (objTimeClockClass.IsSuccessfull == true)
                        {
                            MessageBox.Show("Clock out for this Entry Deleted Successfully.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            dgEmpTimeClock();
                        }
                    }
                }

            }
            catch (Exception)
            {

            }
        }

        private void bntChangeJobCode_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EmployeeJobCodeClass objEmployeeJobCodeClass = new EmployeeJobCodeClass();
                Time_ClockClass objTimeClockClass = new Time_ClockClass();
                TextBlock b = (dgEmployeeTimeClock.Columns[0].GetCellContent(dgEmployeeTimeClock.SelectedItem) as TextBlock);     
                TextBlock c = (dgEmployeeTimeClock.Columns[1].GetCellContent(dgEmployeeTimeClock.SelectedItem) as TextBlock);
                objEmployeeJobCodeClass.Cashier_ID = c.Text;
                DataTable dt = objPOSManagementService.getEmpjobCodes(objEmployeeJobCodeClass);
                if(dt.Rows.Count > 0)
                {
                    TextBlock d = (dgEmployeeTimeClock.Columns[6].GetCellContent(dgEmployeeTimeClock.SelectedItem) as TextBlock);
                    if(d.Text != "" && dt.Rows.Count == 1)
                    {
                        MessageBox.Show("This Employee only has one possible job code to assign. Add more job codes to this Employee using Employee Maintenance.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    SelectVendorForm objSelectJobCodes = new SelectVendorForm(dt, 2);
                    objSelectJobCodes.ShowDialog();
                    if(objSelectJobCodes.set_jobCodeId != null)
                    {
                        objTimeClockClass.Cashier_ID = c.Text;
                        objTimeClockClass.ID = Convert.ToInt32(b.Text);
                        objTimeClockClass.JobCodeID = objSelectJobCodes.set_jobCodeId;
                        objPOSManagementService.updateEmployeJobCode(objTimeClockClass);
                        dgEmpTimeClock();
                    }
                }
                else
                {
                    MessageBox.Show("This employee does not have any job code assigned. Add more job codes to this employee using employee mantenance.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
            }
            catch (Exception)
            {

            }
        }

    }
}
