﻿// <auto-generated />
using System;
using AgenciaDeViagensRecodePro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AgenciaDeViagensRecodePro.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211216133642_Contato")]
    partial class Contato
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AgenciaDeViagensRecodePro.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .HasColumnName("CPF")
                        .HasColumnType("char(11)")
                        .IsFixedLength(true)
                        .HasMaxLength(11)
                        .IsUnicode(false);

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("IdCliente")
                        .HasName("PK__Cliente__D59466421B693E39");

                    b.HasIndex("Cpf")
                        .IsUnique()
                        .HasName("UQ__Cliente__C1F89731B42930D4")
                        .HasFilter("[CPF] IS NOT NULL");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("AgenciaDeViagensRecodePro.Models.Contato", b =>
                {
                    b.Property<int>("IdContato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mensagem")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("IdContato");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("AgenciaDeViagensRecodePro.Models.Hospedagem", b =>
                {
                    b.Property<int>("IdHospedagem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Diarias")
                        .HasColumnType("int");

                    b.Property<string>("Endereco")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<double?>("ValorDiaria")
                        .HasColumnType("float");

                    b.HasKey("IdHospedagem")
                        .HasName("PK__Hospedag__AAF786D5B01D56DB");

                    b.ToTable("Hospedagem");
                });

            modelBuilder.Entity("AgenciaDeViagensRecodePro.Models.Pacote", b =>
                {
                    b.Property<int>("IdPacote")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FkClienteIdCliente")
                        .HasColumnName("fk_Cliente_IdCliente")
                        .HasColumnType("int");

                    b.Property<int?>("FkHospedagemIdHospedagem")
                        .HasColumnName("fk_Hospedagem_IdHospedagem")
                        .HasColumnType("int");

                    b.Property<int?>("FkPassagemIdPassagem")
                        .HasColumnName("fk_Passagem_IdPassagem")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("IdPacote")
                        .HasName("PK__Pacote__40CE6F9C81CBDAD2");

                    b.HasIndex("FkClienteIdCliente");

                    b.HasIndex("FkHospedagemIdHospedagem");

                    b.HasIndex("FkPassagemIdPassagem");

                    b.ToTable("Pacote");
                });

            modelBuilder.Entity("AgenciaDeViagensRecodePro.Models.Passagem", b =>
                {
                    b.Property<int>("IdPassagem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataChegada")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DataPartida")
                        .HasColumnType("datetime");

                    b.Property<string>("LocalChegada")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("LocalPartida")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<double?>("Valor")
                        .HasColumnType("float");

                    b.HasKey("IdPassagem")
                        .HasName("PK__Passagem__9509808BB723CE3A");

                    b.ToTable("Passagem");
                });

            modelBuilder.Entity("AgenciaDeViagensRecodePro.Models.Pacote", b =>
                {
                    b.HasOne("AgenciaDeViagensRecodePro.Models.Cliente", "FkClienteIdClienteNavigation")
                        .WithMany("Pacote")
                        .HasForeignKey("FkClienteIdCliente")
                        .HasConstraintName("FK_Pacote_2")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgenciaDeViagensRecodePro.Models.Hospedagem", "FkHospedagemIdHospedagemNavigation")
                        .WithMany("Pacote")
                        .HasForeignKey("FkHospedagemIdHospedagem")
                        .HasConstraintName("FK_Pacote_4")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgenciaDeViagensRecodePro.Models.Passagem", "FkPassagemIdPassagemNavigation")
                        .WithMany("Pacote")
                        .HasForeignKey("FkPassagemIdPassagem")
                        .HasConstraintName("FK_Pacote_3")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}