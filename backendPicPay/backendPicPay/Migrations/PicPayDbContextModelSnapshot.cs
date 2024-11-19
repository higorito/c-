﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backendPicPay.Data;

#nullable disable

namespace backendPicPay.Migrations
{
    [DbContext(typeof(PicPayDbContext))]
    partial class PicPayDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("backendPicPay.Models.CarteiraEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPFCNPJ")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TipoUsuario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CPFCNPJ", "Email")
                        .IsUnique();

                    b.ToTable("Carteiras");
                });

            modelBuilder.Entity("backendPicPay.Models.TransferenciaEntity", b =>
                {
                    b.Property<Guid>("IdTransferencia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("IdCarteiraDestino")
                        .HasColumnType("int");

                    b.Property<int>("IdCarteiraOrigem")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("IdTransferencia");

                    b.HasIndex("IdCarteiraDestino");

                    b.HasIndex("IdCarteiraOrigem");

                    b.ToTable("Transferencias");
                });

            modelBuilder.Entity("backendPicPay.Models.TransferenciaEntity", b =>
                {
                    b.HasOne("backendPicPay.Models.CarteiraEntity", "CarteiraDestino")
                        .WithMany()
                        .HasForeignKey("IdCarteiraDestino")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Transaction_Destino");

                    b.HasOne("backendPicPay.Models.CarteiraEntity", "CarteiraOrigem")
                        .WithMany()
                        .HasForeignKey("IdCarteiraOrigem")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Transaction_Origem");

                    b.Navigation("CarteiraDestino");

                    b.Navigation("CarteiraOrigem");
                });
#pragma warning restore 612, 618
        }
    }
}
