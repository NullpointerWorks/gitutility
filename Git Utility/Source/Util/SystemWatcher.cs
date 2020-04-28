using System;
using System.IO;

namespace GitUtility.Util
{
    /**
     * singleton pattern. only one instance is allowed during the run of this application
     */
    public class SystemWatcher
    {
        private static SystemWatcher inst = null;
        public static SystemWatcher GetInstance()
        {
            if (inst==null) { inst = new SystemWatcher(); }  return inst;
        }

        private readonly NotifyFilters filter;
        private FileSystemWatcher watcher;
        private WatcherEvent printchanged;
        //private WatcherEvent printrenamed;
        public delegate void WatcherEvent(WatcherChangeTypes type, string msg);

        public SystemWatcher()
        {
            // Watch for changes in LastAccess and LastWrite times, and the renaming of files or directories
            filter = NotifyFilters.LastAccess | 
                    NotifyFilters.LastWrite | 
                    NotifyFilters.FileName | 
                    NotifyFilters.DirectoryName;

            printchanged = null;
            //printrenamed = null;
            watcher = null;
        }

        ~SystemWatcher()
        {
            StopWatching();
        }

        public void StartWatching(string path)
        {
            StopWatching();

            watcher = new FileSystemWatcher();
            watcher.Path = path;
            watcher.NotifyFilter = filter;
            watcher.Filter = "*.*"; // all files
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            ResumeWatching();
        }

        public void SetEventListener(WatcherEvent el)
        {
            printchanged = el;
        }

        public void PauseWatching()
        {
            if (watcher != null) watcher.EnableRaisingEvents = false;
        }

        public void ResumeWatching()
        {
            if (watcher != null) watcher.EnableRaisingEvents = true;
        }

        public void StopWatching()
        {
            if (watcher != null) watcher.Dispose();
            watcher = null;
        }
        
        /**
         * Specify what is done when a file is changed, created, or deleted.
         */
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            printchanged?.Invoke(e.ChangeType, "File: " + e.FullPath + " " + e.ChangeType);
        }

        /**
         * Specify what is done when a file is renamed.
         */
        private void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }
    }
}
