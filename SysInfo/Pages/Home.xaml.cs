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
    ///     Interaction logic for Home.xaml
    /// </summary>
    public partial class Home
    {
        public Home()
        {
            this.InitializeComponent();
        }

        private void PressButton(Object sender, System.Windows.RoutedEventArgs e)
        {
            var si =
                System.Linq.Enumerable.FirstOrDefault(
                    System.Linq.Enumerable.OfType<MainWindow>(System.Windows.Application.Current.Windows));
            this.ButtonPanel.Background =
                new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(211, 211, 211, 211));
            if (si == null) return;
            si.Frame1.NavigationService.Navigate(SysInfo.SystemInformation.SI);
            si.BackButton.Visibility = System.Windows.Visibility.Visible;
            si.Title.Margin = new System.Windows.Thickness(8, 0, 0, 0);
            si.Tabs.SelectedIndex = 0;
        }

        private void ButtonPanel1_MouseDown(Object sender, System.Windows.RoutedEventArgs e)
        {
            var si =
                System.Linq.Enumerable.FirstOrDefault(
                    System.Linq.Enumerable.OfType<MainWindow>(System.Windows.Application.Current.Windows));
            this.ButtonPanel1.Background =
                new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(211, 211, 211, 211));
            if (si == null) return;
            si.Frame1.NavigationService.Navigate(new Performance());
            si.BackButton.Visibility = System.Windows.Visibility.Visible;
            si.Title.Margin = new System.Windows.Thickness(8, 0, 0, 0);
            si.Tabs.SelectedIndex = 1;
        }

        private void ButtonPanel2_MouseDown(Object sender, System.Windows.RoutedEventArgs e)
        {
            var si =
                System.Linq.Enumerable.FirstOrDefault(
                    System.Linq.Enumerable.OfType<MainWindow>(System.Windows.Application.Current.Windows));
            this.ButtonPanel2.Background =
                new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(211, 211, 211, 211));
            if (si == null) return;
            si.Frame1.NavigationService.Navigate(new Res());
            si.BackButton.Visibility = System.Windows.Visibility.Visible;
            si.Title.Margin = new System.Windows.Thickness(8, 0, 0, 0);
            si.Tabs.SelectedIndex = 2;
        }
    }
}