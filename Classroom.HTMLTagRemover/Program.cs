using HtmlAgilityPack;
namespace Classroom.HTMLTagRemover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please enter an HTML string to clean:\r\n ");
                var response = Console.ReadLine();
                Console.WriteLine("Processing...");
                RemoveHtmlTags(response);
                Console.WriteLine();
                Console.WriteLine("Would you like to clean another HTML string? (yes/no):\r\n");
                var userResponse = Console.ReadLine();
                if (userResponse != null && (userResponse.ToLower() == "no" || userResponse.ToLower() == "yes"))
                {
                    if (userResponse.ToLower() == "no")
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter only yes or no");
                }
            }
        }
        static void RemoveHtmlTags(string htmlTags)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlTags);
            string cleanText = doc.DocumentNode.InnerText;

            Console.WriteLine("Original HTML String: ");
            Console.WriteLine(htmlTags);
            Console.WriteLine();
            Console.WriteLine("Cleaned Text:\r\n");
            Console.WriteLine($"{cleanText}");
        }
    }
}