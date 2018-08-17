using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace UsingRestSharp
{
    class Program
    {
        private static List<long> marcador;

        static void Main(string[] args)
        {
            marcador = new List<long>();
            ExecutarRequisicoes(10);
            CalcularMediaTempo();
            Console.ReadKey();
        }

        private static void ExecutarRequisicoes(int qtde)
        {
            for (var i = 0; i <= qtde; i++){

                var watch = Stopwatch.StartNew();

                var paramentros = new long[] { 11823353, 8753332, 11264150, 12033778, 11116874, 11782659, 11639778, 4101207, 4450486, 11478745 };
                var produtos = ListarProdutos(paramentros).Result;
                Console.WriteLine("REST SHARP");
                //Console.WriteLine(produtos);

                watch.Stop();
                Console.WriteLine($"Tempo: { watch.ElapsedMilliseconds }");
                marcador.Add(watch.ElapsedMilliseconds);
            }
        }

        private static void CalcularMediaTempo()
        {
            long total = 0;
            foreach(var i in marcador)
            {
                total += i;
            }
            var media = total / marcador.Count;
            Console.WriteLine($"Tempo Total: { total }");
            Console.WriteLine($"Media: { media }");
        }

        public static async Task<string> ListarProdutos(long[] skus)
        {
            var parametros = PrepararParametrosUrl(skus);
            var url = new Uri($"https://rec.extra.com.br/productdetails/api");
            
            var client = new RestClient
            {
                BaseUrl = url
            };
            var request = new RestRequest($"/skusdetails/getbyids?{ parametros }", Method.GET) { RequestFormat = DataFormat.Json};
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        private static string PrepararParametrosUrl(long[] skus)
        {
            var parametros = skus.Select(sku => $"ids={ sku }").ToArray();
            return string.Join("&", parametros);
        }
    }

    public class Product
    {
        public long ProductId { get; set; }

        public long SkuId { get; set; }

        public string ImageFileId { get; set; }

        public string ImageFile130x130Id { get; set; }

        public string ImageFile45x45Id { get; set; }

        public string ImageFile90x90Id { get; set; }

        public string ImageFile292x292Id { get; set; }

        public string ProductName { get; set; }

        public string Url { get { return $"{ Departament }/{ CategoryName }/{ SkuCategoryName }/{ LinkText }.html"; } }

        [JsonIgnore]
        public string LinkText { get; set; }

        [JsonIgnore]
        public string Departament { get; set; }

        [JsonIgnore]
        public string CategoryName { get; set; }

        [JsonIgnore]
        public string SkuCategoryName { get; set; }
    }
}
