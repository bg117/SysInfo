#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
using Microsoft.VisualBasic;
using ModernWpf;
using ModernWpf.Controls;
using syslib32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Management;
using System.Windows.Forms;
using System.Windows.Interactivity;
using System.Xaml;
using winapicp;
using static SysInfo.App;
using static SysInfo.SystemInformation;
using Point = System.Drawing.Point;

namespace SysInfo
{
    

    public partial class MainWindow
    {
        private Dictionary<string, object> vars = new Dictionary<string, object>();

        #region P/Invoke constants
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        //A window receives this message when the user chooses a command from the Window menu, or when the user chooses the maximize button, minimize button, restore button, or close button.
        private const int WM_SYSCOMMAND = 0x112;

        //Draws a horizontal dividing line.This flag is used only in a drop-down menu, submenu, or shortcut menu.The line cannot be grayed, disabled, or highlighted.
        private const int MF_SEPARATOR = 0x800;

        //Specifies that an ID is a position index into the menu and not a command ID.
        private const int MF_BYPOSITION = 0x400;

        //Specifies that the menu item is a text string.
        private const int MF_STRING = 0x0;

        //Menu Ids for our custom menu items
        private const int _About = 1000;

        private const int _Feedback = 1001;
        #endregion

        public static readonly System.Windows.Input.RoutedCommand OptionsCommand =
            new System.Windows.Input.RoutedUICommand("Options", "OptionsCommand", typeof(MainWindow),
                new System.Windows.Input.InputGestureCollection(new System.Windows.Input.InputGesture[] {
                    new System.Windows.Input.KeyGesture(System.Windows.Input.Key.E,
                        System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Shift),
                }));

        public static MainWindow MW { get; private set; }
        static MainWindow()
        {
            MW = new MainWindow();
        }
        private MainWindow()
        {
            this.InitializeComponent();

            vars.Add("sysinfo", SysInfo.SystemInformation.SI);
            vars.Add("notnewpe", new Performance());
            vars.Add("res", new Res());

            var userPrefs = new UserPreferences();

            this.Height = userPrefs._windowHeight;
            this.Width = userPrefs._windowWidth;
            this.Top = userPrefs._windowTop;
            this.Left = userPrefs._windowLeft;
            this.WindowState = userPrefs._windowState;

            ModernWpf.ThemeManager.Current.ApplicationTheme = SysInfo.Properties.Settings.Default.AppTheme;
            SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme = SysInfo.Properties.Settings.Default.AppThemeFluent;

            if (SysInfo.Properties.Settings.Default.SystemThemeIsOn)
            {
                ModernWpf.ThemeManager.Current.ApplicationTheme = null;
                SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme = SourceChord.FluentWPF.ElementTheme.Default;
            }

            else
            {
                ModernWpf.ThemeManager.Current.ApplicationTheme = SysInfo.Properties.Settings.Default.AppTheme;
                SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme = SysInfo.Properties.Settings.Default.AppThemeFluent;
            }

            if (Environment.OSVersion.Version.Major
                        < 6)
            {
                System.Windows.MessageBox.Show("OS not supported!", "Error", System.Windows.MessageBoxButton.OK,
                    System.Windows.MessageBoxImage.Error);
            }
            if (!VirtualMachineDetector.Assert())
            {
                return;
            }
            this.Runninginvm.Visibility = System.Windows.Visibility.Visible;
            this.RunningInVm2.Visibility = System.Windows.Visibility.Visible;
            this.Activate();
        }

        

        private void AdjustWindowSize()
        {
            if (this.WindowState == System.Windows.WindowState.Maximized)
            {
                System.Windows.SystemCommands.RestoreWindow(this);
            }
            else
            {
                System.Windows.SystemCommands.MaximizeWindow(this);
            }
        }

        private static System.Windows.Point GetMousePos()
        {
            Point point = Control.MousePosition;
            return new System.Windows.Point(point.X, point.Y);
        }



