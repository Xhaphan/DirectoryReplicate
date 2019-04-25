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
        private bool includeSubdirectories;

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
                tbxSource.Text = source;
            }
        }

        private void btnBrowseDestination_Click(object sender, EventArgs e)
        {
            var destinationFolder = new FolderBrowserDialog();
            destinationFolder.ShowDialog();
            if (!string.IsNullOrWhiteSpace(destinationFolder.SelectedPath))
            {
                destination = destinationFolder.SelectedPath;
                tbxDestination.Text = source;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbxSubdirectories_CheckedChanged(object sender, EventArgs e)
        {
            includeSubdirectories = cbxSubdirectories.Checked;
        }
    }
}
