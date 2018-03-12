using System.Data.Entity.ModelConfiguration;

namespace CRUD_EntityFramework
{
    public class CargoConfig : EntityTypeConfiguration<Cargo>
    {
        public CargoConfig()
        {
            ToTable("cargo");

            HasKey(c => c.Id);
            Property(c => c.Id)
                .HasColumnName("id");

            Property(c => c.Descricao)
                .HasColumnName("descricao");
            
        }
    }
}
