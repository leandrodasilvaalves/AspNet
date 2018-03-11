using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CrudEntityFramework
{
    public class OracleContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public OracleContext():base("OracleDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("DBUSER");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new ClienteConfiguration());
        }
    }
}
