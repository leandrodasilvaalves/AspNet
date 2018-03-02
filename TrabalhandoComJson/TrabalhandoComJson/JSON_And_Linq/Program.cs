using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace JSON_And_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            ExemploDoSite();
            ProcessarJsonAPI();
            Console.ReadKey();
        }
        static void ProcessarJsonAPI()
        {
            IList<Post> posts = JsonConvert.SerializeObject<Post>(GetPost);
        }

        static string GetPost()
        {
            string url = "https://jsonplaceholder.typicode.com/posts/";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                return reader.ReadToEnd();
            }
        }

        static void ExemploDoSite()
        {
            string json = @"{
              'channel': {
                'title': 'James Newton-King',
                'link': 'http://james.newtonking.com',
                'description': 'James Newton-King\'s blog.',
                'item': [
                  {
                    'title': 'Json.NET 1.3 + New license + Now on CodePlex',
                    'description': 'Annoucing the release of Json.NET 1.3, the MIT license and the source on CodePlex',
                    'link': 'http://james.newtonking.com/projects/json-net.aspx',
                    'categories': [
                      'Json.NET',
                      'CodePlex'
                    ]
                  },
                  {
                    'title': 'LINQ to JSON beta',
                    'description': 'Annoucing LINQ to JSON',
                    'link': 'http://james.newtonking.com/projects/json-net.aspx',
                    'categories': [
                      'Json.NET',
                      'LINQ'
                    ]
                  }
                ]
              }
            }";

            JObject rss = JObject.Parse(json);

            string rssTitle = (string)rss["channel"]["title"];
            Console.WriteLine(rssTitle);
            // James Newton-King

            string itemTitle = (string)rss["channel"]["item"][0]["title"];
            Console.WriteLine(itemTitle);
            // Json.NET 1.3 + New license + Now on CodePlex

            JArray categories = (JArray)rss["channel"]["item"][0]["categories"];
            // ["Json.NET", "CodePlex"]

            IList<string> categoriesText = categories.Select(c => (string)c).ToList();
            // Json.NET
            // CodePlex

            foreach (var cat in categoriesText)
            {
                Console.WriteLine(cat);
            }

        }


    }
}
