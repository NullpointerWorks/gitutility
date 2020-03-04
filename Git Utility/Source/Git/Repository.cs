using GitUtility.Command;
using GitUtility.Config;
using GitUtility.Util;

using System.Collections.Generic;

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

        public void CheckDifference()
        {
            if (linker == null) return;
            scanNames = false;
            
            // lists files that should be in the repo
            Commander cmdr = new Commander(ApplicationConstant.PATH_CMD);
            cmdr.Start();
            cmdr.SetPrintDelegate(Print);
            cmdr.Execute(@"cd /D " + linker.GetLocal());
            cmdr.Execute(@"git ls-files");
            cmdr.Execute(@"exit");
            cmdr.Close();

            // check files actually in the repo





        }

        /**
         * 
         */
        public Iterator<string> GetIterator()
        {
            return new Iterator<string>(remote);
        }

        /**
         * CMD commander stream output event delegate.
         */
        private void Print(string txt)
        {
            if (txt == null) return;
            if (txt.Equals("")) return;
            
            if (txt.EndsWith("exit"))
            {
                scanNames = false;
            }

            if (scanNames)
            {
                remote.Add(txt);
            }

            if (txt.EndsWith("git ls-files"))
            {
                scanNames = true;
            }
        }
    }
}
