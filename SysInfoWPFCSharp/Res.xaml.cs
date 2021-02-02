using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using static SysInfo.CResolution;
using static SysInfo.GetSetResolution;
using static System.Environment;
using static System.Runtime.InteropServices.Marshal;
using static System.Windows.Int32Rect;
using static System.Windows.Interop.Imaging;
using static System.Windows.Media.Imaging.BitmapSizeOptions;
using static System.Windows.MessageBox;

namespace SysInfo
{
    public class MaskVisibilityBehavior : System.Windows.Interactivity.Behavior<Xceed.Wpf.Toolkit.MaskedTextBox>
    {
        private FrameworkElement _contentPresenter;

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Loaded += (sender, args) =>
            {
                _contentPresenter =
                    AssociatedObject.Template.FindName("PART_ContentHost", AssociatedObject) as FrameworkElement;
                if (_contentPresenter == null)
                    throw new InvalidCastException();
                AssociatedObject.TextChanged += OnTextChanged;
                AssociatedObject.GotFocus += OnGotFocus;
                AssociatedObject.LostFocus += OnLostFocus;
                UpdateMaskVisibility();
            };
        }

        protected override void OnDetaching()
        {
            AssociatedObject.TextChanged -= OnTextChanged;
            AssociatedObject.GotFocus -= OnGotFocus;
            AssociatedObject.LostFocus -= OnLostFocus;
            base.OnDetaching();
        }

        private void OnLostFocus(object sender, RoutedEventArgs routedEventArgs)
        {
            UpdateMaskVisibility();
        }

        private void OnGotFocus(object sender, RoutedEventArgs routedEventArgs)
        {
            UpdateMaskVisibility();
        }

