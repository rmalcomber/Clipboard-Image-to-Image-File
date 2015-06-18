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
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
#endregion

namespace ClipboardImageToFile {


    public partial class frmMain : Form {

        #region Global Declarations

        private bool tmrEnabled = false;
        private Settings settings;
        private bool RealExit = false;
        private Image img;

        private const string DisabledText = "Disable";
        private const string EnabledText = "Enable";

        IntPtr nextClipboardViewer;


        #endregion

        #region Dll Imports

        [DllImport("User32.dll")]
        protected static extern int SetClipboardViewer(int hWndNewViewer);
        [DllImport("User32.dll")]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        #endregion

        //Constructor
        public frmMain() {
            InitializeComponent();
            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)this.Handle);
            settings = Properties.Settings.Default;
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

        #region Methods

        /// <summary>
        /// Checks the clipboard for any images, if there is an image save it. 
        /// </summary>
        private void CheckClipboard() {
            if (Clipboard.ContainsImage()) {

                //Storing the image from the clipboard
                img = Clipboard.GetImage();

                //Get the file details.
                FileOptions fi = GetFileOption((FileType)settings.FormatType);

                //Get the file name
                string filePath = settings.ExportLocation + @"\" + DateTime.Now.ToString("yyyyMMddhhmmssff");

                //Increment the filename if already exists. This should never happen though. 
                int count = 0;
                while (File.Exists(filePath + fi.extension)) {
                    count++;
                    if (count > 0)
                        filePath += "_" + count.ToString();
                }

                //Cast image to new bitmap to stop Surrogate bug 
                Bitmap bmp = new Bitmap(img);

                //Save out the file
                bmp.Save(filePath + fi.extension, fi.format);
                bmp.Dispose();
                img.Dispose();

                //Copy filepath
                if (settings.CopyFilePath)
                    Clipboard.SetText(filePath + fi.extension);

            }
        }

        //Show the form
        private void ShowSettingsform() {
            this.WindowState = FormWindowState.Normal;
            this.Show();
            this.BringToFront();
        }

        //Gets the file type details
        private FileOptions GetFileOption(FileType ft) {

            FileOptions ret = new FileOptions();
            ret.extension = "." + Enum.GetName(typeof(FileType), ft);

            switch (ft) {
                case FileType.PNG:
                    ret.format = ImageFormat.Png;
                    break;
                case FileType.JPEG:
                    ret.format = ImageFormat.Jpeg;
                    break;
                case FileType.GIF:
                    ret.format = ImageFormat.Gif;
                    break;
                case FileType.Bitmap:
                    ret.format = ImageFormat.Bmp;
                    break;
                default:
                    ret.format = ImageFormat.Jpeg;
                    break;
            }

            return ret;

        }

        #endregion

        #region Overrides

        protected override void WndProc(ref Message m) {

            const int WM_DRAWCLIPBOARD = 0x308;
            const int WM_CHANGECBCHAIN = 0x030D;


            switch (m.Msg) {
                case WM_DRAWCLIPBOARD:
                    CheckClipboard();
                    SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;
                case WM_CHANGECBCHAIN:
                    if (m.WParam == nextClipboardViewer)
                        nextClipboardViewer = m.LParam;
                    else
                        SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;


                default:
                    base.WndProc(ref m);
                    break;
            }

        }


        #endregion

        #region Form Events

        // Form load
        private void Form1_Load(object sender, EventArgs e) {

            txtExportLocation.Text = settings.ExportLocation;

            //Show the settings box if the first time running the application
            if (settings.FirstTime) {
                ShowSettingsform();
                settings.FirstTime = false;
                settings.Save();
            }


            cbFileType.DataSource = Enum.GetNames(typeof(FileType));
            cbFileType.SelectedItem = (FileType)settings.FormatType;
            cbCopyFilePath.Checked = settings.CopyFilePath;

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


        //Update settings button
        private void btn_Update_Click(object sender, EventArgs e) {

            bool hasWarning = false;


            if (!Directory.Exists(txtExportLocation.Text)) {
                MessageBox.Show(String.Format("Directory '{0}' cannot be found, please check", txtExportLocation.Text), "Can't Find Directory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hasWarning = true;
            }
            else
                settings.ExportLocation = txtExportLocation.Text;


            FileType fi = (FileType)settings.FormatType;

            if (cbFileType.SelectedValue == null) {
                MessageBox.Show(String.Format("Format option is invalid, please check.", cbFileType.SelectedText), "Can't convert to format type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hasWarning = true;
            }
            else {

                if (!Enum.TryParse<FileType>(cbFileType.SelectedValue.ToString(), out fi)) {
                    MessageBox.Show(String.Format("Option '{0}, cannot be selected as a fortmat type, please check.", cbFileType.SelectedText), "Can't convert to format type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hasWarning = true;
                }
                else
                    settings.FormatType = (int)fi;
            }


            settings.CopyFilePath = cbCopyFilePath.Checked;

            settings.Save();

            cbFileType.SelectedItem = fi;
            txtExportLocation.Text = settings.ExportLocation;



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

        #endregion

        #region classes

        private class FileOptions {

            public string extension { get; set; }
            public ImageFormat format { get; set; }

        }

        #endregion

        #region Enums

        private enum FileType {
            PNG,
            JPEG,
            GIF,
            Bitmap
        }

        #endregion

    }
}
