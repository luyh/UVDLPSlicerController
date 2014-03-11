using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.Reflection;
using UV_DLP_3D_Printer.GUI;

namespace UV_DLP_3D_Printer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            SetDefaultCulture(System.Globalization.CultureInfo.InvariantCulture); 
            Application.SetCompatibleTextRenderingDefault(false);
            //init the app object
            UVDLPApp.Instance().DoAppStartup(); // start the app and load the plug-ins
            frmSplash splash = new frmSplash(); // should pull from a licensed plug-in if need-be
            splash.Show();
            Application.Run(new frmMain2());
        }

        /*Set up a methoid to use reflection to set the culture information*/
        static void SetDefaultCulture(CultureInfo culture)
        {
            Type type = typeof(CultureInfo);

            try
            {
                type.InvokeMember("s_userDefaultCulture",
                                    BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static,
                                    null,
                                    culture,
                                    new object[] { culture });

                type.InvokeMember("s_userDefaultUICulture",
                                    BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static,
                                    null,
                                    culture,
                                    new object[] { culture });
            }
            catch { }

            try
            {
                type.InvokeMember("m_userDefaultCulture",
                                    BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static,
                                    null,
                                    culture,
                                    new object[] { culture });

                type.InvokeMember("m_userDefaultUICulture",
                                    BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static,
                                    null,
                                    culture,
                                    new object[] { culture });
            }
            catch { }
        }

    }
}


