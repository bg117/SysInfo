namespace SysInfo
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
    ///     Interaction logic for About.xaml
    /// </summary>
    public partial class About
    {
        public About()
        {
            this.InitializeComponent();
        }

        private void OpenHyperlink(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(this.Hyperlink.Text);
        }

        private void CopyLink(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.Clipboard.SetText(this.Hyperlink.Text);
            System.Windows.Controls.ToolTip tt = new System.Windows.Controls.ToolTip
            {
                Content = "Copied to clipboard!",
            };
            if (tt.IsOpen)
            {
                tt.StaysOpen = false;
            }
            this.Hyperlink.ToolTip = tt;
            tt.IsOpen = true;
        }

        private void ClickHyperlink(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SysInfo.Windows.ConfirmationWindow cw = new SysInfo.Windows.ConfirmationWindow();
            cw.Owner = System.Windows.Application.Current.MainWindow;
            cw.Show();
        }
    }
}