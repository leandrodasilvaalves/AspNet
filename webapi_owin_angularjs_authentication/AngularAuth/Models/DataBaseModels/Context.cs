using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MySql.Data.Entity;
using MySql.Data.MySqlClient;

namespace AngularAuth.Models.DataBaseModels
{
    public class Context : DbContext
    {
        public Context():base("conexaoSql")
        {
            Database.SetInitializer<Context>(new DataContextInitialize());
        }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Produto>().ToTable("Produto");
            base.OnModelCreating(modelBuilder);
        }

    }

    public class DataContextInitialize : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            new List<Produto>
            {
                new Produto{Nome="Borracha", Preco=0.25M},
                new Produto{Nome="Caderno", Preco=2.5M},
                new Produto{ Nome="Apontador", Preco=0.75M }
            }.ForEach(p => context.Produtos.Add(p));

            base.Seed(context);
        }

    }
}