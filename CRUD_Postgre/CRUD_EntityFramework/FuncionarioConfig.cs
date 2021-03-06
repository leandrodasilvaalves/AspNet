﻿using System.Data.Entity.ModelConfiguration;

namespace CRUD_EntityFramework
{
    public class FuncionarioConfig : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioConfig()
        {
            ToTable("funcionario");

            HasKey(f => f.Id);
            Property(f => f.Id)
                .HasColumnName("id");

            Property(f => f.Nome)
                .HasColumnName("nome")
                .HasMaxLength(100);

            Property(f => f.Email)
                .HasColumnName("email")
                .HasMaxLength(150);

            Property(f => f.CargoId)
                .HasColumnName("cargoid");

            HasRequired(f => f.Cargo)
                .WithMany(c => c.Funcionarios)
                .HasForeignKey(f => f.CargoId);

        }
    }
}
