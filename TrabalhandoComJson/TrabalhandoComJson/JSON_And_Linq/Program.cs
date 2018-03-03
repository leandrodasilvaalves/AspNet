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
            JArray rss = JArray.Parse(GetPost());

            ExampleSite();

            GetByUserId(rss, "6");

            GetById(rss, "3");

            GetByQuery(rss, "possimus");

            GetDataPagination(rss, 1, 5);
            GetDataPagination(rss, 2, 5);
            GetDataPagination(rss, 3, 5);

            GetDataPaginationQuery(rss, "possimus", 1, 2);
            GetDataPaginationQuery(rss, "possimus", 2, 2);
            GetDataPaginationQuery(rss, "possimus", 3, 2);

            DeserializeJsonLinq(rss);

            SerializeJsonLinq();

            Console.ReadKey();
        }

        static void GetByUserId(JArray rss, string id)
        {            
            var lista = (from rs in rss where rs["userId"].ToString() == id select rs);
            PrintScreen(lista);
        }

        static void GetById(JArray rss, string id)
        {
            var lista = (from rs in rss where rs["id"].ToString() == id select rs);
            PrintScreen(lista);
        }

        static void GetByQuery(JArray rss, string search)
        {
            var lista = (from rs in rss where (rs["body"].ToString().Contains(search) 
                         || rs["title"].ToString().Contains(search)) select rs);
            PrintScreen(lista);
        }

        static void GetDataPagination(JArray rss, int page, int pageSize =10)
        {
            var lista = (from rs in rss select rs).Skip((page -1) * pageSize).Take(pageSize);
            PrintScreen(lista);
        }

        static void GetDataPaginationQuery(JArray rss, string search, int page, int pageSize = 10)
        {
            var lista = (from rs in rss
                         where (rs["body"].ToString().Contains(search) || rs["title"].ToString().Contains(search))
                         select rs)
                            .Skip((page - 1) * pageSize)
                            .Take(pageSize);

            PrintScreen(lista);
        }

        static void DeserializeJsonLinq(JArray rss)
        {
            IList<Post> posts = rss.Select(p => new Post
            {
                UserId = (int)p["userId"],
                Id = (int)p["id"],
                Title = (string)p["title"],
                Body = (string)p["body"]
                
            }).ToList();

            PrintDeserializedJson(posts);
        }

        static void SerializeJsonLinq()
        {
            IList<Post> posts = new List<Post>
            {
                new Post
                {
                    UserId = 150,
                    Id = 101,
                    Title = "Title Test",
                    Body =  "This is body test to Jons serializatin with linq"
                }
            };

            JArray postArray = new JArray(
                    posts.Select(p => new JObject {
                        {"userId", p.UserId  },
                        {"id", p.Id },
                        {"title", p.Title },
                        {"body", p.Body }
                    })
                );
            PrintScreen(postArray);
        }

        static void PrintScreen(IEnumerable<JToken> lista)
        {
            foreach (var l in lista)
            {
                Console.WriteLine(l);
            }
            Console.WriteLine("Total items: {0}", lista.Count());
            PrintSeparator();
        }

        static void PrintDeserializedJson(IList<Post> posts)
        {
            foreach (var p in posts)
            {
                Console.WriteLine("UserId: {0} \nId: {1} \nTitle: {2} \nBody: {3}", p.UserId, p.Id, p.Title, p.Body);
                PrintSeparator();
            }
            
        }

        static void PrintSeparator()
        {
            Console.WriteLine("");
            Console.WriteLine(new String('-',100));
            Console.WriteLine("");
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

        static void ExampleSite()
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
            PrintSeparator();

        }


    }
}
