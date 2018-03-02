using Newtonsoft.Json;
using System;

namespace SerializingAndDeserializingJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessarProduto();
            Console.ReadKey();
        }

        static void ProcessarProduto()
        {
            Produto produto = new Produto()
            {
                Nome = "Abacaxi",
                Preco = 2.99M,
                Tamanho = new string[] { "Grande", "Medio", "Pequeno" }
            };

            string produtoJson = JsonConvert.SerializeObject(produto);
            Produto desProdJson = JsonConvert.DeserializeObject<Produto>(produtoJson);

            Console.WriteLine(produtoJson);
            Console.WriteLine(new String('-', 70));
            Console.WriteLine(desProdJson.Nome);
            Console.WriteLine(desProdJson.Preco);
            foreach (var t in desProdJson.Tamanho)
            {
                Console.WriteLine(t);
            }
        }

       


    }
}
