﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebAPI.Context;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebAPI.Models.Cliente", b =>
                {
                    b.Property<int>("Id_Cliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Cliente"));

                    b.Property<DateTime>("Data_Nascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("Numero_Contato")
                        .HasColumnType("text");

                    b.HasKey("Id_Cliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("WebAPI.Models.Pedido", b =>
                {
                    b.Property<int>("Id_Pedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Pedido"));

                    b.Property<int>("Cliente_Id_Cliente")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id_Pedido");

                    b.HasIndex("Cliente_Id_Cliente");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("WebAPI.Models.Pedido_tem_Produto", b =>
                {
                    b.Property<int>("Pedido_Id_Pedido")
                        .HasColumnType("integer");

                    b.Property<int>("Produto_Id_Produto")
                        .HasColumnType("integer");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.HasKey("Pedido_Id_Pedido");

                    b.HasIndex("Produto_Id_Produto");

                    b.ToTable("PedidoTemProdutos");
                });

            modelBuilder.Entity("WebAPI.Models.Produto", b =>
                {
                    b.Property<int>("Id_Produto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Produto"));

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("Tipo")
                        .HasColumnType("text");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id_Produto");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("WebAPI.Models.Pedido", b =>
                {
                    b.HasOne("WebAPI.Models.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("Cliente_Id_Cliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("WebAPI.Models.Pedido_tem_Produto", b =>
                {
                    b.HasOne("WebAPI.Models.Pedido", "Pedido")
                        .WithMany("PedidoTemProdutos")
                        .HasForeignKey("Pedido_Id_Pedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.Produto", "Produto")
                        .WithMany("PedidoTemProdutos")
                        .HasForeignKey("Produto_Id_Produto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("WebAPI.Models.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("WebAPI.Models.Pedido", b =>
                {
                    b.Navigation("PedidoTemProdutos");
                });

            modelBuilder.Entity("WebAPI.Models.Produto", b =>
                {
                    b.Navigation("PedidoTemProdutos");
                });
#pragma warning restore 612, 618
        }
    }
}
