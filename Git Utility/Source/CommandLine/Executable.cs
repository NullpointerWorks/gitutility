using System.Diagnostics;

namespace GitUtility.CommandLine
{
    /// <summary>
    /// simple process delegate to facilitate custom settings
    /// </summary>
    public class Executable
    {
        private Process process = null;
        private bool isSetUp;

        public Executable(string executable, string args = null)
        {
            process = new Process();
            isSetUp = true;

            // Stop the process from opening a new window
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            // Setup executable and parameters
            process.StartInfo.FileName = executable;
            if (args != null) process.StartInfo.Arguments = args;
        }

        public Executable()
        {
            process = new Process();
            isSetUp = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
        }

        ~Executable()
        {
            process.Close();
        }

        public Executable Start()
        {
            if (isSetUp) process.Start();
            return this;
        }

        public Executable Start(string executable, string args = null)
        {
            process.StartInfo.FileName = executable;
            if (args != null) process.StartInfo.Arguments = args;
            isSetUp = true;
            Start();
            return this;
        }

        public Executable WaitForExit()
        {
            process.WaitForExit();
            return this;
        }

    }
}
