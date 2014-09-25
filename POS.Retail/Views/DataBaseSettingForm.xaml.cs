using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
    /// Interaction logic for DataBaseSettingForm.xaml
    /// </summary>
    public partial class DataBaseSettingForm : Window
    {
        SqlConnection con;

        public DataBaseSettingForm()
        {
            InitializeComponent();
        }
        string st;

        public void connection()
        {
            try
            {
                st = "Data Source= " + txt_server_name.Text + ";Initial Catalog= " + txt_db.Text + ";User ID=" + txt_user.Text + ";Password=" + txt_paswd.Text + "";
                con = new SqlConnection(st);
            }
            catch (Exception)
            { }
        }
        private void btn_test_login_Click(object sender, RoutedEventArgs e)
        {
            connection();
            
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * from Departments", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Connected Successfull", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Connection Fail", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void btn_done_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Remove("DatabasePath");
                config.AppSettings.Settings.Add("DatabasePath", st);
                config.Save(ConfigurationSaveMode.Modified);
                MessageBox.Show("Connection String Stored Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
                //MainWindow obj = new MainWindow();
                //obj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
