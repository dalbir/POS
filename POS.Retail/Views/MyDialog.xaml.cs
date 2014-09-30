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
    /// Interaction logic for MyDialog.xaml
    /// </summary>
    public partial class MyDialog : Window
    {
        public MyDialog()
        {
            InitializeComponent();
        }
        public MyDialog(string title, string input)
        {
            InitializeComponent();
            TitleText = title;
            if (title.Contains("Scan, Swipe or Type Gift Card "))
            {
                passwordBox1.Visibility = Visibility.Visible;
                InputTextBox.Visibility = Visibility.Hidden;
            }
            else
            {
                passwordBox1.Visibility = Visibility.Hidden;
                InputTextBox.Visibility = Visibility.Visible;
            }
            InputText = input;
            InputText1 = input;
        }
        public MyDialog(string title, string input, int j)
        {
            InitializeComponent();
            TitleText = title;
            if (title.Contains("Scan, Swipe or Type Gift Card "))
            {
                passwordBox1.Visibility = Visibility.Visible;
                InputTextBox.Visibility = Visibility.Hidden;
            }
            InputText = input;
            InputText1 = input;
        }

        public string TitleText
        {
            get { return TitleTextBox.Text; }
            set { TitleTextBox.Text = value; }
        }

        public string InputText
        {
            get { return InputTextBox.Text; }
            set { InputTextBox.Text = value; }
        }
        public string InputText1
        {
            get { return passwordBox1.Password; }
            set { passwordBox1.Password = value; }
        }


        private void BtnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            InputTextBox.Clear();
            passwordBox1.Clear();
            Close();
        }

        private void BtnOk_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (InputTextBox.Text.Length == 0 && passwordBox1.Password.Length == 0)
            {
                MessageBox.Show("Please " + TitleTextBox.Text + ", Or if you want to cancel click cancel.", "No Gift Card ID entered", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                Close();
            }

        }

        private void btn_keyboard_Click(object sender, RoutedEventArgs e)
        {
            Keyboard kb = new Keyboard(TitleTextBox.Text);
            kb.ShowDialog();
            if (TitleTextBox.Text.Contains("Scan, Swipe or Type Gift Card "))
            {
                passwordBox1.Password = kb.set_decrep;
            }
            else
            {
                InputTextBox.Text = kb.set_decrep;
            }
        }
    }
}
