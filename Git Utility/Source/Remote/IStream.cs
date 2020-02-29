namespace GitUtility.Remote
{
    public interface IStream
    {
        bool Execute(string cmd, int milliDelay = 100);
        string Read();
        void Close();
    }
}
