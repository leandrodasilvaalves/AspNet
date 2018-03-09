using CrudEntityFrameWorkMuitosParaMuitos.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CrudEntityFrameWorkMuitosParaMuitos.EntityConfig
{
    public class AutorConfiguration : EntityTypeConfiguration<Autor>
    {
        public AutorConfiguration()
        {
            ToTable("Autor");

            HasKey(a => a.AutorId);

            Property(a => a.Nome)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);
           
        }
    }
}
