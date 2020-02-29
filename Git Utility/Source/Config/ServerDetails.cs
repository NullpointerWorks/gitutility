namespace GitUtility.Config
{
    public class ServerDetails
    {
        private string name;
        private string ip;
        private string loc;
        private string user;
        private string pass;

        public ServerDetails()
        {}

        public ServerDetails(string n, string s, string l, string u, string p)
        {name = n; ip = s; loc = l; user = u; pass = p;}

        public void SetName(string n) { name = n; }
        public void SetAddress(string s) { ip = s; }
        public void SetLocation(string l) { loc = l; }
        public void SetUser(string u) { user = u; }
        public void SetPass(string p) { pass = p; }

        public string GetName() { return name; }
        public string GetAddress() { return ip; }
        public string GetLocation() { return loc; }
        public string GetUser() { return user; }
        public string GetPass() { return pass; }

        public string GetServerLoginString()
        {
            // pi@127.0.0.1:/media/hdd1/git
            return user+"@"+ip+":"+loc;
        }

        /// <summary>
        /// Returns a reference free copy of the server data
        /// </summary>
        public ServerDetails Copy()
        {
            return new ServerDetails(name,ip,loc,user,pass);
        }
    }
}
