using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipboardImageToFile {
    public partial class diaSettings : Form {
        public diaSettings() {
            InitializeComponent();
        }



        private void valuehaschanged(object sender, EventArgs e) {
            btnApply.Enabled = true;
            btnApply.Visible = true;
        }
    }
}
