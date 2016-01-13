using System;
using System.IO;
using System.Windows;

namespace Extender.IO
{
    public class Paths
    {
        /// <summary>
        /// Creates a relative path from one file or folder to another.
        /// From user 'Dave' on stackoverflow. https://stackoverflow.com/questions/275689/how-to-get-relative-path-from-absolute-path
        /// </summary>
        /// <param name="fromPath">Contains the directory that defines the start of the relative path.</param>
        /// <param name="toPath">Contains the path that defines the endpoint of the relative path.</param>
        /// <returns>The relative path from the start directory to the end path.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="UriFormatException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static String MakeRelativePath(String fromPath, String toPath)
        {
            if (String.IsNullOrEmpty(fromPath)) throw new ArgumentNullException("fromPath");
            if (String.IsNullOrEmpty(toPath)) throw new ArgumentNullException("toPath");

            Uri fromUri = new Uri(fromPath);
            Uri toUri = new Uri(toPath);

            if (fromUri.Scheme != toUri.Scheme) { return toPath; } // path can't be made relative.

            Uri relativeUri = fromUri.MakeRelativeUri(toUri);
            String relativePath = Uri.UnescapeDataString(relativeUri.ToString());

            if (toUri.Scheme.ToUpperInvariant() == "FILE")
            {
                relativePath = relativePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            }

            return relativePath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsLocalPath(string path)
        {
            return new Uri(path).IsFile;
        }

        /// <summary>
        /// Checks if the root drive specified in the provided path exists in the system.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>False if the drive specified in the root path is not found.</returns>
        public static bool DriveExists(string path)
        {
            return !string.IsNullOrWhiteSpace(path)             && 
                    Directory.Exists(Path.GetPathRoot(path));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool PromptDriveExists(string path)
        {
            return PromptDriveExists(path, $"The drive specified in the path '{path}' was not found in the system.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool PromptDriveExists(string path, string message)
        {
            if (DriveExists(path)) return true;


            MessageBox.Show
            (
                message,
                "Drive does not exist.",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
            return false;
        }
    }
}
