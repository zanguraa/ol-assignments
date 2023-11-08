using HtmlAgilityPack;

namespace Classroom.HTMLTagRemover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Please enter html tag with text: ");
            var response = Console.ReadLine();
            
          var doc = new HtmlDocument();
            doc.LoadHtml(response);

         HtmlNode node = doc.DocumentNode.SelectSingleNode("//h1");

            Console.WriteLine(node.ToString());
        }
    }
}