using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectoryReplicate
{
    public partial class frmReplicate : Form
    {
        private string source;
        private string destination;

        public frmReplicate()
        {
            InitializeComponent();
        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            var sourceFolder = new FolderBrowserDialog();
            sourceFolder.ShowDialog();
            if (!string.IsNullOrWhiteSpace(sourceFolder.SelectedPath))
            {
                source = sourceFolder.SelectedPath;
            }
        }
    }
}
