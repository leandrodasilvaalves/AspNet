using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MVCareas.Models.EntityConfig
{
    public class ProdutoConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfig()
        {
            HasKey(p => p.ProdutoId);

            Property(p => p.Nome)
                .IsRequired()
                .HasColumnName("nome")
                .HasMaxLength(150);

            Property(p => p.Preco)
                .IsRequired()
                .HasColumnName("preco");

            HasRequired(p => p.Categoria)
                .WithMany()
                .HasForeignKey(p => p.CategoriaId);

            
        }
    }
}