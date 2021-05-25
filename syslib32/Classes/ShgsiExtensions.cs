namespace syslib32
{
    using System;

    public static class ShgsiExtensions
    {
        public static Boolean HasFlagFast(this Shell32Icons.SHGSI value, Shell32Icons.SHGSI flag)
            => (value & flag) != 0;
    }
}