using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POS.Retail
{
    /// <summary>
    /// Interaction logic for MsgForm.xaml
    /// </summary>
    public partial class MsgForm : Window
    {
        private const int Style = -16;
        private const int MaximizeIcon = 0x10000;
        private const int MinimizeIcon = 0x20000;
        PurchaseOrderForm p = new PurchaseOrderForm();
        private static int cancl = 0;
        public MsgForm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbl.Content = new TextBlock() { Text = "The Vendor '" + p.set_vendor_name + "' is Not associated with this Item. Would You Like To Create Info For '" + p.set_vendor_name + "'", TextWrapping = TextWrapping.Wrap };
            var window = this;
            if (window != null)
            {
                var hWnd = new WindowInteropHelper(window).Handle;
                if (hWnd == IntPtr.Zero)
                {
                    window.SourceInitialized += OnSourceInitialized;
                }
                else
                {
                    UpdateWindowStyle(window, hWnd);
                }
            }
        }

        public static class NativeMethods
        {
            [DllImport("user32.dll")]
            internal static extern int GetWindowLong(IntPtr hWnd, int index);

            [DllImport("user32.dll")]
            internal static extern int SetWindowLong(IntPtr hWnd, int index, int newLong);

        }
        private static void OnSourceInitialized(object sender, EventArgs e)
        {
            var window = (Window)sender;

            var hWnd = new WindowInteropHelper(window).Handle;
            UpdateWindowStyle(window, hWnd);

            window.SourceInitialized -= OnSourceInitialized;
        }
        private static void UpdateWindowStyle(Window window, IntPtr hWnd)
        {
            var style = NativeMethods.GetWindowLong(hWnd, Style);

            style &= ~MinimizeIcon;
            style &= ~MaximizeIcon;

            NativeMethods.SetWindowLong(hWnd, Style, style);
            //const int GWL_STYLE = -16;
            const int WS_SYSMENU = 0x80000;
            IntPtr hwnd = new System.Windows.Interop.WindowInteropHelper(window).Handle;
            NativeMethods.SetWindowLong(hwnd, Style, NativeMethods.GetWindowLong(hwnd, Style) & ~WS_SYSMENU);
            //NativeMethods.RemoveMenu(hWnd, 0xF060, 0x0000);


        }

        private void btn_yes_Click(object sender, RoutedEventArgs e)
        {
            EnterVendorForm vf = new EnterVendorForm();
            this.Close();
            vf.ShowDialog();
        }

        private void btn_no_Click(object sender, RoutedEventArgs e)
        {
            cancl = 1;
            this.Close();
        }

        public int set_cancl
        {
            get { return cancl; }
            set { cancl = value; }
        }
    }
}
