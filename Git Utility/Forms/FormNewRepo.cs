using GitUtility.CommandLine;
using GitUtility.Config;
using GitUtility.Event;
using GitUtility.Git;
using GitUtility.Remote;
using GitUtility.Util;

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GitUtility.Forms
{
    public partial class FormNewRepo : Form, IEventListener
    {
        public FormNewRepo()
        {
            InitializeComponent();
            FileUtil.SetGitIcon(this);
            EventManager.GetInstance().AddListener(this);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = this.MinimizeBox = false;
            ButtonAccept.DialogResult = DialogResult.OK;
            ButtonCancel.DialogResult = DialogResult.Cancel;
            EventManager.Fire(EventCode.REFRESH_SERVERS);
        }
        
        private void RefreshServerComboBox()
        {
            var ds = ServersConfig.GetInstance().GetServerDetailsList();
            ComboBoxSelectServer.DataSource     = ds;
            ComboBoxSelectServer.DisplayMember  = "Name";
            ComboBoxSelectServer.ValueMember    = "Details";
            ComboBoxSelectServer.DropDownStyle  = ComboBoxStyle.DropDownList;
            ComboBoxSelectServer.Refresh();
        }

        private void ProperClose()
        {
            this.Close();
            this.Dispose();
        }

        // =================================================================
        //              Global Events - Threaded
        // =================================================================

        public void OnEvent(EventData ed)
        {
            switch (ed.EventCode)
            {
                // refreshes the server selection combobox
                case EventCode.REFRESH_SERVERS:
                    if (ComboBoxSelectServer.InvokeRequired)
                    {
                        var inv = new MethodInvoker( delegate {RefreshServerComboBox();} );
                        ComboBoxSelectServer.Invoke(inv);
                    }
                    //else { RefreshServerComboBox(); }
                    break;
                    
                default: break;
            }
        }

        // =================================================================
        //              UI Events
        // =================================================================

        private void FormNewRepo_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// When creating a new repository two things need to happen. The 
        /// server needs to setup a bare repo and the local directory needs 
        /// to be linked to the remote repo.
        /// </summary>
        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            // error checks
            string repoName = TextBoxRepoName.Text;
            if (repoName == null) return;
            if (repoName.Equals("")) return;
            if (repoName.Equals("Repository Name")) return;
            string localDir = TextBoxLocalDirectory.Text;
            if (localDir == null) return;
            if (localDir.Equals("")) return;
            string server = ComboBoxSelectServer.GetItemText(ComboBoxSelectServer.SelectedItem);
            if (server == null) return;
            if (server.Equals("")) return;
            localDir = localDir.Replace(@"\","/") +"/"+ repoName;

            // get server details
            var listitem = (ListItem)(ComboBoxSelectServer.SelectedItem);
            ServerDetails sd = listitem.Details;

            // connect to server to setup the remote repo
            RemoteManager rman = RemoteManager.GetInstance();
            IRemote remote = rman.Connect(sd);

            if (!remote.IsConnected()) // error
            {
                DialogUtil.Message("Error: Cannot connect to remote repository");
                return;
            }

            IStream stream = remote.GetStream();
            string repoLoc = sd.GetLocation() + "/" + repoName;
            stream.Execute("mkdir -p " + repoLoc);
            stream.Execute("cd " + repoLoc);
            bool success = stream.Execute("git init --bare");

            if (!success) // error
            {
                DialogUtil.Message("Error: Could not execute command");
                return;
            }
            
            // make local directory
            Directory.CreateDirectory(localDir);

            if (!Directory.Exists(localDir)) // error
            {
                DialogUtil.Message("Error: Could not create local repository");
                return;
            }

            // make filerecord
            //GenericTextFile(localDir+ @"\.repository.txt", new string[] { "[files]","" });

            // make and run the script for initializing a new local repo
            string remoteDir = sd.GetServerLoginString() + "/" + repoName;
            ScriptBuilder.NewScript(repoName, localDir, remoteDir);
            Executable exe = new Executable("expect.exe", "new.lua").Start();
            exe.WaitForExit();

            // add new repo to configuration
            ReposConfig.GetInstance().AddRepoDetails(repoName, sd.GetName(), repoName, localDir, false);
            ReposConfig.GetInstance().Save();

            // done. now close and fire refresh event
            ProperClose();
            EventManager.Fire(EventCode.REFRESH_REPOS);
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            ProperClose();
        }
        
        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string path = fbd.SelectedPath;
                    if (Directory.Exists(path + @"\.git")) // git already initialized warning
                    {
                        MessageBox.Show("This directory has an existing git initialized.");
                        return;
                    }
                    TextBoxLocalDirectory.Text = path;
                }
            }
        }

        private void TextBoxRepoName_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxRepoName.ForeColor = Color.Black;
        }

        private void TextBoxRepoName_Validate(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                TextBoxRepoName.Text = "Repository Name";
                TextBoxRepoName.ForeColor = Color.Gray;
            }
        }
        
        private void TextBoxRepoName_Clicked(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "Repository Name")
            {
                TextBoxRepoName.Text = "";
                TextBoxRepoName.ForeColor = Color.Black;
            }
        }

        private void FormNewRepo_Closing(object sender, FormClosingEventArgs e)
        {
            EventManager.GetInstance().RemoveListener(this);
        }
    }
}
