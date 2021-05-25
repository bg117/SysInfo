using System.Linq;
using System.Management;

namespace System
{
    
    public static partial class Processor
    {
        public static string Speed
        {
            get
            {
                
                string freq = "";
                try
                {
                    ManagementObjectSearcher o =
                        new ManagementObjectSearcher(
                            "SELECT CurrentClockSpeed FROM Win32_Processor");
                    foreach (
                        PropertyData property in from ManagementObject mo in o.Get()
                                                 from PropertyData property in mo.Properties
                                                 where property.Name == "CurrentClockSpeed"
                                                 select property)
                    {
                        freq =
                            (Convert.ToDouble(property.Value) / 1000).ToString();
                    }
                }
                catch (ManagementException e)
                {
                    Windows.MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                }
                _ = new EnumerationOptions
                {
                    ReturnImmediately = true,
                };
                return freq;
            }
        }

        public static ushort Voltage
        {
            get
            {
                ushort voltage = 0;
                try
                {
                    ManagementObjectSearcher o =
                        new ManagementObjectSearcher(
                            "SELECT CurrentVoltage FROM Win32_Processor");
                    foreach (
                        PropertyData property in from ManagementObject mo in o.Get()
                                                 from PropertyData property in mo.Properties
                                                 where property.Name == "CurrentVoltage"
                                                 select property)
                    {
                        voltage =
                            (ushort)property.Value;
                    }
                }
                catch (ManagementException e)
                {
                    Windows.MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                }
                _ = new EnumerationOptions
                {
                    ReturnImmediately = true,
                };
                return voltage;
            }
        }

        public static string CoreCount
        {
            get
            {
                string core = "";
                try
                {
                    ManagementObjectSearcher o =
                        new ManagementObjectSearcher(
                            "SELECT NumberOfCores FROM Win32_Processor");
                    foreach (
                        PropertyData property in from ManagementObject mo in o.Get()
                                                 from PropertyData property in mo.Properties
                                                 where property.Name == "NumberOfCores"
                                                 select property)
                    {
                        core = property.Value.ToString();
                    }
                }
                catch (ManagementException e)
                {
                    Windows.MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                }
                _ = new EnumerationOptions
                {
                    ReturnImmediately = true,
                };
                return core;
            }
        }

        public static string ThreadCount
        {
            get
            {
                string thread = "";
                try
                {
                    ManagementObjectSearcher o =
                        new ManagementObjectSearcher(
                            "SELECT ThreadCount FROM Win32_Processor");
                    foreach (
                        PropertyData property in from ManagementObject mo in o.Get()
                                                 from PropertyData property in mo.Properties
                                                 where property.Name == "ThreadCount"
                                                 select property)
                    {
                        thread = property.Value.ToString();
                    }
                }
                catch (ManagementException e)
                {
                    Windows.MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                }
                _ = new EnumerationOptions
                {
                    ReturnImmediately = true,
                };
                return thread;
            }
        }

        public static string SerialNumber
        {
            get
            {
                string serial = "";

                try
                {
                    ManagementObjectSearcher o =
                        new ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor");
                    foreach (PropertyData p in
                        from ManagementObject m in o.Get()
                        from PropertyData p in m.Properties
                        where p.Name == "ProcessorId"
                        select p)
                    {
                        serial = p.Value.ToString();
                    }
                }
                catch (ManagementException) { }
                return serial;
            }
        }

        public static ushort Architecture
        {
            get
            {
                ushort a = 0;

                try
                {
                    ManagementObjectSearcher o =
                        new ManagementObjectSearcher("SELECT Architecture FROM Win32_Processor");
                    foreach (PropertyData p in
                        from ManagementObject m in o.Get()
                        from PropertyData p in m.Properties
                        where p.Name == "Architecture"
                        select p)
                    {
                        a = (ushort)p.Value;
                    }
                }
                catch (ManagementException) { }
                return a;
            }
        }

        public static void GetPerCoreCacheSizes(out long L1, out long L2, out long L3)
        {
            L1 = 0;
            L2 = 0;
            L3 = 0;

            var info = LogicalProcessorInformation;
            foreach (var entry in info)
            {
                if (entry.Relationship != LOGICAL_PROCESSOR_RELATIONSHIP.RelationCache)
                    continue;
                long mask = (long)entry.ProcessorMask;
                if ((mask & 1) == 0)
                    continue;
                var cache = entry.ProcessorInformation.Cache;
                switch (cache.Level)
                {
                    case 1: L1 += cache.Size / 1024 * 4; break;
                    case 2: L2 += cache.Size / 1024 * 4; break;
                    case 3: L3 += cache.Size / 1024; break;
                    default:
                        break;
                }
            }
        }
    }
}