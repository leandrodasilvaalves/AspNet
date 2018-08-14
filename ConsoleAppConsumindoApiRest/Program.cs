using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConsoleAppConsumindoApiRest
{
    class Program
    {
        private static HttpClient _httpClient;        

        static void Main(string[] args)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var paramentros = new long[] { 11823353, 8753332, 11264150, 12033778, 11116874, 11782659, 11639778, 4101207, 4450486, 11478745 };
            var produtos = ListarProdutos(paramentros).Result.ToList();
            produtos.ForEach(x => Console.WriteLine(x.ToString()));
            
            Console.ReadKey();
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
            string parametrosUrl = string.Empty;

            for (var i = 0; i < skus.Length; i++)
                parametrosUrl += i < skus.Length -1 ? $"ids={skus[i]}&" : $"ids={skus[i]}";

            return parametrosUrl;
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

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
