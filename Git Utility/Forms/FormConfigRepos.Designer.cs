namespace GitUtility.Forms
{
    partial class FormConfigRepos
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
            this.ListBoxRepos = new System.Windows.Forms.ListBox();
            this.ButtonRemRepo = new System.Windows.Forms.Button();
            this.ButtonSaveRepos = new System.Windows.Forms.Button();
            this.GroupBoxRepoDetail = new System.Windows.Forms.GroupBox();
            this.ComboBoxAvailableServers = new System.Windows.Forms.ComboBox();
            this.LabelLocation = new System.Windows.Forms.Label();
            this.TextBoxRemoteName = new System.Windows.Forms.TextBox();
            this.LabelRemote = new System.Windows.Forms.Label();
            this.TextBoxLocalPath = new System.Windows.Forms.TextBox();
            this.LabelServer = new System.Windows.Forms.Label();
            this.TextBoxEntryName = new System.Windows.Forms.TextBox();
            this.LabelServerName = new System.Windows.Forms.Label();
            this.ButtonAddRepository = new System.Windows.Forms.Button();
            this.ButtonNewRepo = new System.Windows.Forms.Button();
            this.GroupBoxRepoDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBoxRepos
            // 
            this.ListBoxRepos.FormattingEnabled = true;
            this.ListBoxRepos.Location = new System.Drawing.Point(12, 147);
            this.ListBoxRepos.Name = "ListBoxRepos";
            this.ListBoxRepos.Size = new System.Drawing.Size(311, 160);
            this.ListBoxRepos.TabIndex = 2;
            this.ListBoxRepos.SelectedIndexChanged += new System.EventHandler(this.ListBoxRepos_SelectedIndexChanged);
            // 
            // ButtonRemRepo
            // 
            this.ButtonRemRepo.Location = new System.Drawing.Point(171, 313);
            this.ButtonRemRepo.Name = "ButtonRemRepo";
            this.ButtonRemRepo.Size = new System.Drawing.Size(73, 27);
            this.ButtonRemRepo.TabIndex = 12;
            this.ButtonRemRepo.Text = "Remove";
            this.ButtonRemRepo.UseVisualStyleBackColor = true;
            this.ButtonRemRepo.Click += new System.EventHandler(this.ButtonRemRepo_Click);
            // 
            // ButtonSaveRepos
            // 
            this.ButtonSaveRepos.Location = new System.Drawing.Point(250, 313);
            this.ButtonSaveRepos.Name = "ButtonSaveRepos";
            this.ButtonSaveRepos.Size = new System.Drawing.Size(73, 27);
            this.ButtonSaveRepos.TabIndex = 14;
            this.ButtonSaveRepos.Text = "Save";
            this.ButtonSaveRepos.UseVisualStyleBackColor = true;
            this.ButtonSaveRepos.Click += new System.EventHandler(this.ButtonSaveRepos_Click);
            // 
            // GroupBoxRepoDetail
            // 
            this.GroupBoxRepoDetail.Controls.Add(this.ComboBoxAvailableServers);
            this.GroupBoxRepoDetail.Controls.Add(this.LabelLocation);
            this.GroupBoxRepoDetail.Controls.Add(this.TextBoxRemoteName);
            this.GroupBoxRepoDetail.Controls.Add(this.LabelRemote);
            this.GroupBoxRepoDetail.Controls.Add(this.TextBoxLocalPath);
            this.GroupBoxRepoDetail.Controls.Add(this.LabelServer);
            this.GroupBoxRepoDetail.Controls.Add(this.TextBoxEntryName);
            this.GroupBoxRepoDetail.Controls.Add(this.LabelServerName);
            this.GroupBoxRepoDetail.Location = new System.Drawing.Point(12, 12);
            this.GroupBoxRepoDetail.Name = "GroupBoxRepoDetail";
            this.GroupBoxRepoDetail.Size = new System.Drawing.Size(311, 129);
            this.GroupBoxRepoDetail.TabIndex = 15;
            this.GroupBoxRepoDetail.TabStop = false;
            this.GroupBoxRepoDetail.Text = "Repository Details";
            // 
            // ComboBoxAvailableServers
            // 
            this.ComboBoxAvailableServers.FormattingEnabled = true;
            this.ComboBoxAvailableServers.Location = new System.Drawing.Point(95, 45);
            this.ComboBoxAvailableServers.Name = "ComboBoxAvailableServers";
            this.ComboBoxAvailableServers.Size = new System.Drawing.Size(210, 21);
            this.ComboBoxAvailableServers.TabIndex = 25;
            this.ComboBoxAvailableServers.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAvailableServers_SelectedIndexChanged);
            // 
            // LabelLocation
            // 
            this.LabelLocation.AutoSize = true;
            this.LabelLocation.Location = new System.Drawing.Point(6, 101);
            this.LabelLocation.Name = "LabelLocation";
            this.LabelLocation.Size = new System.Drawing.Size(58, 13);
            this.LabelLocation.TabIndex = 24;
            this.LabelLocation.Text = "Local Path";
            // 
            // TextBoxRemoteName
            // 
            this.TextBoxRemoteName.Location = new System.Drawing.Point(95, 72);
            this.TextBoxRemoteName.Name = "TextBoxRemoteName";
            this.TextBoxRemoteName.Size = new System.Drawing.Size(210, 20);
            this.TextBoxRemoteName.TabIndex = 6;
            // 
            // LabelRemote
            // 
            this.LabelRemote.AutoSize = true;
            this.LabelRemote.Location = new System.Drawing.Point(6, 75);
            this.LabelRemote.Name = "LabelRemote";
            this.LabelRemote.Size = new System.Drawing.Size(75, 13);
            this.LabelRemote.TabIndex = 23;
            this.LabelRemote.Text = "Remote Name";
            // 
            // TextBoxLocalPath
            // 
            this.TextBoxLocalPath.Location = new System.Drawing.Point(95, 98);
            this.TextBoxLocalPath.Name = "TextBoxLocalPath";
            this.TextBoxLocalPath.Size = new System.Drawing.Size(210, 20);
            this.TextBoxLocalPath.TabIndex = 7;
            // 
            // LabelServer
            // 
            this.LabelServer.AutoSize = true;
            this.LabelServer.Location = new System.Drawing.Point(6, 49);
            this.LabelServer.Name = "LabelServer";
            this.LabelServer.Size = new System.Drawing.Size(38, 13);
            this.LabelServer.TabIndex = 16;
            this.LabelServer.Text = "Server";
            // 
            // TextBoxEntryName
            // 
            this.TextBoxEntryName.Location = new System.Drawing.Point(95, 20);
            this.TextBoxEntryName.Name = "TextBoxEntryName";
            this.TextBoxEntryName.Size = new System.Drawing.Size(210, 20);
            this.TextBoxEntryName.TabIndex = 4;
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
            // ButtonAddRepository
            // 
            this.ButtonAddRepository.Location = new System.Drawing.Point(91, 313);
            this.ButtonAddRepository.Name = "ButtonAddRepository";
            this.ButtonAddRepository.Size = new System.Drawing.Size(73, 27);
            this.ButtonAddRepository.TabIndex = 16;
            this.ButtonAddRepository.Text = "Add";
            this.ButtonAddRepository.UseVisualStyleBackColor = true;
            this.ButtonAddRepository.Click += new System.EventHandler(this.ButtonAddRepository_Click);
            // 
            // ButtonNewRepo
            // 
            this.ButtonNewRepo.Location = new System.Drawing.Point(12, 313);
            this.ButtonNewRepo.Name = "ButtonNewRepo";
            this.ButtonNewRepo.Size = new System.Drawing.Size(73, 27);
            this.ButtonNewRepo.TabIndex = 17;
            this.ButtonNewRepo.Text = "New";
            this.ButtonNewRepo.UseVisualStyleBackColor = true;
            this.ButtonNewRepo.Click += new System.EventHandler(this.ButtonNewRepo_Click);
            // 
            // FormConfigRepos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 352);
            this.Controls.Add(this.ButtonNewRepo);
            this.Controls.Add(this.ButtonAddRepository);
            this.Controls.Add(this.GroupBoxRepoDetail);
            this.Controls.Add(this.ButtonSaveRepos);
            this.Controls.Add(this.ButtonRemRepo);
            this.Controls.Add(this.ListBoxRepos);
            this.Name = "FormConfigRepos";
            this.Text = "Configure Repositories";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormConfigRepos_FormClosing);
            this.Load += new System.EventHandler(this.FormRepositories_Load);
            this.GroupBoxRepoDetail.ResumeLayout(false);
            this.GroupBoxRepoDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxRepos;
        private System.Windows.Forms.Button ButtonRemRepo;
        private System.Windows.Forms.Button ButtonSaveRepos;
        private System.Windows.Forms.GroupBox GroupBoxRepoDetail;
        private System.Windows.Forms.Label LabelLocation;
        private System.Windows.Forms.TextBox TextBoxRemoteName;
        private System.Windows.Forms.Label LabelRemote;
        private System.Windows.Forms.TextBox TextBoxLocalPath;
        private System.Windows.Forms.Label LabelServer;
        private System.Windows.Forms.TextBox TextBoxEntryName;
        private System.Windows.Forms.Label LabelServerName;
        private System.Windows.Forms.ComboBox ComboBoxAvailableServers;
        private System.Windows.Forms.Button ButtonAddRepository;
        private System.Windows.Forms.Button ButtonNewRepo;
    }
}