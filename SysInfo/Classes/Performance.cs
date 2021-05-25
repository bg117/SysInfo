namespace SysInfo
{
    using Microsoft.VisualBasic;
    using ModernWpf;
    using ModernWpf.Controls;
    using syslib32;
    using System;
    using System.Drawing;
    using System.Management;
    using System.Windows.Forms;
    using System.Windows.Interactivity;
    using System.Xaml;
    using winapicp;
    using Xceed.Wpf.Toolkit;

    public partial class Performance
    {
        private static readonly System.Diagnostics.PerformanceCounter CpuCounter =
            new System.Diagnostics.PerformanceCounter("Processor", "% Processor Time", "_Total");

        private string CurrentCpuUsage
        {
            get => $"{Math.Round(Performance.CpuCounter.NextValue(), 2, MidpointRounding.AwayFromZero)}%";
        }
    }
}