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

    internal class UserPreferences
    {
        public System.Windows.WindowState _windowState;
        public double _windowTop, _windowLeft, _windowHeight, _windowWidth;

        public UserPreferences()
        {
            this.Load();
            this.SizeToFit();
            this.MoveIntoView();
        }

        private void Load()
        {
            _windowTop = Properties.Settings.Default.WindowTop;
            _windowLeft = Properties.Settings.Default.WindowLeft;
            _windowHeight = Properties.Settings.Default.WindowHeight;
            _windowWidth = Properties.Settings.Default.WindowWidth;
            _windowState = Properties.Settings.Default.WindowState;
        }

        public void Save()
        {
            if (_windowState != System.Windows.WindowState.Minimized)
            {
                Properties.Settings.Default.WindowTop = _windowTop;
                Properties.Settings.Default.WindowLeft = _windowLeft;
                Properties.Settings.Default.WindowHeight = _windowHeight;
                Properties.Settings.Default.WindowWidth = _windowWidth;
                Properties.Settings.Default.WindowState = _windowState;

                Properties.Settings.Default.Save();
            }
        }

        private void SizeToFit()
        {
            if (_windowHeight > System.Windows.SystemParameters.VirtualScreenHeight)
            {
                _windowHeight = System.Windows.SystemParameters.VirtualScreenHeight;
            }

            if (_windowWidth > System.Windows.SystemParameters.VirtualScreenWidth)
            {
                _windowWidth = System.Windows.SystemParameters.VirtualScreenWidth;
            }
        }

        private void MoveIntoView()
        {
            if (_windowTop + _windowHeight / 2 >
                 System.Windows.SystemParameters.VirtualScreenHeight)
            {
                _windowTop =
                  System.Windows.SystemParameters.VirtualScreenHeight -
                  _windowHeight;
            }

            if (_windowLeft + _windowWidth / 2 >
                     System.Windows.SystemParameters.VirtualScreenWidth)
            {
                _windowLeft =
                  System.Windows.SystemParameters.VirtualScreenWidth -
                  _windowWidth;
            }

            if (_windowTop < 0)
            {
                _windowTop = 0;
            }

            if (_windowLeft < 0)
            {
                _windowLeft = 0;
            }
        }
    }
}