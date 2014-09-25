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
    /// Interaction logic for CorporateSetupForm.xaml
    /// </summary>
    public partial class CorporateSetupForm : Window
    {
        //GlobalClass glo = new GlobalClass();
        public CorporateSetupForm()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            fun_fill_lsb_stores();
        }
        private void fun_fill_lsb_stores()
        {
            //string qury = "select Store_ID from Setup";
            //glo.fun_search(qury);
            //while (glo.dr.Read())
            //{
            //    lsb_storeids.Items.Add(glo.dr["Store_ID"].ToString());
            //}
            //glo.dr.Close();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            ////InforPromptForm prompt = new InforPromptForm("Enter The ID of the New Store You Like to Add");
            ////prompt.ShowDialog();
            ////if (prompt.set_store_id != null)
            ////{
            ////    string qrry = "insert into Setup(Store_ID) values('"+ prompt.set_store_id +"')";
            ////    glo.fun_insert(qrry);
            ////    //string qry_defalut_station = "insert into Station(";
            ////    lsb_storeids.Items.Clear();
            ////    fun_fill_lsb_stores();
            ////    prompt.set_store_id = null;
            //}
        }

        private void btn_change_email_Click(object sender, RoutedEventArgs e)
        {
            if (lsb_storeids.SelectedItems.Equals(0))
            {
                MessageBox.Show("Please Select a Store ID", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //InforPromptForm pro = new InforPromptForm("Please Enter This Store New Email's Address");
            //pro.ShowDialog();
            
            //if (pro.set_email != null)
            //{
            //    string update_email = "update Setup set Store_Email = '" + pro.set_email + "' where Store_ID = '"+ lsb_storeids.SelectedItem.ToString() +"'";
            //    glo.fun_insert(update_email);
            //}
            //pro.set_email = null;
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string delete = "delete from ";
                lsb_storeids.Items.RemoveAt(lsb_storeids.SelectedIndex);
            }
            catch (Exception)
            { }
        }

        private void btn_zero_inventory_Click(object sender, RoutedEventArgs e)
        {
            if (lsb_storeids.SelectedItems.Equals(0))
            {
                MessageBox.Show("Please Select a Store ID", "Warning",MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show("Are You Sure You would Like to Zero out the in Stock Value for This Store","Infor Prompt", MessageBoxButton.YesNo,MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                //string qryy = "update Inventory set In_Stock = 0 where Store_ID ='" + lsb_storeids.SelectedItem + "'";
                //glo.fun_insert(qryy);
                MessageBox.Show("Your Inventory For this Store has been Zeroed","Run time Support", MessageBoxButton.OK,MessageBoxImage.Information);
            }
        }

        private void btn_dup_inventory_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
