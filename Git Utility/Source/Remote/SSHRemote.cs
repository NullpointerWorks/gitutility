using GitUtility.Config;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace GitUtility.Remote
{
    /// <summary>
    /// Secure Bash Remote implementation
    /// </summary>
    public class SSHRemote : IRemote
    {
        private bool isConnected;
        private ServerDetails server;
        private SshClient sshClient = null;
        private List<SSHStream> streams;

        public SSHRemote()
        {
            isConnected = false;
            streams = new List<SSHStream>();
        }
        
        public IStream GetStream()
        {
            var sshStream = sshClient.CreateShellStream("Git Utility", 80, 40, 80, 40, 2048);
            var newStream = new SSHStream(sshStream);
            streams.Add(newStream);
            return newStream;
        }

        public bool IsConnected()
        {
            return isConnected;
        }
        
        public void Connect(ServerDetails sd)
        {
            if (sd == null) return;
            server = sd.Copy();

            string ip = server.GetAddress();
            string user = server.GetUser();
            string pass = server.GetPass();

            sshClient = new SshClient(ip, user, pass);

            try
            {
                sshClient.Connect();
            }
            catch (SocketException ex)
            {
                Console.WriteLine("SocketException: " + ex.ErrorCode);
                return;
            }
            
            isConnected = sshClient.IsConnected;
        }

        public void Disconnect()
        {
            if (sshClient.IsConnected)
            {
                foreach(SSHStream s in streams)
                {
                    s.Close();
                }
                
                sshClient.Disconnect();
                sshClient = null;
                isConnected = false;
            }
        }
    }
}
