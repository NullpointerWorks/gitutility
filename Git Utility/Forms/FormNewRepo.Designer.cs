namespace GitUtility.Forms
{
    partial class FormNewRepo
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
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.TextBoxRepoName = new System.Windows.Forms.TextBox();
            this.ButtonAccept = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxLocalDirectory = new System.Windows.Forms.TextBox();
            this.ButtonBrowse = new System.Windows.Forms.Button();
            this.ComboBoxSelectServer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(262, 131);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(82, 32);
            this.ButtonCancel.TabIndex = 6;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // TextBoxRepoName
            // 
            this.TextBoxRepoName.ForeColor = System.Drawing.Color.Gray;
            this.TextBoxRepoName.Location = new System.Drawing.Point(12, 25);
            this.TextBoxRepoName.Name = "TextBoxRepoName";
            this.TextBoxRepoName.Size = new System.Drawing.Size(332, 20);
            this.TextBoxRepoName.TabIndex = 1;
            this.TextBoxRepoName.Text = "Repository Name";
            this.TextBoxRepoName.Click += new System.EventHandler(this.TextBoxRepoName_Clicked);
            this.TextBoxRepoName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxRepoName_KeyPress);
            this.TextBoxRepoName.Validated += new System.EventHandler(this.TextBoxRepoName_Validate);
            // 
            // ButtonAccept
            // 
            this.ButtonAccept.Location = new System.Drawing.Point(145, 131);
            this.ButtonAccept.Name = "ButtonAccept";
            this.ButtonAccept.Size = new System.Drawing.Size(111, 32);
            this.ButtonAccept.TabIndex = 5;
            this.ButtonAccept.Text = "Create Repository";
            this.ButtonAccept.UseVisualStyleBackColor = true;
            this.ButtonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Local Directory";
            // 
            // TextBoxLocalDirectory
            // 
            this.TextBoxLocalDirectory.Location = new System.Drawing.Point(12, 65);
            this.TextBoxLocalDirectory.Name = "TextBoxLocalDirectory";
            this.TextBoxLocalDirectory.Size = new System.Drawing.Size(302, 20);
            this.TextBoxLocalDirectory.TabIndex = 2;
            // 
            // ButtonBrowse
            // 
            this.ButtonBrowse.Location = new System.Drawing.Point(320, 65);
            this.ButtonBrowse.Name = "ButtonBrowse";
            this.ButtonBrowse.Size = new System.Drawing.Size(24, 20);
            this.ButtonBrowse.TabIndex = 3;
            this.ButtonBrowse.Text = "...";
            this.ButtonBrowse.UseVisualStyleBackColor = true;
            this.ButtonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // ComboBoxSelectServer
            // 
            this.ComboBoxSelectServer.FormattingEnabled = true;
            this.ComboBoxSelectServer.Location = new System.Drawing.Point(12, 104);
            this.ComboBoxSelectServer.Name = "ComboBoxSelectServer";
            this.ComboBoxSelectServer.Size = new System.Drawing.Size(332, 21);
            this.ComboBoxSelectServer.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Server";
            // 
            // FormNewRepo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 171);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ComboBoxSelectServer);
            this.Controls.Add(this.ButtonBrowse);
            this.Controls.Add(this.TextBoxLocalDirectory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonAccept);
            this.Controls.Add(this.TextBoxRepoName);
            this.Controls.Add(this.ButtonCancel);
            this.Name = "FormNewRepo";
            this.Text = "New Repository";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNewRepo_Closing);
            this.Load += new System.EventHandler(this.FormNewRepo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.TextBox TextBoxRepoName;
        private System.Windows.Forms.Button ButtonAccept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxLocalDirectory;
        private System.Windows.Forms.Button ButtonBrowse;
        private System.Windows.Forms.ComboBox ComboBoxSelectServer;
        private System.Windows.Forms.Label label3;
    }
}