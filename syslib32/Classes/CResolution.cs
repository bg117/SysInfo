namespace syslib32
{
    using System;
    using System.Linq;
    using System.Management;
    using System.Windows.Forms;

    public class CResolution
    {
        public static int CRefreshRate
        {
            get
            {
                string freq = "";
                try
                {
                    ManagementObjectSearcher o =
                        new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
                    foreach (
                        PropertyData property in from ManagementObject mo in o.Get()
                                                 from PropertyData property in mo.Properties
                                                 where property.Name == "CurrentRefreshRate"
                                                 select property)
                    {
                        freq = property.Value.ToString();
                    }
                }
                catch (ManagementException e)
                {
                    MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                }

                return Convert.ToInt32(freq);
            }
        }


        public static void ChangeRes(int a, int b)
        {
            int iWidth = a;
            int iHeight = b;
            DEVMODE dm = new DEVMODE
            {
                dmDeviceName = new string(new char[32]),
                dmFormName = new string(new char[32]),
            };
            dm.dmSize = (ushort)System.Runtime.InteropServices.Marshal.SizeOf(dm);
            if (User32.EnumDisplaySettings(null, User32.ENUM_CURRENT_SETTINGS, ref dm) == 0) return;
            dm.dmPelsWidth = (uint)iWidth;
            dm.dmPelsHeight = (uint)iHeight;
            dm.dmBitsPerPel = (uint)Screen.PrimaryScreen.BitsPerPixel;
            dm.dmDisplayFrequency = (uint)CResolution.CRefreshRate;
            int iRet = User32.ChangeDisplaySettings(ref dm, User32.CDS_TEST);
            if (iRet != User32.DISP_CHANGE_FAILED)
            {
                iRet = User32.ChangeDisplaySettings(ref dm, User32.CDS_UPDATEREGISTRY);
                switch (iRet)
                {
                    case User32.DISP_CHANGE_SUCCESSFUL:
                        {
                            MessageBox.Show("Resolution changed successfully.", "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            break;
                        }
                    case User32.DISP_CHANGE_RESTART:
                        {
                            MessageBox.Show(
                                "You need to restart for the changes to apply.\nIf there are problems after restarting, try to change resolution in Safe Mode.",
                                "Alert", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            break;
                        }
                    default:
                        {
                            MessageBox.Show(
                                "Failed to change the resolution. Your resolution may be too high.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                }
            }
            else
            {
                MessageBox.Show(
                    "Failed to change the resolution. The resolution may be too high.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void ChangeRes(int a, int b, int frequency)
        {
            int iWidth = a;
            int iHeight = b;
            int freq = frequency;
            DEVMODE dm = new DEVMODE
            {
                dmDeviceName = new string(new char[32]),
                dmFormName = new string(new char[32]),
            };
            dm.dmSize = (ushort)System.Runtime.InteropServices.Marshal.SizeOf(dm);
            if (User32.EnumDisplaySettings(null, User32.ENUM_CURRENT_SETTINGS, ref dm) != 0)
            {
                dm.dmPelsWidth = (uint)iWidth;
                dm.dmPelsHeight = (uint)iHeight;
                dm.dmBitsPerPel = (uint)Screen.PrimaryScreen.BitsPerPixel;
                dm.dmDisplayFrequency = (uint)freq;
                int iRet = User32.ChangeDisplaySettings(ref dm, User32.CDS_TEST);
                if (iRet == User32.DISP_CHANGE_FAILED)
                {
                    MessageBox.Show(
                        "Failed to change the resolution. Your resolution/refresh rate (or both) may be too high.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    iRet = User32.ChangeDisplaySettings(ref dm, User32.CDS_UPDATEREGISTRY);
                    switch (iRet)
                    {
                        case User32.DISP_CHANGE_SUCCESSFUL:
                            {
                                MessageBox.Show("Resolution changed successfully.", "Success",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                break;
                            }
                        case User32.DISP_CHANGE_RESTART:
                            {
                                MessageBox.Show(
                                    "You need to restart for the changes to apply.\nIf there are problems after restarting, try to change resolution in Safe Mode.",
                                    "Alert", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                break;
                            }
                        default:
                            {
                                MessageBox.Show(
                                    "Failed to change the resolution. Your resolution/refresh rate (or both) may be too high.",
                                    "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                break;
                            }
                    }
                }
            }
        }

        public static void ChangeRes(uint a, uint b, uint frequency, uint bitsperpel)
        {
            uint iWidth = a;
            uint iHeight = b;
            uint freq = frequency;
            uint bits = bitsperpel;
            DEVMODE dm = new DEVMODE
            {
                dmDeviceName = new string(new char[32]),
                dmFormName = new string(new char[32]),
            };
            dm.dmSize = (ushort)System.Runtime.InteropServices.Marshal.SizeOf(dm);
            if (User32.EnumDisplaySettings(null, User32.ENUM_CURRENT_SETTINGS, ref dm) != 0)
            {
                dm.dmPelsWidth = iWidth;
                dm.dmPelsHeight = iHeight;
                dm.dmBitsPerPel = bits;
                dm.dmDisplayFrequency = freq;
                int iRet = User32.ChangeDisplaySettings(ref dm, User32.CDS_TEST);
                if (iRet == User32.DISP_CHANGE_FAILED)
                {
                    MessageBox.Show(
                        "Failed to change the resolution. Your resolution/refresh rate (or both) may be too high, or the color depth is not supported.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    iRet = User32.ChangeDisplaySettings(ref dm, User32.CDS_UPDATEREGISTRY);
                    switch (iRet)
                    {
                        case User32.DISP_CHANGE_SUCCESSFUL:
                            {
                                MessageBox.Show("Resolution changed successfully.", "Success",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                break;
                            }
                        case User32.DISP_CHANGE_RESTART:
                            {
                                MessageBox.Show(
                                    "You need to restart for the changes to apply.\nIf there are problems after restarting, try to change resolution in Safe Mode.",
                                    "Alert", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                break;
                            }
                        default:
                            {
                                MessageBox.Show(
                                    "Failed to change the resolution. Your resolution/refresh rate (or both) may be too high, or the bits per pixel is not supported.",
                                    "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                break;
                            }
                    }
                }
            }
        }
    }
}