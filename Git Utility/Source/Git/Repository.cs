using GitUtility.Command;
using GitUtility.Config;
using GitUtility.Util;
using System;
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

        public Repository(RepoDetails rd)
        {
            linker = rd;
            remote = new List<string>();
            local = new List<string>();
        }
        
        ~Repository()
        {
            linker = null;
        }

        public Iterator<string> GetIterator()
        {
            return new Iterator<string>(remote);
        }

        private void Print(string txt)
        {
            if (txt == null) return;
            if (txt.Equals("")) return;
            if (txt.EndsWith("exit")) scanNames = false;
            if (scanNames) remote.Add(txt);
            if (txt.EndsWith("git ls-files")) scanNames = true;
        }

        public void CheckDifference()
        {
            if (linker == null) return;
            scanNames = false;
            remote.Clear();
            local.Clear();
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

            /*/ check files actually in the repo, and compare
            string[] fileArray = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories);
            foreach (string f in fileArray)
            {
                if (f.Contains(@"\.git")) continue; // ignore .git repo folder
                foreach (string r in remote)
                {
                    string remotefile = (@"\" + r).Replace("/", @"\");
                    if (f.EndsWith(remotefile))
                    {
                        continue;
                    }
                }
            }
            //*/





        }
    }
}
