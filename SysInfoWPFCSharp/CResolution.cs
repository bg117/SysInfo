using System;
using System.Linq;
using System.Management;
using System.Windows;
using System.Windows.Forms;
using static SysInfo.User32;
using static System.Runtime.InteropServices.Marshal;
using static System.Windows.MessageBox;

namespace SysInfo
{
    internal class CResolution
    {
        public static int CRefreshRate
        {
            get
            {
                string freq = "";
                try
                {
                    ManagementObjectSearcher o = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
                    foreach (PropertyData property in from ManagementObject mo in o.Get()
                                                      from PropertyData property in mo.Properties
                                                      where property.Name == "CurrentRefreshRate"
                                                      select property)
                    {
                        freq = property.Value.ToString();
                    }
                }
                catch (ManagementException e)
                {
                    Show("An error occurred while querying for WMI data: " + e.Message);
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
                dmFormName = new string(new char[32])
            };
            dm.dmSize = (ushort)SizeOf(dm);
            if (0 != EnumDisplaySettings(null, ENUM_CURRENT_SETTINGS, ref dm))
            {
                dm.dmPelsWidth = (uint)iWidth;
                dm.dmPelsHeight = (uint)iHeight;
                dm.dmBitsPerPel = (uint)Screen.PrimaryScreen.BitsPerPixel;
                dm.dmDisplayFrequency = (uint)CRefreshRate;
                int iRet = ChangeDisplaySettings(ref dm, CDS_TEST);
                if (iRet == DISP_CHANGE_FAILED)
                {
                    Show("Failed to change the resolution. The resolution may be too high.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    iRet = ChangeDisplaySettings(ref dm, CDS_UPDATEREGISTRY);
                    switch (iRet)
                    {
                        case DISP_CHANGE_SUCCESSFUL:
                            {
                                Show("Resolution changed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                                break;
                            }
                        case DISP_CHANGE_RESTART:
                            {
                                Show("You need to restart for the changes to apply.\nIf there are problems after restarting, try to change resolution in Safe Mode.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                                break;
                            }
                        default:
                            {
                                Show("Failed to change the resolution. Your resolution may be too high.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                    }
                }
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
                dmFormName = new string(new char[32])
            };
            dm.dmSize = (ushort)SizeOf(dm);
            if (0 != EnumDisplaySettings(null, ENUM_CURRENT_SETTINGS, ref dm))
            {
                dm.dmPelsWidth = (uint)iWidth;
                dm.dmPelsHeight = (uint)iHeight;
                dm.dmBitsPerPel = (uint)Screen.PrimaryScreen.BitsPerPixel;
                dm.dmDisplayFrequency = (uint)freq;
                int iRet = ChangeDisplaySettings(ref dm, CDS_TEST);
                if (iRet == DISP_CHANGE_FAILED)
                {
                    Show("Failed to change the resolution. Your resolution/refresh rate (or both) may be too high.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    iRet = ChangeDisplaySettings(ref dm, CDS_UPDATEREGISTRY);
                    switch (iRet)
                    {
                        case DISP_CHANGE_SUCCESSFUL:
                            {
                                Show("Resolution changed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                                break;
                            }
                        case DISP_CHANGE_RESTART:
                            {
                                Show("You need to restart for the changes to apply.\nIf there are problems after restarting, try to change resolution in Safe Mode.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                                break;
                            }
                        default:
                            {
                                Show("Failed to change the resolution. Your resolution/refresh rate (or both) may be too high.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                dmFormName = new string(new char[32])
            };
            dm.dmSize = (ushort)SizeOf(dm);
            if (0 != User32.EnumDisplaySettings(null, ENUM_CURRENT_SETTINGS, ref dm))
            {
                dm.dmPelsWidth = iWidth;
                dm.dmPelsHeight = iHeight;
                dm.dmBitsPerPel = bits;
                dm.dmDisplayFrequency = freq;
                int iRet = ChangeDisplaySettings(ref dm, CDS_TEST);
                if (iRet == DISP_CHANGE_FAILED)
                {
                    Show("Failed to change the resolution. Your resolution/refresh rate (or both) may be too high, or the color depth is not supported.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    iRet = ChangeDisplaySettings(ref dm, CDS_UPDATEREGISTRY);
                    switch (iRet)
                    {
                        case DISP_CHANGE_SUCCESSFUL:
                            {
                                Show("Resolution changed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                                break;
                            }
                        case DISP_CHANGE_RESTART:
                            {
                                Show("You need to restart for the changes to apply.\nIf there are problems after restarting, try to change resolution in Safe Mode.", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                                break;
                            }
                        default:
                            {
                                Show("Failed to change the resolution. Your resolution/refresh rate (or both) may be too high, or the bits per pixel is not supported.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                            }
                    }
                }
            }
        }
    }
}