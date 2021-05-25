namespace SysInfo
{
    using LibreHardwareMonitor.Hardware;
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
    using static App;
    using static System.Environment;

    public partial class SystemInformation
    {
        Computer computer = new Computer
        { IsGpuEnabled = true };

        public static SystemInformation SI { get; private set; }

        static SystemInformation()
        {
            SI = new SystemInformation();
        }

        private SystemInformation()
        {
            this.InitializeComponent();
            TextBlocks();

            

            this.ReleaseId.Visibility = Environment.OSVersion.Version.Major < 10
                ? System.Windows.Visibility.Collapsed
                : System.Windows.Visibility.Visible;
        }

        private void TextBlocks()
        {
            this.computer.Open();

            #region Check operating system version

            switch (Environment.OSVersion.Version.Major)
            {
                case 10 when Environment.OSVersion.Version.Minor == 0:
                    this.Ver.Text = "Windows Version: Windows 10";
                    this.WinIcon.ToolTip = "Windows 10";
                    break;

                case 6 when Environment.OSVersion.Version.Minor == 3:
                    this.Ver.Text = "Windows Version: Windows 8.1";
                    this.WinIcon.ToolTip = "Windows 8.1";
                    break;

                case 6 when Environment.OSVersion.Version.Minor == 2:
                    this.Ver.Text = "Windows Version: Windows 8";
                    this.WinIcon.ToolTip = "Windows 8";
                    break;

                case 6 when Environment.OSVersion.Version.Minor == 1:
                    this.Ver.Text = "Windows Version: Windows 7";
                    this.WinIcon.ToolTip = "Windows 7";
                    break;

                case 6 when Environment.OSVersion.Version.Minor == 0:
                    this.Ver.Text = "Windows Version: Windows Vista";
                    this.WinIcon.ToolTip = "Windows Vista";
                    break;
            }

            #endregion Check operating system version

            #region Set textblock value

            #region General tab

            this.ReleaseId.Text =
                $"Release ID: {Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ReleaseId", "")}";
            this.Build.Text =
                $"Current Build: {Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", "")}";
            this.Edition.Text =
                $"Edition: {Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "EditionId", "")}";
            this.pcname.Text =
                $"Computer Name: {Environment.UserDomainName}";
            this.Regowner.Text =
                $"Registered Owner: {Environment.UserName}";
            this.Regorg.Text =
                $"Registered Organization: {Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "RegisteredOrganization", "")}";
            this.Buildguid.Text =
                $"Build GUID: {Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "BuildGUID", "")}";
            this.Cpu.Text = this.cpu_P.Text =
                $"CPU: {Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0", "ProcessorNameString", "")}";
            this.Ram.Text =
                $"Available Installed RAM: {Math.Round((double)new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory / 1073741824, 2, MidpointRounding.AwayFromZero)} GB";
            this.VideoAdapter.Text = DisplayAdapter.Text = $"Display Adapter: {Display.Adapter}";

            foreach (Screen t in Screen.AllScreens)
            {
                string v =
                    $"{t.Bounds.Width}x{t.Bounds.Height} at {CResolution.CRefreshRate} Hz ({t.BitsPerPixel} bits per pixel)\r";
                this.Screenres.Text += v.TrimEnd();
            }

            this.Bits.Text = Environment.Is64BitOperatingSystem
                ? "64-bit operating system"
                : "32-bit operating system";

            #endregion

            #region CPU architecture

            string arc = "";

            switch (Processor.Architecture)
            {
                case 0:
                    arc = "x86";
                    break;
                case 1:
                    arc = "MIPS";
                    break;
                case 2:
                    arc = "Alpha";
                    break;
                case 3:
                    arc = "PowerPC";
                    break;
                case 5:
                    arc = "ARM";
                    break;
                case 6:
                    arc = "IA64";
                    break;
                case 9:
                    arc = "x64";
                    break;
            }

            #endregion

            #region Processor tab
            long l1, l2, l3;
            Processor.GetPerCoreCacheSizes(out l1, out l2, out l3);

            this.identifier.Text =
                $"Identifier (codename): {Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER")}";
            this.cpuSn.Text = $"Serial Number of CPU: {Processor.SerialNumber}";
            this.cpuArchitecture.Text = $"Architecture: {arc}";
            this.cpuSpeed.Text = $"Clock Speed: {Processor.Speed}0 GHz";
            this.cpuVoltage.Text = $"Voltage: {(Single)Processor.Voltage / 10} V";
            this.cpuCacheL1.Text =
                ((l1 > 1024) ? $"L1 Cache Size: {(float)l1 / 1024} MB" : $"L1 Cache Size {l1} KB");
            this.cpuCacheL2.Text =
                ((l2 > 1024) ? $"L2 Cache Size: {(float)l2 / 1024} MB" : $"L2 Cache Size {l2} KB");
            this.cpuCacheL3.Text =
                ((l3 > 1024) ? $"L3 Cache Size: {(float)l3 / 1024} MB" : $"L3 Cache Size {l3} KB");

            #endregion

            #region Video tab

            foreach (var h in this.computer.Hardware) {
                if (h.HardwareType == HardwareType.GpuNvidia || h.HardwareType == HardwareType.GpuAmd) {
                    h.Update();
                    foreach (var sensor in h.Sensors) {
                        if (sensor.SensorType == SensorType.Voltage)
                            this.DisplayAdapterVoltage.Text = $"Voltage: {sensor.Value / 1000000.0f} V";
                        if (sensor.SensorType == SensorType.Clock)
                            this.DisplayAdapterMemClock.Text = $"GPU Memory Clock: {sensor.Value} MHz";
                        if (sensor.SensorType == SensorType.Clock)
                            this.DisplayAdapterClock.Text = $"Core Clock: {sensor.Value} MHz";
                        
                    }
                }
            }

            this.DisplayAdapterMaxRef.Text = $"Maximum Refresh Rate: {Display.GetRefreshRate("Max")} Hz";
            this.DisplayAdapterMinRef.Text = $"Minimum Refresh Rate: {Display.GetRefreshRate("Min")} Hz";

            #endregion

            #region Disk tab

            this.drivenm.Text = Drives.GetNameAndSerial();
            this.Sysroot.Text = $"Windows is installed in {Environment.SystemDirectory}";
            this.Drive.Text = Drives.GetType();


            #endregion

            #endregion
        }

        

        private void Export(object sender, System.Windows.RoutedEventArgs e)
        {
            SysInfo.MainWindow.MW.ExportFile();
        }
    }
}