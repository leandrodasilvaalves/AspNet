using System.Data.Entity;

namespace Mvc5ValidandoDecimal.Models
{
    public class Context : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public Context():base("DefaultConnection")
        {
            Database.SetInitializer<Context>(new DropCreateDatabaseIfModelChanges<Context>());
        }
    }
}