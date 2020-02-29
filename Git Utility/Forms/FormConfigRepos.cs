using GitUtility.Config;
using GitUtility.Event;
using GitUtility.Util;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GitUtility.Forms
{
    public partial class FormConfigRepos : Form, IEventListener
    {
        private string selected = "";

        public FormConfigRepos()
        {
            InitializeComponent();
            FileUtil.SetGitIcon(this);
            EventManager.GetInstance().AddListener(this);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = this.MinimizeBox = false;
        }

        /// <summary>
        /// refreshes the repo listbox
        /// </summary>
        private void RefreshList()
        {
            ListBoxRepos.Items.Clear();
            ReposConfig cnf = ReposConfig.GetInstance();
            Iterator<RepoDetails> itsd = cnf.GetRepoDetails();
            while (itsd.HasNext())
            {
                RepoDetails sd = itsd.GetNext();
                ListBoxRepos.Items.Add(sd.GetName());
            }
        }

        /// <summary>
        /// refreshes the font color of the textboxes to black
        /// </summary>
        private void RefreshTextBoxes()
        {
            TextBoxEntryName.ForeColor = Color.Black;
            ComboBoxAvailableServers.ForeColor = Color.Black;
            TextBoxRemoteName.ForeColor = Color.Black;
            TextBoxLocalPath.ForeColor = Color.Black;
        }

        /// <summary>
        /// set the text of all the texboxes in the form
        /// </summary>
        private void SetTextBoxText(string n, string s, string r, string l)
        {
            TextBoxEntryName.Text = n;
            ComboBoxAvailableServers.Text = s;
            TextBoxRemoteName.Text = r;
            TextBoxLocalPath.Text = l;
        }

        private void RefreshServerComboBox()
        {
            var dataSource = ServersConfig.GetInstance().GetServerDetailsList();
            ComboBoxAvailableServers.DataSource = dataSource;
            ComboBoxAvailableServers.DisplayMember = "Name";
            ComboBoxAvailableServers.ValueMember = "Details";
            ComboBoxAvailableServers.Refresh();
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
                    if (ComboBoxAvailableServers.InvokeRequired)
                    {
                        ComboBoxAvailableServers.Invoke(new MethodInvoker(delegate
                        {
                            RefreshServerComboBox();
                        }));
                    }
                    else
                    {
                        RefreshServerComboBox();
                    }
                    break;

                // refreshes the repository list
                case EventCode.REFRESH_REPOS:
                    if (ListBoxRepos.InvokeRequired)
                    {
                        ListBoxRepos.Invoke(new MethodInvoker(delegate
                        {
                            RefreshList();
                        }));
                    }
                    else
                    {
                        RefreshList();
                    }
                    break;

                default: break;
            }
        }

        // =================================================================
        //          UI Events
        // =================================================================

        private void FormRepositories_Load(object sender, EventArgs e)
        {
            RefreshList();
            RefreshTextBoxes();
            EventManager.Fire(EventCode.REFRESH_SERVERS);
        }

        private void FormConfigRepos_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventManager.GetInstance().RemoveListener(this);
            this.Dispose();
        }

        private void ButtonSaveRepos_Click(object sender, EventArgs e)
        {
            ReposConfig cnf = ReposConfig.GetInstance();
            var select = cnf.GetSelected();
            if (select != null)
            {
                select.SetName(TextBoxEntryName.Text);
                select.SetServer(ComboBoxAvailableServers.Text);
                select.SetRemote(TextBoxRemoteName.Text);
                select.SetLocal(TextBoxLocalPath.Text);
            }
            cnf.Save();
            EventManager.Fire(EventCode.REFRESH_REPOS);
        }

        private void ButtonRemRepo_Click(object sender, EventArgs e)
        {
            ReposConfig cnf = ReposConfig.GetInstance();
            var select = cnf.GetSelected();
            if (select == null) return; // no selection made

            string msg = "Are you sure you wish to remove the reference to " + select.GetName() + "?";
            bool confirm = DialogUtil.Confirm(msg);
            if (confirm)
            {
                cnf.RemoveRepoDetails(select);
                RefreshList();
            }
        }

        private void ComboBoxAvailableServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = ComboBoxAvailableServers.SelectedIndex;
            ServersConfig cnf = ServersConfig.GetInstance();
            ServerDetails serv = cnf.GetServerDetailsByIndex(i);
            if (serv == null) return;
            cnf.SetSelectedByIndex(i);
            ReposConfig rcnf = ReposConfig.GetInstance();
            RepoDetails repo = rcnf.GetSelected();
            if (repo == null) return;
            repo.SetServer( cnf.GetSelected().GetName() );
        }

        private void ListBoxRepos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = (ListBox)sender;
            if (lb == null) return;
            object item = lb.SelectedItem;
            if (item == null) return;
            selected = item.ToString();
            ReposConfig cnf = ReposConfig.GetInstance();
            var sd = cnf.GetRepoDetailsByName(selected);
            cnf.SetSelected(sd);
            SetTextBoxText(sd.GetName(), sd.GetServer(), sd.GetRemote(), sd.GetLocal());
        }

        private void ButtonAddRepository_Click(object sender, EventArgs e)
        {
            string res = DialogUtil.BrowseFolder();
            if (res == null) return;
            if (FileUtil.Exists(res))
            {
                if (!FileUtil.Exists(res+@"\.git"))
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

        private void ButtonNewRepo_Click(object sender, EventArgs e)
        {
            new FormNewRepo().ShowDialog();
            EventManager.Fire(EventCode.REFRESH_REPOS);
        }
    }
}
