using GitUtility.Config;
using GitUtility.Event;
using GitUtility.Util;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GitUtility.Forms
{
    public partial class FormConfigServers : Form, IEventListener
    {
        private string selected = "";

        public FormConfigServers()
        {
            InitializeComponent();
            FileUtil.SetGitIcon(this);
            EventManager.GetInstance().AddListener(this);
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // no resize
            this.MaximizeBox = this.MinimizeBox = false; // removes the resize buttons
        }

        /// <summary>
        /// if the selected item still exists in the list, auto select it
        /// </summary>
        private void AutoSelect()
        {
            ServersConfig cnf = ServersConfig.GetInstance();
            var sd = cnf.GetSelected();
            if (sd!=null)
            {
                selected = sd.GetName();
                ListBoxServers.SelectedItem = selected;
            }
        }

        /// <summary>
        /// refreshes the listbox
        /// </summary>
        private void RefreshList()
        {
            ListBoxServers.Items.Clear();
            ServersConfig cnf = ServersConfig.GetInstance();
            Iterator<ServerDetails> itsd = cnf.GetServerDetails();
            while (itsd.HasNext())
            {
                ServerDetails sd = itsd.GetNext();
                ListBoxServers.Items.Add(sd.GetName());
            }
        }

        /// <summary>
        /// refreshes the font color of the textboxes to black
        /// </summary>
        private void RefreshTextBoxes()
        {
            TextBoxServerName.ForeColor = Color.Black;
            TextBoxServerAddress.ForeColor = Color.Black;
            TextBoxServerLocation.ForeColor = Color.Black;
            TextBoxServerUser.ForeColor = Color.Black;
            TextBoxServerPass.ForeColor = Color.Black;
        }

        /// <summary>
        /// set the text of all the texboxes in the form
        /// </summary>
        private void SetTextBoxText(string n, string a, string l, string u, string p)
        {
            TextBoxServerName.Text = n;
            TextBoxServerAddress.Text = a;
            TextBoxServerLocation.Text = l;
            TextBoxServerUser.Text = u;
            TextBoxServerPass.Text = p;
        }

        // =================================================================
        //              Global Events - Threaded
        // =================================================================

        public void OnEvent(EventData ed)
        {
            
        }

        // =================================================================
        //          UI Events
        // =================================================================

        /// <summary>
        /// load the form
        /// </summary>
        private void ConfigServers_Load(object sender, EventArgs e)
        {
            RefreshList();
            RefreshTextBoxes();
            AutoSelect();
        }

        /// <summary>
        /// event trigger when the listbox was selected
        /// </summary>
        private void ListBoxServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = (ListBox)sender;
            if (lb == null) return;
            object item = lb.SelectedItem;
            if (item == null) return;
            selected = item.ToString();
            ServersConfig cnf = ServersConfig.GetInstance();
            var sd = cnf.GetServerDetailsByName(selected);
            cnf.SetSelected(sd);
            SetTextBoxText(sd.GetName(), sd.GetAddress(), sd.GetLocation(), sd.GetUser(), sd.GetPass());
        }

        /// <summary>
        /// 
        /// </summary>
        private void ButtonAddServer_Click(object sender, EventArgs e)
        {
            ServersConfig cnf = ServersConfig.GetInstance();
            string n = TextBoxServerName.Text;
            string a = TextBoxServerAddress.Text;
            string l = TextBoxServerLocation.Text;
            string u = TextBoxServerUser.Text;
            string p = TextBoxServerPass.Text;
            cnf.AddServerDetails(n, a, l, u, p, true);
            RefreshList();
            RefreshTextBoxes();
        }

        /// <summary>
        /// event trigger to remove a server from the list. 
        /// TODO: no confirmation is required.
        /// </summary>
        private void ButtonRemServer_Click(object sender, EventArgs e)
        {
            ServersConfig cnf = ServersConfig.GetInstance();
            cnf.RemoveServerDetails( cnf.GetSelected() );
            RefreshList();
        }
        
        private void ButtonSaveServers_Click(object sender, EventArgs e)
        {
            ServersConfig.GetInstance().Save();
            EventManager.Fire(EventCode.REFRESH_SERVERS);
        }

        private void FormConfigServers_Closing(object sender, FormClosingEventArgs e)
        {
            EventManager.GetInstance().RemoveListener(this);
            this.Dispose();
        }
    }
}
