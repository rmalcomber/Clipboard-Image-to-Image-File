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
using System.Net;
#endregion

namespace ClipboardImageToFile {


    public partial class frmMain : Form {

        #region Global Declarations

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

            diaSettings setdia = new diaSettings();
            setdia.ShowDialog(this);
#if DEBUG
            if (settings.FirstTime) {
                string dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (Directory.Exists(dir))
                    settings.ExportLocation = dir;
                settings.Save();

            }
#endif


#if RELEASE
            

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
                FileOptions fi = FileController.GetFileOption((global::FileType)settings.FormatType);

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

                bool performUpload = false;
                byte[] by = File.ReadAllBytes(filePath + fi.extension);

                if (settings.AutoUpload)
                    performUpload = true;
                else
                    if (settings.AskToUpload)
                        if (MessageBox.Show("Do you want to upload to imgur?", "Upload?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                            performUpload = true;
                        else
                            if (settings.CopyFilePath)
                                Clipboard.SetText(filePath + fi.extension);

                if (performUpload)
                    FileController.UploadToImgur(filePath + fi.extension, client_UploadDataCompleted);
                else
                    Clipboard.SetText(filePath + fi.extension);

            }
        }

        void client_UploadDataCompleted(object sender, UploadDataCompletedEventArgs e) {
            var response = System.Text.Encoding.Default.GetString(e.Result);
            RootObject ro = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(response);

            global::AfterUpload au = (AfterUpload)settings.AfterUpload;
            
            if (ro.success)
                switch (au) {
                    case AfterUpload.Copy_address_to_clipboard:
                        Clipboard.SetText(ro.data.link);
                        not.BalloonTipTitle = "Uploaded!";
                        not.BalloonTipText = ro.data.link;
                        not.ShowBalloonTip(5000);
                        not.Click += not_Click;
                        break;
                    case AfterUpload.Open_browser:
                        System.Diagnostics.Process.Start(ro.data.link);
                        Clipboard.SetText(ro.data.link);
                        break;
                    case AfterUpload.Nothing:
                        break;
                    default:
                        break;
                }

        }

        void not_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(not.BalloonTipText);
        }



        //Show the form
        private void ShowSettingsform() {
            diaSettings sets = new diaSettings();
            sets.ShowDialog(this);
        }

        //Gets the file type details


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



            //Show the settings box if the first time running the application
            if (settings.FirstTime) {
                diaSettings set = new diaSettings();
                set.ShowDialog(this);
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

        #endregion


    }
}
