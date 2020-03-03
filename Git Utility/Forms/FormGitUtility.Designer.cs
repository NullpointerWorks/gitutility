namespace GitUtility.Forms
{
    partial class FormGitUtility
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
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemNewRepo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemAddLocalRepo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCloneRepo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemConnections = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemConfigureServers = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemReposConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItem_OpenTerminal = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemShowVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.ComboBoxAvailableRepos = new System.Windows.Forms.ComboBox();
            this.ListBoxRepoChanges = new System.Windows.Forms.ListBox();
            this.ComboBoxBranches = new System.Windows.Forms.ComboBox();
            this.ButtonFetch = new System.Windows.Forms.Button();
            this.ButtonCommitChanges = new System.Windows.Forms.Button();
            this.TextBoxCommitMessage = new System.Windows.Forms.TextBox();
            this.TextBoxChangeDetails = new System.Windows.Forms.TextBox();
            this.ButtonPushCommits = new System.Windows.Forms.Button();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newRepositoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneRepositoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRepositoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repositoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemNewRepo,
            this.toolStripSeparator3,
            this.MenuItemAddLocalRepo,
            this.MenuItemCloneRepo,
            this.toolStripSeparator2,
            this.MenuItemExit});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.programToolStripMenuItem.Text = "File";
            // 
            // MenuItemNewRepo
            // 
            this.MenuItemNewRepo.Name = "MenuItemNewRepo";
            this.MenuItemNewRepo.Size = new System.Drawing.Size(186, 22);
            this.MenuItemNewRepo.Text = "New Repository";
            this.MenuItemNewRepo.Click += new System.EventHandler(this.MenuItemNewRepo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(183, 6);
            // 
            // MenuItemAddLocalRepo
            // 
            this.MenuItemAddLocalRepo.Name = "MenuItemAddLocalRepo";
            this.MenuItemAddLocalRepo.Size = new System.Drawing.Size(186, 22);
            this.MenuItemAddLocalRepo.Text = "Add Local Repository";
            this.MenuItemAddLocalRepo.Click += new System.EventHandler(this.MenuItemAddLocalRepo_Click);
            // 
            // MenuItemCloneRepo
            // 
            this.MenuItemCloneRepo.Enabled = false;
            this.MenuItemCloneRepo.Name = "MenuItemCloneRepo";
            this.MenuItemCloneRepo.Size = new System.Drawing.Size(186, 22);
            this.MenuItemCloneRepo.Text = "Clone Repository";
            this.MenuItemCloneRepo.Click += new System.EventHandler(this.MenuItemCloneRepo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(183, 6);
            // 
            // MenuItemExit
            // 
            this.MenuItemExit.Name = "MenuItemExit";
            this.MenuItemExit.Size = new System.Drawing.Size(186, 22);
            this.MenuItemExit.Text = "Exit";
            this.MenuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // MenuItemConnections
            // 
            this.MenuItemConnections.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemConfigureServers,
            this.MenuItemReposConfig,
            this.toolStripSeparator1,
            this.MenuItem_OpenTerminal});
            this.MenuItemConnections.Name = "MenuItemConnections";
            this.MenuItemConnections.Size = new System.Drawing.Size(72, 20);
            this.MenuItemConnections.Text = "Configure";
            // 
            // MenuItemConfigureServers
            // 
            this.MenuItemConfigureServers.Name = "MenuItemConfigureServers";
            this.MenuItemConfigureServers.Size = new System.Drawing.Size(166, 22);
            this.MenuItemConfigureServers.Text = "Servers";
            this.MenuItemConfigureServers.Click += new System.EventHandler(this.MenuItemConfigureServers_Click);
            // 
            // MenuItemReposConfig
            // 
            this.MenuItemReposConfig.Name = "MenuItemReposConfig";
            this.MenuItemReposConfig.Size = new System.Drawing.Size(166, 22);
            this.MenuItemReposConfig.Text = "Repositories";
            this.MenuItemReposConfig.Click += new System.EventHandler(this.MenuItemReposConfig_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(163, 6);
            // 
            // MenuItem_OpenTerminal
            // 
            this.MenuItem_OpenTerminal.Name = "MenuItem_OpenTerminal";
            this.MenuItem_OpenTerminal.Size = new System.Drawing.Size(166, 22);
            this.MenuItem_OpenTerminal.Text = "Terminal (buggy)";
            this.MenuItem_OpenTerminal.Click += new System.EventHandler(this.MenuItemOpenTerminal_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemShowVersion});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.aboutToolStripMenuItem.Text = "Info";
            // 
            // MenuItemShowVersion
            // 
            this.MenuItemShowVersion.Name = "MenuItemShowVersion";
            this.MenuItemShowVersion.Size = new System.Drawing.Size(113, 22);
            this.MenuItemShowVersion.Text = "Version";
            this.MenuItemShowVersion.Click += new System.EventHandler(this.MenuItemShowVersion_Click);
            // 
            // ComboBoxAvailableRepos
            // 
            this.ComboBoxAvailableRepos.FormattingEnabled = true;
            this.ComboBoxAvailableRepos.Location = new System.Drawing.Point(12, 27);
            this.ComboBoxAvailableRepos.Name = "ComboBoxAvailableRepos";
            this.ComboBoxAvailableRepos.Size = new System.Drawing.Size(197, 21);
            this.ComboBoxAvailableRepos.TabIndex = 16;
            this.ComboBoxAvailableRepos.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAvailableRepos_SelectedIndexChanged);
            // 
            // ListBoxRepoChanges
            // 
            this.ListBoxRepoChanges.FormattingEnabled = true;
            this.ListBoxRepoChanges.Location = new System.Drawing.Point(12, 54);
            this.ListBoxRepoChanges.Name = "ListBoxRepoChanges";
            this.ListBoxRepoChanges.Size = new System.Drawing.Size(197, 303);
            this.ListBoxRepoChanges.TabIndex = 20;
            this.ListBoxRepoChanges.SelectedIndexChanged += new System.EventHandler(this.ListBoxRepoChanges_SelectedIndexChanged);
            // 
            // ComboBoxBranches
            // 
            this.ComboBoxBranches.Enabled = false;
            this.ComboBoxBranches.FormattingEnabled = true;
            this.ComboBoxBranches.Location = new System.Drawing.Point(215, 27);
            this.ComboBoxBranches.Name = "ComboBoxBranches";
            this.ComboBoxBranches.Size = new System.Drawing.Size(197, 21);
            this.ComboBoxBranches.TabIndex = 21;
            // 
            // ButtonFetch
            // 
            this.ButtonFetch.Location = new System.Drawing.Point(418, 27);
            this.ButtonFetch.Name = "ButtonFetch";
            this.ButtonFetch.Size = new System.Drawing.Size(197, 21);
            this.ButtonFetch.TabIndex = 22;
            this.ButtonFetch.Text = "Fetch Origin";
            this.ButtonFetch.UseVisualStyleBackColor = true;
            this.ButtonFetch.Click += new System.EventHandler(this.ButtonFetch_Click);
            // 
            // ButtonCommitChanges
            // 
            this.ButtonCommitChanges.Location = new System.Drawing.Point(12, 462);
            this.ButtonCommitChanges.Name = "ButtonCommitChanges";
            this.ButtonCommitChanges.Size = new System.Drawing.Size(197, 21);
            this.ButtonCommitChanges.TabIndex = 23;
            this.ButtonCommitChanges.Text = "Commit Changes";
            this.ButtonCommitChanges.UseVisualStyleBackColor = true;
            this.ButtonCommitChanges.Click += new System.EventHandler(this.ButtonCommitChanges_Click);
            // 
            // TextBoxCommitMessage
            // 
            this.TextBoxCommitMessage.ForeColor = System.Drawing.Color.Gray;
            this.TextBoxCommitMessage.Location = new System.Drawing.Point(12, 363);
            this.TextBoxCommitMessage.Multiline = true;
            this.TextBoxCommitMessage.Name = "TextBoxCommitMessage";
            this.TextBoxCommitMessage.Size = new System.Drawing.Size(197, 93);
            this.TextBoxCommitMessage.TabIndex = 24;
            this.TextBoxCommitMessage.Text = "Commit Description";
            this.TextBoxCommitMessage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxCommitMessage_Clicked);
            this.TextBoxCommitMessage.Validated += new System.EventHandler(this.TextBoxCommitMessage_Validate);
            // 
            // TextBoxChangeDetails
            // 
            this.TextBoxChangeDetails.Font = new System.Drawing.Font("Consolas", 8F);
            this.TextBoxChangeDetails.Location = new System.Drawing.Point(215, 54);
            this.TextBoxChangeDetails.Multiline = true;
            this.TextBoxChangeDetails.Name = "TextBoxChangeDetails";
            this.TextBoxChangeDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBoxChangeDetails.Size = new System.Drawing.Size(399, 456);
            this.TextBoxChangeDetails.TabIndex = 25;
            // 
            // ButtonPushCommits
            // 
            this.ButtonPushCommits.Location = new System.Drawing.Point(12, 489);
            this.ButtonPushCommits.Name = "ButtonPushCommits";
            this.ButtonPushCommits.Size = new System.Drawing.Size(197, 21);
            this.ButtonPushCommits.TabIndex = 26;
            this.ButtonPushCommits.Text = "Push to Remote";
            this.ButtonPushCommits.UseVisualStyleBackColor = true;
            this.ButtonPushCommits.Click += new System.EventHandler(this.ButtonPushCommits_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem1,
            this.configurationToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(626, 24);
            this.MenuStrip.TabIndex = 27;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // programToolStripMenuItem1
            // 
            this.programToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newRepositoryToolStripMenuItem,
            this.addRepositoryToolStripMenuItem,
            this.cloneRepositoryToolStripMenuItem,
            this.toolStripSeparator4,
            this.exitToolStripMenuItem});
            this.programToolStripMenuItem1.Name = "programToolStripMenuItem1";
            this.programToolStripMenuItem1.Size = new System.Drawing.Size(65, 20);
            this.programToolStripMenuItem1.Text = "Program";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // newRepositoryToolStripMenuItem
            // 
            this.newRepositoryToolStripMenuItem.Name = "newRepositoryToolStripMenuItem";
            this.newRepositoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newRepositoryToolStripMenuItem.Text = "New Repository";
            this.newRepositoryToolStripMenuItem.Click += new System.EventHandler(this.MenuItemNewRepo_Click);
            // 
            // cloneRepositoryToolStripMenuItem
            // 
            this.cloneRepositoryToolStripMenuItem.Name = "cloneRepositoryToolStripMenuItem";
            this.cloneRepositoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cloneRepositoryToolStripMenuItem.Text = "Clone Repository";
            this.cloneRepositoryToolStripMenuItem.Click += new System.EventHandler(this.MenuItemCloneRepo_Click);
            // 
            // addRepositoryToolStripMenuItem
            // 
            this.addRepositoryToolStripMenuItem.Name = "addRepositoryToolStripMenuItem";
            this.addRepositoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addRepositoryToolStripMenuItem.Text = "Add Repository";
            this.addRepositoryToolStripMenuItem.Click += new System.EventHandler(this.MenuItemAddLocalRepo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.repositoriesToolStripMenuItem,
            this.serverToolStripMenuItem,
            this.toolStripSeparator5,
            this.terminalToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // repositoriesToolStripMenuItem
            // 
            this.repositoriesToolStripMenuItem.Name = "repositoriesToolStripMenuItem";
            this.repositoriesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.repositoriesToolStripMenuItem.Text = "Repositories";
            this.repositoriesToolStripMenuItem.Click += new System.EventHandler(this.MenuItemReposConfig_Click);
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.serverToolStripMenuItem.Text = "Server";
            this.serverToolStripMenuItem.Click += new System.EventHandler(this.MenuItemConfigureServers_Click);
            // 
            // terminalToolStripMenuItem
            // 
            this.terminalToolStripMenuItem.Name = "terminalToolStripMenuItem";
            this.terminalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.terminalToolStripMenuItem.Text = "Terminal";
            this.terminalToolStripMenuItem.Click += new System.EventHandler(this.MenuItemOpenTerminal_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.versionToolStripMenuItem.Text = "Version";
            this.versionToolStripMenuItem.Click += new System.EventHandler(this.MenuItemShowVersion_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(177, 6);
            // 
            // FormGitUtility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 521);
            this.Controls.Add(this.ButtonPushCommits);
            this.Controls.Add(this.TextBoxChangeDetails);
            this.Controls.Add(this.TextBoxCommitMessage);
            this.Controls.Add(this.ButtonCommitChanges);
            this.Controls.Add(this.ButtonFetch);
            this.Controls.Add(this.ComboBoxBranches);
            this.Controls.Add(this.ListBoxRepoChanges);
            this.Controls.Add(this.ComboBoxAvailableRepos);
            this.Controls.Add(this.MenuStrip);
            this.KeyPreview = true;
            this.Name = "FormGitUtility";
            this.Text = "Git Utility";
            this.Load += new System.EventHandler(this.FormGitUtility_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemNewRepo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCloneRepo;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAddLocalRepo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem MenuItemConnections;
        private System.Windows.Forms.ToolStripMenuItem MenuItemConfigureServers;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_OpenTerminal;
        private System.Windows.Forms.ComboBox ComboBoxAvailableRepos;
        private System.Windows.Forms.ListBox ListBoxRepoChanges;
        private System.Windows.Forms.ComboBox ComboBoxBranches;
        private System.Windows.Forms.Button ButtonFetch;
        private System.Windows.Forms.Button ButtonCommitChanges;
        private System.Windows.Forms.TextBox TextBoxCommitMessage;
        private System.Windows.Forms.TextBox TextBoxChangeDetails;
        private System.Windows.Forms.ToolStripMenuItem MenuItemReposConfig;
        private System.Windows.Forms.Button ButtonPushCommits;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemShowVersion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newRepositoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneRepositoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRepositoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repositoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}