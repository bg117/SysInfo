using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Management;
using System.Windows;

namespace SysInfo
{
    public partial class SystemInformation
    {
        public SystemInformation()
        {
            InitializeComponent();
            TextBlocks();
            ReleaseId.Visibility = Environment.OSVersion.Version.Major < 10 ? Visibility.Collapsed : Visibility.Visible;
        }

        private void GetMediaType() {
            DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo drive in drives){
                    Drive.Text +=
                        $@"Drive {drive.Name.Replace(@"\", "")} is {DriveType.HasNominalMediaRotationRate()}
";
                }
        }
        private static string DisplayAdapter
        {
            get
            {
                string graphicsCard = "";
                try
                {
                    using (ManagementObjectSearcher searcher
                        = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController"))
                    {
                        foreach (PropertyData property in from ManagementObject mo in searcher.Get()
                                                          from PropertyData property in mo.Properties
                                                          where property.Name == "Description"
                                                          select property)
                        {
                            graphicsCard = property.Value.ToString();
                        }
                    }
                }
                catch (ManagementException e)
                {
                    MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                }
                return graphicsCard;
            }
        }

        private void TextBlocks()
        {
            #region Check operating system version

            switch (Environment.OSVersion.Version.Major)
            {
                case 10 when Environment.OSVersion.Version.Minor == 0:
                    Ver.Text = "Windows Version: Windows 10";
                    break;

                case 6 when Environment.OSVersion.Version.Minor == 3:
                    Ver.Text = "Windows Version: Windows 8.1";
                    break;

                case 6 when Environment.OSVersion.Version.Minor == 2:
                    Ver.Text = "Windows Version: Windows 8";
                    break;

                case 6 when Environment.OSVersion.Version.Minor == 1:
                    Ver.Text = "Windows Version: Windows 7";
                    break;

                case 6 when Environment.OSVersion.Version.Minor == 0:
                    Ver.Text = "Windows Version: Windows Vista";
                    break;
            }

            #endregion Check operating system version

            #region Set textblock value

            ReleaseId.Text =
                $"Release ID: {Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ReleaseId", "")}";
            Build.Text =
                $"Current Build: {Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", "")}";
            Edition.Text =
                $"Edition: {Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "EditionId", "")}";
            Regowner.Text =
                $"Registered Owner: {Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "RegisteredOwner", "")}";
            Regorg.Text =
                $"Registered Organization: {Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "RegisteredOrganization", "")}";
            Buildguid.Text =
                $"Build GUID: {Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "BuildGUID", "")}";
            Cpu.Text =
                $"CPU: {Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0", "ProcessorNameString", "")}";
            Ram.Text =
                $"Available Installed RAM: {Math.Round((double)new ComputerInfo().TotalPhysicalMemory / 1073741824, 2, MidpointRounding.AwayFromZero)} GB";
            Displayadapter.Text = $"Display adapter: {DisplayAdapter}";
            Sysroot.Text = $"Windows is installed in {Environment.GetEnvironmentVariable("SystemRoot")}";
            Screenres.Text =
                $"Screen Resolution: {SystemParameters.PrimaryScreenWidth}x{SystemParameters.PrimaryScreenHeight}";
            GetMediaType();
            #endregion Set textblock value
        }
    }
}