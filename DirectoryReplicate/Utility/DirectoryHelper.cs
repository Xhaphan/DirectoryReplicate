using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

        public static bool ValidateDirectories(string[] paths)
        {
            return paths.All(Directory.Exists);
        }

        public static void ReplicateDirectory(string source, string destination, bool includeSubdirectories)
        {
            ReplicateFiles(source, destination, includeSubdirectories);
            DeleteFilesInDestination(destination, source, includeSubdirectories);
        }

        private static void ReplicateFiles(string source, string destination, bool includeSubdirectories)
        {
            var sourceFiles = source.GetFilesInfo(includeSubdirectories);
            var destinationFiles = destination.GetFilesInfo(includeSubdirectories);
            foreach (var sourceFile in sourceFiles)
            {
                var sourceRelativePath = sourceFile.FullName.Replace(source, string.Empty);
                //checks if there is a destination file with the same path, name, date modified and size
                //var destinationFile = destinationFiles.FirstOrDefault(f => f.Name == sourceFile.Name
                //                                                           && f.Length == sourceFile.Length
                //                                                           && f.DirectoryName == sourceFile.DirectoryName
                //                                                           && f.LastWriteTime == sourceFile.LastWriteTime);
                //File needs to be copied to destination
                if (destinationFiles.All(f => f.Name != sourceFile.Name
                                              || (f.Name == sourceFile.Name && f.Length != sourceFile.Length)
                                              || (f.Name == sourceFile.Name && f.LastWriteTime != sourceFile.LastWriteTime)))
                {
                    var pathToNewFile = destination + sourceRelativePath;
                    Directory.CreateDirectory(pathToNewFile.Replace(sourceFile.Name, string.Empty));

                    sourceFile.CopyTo(pathToNewFile, true);
                }

                //if (destinationFile == null) return true;
            }
        }

        private static void DeleteFilesInDestination(string source, string destination, bool includeSubdirectories)
        {
            var sourceFiles = source.GetFilesInfo(includeSubdirectories);
            var destinationFiles = destination.GetFilesInfo(includeSubdirectories);

            foreach (var sourceFile in sourceFiles)
            {
                var sourceRelativePath = sourceFile.FullName.Replace(source, string.Empty);
                //File  needs to be deleted
                if (destinationFiles.All(f => f.Name != sourceFile.Name))
                {
                    sourceFile.Delete();
                    //var pathToNewFile = destination + sourceRelativePath;
                    //Directory.CreateDirectory(pathToNewFile.Replace(sourceFile.Name, string.Empty));

                    //sourceFile.CopyTo(pathToNewFile, true);
                }

                //if (destinationFile == null) return true;
            }

            var sourceDirectories = source.GetDirectoriesInfo(includeSubdirectories);
            var destinationDirectories = destination.GetDirectoriesInfo(includeSubdirectories);

            foreach (var sourceDirectory in sourceDirectories)
            {
                if (destinationDirectories.Any(d => d.Name != sourceDirectory.Name))
                {
                    sourceDirectory.Delete();
                }
            }
        }

        //private static Dictionary<string, string> GetChangesBetweenDirectories(FileInfo[] sourceFiles, FileInfo[] destinationFiles)
        //{
        //var changes = new Dictionary<string, string>();
        //If the amount of files are not the same, make an early exit without wasting time
        //if (sourceFiles.Length != destinationFiles.Length) return true;

        //I opted to use a foreach instead of LINQ only, as it makes it more readable and easier to debug
        /*
         * LINQ only for the below would look like this
         * sourceFiles.Select(sourceFile => destinationFiles.FirstOrDefault(f =>
                f.Name == sourceFile.Name && f.Length == sourceFile.Length &&
                f.DirectoryName == sourceFile.DirectoryName && f.LastWriteTime == sourceFile.LastWriteTime))
            .Any(destinationFile => destinationFile == null);
         */
        //if (sourceFiles.Select(sourceFile => destinationFiles.FirstOrDefault(f =>
        //        f.Name == sourceFile.Name && f.Length == sourceFile.Length &&
        //        f.DirectoryName == sourceFile.DirectoryName && f.LastWriteTime == sourceFile.LastWriteTime))
        //    .Any(destinationFile => destinationFile == null))
        //{
        //    return true;
        //}

        //if (destinationFiles.Select(destinationFile => sourceFiles.FirstOrDefault(f =>
        //        f.Name == destinationFile.Name && f.Length == destinationFile.Length &&
        //        f.DirectoryName == destinationFile.DirectoryName && f.LastWriteTime == destinationFile.LastWriteTime))
        //    .Any(sourceFile => sourceFile == null))
        //{
        //    return true;
        //}


        //foreach (var sourceFile in sourceFiles)
        //{
        //    //checks if there is a destination file with the same path, name, date modified and size
        //    var destinationFile = destinationFiles.FirstOrDefault(f => f.Name == sourceFile.Name 
        //                                                               && f.Length == sourceFile.Length
        //                                                               && f.DirectoryName == sourceFile.DirectoryName
        //                                                               && f.LastWriteTime == sourceFile.LastWriteTime);
        //    //File does not exist
        //    if (destinationFiles.All(f => f.Name != sourceFile.Name))
        //    {
        //        sourceFile.
        //    }

        //if (destinationFile == null) return true;
        //}
        //return false;


        /*
         * After I finished the method, I wanted to know if there is a more efficient way of doing it.
         * I did then find a nice and much cleaner way of doing it with a custom comparer.
         * However, I felt like it would be cheating to use it here, since I did not come up with that solution
         * myself.
         */

        //}
    }
}
