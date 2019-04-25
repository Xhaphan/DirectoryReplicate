using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryReplicate.Utility
{
    static class ExtentionMethods
    {
        public static string[] GetFiles(this string path, bool includeSubdirectories)
        {
            if (!Directory.Exists(path)) return null;

            return Directory.GetFiles(path, "*.*",
                includeSubdirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        }

        public static FileInfo[] GetFilesInfo(this string path, bool includeSubdirectories)
        {
            if (!Directory.Exists(path)) return null;

            var directory = new DirectoryInfo(path);

            return directory.GetFiles("*.*",
                includeSubdirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        }

        public static DirectoryInfo[] GetDirectoriesInfo(this string path, bool includeSubdirectories)
        {
            if (!Directory.Exists(path)) return null;

            var directory = new DirectoryInfo(path);

            return directory.GetDirectories("*.*",
                includeSubdirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        }
    }
}
