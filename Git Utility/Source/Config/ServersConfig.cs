using GitUtility.Util;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GitUtility.Config
{
    /**
     * singleton pattern. only one instance is allowed during the run of this application
     */
    public class ServersConfig
    {
        private static ServersConfig inst = null;
        public static ServersConfig GetInstance()
        {
            if (inst == null) inst = new ServersConfig(); return inst;
        }

        private List<ServerDetails> details;
        private ServerDetails selected;
        private readonly Encoding utf8WithoutBom;

        /// <summary>
        /// private singleton constructor
        /// </summary>
        private ServersConfig()
        {
            details = new List<ServerDetails>();
            selected = null;
            utf8WithoutBom = new UTF8Encoding(false);
        }

        /// <summary>
        /// add server details to the list. 
        /// overwrite existing entry if exists
        /// </summary>
        public void AddServerDetails(string n, string s, string l, string u, string p, bool overwrite)
        {
            AddServerDetails(new ServerDetails(n, s, l, u, p), overwrite);
        }

        /// <summary>
        /// add a server detail object to the list. 
        /// overwrite existing entry if exists
        /// </summary>
        public void AddServerDetails(ServerDetails sd, bool overwrite)
        {
            if (sd == null) return;
            var detail = GetServerDetailsByName(sd.GetName());
            if (detail != null)
            {
                if (!overwrite) return;
                detail.SetAddress(sd.GetAddress());
                detail.SetLocation(sd.GetLocation());
                detail.SetUser(sd.GetUser());
                detail.SetPass(sd.GetPass());
                return;
            }
            details.Add(sd);
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetSelected(ServerDetails sd)
        {
            selected = sd;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetSelectedByName(string name)
        {
            SetSelected(GetServerDetailsByName(name));
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetSelectedByIndex(int index)
        {
            SetSelected(GetServerDetailsByIndex(index));
        }

        /// <summary>
        /// returns the selected server details
        /// </summary>
        public ServerDetails GetSelected()
        {
            return selected;
        }

        /// <summary>
        /// returns an iterator of server details
        /// </summary>
        public Iterator<ServerDetails> GetServerDetails()
        {
            return new Iterator<ServerDetails>(details);
        }

        /// <summary>
        /// returns a list of items used in combobox UIs
        /// </summary>
        public List<ListItem> GetServerDetailsList()
        {
            List<ListItem> sdl = new List<ListItem>();
            foreach (ServerDetails sd in details)
            {
                sdl.Add( new ListItem() { Name = sd.GetName() , Details = sd } );
            }
            return sdl;
        }

        /// <summary>
        /// returns a server detail object based on name
        /// </summary>
        public ServerDetails GetServerDetailsByName(string name)
        {
            if (details == null) return null;
            if (name == null) return null;
            foreach (ServerDetails sd in details)
            {
                if (sd.GetName().Equals(name)) return sd;
            }
            return null;
        }

        /// <summary>
        /// returns a server detail object based on the index in the array
        /// </summary>
        public ServerDetails GetServerDetailsByIndex(int index)
        {
            if (index < 0 && index >= details.Count) return null;
            return details[index];
        }

        /// <summary>
        /// remove a server entry by passing an entry instance
        /// </summary>
        public void RemoveServerDetails(ServerDetails sd)
        {
            if (sd == null) return;
            int l = details.Count - 1;
            for (; l >= 0; l--)
            {
                ServerDetails sdr = details[l];
                if (sd.GetHashCode() == sdr.GetHashCode())
                {
                    details.RemoveAt(l);
                    return;
                }
            }
        }

        /// <summary>
        /// removes an server entry by name
        /// </summary>
        public void RemoveServerDetailsByName(string name)
        {
            if (name == null) return;
            var d = GetServerDetailsByName(name);
            RemoveServerDetails(d);
        }

        // ====================================================================
        //          FILE IO
        // ====================================================================

        public void Load()
        {
            LoadFile(ApplicationConstant.PATH_SERVER);
        }

        public void Save()
        {
            WriteFile(ApplicationConstant.PATH_SERVER);
        }

        public void LoadFile(string path)
        {
            if (!File.Exists(path))
            {
                FileUtil.WriteToFileUTF8(path, null);
                return;
            }

            string[] lines = File.ReadAllLines(path);
            ServerDetails detail = null;
            foreach (string line in lines)
            {
                if (line.Substring(0, 1).Equals("#"))
                {
                    AddServerDetails(detail, true);
                    detail = new ServerDetails();
                    detail.SetName(line.Substring(1));
                }
                if (detail == null) continue;
                string sub = line.Substring(0, 2);
                if (sub.Equals("s:")) detail.SetAddress(line.Substring(2));
                if (sub.Equals("u:")) detail.SetUser(line.Substring(2));
                if (sub.Equals("p:")) detail.SetPass(line.Substring(2));
                if (sub.Equals("l:")) detail.SetLocation(line.Substring(2));
            }
            AddServerDetails(detail, true);
        }

        public void WriteFile(string path)
        {
            List<string> lines = new List<string>();
            foreach (ServerDetails sd in details)
            {
                lines.Add("#" + sd.GetName());
                lines.Add("s:" + sd.GetAddress());
                lines.Add("l:" + sd.GetLocation());
                lines.Add("u:" + sd.GetUser());
                lines.Add("p:" + sd.GetPass());
            }
            FileUtil.WriteToFileUTF8(path, lines.ToArray());
        }
    }
}
