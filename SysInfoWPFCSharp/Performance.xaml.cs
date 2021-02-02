using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Threading;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;

namespace SysInfo
{
    /// <summary>
    /// Interaction logic for Performance.xaml
    /// </summary>
    
    public partial class Performance : Page
    {

        public Performance()
        {
            timer.Tick += TimerTick;
            timer.Interval = System.TimeSpan.FromMilliseconds(Properties.Settings.Default.TimerInterval);
            timer.Start();
            InitializeComponent();
            TextBlock();
        }
        public DispatcherTimer timer = new DispatcherTimer();
        private void TimerTick(object sender, EventArgs e)
        {
            CpuUsage.Text = $"CPU Usage: {CurrentCpuUsage}";
            RamUsage.Text = $"RAM Usage: {AvailableRam}";
        }

        private readonly PerformanceCounter _cpuCounter =
            new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private static int GetDimmSlots {
            get {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemoryArray");
                int totalDimmSlots = 0;
                try {
                    foreach (ManagementObject queryObj in searcher.Get()) {
                        totalDimmSlots = Convert.ToInt32(queryObj["MemoryDevices"]);
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("An error occurred. Reason: " + ex.Message);
                }
                return totalDimmSlots;
            }
        }
        private static string DisplayAdapter
        {
            get
            {
                string graphicsCard = "";
                try
                {
                    ManagementObjectSearcher searcher =
                        new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
                    foreach (PropertyData property in from ManagementObject mo in searcher.Get()
                                                      from PropertyData property in mo.Properties
                                                      where property.Name == "Description"
                                                      select property)
                    {
                        graphicsCard = property.Value.ToString();
                    }
                }
                catch (ManagementException e)
                {
                    MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                }

                return graphicsCard;
            }
        }

        private static string DisplayAdapterVRAM
        {
            get
            {
                string graphicsCard = "";
                try
                {
                    ManagementObjectSearcher searcher =
                        new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
                    foreach (PropertyData property in from ManagementObject mo in searcher.Get()
                                                      from PropertyData property in mo.Properties
                                                      where property.Name == "AdapterRAM"
                                                      select property)
                    {
                        graphicsCard = (Convert.ToDouble(property.Value) / 1073741824).ToString(CultureInfo.CurrentCulture);
                    }
                }
                catch (ManagementException e)
                {
                    MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                }

                return graphicsCard;
            }
        }
        private string CurrentCpuUsage => $"{Math.Round(_cpuCounter.NextValue(), 2, MidpointRounding.AwayFromZero)}%";

        private string CpuSpeed
        {
            get
            {
                string freq = "";
                try
                {
                    ManagementObjectSearcher o = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                    foreach (PropertyData property in from ManagementObject mo in o.Get()
                                                      from PropertyData property in mo.Properties
                                                      where property.Name == "CurrentClockSpeed"
                                                      select property)
                    {
                        freq = (Convert.ToDouble(property.Value) / 1000).ToString(CultureInfo.CurrentCulture);
                    }
                }
                catch (ManagementException e)
                {
                    MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                }

                return freq;
            }
        }

        private string CpuCores
        {
            get
            {
                string core = "";
                try
                {
                    ManagementObjectSearcher o = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                    foreach (PropertyData property in from ManagementObject mo in o.Get()
                                                      from PropertyData property in mo.Properties
                                                      where property.Name == "NumberOfCores"
                                                      select property)
                    {
                        core = property.Value.ToString();
                    }
                }
                catch (ManagementException e)
                {
                    MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                }

                return core;
            }
        }

        
        private string CpuThreads
        {
            get
            {
                string thread = "";
                try
                {
                    ManagementObjectSearcher o = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                    foreach (PropertyData property in from ManagementObject mo in o.Get()
                                                      from PropertyData property in mo.Properties
                                                      where property.Name == "ThreadCount"
                                                      select property)
                    {
                        thread = property.Value.ToString();
                    }
                }
                catch (ManagementException e)
                {
                    MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                }

                return thread;
            }
        }

        private string AvailableRam {
            get {
                string av;
                Int64 phav = PerformanceInfo.GetPhysicalAvailableMemoryInMiB();
                Int64 tot = PerformanceInfo.GetTotalMemoryInMiB();
                decimal percentFree = phav / (decimal)tot * 100;
                decimal percentOccupied = 100 - percentFree;
                decimal occupied = Math.Round(percentOccupied, 2, MidpointRounding.AwayFromZero);
                av = occupied.ToString(CultureInfo.CurrentCulture) + "%";
                return av;
            }
        }

        private string GetRamFreq {
            get {
                string freq = "";
                try {
                    ManagementObjectSearcher o = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
                    foreach (PropertyData property in from ManagementObject mo in o.Get()
                                                      from PropertyData property in mo.Properties
                                                      where property.Name == "ConfiguredClockSpeed"
                                                      select property) {
                        freq = property.Value.ToString();
                    }
                }
                catch (ManagementException e)
                {
                    MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                }

                return freq;
            }
        }

        private void TextBlock() {
            string cpu = Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0",
                "ProcessorNameString", "").ToString();
            Cpu.Text = $"CPU: {cpu} ({CpuCores} cores, {CpuThreads} threads)";
            Gpu.Text = $"Display adapter: {DisplayAdapter} with {DisplayAdapterVRAM}GB of VRAM";
            CPUSpeed.Text = $"CPU Speed: {CpuSpeed}GHz";
            CpuUsage.Text = $"CPU Usage: {CurrentCpuUsage}";
            DimmSlots.Text = $"(Configured) Total DIMM slots: {GetDimmSlots}";
            RamUsage.Text = $"RAM Usage: {AvailableRam}";
            Ramfreq.Text = $"RAM Frequency: {GetRamFreq}MHz";
            Disk();
        }

