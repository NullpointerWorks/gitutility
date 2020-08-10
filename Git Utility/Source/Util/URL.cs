using System.Collections.Generic;

namespace GitUtility.Util
{
    public class URL
    {
        private bool isNetwork = false;
        private string originalString = "";
        private List<string> folders;

        public URL(string path)
        {
            folders = new List<string>();
            originalString = path;

            path = path.Replace(@"\", "/");
            string[] tokens = path.Split('/');

            isNetwork = path.StartsWith("//");
            
            int leng = tokens.Length;
            for (int i = 0; i<leng; i++)
            {
                string token = tokens[i];
                if (token == null) continue;
                if (token.Equals("")) continue;
                folders.Add(token);
            }
        }

        public string GetFolder(int index)
        {
            if (index < 0) index = 0;
            if (index >= folders.Count) index = folders.Count - 1;
            return folders[index];
        }

        public string GetLastFolder()
        {
            return folders[folders.Count - 1];
        }

        public bool IsNetworkLocation()
        {
            return isNetwork;
        }

        public string GetOriginalString()
        {
            return originalString;
        }

        public string GetLocationString()
        {
            string res = "";
            int leng = folders.Count;
            for(int i=0; i<leng; i++)
            {
                string s = folders[i];
                res += (i==0?@"\":"") + s;
            }
            return (isNetwork?@"\\":"") + res;
        }
    }
}
