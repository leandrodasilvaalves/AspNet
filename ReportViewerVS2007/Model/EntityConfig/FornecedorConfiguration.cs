using Model.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Model.EntityConfig
{
    public class FornecedorConfiguration : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorConfiguration()
        {
            ToTable("Suppliers");
            HasKey(f => f.SupplierID);
        }
    }
}
