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
using System.Globalization;

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
                btnBack.Visibility = Visibility.Hidden;
                btnDeleteEntry.IsEnabled = true;
                btnModifyCloseout.IsEnabled = true;
                btnReprint.IsEnabled = true;
                bntDeleteClockReport.IsEnabled = true;
                bntChangeJobCode.IsEnabled = true;
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
                dgEmployeeTimeClock.Visibility = Visibility.Visible;
                dgEmployeeTimeBreakClock.Visibility = Visibility.Hidden;
                this.btnBack.Visibility = Visibility.Hidden;
                btnDeleteEntry.IsEnabled = true;
                btnModifyCloseout.IsEnabled = true;
                btnReprint.IsEnabled = true;
                bntDeleteClockReport.IsEnabled = true;
                bntChangeJobCode.IsEnabled = true;
                //
                Time_ClockClass objTimeClockClass = new Time_ClockClass();
                objTimeClockClass.StartDateTime = Convert.ToDateTime(txtStartDate.SelectedDate);
                objTimeClockClass.EndDateTime = Convert.ToDateTime(txtEndDate.SelectedDate);
                objTimeClockClass.Store_ID = "1001";
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
            dgEmployeeTimeClock.Visibility = Visibility.Visible;
            dgEmployeeTimeBreakClock.Visibility = Visibility.Hidden;
            this.btnBack.Visibility = Visibility.Hidden;

            btnDeleteEntry.IsEnabled = true;
            btnModifyCloseout.IsEnabled = true;
            btnReprint.IsEnabled = true;
            bntDeleteClockReport.IsEnabled = true;
            bntChangeJobCode.IsEnabled = true;
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
                        TextBlock b = (dgEmployeeTimeClock.Columns[1].GetCellContent(dgEmployeeTimeClock.SelectedItem) as TextBlock);
                        objTimeClockClass.ID = Convert.ToInt32(b.Text);
                        TextBlock c = (dgEmployeeTimeClock.Columns[2].GetCellContent(dgEmployeeTimeClock.SelectedItem) as TextBlock);
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
                        TextBlock b = (dgEmployeeTimeClock.Columns[1].GetCellContent(dgEmployeeTimeClock.SelectedItem) as TextBlock);
                        objTimeClockClass.ID = Convert.ToInt32(b.Text);
                        TextBlock c = (dgEmployeeTimeClock.Columns[2].GetCellContent(dgEmployeeTimeClock.SelectedItem) as TextBlock);
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
                TextBlock b = (dgEmployeeTimeClock.Columns[1].GetCellContent(dgEmployeeTimeClock.SelectedItem) as TextBlock);     
                TextBlock c = (dgEmployeeTimeClock.Columns[2].GetCellContent(dgEmployeeTimeClock.SelectedItem) as TextBlock);
                objEmployeeJobCodeClass.Cashier_ID = c.Text;
                DataTable dt = objPOSManagementService.getEmpjobCodes(objEmployeeJobCodeClass);
                if(dt.Rows.Count > 0)
                {
                    TextBlock d = (dgEmployeeTimeClock.Columns[7].GetCellContent(dgEmployeeTimeClock.SelectedItem) as TextBlock);
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
        public int TimeClockID;
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            fillBreakDg();  
        }
        private void fillBreakDg()
        {
            try
            {
                Time_Clock_BreaksClass objTimeClockBreakClass = new Time_Clock_BreaksClass();
                TextBlock b = (dgEmployeeTimeClock.Columns[1].GetCellContent(dgEmployeeTimeClock.SelectedItem) as TextBlock); 
                objTimeClockBreakClass.Store_ID = "1001";
                objTimeClockBreakClass.ID = Convert.ToInt32(b.Text);
                DataTable dt = objPOSManagementService.getClockBreak(objTimeClockBreakClass);
                if(dt.Rows.Count > 0)
                {
                    TextBlock id = (dgEmployeeTimeClock.Columns[1].GetCellContent(dgEmployeeTimeClock.SelectedItem) as TextBlock);
                    TimeClockID = Convert.ToInt32(id.Text);
                    dgEmployeeTimeClock.Visibility = Visibility.Hidden;
                    dgEmployeeTimeBreakClock.Visibility = Visibility.Visible;
                    dgEmployeeTimeBreakClock.ItemsSource = dt.DefaultView;
                    btnBack.Visibility = Visibility.Visible;
                    btnDeleteEntry.IsEnabled = false;
                    btnModifyCloseout.IsEnabled = false;
                    btnReprint.IsEnabled = false;
                    bntDeleteClockReport.IsEnabled = false;
                    bntChangeJobCode.IsEnabled = false;
                }
                else
                {
                    MessageBox.Show("There are no breaks associated with this Shift.", "Run Time Support", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dgEmployeeTimeClock.Visibility = Visibility.Visible;
            dgEmployeeTimeBreakClock.Visibility = Visibility.Hidden;
            this.btnBack.Visibility = Visibility.Hidden;
            btnDeleteEntry.IsEnabled = true;
            btnModifyCloseout.IsEnabled = true;
            btnReprint.IsEnabled = true;
            bntDeleteClockReport.IsEnabled = true;
            bntChangeJobCode.IsEnabled = true;       
        }

        private void dgEmployeeTimeClock_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
               
                Time_ClockClass objTimeClockClass = new Time_ClockClass();
                TextBlock id = (dgEmployeeTimeClock.Columns[1].GetCellContent(dgEmployeeTimeClock.SelectedItem) as TextBlock);
                TextBlock empid = (dgEmployeeTimeClock.Columns[2].GetCellContent(dgEmployeeTimeClock.SelectedItem) as TextBlock);
                objTimeClockClass.ID = Convert.ToInt32(id.Text);
                objTimeClockClass.Cashier_ID = empid.Text;
                objTimeClockClass.Store_ID = "1001";
                TextBox t = e.EditingElement as TextBox;  // Assumes columns are all TextBoxes
                DataGridColumn dgc = e.Column;
                if (IsValidDateFormat(t.Text) == true)
                {
                    DataGridColumn col1 = e.Column;
                    int col_index = col1.DisplayIndex;
                    if(col_index == 3)
                    {
                        TextBlock startDate = (dgEmployeeTimeClock.Columns[4].GetCellContent(dgEmployeeTimeClock.SelectedItem) as TextBlock);
                        string starDate = startDate.Text;
                        if (Convert.ToDateTime(t.Text) > Convert.ToDateTime(starDate))
                        {
                            MessageBox.Show("Start date time must be before end date time", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        objTimeClockClass.updateColumn = "StartDateTime";
                        objTimeClockClass.updateValeDate = Convert.ToDateTime(t.Text);
                    }
                    else if(col_index == 4)
                    {
                        TextBlock startDate = (dgEmployeeTimeClock.Columns[3].GetCellContent(dgEmployeeTimeClock.SelectedItem) as TextBlock);
                        string starDate = startDate.Text;
                        if(Convert.ToDateTime(t.Text) < Convert.ToDateTime(starDate))
                        {
                            MessageBox.Show("Start date time must be before end date time","Warning",MessageBoxButton.OK,MessageBoxImage.Warning);
                            return;
                        }
                        objTimeClockClass.updateColumn = "EndDateTime";
                        objTimeClockClass.updateValeDate = Convert.ToDateTime(t.Text);
                    }
                    objPOSManagementService.updateClockDate(objTimeClockClass);
                    if(objTimeClockClass.IsSuccessfull == true)
                    {
                        dgEmpTimeClock();
                    }
                }
                else
                {
                    dgEmpTimeClock();
                    MessageBox.Show("You have entered an invalid Date please ReEnter. Formate: MM/dd/yyyy h:m:s tt.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);  
                }
            }
            catch (Exception)
            {
                
            }
        }
        private bool IsValidDateFormat(string date)
        {
            try
            {
                String dateFormat = "MM/dd/yyyy h:m:s tt";
                DateTime.ParseExact(date, dateFormat, CultureInfo.InvariantCulture);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void dgEmployeeTimeBreakClock_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {

                Time_Clock_BreaksClass objTimeClockClass = new Time_Clock_BreaksClass();
                objTimeClockClass.ID = TimeClockID;               
                objTimeClockClass.Store_ID = "1001";
                TextBox t = e.EditingElement as TextBox;  // Assumes columns are all TextBoxes
                DataGridColumn dgc = e.Column;
                if (IsValidDateFormat(t.Text) == true)
                {
                    DataGridColumn col1 = e.Column;
                    int col_index = col1.DisplayIndex;
                    if (col_index == 0)
                    {
                        TextBlock startDate = (dgEmployeeTimeBreakClock.Columns[1].GetCellContent(dgEmployeeTimeBreakClock.SelectedItem) as TextBlock);
                        string starDate = startDate.Text;
                        if (Convert.ToDateTime(t.Text) > Convert.ToDateTime(starDate))
                        {
                            MessageBox.Show("Start date time must be before end date time", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        objTimeClockClass.updateColumn = "BreakStartDateTime";
                        objTimeClockClass.whereColumn = "BreakEndDateTime";
                        objTimeClockClass.whereColumnValue = Convert.ToDateTime(starDate);
                        objTimeClockClass.updateValeDate = Convert.ToDateTime(t.Text);
                    }
                    else if (col_index == 1)
                    {
                        TextBlock endDate = (dgEmployeeTimeBreakClock.Columns[0].GetCellContent(dgEmployeeTimeBreakClock.SelectedItem) as TextBlock);
                        string EndDat = endDate.Text;
                        if (Convert.ToDateTime(t.Text) < Convert.ToDateTime(EndDat))
                        {
                            MessageBox.Show("Start date time must be before end date time", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        objTimeClockClass.whereColumn = "BreakStartDateTime";
                        objTimeClockClass.whereColumnValue = Convert.ToDateTime(EndDat);
                        objTimeClockClass.updateColumn = "BreakEndDateTime";
                        objTimeClockClass.updateValeDate = Convert.ToDateTime(t.Text); 
                    }
                    objPOSManagementService.updateBreckClock(objTimeClockClass);
                    if (objTimeClockClass.IsSuccessfull == true)
                    {
                        fillBreakDg();
                    }
                }
                else
                {
                    fillBreakDg();
                    MessageBox.Show("You have entered an invalid Date please ReEnter. Formate: MM/dd/yyyy h:m:s tt", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            catch (Exception)
            {

            }
        }

    }
}
