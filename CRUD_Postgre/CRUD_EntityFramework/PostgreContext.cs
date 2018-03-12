using System.Data.Entity;

namespace CRUD_EntityFramework
{
    public class PostgreContext : DbContext
    {        
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        public PostgreContext():base("PostgreConexao")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CargoConfig());
            modelBuilder.Configurations.Add(new FuncionarioConfig());            
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }


    }
}
