//#define TIMEDTRIAL

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.Reflection;
using UV_DLP_3D_Printer.GUI;
using SoftwareLocker;

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
            //check to see if a loaded plugin has licensing issues for trial
            // if so, who the timed trial dialog
#if (TIMEDTRIAL)
            if (CheckTrial())
            {
                frmSplash splash = new frmSplash(); // should pull from a licensed plug-in if need-be
                splash.Show();
                Application.Run(new frmMain2());
            }

#else
            frmSplash splash = new frmSplash(); // should pull from a licensed plug-in if need-be
            splash.Show();
            Application.Run(new frmMain2());

#endif
        }
        static bool CheckTrial() 
        {

            TrialMaker t = new TrialMaker("TT1", Application.StartupPath + "\\RegFile.reg",
                Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\TMSetp.dbf",
                "",
                30, 1000, "745");

            byte[] MyOwnKey = { 97, 250, 1, 5, 84, 21, 7, 63,
            4, 54, 87, 56, 123, 10, 3, 62,
            7, 9, 20, 36, 37, 21, 101, 57};
            t.TripleDESKey = MyOwnKey;

            TrialMaker.RunTypes RT = t.ShowDialog();
            bool is_trial;
            if (RT != TrialMaker.RunTypes.Expired)
            {
                if (RT == TrialMaker.RunTypes.Full)
                    is_trial = false;
                else
                    is_trial = true;
                return true;
                //Application.Run(new Form1(is_trial));
            }
            return false;
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


