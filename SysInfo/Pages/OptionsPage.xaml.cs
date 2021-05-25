using ModernWpf;
using ModernWpf.Controls;

namespace SysInfo
{


    /// <summary>
    ///     Interaction logic for OptionsWindow.xaml
    /// </summary>
    public partial class OptionsPage
    {
        public OptionsPage()
        {
            this.InitializeComponent();
            if (SysInfo.Properties.Settings.Default.AppTheme == ApplicationTheme.Dark)
                this.DarkSwitch.IsOn = true;
            else
                this.DarkSwitch.IsOn = false;

            IsSystemTheme.IsChecked = SysInfo.Properties.Settings.Default.SystemThemeIsOn;
            this.TransparencySwitch.IsOn = SysInfo.Properties.Settings.Default.TransparencySwitchIsOn;

            if (!TransparencySwitch.IsOn)
            {
                SysInfo.MainWindow.MW.TintOpacity = 1.0;
            }

            else
            {
                SysInfo.MainWindow.MW.TintOpacity = 0.6;
            }



            if ((bool)IsSystemTheme.IsChecked)
            {
                this.DarkSwitch.IsEnabled = false;
                ModernWpf.ThemeManager.Current.ApplicationTheme = null;
                SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme = SourceChord.FluentWPF.ElementTheme.Default;
            }

            else
            {

                this.DarkSwitch.IsEnabled = true;
                ModernWpf.ThemeManager.Current.ApplicationTheme = SysInfo.Properties.Settings.Default.AppTheme;
                SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme = SysInfo.Properties.Settings.Default.AppThemeFluent;
            }
        }

        private void UseDarkMode(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DarkSwitch.IsOn)
            {
                SysInfo.Properties.Settings.Default.AppTheme = ApplicationTheme.Dark;
                SysInfo.Properties.Settings.Default.AppThemeFluent = SourceChord.FluentWPF.ElementTheme.Dark;
                SysInfo.Properties.Settings.Default.Save();
                ModernWpf.ThemeManager.Current.ApplicationTheme = SysInfo.Properties.Settings.Default.AppTheme;
                SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme = SysInfo.Properties.Settings.Default.AppThemeFluent;
            }

            else
            {
                SysInfo.Properties.Settings.Default.AppTheme = ApplicationTheme.Light;
                SysInfo.Properties.Settings.Default.AppThemeFluent = SourceChord.FluentWPF.ElementTheme.Light;
                SysInfo.Properties.Settings.Default.Save();
                ModernWpf.ThemeManager.Current.ApplicationTheme = SysInfo.Properties.Settings.Default.AppTheme;
                SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme = SysInfo.Properties.Settings.Default.AppThemeFluent;
            }
        }

        private void UseSystem(object sender, System.Windows.RoutedEventArgs e)
        {
            if ((bool)this.IsSystemTheme.IsChecked)
            {

                this.DarkSwitch.IsEnabled = false;
                ModernWpf.ThemeManager.Current.ApplicationTheme = null;
                SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme = null;
                SysInfo.Properties.Settings.Default.SystemThemeIsOn = true;
                SysInfo.Properties.Settings.Default.Save();
            }

            else
            {
                this.DarkSwitch.IsEnabled = true;
                ModernWpf.ThemeManager.Current.ApplicationTheme = this.DarkSwitch.IsOn
                ? ApplicationTheme.Dark
                : ApplicationTheme.Light;
                SourceChord.FluentWPF.ResourceDictionaryEx.GlobalTheme = this.DarkSwitch.IsOn
                ? SourceChord.FluentWPF.ElementTheme.Dark
                : SourceChord.FluentWPF.ElementTheme.Light;
                SysInfo.Properties.Settings.Default.SystemThemeIsOn = false;
                SysInfo.Properties.Settings.Default.Save();
            }
        }

        private void ToggleTransparency(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!this.TransparencySwitch.IsOn)
            {
                SysInfo.MainWindow.MW.TintOpacity = 1.0;
                SysInfo.Properties.Settings.Default.TransparencySwitchIsOn = false;
                SysInfo.Properties.Settings.Default.Save();
            }

            else
            {
                SysInfo.MainWindow.MW.TintOpacity = 0.6;
                SysInfo.Properties.Settings.Default.TransparencySwitchIsOn = true;
                SysInfo.Properties.Settings.Default.Save();
            }
        }
    }
}