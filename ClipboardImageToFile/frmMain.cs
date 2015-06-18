#region Using statements
using ClipboardImageToFile.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace ClipboardImageToFile {


    public partial class frmMain : Form {

        #region Global Declarations

        private bool tmrEnabled = false;
        private Settings settings;
        private bool RealExit = false;
        private string FileExtension = ".jpg";
        private Image img;

        private const string DisabledText = "Disable";
        private const string EnabledText = "Enable";
        

        #endregion

        //Constructor
        public frmMain() {
            InitializeComponent();
            settings = Properties.Settings.Default;
            tmrPoll.Interval = settings.PollingTime;
            this.WindowState = FormWindowState.Minimized;
            img = new Bitmap(10, 10);


#if DEBUG
            settings.Reset();
#endif 


#if RELEASE
            
            if (settings.FirstTime) {
                string dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (Directory.Exists(dir))
                    settings.ExportLocation = dir;
                settings.Save();
                    
            }
#endif


        }

        #region Timers

        //Checking the current status of the Poll timer and update the relevant places
        private void StatusCheck_Tick(object sender, EventArgs e) {

            btnRun.Text = StatusText();
            enableToolStripMenuItem.Text = StatusText();
            toolStripStatusLabel1.Text = ActualStatusText();
            not.Text = String.Format(not.Text, ActualStatusText());
            menuStripStatus.Text = ActualStatusText();

        }

        //Main timer to check the clipboard
        private void tmrPoll_Tick(object sender, EventArgs e) {

            toolStripStatusLabel1.Text = "Status: Running";
            CheckClipboard();
           
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the current status
        /// </summary>
        /// <returns>the text form of Enabled or Disabled</returns>
        private string StatusText() {
            if (tmrEnabled)
                return DisabledText;

            else
                return EnabledText;

        }

        /// <summary>
        /// Returns some more status text based on the poll timer running
        /// </summary>
        /// <returns>Status: {Status}</returns>
        private string ActualStatusText() {
            if (tmrEnabled)
                return "Status: Running";
            else
                return "Status: Not Running";
        }

        /// <summary>
        /// Checks the clipboard for any images, if there is an image save it. 
        /// </summary>
        private void CheckClipboard() {
            if (Clipboard.ContainsImage()) {

                //Storing the image from the clipboard
                img = Clipboard.GetImage();

                //Clear the clipboard of the entire, otherwise it loop on the next poll. (Maybe some better way of checking)
                Clipboard.Clear();

                //Get the file name
                string filePath = settings.ExportLocation + "/" + DateTime.Now.ToString("yyyyMMddhhmmssff");

                //Increment the filename if already exists. This should never happen though. 
                int count = 0;
                while (File.Exists(filePath + FileExtension)) {
                    count++;
                    if (count > 0)
                        filePath += "_" + count.ToString();
                }

                //Cast image to new bitmap to stop Surrogate bug 
                Bitmap bmp = new Bitmap(img);

                //Save out the file
                bmp.Save(filePath + FileExtension, System.Drawing.Imaging.ImageFormat.Jpeg);
                bmp.Dispose();
                img.Dispose();

            }
        }

        //Enable or Disable the timer, and save its current state to settings.
        private void Run() {
            tmrPoll.Enabled = tmrEnabled;
            settings.tmrEnabled = tmrEnabled;
            settings.Save();
        }

        //Show the form
        private void ShowSettingsform() {
            this.WindowState = FormWindowState.Normal;
            this.Show();
            this.BringToFront();
        }

        #endregion

        #region Form Events

        // Form load
        private void Form1_Load(object sender, EventArgs e) {

            txtExportLocation.Text = settings.ExportLocation;
            txtPollingTime.Text = settings.PollingTime.ToString();
            tmrEnabled = settings.tmrEnabled;
            Run();

            //Show the settings box if the first time running the application
            if (settings.FirstTime) {
                ShowSettingsform();
                settings.FirstTime = false;
                settings.Save();
            }
        }


        //Form closing
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {

            //Capture closing event, only exit when the exit button on the context menu is used. 

            if (!RealExit) {
                e.Cancel = true;
                this.Hide();
            }

            if (img == null) {
                img.Dispose();
            }

        }

        #endregion

        #region Control Events

        // Notification Double Click Handler
        private void not_DoubleClick(object sender, EventArgs e) {
            ShowSettingsform();
        }

        // Exit Application from context strip
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            RealExit = true;
            this.Close();
        }

        // Settings option on context strip
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowSettingsform();

        }

        // Enable/Disable button on settings form
        private void btnRun_Click(object sender, EventArgs e) {
            tmrEnabled = !tmrEnabled;

            Run();
        }

        //Update settings button
        private void btn_Update_Click(object sender, EventArgs e) {

            bool hasWarning = false;
            int PollTime = tmrPoll.Interval;

            if (!int.TryParse(txtPollingTime.Text, out PollTime)) {
                MessageBox.Show(String.Format("'{0}' is not a valid polling time. Please enter a number only", txtPollingTime.Text), "Invalid Poll Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PollTime = settings.PollingTime;
                hasWarning = true;
            }
            else
                settings.PollingTime = PollTime;





            if (!Directory.Exists(txtExportLocation.Text)) {
                MessageBox.Show(String.Format(" Directory '{0}' cannot be found, please check", txtExportLocation.Text), "Can't Find Directory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hasWarning = true;
            } else
                settings.ExportLocation = txtExportLocation.Text;

            settings.Save();
            

            txtExportLocation.Text = settings.ExportLocation;
            txtPollingTime.Text = tmrPoll.Interval.ToString();
            tmrPoll.Interval = PollTime;

            if (!hasWarning)
                this.Hide();
        }

        //Browse location button
        private void bntBrowesLocattion_Click(object sender, EventArgs e) {
            folderBrowserDialog1.SelectedPath = settings.ExportLocation;
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK) {
                txtExportLocation.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        //Enable/Disable button on context menu
        private void enableToolStripMenuItem_Click(object sender, EventArgs e) {
            tmrEnabled = !tmrEnabled;
            Run();
        }

        #endregion

    }
}
