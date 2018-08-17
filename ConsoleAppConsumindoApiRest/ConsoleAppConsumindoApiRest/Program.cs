using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConsoleAppConsumindoApiRest
{
    class Program
    {
        private static HttpClient _httpClient;
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
            for(var i = 0; i <= qtde; i++)
            {
                var watch = Stopwatch.StartNew();

                _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var paramentros = new long[] { 11823353, 8753332, 11264150, 12033778, 11116874, 11782659, 11639778, 4101207, 4450486, 11478745 };
                var produtos = JsonConvert.SerializeObject(ListarProdutos(paramentros).Result);
                Console.WriteLine("HTTPCLIENT");
                //Console.WriteLine(produtos);

                watch.Stop();
                Console.WriteLine($"Tempo: { watch.ElapsedMilliseconds }");
                marcador.Add(watch.ElapsedMilliseconds);
            }
        }

        private static void CalcularMediaTempo()
        {
            long total = 0;
            foreach (var i in marcador)
            {
                total += i;
            }
            var media = total / marcador.Count;
            Console.WriteLine($"Tempo Total: { total }");
            Console.WriteLine($"Media: { media }");
        }

        public static async Task<ICollection<Product>> ListarProdutos(long[] skus)
        {
            var parametros = PrepararParametrosUrl(skus);
            var url = new Uri($"https://rec.extra.com.br/productdetails/api/skusdetails/getbyids?{parametros}");

            HttpResponseMessage httpResponse = await _httpClient.GetAsync(url);
            string responseData = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ICollection<Product>>(responseData);
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
