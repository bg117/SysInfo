namespace syslib32
{
    public class User32
    {
        public const int ENUM_CURRENT_SETTINGS = -1;
        public const int CDS_UPDATEREGISTRY = 0x01;
        public const int CDS_TEST = 0x02;
        public const int DISP_CHANGE_SUCCESSFUL = 0;
        public const int DISP_CHANGE_RESTART = 1;
        public const int DISP_CHANGE_FAILED = -1;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll"),]
        public static extern int EnumDisplaySettings(string deviceName, int modeNum,
            ref DEVMODE devMode);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll"),]
        public static extern int ChangeDisplaySettings(ref DEVMODE devMode, int flags);
    }
}