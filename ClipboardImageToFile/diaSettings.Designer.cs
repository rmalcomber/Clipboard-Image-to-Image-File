namespace ClipboardImageToFile {
    partial class diaSettings {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(diaSettings));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.cbFileType = new System.Windows.Forms.ComboBox();
            this.cbCopyFilePath = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bntBrowesLocattion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtExportLocation = new System.Windows.Forms.TextBox();
            this.cbAutoUpload = new System.Windows.Forms.CheckBox();
            this.cbAskToUpload = new System.Windows.Forms.CheckBox();
            this.cbAfterUpload = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.84746F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.15254F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnApply, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(132, 150);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(247, 29);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(164, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(85, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(73, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(3, 3);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Visible = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // cbFileType
            // 
            this.cbFileType.FormattingEnabled = true;
            this.cbFileType.Location = new System.Drawing.Point(95, 38);
            this.cbFileType.Name = "cbFileType";
            this.cbFileType.Size = new System.Drawing.Size(82, 21);
            this.cbFileType.TabIndex = 17;
            this.cbFileType.SelectedIndexChanged += new System.EventHandler(this.valuehaschanged);
            // 
            // cbCopyFilePath
            // 
            this.cbCopyFilePath.AutoSize = true;
            this.cbCopyFilePath.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbCopyFilePath.Location = new System.Drawing.Point(12, 68);
            this.cbCopyFilePath.Name = "cbCopyFilePath";
            this.cbCopyFilePath.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbCopyFilePath.Size = new System.Drawing.Size(90, 17);
            this.cbCopyFilePath.TabIndex = 16;
            this.cbCopyFilePath.Text = "Copy file path";
            this.cbCopyFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbCopyFilePath.UseVisualStyleBackColor = true;
            this.cbCopyFilePath.Click += new System.EventHandler(this.valuehaschanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Format:";
            // 
            // bntBrowesLocattion
            // 
            this.bntBrowesLocattion.Location = new System.Drawing.Point(277, 12);
            this.bntBrowesLocattion.Name = "bntBrowesLocattion";
            this.bntBrowesLocattion.Size = new System.Drawing.Size(26, 20);
            this.bntBrowesLocattion.TabIndex = 14;
            this.bntBrowesLocattion.Text = "...";
            this.bntBrowesLocattion.UseVisualStyleBackColor = true;
            this.bntBrowesLocattion.Click += new System.EventHandler(this.bntBrowesLocattion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Export location:";
            // 
            // txtExportLocation
            // 
            this.txtExportLocation.Location = new System.Drawing.Point(95, 12);
            this.txtExportLocation.Name = "txtExportLocation";
            this.txtExportLocation.Size = new System.Drawing.Size(178, 20);
            this.txtExportLocation.TabIndex = 12;
            this.txtExportLocation.TextChanged += new System.EventHandler(this.valuehaschanged);
            // 
            // cbAutoUpload
            // 
            this.cbAutoUpload.AutoSize = true;
            this.cbAutoUpload.Location = new System.Drawing.Point(12, 91);
            this.cbAutoUpload.Name = "cbAutoUpload";
            this.cbAutoUpload.Size = new System.Drawing.Size(130, 17);
            this.cbAutoUpload.TabIndex = 18;
            this.cbAutoUpload.Text = "Auto Upload To Imgur";
            this.cbAutoUpload.UseVisualStyleBackColor = true;
            this.cbAutoUpload.Click += new System.EventHandler(this.valuehaschanged);
            // 
            // cbAskToUpload
            // 
            this.cbAskToUpload.AutoSize = true;
            this.cbAskToUpload.Location = new System.Drawing.Point(12, 114);
            this.cbAskToUpload.Name = "cbAskToUpload";
            this.cbAskToUpload.Size = new System.Drawing.Size(97, 17);
            this.cbAskToUpload.TabIndex = 19;
            this.cbAskToUpload.Text = "Ask To Upload";
            this.cbAskToUpload.UseVisualStyleBackColor = true;
            this.cbAskToUpload.Click += new System.EventHandler(this.valuehaschanged);
            // 
            // cbAfterUpload
            // 
            this.cbAfterUpload.FormattingEnabled = true;
            this.cbAfterUpload.Location = new System.Drawing.Point(252, 110);
            this.cbAfterUpload.Name = "cbAfterUpload";
            this.cbAfterUpload.Size = new System.Drawing.Size(121, 21);
            this.cbAfterUpload.TabIndex = 20;
            this.cbAfterUpload.SelectedIndexChanged += new System.EventHandler(this.valuehaschanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "After Upload:";
            // 
            // diaSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 191);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbAfterUpload);
            this.Controls.Add(this.cbAskToUpload);
            this.Controls.Add(this.cbAutoUpload);
            this.Controls.Add(this.cbFileType);
            this.Controls.Add(this.cbCopyFilePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bntBrowesLocattion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtExportLocation);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "diaSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "diaSettings";
            this.Load += new System.EventHandler(this.diaSettings_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ComboBox cbFileType;
        private System.Windows.Forms.CheckBox cbCopyFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bntBrowesLocattion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExportLocation;
        private System.Windows.Forms.CheckBox cbAutoUpload;
        private System.Windows.Forms.CheckBox cbAskToUpload;
        private System.Windows.Forms.ComboBox cbAfterUpload;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}