using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncWebScraper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to Async Web Scraper!");

            do
            {
                Console.WriteLine("Enter URLs to scrape (separated by a comma):");
                string input = Console.ReadLine();

                List<string> urls = ParseUrls(input);

                await ScrapeUrlsAsync(urls);

                Console.WriteLine("\nWould you like to scrape more URLs? (yes/no):");
            } while (Console.ReadLine().Trim().ToLower() == "yes");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static List<string> ParseUrls(string input)
        {
            List<string> urls = new List<string>();

            string[] urlArray = input.Split(',');
            foreach (string url in urlArray)
            {
                urls.Add(url.Trim());
            }

            return urls;
        }

        static async Task ScrapeUrlsAsync(List<string> urls)
        {
            int successfulCount = 0;

            using (HttpClient httpClient = new HttpClient())
            {
                foreach (string url in urls)
                {
                    Console.WriteLine($"\nFetching data from {url}...");

                    try
                    {
                        HttpResponseMessage response = await httpClient.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine($"{url} - Data fetched successfully.");
                            successfulCount++;
                        }
                        else
                        {
                            Console.WriteLine($"{url} - Error: {response.StatusCode}");
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        Console.WriteLine($"{url} - Error: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{url} - An unexpected error occurred: {ex.Message}");
                    }
                }
            }

            Console.WriteLine($"\nProcessed {successfulCount} out of {urls.Count} URLs successfully.");
        }
    }
}
