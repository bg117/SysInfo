using System.Linq;
using System.Management;

namespace System
{
    public static class Display
    {
        public static String Adapter
        {
            get
            {
                string graphicsCard = "";
                try
                {
                    ManagementObjectSearcher searcher =
                        new ManagementObjectSearcher(
                            "SELECT Description FROM Win32_VideoController")
                        ;
                    foreach (
                        PropertyData property in
                            from ManagementObject mo in searcher.Get()
                            from PropertyData property in mo.Properties
                            where property.Name == "Description"
                            select property)
                    {
                        graphicsCard = property.Value.ToString();
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
                return graphicsCard;
            }
        }

        public static String VideoMemory
        {
            get
            {
                string graphicsCard = "";
                try
                {
                    ManagementObjectSearcher searcher =
                        new ManagementObjectSearcher(
                            "SELECT AdapterRAM FROM Win32_VideoController")
                        ;
                    foreach (
                        PropertyData property in
                            from ManagementObject mo in searcher.Get()
                            from PropertyData property in mo.Properties
                            where property.Name == "AdapterRAM"
                            select property)
                    {
                        graphicsCard =
                            (Convert.ToDouble(property.Value) / 1073741824).ToString(
                                System.Globalization.CultureInfo.CurrentCulture);
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
                return graphicsCard;
            }
        }
        /// <summary>
        /// Gets refresh rate (current, minimum, or maximum).
        /// </summary>
        /// <param name="_Option">Specifies what kind of refresh rate to find. Valid options: "Min", "Max", "Current"</param>
        /// <returns></returns>
        public static String GetRefreshRate(string _Option)
        {
            string graphicsCard = "";
            try
            {
                ManagementObjectSearcher searcher =
                   new ManagementObjectSearcher("root\\CIMV2",
                   "SELECT * FROM Win32_VideoController");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    if (_Option == "Min")
                        graphicsCard = queryObj["MinRefreshRate"].ToString();
                    else if (_Option == "Max")
                        graphicsCard = queryObj["MaxRefreshRate"].ToString();
                    else if (_Option == "Current")
                        graphicsCard = queryObj["CurrentRefreshRate"].ToString();
                    else
                        Windows.MessageBox.Show(_Option + " is not a valid option! Valid options are: Min, Max, Current", "Invalid option", Windows.MessageBoxButton.OK, Windows.MessageBoxImage.Error);
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
            return graphicsCard;
        }
    }
}