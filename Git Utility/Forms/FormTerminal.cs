using GitUtility.Config;
using GitUtility.Remote;
using GitUtility.Util;
using System;
using System.Windows.Forms;

namespace GitUtility.Forms
{
    public partial class FormTerminal : Form
    {
        private IRemote rm = null;
        private IStream st = null;

        public FormTerminal()
        {
            InitializeComponent();
            FileUtil.SetGitIcon(this);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = this.MinimizeBox = false;
        }
        
        private void AppendText(string msg)
        {
            TextBoxConsoleOut.AppendText(msg + "\n");
            TextBoxConsoleOut.SelectionStart = TextBoxConsoleOut.Text.Length; // auto-scroll down
            TextBoxConsoleOut.ScrollToCaret();
        }

        // =================================================================
        //              UI Events
        // =================================================================

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            var sd = ServersConfig.GetInstance().GetSelected();
            if (sd == null) return;
            if (rm == null)
            {
                RemoteManager rmm = RemoteManager.GetInstance();
                rm = rmm.Connect(sd);

                if (rm.IsConnected())
                {
                    st = rm.GetStream();
                    ButtonConnect.Text = "Disconnect";
                }
                return;
            }

            if (rm.IsConnected())
            {
                rm.Disconnect();
                rm = null;
                st = null;
                ButtonConnect.Text = "Connect";
            }
        }

        private void TextBoxConsoleCommand_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ButtonConsoleSend_Click(sender, null);
            }
        }

        private void TextBoxConsoleCommand_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ButtonConsoleSend_Click(sender, null);
            }
        }

        private void ButtonConsoleSend_Click(object sender, EventArgs e)
        {
            if (st == null) return;
            if (!rm.IsConnected()) return;
            string cmd = TextBoxConsoleCommand.Text;
            st.Execute(cmd);
            string line = st.Read();
            AppendText(line);
            TextBoxConsoleCommand.Text = "";
        }

        private void ComboBoxSelectServer_MouseDown(object sender, MouseEventArgs e)
        {
            var dataSource = ServersConfig.GetInstance().GetServerDetailsList();
            ComboBoxSelectServer.DataSource = dataSource;
            ComboBoxSelectServer.DisplayMember = "Name";
            ComboBoxSelectServer.ValueMember = "Details";
            ComboBoxSelectServer.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ComboBoxSelectServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ComboBoxSelectServer.SelectedIndex;
            ServersConfig.GetInstance().SetSelectedByIndex(index);
        }
    }
}
