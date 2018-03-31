using Model.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Model.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            ToTable("Products");
            HasKey(p => p.ProductID);

            HasRequired(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.CategoryID);

            HasRequired(p => p.Fornecedor)
                .WithMany(f => f.Produtos)
                .HasForeignKey(p => p.SupplierID);
        }
    }
}
