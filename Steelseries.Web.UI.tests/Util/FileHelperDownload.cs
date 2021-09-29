using System;
using System.IO;
using System.Threading;

namespace Steelseries.Web.UI.tests.Util
{
    class FileHelperDownload
    {
        public static string DownloadsPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Downloads");
        public static void WaitUntilFileIsDownloaded(string fileName) => SpinWait.SpinUntil(() => IsFileExists(fileName), 30000);

        public static void ClearDownloadsFolder()
        {
            var directory = new DirectoryInfo(DownloadsPath);
            foreach (var file in directory.GetFiles())
            {
                file.Delete();
            }
        }

        public static bool IsFileExists(string fileName) => File.Exists($"{DownloadsPath}\\{fileName}");

        public static void CreateDownloadsFolder()
        {
            var directoryInfo = new DirectoryInfo(DownloadsPath);
            if (directoryInfo.Exists)
            {
                return;
            }

            directoryInfo.Create();
        }

        public static string GetDownloadsFolderPath()
        {
            CreateDownloadsFolder();

            return DownloadsPath;
        }

    }
}
