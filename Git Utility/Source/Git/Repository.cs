using GitUtility.Command;
using GitUtility.Config;
using System.Collections.Generic;
using System.IO;

namespace GitUtility.Git
{
    public class Repository
    {
        private bool scanNames;
        private RepoDetails details;
        private List<string> buffer;

        public Repository(RepoDetails rd)
        {
            details = rd;
            buffer = new List<string>();
        }
        
        ~Repository()
        {
            details = null;
        }

        public string GetName()
        {
            return details.GetName();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> FileDelta(string file)
        {
            if (details == null) return null;
            List<string> delta = new List<string>();
            scanNames = false;
            string dir = details.GetLocal();

            // get file difference compared to previous commit
            StartTrigger = "@@ ";// "diff --git";
            EndTrigger = "pause";
            Commander cmdr = new Commander(ApplicationConstant.PATH_CMD);
            cmdr.Start();
            cmdr.SetPrintDelegate(Print);
            cmdr.WaitForExit = true;
            cmdr.Execute(@"cd /D " + dir);
            cmdr.Execute(@"git diff -- " + file);
            cmdr.Execute(@"exit");
            cmdr.Close();
            foreach (string line in buffer) delta.Add(line);
            buffer.Clear();
            return delta;
        }

        /// <summary>
        /// collects the repository differences compared to previous commit
        /// </summary>
        /// <returns>
        /// returns a list of file names with their status
        /// </returns>
        public List<string> RepoDelta()
        {
            if (details == null) return null;
            List<string> delta = new List<string>();
            List<string> local = new List<string>();
            scanNames = false;
            
            string dir = details.GetLocal();
            string name = details.GetName();

            // lists remote repo files
            StartTrigger = "git ls-files";
            EndTrigger = "exit";
            Commander cmdr = new Commander(ApplicationConstant.PATH_CMD);
            cmdr.Start();
            cmdr.SetPrintDelegate(Print);
            cmdr.WaitForExit = true;
            cmdr.Execute(@"cd /D " + dir);
            cmdr.Execute(@"git ls-files");
            cmdr.Execute(@"exit");
            cmdr.Close();

            // look for the files actually in the repo
            string localPath = details.GetLocal().Replace("/", @"\"); // make sure we match the right characters
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

            // find changed files
            StartTrigger = "git diff --name-only";
            EndTrigger = "exit";
            cmdr.Start();
            cmdr.SetPrintDelegate(Print);
            cmdr.WaitForExit = true;
            cmdr.Execute(@"cd /D " + dir);
            cmdr.Execute(@"git diff --name-only");
            cmdr.Execute(@"exit");
            cmdr.Close();

            // changed files that still exist, are modified
            // changed files that are no longer present are deleted
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
            buffer.Clear();

            return delta;
        }

        private string StartTrigger = "git ls-files";
        private string EndTrigger = "exit";
        private void Print(string txt)
        {
            if (txt == null) return;
            if (txt.Equals("")) return;
            if (txt.EndsWith(EndTrigger)) scanNames = false;
            txt = txt.Replace("/", @"\"); // make sure slashes are the same direction
            if (scanNames) buffer.Add(txt);
            if (txt.Contains(StartTrigger)) scanNames = true;
        }
    }
}
