using HtmlAgilityPack;

namespace Classroom.HTMLTagRemover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter an HTML string to clean:\r\n ");
            var response = Console.ReadLine();

            Console.WriteLine("Processing...");
            RemoveHtmlTags(response);
        }
        static void RemoveHtmlTags(string htmlTags)
        {
            Console.WriteLine("Original HTML String: ");
            Console.WriteLine(htmlTags);
        }
    }
}