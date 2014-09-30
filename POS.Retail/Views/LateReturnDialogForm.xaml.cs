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
    /// Interaction logic for LateReturnDialogForm.xaml
    /// </summary>
    public partial class LateReturnDialogForm : Window
    {
        private static string values = null;
        public LateReturnDialogForm() //Late_Return_Dialog_frm()
        {
            InitializeComponent();
        }

        private void InputTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Keyboard kb_frm = new Keyboard("Enter New Value");
            kb_frm.ShowDialog();
            if (kb_frm.set_new_value != null)
            {
                InputTextBox.Text = kb_frm.set_new_value;
            }
        }

        public string value_input
        {
            get { return values; }
            set { values = value; }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            take_result();
       }
        private void take_result()
        {
            if (InputTextBox.Text.Length != 0)
            {
                if (InputTextBox.Text == "I" || InputTextBox.Text == "i" || InputTextBox.Text == "W" || InputTextBox.Text == "w")
                {
                    if (InputTextBox.Text == "I" || InputTextBox.Text == "i")
                    {
                        values = "I";
                        this.Close();
                    }
                    else
                    {
                        values = "W";
                    }
                }
                else
                {
                    MessageBox.Show("Valid values or (I) and (W)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btn_keyboard_Click(object sender, RoutedEventArgs e)
        {
            Keyboard kb_frm = new Keyboard("Enter New Value");
            kb_frm.ShowDialog();
            if (kb_frm.set_new_value != null)
            {
                InputTextBox.Text = kb_frm.set_new_value;
            }
        }

        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                take_result();
            }
        }
    }
}
