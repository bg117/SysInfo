namespace System
{

    using System.Linq;
    using System.Management;


    public static class RandomAccessMemory
    {
        public static Int32 SlotCount
        {
            get
            {
                var searcher =
                    new ManagementObjectSearcher(
                        "root\\CIMV2",
                        "SELECT MemoryDevices FROM Win32_PhysicalMemoryArray")
                    ;
                int totalDimmSlots = 0;
                try
                {
                    foreach (ManagementBaseObject o in searcher.Get())
                    {
                        ManagementObject queryObj = (ManagementObject)o;
                        totalDimmSlots = Convert.ToInt32(queryObj["MemoryDevices"]);
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("An error occurred. Reason: " + ex.Message);
                }
                _ = new EnumerationOptions
                {
                    ReturnImmediately = true,
                };
                return totalDimmSlots;
            }
        }

        public static String Available
        {
            get
            {
                Int64 available = PerformanceInfo.GetPhysicalAvailableMemoryInMiB();
                Int64 tot = PerformanceInfo.GetTotalMemoryInMiB();
                Decimal percentFree = available / (Decimal)tot * 100;
                Decimal percentOccupied = 100 - percentFree;
                Decimal occupied = Math.Round(percentOccupied, 2, MidpointRounding.AwayFromZero);
                return occupied.ToString(System.Globalization.CultureInfo.CurrentCulture) + "%";
            }
        }

        public static String Frequency
        {
            get
            {
                string freq = "";
                try
                {
                    ManagementObjectSearcher o =
                        new ManagementObjectSearcher(
                            "SELECT ConfiguredClockSpeed FROM Win32_PhysicalMemory");
                    foreach (
                        PropertyData property in from ManagementObject mo in o.Get()
                                                 from PropertyData property in mo.Properties
                                                 where property.Name == "ConfiguredClockSpeed"
                                                 select property)
                    {
                        freq = property.Value.ToString();
                    }
                }
                catch (ManagementException e)
                {
                    System.Windows.MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                }
                _ = new EnumerationOptions
                {
                    ReturnImmediately = true,
                };
                return freq;
            }
        }
    }
}