namespace GitUtility.Forms
{
    partial class FormTerminal
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
            this.GroupBoxSelectServer = new System.Windows.Forms.GroupBox();
            this.ComboBoxSelectServer = new System.Windows.Forms.ComboBox();
            this.ButtonConnect = new System.Windows.Forms.Button();
            this.ButtonConsoleSend = new System.Windows.Forms.Button();
            this.TextBoxConsoleCommand = new System.Windows.Forms.TextBox();
            this.TextBoxConsoleOut = new System.Windows.Forms.TextBox();
            this.GroupBoxSelectServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBoxSelectServer
            // 
            this.GroupBoxSelectServer.Controls.Add(this.ComboBoxSelectServer);
            this.GroupBoxSelectServer.Controls.Add(this.ButtonConnect);
            this.GroupBoxSelectServer.Location = new System.Drawing.Point(12, 12);
            this.GroupBoxSelectServer.Name = "GroupBoxSelectServer";
            this.GroupBoxSelectServer.Size = new System.Drawing.Size(511, 60);
            this.GroupBoxSelectServer.TabIndex = 18;
            this.GroupBoxSelectServer.TabStop = false;
            this.GroupBoxSelectServer.Text = "Select Server";
            // 
            // ComboBoxSelectServer
            // 
            this.ComboBoxSelectServer.FormattingEnabled = true;
            this.ComboBoxSelectServer.Location = new System.Drawing.Point(6, 22);
            this.ComboBoxSelectServer.Name = "ComboBoxSelectServer";
            this.ComboBoxSelectServer.Size = new System.Drawing.Size(420, 21);
            this.ComboBoxSelectServer.TabIndex = 15;
            this.ComboBoxSelectServer.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectServer_SelectedIndexChanged);
            this.ComboBoxSelectServer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComboBoxSelectServer_MouseDown);
            // 
            // ButtonConnect
            // 
            this.ButtonConnect.Location = new System.Drawing.Point(432, 22);
            this.ButtonConnect.Name = "ButtonConnect";
            this.ButtonConnect.Size = new System.Drawing.Size(72, 21);
            this.ButtonConnect.TabIndex = 7;
            this.ButtonConnect.Text = "Connect";
            this.ButtonConnect.UseVisualStyleBackColor = true;
            this.ButtonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // ButtonConsoleSend
            // 
            this.ButtonConsoleSend.Location = new System.Drawing.Point(465, 339);
            this.ButtonConsoleSend.Name = "ButtonConsoleSend";
            this.ButtonConsoleSend.Size = new System.Drawing.Size(52, 20);
            this.ButtonConsoleSend.TabIndex = 21;
            this.ButtonConsoleSend.Text = "Send";
            this.ButtonConsoleSend.UseVisualStyleBackColor = true;
            // 
            // TextBoxConsoleCommand
            // 
            this.TextBoxConsoleCommand.Location = new System.Drawing.Point(18, 339);
            this.TextBoxConsoleCommand.Name = "TextBoxConsoleCommand";
            this.TextBoxConsoleCommand.Size = new System.Drawing.Size(442, 20);
            this.TextBoxConsoleCommand.TabIndex = 20;
            this.TextBoxConsoleCommand.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxConsoleCommand_KeyUp);
            // 
            // TextBoxConsoleOut
            // 
            this.TextBoxConsoleOut.Location = new System.Drawing.Point(18, 78);
            this.TextBoxConsoleOut.Multiline = true;
            this.TextBoxConsoleOut.Name = "TextBoxConsoleOut";
            this.TextBoxConsoleOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxConsoleOut.Size = new System.Drawing.Size(499, 255);
            this.TextBoxConsoleOut.TabIndex = 19;
            // 
            // FormTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 373);
            this.Controls.Add(this.ButtonConsoleSend);
            this.Controls.Add(this.TextBoxConsoleCommand);
            this.Controls.Add(this.TextBoxConsoleOut);
            this.Controls.Add(this.GroupBoxSelectServer);
            this.Name = "FormTerminal";
            this.Text = "Terminal";
            this.GroupBoxSelectServer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxSelectServer;
        private System.Windows.Forms.ComboBox ComboBoxSelectServer;
        private System.Windows.Forms.Button ButtonConnect;
        private System.Windows.Forms.Button ButtonConsoleSend;
        private System.Windows.Forms.TextBox TextBoxConsoleCommand;
        private System.Windows.Forms.TextBox TextBoxConsoleOut;
    }
}