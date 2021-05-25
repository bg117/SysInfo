using System;
using static SysInfo.MainWindow;
using static SysInfo.SystemInformation;
using System.Linq;
using System.Runtime.InteropServices;
using winapicp;
using static System.Environment;
using Forms = System.Windows.Forms;
using System.Windows;

namespace SysInfo
{
    
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        

        public App()
        {
            try {
                if (!System.IO.File.Exists("syslib32.dll")) {

                    var td = new winapicp.Dialogs.TaskDialogs.TaskDialog {
                        Caption = "Fatal error: DLL not found",
                        InstructionText = "Fatal error: DLL not found",
                        Icon = winapicp.Dialogs.TaskDialogs.TaskDialogStandardIcon.Error,
                        Text =
                            "Fatal error: syslib32.dll not found! Please include it in the same directory as the application!",
                    };
                    td.Show();
                    System.Windows.Application.Current.Shutdown();
                }
            }
            catch (TypeInitializationException e) {
                System.Windows.MessageBox.Show(e.Message);
            }
        }
        protected override void OnExit(System.Windows.ExitEventArgs e)
        {
            SysInfo.Properties.Settings.Default.Save();
        }

        protected override void OnStartup(System.Windows.StartupEventArgs e)
        {
            base.OnStartup(e);
            if (e.Args.Length > 0)
            {
                for (int i = 0; i < e.Args.Length; ++i)
                {
                    if (e.Args[i].Equals("/info") || e.Args[i].Equals("--info"))
                    {
                        if (AttachConsole(-1))
                        {
                            Console.WriteLine('\n' + MW.FileText);
                            Forms.SendKeys.SendWait("{ENTER}");
                            Application.Current.Shutdown();
                        }
                    }
                    else if (e.Args[i].Equals("/write") || e.Args[i].Equals("--write"))
                    {
                        try
                        {
                            if (AttachConsole(-1))
                            {
                                MW.ExportFile(e.Args[i + 1]);
                                Console.WriteLine("\nSuccessfully written to file '{0}'", e.Args[i + 1]);
                                Forms.SendKeys.SendWait("{ENTER}");
                                Application.Current.Shutdown();
                            }
                        }
                        catch(System.IndexOutOfRangeException)
                        {
                            Console.WriteLine("\nPlease specify a file to write to.");
                            Forms.SendKeys.SendWait("{ENTER}");
                            Application.Current.Shutdown(-1);
                        }
                    }

                    else if (e.Args[i].Equals("/help") || e.Args[i].Equals("--help"))
                    {
                        if (AttachConsole(-1))
                        {
                            Console.WriteLine("SysInfo Help\r\n\n\n--info | /info : displays system information in command line instead of opening SysInfo");
                            Forms.SendKeys.SendWait("{ENTER}");
                            Application.Current.Shutdown();
                        }

                        
                    }
                    
                }
            } 
            else
            {
                MW.Show();
            }

        }
    }
}