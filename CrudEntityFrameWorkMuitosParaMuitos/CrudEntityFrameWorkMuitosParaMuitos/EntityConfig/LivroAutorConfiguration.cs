using CrudEntityFrameWorkMuitosParaMuitos.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CrudEntityFrameWorkMuitosParaMuitos.EntityConfig
{
    public class LivroAutorConfiguration : EntityTypeConfiguration<LivroAutor>
    {
        public LivroAutorConfiguration()
        {
            ToTable("LivroAutor");

            HasKey(la => new { la.AutorId, la.LivroId });

            HasRequired(la => la.Autor)
                .WithMany(a => a.LivrosAutores)
                .HasForeignKey(la => la.AutorId)
                .WillCascadeOnDelete(false);

            HasRequired(la => la.Livro)
                .WithMany(l => l.LivrosAutores)
                .HasForeignKey(la => la.LivroId)
                .WillCascadeOnDelete(false);
        }
    }
}
