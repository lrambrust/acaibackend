﻿// <auto-generated />
using System;
using AcaiApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AcaiApp.Migrations
{
    [DbContext(typeof(AcaiContext))]
    partial class AcaiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AcaiApp.Domain.Entities.Adicional", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("TempoPreparo")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorAdicional")
                        .HasColumnType("decimal(5,3)");

                    b.HasKey("Id");

                    b.ToTable("Adicional");
                });

            modelBuilder.Entity("AcaiApp.Domain.Entities.Pedido", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Cliente")
                        .IsRequired()
                        .HasColumnType("varchar(30) CHARACTER SET utf8mb4")
                        .HasMaxLength(30);

                    b.Property<int>("Sabores")
                        .HasColumnType("int");

                    b.Property<int>("Tamanho")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(5,3)");

                    b.HasKey("Id");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("AcaiApp.Domain.Entities.PedidoAdicional", b =>
                {
                    b.Property<int>("IdAdicional")
                        .HasColumnType("int");

                    b.Property<long>("IdPedido")
                        .HasColumnType("bigint");

                    b.Property<long?>("AdicionalId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PedidoId")
                        .HasColumnType("bigint");

                    b.HasKey("IdAdicional", "IdPedido");

                    b.HasIndex("AdicionalId");

                    b.HasIndex("PedidoId");

                    b.ToTable("Pedido_Adicional");
                });

            modelBuilder.Entity("AcaiApp.Domain.Entities.PedidoAdicional", b =>
                {
                    b.HasOne("AcaiApp.Domain.Entities.Adicional", "Adicional")
                        .WithMany()
                        .HasForeignKey("AdicionalId");

                    b.HasOne("AcaiApp.Domain.Entities.Pedido", "Pedido")
                        .WithMany("PedidoAdicional")
                        .HasForeignKey("PedidoId");
                });
#pragma warning restore 612, 618
        }
    }
}
