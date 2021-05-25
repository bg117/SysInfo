using System;
using System.Management;
using System.Text;

namespace System
{
    public static class Drives
    {
        private class Properties
        {
            private string model = null;
            private string type = null;
            private string serialNo = null;
            public string Model
            {
                get { return model; }
                set { model = value; }
            }
            public string Type
            {
                get { return type; }
                set { type = value; }
            }
            public string SerialNo
            {
                get { return serialNo; }
                set { serialNo = value; }

            }
        }

        new public static string GetType()
        {
            var drives = IO.DriveInfo.GetDrives();
            System.Text.StringBuilder driveType = new System.Text.StringBuilder();
            try
            {
                var scope =
                    new ManagementScope(
                        @"root\microsoft\windows\storage")
                    ;
                var searcher =
                    new ManagementObjectSearcher(
                        "SELECT SpindleSpeed FROM MSFT_PhysicalDisk")
                    ;
                scope.Connect();
                int i = 0;
                searcher.Scope = scope;
                {
                    foreach (ManagementBaseObject queryObj in searcher.Get())
                    {
                        driveType.Append(Convert.ToString(queryObj["SpindleSpeed"]).Length <= 1
                            ? $"Drive {drives[i].Name.Replace("\\", "")} ({drives[i].VolumeLabel}) is an SSD\r"
                            : $"Drive {drives[i].Name.Replace("\\", "")} ({drives[i].VolumeLabel}) is an HDD/unknown\r");

                        ++i;
                    }
                    searcher.Dispose();
                }
            }
            catch (ManagementException e)
            {
                Windows.MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }
            return driveType.ToString().TrimEnd('\n', '\r');
        }
        public static string GetNameAndSerial()
        {
            StringBuilder sn = new StringBuilder();
            try
            {
                var scope =
                    new ManagementScope(
                        @"root\CIMV2")
                    ;
                var searcher =
                   new ManagementObjectSearcher(
                        "SELECT SerialNumber FROM Win32_PhysicalMedia")
                    ;
                var searcher2 =
                   new ManagementObjectSearcher(
                        "SELECT Model FROM Win32_DiskDrive")
                    ;
                scope.Connect();

                searcher.Scope = scope;
                searcher2.Scope = scope;

                using (var e1 = searcher.Get().GetEnumerator())
                using (var e2 = searcher2.Get().GetEnumerator())
                {
                    while (e1.MoveNext() && e2.MoveNext())
                    {
                        var queryobjd = e1.Current;
                        var queryobjw = e2.Current;

                        sn.Append($"Serial Number of disk '" +
                            $"{((queryobjw["Model"] != null || (string)queryobjw["Model"] != string.Empty) ? queryobjw["Model"].ToString().TrimStart('\n', '\t', '\r', ' ').TrimEnd('\n', '\t', '\r', ' ') : "unidentified")}" +
                            $"' is {((queryobjd["SerialNumber"] != null || (string)queryobjd["SerialNumber"] != string.Empty) ? queryobjd["SerialNumber"].ToString().TrimStart('\t', '\n', '\r', ' ').TrimEnd('\n', '\t', '\r', ' ') : "not available")}\r");
                    }
                }

                searcher.Dispose();
                searcher2.Dispose();

            }
            catch (ManagementException e)
            {
                Windows.MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }
            return sn.ToString().TrimEnd('\n', '\r');
        }
    }
}
