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

namespace POS.Retail.Views
{
    /// <summary>
    /// Interaction logic for CashCountForm.xaml
    /// </summary>
    public partial class CashCountForm : Window
    {
        TextBox senderTextBox;
        public CashCountForm()
        {
            InitializeComponent();
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

    }
}
