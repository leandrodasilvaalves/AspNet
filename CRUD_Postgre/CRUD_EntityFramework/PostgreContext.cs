using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CRUD_EntityFramework
{
    public class PostgreContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }

        public PostgreContext():base("PostgreConexao")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FuncionarioConfig());
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }


    }
}
