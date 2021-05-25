namespace System
{

    public static class PerformanceInfo
    {
        [System.Runtime.InteropServices.DllImportAttribute("psapi.dll", SetLastError = true),]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool),]
        private static extern Boolean GetPerformanceInfo(
            [System.Runtime.InteropServices.OutAttribute,] out PerformanceInformation PerformanceInformation,
            [System.Runtime.InteropServices.InAttribute,] int Size);

        public static Int64 GetPhysicalAvailableMemoryInMiB()
        {
            PerformanceInformation _ = new PerformanceInformation();
            if (PerformanceInfo.GetPerformanceInfo(out _, System.Runtime.InteropServices.Marshal.SizeOf(_)))
            {
                return Convert.ToInt64(_.PhysicalAvailable.ToInt64() * _.PageSize.ToInt64() / 1048576);
            }

            return -1;
        }

        public static Int64 GetTotalMemoryInMiB()
        {
            PerformanceInformation _ = new PerformanceInformation();
            if (PerformanceInfo.GetPerformanceInfo(out _, System.Runtime.InteropServices.Marshal.SizeOf(_)))
            {
                return Convert.ToInt64(_.PhysicalTotal.ToInt64() * _.PageSize.ToInt64() / 1048576);
            }

            return -1;
        }

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential),]
        public struct PerformanceInformation
        {
            public int Size;
            public IntPtr CommitTotal;
            public IntPtr CommitLimit;
            public IntPtr CommitPeak;
            public IntPtr PhysicalTotal;
            public IntPtr PhysicalAvailable;
            public IntPtr SystemCache;
            public IntPtr KernelTotal;
            public IntPtr KernelPaged;
            public IntPtr KernelNonPaged;
            public IntPtr PageSize;
            public int HandlesCount;
            public int ProcessCount;
            public int ThreadCount;
        }
    }
}