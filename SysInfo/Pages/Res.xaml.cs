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

    public partial class Res
    {
        public Res()
        {
            this.InitializeComponent();
            GetSetResolution.SaveData();
            this.ListDisplaySettings();
            this.ResBox.Mask = "0000 x 0000";
            this.BitsPerPel.Value = Screen.PrimaryScreen.BitsPerPixel;
            this.HzControl.Value = CResolution.CRefreshRate;
        }

        public System.Windows.Input.ICommand ApplyResCommand { get; set; }

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll"),]
        private static extern Boolean EnumDisplaySettingsA(string lpszDeviceName, int iModeNum,
            ref DEVMODE lpDevMode);

        private void ListDisplaySettings()
        {
            DEVMODE vDevMode = new DEVMODE();
            int i = 0;
            while (EnumDisplaySettingsA(null!, i, ref vDevMode))
            {
                ListViewR.Items.Add(new ResItems
                {
                    Resolution = vDevMode.dmPelsWidth + "x" + vDevMode.dmPelsHeight,
                    RefreshRate = vDevMode.dmDisplayFrequency + " Hz",
                    ColorMode = Screen.PrimaryScreen.BitsPerPixel + "bpp",
                });
                i++;
            }
        }

        private async void Apply()
        {
            string txt = this.ResBox.Text;
            int bpp = (int)this.BitsPerPel.Value;
            string[] partsOfText = txt.Split('x');
            try
            {
                int resHeight = int.Parse(partsOfText[1]);
                int resWidth = int.Parse(partsOfText[0]);
                int hz = int.Parse(this.HzControl.Text.Trim());
                CResolution cResolution = new CResolution();
                ContentDialog cd = new ContentDialog
                {
                    Title = "Apply a custom resolution?",
                    Content =
                        $"You are about to apply a custom resolution of {resWidth}x{resHeight} with a refresh rate of {hz}hz and a color depth of {bpp}bpp. Is this correct?",
                    PrimaryButtonText = "Yes",
                    CloseButtonText = "No",
                };
                ContentDialog cd2 = new ContentDialog
                {
                    Title = "Apply a custom resolution?",
                    Content = $"You are about to apply a custom resolution of {resWidth}x{resHeight}. Is this correct?",
                    PrimaryButtonText = "Yes",
                    CloseButtonText = "No",
                };
                winapicp.Dialogs.TaskDialogs.TaskDialog td = new winapicp.Dialogs.TaskDialogs.TaskDialog
                {
                    InstructionText = "Apply a custom resolution?",
                    Text =
                        $"You are about to apply a custom resolution of {resWidth}x{resHeight} with a refresh rate of {hz}hz and a color depth of {bpp}bpp. Is this correct?",
                    Caption = "Custom resolution",
                    Icon = winapicp.Dialogs.TaskDialogs.TaskDialogStandardIcon.Warning,
                    StandardButtons =
                        winapicp.Dialogs.TaskDialogs.TaskDialogStandardButtons.Yes |
                        winapicp.Dialogs.TaskDialogs.TaskDialogStandardButtons.No,
                };
                winapicp.Dialogs.TaskDialogs.TaskDialog td2 = new winapicp.Dialogs.TaskDialogs.TaskDialog
                {
                    InstructionText = "Apply a custom resolution?",
                    Text =
                        $"You are about to apply a custom resolution of {resWidth}x{resHeight}. Is this correct?",
                    Caption = "Custom resolution",
                    Icon = winapicp.Dialogs.TaskDialogs.TaskDialogStandardIcon.Warning,
                    StandardButtons =
                        winapicp.Dialogs.TaskDialogs.TaskDialogStandardButtons.Yes |
                        winapicp.Dialogs.TaskDialogs.TaskDialogStandardButtons.No,
                };
                switch (this.C.IsChecked)
                {
                    case true:
                        {
                            ContentDialogResult d =
                                await cd.ShowAsync();
                            if (d != ContentDialogResult.Primary)
                            {
                                break;
                            }

                            CResolution.ChangeRes((uint)resWidth, (uint)resHeight,
                                (uint)hz, (uint)bpp);
                        }
                        break;

                    default:
                        {
                            ContentDialogResult d = await cd2.ShowAsync();
                            if (d != ContentDialogResult.Primary)
                            {
                                break;
                            }
                            CResolution.ChangeRes(resWidth, resHeight);
                            this.HzControl.Value = CResolution.CRefreshRate;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show($"Invalid and/or blank resolution! {e.Message}", "Error",
                    System.Windows.MessageBoxButton.OK,
                    System.Windows.MessageBoxImage.Error);
            }
            finally
            {
                this.ResBox.Text = "";
            }
        }

        private void CallRes(Object sender, EventArgs e)
        {
            this.Apply();
        }

        private void GetResolution()
        {
            if (this.ListViewR.SelectedItems.Count <= 0) return;
            var SelectedResItems = (ResItems)this.ListViewR.SelectedItem;
            string s = SelectedResItems.Resolution + "@" + SelectedResItems.RefreshRate + SelectedResItems.ColorMode;
            string[] v = s.Split(new[] { "x", "@", "Hz", "bpp", }, StringSplitOptions.RemoveEmptyEntries);
            uint q = uint.Parse(v[0]);
            uint b = uint.Parse(v[1]);
            uint z = uint.Parse(v[2]);
            uint f = uint.Parse(v[3]);
            CResolution.ChangeRes(q, b, z, f);
            this.HzControl.Value = CResolution.CRefreshRate;
        }

        private void ClickApply(Object sender, System.Windows.RoutedEventArgs e)
        {
            this.GetResolution();
        }

        private void ListViewR_MouseDoubleClick(Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var SelectedResItems = (ResItems)this.ListViewR.SelectedItem;
            string s = SelectedResItems.Resolution + "@" + SelectedResItems.RefreshRate + SelectedResItems.ColorMode;
            string[] v = s.Split(new[] { "x", "@", "Hz", "bpp", }, StringSplitOptions.RemoveEmptyEntries);
            uint q = uint.Parse(v[0]);
            uint b = uint.Parse(v[1]);
            uint z = uint.Parse(v[2]);
            uint f = uint.Parse(v[3]);
            CResolution.ChangeRes(q, b, z, f);
            this.HzControl.Value = CResolution.CRefreshRate;
        }

        private void DisableEnableHzControl(Object sender, System.Windows.RoutedEventArgs e)
        {
            winapicp.Dialogs.TaskDialogs.TaskDialog warningDialog = new winapicp.Dialogs.TaskDialogs.TaskDialog
            {
                Caption = "Alert",
                Text =
                    "Warning: We are not responsible for any damage caused by this tool to your computer! Use carefully.",
                InstructionText = "Alert",
                FooterCheckBoxText = "Don't show again",
                DetailsExpandedText =
                    "You are trying to change the refresh rate and/or color mode. This may cause damage to your computer.",
                Icon = winapicp.Dialogs.TaskDialogs.TaskDialogStandardIcon.Information,
                FooterIcon = winapicp.Dialogs.TaskDialogs.TaskDialogStandardIcon.Warning,
            };
            switch (this.C.IsChecked)
            {
                case true:
                    {
                        if (SysInfo.Properties.Settings.Default.ShowWarning)
                        {
                            warningDialog.Show();
                            if (warningDialog.FooterCheckBoxChecked == true)
                            {
                                SysInfo.Properties.Settings.Default.ShowWarning = false;
                                SysInfo.Properties.Settings.Default.Save();
                            }
                        }
                        this.HzControl.IsEnabled = true;
                        this.BitsPerPel.IsEnabled = true;
                        break;
                    }
                default:
                    this.HzControl.IsEnabled = false;
                    this.BitsPerPel.IsEnabled = false;
                    break;
            }
        }

        private void RevertRes(Object sender, System.Windows.RoutedEventArgs e)
        {
            GetSetResolution.LoadData();
            this.HzControl.Value = CResolution.CRefreshRate;
        }
    }
}