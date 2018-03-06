using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingContractResolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Product prod = new Product
            {
                ExpiryDate = new DateTime(2018,02,18),
                Name="Widget",
                Price=9.99M,
                Sizes= new[] {"Small", "Medium", "Large"}
            };

            string json = JsonConvert.SerializeObject(prod, Formatting.Indented,
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            string jsonCustonContractResolver = JsonConvert.SerializeObject(prod, Formatting.Indented,
                new JsonSerializerSettings { ContractResolver = new ConverterContractResolver() });

            Console.WriteLine(json);
            Console.WriteLine(jsonCustonContractResolver);
            Console.ReadKey();
        }

    }
}