        private void OnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            UpdateMaskVisibility();
        }

        private void UpdateMaskVisibility()
        {
            _contentPresenter.Visibility = AssociatedObject.MaskedTextProvider.AssignedEditPositionCount > 0 ||
                                           AssociatedObject.IsFocused
                ? Visibility.Visible
                : Visibility.Hidden;
        }
    }

    public partial class Res : Page
    {
        [DllImport("user32.dll")]
        private static extern bool EnumDisplaySettingsA(string lpszDeviceName, int iModeNum, ref DEVMODE lpDevMode);

        private void ListDisplaySettings()
        {
            DEVMODE vDevMode = new DEVMODE();
            int i = 0;
            while (EnumDisplaySettingsA(null, i, ref vDevMode))
            {
                ListViewR.Items.Add($"{vDevMode.dmPelsWidth}x{vDevMode.dmPelsHeight}@{vDevMode.dmDisplayFrequency}Hz            {vDevMode.dmBitsPerPel}bpp");
                i++;
            }
        }

        private static int CRefreshRate
        {
            get
            {
                string freq = "";
                try
                {
                    ManagementObjectSearcher o = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
                    foreach (PropertyData property in from ManagementObject mo in o.Get()
                                                      from PropertyData property in mo.Properties
                                                      where property.Name == "CurrentRefreshRate"
                                                      select property)
                    {
                        freq = property.Value.ToString();
                    }
                }
                catch (ManagementException e)
                {
                    Show("An error occurred while querying for WMI data: " + e.Message);
                }

                return Convert.ToInt32(freq);
            }
        }

        public Res()
        {
            InitializeComponent();
            SaveData();
            Shield();
            ListDisplaySettings();
            ResBox.Mask = "0000 x 0000";
            BitsPerPel.Value = Screen.PrimaryScreen.BitsPerPixel;
            HzControl.Value = CRefreshRate;
        }

        private void Apply()
        {
            string txt = ResBox.Text;
            int? bpp = BitsPerPel.Value;
            string[] partsOfText = txt.Split('x');
            try
            {
                int resHeight = int.Parse(partsOfText[1]);
                int resWidth = int.Parse(partsOfText[0]);
                int hz = int.Parse(HzControl.Text.Trim());

                switch (CheckBox.IsChecked)
                {
                    case true:
                        {
                            DialogResult d = (DialogResult)Show(
                                $"You are about to apply a custom resolution of {resWidth}x{resHeight} with a refresh rate of {hz}hz. Is this correct?",
                                "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                            if (d != DialogResult.Yes)
                            {
                                break;
                            }

                            ChangeRes((uint)resWidth, (uint)resHeight, (uint)hz, (uint)bpp);
                        }
                        break;

                    default:
                        {
                            DialogResult d = (DialogResult)Show(
                                $"You are about to apply a custom resolution of {resWidth}x{resHeight}. Is this correct?",
                                "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                            if (d != DialogResult.Yes)
                            {
                                break;
                            }

                            ChangeRes(resWidth, resHeight);
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                Show($"Invalid and/or blank resolution! {e.Message}", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            finally
            {
                ResBox.Text = "";
            }
        }

        private void CallRes(object sender, EventArgs e)
        {
            Apply();
        }

        private void Shield()
        {
            BitmapSource shieldSource;
            Shell32Icons.SHSTOCKICONINFO sii = new Shell32Icons.SHSTOCKICONINFO();
            Type t = typeof(Shell32Icons.SHSTOCKICONINFO);
            if (OSVersion.Version.Major <= 6)
            {
                shieldSource = CreateBitmapSourceFromHIcon(SystemIcons.Shield.Handle, Empty, FromEmptyOptions());
                Img.Source = shieldSource;
            }
            else
            {
                sii.cbSize = (uint)SizeOf(t);
                ThrowExceptionForHR(Shell32Icons.SHGetStockIconInfo(Shell32Icons.SHSTOCKICONID.SIID_SHIELD,
                    Shell32Icons.SHGSI.SHGSI_ICON | Shell32Icons.SHGSI.SHGSI_SMALLICON, ref sii));
                shieldSource = CreateBitmapSourceFromHIcon(sii.hIcon, Empty, FromEmptyOptions());
                Shell32Icons.DestroyIcon(sii.hIcon);
                Img.Source = shieldSource;
            }
        }

        private void RevertRes(object sender, EventArgs e) => LoadData();

        private void DisableEnableHzControl(object sender, RoutedEventArgs e)
        {
            if (CheckBox.IsChecked != null && (bool)CheckBox.IsChecked)
            {
                if (Properties.Settings.Default.ShowWarning)
                {
                    Show(
                        $"WARNING: We are not responsible for any damage caused by this tool to your computer! Use carefully.",
                        "Alert", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    Properties.Settings.Default.ShowWarning = false;
                    Properties.Settings.Default.Save();
                }

                HzControl.IsEnabled = true;
                BitsPerPel.IsEnabled = true;
            }
            else
            {
                HzControl.IsEnabled = false;
                BitsPerPel.IsEnabled = false;
            }
        }

        private void GetResolution()
        {
            if (ListViewR.SelectedItems.Count > 0)
            {
                string s = ListViewR.SelectedItem.ToString();
                string[] v = s.Split(new String[] { "x", "@", "Hz", "bpp" }, StringSplitOptions.RemoveEmptyEntries);
                uint q = uint.Parse(v[0]);
                uint b = uint.Parse(v[1]);
                uint z = uint.Parse(v[2]);
                uint f = uint.Parse(v[3]);
                ChangeRes(q, b, z, f);
            }
            else
            {
                return;
            }
        }

        private void ClickApply(object sender, RoutedEventArgs e)
        {
            GetResolution();
        }

        private void ResBoxEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is MaskedTextBox textBox)
            {
                Dispatcher.BeginInvoke((MethodInvoker)delegate ()
                {
                    int pos = textBox.SelectionStart;

                    if (pos > textBox.Text.Length)
                        pos = textBox.Text.Length;

                    textBox.Select(pos, 0);
                });
            }
        }

        private void ListViewR_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            string s = ListViewR.SelectedItem.ToString();
            string[] v = s.Split(new String[] { "x", "@", "Hz", "bpp" }, StringSplitOptions.RemoveEmptyEntries);
            uint q = uint.Parse(v[0]);
            uint b = uint.Parse(v[1]);
            uint z = uint.Parse(v[2]);
            uint f = uint.Parse(v[3]);
            ChangeRes(q, b, z, f);
        }
    }
}