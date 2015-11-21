using ClipboardImageToFile.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;


namespace ClipboardImageToFile {
    public partial class diaSettings : Form {


        private Settings settings;
        bool hasWarning = false;
        bool isDirty = false;

        public diaSettings() {
            InitializeComponent();
            settings = Properties.Settings.Default;
        }

        private void bntBrowesLocattion_Click(object sender, EventArgs e) {
            folderBrowserDialog1.SelectedPath = settings.ExportLocation;
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK) {
                txtExportLocation.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void LoadAllSettings() {

            txtExportLocation.Text = settings.ExportLocation;

            cbFileType.DataSource = Enum.GetNames(typeof(FileType));
            cbFileType.SelectedIndex = settings.FormatType;
            cbCopyFilePath.Checked = settings.CopyFilePath;

            cbAfterUpload.DataSource = Enum.GetNames(typeof(AfterUpload));
            cbAfterUpload.SelectedIndex = settings.AfterUpload;

            cbAutoUpload.Checked = settings.AutoUpload;
            cbAskToUpload.Checked = settings.AskToUpload;
            hasWarning = false;
            btnApply.Enabled = false;
            btnApply.Visible = true;
            isDirty = false;

        }

        private void SaveAllSettings() {


            if (!Directory.Exists(txtExportLocation.Text)) {
                MessageBox.Show(String.Format("Directory '{0}' cannot be found, please check", txtExportLocation.Text), "Can't Find Directory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hasWarning = true;
            } else
                settings.ExportLocation = txtExportLocation.Text;


            FileType fi = (FileType)settings.FormatType;

            if (cbFileType.SelectedValue == null) {
                MessageBox.Show(String.Format("Format option is invalid, please check.", cbFileType.SelectedText), "Can't convert to format type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hasWarning = true;
            } else {

                if (!Enum.TryParse<FileType>(cbFileType.SelectedValue.ToString(), out fi)) {
                    MessageBox.Show(String.Format("Option '{0}, cannot be selected as a fortmat type, please check.", cbFileType.SelectedText), "Can't convert to format type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hasWarning = true;
                } else
                    settings.FormatType = (int)fi;
            }


            settings.CopyFilePath = cbCopyFilePath.Checked;
            settings.AutoUpload = cbAutoUpload.Checked;
            settings.AskToUpload = cbAskToUpload.Checked;

            AfterUpload au = (AfterUpload)settings.AfterUpload;

            if (cbAfterUpload.SelectedValue == null) {
                MessageBox.Show(String.Format("After Upload option is invalid"), "Can't convert to after upload type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hasWarning = true;
            } else
                 if (!Enum.TryParse<AfterUpload>(cbAfterUpload.SelectedValue.ToString(), out au)) {
                    MessageBox.Show(String.Format("Option '{0}, cannot be selected as a after upload type, please check.", cbAfterUpload.SelectedText), "Can't convert to format type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hasWarning = true;
                } else
                    settings.AfterUpload = (int)au;


            settings.FirstTime = false;

            if (!hasWarning) {
                settings.Save();
                isDirty = false;
            }


        }



        private void valuehaschanged(object sender, EventArgs e) {
            btnApply.Enabled = true;
            isDirty = true;
        }

        private void diaSettings_Load(object sender, EventArgs e) {
            LoadAllSettings();
        }

        private void btnApply_Click(object sender, EventArgs e) {

            if (MessageBox.Show("Are you sure you want to save the new settings?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                SaveAllSettings();
                if (!hasWarning) {
                    LoadAllSettings();

                }
            }

        }

        private void btnOK_Click(object sender, EventArgs e) {
            if(isDirty)
                if (MessageBox.Show("Settings have not been saved, do you wish to save them?", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                    SaveAllSettings();
                    if (!hasWarning)
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                       
                }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            if (isDirty)
                if (MessageBox.Show("Settings have not been saved, do you wish to save them?", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                    SaveAllSettings();
                    if (!hasWarning)
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;

                }
        }



    }



}