        private void Disk() {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives) {
                DiskSpace.Text +=
                    $"Drive {drive.Name.Replace(@"\", "")} ({drive.VolumeLabel}) has {Math.Round((double)drive.AvailableFreeSpace / 1073741824, 2, MidpointRounding.AwayFromZero)} GB free \r\n\r\n";
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e) {
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Popup.IsOpen = true;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            switch (Slider.Value) {
                case 0:
                    timer.Interval = TimeSpan.FromMilliseconds(166);
                    Properties.Settings.Default.TimerInterval = 166;
                    Properties.Settings.Default.Save();
                    break;
                case 1:
                    timer.Interval = TimeSpan.FromMilliseconds(333);
                    Properties.Settings.Default.TimerInterval = 33;
                    Properties.Settings.Default.Save();
                    break;
                case 2:
                    timer.Interval = TimeSpan.FromMilliseconds(500);
                    Properties.Settings.Default.TimerInterval = 500;
                    Properties.Settings.Default.Save();
                    break;
                case 3:
                    timer.Interval = TimeSpan.FromMilliseconds(666);
                    Properties.Settings.Default.TimerInterval = 666;
                    Properties.Settings.Default.Save();
                    break;
                case 4:
                    timer.Interval = TimeSpan.FromMilliseconds(833);
                    Properties.Settings.Default.TimerInterval = 833;
                    Properties.Settings.Default.Save();
                    break;
                case 5:
                    timer.Interval = TimeSpan.FromMilliseconds(1000);
                    Properties.Settings.Default.TimerInterval = 1000;
                    Properties.Settings.Default.Save();
                    break;
                case 6:
                    timer.Interval = TimeSpan.FromMilliseconds(1166);
                    Properties.Settings.Default.TimerInterval = 1166;
                    Properties.Settings.Default.Save();
                    break;
                case 7:
                    timer.Interval = TimeSpan.FromMilliseconds(1333);
                    Properties.Settings.Default.TimerInterval = 1333;
                    Properties.Settings.Default.Save();
                    break;
                case 8:
                    timer.Interval = TimeSpan.FromMilliseconds(1500);
                    Properties.Settings.Default.TimerInterval = 1500;
                    Properties.Settings.Default.Save();
                    break;
                case 9:
                    timer.Interval = TimeSpan.FromMilliseconds(1666);
                    Properties.Settings.Default.TimerInterval = 1666;
                    Properties.Settings.Default.Save();
                    break;
                case 10:
                    timer.Interval = TimeSpan.FromMilliseconds(1833);
                    Properties.Settings.Default.TimerInterval = 1833;
                    Properties.Settings.Default.Save();
                    break;
            }
        }

        private void ColorChangeE(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ColorAnimation ca = new ColorAnimation(Color.FromArgb(128, 211, 211, 211),
                new Duration(TimeSpan.FromSeconds(0.4)));
            ButtonExpand.Background = new SolidColorBrush(Colors.Transparent);
            ButtonExpand.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
            Icon.Kind = PackIconKind.ArrowDownBold;
        }

        private void ColorChangeL(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ColorAnimation ca = new ColorAnimation(Colors.Transparent,
                new Duration(TimeSpan.FromSeconds(0.4)));
            ButtonExpand.Background = new SolidColorBrush(Color.FromArgb(128, 211, 211, 211));
            ButtonExpand.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
            Icon.Kind = PackIconKind.ArrowDown;
        }
    }

    public static class PerformanceInfo {
        [DllImport("psapi.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetPerformanceInfo([Out] out PerformanceInformation PerformanceInformation,
            [In] int Size);

        [StructLayout(LayoutKind.Sequential)]
        public struct PerformanceInformation {
            public int Size;
            public IntPtr CommitTotal;
            public IntPtr CommitLimit;
            public IntPtr CommitPeak;
            public IntPtr PhysicalTotal;
            public IntPtr PhysicalAvailable;
            public IntPtr SystemCache;
            public IntPtr KernelTotal;
            public IntPtr KernelPaged;
            public IntPtr KernelNonPaged;
            public IntPtr PageSize;
            public int HandlesCount;
            public int ProcessCount;
            public int ThreadCount;
        }

        public static Int64 GetPhysicalAvailableMemoryInMiB() {
            PerformanceInformation pi = new PerformanceInformation();
            if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi))) {
                return Convert.ToInt64(pi.PhysicalAvailable.ToInt64() * pi.PageSize.ToInt64() / 1048576);
            }

            return -1;

        }

        public static Int64 GetTotalMemoryInMiB() {
            PerformanceInformation pi = new PerformanceInformation();
            if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi))) {
                return Convert.ToInt64(pi.PhysicalTotal.ToInt64() * pi.PageSize.ToInt64() / 1048576);
            }

            return -1;

        }
    }
}