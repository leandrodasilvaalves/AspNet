using AspNetCore.Models.DataBaseModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Models.DataBaseModels.Context
{
    public class MeuContexto : DbContext
    {
        public DbSet<Categoria > Categorias { get; set; }
        
        public MeuContexto(DbContextOptions<MeuContexto> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().ToTable("categoria");

            modelBuilder.Entity<Categoria>().HasKey(c => c.Id);
            modelBuilder.Entity<Categoria>().Property(c => c.Id).HasColumnName("id");
            modelBuilder.Entity<Categoria>().Property(c => c.Descricao).HasColumnName("descricao");

            base.OnModelCreating(modelBuilder);
        }

        
    }
}
