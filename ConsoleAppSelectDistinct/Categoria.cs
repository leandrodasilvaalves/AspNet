using System.Collections.Generic;

namespace ConsoleAppSelectDistinct
{
    public class Categoria
    {
        public string Nome { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}
