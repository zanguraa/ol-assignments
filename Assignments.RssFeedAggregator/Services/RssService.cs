using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Net;
using System.Xml;
using Assignments.RssFeedAggregator.Db;
using Assignments.RssFeedAggregator.Models;
using Dapper;

namespace Assignments.RssFeedAggregator.Services
{
   

    namespace ProjectName.Services
    {
        public static class RssService
        {
            public static List<RssItem> GetRssItems(string rssFeedUrl)
            {
                List<RssItem> rssItems = new List<RssItem>();

                using (WebClient client = new WebClient())
                {
                    string rssContent = client.DownloadString(rssFeedUrl);

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(rssContent);

                    XmlNodeList itemNodes = xmlDoc.SelectNodes("//item");

                    foreach (XmlNode itemNode in itemNodes)
                    {
                        string title = itemNode.SelectSingleNode("title").InnerText;
                        string link = itemNode.SelectSingleNode("link").InnerText;
                        string description = itemNode.SelectSingleNode("description").InnerText;

                        rssItems.Add(new RssItem { Title = title, Link = link, Description = description });
                    }
                }

                return rssItems;
            }

            public static void WriteRssItemsToDatabase(List<RssItem> rssItems)
            {
                using (SqlConnection connection = DataContext.GetConnection())
                {
                    connection.Open();

                    foreach (RssItem item in rssItems)
                    {
                        string insertQuery = "INSERT INTO RssItems (Title, Link, Description) VALUES (@Title, @Link, @Description)";
                        connection.Execute(insertQuery, item);
                    }
                }
            }
        }
    }

}
