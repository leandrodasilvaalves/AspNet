namespace MVCareas.Migrations
{
    using MVCareas.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCareas.Models.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Contexto context)
        {           

            context.Categorias.AddOrUpdate(
                c => c.Descricao,
                    new Categoria {Descricao = "Horti-Fruti"},
                    new Categoria { Descricao="Frios"},
                    new Categoria { Descricao="Açougue"}
                );

            context.Produtos.AddOrUpdate(
                p => p.Nome,
                    new Produto { Nome="Banana", Preco=2, CategoriaId=1 },
                    new Produto { Nome = "Alface", Preco = 1, CategoriaId = 1 },
                    new Produto { Nome = "Uva", Preco = 5, CategoriaId = 1 },

                    new Produto { Nome="Mussarella", Preco=5, CategoriaId=2},
                    new Produto { Nome = "Presunto", Preco = 4, CategoriaId=2 },

                    new Produto { Nome = "Frango", Preco = 8, CategoriaId=3 },
                    new Produto { Nome = "Coxão Mole", Preco = 19, CategoriaId=3 },
                    new Produto { Nome = "Costela", Preco = 10, CategoriaId=3 }
                );
            
        }
    }
}
