using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.UnmanagedType;

namespace SysInfo
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct DEVMODE
    {
        [MarshalAs(ByValTStr, SizeConst = 32)]
        public string dmDeviceName;

        [MarshalAs(U2)]
        public ushort dmSpecVersion;

        [MarshalAs(U2)]
        public ushort dmDriverVersion;

        [MarshalAs(U2)]
        public ushort dmSize;

        [MarshalAs(U2)]
        public ushort dmDriverExtra;

        [MarshalAs(U4)]
        public uint dmFields;

        public POINTL dmPosition;

        [MarshalAs(U4)]
        public uint dmDisplayOrientation;

        [MarshalAs(U4)]
        public uint dmDisplayFixedOutput;

        [MarshalAs(I2)]
        public short dmColor;

        [MarshalAs(I2)]
        public short dmDuplex;

        [MarshalAs(I2)]
        public short dmYResolution;

        [MarshalAs(I2)]
        public short dmTTOption;

        [MarshalAs(I2)]
        public short dmCollate;

        [MarshalAs(ByValTStr, SizeConst = 32)]
        public string dmFormName;

        [MarshalAs(U2)]
        public ushort dmLogPixels;

        [MarshalAs(U4)]
        public uint dmBitsPerPel;

        [MarshalAs(U4)]
        public uint dmPelsWidth;

        [MarshalAs(U4)]
        public uint dmPelsHeight;

        [MarshalAs(U4)]
        public uint dmDisplayFlags;

        [MarshalAs(U4)]
        public uint dmDisplayFrequency;

        [MarshalAs(U4)]
        public uint dmICMMethod;

        [MarshalAs(U4)]
        public uint dmICMIntent;

        [MarshalAs(U4)]
        public uint dmMediaType;

        [MarshalAs(U4)]
        public uint dmDitherType;

        [MarshalAs(U4)]
        public uint dmReserved1;

        [MarshalAs(U4)]
        public uint dmReserved2;

        [MarshalAs(U4)]
        public uint dmPanningWidth;

        [MarshalAs(U4)]
        public uint dmPanningHeight;
    }
}