        [System.Runtime.InteropServices.DllImportAttribute("user32.dll"),]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp,
            IntPtr lp);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll"),]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, Boolean bRevert);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll"),]
        private static extern int TrackPopupMenu(IntPtr hMenu, uint uFlags, int x,
            int y, int nReserved, IntPtr hWnd, IntPtr prcRect);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll"),]
        private static extern Boolean GetWindowRect(IntPtr hWnd, out RECT rect);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll"),]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam,
            int lParam);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll"),]
        public static extern Boolean ReleaseCapture();

        private void SysMenu(Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            IntPtr hWnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            MainWindow.GetWindowRect(
                hWnd,
                out RECT _);
            IntPtr hMenu = MainWindow.GetSystemMenu(hWnd, false);
            int cmd = MainWindow.TrackPopupMenu(hMenu, 0x100,
                Convert.ToInt32(MainWindow.GetMousePos().X),
                Convert.ToInt32(MainWindow.GetMousePos().Y), 0, hWnd, IntPtr.Zero);
            if (cmd > 0)
            {
                MainWindow.SendMessage(hWnd, 0x112, (IntPtr)cmd, IntPtr.Zero);
            }
        }

        private void FormMove(Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton != System.Windows.Input.MouseButton.Left) return;
            if (e.ClickCount == 2)
            {
                this.AdjustWindowSize();
            }
            else
            {
                this.DragMove(); //Here is where I do the drag move
            }
        }

        private void CloseApp(Object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void HelpClick(Object sender, System.Windows.RoutedEventArgs e)
        {
            this.Frame1.NavigationService.Navigate(new About());
            this.BackButton.Visibility = System.Windows.Visibility.Visible;
            this.Title.Margin = new System.Windows.Thickness(8, 0, 0, 0);
            this.Tabs.SelectedIndex = -1;
        }

        private void HomeClick(Object sender, System.Windows.RoutedEventArgs e)
        {
            this.Frame1.NavigationService.Navigate(new Home());
            this.Tabs.SelectedIndex = -1;
        }

        private void ClickListViewItem(Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.BackButton.Visibility = System.Windows.Visibility.Visible;
            this.Title.Margin = new System.Windows.Thickness(8, 0, 0, 0);
            this.Frame1.NavigationService.Navigate(vars[(string)((System.Windows.Controls.ListViewItem) sender).Tag]);
        }

        private void Close(Object sender, System.ComponentModel.CancelEventArgs e)
        {
            UserPreferences userPrefs = new UserPreferences
            {
                _windowHeight = this.Height,
                _windowWidth = this.Width,
                _windowLeft = this.Left,
                _windowTop = this.Top,
                _windowState = this.WindowState,
            };


            userPrefs.Save();
            SysInfo.Properties.Settings.Default.Save();
            System.IO.File.Delete(@"C:\Program Files\SysInfo\data\resolution.dat");
        }

        private void ExportButton(Object sender, System.Windows.RoutedEventArgs e)
        {
            ExportFile();
        }

        public void ExportFile()
        {
            Microsoft.Win32.SaveFileDialog sv = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "System information file (*.snfo)|*.snfo",
                Title = "Export system information",
            };
            Boolean? result = sv.ShowDialog();
            if (result == true)
            {
                System.IO.File.WriteAllText(sv.FileName, this.FileText);
            }
        }

        public void ExportFile(string file)
        {
            
            if (!file.Contains(".")) file += ".snfo";
            System.IO.FileInfo fileName = new System.IO.FileInfo(file);
            fileName.Directory.Create();
            System.IO.File.WriteAllText(fileName.FullName, this.FileText);
        }

        private string GetDebuggerDisplay() => this.ToString();

        private void LostFocus(Object sender, EventArgs e)
        {
            this.BackButton.Foreground =
                new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 128, 128, 128));
            this.titleName.Foreground =
                new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 128, 128, 128));
            this.HomeButton.Foreground = this.HelpButton.Foreground =
                System.Windows.Media.Brushes.Gray;

        }

        private void GainFocus(Object sender, EventArgs e)
        {
            this.BackButton.SetResourceReference(System.Windows.Controls.Control.ForegroundProperty,
                "SystemControlBackgroundBaseHighBrush");
            this.titleName.SetResourceReference(System.Windows.Controls.Control.ForegroundProperty,
                "SystemControlBackgroundBaseHighBrush");
            this.HomeButton.SetResourceReference(System.Windows.Controls.Control.ForegroundProperty,
                "SystemControlBackgroundBaseHighBrush");
            this.HelpButton.SetResourceReference(System.Windows.Controls.Control.ForegroundProperty,
                "SystemControlBackgroundBaseHighBrush");
        }

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll"),]
        private static extern Boolean InsertMenu(IntPtr hMenu, int wPosition, int wFlags,
            int wIdNewItem, string lpNewItem);

        /// <summary>
        /// The event activated when MainWindow loads.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadWindow(Object sender, System.Windows.RoutedEventArgs e)
        {
            IntPtr windowhandle = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            System.Windows.Interop.HwndSource hwndSource = System.Windows.Interop.HwndSource.FromHwnd(windowhandle);
            if (hwndSource == null) return;
            hwndSource.AddHook(this.WndProc);

            //Get the handle for the system menu
            IntPtr systemMenuHandle = MainWindow.GetSystemMenu(windowhandle, false);

            //Insert our custom menu items
            MainWindow.InsertMenu(systemMenuHandle, 5, MainWindow.MF_BYPOSITION | MainWindow.MF_SEPARATOR,
                MainWindow.MF_STRING, string.Empty);
            MainWindow.InsertMenu(systemMenuHandle, 6, MainWindow.MF_BYPOSITION, MainWindow._About, "About...");
            //add an About menu item
            MainWindow.InsertMenu(systemMenuHandle, 7, MainWindow.MF_BYPOSITION, MainWindow._Feedback, "Give feedback");
            //add an About menu item

            hwndSource.AddHook(this.WndProc);
        }

        public string FileText =
