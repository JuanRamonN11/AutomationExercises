using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AutomationExercise
{
    public class Utility
    {
        public static string GetDownloadPath()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectRoot = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            return Path.Combine(projectRoot, "Files");
        }
        public static void CreateFile(string fileName, string fileContent)
        {

            string downloadPath = GetDownloadPath();
            string file = Path.Combine(downloadPath, fileName);
            using (FileStream fs = File.Create(file))
            {
                Byte[] title = new UTF8Encoding(true).GetBytes(fileContent);
                fs.Write(title, 0, title.Length);
            }

        }
        public static void DeleteFile(string fileName)
        {

            string downloadPath = GetDownloadPath();
            string filePathToDelete = Path.Combine(downloadPath, fileName);
            if (File.Exists(filePathToDelete))
                File.Delete(filePathToDelete);

        }

    }
}
