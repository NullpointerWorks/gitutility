using GitUtility.CommandLine;
using GitUtility.Config;
using GitUtility.Event;
using GitUtility.Git;
using GitUtility.Remote;
using GitUtility.Util;

using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace GitUtility.Forms
{
    public partial class FormGetRemoteRepo : Form, IEventListener
    {
        public FormGetRemoteRepo()
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
            ComboBoxSelectServer.DataSource = ds;
            ComboBoxSelectServer.DisplayMember = "Name";
            ComboBoxSelectServer.ValueMember = "Details";
            ComboBoxSelectServer.DropDownStyle = ComboBoxStyle.DropDownList;
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
                        var inv = new MethodInvoker(delegate { RefreshServerComboBox(); });
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
            localDir = localDir.Replace(@"\", "/");

            string server = ComboBoxSelectServer.GetItemText(ComboBoxSelectServer.SelectedItem);
            if (server == null) return;
            if (server.Equals("")) return;
            

            // get server details
            ListItem listitem = (ListItem)(ComboBoxSelectServer.SelectedItem);
            ServerDetails sd = listitem.Details;

            // check to see if sevrer is available
            RemoteManager rman = RemoteManager.GetInstance();
            IRemote remote = rman.Connect(sd);
            if (!remote.IsConnected()) // error
            {
                DialogUtil.Message("Error: Cannot connect to remote repository");
                return;
            }

            // make and run the script for downloading the selected repository
            string remoteDir = sd.GetServerLoginString() + "/" + repoName;
            RepoDetails repo = new RepoDetails(repoName, sd.GetName(), remoteDir, localDir);
            string script = ScriptBuilder.CloneScript(repo,sd);
            Executable exe = new Executable("expect.exe", script).Start();
            exe.WaitForExit();

            // add new repo to configuration
            ReposConfig.GetInstance().AddRepoDetails(repo, false);
            ReposConfig.GetInstance().Save();

            // done. now close and fire refresh event
            EventManager.Fire(EventCode.REFRESH_REPOS);
            ProperClose();
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
    }
}
