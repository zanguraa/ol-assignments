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
            Console.WriteLine("Enter the list of URLs you want to scrape (one URL per line). Type 'done' to finish:");

            // Collect URLs from user input
            List<string> urls = new List<string>();
            string url;
            while ((url = Console.ReadLine()) != "done")
            {
                urls.Add(url);
            }

            // Fetch data from URLs asynchronously
            await ScrapeUrlsAsync(urls);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static async Task ScrapeUrlsAsync(List<string> urls)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                foreach (string url in urls)
                {
                    Console.WriteLine($"Fetching {url}...");

                    try
                    {
                        HttpResponseMessage response = await httpClient.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            string content = await response.Content.ReadAsStringAsync();
                            // Display or process the scraped data as needed
                            Console.WriteLine($"Scraped data from {url}: {content.Length} characters");
                        }
                        else
                        {
                            Console.WriteLine($"Failed to fetch data from {url}. Status code: {response.StatusCode}");
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        Console.WriteLine($"Error fetching data from {url}: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An unexpected error occurred while fetching data from {url}: {ex.Message}");
                    }
                }
            }
        }
    }
}
