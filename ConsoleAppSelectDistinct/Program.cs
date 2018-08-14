using System;
using System.Linq;

namespace ConsoleAppSelectDistinct
{
    class Program
    {
        static void Main(string[] args)
        {
            var categorias = CategoriaCarga.Carga();
            var skus = categorias.SelectMany(x => x.Produtos.Select(p => p.Sku)).Distinct().ToArray();
            
            string texto = string.Empty;
            foreach (var s in skus)
                texto += $"-{s}-";

            Console.WriteLine(texto);
            Console.ReadKey();
        }
    }
}
