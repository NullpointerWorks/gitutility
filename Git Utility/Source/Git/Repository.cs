using GitUtility.Command;
using GitUtility.Config;
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
            Commander cmdr = new Commander(ApplicationConstant.PATH_CMD);
            cmdr.Start();
            cmdr.Execute(@"cd " + linker.GetLocal());
            cmdr.SetPrintDelegate(Print);
            cmdr.Execute(@"git ls-files"); // lists files that should be in the repo
            cmdr.Execute(@"exit");
            cmdr.Close();



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
