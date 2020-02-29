using GitUtility.Config;
using System.Collections.Generic;

namespace GitUtility.Remote
{
    public class RemoteManager
    {
        private static RemoteManager inst = null;
        public static RemoteManager GetInstance()
        {
            if (inst == null) inst = new RemoteManager(); return inst;
        }
        
        private List<IRemote> remotes;
        private RemoteManager()
        {
            remotes = new List<IRemote>();
        }

        public IRemote Connect(ServerDetails sd)
        {
            if (sd == null) return null;
            IRemote rem = new SSHRemote();
            rem.Connect(sd);
            remotes.Add(rem);
            return rem;
        }

        public void DisconnectAll()
        {
            foreach(IRemote r in remotes)
            {
                if (r.IsConnected()) r.Disconnect();
            }
        }
    }
}
