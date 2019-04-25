using System.IO;
using System.Linq;
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

        public static bool ValidateDirectories(string[] paths)
        {
            return paths.All(Directory.Exists);
        }

        public static async Task ReplicateDirectoryAsync(string source, string destination, bool includeSubdirectories, bool doNotDelete)
        {
            LogHandler.Log.Info($"Replication started with {includeSubdirectories} for sub directories and {doNotDelete} for do not delete.");

            await ReplicateFiles(source, destination, includeSubdirectories);

            if (!doNotDelete)
            {
                await DeleteFilesInDestination(destination, source, includeSubdirectories);
            }
        }

        private static async Task ReplicateFiles(string source, string destination, bool includeSubdirectories)
        {
            await Task.Run(() =>
            {
                var sourceFiles = source.GetFilesInfo(includeSubdirectories);
                var destinationFiles = destination.GetFilesInfo(includeSubdirectories);
                var sourceDirectories = source.GetDirectoriesInfo(includeSubdirectories);

                foreach (var sourceDirectory in sourceDirectories)
                {
                    var sourceRelativePath = sourceDirectory.FullName.Replace(source, string.Empty);
                    var pathToNewFile = destination + sourceRelativePath;
                    Directory.CreateDirectory(pathToNewFile);
                }

                foreach (var sourceFile in sourceFiles)
                {
                    var sourceRelativePath = sourceFile.FullName.Replace(source, string.Empty);
                    //File does not need to be copied to destination
                    if (!destinationFiles.All(f => f.Name != sourceFile.Name
                                                   || (f.Name == sourceFile.Name && f.Length != sourceFile.Length)
                                                   || (f.Name == sourceFile.Name &&
                                                       f.LastWriteTime != sourceFile.LastWriteTime)))
                    {
                        continue;
                    }

                    var pathToNewFile = destination + sourceRelativePath;
                    Directory.CreateDirectory(pathToNewFile.Replace(sourceFile.Name, string.Empty));

                    sourceFile.CopyTo(pathToNewFile, true);
                    LogHandler.Log.Info($"{sourceFile.FullName} copied to {pathToNewFile}");

                    //if (destinationFile == null) return true;
                }
            });
    }

        private static async Task DeleteFilesInDestination(string source, string destination, bool includeSubdirectories)
        {
            await Task.Run(() =>
            {
                var sourceFiles = source.GetFilesInfo(includeSubdirectories);
                var destinationFiles = destination.GetFilesInfo(includeSubdirectories);

                foreach (var sourceFile in sourceFiles)
                {
                    //File  needs to be deleted
                    if (destinationFiles.All(f => f.Name != sourceFile.Name))
                    {
                        sourceFile.Delete();
                        LogHandler.Log.Info($"Deleted file {sourceFile.FullName}");
                    }
                }

                var sourceDirectories = source.GetDirectoriesInfo(includeSubdirectories);

                //The reverse is to ensure we start deleting sub folders first
                foreach (var sourceDirectory in sourceDirectories.Reverse())
                {

                    var sourceRelativePath = sourceDirectory.FullName.Replace(source, string.Empty);
                    var pathToDestinationFile = destination + sourceRelativePath;
                    if (!Directory.Exists(pathToDestinationFile))
                    {
                        sourceDirectory.Delete();
                        LogHandler.Log.Info($"Deleting Directory {sourceDirectory.FullName}");
                    }
                }
            });
        }
    }
}
