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

        private List<string> buffer;
        private List<string> local;
        private List<string> delta;

        public Repository(RepoDetails rd)
        {
            linker = rd;
            buffer = new List<string>();
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

        public void CheckDifference()
        {
            if (linker == null) return;
            scanNames = false;
            buffer.Clear();
            local.Clear();
            delta.Clear();

            string dir = linker.GetLocal();
            string name = linker.GetName();

            // lists remote repo files
            Commander cmdr = new Commander(ApplicationConstant.PATH_CMD);
            cmdr.Start();
            cmdr.SetPrintDelegate(PrintRemote);
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
                if (!buffer.Contains(file))
                {
                    delta.Add(file+" - added");
                }
            }
            buffer.Clear();

            // find deleted and modified files
            cmdr.Start();
            cmdr.SetPrintDelegate(PrintModified);
            cmdr.WaitForExit = true;
            cmdr.Execute(@"cd /D " + dir);
            cmdr.Execute(@"git diff --name-only");
            cmdr.Execute(@"exit");
            cmdr.Close();

            // compare the modified files to the local repository. 
            // any files that are still present are modified.
            // other files that do not match the local repo are deleted.
            foreach (string file in buffer)
            {
                if (local.Contains(file))
                {
                    delta.Add(file+" - modified");
                }
                else
                {
                    delta.Add(file+" - deleted");
                } 
            }
        }

        private void PrintRemote(string txt)
        {
            if (txt == null) return;
            if (txt.Equals("")) return;
            if (txt.EndsWith("exit")) scanNames = false;
            txt = txt.Replace("/", @"\"); // make sure slashes are the same direction
            if (scanNames) buffer.Add(txt);
            if (txt.EndsWith("git ls-files")) scanNames = true;
        }

        private void PrintModified(string txt)
        {
            if (txt == null) return;
            if (txt.Equals("")) return;
            if (txt.EndsWith("exit")) scanNames = false;
            txt = txt.Replace("/", @"\"); // make sure slashes are the same direction
            if (scanNames) buffer.Add(txt);
            if (txt.EndsWith("git diff --name-only")) scanNames = true;
        }
    }
}
