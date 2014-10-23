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
using System.Text.RegularExpressions;

namespace POS.Retail.Views
{
    /// <summary>
    /// Interaction logic for PayrollexportSettingForm.xaml
    /// </summary>
    public partial class PayrollexportSettingForm : Window
    {
        POSManagementService objPOSManagementService = new POSManagementService();
        public PayrollexportSettingForm()
        {
            InitializeComponent();
        }

        private void bntExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSaveExit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtExportEmail.Text == "" || !Regex.IsMatch(txtExportEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    MessageBox.Show("Please Enter a valid Email ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtExportEmail.Focus();
                    return;
                }
                User_DefinedClass objUserDefinedClass = new User_DefinedClass();
                // insertion of email.
                objUserDefinedClass.Store_ID = "1001";
                objUserDefinedClass.UD_ID = "PEXPRT";
                objUserDefinedClass.Type = txtExportEmail.Text;
                objUserDefinedClass.Description = "EMailID";
                objPOSManagementService.insertEmialinUserDefined(objUserDefinedClass);
                // insertion of export key...              
                objUserDefinedClass.Type = txtExportKey.Text;
                objUserDefinedClass.Description = "ExportKey";
                objPOSManagementService.insertEmialinUserDefined(objUserDefinedClass);
                if(objUserDefinedClass.IsSuccessfull == true)
                {
                    this.Close();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
