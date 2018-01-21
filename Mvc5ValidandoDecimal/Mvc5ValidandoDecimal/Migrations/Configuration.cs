namespace Mvc5ValidandoDecimal.Migrations
{
    using Mvc5ValidandoDecimal.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Produtos.Add(new Produto { Nome="Borracha", Preco=1.5M });
            context.Produtos.Add(new Produto { Nome = "Caneta", Preco = 1.85M });
            context.Produtos.Add(new Produto { Nome = "Lápis", Preco = 0.68M });
        }
    }
}
