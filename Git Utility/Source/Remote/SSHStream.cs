using Renci.SshNet;
using System.Threading;

namespace GitUtility.Remote
{
    /// <summary>
    /// Secure Bash Stream implementation
    /// </summary>
    public class SSHStream : IStream
    {
        private readonly ShellStream stream;

        public SSHStream(ShellStream sshs)
        {
            stream = sshs;
        }
        
        public bool Execute(string cmd, int milliDelay = 100)
        {
            if (stream == null) return false;
            if (cmd == null) return false;
            stream.WriteLine(cmd);
            Thread.Sleep(milliDelay);
            return true;
        }

        /// <summary>
        /// Returns the possible response from the previously issues command.
        /// </summary>
        public string Read()
        {
            return stream.Read();
        }

        public void Close()
        {
            stream.Close();
        }
    }
}
