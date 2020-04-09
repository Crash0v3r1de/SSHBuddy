namespace SSHBuddy
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingDNSIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkBasicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spanningTreeRapidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iPRoutingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(218, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.txtHost);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 107);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Details";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(59, 66);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(153, 20);
            this.txtPassword.TabIndex = 6;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(44, 40);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(204, 20);
            this.txtUser.TabIndex = 5;
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(44, 15);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(204, 20);
            this.txtHost.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "User:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Host:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 313);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(531, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(73, 17);
            this.lblStatus.Text = "Status: Idle...";
            // 
            // txtConsole
            // 
            this.txtConsole.Location = new System.Drawing.Point(12, 146);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.Size = new System.Drawing.Size(507, 164);
            this.txtConsole.TabIndex = 4;
            this.txtConsole.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(355, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Console Output";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.commandsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(531, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // commandsToolStripMenuItem
            // 
            this.commandsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pingDNSIPToolStripMenuItem,
            this.networkBasicsToolStripMenuItem});
            this.commandsToolStripMenuItem.Name = "commandsToolStripMenuItem";
            this.commandsToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.commandsToolStripMenuItem.Text = "Commands";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // pingDNSIPToolStripMenuItem
            // 
            this.pingDNSIPToolStripMenuItem.Name = "pingDNSIPToolStripMenuItem";
            this.pingDNSIPToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pingDNSIPToolStripMenuItem.Text = "Ping DNS/IP";
            this.pingDNSIPToolStripMenuItem.Click += new System.EventHandler(this.pingDNSIPToolStripMenuItem_Click);
            // 
            // networkBasicsToolStripMenuItem
            // 
            this.networkBasicsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spanningTreeRapidToolStripMenuItem,
            this.iPRoutingToolStripMenuItem});
            this.networkBasicsToolStripMenuItem.Name = "networkBasicsToolStripMenuItem";
            this.networkBasicsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.networkBasicsToolStripMenuItem.Text = "Network Basics";
            // 
            // spanningTreeRapidToolStripMenuItem
            // 
            this.spanningTreeRapidToolStripMenuItem.Name = "spanningTreeRapidToolStripMenuItem";
            this.spanningTreeRapidToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.spanningTreeRapidToolStripMenuItem.Text = "SpanningTree Rapid";
            this.spanningTreeRapidToolStripMenuItem.Click += new System.EventHandler(this.spanningTreeRapidToolStripMenuItem_Click);
            // 
            // iPRoutingToolStripMenuItem
            // 
            this.iPRoutingToolStripMenuItem.Name = "iPRoutingToolStripMenuItem";
            this.iPRoutingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.iPRoutingToolStripMenuItem.Text = "IP Routing";
            this.iPRoutingToolStripMenuItem.Click += new System.EventHandler(this.iPRoutingToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 335);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SSH Buddy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.RichTextBox txtConsole;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pingDNSIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem networkBasicsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spanningTreeRapidToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iPRoutingToolStripMenuItem;
    }
}

