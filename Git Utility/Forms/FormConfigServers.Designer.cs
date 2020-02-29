namespace GitUtility.Forms
{
    partial class FormConfigServers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListBoxServers = new System.Windows.Forms.ListBox();
            this.ButtonRemServer = new System.Windows.Forms.Button();
            this.TextBoxServerName = new System.Windows.Forms.TextBox();
            this.LabelServerName = new System.Windows.Forms.Label();
            this.GroupBoxNewServer = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ButtonAddServer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxServerLocation = new System.Windows.Forms.TextBox();
            this.LabelLocation = new System.Windows.Forms.Label();
            this.TextBoxServerUser = new System.Windows.Forms.TextBox();
            this.TextBoxServerPass = new System.Windows.Forms.TextBox();
            this.TextBoxServerAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ButtonSaveRepos = new System.Windows.Forms.Button();
            this.GroupBoxNewServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBoxServers
            // 
            this.ListBoxServers.FormattingEnabled = true;
            this.ListBoxServers.Location = new System.Drawing.Point(12, 208);
            this.ListBoxServers.Name = "ListBoxServers";
            this.ListBoxServers.Size = new System.Drawing.Size(311, 160);
            this.ListBoxServers.TabIndex = 10;
            this.ListBoxServers.SelectedIndexChanged += new System.EventHandler(this.ListBoxServers_SelectedIndexChanged);
            // 
            // ButtonRemServer
            // 
            this.ButtonRemServer.Location = new System.Drawing.Point(12, 374);
            this.ButtonRemServer.Name = "ButtonRemServer";
            this.ButtonRemServer.Size = new System.Drawing.Size(75, 27);
            this.ButtonRemServer.TabIndex = 11;
            this.ButtonRemServer.Text = "Remove";
            this.ButtonRemServer.UseVisualStyleBackColor = true;
            this.ButtonRemServer.Click += new System.EventHandler(this.ButtonRemServer_Click);
            // 
            // TextBoxServerName
            // 
            this.TextBoxServerName.Location = new System.Drawing.Point(95, 20);
            this.TextBoxServerName.Name = "TextBoxServerName";
            this.TextBoxServerName.Size = new System.Drawing.Size(210, 20);
            this.TextBoxServerName.TabIndex = 4;
            // 
            // LabelServerName
            // 
            this.LabelServerName.AutoSize = true;
            this.LabelServerName.Location = new System.Drawing.Point(6, 23);
            this.LabelServerName.Name = "LabelServerName";
            this.LabelServerName.Size = new System.Drawing.Size(35, 13);
            this.LabelServerName.TabIndex = 9;
            this.LabelServerName.Text = "Name";
            // 
            // GroupBoxNewServer
            // 
            this.GroupBoxNewServer.Controls.Add(this.label3);
            this.GroupBoxNewServer.Controls.Add(this.ButtonAddServer);
            this.GroupBoxNewServer.Controls.Add(this.label2);
            this.GroupBoxNewServer.Controls.Add(this.TextBoxServerLocation);
            this.GroupBoxNewServer.Controls.Add(this.LabelLocation);
            this.GroupBoxNewServer.Controls.Add(this.TextBoxServerUser);
            this.GroupBoxNewServer.Controls.Add(this.TextBoxServerPass);
            this.GroupBoxNewServer.Controls.Add(this.TextBoxServerAddress);
            this.GroupBoxNewServer.Controls.Add(this.label4);
            this.GroupBoxNewServer.Controls.Add(this.TextBoxServerName);
            this.GroupBoxNewServer.Controls.Add(this.LabelServerName);
            this.GroupBoxNewServer.Location = new System.Drawing.Point(12, 12);
            this.GroupBoxNewServer.Name = "GroupBoxNewServer";
            this.GroupBoxNewServer.Size = new System.Drawing.Size(311, 190);
            this.GroupBoxNewServer.TabIndex = 12;
            this.GroupBoxNewServer.TabStop = false;
            this.GroupBoxNewServer.Text = "Server Details";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Password";
            // 
            // ButtonAddServer
            // 
            this.ButtonAddServer.Location = new System.Drawing.Point(9, 153);
            this.ButtonAddServer.Name = "ButtonAddServer";
            this.ButtonAddServer.Size = new System.Drawing.Size(75, 27);
            this.ButtonAddServer.TabIndex = 9;
            this.ButtonAddServer.Text = "Add";
            this.ButtonAddServer.UseVisualStyleBackColor = true;
            this.ButtonAddServer.Click += new System.EventHandler(this.ButtonAddServer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "User";
            // 
            // TextBoxServerLocation
            // 
            this.TextBoxServerLocation.Location = new System.Drawing.Point(95, 72);
            this.TextBoxServerLocation.Name = "TextBoxServerLocation";
            this.TextBoxServerLocation.Size = new System.Drawing.Size(210, 20);
            this.TextBoxServerLocation.TabIndex = 6;
            // 
            // LabelLocation
            // 
            this.LabelLocation.AutoSize = true;
            this.LabelLocation.Location = new System.Drawing.Point(6, 75);
            this.LabelLocation.Name = "LabelLocation";
            this.LabelLocation.Size = new System.Drawing.Size(48, 13);
            this.LabelLocation.TabIndex = 23;
            this.LabelLocation.Text = "Location";
            // 
            // TextBoxServerUser
            // 
            this.TextBoxServerUser.Location = new System.Drawing.Point(95, 98);
            this.TextBoxServerUser.Name = "TextBoxServerUser";
            this.TextBoxServerUser.Size = new System.Drawing.Size(210, 20);
            this.TextBoxServerUser.TabIndex = 7;
            // 
            // TextBoxServerPass
            // 
            this.TextBoxServerPass.Location = new System.Drawing.Point(95, 124);
            this.TextBoxServerPass.Name = "TextBoxServerPass";
            this.TextBoxServerPass.PasswordChar = '*';
            this.TextBoxServerPass.Size = new System.Drawing.Size(210, 20);
            this.TextBoxServerPass.TabIndex = 8;
            // 
            // TextBoxServerAddress
            // 
            this.TextBoxServerAddress.Location = new System.Drawing.Point(95, 46);
            this.TextBoxServerAddress.Name = "TextBoxServerAddress";
            this.TextBoxServerAddress.Size = new System.Drawing.Size(210, 20);
            this.TextBoxServerAddress.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "IP Address";
            // 
            // ButtonSaveRepos
            // 
            this.ButtonSaveRepos.Location = new System.Drawing.Point(248, 374);
            this.ButtonSaveRepos.Name = "ButtonSaveRepos";
            this.ButtonSaveRepos.Size = new System.Drawing.Size(75, 27);
            this.ButtonSaveRepos.TabIndex = 13;
            this.ButtonSaveRepos.Text = "Save";
            this.ButtonSaveRepos.UseVisualStyleBackColor = true;
            this.ButtonSaveRepos.Click += new System.EventHandler(this.ButtonSaveServers_Click);
            // 
            // FormConfigServers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 413);
            this.Controls.Add(this.ButtonSaveRepos);
            this.Controls.Add(this.GroupBoxNewServer);
            this.Controls.Add(this.ListBoxServers);
            this.Controls.Add(this.ButtonRemServer);
            this.Name = "FormConfigServers";
            this.Text = "Configure SSH Servers";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormConfigServers_Closing);
            this.Load += new System.EventHandler(this.ConfigServers_Load);
            this.GroupBoxNewServer.ResumeLayout(false);
            this.GroupBoxNewServer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox ListBoxServers;
        private System.Windows.Forms.Button ButtonRemServer;
        private System.Windows.Forms.TextBox TextBoxServerName;
        private System.Windows.Forms.Label LabelServerName;
        private System.Windows.Forms.GroupBox GroupBoxNewServer;
        private System.Windows.Forms.TextBox TextBoxServerAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ButtonAddServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxServerLocation;
        private System.Windows.Forms.Label LabelLocation;
        private System.Windows.Forms.TextBox TextBoxServerUser;
        private System.Windows.Forms.TextBox TextBoxServerPass;
        private System.Windows.Forms.Button ButtonSaveRepos;
    }
}