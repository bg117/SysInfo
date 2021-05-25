namespace SysInfo.Windows
{
    using Microsoft.VisualBasic;
    using ModernWpf;
    using ModernWpf.Controls;
    using syslib32;
    using System;
    using System.Drawing;
    using System.Management;
    using System.Windows.Forms;
    using System.Windows.Interactivity;
    using System.Xaml;
    using winapicp;
    using Xceed.Wpf.Toolkit;

    /// <summary>
    ///     Interaction logic for ConfirmationWindow.xaml
    /// </summary>
    public partial class ConfirmationWindow : System.Windows.Window
    {
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;

        private readonly About _a = new About();

        public ConfirmationWindow()
        {
            this.InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", SetLastError = true),]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll"),]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.title.Text = this.title.Text.Replace("{link}", this._a.Hyperlink.Text);
            this.linkText.Text = this.linkText.Text.Replace("{link}", this._a.Hyperlink.Text);
            IntPtr hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            ConfirmationWindow.SetWindowLong(hwnd, ConfirmationWindow.GWL_STYLE,
                ConfirmationWindow.GetWindowLong(hwnd, ConfirmationWindow.GWL_STYLE) & ~ConfirmationWindow.WS_SYSMENU);
        }

        private void No(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

        private void Yes(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(this._a.Hyperlink.Text);
        }
    }
}