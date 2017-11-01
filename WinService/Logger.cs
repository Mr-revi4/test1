using System;
using System.IO;
using System.Threading;

namespace WinService
{
    class Logger
    {
        FileSystemWatcher watcher;
        bool enable = true;
        object locker = new object();
        public Logger()
        {
            watcher = new FileSystemWatcher(@"C:\Db");
            watcher.Changed += Watcher_Changed;
            watcher.Deleted += Watcher_Deleted;
            watcher.Renamed += Watcher_Renamed;
            watcher.Created += Watcher_Created;
        }

        public void Start()
        {
            watcher.EnableRaisingEvents = true;
            while (enable)
                Thread.Sleep(1000);                
        }

        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
            enable = false;
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e) =>
            RecordEntry("created", e.FullPath);

        private void Watcher_Renamed(object sender, RenamedEventArgs e) =>        
            RecordEntry("renamed to " + e.FullPath, e.OldFullPath);

        private void Watcher_Deleted(object sender, FileSystemEventArgs e) =>
            RecordEntry("deleted ", e.FullPath);

        private void Watcher_Changed(object sender, FileSystemEventArgs e) =>
            RecordEntry("changed", e.FullPath);


        private void RecordEntry(string fileEvent, string filePath)
        {
            lock (locker)
            {
                using (StreamWriter writer = new StreamWriter("Log.txt"))
                {
                    writer.WriteLine(String.Format("{0} file {1} was {2}",
                        DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), filePath, fileEvent));
                    writer.Flush();
                }
            }
        }
    }
}
