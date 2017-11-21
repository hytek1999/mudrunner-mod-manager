using System.IO;
using SharpCompress.Archives;
using SharpCompress.Readers;
using SharpCompress.Writers;
using SharpCompress.Archives.Zip;

namespace Mudrunner_Mod_Manager
{
    public class ModFileReader
    {
        public static string OpenFile(string filePath, ManagerSettings settings)
        {
            string tempDirectory = GetTemporaryDirectory();
            string resultFile = string.Empty;
            var archive = ArchiveFactory.Open(filePath);

            var options = new ExtractionOptions()
            {
                ExtractFullPath = true,
                Overwrite = true
            };

            foreach (var entry in archive.Entries)
            {
                if (!entry.IsDirectory)
                {
                    entry.WriteToDirectory(tempDirectory, options);
                }
            }

            DirectoryInfo tempDirectoryInfo = new DirectoryInfo(tempDirectory);
            DirectoryInfo modFolder = GetFolder(tempDirectoryInfo, settings.Defaults.ModFolders);
            if (modFolder != null)
            {
                resultFile = CreateModFromFolder(modFolder);
            }
            else
            {
                DirectoryInfo unstructuredMapFolder = GetFolder(tempDirectoryInfo, settings.Defaults.LevelFiles);
                if (unstructuredMapFolder != null)
                {
                    if (SetupModsFolder(unstructuredMapFolder, settings.Defaults.LevelFolderName, settings.Defaults.LevelFiles))
                    {
                        resultFile = CreateModFromFolder(tempDirectoryInfo);
                    }
                }
            }

            Directory.Delete(tempDirectory, true);

            return resultFile;
        }

        private static string GetTemporaryDirectory()
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
        }

        private static DirectoryInfo GetFolder(DirectoryInfo source, string name)
        {
            if (string.Compare(source.Name, name, true) == 0) return source;
            foreach (DirectoryInfo child in source.GetDirectories())
            {
                DirectoryInfo result = GetFolder(child, name);
                if (result != null) return result; 
            }
            return null;
        }

        private static DirectoryInfo GetFolder(DirectoryInfo source, string[] searchPatterns)
        {
            bool folderMatches = false; 
            foreach (string searchPattern in searchPatterns)
            {
                folderMatches = (source.GetFiles(searchPattern).Length > 0);
                if (folderMatches) return source;
            }
            foreach (string searchPattern in searchPatterns)
            {
                folderMatches = (source.GetDirectories(searchPattern).Length > 0);
                if (folderMatches) return source;
            }

            foreach (DirectoryInfo child in source.GetDirectories())
            {
                DirectoryInfo result = GetFolder(child, searchPatterns);
                if (result != null) return result; 
            }
            return null; 
        }

        private static string CreateModFromFolder(DirectoryInfo folder)
        {
            var resultFile = Path.GetTempFileName();

            using (var archive = ZipArchive.Create())
            {
                archive.AddAllFromDirectory(folder.FullName);
                WriterOptions options = new WriterOptions(SharpCompress.Common.CompressionType.Deflate);
                archive.SaveTo(resultFile, options);
            }

            return resultFile;
        }

        private static bool SetupModsFolder(DirectoryInfo folder, string folderName, string[] searchPatterns)
        {
            string levelsFolder = Path.Combine(folder.FullName, folderName);
            Directory.CreateDirectory(levelsFolder);

            foreach (string searchPattern in searchPatterns)
            {
                foreach (FileInfo file in folder.GetFiles(searchPattern))
                {
                    string dest = Path.Combine(levelsFolder, file.Name);
                    File.Move(file.FullName, dest);
                }
            }
            return true; 
        }
    }
}
