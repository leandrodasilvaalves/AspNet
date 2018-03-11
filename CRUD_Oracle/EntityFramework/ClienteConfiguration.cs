using System.Data.Entity.ModelConfiguration;

namespace CrudEntityFramework
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            ToTable("CLIENTE");
            Property(c => c.Id)
                .HasColumnName("ID");

            Property(c => c.Nome)
                .HasColumnName("NOME");
        }
    }
}
