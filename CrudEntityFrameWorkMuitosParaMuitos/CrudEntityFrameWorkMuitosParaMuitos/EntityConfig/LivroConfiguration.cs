using CrudEntityFrameWorkMuitosParaMuitos.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CrudEntityFrameWorkMuitosParaMuitos.EntityConfig
{
    public class LivroConfiguration : EntityTypeConfiguration<Livro>
    {
        public LivroConfiguration()
        {
            ToTable("Livro");

            HasKey(l => l.LivroId);

            Property(l => l.Titulo)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(150);
        }
    }
}
