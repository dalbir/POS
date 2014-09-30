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
    /// Interaction logic for StoreStationForm.xaml
    /// </summary>
    public partial class StoreStationForm : Window
    {
        //GlobalClass glo = new GlobalClass();
        
        string str;
        private int p;
        public StoreStationForm() //StoreStation()
        {
            InitializeComponent();
        }

        public StoreStationForm(int p)
        {
            InitializeComponent();
            this.p = p;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fun_fill_lsb_stores();
           
            lbl_store_id.Content = str;
            lbl_station_id.Content = lsb_stations.SelectedItem;
            if (p == 0)
            {
                lstb_stores.IsEnabled = false;
                btn_add_station.IsEnabled = true;
                groupBox1.Header = "Select or Create a Station";
            }
            else if (p == 1)
            {
                lstb_stores.IsEnabled = true;
                lsb_stations.IsEnabled = false;
                btn_add_station.IsEnabled = false;
                groupBox1.Header = "Select This Station's Store ID";
            }
        }
        private void fun_fill_lsb_stores()
        {
            //string qury = "select Store_ID + ' ' + Company_Info_1 as store from Setup";
            //glo.fun_search(qury);
            //while (glo.dr.Read())
            //{
            //    lstb_stores.Items.Add(glo.dr["store"].ToString());
            //}
            //glo.dr.Close();
            //lstb_stores.SelectedIndex = 0;
            //lsb_stations.Items.Clear();
            //string[] strsplit = lstb_stores.SelectedItem.ToString().Split(' ');
            //str = strsplit[0];
            //string qry = "select Station_ID from Stations where Store_ID = '"+ str +"'";
            //glo.fun_search(qry);
            //while (glo.dr.Read())
            //{
            //    lsb_stations.Items.Add(glo.dr["Station_ID"].ToString());
            //}
            //glo.dr.Close();
            //lsb_stations.SelectedIndex = 0;
        }

        private void lsb_stations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                lbl_station_id.Content = lsb_stations.SelectedItem.ToString();
            }
            catch (Exception)
            { }
        }

        private void btn_add_station_Click(object sender, RoutedEventArgs e)
        {
            Keyboard kb = new Keyboard("Ener a New Station ID (Example: 01, 02, 99, etc)");
            kb.ShowDialog();
            if (kb.set_decrep != null)
            {
                //string qurry = "insert into Stations(Station_ID,Store_ID) values('" + kb.set_decrep.ToString() + "', '" + str + "')";
                //glo.fun_insert(qurry);
                lstb_stores.Items.Clear();
                lsb_stations.Items.Clear();
                fun_fill_lsb_stores();
            }
        }

        private void btn_store_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lstb_stores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string[] strsplit = lstb_stores.SelectedItem.ToString().Split(' ');
                str = strsplit[0];
                lbl_store_id.Content = str;
                lsb_stations.Items.Clear();
                string qry = "select Station_ID from Stations where Store_ID = '" + str + "'";
                //glo.fun_search(qry);
                //while (glo.dr.Read())
                //{
                //    lsb_stations.Items.Add(glo.dr["Station_ID"].ToString());
                //}
                //glo.dr.Close();
            }
            catch (Exception)
            {
 
            }
        }
    }
}
