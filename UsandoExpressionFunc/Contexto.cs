using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace UsandoExpressionFunc
{
    public class Contexto : DbContext
    {
        public Contexto():base("UsandoExpressionFunc")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Contexto>());
        }

        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
