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
using System.Data;

namespace POS.Retail
{
    /// <summary>
    /// Interaction logic for TaxSetupForm.xaml
    /// </summary>
    public partial class TaxSetupForm : Window
    {
        Keyboard keyb = new Keyboard();
        NumberKeypaid kpaid = new NumberKeypaid();
        public TaxSetupForm() //FrmTaxSetup()
        {
            InitializeComponent();
        }
        private void fun_load_default_rates()
        {
            try
            {
                POSManagementService managmentService = new POSManagementService();
                Tax_RateClass objTaxRate = new Tax_RateClass();
                objTaxRate.Store_ID = "1001";
                managmentService.RetriveTaxRate(objTaxRate);
                //string qury = "select Store_ID, Tax1_Rate,Tax1_Name,Tax2_Rate,Tax2_Name,Tax3_Rate,Tax3_Name,Tax2OnTax1,Tax2Threshold from Tax_Rate where Store_ID = '1001'";
                DataTable dt = objTaxRate.dtTaxRates;
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    DG_tax_rates.Rows.Add();
                    for (Int32 j = 0; j <= DG_tax_rates.Columns.Count - 1; j++)
                    {
                        double tax1 = Math.Round(Convert.ToDouble(dt.Rows[i]["Tax1_Rate"]) * 100, 1);
                        double tax2 = Math.Round(Convert.ToDouble(dt.Rows[i]["Tax2_Rate"]) * 100, 1);
                        double tax3 = Math.Round(Convert.ToDouble(dt.Rows[i]["Tax3_Rate"]) * 100, 1);
                        double taxth = Math.Round(Convert.ToDouble(dt.Rows[i]["Tax2Threshold"]) * 100, 1);
                        DG_tax_rates.Rows[i].Cells["store_id"].Value = dt.Rows[i]["Store_ID"];
                        DG_tax_rates.Rows[i].Cells["tax1rate"].Value = tax1.ToString();
                        DG_tax_rates.Rows[i].Cells["tax1"].Value = dt.Rows[i]["Tax1_Name"];
                        DG_tax_rates.Rows[i].Cells["tax2rate"].Value = tax2.ToString();
                        DG_tax_rates.Rows[i].Cells["tax2"].Value = dt.Rows[i]["Tax2_Name"];
                        DG_tax_rates.Rows[i].Cells["tax3rate"].Value = tax3.ToString();
                        DG_tax_rates.Rows[i].Cells["tax3"].Value = dt.Rows[i]["Tax3_Name"];
                        DG_tax_rates.Rows[i].Cells["tax2ontax1"].Value = dt.Rows[i]["Tax2OnTax1"];
                        DG_tax_rates.Rows[i].Cells["tax2thrhold"].Value = taxth.ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Error: ]", ex.Message);
            }
        }
        private void fun_load_area_rates()
        {
            try
            {
                Tax_Rate_AreasClass objTaxRateAreas = new Tax_Rate_AreasClass();
                POSManagementService objmanagmentService = new POSManagementService();

                //string aquary = "SELECT Tax_Rate_ID, Area, [Description],Percent1*100  as per  FROM Tax_Rate_Areas";
                DataTable adt = objmanagmentService.GetTaxRateAreas(objTaxRateAreas);
                DG_area_rates.ItemsSource = adt.DefaultView;
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[Error: ]", ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fun_load_default_rates();
            fun_load_area_rates();
        }

        private void btn_cancel_rates_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_update_rates_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double tax1 = Convert.ToDouble(DG_tax_rates.Rows[0].Cells[1].Value) / 100;
                double tax2 = Convert.ToDouble(DG_tax_rates.Rows[0].Cells[3].Value) / 100;
                double tax3 = Convert.ToDouble(DG_tax_rates.Rows[0].Cells[5].Value) / 100;
                double taxth = Convert.ToDouble(DG_tax_rates.Rows[0].Cells[8].Value) / 100;
                POSManagementService objManagmentService = new POSManagementService();
                Tax_RateClass objTaxRates = new Tax_RateClass();
                objTaxRates.Tax1_Rate = tax1;
                objTaxRates.Tax1_Name = DG_tax_rates.Rows[0].Cells[2].Value.ToString();
                objTaxRates.Tax2_Rate = tax2;
                objTaxRates.Tax2_Name = DG_tax_rates.Rows[0].Cells[4].Value.ToString();
                objTaxRates.Tax3_Rate = tax3;
                objTaxRates.Tax3_Name = DG_tax_rates.Rows[0].Cells[6].Value.ToString();
                objTaxRates.Tax2OnTax1 = Convert.ToByte(DG_tax_rates.Rows[0].Cells[7].Value);
                objTaxRates.Tax2Threshold = taxth;
                objTaxRates.Store_ID = DG_tax_rates.Rows[0].Cells[0].Value.ToString();
                objManagmentService.updateTaxRates(objTaxRates);
           
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Error: ]", ex.Message);
            }
        }

        private void btn_add_tax_area_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string lbl = "Enter Contry Name";
                int lbl_keypad = 1;
                Keyboard kb = new Keyboard(lbl);
                kb.ShowDialog();
                if (keyb.set_county != null)
                {
                    Keyboard kb1 = new Keyboard("Enter Description of Tax Rate");
                    kb1.ShowDialog();
                    if (keyb.set_decrep != null)
                    {
                        NumberKeypaid kp = new NumberKeypaid(lbl_keypad);
                        kp.ShowDialog();
                        if (kpaid.set_percentage != null)
                        {
                            POSManagementService objMangamentService = new POSManagementService();
                            //string qury = "select isnull(max(Tax_Rate_ID), 0) + 1 as tax_id from Tax_Rate_Areas";
                            string maxmID = objMangamentService.GetMaxTaxId();
                            // glo.maxm_id(qury);
                            Tax_Rate_AreasClass objTaxRatesAreras = new Tax_Rate_AreasClass();
                            objTaxRatesAreras.Tax_Rate_ID = Convert.ToInt32(maxmID);
                            objTaxRatesAreras.Area = keyb.set_county;
                            objTaxRatesAreras.Description = keyb.set_decrep;
                            objTaxRatesAreras.Percent1 = Convert.ToDouble(kpaid.set_percentage) / 100;
                            objMangamentService.intsertTaxRates(objTaxRatesAreras);
                            //string tax_quray = "insert into Tax_Rate_Areas(Tax_Rate_ID,Area,Description,Percent1) values('" + glo.maxm_id(qury) + "','" + keyb.set_county + "','" + keyb.set_decrep + "','" + Convert.ToDouble(kpaid.set_percentage) / 100 + "')";
                            //glo.fun_insert(tax_quray);
                            fun_load_area_rates();
                        }
                    }

                }
                keyb.set_county = null;
                keyb.set_decrep = null;
                kpaid.set_percentage = null;
            }
            catch(Exception ex)
            {
                CustomLogging.Log("[Error: ]", ex.Message);
            }
        }

        private void btn_remove_tax_area_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGridRow rowss = (DataGridRow)DG_area_rates.ItemContainerGenerator.ContainerFromIndex(DG_area_rates.SelectedIndex);
                string a = (DG_area_rates.Columns[0].GetCellContent(rowss) as TextBlock).Text;
                if (a == "0")
                {
                    MessageBox.Show("You May Not Delete The Default Area Tex", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    POSManagementService objManagmentService = new POSManagementService();
                    Tax_Rate_AreasClass objTaxRatesAreas = new Tax_Rate_AreasClass();
                    objTaxRatesAreas.Tax_Rate_ID = Convert.ToInt32(a);
                    objManagmentService.DeleteTaxAreas(objTaxRatesAreas);
                   // string del_area_rate = "delete from Tax_Rate_Areas where Tax_Rate_ID ='" + a + "'";
                    //glo.fun_insert(del_area_rate);
                    fun_load_area_rates();
                }
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Error: ]", ex.Message);
            }
        }

        private void btn_change_rate_taxarea_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGridRow rowss = (DataGridRow)DG_area_rates.ItemContainerGenerator.ContainerFromIndex(DG_area_rates.SelectedIndex);
                string a = (DG_area_rates.Columns[0].GetCellContent(rowss) as TextBlock).Text;
                int tx_id = Convert.ToInt32(a);
                NumberKeypaid kkbb = new NumberKeypaid(14);
                kkbb.ShowDialog();
                if (kpaid.set_quantity != null)
                {
                    POSManagementService objManagmentService = new POSManagementService();
                    Tax_Rate_AreasClass objTaxRatesAreas = new Tax_Rate_AreasClass();
                    objTaxRatesAreas.Percent1 = Convert.ToDouble(kpaid.set_quantity) / 100;
                    objTaxRatesAreas.Tax_Rate_ID = tx_id;
                    objManagmentService.ChangeTaxRateAreas(objTaxRatesAreas);
                    //string update_tax_rate = "update Tax_Rate_Areas set Percent1 = '" + Convert.ToDouble(kpaid.set_quantity) / 100 + "' where Tax_Rate_ID = '" + tx_id + "'";
                    //glo.fun_insert(update_tax_rate);
                    fun_load_area_rates();
                }
                kpaid.set_quantity = null;
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[Error: ]", ex.Message);
            }
        }
    }
}
