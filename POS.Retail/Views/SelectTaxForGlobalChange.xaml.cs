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

namespace POS.Retail.Views
{
    /// <summary>
    /// Interaction logic for SelectTaxForGlobalChange.xaml
    /// </summary>
    public partial class SelectTaxForGlobalChange : Window
    {
        POSManagementService objPOSMangmentService = new POSManagementService();
        private static string valu = null;
        public SelectTaxForGlobalChange()
        {
            InitializeComponent();
        }
        public string setValu
        {
            get { return valu; }
            set { valu = value; }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Tax_RateClass objTaxRate = new Tax_RateClass();
                objTaxRate.Store_ID = "1001";
                DataTable dt = objPOSMangmentService.RetriveTaxRat(objTaxRate);
                if(dt.Rows.Count > 0)
                {
                    tax1price.Text = dt.Rows[0]["Tax1_Rate"].ToString();
                    tax2price.Text = dt.Rows[0]["Tax2_Rate"].ToString();
                    tax3price.Text = dt.Rows[0]["Tax3_Rate"].ToString();
                }
                else
                {
                    tax1price.Text = "0.00";
                    tax2price.Text = "0.00";
                    tax3price.Text = "0.00";
                }
            }
            catch(Exception ex)
            {
            }
        }
        private void btnTax1_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if(btn.Name == "btnTax1")
            {
                valu = "tax1";
            }
            else if(btn.Name == "btnTax2")
            {
                valu = "tax2";
            }
            else if(btn.Name == "btnTax3")
            {
                valu = "tax3";
            }
            else if (btn.Name == "btnBarTax")
            {
                valu = "barTax";
            }
            this.Close();
        }
    }
}
