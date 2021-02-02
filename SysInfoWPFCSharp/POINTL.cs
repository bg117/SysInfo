using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct POINTL
{
    [MarshalAs(UnmanagedType.I4)]
    public int x;

    [MarshalAs(UnmanagedType.I4)]
    public int y;

    public POINTL(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}