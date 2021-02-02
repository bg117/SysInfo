#pragma warning disable CS0108 // Member hides inherited member; missing new keyword

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using static System.Windows.Forms.Cursor;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;
using point = System.Drawing.Point;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace SysInfo
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public partial class SysInfoHome
    {
        public static readonly RoutedCommand OptionsCommand = new RoutedUICommand("Options", "OptionsCommand", typeof(SysInfoHome), new InputGestureCollection(new InputGesture[]
        {
            new KeyGesture(Key.E, ModifierKeys.Control | ModifierKeys.Alt)
        }));

        public SysInfoHome()
        {
            InitializeComponent();
            
            point point = new point(Position.X,
                Position.Y);
            Top = point.Y;
            Left = point.X;
            bool v = Environment.OSVersion.Version.Major
                     < 6;
            if (v)
                MessageBox.Show("OS not supported!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            if (!VirtualMachineDetector.Assert())
                return;
            Runninginvm.Visibility = Visibility.Visible;
            RunningInVm2.Visibility = Visibility.Visible;
        }

        public static Point GetMousePositionWindowsForms()
        {
            point point = Control.MousePosition;
            return new Point(point.X, point.Y);
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            if (sizeInfo is null)
                throw new ArgumentNullException(nameof(sizeInfo));

            base.OnRenderSizeChanged(sizeInfo: sizeInfo);
            switch (WindowState)
            {
                case WindowState.Maximized:
                    BorderThickness = new Thickness(
                        left: SystemParameters.WindowResizeBorderThickness.Left
                              + SystemParameters.FixedFrameVerticalBorderWidth,
                        top: SystemParameters.WindowResizeBorderThickness.Top
                              + SystemParameters.FixedFrameHorizontalBorderHeight,
                        right: SystemParameters.WindowResizeBorderThickness.Right
                              + SystemParameters.FixedFrameVerticalBorderWidth,
                        bottom: SystemParameters.WindowResizeBorderThickness.Bottom
                              + SystemParameters.FixedFrameHorizontalBorderHeight);
                    break;

                default:
                    BorderThickness = new Thickness();
                    break;
            }
            switch (WindowState)
            {
                case WindowState.Maximized:
                    Max.ToolTip = "Restore Down";
                    Max.Content = "2";
                    break;

                default:
                    Max.ToolTip = "Maximize";
                    Max.Content = "1";
                    break;
            }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        private static extern int TrackPopupMenu(IntPtr hMenu, uint uFlags, int x, int y, int nReserved, IntPtr hWnd, IntPtr prcRect);

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT rect);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private struct RECT
        { public int left, top, right, bottom; }

        private void SysMenu(object sender, MouseButtonEventArgs e)
        {
            IntPtr hWnd = new WindowInteropHelper(this).Handle;
            GetWindowRect(
                hWnd,
                out _);
            IntPtr hMenu = GetSystemMenu(hWnd, false);
            int cmd = TrackPopupMenu(hMenu, 0x100, Convert.ToInt32(GetMousePositionWindowsForms().X), Convert.ToInt32(GetMousePositionWindowsForms().Y), 0, hWnd, IntPtr.Zero);
            if (cmd > 0)
            {
                SendMessage(hWnd, 0x112, (IntPtr)cmd, IntPtr.Zero);
            }
        }

        private void FormMove(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            DragMove();
        }

        private void CloseApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void EnterClose(object sender, MouseEventArgs e)
        {
            CloseBtn.Background = new SolidColorBrush(Colors.Red);
            CloseBtn.Foreground = new SolidColorBrush(Colors.White);
        }

        private void LeaveClose(object sender, MouseEventArgs e)
        {
            CloseBtn.Background = new SolidColorBrush(Colors.White);
            CloseBtn.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void EnterHelp(object sender, MouseEventArgs e)
        {
            Help.Background = new SolidColorBrush(Color.FromArgb(255, 0, 120, 215));
            Help.Foreground = new SolidColorBrush(Colors.White);
        }

        private void LeaveHelp(object sender, MouseEventArgs e)
        {
            Help.Background = new SolidColorBrush(Colors.White);
            Help.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void HelpClick(object sender, RoutedEventArgs e)
        => Frame1.Source = new Uri("About.xaml", UriKind.Relative);

        private void HomeClick(object sender, RoutedEventArgs e)
        => Frame1.Source = new Uri("Home.xaml", UriKind.Relative);

        private void HoverHome(object sender, MouseEventArgs e)
        => Home.Background = new SolidColorBrush(Color.FromArgb(255, 211, 211, 211));

        private void LeaveHome(object sender, MouseEventArgs e)
        => Home.Background = new SolidColorBrush(Colors.White);

        private void ClickSystemInformation(object sender, MouseButtonEventArgs e)
        => Frame1.Source = new Uri("SystemInformation.xaml", UriKind.Relative);

        private void EnterMinimize(object sender, MouseEventArgs e)
        => Minimize.Background = new SolidColorBrush(Color.FromArgb(255, 211, 211, 211));

        private void LeaveMinimize(object sender, MouseEventArgs e)
        => Minimize.Background = new SolidColorBrush(Colors.White);

        private void MinimizeButton(object sender, RoutedEventArgs e)
        => WindowState = WindowState.Minimized;

        private void MaximizeButton(object sender, RoutedEventArgs e)
        {
            switch (WindowState)
            {
                case WindowState.Maximized:
                    WindowState = WindowState.Normal;
                    break;

                default:
                    WindowState = WindowState.Maximized;
                    break;
            }
        }

        private void Max_MouseEnter(object sender, MouseEventArgs e)
        => Max.Background = new SolidColorBrush(Color.FromArgb(255, 211, 211, 211));

        private void Max_MouseLeave(object sender, MouseEventArgs e)
        => Max.Background = new SolidColorBrush(Colors.White);

        private void ListBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
            => Frame1.Source = new Uri("Performance.xaml", UriKind.Relative);

        private void ListBox_PreviewMouseDown_1(object sender, MouseButtonEventArgs e) =>
            Frame1.Source = new Uri("Res.xaml", UriKind.Relative);

        private void Close(object sender, CancelEventArgs e) =>
            File.Delete(@"C:\Program Files\SysInfo\data\resolution.dat");

        private string FileText {
            get {
                SystemInformation si = new SystemInformation();
                string s =
                    string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}\n{8}\n{9}\n{10}\n{11}\r\n", si.Ver.Text,
                        si.Edition.Text, si.Build.Text, si.Buildguid.Text, si.Regowner.Text, si.Regorg.Text,
                        si.Cpu.Text, si.Displayadapter.Text, si.Screenres.Text, si.Ram.Text, si.Sysroot.Text,
                        si.Drive.Text);
                return s;
            }
        }

        private void ExportFile(object sender, RoutedEventArgs e) {
            SaveFileDialog sv = new SaveFileDialog {
                Filter = "System information file (*.sinf)|*.sinf", Title = "Export system information"
            };
            bool? result = sv.ShowDialog();
            if (result == true) {
                File.WriteAllText(sv.FileName, FileText);
            }
        }

        private string GetDebuggerDisplay() {
            return ToString();
        }

        private void ChangeColorEnter(object sender, MouseEventArgs e) {
            ColorAnimation ca = new ColorAnimation(Color.FromArgb(128, 211, 211, 211),
                new Duration(TimeSpan.FromSeconds(0.4)));
            ButtonMenu.Background = new SolidColorBrush(Colors.Transparent);
            ButtonMenu.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
        }

        private void ChangeColorLeave(object sender, MouseEventArgs e) {
            ColorAnimation ca = new ColorAnimation(Colors.Transparent, new Duration(TimeSpan.FromSeconds(0.4)));
            ButtonMenu.Background = new SolidColorBrush(Color.FromArgb(128, 211, 211, 211));
            ButtonMenu.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
        }

        private void ContextMenu(object sender, RoutedEventArgs e) {
            v.IsOpen = v.IsOpen == false;
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            e.Handled = true;
            if (e.ChangedButton == MouseButton.Right) {
                return;
            }

            IntPtr hWnd = new WindowInteropHelper(this).Handle;
            RECT pos;
            GetWindowRect(hWnd, out pos);
            IntPtr hMenu = GetSystemMenu(hWnd, false);
            int cmd = TrackPopupMenu(hMenu, 0x100, pos.left, pos.top + 32, 0, hWnd, IntPtr.Zero);
            if (cmd > 0) SendMessage(hWnd, 0x112, (IntPtr) cmd, IntPtr.Zero);
        }
    }
}