@$"
[General]
{SI.Ver.Text}
{SI.Edition.Text}
{SI.ReleaseId.Text}
{SI.Build.Text}
{SI.Buildguid.Text}
{SI.pcname.Text}
{SI.Regowner.Text}
{SI.Regorg.Text}
{SI.Cpu.Text}
{SI.VideoAdapter.Text}
{SI.Screenres.Text}
{SI.Ram.Text}
{SI.Bits.Text}

[Processor]
{SI.cpu_P.Text}
{SI.identifier.Text}
{SI.cpuSn.Text}
{SI.cpuArchitecture.Text}
{SI.cpuSpeed.Text}
{SI.cpuVoltage.Text}
    [Cache Sizes]
    {SI.cpuCacheL1.Text}
    {SI.cpuCacheL2.Text}
    {SI.cpuCacheL3.Text}

[Display Adapter]
{SI.DisplayAdapter.Text}
{SI.DisplayAdapterMaxRef.Text}
{SI.DisplayAdapterMinRef.Text}
{SI.DisplayAdapterVoltage.Text}
{SI.DisplayAdapterClock.Text}
{SI.DisplayAdapterMemClock.Text}

[Disk Drives]
{SI.drivenm.Text}
{SI.Sysroot.Text}
{SI.Drive.Text}

".TrimStart();
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam,
            ref Boolean handled)
        {
            if (msg == MainWindow.WM_SYSCOMMAND)
            {
                //check which menu item was clicked
                switch (wParam.ToInt32())
                {
                    case MainWindow._About:
                        this.Frame1.NavigationService.Navigate(new About());
                        this.BackButton.Visibility = System.Windows.Visibility.Visible;
                        this.Title.Margin = new System.Windows.Thickness(8, 0, 0, 0);
                        this.Tabs.SelectedIndex = -1;

                        handled = true;
                        break;

                    case MainWindow._Feedback:
                        System.Diagnostics.Process.Start("https://forms.gle/Hd7Hp3TNY4heVV5R8");
                        this.Tabs.SelectedIndex = -1;

                        handled = true;
                        break;
                }
            }
            return IntPtr.Zero;
        }

        private void Back(Object sender, System.Windows.RoutedEventArgs e)
        {
            this.Frame1.NavigationService.GoBack();
            this.Tabs.SelectedIndex = -1;
            if (this.Frame1.NavigationService.CanGoBack) return;
            this.BackButton.Visibility = System.Windows.Visibility.Hidden;
            this.Title.Margin = new System.Windows.Thickness(-40, 0, 0, 0);
        }

        private void ShowOptionsPage(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Frame1.NavigationService.Navigate(new OptionsPage());
            this.BackButton.Visibility = System.Windows.Visibility.Visible;
            this.Title.Margin = new System.Windows.Thickness(8, 0, 0, 0);
            this.Tabs.SelectedIndex = -1;
        }

        private void ShowContextMenu(object sender, System.Windows.RoutedEventArgs e)
        {
            this.cMenu.PlacementTarget = sender as System.Windows.UIElement;
            this.cMenu.IsOpen = true;
        }

        private struct RECT
        {
            public int left, top, right, bottom;
        }

        private void ShowFeedbackPage(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://forms.gle/Hd7Hp3TNY4heVV5R8");
            this.Tabs.SelectedIndex = -1;
        }
    }
}