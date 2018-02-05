using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MVCareas.Models.EntityConfig
{
    public class CategoriaConfig : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfig()
        {
            HasKey(c => c.CategoriaId);

            Property(c => c.Descricao)
                .IsRequired()
                .HasColumnName("Descricao")
                .HasMaxLength(100);            

        }
    }
}