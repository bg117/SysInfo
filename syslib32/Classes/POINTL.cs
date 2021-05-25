namespace syslib32
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential),]
    public struct POINTL
    {
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I4),]
        public
            int x;

        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I4),]
        public
            int y;

        public POINTL(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}