using DirectoryReplicate.Utility;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace DirectoryReplicate
{
    public partial class frmReplicate : Form
    {
        private string _source;
        private string _destination;
        private bool _includeSubdirectories;
        private bool _doNotDelete;

        public frmReplicate()
        {
            InitializeComponent();
            tbxSource.Text = Properties.Settings.Default.SourceDirectory;
            _source = tbxSource.Text;
            tbxDestination.Text = Properties.Settings.Default.DestinationDirectory;
            _destination = tbxDestination.Text;
            cbxDoNotDelete.Checked = Properties.Settings.Default.DoNotDelete;
            cbxSubdirectories.Checked = Properties.Settings.Default.IncludeSubdirectory;

            LogHandler.Log.Info("Application started!");

            /*
             * I haven't worked with WinForms in more than 5 years, so I had some refreshing to do :)
             * I did not get to the progress bar, as I ran out of time and only had one evening to do the test.
             * I did make my replicate methods Async, as to not lock up the UI thread.
             * Normally with WPF or similar, I would bind the UI to and observable property and then set the values like that
             * for the progress bar. I do remember a long time ago I used a background worked for this kind of thing.
             *
             * I also wanted to do Unit tests in NUnit, with some mock data to replicate a folder structure.
             * Unfortunately I did not get a change to do so.
             */
        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            _source = DirectoryHelper.GetDirectoryPathFromUser();
            tbxSource.Text = _source;
            Properties.Settings.Default.SourceDirectory = _source;
            LogHandler.Log.Info($"Source directory was set to {_source}");
        }

        private void btnBrowseDestination_Click(object sender, EventArgs e)
        {
            _destination = DirectoryHelper.GetDirectoryPathFromUser();
            tbxDestination.Text = _destination;
            Properties.Settings.Default.DestinationDirectory = _destination;
            LogHandler.Log.Info($"Destination directory was set to {_destination}");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            LogHandler.Log.Info("Application closed...");
        }

        private void cbxSubdirectories_CheckedChanged(object sender, EventArgs e)
        {
            _includeSubdirectories = cbxSubdirectories.Checked;
            Properties.Settings.Default.IncludeSubdirectory = _includeSubdirectories;
        }

        private async void btnReplicate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DirectoryHelper.ValidateDirectories(new[] {_source, _destination})
                    && _source != _destination)
                {
                    LogHandler.Log.Error("The directories selected were invalid.");
                    MessageBox.Show("The directories selected are invalid.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                LogHandler.Log.Info("Replication started.");
                lblStatus.Text = "Replication started";
                await DirectoryHelper.ReplicateDirectoryAsync(_source, _destination, _includeSubdirectories, _doNotDelete);
                LogHandler.Log.Info("Replication completed.");
                lblStatus.Text = "Replication completed";
            }
            catch (Exception ex)
            {
                LogHandler.Log.Error($"Exception occured while replicating - {ex.StackTrace}");
                MessageBox.Show("Error occured. Please see log file for more details", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void btnViewLog_Click(object sender, EventArgs e)
        {
            try
            {
                if (LogHandler.FileAppender != null && File.Exists(LogHandler.FileAppender.File))
                {
                    //This should open the log file with your default associated application for the extension
                    Process.Start(LogHandler.FileAppender.File);
                }
                else
                {
                    MessageBox.Show("Unable to open log file.", "Unable to open log file", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                LogHandler.Log.Error($"Exception occured trying to view log file - {ex.StackTrace}");
                MessageBox.Show("Error occured. Please see log file for more details", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void cbxDoNotDelete_CheckedChanged(object sender, EventArgs e)
        {
            _doNotDelete = cbxDoNotDelete.Checked;
            Properties.Settings.Default.DoNotDelete = _doNotDelete;
        }

        private void frmReplicate_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
