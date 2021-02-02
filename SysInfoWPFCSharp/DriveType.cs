using System;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace SysInfo
{
    public static class DriveType
    {
        // For CreateFile to get handle to drive
        public const uint GENERIC_READ = 0x80000000;
        public const uint GENERIC_WRITE = 0x40000000;
        public const uint FILE_SHARE_READ = 0x00000001;
        public const uint FILE_SHARE_WRITE = 0x00000002;
        public const uint OPEN_EXISTING = 3;
        public const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;

        // CreateFile to get handle to drive
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SafeFileHandle CreateFileW(
            [MarshalAs(UnmanagedType.LPWStr)]
            string lpFileName,
            uint dwDesiredAccess,
            uint dwShareMode,
            IntPtr lpSecurityAttributes,
            uint dwCreationDisposition,
            uint dwFlagsAndAttributes,
            IntPtr hTemplateFile);

        // For control codes
        public const uint FILE_DEVICE_MASS_STORAGE = 0x0000002d;
        public const uint IOCTL_STORAGE_BASE = FILE_DEVICE_MASS_STORAGE;
        public const uint FILE_DEVICE_CONTROLLER = 0x00000004;
        public const uint IOCTL_SCSI_BASE = FILE_DEVICE_CONTROLLER;
        public const uint METHOD_BUFFERED = 0;
        public const uint FILE_ANY_ACCESS = 0;
        public const uint FILE_READ_ACCESS = 0x00000001;
        public const uint FILE_WRITE_ACCESS = 0x00000002;

        public static uint CTL_CODE(uint DeviceType, uint Function,
                                     uint Method, uint Access)
        {
            return ((DeviceType << 16) | (Access << 14) |
                    (Function << 2) | Method);
        }

        // For DeviceIoControl to check no seek penalty
        public const uint StorageDeviceSeekPenaltyProperty = 7;
        public const uint PropertyStandardQuery = 0;

        [StructLayout(LayoutKind.Sequential)]
        public struct STORAGE_PROPERTY_QUERY
        {
            public uint PropertyId;
            public uint QueryType;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] AdditionalParameters;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DEVICE_SEEK_PENALTY_DESCRIPTOR
        {
            public uint Version;
            public uint Size;
            [MarshalAs(UnmanagedType.U1)]
            public bool IncursSeekPenalty;
        }

        // DeviceIoControl to check no seek penalty
        [DllImport("kernel32.dll", EntryPoint = "DeviceIoControl",
                   SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeviceIoControl(
            SafeFileHandle hDevice,
            uint dwIoControlCode,
            ref STORAGE_PROPERTY_QUERY lpInBuffer,
            uint nInBufferSize,
            ref DEVICE_SEEK_PENALTY_DESCRIPTOR lpOutBuffer,
            uint nOutBufferSize,
            out uint lpBytesReturned,
            IntPtr lpOverlapped);

        // For DeviceIoControl to check nominal media rotation rate
        public const uint ATA_FLAGS_DATA_IN = 0x02;

        [StructLayout(LayoutKind.Sequential)]
        public struct ATA_PASS_THROUGH_EX
        {
            public ushort Length;
            public ushort AtaFlags;
            public byte PathId;
            public byte TargetId;
            public byte Lun;
            public byte ReservedAsUchar;
            public uint DataTransferLength;
            public uint TimeOutValue;
            public uint ReservedAsUlong;
            public IntPtr DataBufferOffset;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] PreviousTaskFile;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] CurrentTaskFile;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ATAIdentifyDeviceQuery
        {
            public ATA_PASS_THROUGH_EX header;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public ushort[] data;
        }

        // DeviceIoControl to check nominal media rotation rate
        [DllImport("kernel32.dll", EntryPoint = "DeviceIoControl",
                   SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeviceIoControl(
            SafeFileHandle hDevice,
            uint dwIoControlCode,
            ref ATAIdentifyDeviceQuery lpInBuffer,
            uint nInBufferSize,
            ref ATAIdentifyDeviceQuery lpOutBuffer,
            uint nOutBufferSize,
            out uint lpBytesReturned,
            IntPtr lpOverlapped);

        // For error message
        public const uint FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern uint FormatMessage(
            uint dwFlags,
            IntPtr lpSource,
            uint dwMessageId,
            uint dwLanguageId,
            StringBuilder lpBuffer,
            uint nSize,
            IntPtr arguments);

        // Method for nominal media rotation rate
        // (Administrative privilege is required)
        public static string HasNominalMediaRotationRate()
        {
            SafeFileHandle hDrive = CreateFileW(
                "\\\\.\\PhysicalDrive0",
                GENERIC_READ | GENERIC_WRITE, // Administrative privilege is required
                FILE_SHARE_READ | FILE_SHARE_WRITE,
                IntPtr.Zero,
                OPEN_EXISTING,
                FILE_ATTRIBUTE_NORMAL,
                IntPtr.Zero);

            if (hDrive == null || hDrive.IsInvalid)
            {
                string message = GetErrorMessage(Marshal.GetLastWin32Error());
                return ("CreateFile failed. " + message);
            }

            uint ioctlAtaPassThrough = CTL_CODE(
                IOCTL_SCSI_BASE, 0x040b, METHOD_BUFFERED,
                FILE_READ_ACCESS | FILE_WRITE_ACCESS); // From ntddscsi.h

            ATAIdentifyDeviceQuery idQuery = new ATAIdentifyDeviceQuery {data = new ushort[256]};

            idQuery.header.Length = (ushort)Marshal.SizeOf(idQuery.header);
            idQuery.header.AtaFlags = (ushort)ATA_FLAGS_DATA_IN;
            idQuery.header.DataTransferLength =
                (uint)(idQuery.data.Length * 2); // Size of "data" in bytes
            idQuery.header.TimeOutValue = 3; // Sec
            idQuery.header.DataBufferOffset = (IntPtr)Marshal.OffsetOf(
                typeof(ATAIdentifyDeviceQuery), "data");
            idQuery.header.PreviousTaskFile = new byte[8];
            idQuery.header.CurrentTaskFile = new byte[8];
            idQuery.header.CurrentTaskFile[6] = 0xec; // ATA IDENTIFY DEVICE

            uint retvalSize;

            bool result = DeviceIoControl(
                hDrive,
                ioctlAtaPassThrough,
                ref idQuery,
                (uint)Marshal.SizeOf(idQuery),
                ref idQuery,
                (uint)Marshal.SizeOf(idQuery),
                out retvalSize,
                IntPtr.Zero);

            hDrive.Close();

            if (result == false)
            {
                string message = GetErrorMessage(Marshal.GetLastWin32Error());
                return ("DeviceIoControl failed. " + message);
            }

            // Word index of nominal media rotation rate
            // (1 means non-rotate device)
            const int kNominalMediaRotRateWordIndex = 217;

            if (idQuery.data[kNominalMediaRotRateWordIndex] == 0) {
                return "HDD";
            }

            return "SSD";
        }

        // Method for error message
        public static string GetErrorMessage(int code)
        {
            StringBuilder message = new StringBuilder(255);

            FormatMessage(
              FORMAT_MESSAGE_FROM_SYSTEM,
              IntPtr.Zero,
              (uint)code,
              0,
              message,
              (uint)message.Capacity,
              IntPtr.Zero);

            return message.ToString();
        }
    }
}