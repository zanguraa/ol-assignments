namespace Classroom.DirectoryExplorer
{
    internal class Program
    {
       static string message = "Welcome to Directory Explorer.\r\n";
        static string instruction = "Please enter a directory path to list files and folders, or use commands: [NEW: Create New Directory] [DEL: Delete Directory]\r\n";
        static void Main(string[] args)
        {
            Welcome(message);
            Instruction(instruction);
           
        }
        static void Welcome(string message)
        {
            Console.WriteLine(message);
        }
        static void Instruction(string instruction)
        {
            Console.WriteLine(instruction);
        }
    }
}