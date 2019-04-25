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
using DirectoryReplicate.Properties;
using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;

namespace DirectoryReplicate
{
    public partial class frmReplicate : Form
    {
        private static readonly log4net.ILog Log
            = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private string _source;
        private string _destination;
        private bool _includeSubdirectories;

        public frmReplicate()
        {
            InitializeComponent();
            Log.Info("Application started!");
        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            _source = Utility.DirectoryHelper.GetDirectoryPathFromUser();
            tbxSource.Text = _source;
            Log.Info($"Source directory was set to {_source}");
        }

        private void btnBrowseDestination_Click(object sender, EventArgs e)
        {
            _destination = Utility.DirectoryHelper.GetDirectoryPathFromUser();
            tbxDestination.Text = _destination;
            Log.Info($"Destination directory was set to {_destination}");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Log.Info("Application closed...");
        }

        private void cbxSubdirectories_CheckedChanged(object sender, EventArgs e)
        {
            _includeSubdirectories = cbxSubdirectories.Checked;
        }

        private void btnReplicate_Click(object sender, EventArgs e)
        {
            if (!Utility.DirectoryHelper.ValidateDirectories(new[] {_source, _destination})
            && _source != _destination)
            {
                MessageBox.Show("The directories selected are invalid.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }


        }

        private void btnViewLog_Click(object sender, EventArgs e)
        {
            var rootAppender = ((Hierarchy)LogManager.GetRepository())
                .Root.Appenders.OfType<FileAppender>()
                .FirstOrDefault();

            if (rootAppender != null && File.Exists(rootAppender.File))
            {
                //This should open the log file with your default associated application for the extension
                Process.Start(rootAppender.File);
            }
            else
            {
                MessageBox.Show("Unable to open log file.", "Unable to open log file", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
