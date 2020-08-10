using GitUtility.Util;

using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GitUtility.Config
{
    /**
     * singleton pattern. only one instance is allowed during the run of this application
     */
    public class ReposConfig
    {
        private static ReposConfig inst = null;
        public static ReposConfig GetInstance()
        {
            if (inst == null) inst = new ReposConfig(); return inst;
        }

        private List<RepoDetails> details;
        private RepoDetails selected;
        private readonly Encoding utf8WithoutBom;

        /// <summary>
        /// private singleton constructor
        /// </summary>
        private ReposConfig()
        {
            details = new List<RepoDetails>();
            selected = null;
            utf8WithoutBom = new UTF8Encoding(false);
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddRepoDetails(string n, string s, string r, string l, bool overwrite)
        {
            AddRepoDetails( new RepoDetails(n,s,r,l) , overwrite);
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddRepoDetails(RepoDetails sd, bool overwrite)
        {
            if (sd == null) return;
            var detail = GetRepoDetailsByName(sd.GetName());
            if (detail != null)
            {
                if (!overwrite) return;
                detail.SetName(sd.GetName());
                detail.SetServer(sd.GetServer());
                detail.SetRemote(sd.GetRemote());
                detail.SetLocal(sd.GetLocal());
                return;
            }
            details.Add(sd);
            WriteFile(ApplicationConstant.PATH_REPO);
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetSelected(RepoDetails sd)
        {
            selected = sd;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetSelectedByName(string name)
        {
            SetSelected( GetRepoDetailsByName(name) );
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetSelectedByIndex(int index)
        {
            SetSelected(GetRepoDetailsByIndex(index));
        }

        /// <summary>
        /// returns the selected server details
        /// </summary>
        public RepoDetails GetSelected()
        {
            return selected;
        }

        /// <summary>
        /// returns an iterator of server details
        /// </summary>
        public Iterator<RepoDetails> GetRepoDetails()
        {
            return new Iterator<RepoDetails>(details);
        }

        /// <summary>
        /// returns a server detail object based on name
        /// </summary>
        public RepoDetails GetRepoDetailsByName(string name)
        {
            if (details == null) return null;
            if (name == null) return null;
            foreach (RepoDetails sd in details)
            {
                if (sd.GetName().Equals(name)) return sd;
            }
            return null;
        }

        /// <summary>
        /// returns a server detail object based on the index in the array
        /// </summary>
        public RepoDetails GetRepoDetailsByIndex(int index)
        {
            if (index < 0 && index >= details.Count) return null;
            return details[index];
        }

        /// <summary>
        /// 
        /// </summary>
        public void RemoveRepoDetails(RepoDetails sd)
        {
            if (sd == null) return;
            int l = details.Count - 1;
            for (; l >= 0; l--)
            {
                RepoDetails sdr = details[l];
                if (sd.GetHashCode() == sdr.GetHashCode())
                {
                    details.RemoveAt(l);
                    return;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void RemoveRepoDetailsByName(string name)
        {
            if (name == null) return;
            var d = GetRepoDetailsByName(name);
            RemoveRepoDetails(d);
        }

        // ====================================================================
        //          FILE IO
        // ====================================================================

        public void Load()
        {
            LoadFile(ApplicationConstant.PATH_REPO);
        }

        public void Save()
        {
            WriteFile(ApplicationConstant.PATH_REPO);
        }

        /// <summary>
        /// Load a server file into memory
        /// </summary>
        public void LoadFile(string path)
        {
            if (!File.Exists(path))
            {
                FileUtil.WriteToFileUTF8(ApplicationConstant.PATH_REPO, null);
                return;
            }

            string[] lines = File.ReadAllLines(path);
            RepoDetails detail = null;
            foreach (string line in lines)
            {
                if (line.Length<1) continue;
                if (line.Substring(0,1).Equals("#"))
                {
                    AddRepoDetails(detail, true);
                    detail = new RepoDetails();
                    detail.SetName(line.Substring(1));
                }
                if (detail == null) continue;
                string sub = line.Substring(0, 2);
                if (sub.Equals("s:")) detail.SetServer(line.Substring(2));
                if (sub.Equals("r:")) detail.SetRemote(line.Substring(2));
                if (sub.Equals("l:")) detail.SetLocal(line.Substring(2));
            }
            AddRepoDetails(detail, true);
        }

        /// <summary>
        /// 
        /// </summary>
        public void WriteFile(string path)
        {
            List<string> lines = new List<string>();
            foreach (RepoDetails sd in details)
            {
                lines.Add("#" + sd.GetName());
                lines.Add("s:" + sd.GetServer());
                lines.Add("r:" + sd.GetRemote());
                lines.Add("l:" + sd.GetLocal());
            }
            FileUtil.WriteToFileUTF8(ApplicationConstant.PATH_REPO, lines.ToArray());
        }
    }
}
