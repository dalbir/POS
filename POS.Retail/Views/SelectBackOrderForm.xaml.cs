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

namespace POS.Retail.Views
{
    /// <summary>
    /// Interaction logic for SelectBackOrderForm.xaml
    /// </summary>
    public partial class SelectBackOrderForm : Window
    {
       private static string lineNo;
       private BackOrdersClass objBackOrdersClass;
        public SelectBackOrderForm()
        {
            InitializeComponent();
        }

        public SelectBackOrderForm(BackOrdersClass objBackOrdersClass)
        {
            InitializeComponent();
            this.objBackOrdersClass = objBackOrdersClass;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BackOrdersForm objBackOrdersForm = new BackOrdersForm();
            lblGetContent.Content = objBackOrdersForm.setContent;
            txtLineNumber.Text = objBackOrdersForm.setLineNumber;
        }
        public string setLineNo
        {
            get { return lineNo; }
            set { lineNo = value; }
        }
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
           
            this.Close();
            //objBackOrdersClass.flage = "FillOrders";
            lineNo = txtLineNumber.Text.Trim();
            


        }
    }
}
