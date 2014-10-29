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
using POS.Retail.Common;

namespace POS.Retail.Views
{
    /// <summary>
    /// Interaction logic for InventoryTransferForm.xaml
    /// </summary>
    public partial class InventoryTransferForm : Window
    {
        private string reason;

        public InventoryTransferForm()
        {
            InitializeComponent();
        }

        public InventoryTransferForm(string reason)
        {
            InitializeComponent();
            this.reason = reason;
            this.Title = "New Transfer: -" + reason;
        }
    }
}
