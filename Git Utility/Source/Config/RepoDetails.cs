namespace GitUtility.Config
{
    public class RepoDetails
    {
        private string name;
        private string serv;
        private string loc;
        private string rem;

        public RepoDetails()
        { name = ""; serv = ""; loc = ""; rem = ""; }

        public RepoDetails(string n, string s, string r, string l)
        { name = n; serv = s; loc = l; rem = r; }

        public void SetName(string n) { name = n; }
        public void SetServer(string s) { serv = s; }
        public void SetRemote(string r) { rem = r; }
        public void SetLocal(string l) { loc = l; }

        public string GetName() { return name; }
        public string GetServer() { return serv; }
        public string GetRemote() { return rem; }
        public string GetLocal() { return loc; }
    }
}
