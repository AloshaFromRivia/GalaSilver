﻿// <auto-generated />
using System;
using GalaSilver.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GalaSilver.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220429101829_OrdersTable")]
    partial class OrdersTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GalaSilver.Models.CartLine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int?>("OrderID")
                        .HasColumnType("int");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductId");

                    b.ToTable("CartLine");
                });

            modelBuilder.Entity("GalaSilver.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("GalaSilver.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Line1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("OrderID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("GalaSilver.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("longblob");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("GalaSilver.Models.CartLine", b =>
                {
                    b.HasOne("GalaSilver.Models.Order", null)
                        .WithMany("Lines")
                        .HasForeignKey("OrderID");

                    b.HasOne("GalaSilver.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GalaSilver.Models.Product", b =>
                {
                    b.HasOne("GalaSilver.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("GalaSilver.Models.Order", b =>
                {
                    b.Navigation("Lines");
                });
#pragma warning restore 612, 618
        }
    }
}