using GitUtility.Config;
using GitUtility.Event;
using GitUtility.Forms;
using GitUtility.Git;

using System;
using System.Windows.Forms;

namespace GitUtility
{
    static class Program
    {
        /// <summary>
        /// Application entry point
        /// </summary>
        /// 
        /// STAThread - MSDN:
        /// STAThreadAttribute indicates that the COM threading model 
        /// for the application is single-threaded apartment. This 
        /// attribute must be present on the entry point of any 
        /// application that uses Windows Forms; if it is omitted, the
        /// Windows components might not work correctly. If the 
        /// attribute is not present, the application uses the 
        /// multithreaded apartment model, which is not supported for 
        /// Windows Forms.
        [STAThread]
        static void Main()
        {
            EventManager.Initialize();
            ServersConfig.GetInstance().Load();
            ReposConfig.GetInstance().Load();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormGitUtility());
        }
    }
}
