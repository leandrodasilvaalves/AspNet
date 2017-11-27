namespace IdentityMySQLDemo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IdentityMySQLDemo.Models.DataBaseModels.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(IdentityMySQLDemo.Models.DataBaseModels.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );

            // new List<Produto>
            //        {
            //            new Produto{Nome="Borracha", Preco=0.25M},
            //            new Produto{Nome="Caderno", Preco=2.5M},
            //            new Produto{ Nome="Apontador", Preco=0.75M }
            //        }.ForEach(p => context.Produtos.Add(p));

            //        base.Seed(context);
            //

            
        }
    }
}
