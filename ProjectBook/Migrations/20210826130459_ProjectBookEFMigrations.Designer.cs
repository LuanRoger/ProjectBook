﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectBook.DB.SqlServerExpress;

namespace ProjectBook.Migrations
{
    [DbContext(typeof(DatabaseManager))]
    [Migration("20210826130459_ProjectBookEFMigrations")]
    partial class ProjectBookEFMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectBook.Livros.AluguelModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("alugadoPor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("AlugadoPor");

                    b.Property<string>("autor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Autor");

                    b.Property<DateTime>("dataDevolucao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataDevolucao");

                    b.Property<DateTime>("dataEntrega")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataEntrega");

                    b.Property<int>("status")
                        .HasMaxLength(9)
                        .HasColumnType("int")
                        .HasColumnName("Status");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Titulo");

                    b.HasKey("id");

                    b.ToTable("Aluguel");
                });

            modelBuilder.Entity("ProjectBook.Livros.ClienteModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cep")
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)")
                        .HasColumnName("Cep");

                    b.Property<string>("cidade")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Cidade");

                    b.Property<string>("email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Endereco");

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("Estado");

                    b.Property<string>("nomeCompleto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NomeCompleto");

                    b.Property<string>("telefone1")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)")
                        .HasColumnName("Telefone1");

                    b.Property<string>("telefone2")
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)")
                        .HasColumnName("Telefone2");

                    b.HasKey("id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ProjectBook.Livros.LivroModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ano")
                        .HasMaxLength(100)
                        .HasColumnType("int")
                        .HasColumnName("Ano");

                    b.Property<string>("autor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Autor");

                    b.Property<DateTime>("dataCadastro")
                        .HasMaxLength(100)
                        .HasColumnType("datetime2")
                        .HasColumnName("DataCadastro");

                    b.Property<string>("edicao")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Edicao");

                    b.Property<string>("editora")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Editora");

                    b.Property<string>("genero")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Genero");

                    b.Property<string>("isbn")
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)")
                        .HasColumnName("ISBN");

                    b.Property<string>("observacoes")
                        .HasColumnType("varchar(MAX)")
                        .HasColumnName("Observacoes");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Titulo");

                    b.HasKey("id");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("ProjectBook.Livros.UsuarioModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Senha");

                    b.Property<int>("tipo")
                        .HasMaxLength(3)
                        .HasColumnType("int")
                        .HasColumnName("Tipo");

                    b.Property<string>("usuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Usuario");

                    b.HasKey("id");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
