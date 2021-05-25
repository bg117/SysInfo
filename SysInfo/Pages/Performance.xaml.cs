namespace SysInfo
{
    using Microsoft.VisualBasic;
    using ModernWpf;
    using ModernWpf.Controls;
    using syslib32;
    using System;
    using System.Drawing;
    using System.Management;
    using System.Text;
    using System.Windows.Forms;
    using System.Windows.Interactivity;
    using System.Xaml;
    using winapicp;
    using Xceed.Wpf.Toolkit;

    /// <summary>
    ///     Interaction logic for Performance.xaml
    /// </summary>
    public partial class Performance
    {
        private readonly System.Windows.Threading.DispatcherTimer _timer =
            new System.Windows.Threading.DispatcherTimer();

        public Performance() 
        {
            this.InitializeComponent();
            this.InitializeTextBlocks();

            Properties.Settings.Default.Upgrade();

            this._timer.Tick += this.TimerTick;
            this._timer.Start();

            this.Slider.Value = Properties.Settings.Default.SliderVal;
            this._timer.Interval = TimeSpan.FromMilliseconds(Properties.Settings.Default.TimerInterval);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            this.CpuUsage.Text = $"CPU Usage: {this.CurrentCpuUsage}";
            this.RamUsage.Text = $"RAM Usage: {RandomAccessMemory.Available}";
        }

        private void Disk()
        {
            StringBuilder strings = new StringBuilder();
            for (int i = 0; i < System.IO.DriveInfo.GetDrives().Length; i++)
            {
                strings.Append(
                    $"Drive {System.IO.DriveInfo.GetDrives()[i].Name.Replace(@"\", "")}" +
                    $" ({System.IO.DriveInfo.GetDrives()[i].VolumeLabel}) has " +
                    $"{Math.Round((double)System.IO.DriveInfo.GetDrives()[i].AvailableFreeSpace / 1073741824, 2, MidpointRounding.AwayFromZero)} " +
                    "GB free \r");
            }
            this.DiskSpace.Text = strings.ToString().TrimEnd();
        }


        private void InitializeTextBlocks()
        {

            string cpu =
                Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0",
                    "ProcessorNameString", "").ToString();
            this.Cpu.Text = $"CPU: {cpu} ({Processor.CoreCount} cores, {Processor.ThreadCount} threads)";
            this.Gpu.Text =
                $"Display adapter: {Display.Adapter} with {Display.VideoMemory}GB of VRAM";
            this.CPUSpeed.Text = $"CPU Speed: {Processor.Speed}0 GHz";
            this.CpuUsage.Text = $"CPU Usage: {this.CurrentCpuUsage}";
            this.DimmSlots.Text = $"(Configured) Total DIMM slots: {RandomAccessMemory.SlotCount}";
            this.RamUsage.Text = $"RAM Usage: {RandomAccessMemory.Available}";
            this.Ramfreq.Text = $"RAM Frequency: {RandomAccessMemory.Frequency} MHz";
            this.Disk();
        }

        private void LoadedPerformance(Object sender, System.Windows.RoutedEventArgs e) {
            
        }

        private void ChangeSliderValue(Object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e) {
            switch (this.Slider.Value)
            {
                case 0:
                    SysInfo.Properties.Settings.Default.TimerInterval = 166;
                    SysInfo.Properties.Settings.Default.SliderVal = 0;
                    Properties.Settings.Default.Save();

                    this._timer.Interval = TimeSpan.FromMilliseconds(SysInfo.Properties.Settings.Default.TimerInterval);
                    break;
                case 1:
                    SysInfo.Properties.Settings.Default.TimerInterval = 333;
                    SysInfo.Properties.Settings.Default.SliderVal = 1;
                    Properties.Settings.Default.Save();

                    this._timer.Interval = TimeSpan.FromMilliseconds(SysInfo.Properties.Settings.Default.TimerInterval);
                    break;
                case 2:
                    SysInfo.Properties.Settings.Default.TimerInterval = 500;
                    SysInfo.Properties.Settings.Default.SliderVal = 2;
                    Properties.Settings.Default.Save();

                    this._timer.Interval = TimeSpan.FromMilliseconds(SysInfo.Properties.Settings.Default.TimerInterval);
                    break;
                case 3:
                    SysInfo.Properties.Settings.Default.TimerInterval = 666;
                    SysInfo.Properties.Settings.Default.SliderVal = 3;
                    Properties.Settings.Default.Save();

                    this._timer.Interval = TimeSpan.FromMilliseconds(SysInfo.Properties.Settings.Default.TimerInterval);
                    break;
                case 4:
                    SysInfo.Properties.Settings.Default.TimerInterval = 833;
                    SysInfo.Properties.Settings.Default.SliderVal = 4;
                    Properties.Settings.Default.Save();

                    this._timer.Interval = TimeSpan.FromMilliseconds(SysInfo.Properties.Settings.Default.TimerInterval);
                    break;
                case 5:
                    SysInfo.Properties.Settings.Default.TimerInterval = 1000;
                    SysInfo.Properties.Settings.Default.SliderVal = 5;
                    Properties.Settings.Default.Save();

                    this._timer.Interval = TimeSpan.FromMilliseconds(SysInfo.Properties.Settings.Default.TimerInterval);
                    break;
                case 6:
                    SysInfo.Properties.Settings.Default.TimerInterval = 1166;
                    SysInfo.Properties.Settings.Default.SliderVal = 6;
                    Properties.Settings.Default.Save();

                    this._timer.Interval = TimeSpan.FromMilliseconds(SysInfo.Properties.Settings.Default.TimerInterval);
                    break;
                case 7:
                    SysInfo.Properties.Settings.Default.TimerInterval = 1333;
                    SysInfo.Properties.Settings.Default.SliderVal = 7;
                    Properties.Settings.Default.Save();

                    this._timer.Interval = TimeSpan.FromMilliseconds(SysInfo.Properties.Settings.Default.TimerInterval);
                    break;
                case 8:
                    SysInfo.Properties.Settings.Default.TimerInterval = 1500;
                    SysInfo.Properties.Settings.Default.SliderVal = 8;
                    Properties.Settings.Default.Save();

                    this._timer.Interval = TimeSpan.FromMilliseconds(SysInfo.Properties.Settings.Default.TimerInterval);
                    break;
                case 9:
                    SysInfo.Properties.Settings.Default.TimerInterval = 1666;
                    SysInfo.Properties.Settings.Default.SliderVal = 9;
                    Properties.Settings.Default.Save();

                    this._timer.Interval = TimeSpan.FromMilliseconds(SysInfo.Properties.Settings.Default.TimerInterval);
                    break;
                case 10:
                    SysInfo.Properties.Settings.Default.TimerInterval = 1833;
                    SysInfo.Properties.Settings.Default.SliderVal = 10;
                    Properties.Settings.Default.Save();

                    this._timer.Interval = TimeSpan.FromMilliseconds(SysInfo.Properties.Settings.Default.TimerInterval);
                    break;
                
            }
        }
    }
}