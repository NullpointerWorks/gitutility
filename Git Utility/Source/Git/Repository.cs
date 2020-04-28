using GitUtility.Command;
using GitUtility.Config;
using GitUtility.Util;
using System.Collections.Generic;
using System.IO;

namespace GitUtility.Git
{
    public class Repository
    {
        private bool scanNames;
        private RepoDetails linker;
        private List<string> remote;
        private List<string> local;
        private List<string> delta;

        public Repository(RepoDetails rd)
        {
            linker = rd;
            remote = new List<string>();
            local = new List<string>();
            delta = new List<string>();
        }
        
        ~Repository()
        {
            linker = null;
        }

        public Iterator<string> GetIterator()
        {
            return new Iterator<string>(delta);
        }

        private void Print(string txt)
        {
            if (txt == null) return;
            if (txt.Equals("")) return;
            if (txt.EndsWith("exit")) scanNames = false;
            txt = txt.Replace("/", @"\"); // make sure slashes are the same direction
            if (scanNames) remote.Add(txt);
            if (txt.EndsWith("git ls-files")) scanNames = true;
        }

        public void CheckDifference()
        {
            if (linker == null) return;
            scanNames = false;
            remote.Clear();
            local.Clear();
            delta.Clear();

            string dir = linker.GetLocal();
            string name = linker.GetName();

            // lists files that should be in the repo
            Commander cmdr = new Commander(ApplicationConstant.PATH_CMD);
            cmdr.Start();
            cmdr.SetPrintDelegate(Print);
            cmdr.WaitForExit = true;
            cmdr.Execute(@"cd /D " + dir);
            cmdr.Execute(@"git ls-files");
            cmdr.Execute(@"exit");
            cmdr.Close();

            // look for the files actually in the repo
            string localPath = linker.GetLocal().Replace("/", @"\"); // make sure we match the right characters
            int leng = (localPath+"\\").Length;
            string[] allfiles = Directory.GetFiles(localPath, "*.*", SearchOption.AllDirectories);
            
            // compare local repo for new files
            foreach (string f in allfiles)
            {
                string file = f.Replace("/", @"\"); // set correct slashes
                if (file.Contains(@"\.git")) continue; // ignore .git repo folder
                file = file.Substring(leng);
                local.Add(file);

                // if the found local file is not part of the repo state, a new file
                if (!remote.Contains(file))
                {
                    delta.Add(file); // added
                }
            }

            // compare remote repo for deleted files
            foreach (string file in remote)
            {
                // if the remote file is not in the local repo, a deleted file
                if (!local.Contains(file))
                {
                    delta.Add(file); // deleted
                }
            }
        }
    }
}
