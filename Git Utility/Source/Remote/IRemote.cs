using GitUtility.Config;

namespace GitUtility.Remote
{
    public interface IRemote
    {
        void Connect(ServerDetails sd);
        void Disconnect();
        bool IsConnected();
        IStream GetStream();
    }
}
