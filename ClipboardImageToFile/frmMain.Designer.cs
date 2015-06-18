namespace ClipboardImageToFile {
    partial class frmMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tmrPoll = new System.Windows.Forms.Timer(this.components);
            this.txtExportLocation = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.bntBrowesLocattion = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPollingTime = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btn_Update = new System.Windows.Forms.Button();
            this.not = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusCheck = new System.Windows.Forms.Timer(this.components);
            this.menuStripStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrPoll
            // 
            this.tmrPoll.Tick += new System.EventHandler(this.tmrPoll_Tick);
            // 
            // txtExportLocation
            // 
            this.txtExportLocation.Location = new System.Drawing.Point(98, 12);
            this.txtExportLocation.Name = "txtExportLocation";
            this.txtExportLocation.Size = new System.Drawing.Size(178, 20);
            this.txtExportLocation.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Export location:";
            // 
            // bntBrowesLocattion
            // 
            this.bntBrowesLocattion.Location = new System.Drawing.Point(201, 38);
            this.bntBrowesLocattion.Name = "bntBrowesLocattion";
            this.bntBrowesLocattion.Size = new System.Drawing.Size(75, 23);
            this.bntBrowesLocattion.TabIndex = 2;
            this.bntBrowesLocattion.Text = "Browse...";
            this.bntBrowesLocattion.UseVisualStyleBackColor = true;
            this.bntBrowesLocattion.Click += new System.EventHandler(this.bntBrowesLocattion_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Poll Amount:";
            // 
            // txtPollingTime
            // 
            this.txtPollingTime.Location = new System.Drawing.Point(98, 58);
            this.txtPollingTime.Name = "txtPollingTime";
            this.txtPollingTime.Size = new System.Drawing.Size(31, 20);
            this.txtPollingTime.TabIndex = 4;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 112);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 5;
            this.btnRun.Text = "Enable";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 138);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(288, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(125, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(183, 112);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(93, 23);
            this.btn_Update.TabIndex = 7;
            this.btn_Update.Text = "Update Settings";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // not
            // 
            this.not.ContextMenuStrip = this.contextMenuStrip1;
            this.not.Icon = ((System.Drawing.Icon)(resources.GetObject("not.Icon")));
            this.not.Text = "Clipoboard Image to File - {0}";
            this.not.Visible = true;
            this.not.DoubleClick += new System.EventHandler(this.not_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripStatus,
            this.enableToolStripMenuItem,
            this.toolStripMenuItem1,
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 120);
            // 
            // enableToolStripMenuItem
            // 
            this.enableToolStripMenuItem.Name = "enableToolStripMenuItem";
            this.enableToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.enableToolStripMenuItem.Text = "Enable";
            this.enableToolStripMenuItem.Click += new System.EventHandler(this.enableToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // StatusCheck
            // 
            this.StatusCheck.Enabled = true;
            this.StatusCheck.Tick += new System.EventHandler(this.StatusCheck_Tick);
            // 
            // menuStripStatus
            // 
            this.menuStripStatus.Enabled = false;
            this.menuStripStatus.Name = "menuStripStatus";
            this.menuStripStatus.Size = new System.Drawing.Size(152, 22);
            this.menuStripStatus.Text = "Status: {0}";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 160);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtPollingTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bntBrowesLocattion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtExportLocation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrPoll;
        private System.Windows.Forms.TextBox txtExportLocation;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bntBrowesLocattion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPollingTime;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.NotifyIcon not;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem enableToolStripMenuItem;
        private System.Windows.Forms.Timer StatusCheck;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuStripStatus;
    }
}

