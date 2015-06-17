using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipboardImageToFile {


    public partial class Form1 : Form {

        bool tmrEnabled = false;
        Properties.Settings settings;

        private const string DisabledText = "Disable";
        private const string EnabledText = "Enable";
        bool RealExit = false;
        public Form1() {
            InitializeComponent();
            settings = Properties.Settings.Default;
            tmrPoll.Interval = settings.PollingTime;
            this.WindowState = FormWindowState.Minimized;
        }

        private void tmrPoll_Tick(object sender, EventArgs e) {

            toolStripStatusLabel1.Text = "Status: Running";

            if (Clipboard.ContainsImage()) {
                Image img = Clipboard.GetImage();
                Clipboard.Clear();


                Bitmap bm = new Bitmap(img);
                string filePath = settings.ExportLocation + "/" + DateTime.Now.ToString("yyyyMMddhhmmssff");



                bm.Save(filePath + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                Debug.WriteLine("File Saved!");

                string argument = @"/select, " + filePath;

                //System.Diagnostics.Process.Start("explorer.exe", argument);

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e) {

        }

        private void btnRun_Click(object sender, EventArgs e) {
            tmrEnabled = !tmrEnabled;

            Run();
        }

        private void Run() {

            tmrPoll.Enabled = tmrEnabled;
            settings.tmrEnabled = tmrEnabled;
            settings.Save();
        }

        private void Form1_Load(object sender, EventArgs e) {


            txtExportLocation.Text = settings.ExportLocation;
            txtPollingTime.Text = settings.PollingTime.ToString();
            tmrEnabled = settings.tmrEnabled;

            Run();


        }

        private void btn_Update_Click(object sender, EventArgs e) {
            settings.PollingTime = int.Parse(txtPollingTime.Text);
            settings.ExportLocation = txtExportLocation.Text;
            settings.Save();
            this.Hide();
        }

        private void bntBrowesLocattion_Click(object sender, EventArgs e) {
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK) {
                txtExportLocation.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void enableToolStripMenuItem_Click(object sender, EventArgs e) {
            tmrEnabled = !tmrEnabled;
            Run();
        }



        private void StatusCheck_Tick(object sender, EventArgs e) {

            btnRun.Text = StatusText();
            enableToolStripMenuItem.Text = StatusText();
            toolStripStatusLabel1.Text = ActualStatusText();


        }

        private string StatusText() {
            if (tmrEnabled)
                return DisabledText;

            else
                return EnabledText;

        }

        private string ActualStatusText() {
            if (tmrEnabled)
                return "Status: Running";
            else
                return "Status: Not Running";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            RealExit = true;
            this.Close();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if (!RealExit) { 
                e.Cancel = true;
                this.Hide();
            }
            
        }

        private void not_DoubleClick(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

    }
}
