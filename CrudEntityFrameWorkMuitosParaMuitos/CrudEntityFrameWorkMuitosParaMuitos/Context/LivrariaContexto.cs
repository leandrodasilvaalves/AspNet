using CrudEntityFrameWorkMuitosParaMuitos.Entities;
using CrudEntityFrameWorkMuitosParaMuitos.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CrudEntityFrameWorkMuitosParaMuitos.Context
{
    public class LivrariaContexto : DbContext
    {
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<LivroAutor> LivrosAutores { get; set; }

        public LivrariaContexto():base("conexao")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new AutorConfiguration());
            modelBuilder.Configurations.Add(new LivroConfiguration());
            modelBuilder.Configurations.Add(new LivroAutorConfiguration());
        }
    }
}
