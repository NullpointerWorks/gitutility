using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

/* 
 * 
 * 
 * string path = "C:/folder1/folder2/file.txt";
 * string lastFolderName = Path.GetFileName( Path.GetDirectoryName( path ) ); 
 * 
 * 
 */
namespace GitUtility.Util
{
    public class FileUtil
    {
        public static void SetGitIcon(Form form)
        {
            using (var stream = File.OpenRead(ApplicationConstant.PATH_LOGO))
            {
                form.Icon = new Icon(stream);
            }
        }

        /// <summary>
        /// returns true if the file or directory exists on the local system
        /// </summary>
        public static bool Exists(string name)
        {
            return (Directory.Exists(name) || File.Exists(name));
        }

        /// <summary>
        /// Returns the folder path of the running application
        /// </summary>
        public static string GetAppliationSource()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void WriteToFileUTF8(string path, string[] lines)
        {
            UTF8Encoding utf8WithoutBom = new UTF8Encoding(false);
            FileInfo filei = new FileInfo(path);
            filei.Directory.Create();
            StreamWriter file = new StreamWriter(path, false, utf8WithoutBom);
            if (lines != null)
            {
                foreach (string line in lines)
                    file.WriteLine(line);
            }
            file.Close();
        }

        public void GenericTextFile(string abspath, string[] lines)
        {
            string dpath = Path.GetDirectoryName(abspath);
            if (dpath.Length > 0) Directory.CreateDirectory(dpath);
            Encoding utf8WithoutBom = new UTF8Encoding(false);
            StreamWriter file = new StreamWriter(abspath, false, utf8WithoutBom);
            foreach (string line in lines) { file.WriteLine(line); }
            file.Close();
        }
    }
}
