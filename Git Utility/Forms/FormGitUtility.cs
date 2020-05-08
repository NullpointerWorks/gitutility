using GitUtility.CommandLine;
using GitUtility.Config;
using GitUtility.Event;
using GitUtility.Git;
using GitUtility.Remote;
using GitUtility.Util;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace GitUtility.Forms
{
    public partial class FormGitUtility : Form, IEventListener
    {
        public FormGitUtility()
        {
            InitializeComponent();
            FileUtil.SetGitIcon(this);
            EventManager.GetInstance().AddListener(this);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = this.MinimizeBox = false;
            ComboBoxAvailableRepos.DropDownStyle = ComboBoxStyle.DropDownList; // make ComboBoxAvailableRepos not editable
            ComboBoxBranches.DropDownStyle = ComboBoxStyle.DropDownList; // make ComboBoxBranches not editable
        }

        // =================================================================
        //              Global Events - Threaded
        // =================================================================

        public void OnEvent(EventData ed)
        {
            switch (ed.EventCode)
            {
                // refreshes the repository list
                case EventCode.REFRESH_REPOS:
                    ComboBoxAvailableRepos.Invoke(new MethodInvoker(delegate
                    {
                        ComboBoxAvailableRepos.Items.Clear();
                        var cnf = ReposConfig.GetInstance();
                            
                        Iterator<RepoDetails> itsd = cnf.GetRepoDetails();
                        while (itsd.HasNext())
                        {
                            RepoDetails sd = itsd.GetNext();
                            ComboBoxAvailableRepos.Items.Add(sd.GetName());
                        }
                    }));
                    break;

                case EventCode.REFRESH_CHANGES:
                    // clear the change details. they're possibly invalid
                    RichTextBoxDeltaDetails.Invoke(new MethodInvoker(delegate
                    {
                        RichTextBoxDeltaDetails.Text = "";
                    }));
                    
                    var repdetails = ReposConfig.GetInstance().GetSelected();

                    // get the repository from the manager
                    // if the repo doesnt 
                    Repository rep = new Repository(repdetails);
                    List<string> deltas = rep.RepoDelta();
                    
                    // update repository 
                    ListBoxRepoChanges.Invoke(new MethodInvoker(delegate
                    {
                        ListBoxRepoChanges.Items.Clear();
                        Iterator<string> it = new Iterator<string>(deltas);
                        while (it.HasNext())
                        {
                            ListBoxRepoChanges.Items.Add( it.GetNext() );
                        }
                    }));
                    break;

                default: break;
            }
        }

        // =================================================================
        //              File System Change Events - Threaded
        // =================================================================
        
        public void OnWatcherEvent(WatcherChangeTypes type, string msg)
        {
            Thread.Sleep(250); // delay so not to load the CPU to much when lots of changes occur
            EventManager.Fire(EventCode.REFRESH_CHANGES);
        }

        // =================================================================
        //              UI Events
        // =================================================================

        /**
         * Requests a refresh of all configuration data
         */
        private void FormGitUtility_Load(object sender, EventArgs e)
        {
            RichTextBoxDeltaDetails.ReadOnly = true;
            RichTextBoxDeltaDetails.BackColor = SystemColors.Window;
            EventManager.Fire(EventCode.REFRESH_SERVERS);
            EventManager.Fire(EventCode.REFRESH_REPOS);
        }

        private void TextBoxCommitMessage_Validate(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Equals(""))
            {
                TextBoxCommitMessage.Text = ApplicationConstant.COMMIT_GREYTEXT;
                TextBoxCommitMessage.ForeColor = Color.Gray;
            }
        }
        
        private void TextBoxCommitMessage_Clicked(object sender, MouseEventArgs e)
        {
            if (((TextBox)sender).Text.Equals(ApplicationConstant.COMMIT_GREYTEXT))
            {
                TextBoxCommitMessage.Text = "";
                TextBoxCommitMessage.ForeColor = Color.Black;
            }
        }
        
        /// <summary>
        /// When a repository has been selected, start a systemwatcher to look for live updates.
        /// </summary>
        private void ComboBoxAvailableRepos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ComboBoxAvailableRepos.SelectedIndex;
            ReposConfig cnf = ReposConfig.GetInstance();
            var repo = cnf.GetRepoDetailsByIndex(index);
            if (repo == null) return; // prevent concurrency error

            cnf.SetSelectedByIndex(index);
            EventManager.Fire(EventCode.REFRESH_CHANGES); // refresh changelist

            var sys = SystemWatcher.GetInstance();
            sys.StartWatching(repo.GetLocal());
            sys.SetEventListener(OnWatcherEvent);
        }

        private void ButtonFetch_Click(object sender, EventArgs e)
        {
            RepoDetails local = ReposConfig.GetInstance().GetSelected();
            if (local == null)
            {
                DialogUtil.Message("Please select a repository before fetching.");
                return;
            }

            ServerDetails remote = ServersConfig.GetInstance().GetServerDetailsByName(local.GetServer());
            if (remote == null)
            {
                DialogUtil.Message("Server \"" + local.GetServer() + "\" is not available.");
                return;
            }
            
            // build and execute script
            ScriptBuilder.FetchScript(local, remote);
            Executable exe = new Executable("expect.exe", "fetch.lua").Start();
            exe.WaitForExit(); // hold thread till update

            EventManager.Fire(EventCode.REFRESH_CHANGES); // refresh changelist
        }

        /// <summary>
        /// 
        /// </summary>
        private void ListBoxRepoChanges_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = ListBoxRepoChanges.SelectedItem;
            if (item == null) return;

            RepoDetails rd   = ReposConfig.GetInstance().GetSelected();
            string selectedFile = item.ToString();
            string selectedPath = rd.GetLocal().Replace(@"\","/") + "/" + selectedFile;

            // get changes in the selected file
            Repository rep = new Repository(rd);
            List<string> lines = rep.FileDelta(selectedFile);

            // reset the textbox
            // color the removed lines red and the new lines green
            RichTextBoxDeltaDetails.Text = "";
            foreach (string line in lines)
            {
                if (line.StartsWith("+"))
                    RichTextBoxDeltaDetails.SelectionColor = Color.Green;

                if (line.StartsWith("-"))
                    RichTextBoxDeltaDetails.SelectionColor = Color.Red;
                
                RichTextBoxDeltaDetails.SelectedText = line + Environment.NewLine;
            }
        }

        /// <summary>
        /// Creates and executes a commit script based on the currently selected repository.
        /// </summary>
        private void ButtonCommitChanges_Click(object sender, EventArgs e)
        {
            string commitmsg = TextBoxCommitMessage.Text;
            if (commitmsg.Equals("") || commitmsg.Equals(ApplicationConstant.COMMIT_GREYTEXT))
            {
                DialogUtil.Message("Commit Error", "Please add a commit message before committing.");
                return;
            }

            RepoDetails repo = ReposConfig.GetInstance().GetSelected();
            if (repo == null)
            {
                DialogUtil.Message("Commit Error", "Please select a repository to commit to.");
                return;
            }

            ScriptBuilder.CommitScript(repo, TextBoxCommitMessage.Text);
            Executable exe = new Executable("expect.exe", "commit.lua").Start();
            exe.WaitForExit();
            
            TextBoxCommitMessage.Text = ""; // will not show greytext
            TextBoxCommitMessage_Validate(TextBoxCommitMessage, e);
            EventManager.Fire(EventCode.REFRESH_CHANGES);
        }

        /// <summary>
        /// Creates and executes a push script to upload commits to the repository's server
        /// </summary>
        private void ButtonPushCommits_Click(object sender, EventArgs e)
        {
            RepoDetails local = ReposConfig.GetInstance().GetSelected();
            if (local == null)
            {
                DialogUtil.Message("Push Error", "Please select a repository to push commits to.");
                return;
            }

            ServerDetails remote = ServersConfig.GetInstance().GetServerDetailsByName(local.GetServer());
            if (remote == null)
            {
                DialogUtil.Message("Push Error", "Server \"" + local.GetServer() + "\" is not available");
                return;
            }
            
            ScriptBuilder.PushScript(local, remote);
            Executable exe = new Executable("expect.exe", "push.lua").Start();
            exe.WaitForExit();

            EventManager.Fire(EventCode.REFRESH_CHANGES);
        }

        // ========================================================
        //          Menu Bar UI Events
        // ========================================================
        
        private void MenuItemNewRepo_Click(object sender, EventArgs e)
        {
            new FormNewRepo().ShowDialog();
        }

        private void MenuItemCloneRepo_Click(object sender, EventArgs e)
        {
            new FormCloneRepo().ShowDialog(); // TODO make clone dialog
        }

        private void MenuItemAddLocalRepo_Click(object sender, EventArgs e)
        {
            string res = DialogUtil.BrowseFolder();
            if (res == null) return;
            if (FileUtil.Exists(res))
            {
                if (!FileUtil.Exists(res + @"\.git"))
                {
                    DialogUtil.Message("Invalid Repository", "This directory is not initialized as a Git repository.");
                    return;
                }
                ReposConfig cnf = ReposConfig.GetInstance();
                string folderName = Path.GetFileName(res);
                cnf.AddRepoDetails(folderName, "", folderName, res, false);
                DialogUtil.Message("Repository Added", "Don't forget to set a remote server in the repository configuration.");
                EventManager.Fire(EventCode.REFRESH_REPOS);
            }
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            RemoteManager.GetInstance().DisconnectAll();
            Application.Exit();
        }
        
        private void MenuItemReposConfig_Click(object sender, EventArgs e)
        {
            new FormConfigRepos().ShowDialog();
        }

        private void MenuItemConfigureServers_Click(object sender, EventArgs e)
        {
            new FormConfigServers().ShowDialog();
        }

        private void MenuItemOpenTerminal_Click(object sender, EventArgs e)
        {
            new FormTerminal().Show();
        }

        private void MenuItemShowVersion_Click(object sender, EventArgs e)
        {
            DialogUtil.Message( "Version", 
                                "Git Utility\n"+
                                "SSH Repository Tool\n" +
                                "Nullpointer Works © 2020\n\n" +
                                "Version: " + ApplicationConstant.APP_VERSION);
        }
    }
}
