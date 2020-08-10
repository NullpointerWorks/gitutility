using System.Windows.Forms;

namespace GitUtility.Util
{
    class DialogUtil
    {
        /// <summary>
        /// opens a browse pop-up to search the local system for a file
        /// </summary>
        public static string BrowseFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                return ofd.FileName;
            }
            return null;
        }
        /// <summary>
        /// opens a browse pop-up to search the local system for a folder
        /// </summary>
        public static string BrowseFolder(string desc = "Select the document folder")
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            ofd.Description = desc;
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                return ofd.SelectedPath;
            }
            return null;
        }

        /// <summary>
        /// opens a "yes no" confirmation window. returns true if confirmed, false otherwise
        /// </summary>
        public static bool Confirm(string caption, string message)
        {
            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);
            return result == DialogResult.Yes;
        }

        /// <summary>
        /// opens a "yes no" confirmation window. returns true if confirmed, false otherwise
        /// </summary>
        public static bool Confirm(string message)
        {
            DialogResult result = MessageBox.Show(message, "Confirm", MessageBoxButtons.YesNo);
            return result == DialogResult.Yes;
        }

        /// <summary>
        /// opens a simple message popup
        /// </summary>
        public static void Message(string message)
        {
            MessageBox.Show(message);
        }

        /// <summary>
        /// opens a simple message popup
        /// </summary>
        public static void Message(string caption, string message)
        {
            MessageBox.Show(message, caption);
        }

    }
}
