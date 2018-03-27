using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AspNetCore.Models.DataBaseModels.Context;

namespace AspNetCore.Migrations
{
    [DbContext(typeof(MeuContexto))]
    [Migration("20180327171340_categoria")]
    partial class categoria
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspNetCore.Models.DataBaseModels.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Descricao")
                        .HasColumnName("descricao");

                    b.HasKey("Id");

                    b.ToTable("categoria");
                });
        }
    }
}
