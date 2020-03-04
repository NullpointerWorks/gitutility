using GitUtility.CommandLine;
using GitUtility.Config;
using GitUtility.Event;
using GitUtility.Git;
using GitUtility.Remote;
using GitUtility.Util;

using System;
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
                    TextBoxChangeDetails.Invoke(new MethodInvoker(delegate
                    {
                        TextBoxChangeDetails.Text = "";
                    }));

                    var rcnf = ReposConfig.GetInstance();
                    Repository rep = new Repository(rcnf.GetSelected());
                    rep.CheckDifference();
                    
                    // update repository 
                    ListBoxRepoChanges.Invoke(new MethodInvoker(delegate
                    {
                        ListBoxRepoChanges.Items.Clear();
                        Iterator<string> it = rep.GetIterator();
                        //ListBoxRepoChanges.Items.Add("files: "+ it.Size());
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
            Thread.Sleep(500); // delay so not to load the CPU to much when lots of changes occur
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
            TextBoxChangeDetails.ReadOnly = true;
            TextBoxChangeDetails.BackColor = SystemColors.Window;
            
            EventManager.Fire(EventCode.REFRESH_SERVERS);
            EventManager.Fire(EventCode.REFRESH_REPOS);
        }

        private void TextBoxCommitMessage_Validate(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                TextBoxCommitMessage.Text = "Commit Description";
                TextBoxCommitMessage.ForeColor = Color.Gray;
            }
        }
        
        private void TextBoxCommitMessage_Clicked(object sender, MouseEventArgs e)
        {
            if (((TextBox)sender).Text == "Commit Description")
            {
                TextBoxCommitMessage.Text = "";
                TextBoxCommitMessage.ForeColor = Color.Black;
            }
        }
        
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
            ReposConfig lcnf = ReposConfig.GetInstance();
            RepoDetails local = lcnf.GetSelected();

            ServersConfig rcnf = ServersConfig.GetInstance();
            ServerDetails remote = rcnf.GetServerDetailsByName(local.GetServer());

            if (remote == null)
            {
                DialogUtil.Message("Server \"" + local.GetServer() + "\" is not available");
                return;
            }
            
            // build and execute script
            ScriptBuilder.FetchScript(local, remote);

            Executable exe = new Executable("expect.exe", "fetch.lua").Start();
            exe.WaitForExit(); // hold thread till update

            EventManager.Fire(EventCode.REFRESH_CHANGES); // refresh changelist
        }

        private void ListBoxRepoChanges_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = ListBoxRepoChanges.SelectedItem;
            if (item == null) return;

            string selectedFile = item.ToString();
            ReposConfig lcnf    = ReposConfig.GetInstance();
            RepoDetails local   = lcnf.GetSelected();
            string selectedPath = local.GetLocal().Replace(@"\","/") + "/" + selectedFile;
            //DialogUtil.Message(selectedPath);


            
            // TODO get changes in the selected file

            // TODO print changes in 'TextBoxChangeDetails.Text'

            

        }

        private void ButtonCommitChanges_Click(object sender, EventArgs e)
        {
            string commitmsg = TextBoxCommitMessage.Text;
            if (commitmsg.Equals("")) return;
            
            ReposConfig lcnf = ReposConfig.GetInstance();
            RepoDetails local = lcnf.GetSelected();
            
            // build and execute script
            ScriptBuilder.CommitScript(local, TextBoxCommitMessage.Text);
            Executable exe = new Executable("expect.exe", "commit.lua").Start();
            exe.WaitForExit();


            TextBoxCommitMessage.Text = "";
            EventManager.Fire(EventCode.REFRESH_CHANGES);
        }

        private void ButtonPushCommits_Click(object sender, EventArgs e)
        {
            ReposConfig lcnf = ReposConfig.GetInstance();
            RepoDetails local = lcnf.GetSelected();

            ServersConfig rcnf = ServersConfig.GetInstance();
            ServerDetails remote = rcnf.GetServerDetailsByName(local.GetServer());

            if (remote == null)
            {
                DialogUtil.Message("Server \"" + local.GetServer() + "\" is not available");
                return;
            }

            // build and execute script
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
                    DialogUtil.Message("Invalid repository", "This directory is not initialized as a Git repository.");
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
                                "Git Utility\n" +
                                "Axtron Development Tool\n" +
                                "Nullpointer Works © 2020\n\n" +
                                "Version: " + ApplicationConstant.APP_VERSION);
        }
    }
}
