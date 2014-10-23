using System;
using System.Collections;
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
    /// Interaction logic for CashCountForm.xaml
    /// </summary>
    public partial class CashCountForm : Window
    {
        TextBox senderTextBox;
        POSManagementService objPOSManagementService = new POSManagementService();
        private string ID;
        public CashCountForm()
        {
            InitializeComponent();
        }

        public CashCountForm(string ID)
        {
            InitializeComponent();
            this.ID = ID;
        }
        
        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                string txt = btn.Name.ToString().Substring(3, 1);
                if (senderTextBox.Text == "0")
                    senderTextBox.Text = "";
                senderTextBox.Text = senderTextBox.Text + txt;
                funCount();
            }
            catch (Exception)
            {
                
            }
        }
        
        public void funCount()
        {
     
            double total = 0;
            double txtboxValue = 0;
            double multiplyValue = 0;
            try
            {
                IEnumerable<TextBox> txtBoxes = mainGrid.Children.OfType<TextBox>();
                foreach (var itemTxt in txtBoxes)
                {
                    if (itemTxt.Name != "txtTotal")
                    {
                        if (itemTxt.Text == "")
                        {
                            txtboxValue = 0;
                        }
                        else
                        {
                            switch(itemTxt.TabIndex)
                            {
                                case 1:
                                    multiplyValue = 0.01;
                                    break;
                                case 2:
                                    multiplyValue = 0.05;
                                    break;
                                case 3:
                                    multiplyValue = 0.10;
                                    break;
                                case 4:
                                    multiplyValue = 0.25;
                                    break;
                                case 5:
                                    multiplyValue = 0.50;
                                    break;
                                case 6:
                                    multiplyValue = 1;
                                    break;
                                case 7:
                                    multiplyValue = 5;
                                    break;
                                case 8:
                                    multiplyValue = 10;
                                    break;
                                case 9:
                                    multiplyValue = 20;
                                    break;
                                case 10:
                                    multiplyValue = 50;
                                    break;
                                case 11:
                                    multiplyValue = 100;
                                    break;
                            }
                            txtboxValue = Convert.ToDouble(itemTxt.Text) * multiplyValue;
                        }
                        total = total + txtboxValue;
                    }
                }
                txtTotal.Text = total.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void txtPennies_GotFocus(object sender, RoutedEventArgs e)
        {
           TextBox focusedTextbox = (TextBox)sender;
           senderTextBox = focusedTextbox;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            senderTextBox.Text = "0";
            funCount();
           
        }

        private void txtPennies_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txt = sender as TextBox;
           
            funCount();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Are you sure you are done counting?","Question",MessageBoxButton.YesNo,MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Time_Clock_Cash_CountClass objTimeClockCashCount = new Time_Clock_Cash_CountClass();
                    objTimeClockCashCount.Store_ID = "1001";
                    objTimeClockCashCount.ID = Convert.ToInt32(ID);
                    objTimeClockCashCount.NumPennies = Convert.ToInt32(txtPennies.Text);
                    objTimeClockCashCount.NumNickels = Convert.ToInt32(txtNicles.Text);
                    objTimeClockCashCount.NumDimes = Convert.ToInt32(txtDimes.Text);
                    objTimeClockCashCount.NumQuarters = Convert.ToInt32(txtQuarters.Text);
                    objTimeClockCashCount.NumHalfDollars = Convert.ToInt32(txtHalfQuarters.Text);
                    objTimeClockCashCount.NumDollars = Convert.ToInt32(txtDoller.Text);
                    objTimeClockCashCount.NumFives = Convert.ToInt32(txtFives.Text);
                    objTimeClockCashCount.NumTens = Convert.ToInt32(txtTens.Text);
                    objTimeClockCashCount.NumTwenties = Convert.ToInt32(txtTwenties.Text);
                    objTimeClockCashCount.NumFifties = Convert.ToInt32(txtFiftes.Text);
                    objTimeClockCashCount.NumHundreds = Convert.ToInt32(txtHundres.Text);
                    objPOSManagementService.insertClockCashCount(objTimeClockCashCount);
                    if (objTimeClockCashCount.IsSuccessfull == true)
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception)
            {
 
            }
        }

    }
}
