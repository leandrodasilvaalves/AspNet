using Model.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Model.EntityConfig
{
    public class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            ToTable("Categories");
            HasKey(c => c.CategoryID);

        }
    }
}
