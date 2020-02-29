using GitUtility.Config;
using GitUtility.Event;
using GitUtility.Forms;

using System;
using System.Windows.Forms;

namespace GitUtility
{
    static class Program
    {
        /// <summary>
        /// Application entry point
        /// </summary>
        [STAThread]
        static void Main()
        {
            EventManager.GetInstance();
            ServersConfig.GetInstance().Load();
            ReposConfig.GetInstance().Load();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormGitUtility());
        }
    }
}
