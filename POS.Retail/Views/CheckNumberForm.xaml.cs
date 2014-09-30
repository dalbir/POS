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
    /// Interaction logic for CheckNumberForm.xaml
    /// </summary>
    public partial class CheckNumberForm : Window
    {
       private static Int64 chk_number=0;

       public CheckNumberForm()
        {
            InitializeComponent();
        }
        private void btn_n1_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_n1.Content.ToString();
        }

        private void btn_n2_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_n2.Content.ToString();
        }

        private void btn_n3_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_n3.Content.ToString();
        }

        private void btn_n4_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_n4.Content.ToString();
        }

        private void btn_n5_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_n5.Content.ToString();
        }

        private void btn_n6_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_n6.Content.ToString();
        }

        private void btn_n7_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_n7.Content.ToString();
        }

        private void btn_n8_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_n8.Content.ToString();
        }

        private void btn_n9_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_n9.Content.ToString();
        }

        private void btn_n0_Click(object sender, RoutedEventArgs e)
        {
            txt_keyboard.Text = txt_keyboard.Text + btn_n0.Content.ToString();
        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            if (txt_keyboard.Text.Length != 0)
            {
                string s = txt_keyboard.Text;

                string s2 = s.Substring(0, s.Length - 1);
                txt_keyboard.Text = s2;
            }
        }

        private void btn_enter_Click(object sender, RoutedEventArgs e)
        {
            if (txt_keyboard.Text.Length != 0)
            {
                chk_number = Convert.ToInt64(txt_keyboard.Text);
                this.Close();
            }
            //string txt = txt_keyboard.Text;
            //if (txt_keyboard.Text.Contains("("))
            //{
            //    txt_keyboard.Text = txt.Substring(1, txt.Length -2);
                
            //}
            //else
            //{
            //    txt_keyboard.Text = "(" + txt_keyboard.Text + ")";
            //}
        }
        public  Int64 chknum
        {
            get { return chk_number; }
            set { chk_number = value; }
        }

        private void btn_bp_Click(object sender, RoutedEventArgs e)
        {
            if (txt_keyboard.Text.Length != 0)
            {
                string s = txt_keyboard.Text;

                string s2 = s.Substring(0, s.Length - 1);
                txt_keyboard.Text = s2;
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            chknum = 0;
        }
    }
}
