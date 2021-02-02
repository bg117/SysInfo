using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace SysInfo
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void HoverButton(object sender, System.Windows.Input.MouseEventArgs e)
        {
            
            ColorAnimation ca = new ColorAnimation(Color.FromArgb(211, 211, 211, 211),
                new Duration(TimeSpan.FromSeconds(0.4)));
            ButtonPanel.Background = new SolidColorBrush(Colors.White);
            ButtonPanel.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
        }
        private void LeaveButton(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ColorAnimation ca = new ColorAnimation(Colors.White,
                new Duration(TimeSpan.FromSeconds(0.4)));
            ButtonPanel.Background = new SolidColorBrush(Color.FromArgb(211, 211, 211, 211));
            ButtonPanel.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
        }
        private void PressButton(object sender, RoutedEventArgs e)
        {
             SysInfoHome si = Application.Current.Windows.OfType<SysInfoHome>().FirstOrDefault();
            ButtonPanel.Background = new SolidColorBrush(Color.FromArgb(211, 211, 211, 211));
            si.Frame1.NavigationService.Navigate(new Uri("SystemInformation.xaml", UriKind.Relative));
        }

        private void ButtonPanel1_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            
            ColorAnimation ca = new ColorAnimation(Color.FromArgb(211, 211, 211, 211),
                new Duration(TimeSpan.FromSeconds(0.4)));
            ButtonPanel1.Background = new SolidColorBrush(Colors.White);
            ButtonPanel1.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
        }

        private void ButtonPanel1_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ColorAnimation ca = new ColorAnimation(Colors.White,
                new Duration(TimeSpan.FromSeconds(0.4)));
            ButtonPanel1.Background = new SolidColorBrush(Color.FromArgb(211, 211, 211, 211));
            ButtonPanel1.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);

        }

        private void ButtonPanel1_MouseDown(object sender, RoutedEventArgs e)
        {
            SysInfoHome si = Application.Current.Windows.OfType<SysInfoHome>().FirstOrDefault();
            ButtonPanel1.Background = new SolidColorBrush(Color.FromArgb(211, 211, 211, 211));
            si.Frame1.NavigationService.Navigate(new Uri("Performance.xaml", UriKind.Relative));
        }

        private void ButtonPanel2_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ColorAnimation ca = new ColorAnimation(Color.FromArgb(211, 211, 211, 211),
                new Duration(TimeSpan.FromSeconds(0.4)));
            ButtonPanel2.Background = new SolidColorBrush(Colors.White);
            ButtonPanel2.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
        }

        private void ButtonPanel2_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ColorAnimation ca = new ColorAnimation(Colors.White,
                new Duration(TimeSpan.FromSeconds(0.4)));
            ButtonPanel2.Background = new SolidColorBrush(Color.FromArgb(211, 211, 211, 211));
            ButtonPanel2.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
        }

        private void ButtonPanel2_MouseDown(object sender, RoutedEventArgs e)
        {
            SysInfoHome si = Application.Current.Windows.OfType<SysInfoHome>().FirstOrDefault();
            ButtonPanel2.Background = new SolidColorBrush(Color.FromArgb(211, 211, 211, 211));
            si.Frame1.NavigationService.Navigate(new Uri("Res.xaml", UriKind.Relative));
        }
    }
}