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
            return Connect(sd, RemoteType.SSH);
        }

        public IRemote Connect(ServerDetails sd, RemoteType rt)
        {
            if (sd == null) return null;
            IRemote rem = null;
            switch (rt)
            {
                case RemoteType.SSH:
                    rem = new SSHRemote();
                    break;
                default:
                    break;
            }
            if (rem == null) return null;
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
