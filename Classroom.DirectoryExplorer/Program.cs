using System.Diagnostics.Metrics;
using System.IO;

namespace Classroom.DirectoryExplorer
{
    internal class Program
    {
        static string message = "Welcome to Directory Explorer.\r\n";
        static string instruction = "Please enter a directory path to list files and folders, or use commands: [NEW: Create New Directory] [DEL: Delete Directory]\r\n";
        static string path = "";
        static void Main(string[] args)
        {
            Welcome(message);
            Instruction(instruction);
            AskUserFilePath();
            DirectoryExplorer(path);

        }
        static void Welcome(string message)
        {
            Console.WriteLine(message);
        }
        static void Instruction(string instruction)
        {
            Console.WriteLine(instruction);
        }
        private static void AskUserFilePath()
        {
            path = Console.ReadLine();
            Console.WriteLine($"\n Listing contents of: {path}");
        }
        static void DirectoryExplorer(string path)
        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine($"No subdirectories in '{path}'.");
            }

            string[] subdirectories = Directory.GetDirectories(path);
            if (subdirectories.Length > 0)
            {
                var counter = 1;
                Console.WriteLine("Folders: ");
                foreach (string subdirectory in subdirectories)
                {
                    string subdirectoryName = Path.GetFileName(subdirectory);
                    Console.WriteLine($" {counter++}.  {subdirectoryName}");
                }
            }
            string[] filesList = Directory.GetFiles(path);
            if(filesList.Length > 0)
            {
                var filesCounter = 1;
                Console.WriteLine("Files: ");
                foreach(string file in filesList)
                {
                    string fileName = Path.GetFileName(file);
                    Console.WriteLine($"{filesCounter++}. {fileName}");
                }
            }

           

        }
        static void FileExplorer(string path)
        {
           
        }
    }
}