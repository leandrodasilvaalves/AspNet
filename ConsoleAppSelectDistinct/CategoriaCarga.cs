using System.Collections.Generic;

namespace ConsoleAppSelectDistinct
{
    public static class CategoriaCarga
    {
        public static ICollection<Categoria> Carga()
        {
            return new List<Categoria>
            {
                new Categoria{
                    Nome ="aaaaa",
                    Produtos = new List<Produto>
                    {
                        new Produto{ Nome ="prod aaaaa", Sku = 1111},
                        new Produto{ Nome ="prod bbbbb", Sku = 2222},
                        new Produto{ Nome ="prod ccccc", Sku = 3333},
                        new Produto{ Nome ="prod ddddd", Sku = 4444},
                    }
                },
                new Categoria{
                    Nome ="bbbbb",
                    Produtos = new List<Produto>
                    {
                        new Produto{ Nome ="prod eeeee", Sku = 1111},
                        new Produto{ Nome ="prod fffff", Sku = 2222},
                        new Produto{ Nome ="prod ggggg", Sku = 3333},
                        new Produto{ Nome ="prod hhhhh", Sku = 4444},
                    }
                },
                new Categoria{
                    Nome ="ccccc",
                    Produtos = new List<Produto>
                    {
                        new Produto{ Nome ="prod iiiii", Sku = 1111},
                        new Produto{ Nome ="prod jjjjj", Sku = 2222},
                        new Produto{ Nome ="prod kkkkk", Sku = 3333},
                        new Produto{ Nome ="prod lllll", Sku = 4444},
                    }
                },
                new Categoria{
                    Nome ="ddddd",
                    Produtos = new List<Produto>
                    {
                        new Produto{ Nome ="prod mmmmm", Sku = 1111},
                        new Produto{ Nome ="prod nnnnn", Sku = 2222},
                        new Produto{ Nome ="prod ooooo", Sku = 3333},
                        new Produto{ Nome ="prod ppppp", Sku = 4444},
                    }
                },
                new Categoria{
                    Nome ="eeeee",
                    Produtos = new List<Produto>
                    {
                        new Produto{ Nome ="prod rrrrr", Sku = 1111},
                        new Produto{ Nome ="prod sssss", Sku = 2222},
                        new Produto{ Nome ="prod ttttt", Sku = 3333},
                        new Produto{ Nome ="prod uuuuu", Sku = 4444},
                    }
                },
                new Categoria{
                    Nome ="fffff",
                    Produtos = new List<Produto>
                    {
                        new Produto{ Nome ="prod xxxxx", Sku = 1111},
                        new Produto{ Nome ="prod yyyyy", Sku = 2222},
                        new Produto{ Nome ="prod vvvvv", Sku = 3333},
                        new Produto{ Nome ="prod wwwww", Sku = 4444},
                        new Produto{ Nome ="prod zzzzz", Sku = 5555},
                    }
                },
            };
        }
    }
}
