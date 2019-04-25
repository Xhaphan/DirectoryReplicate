using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectoryReplicate.Utility
{
    public static class DirectoryHelper
    {
        public static string GetDirectoryPathFromUser()
        {
            var dialog = new FolderBrowserDialog();
            dialog.ShowDialog();

            return !string.IsNullOrWhiteSpace(dialog.SelectedPath) ? dialog.SelectedPath : string.Empty;
        }
    }
}
