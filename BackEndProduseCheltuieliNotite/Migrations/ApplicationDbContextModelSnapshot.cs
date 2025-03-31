﻿// <auto-generated />
using System;
using BackEndProduseCheltuieliNotite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEndProduseCheltuieliNotite.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("BackEndProduseCheltuieliNotite.Models.Objects.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("BackEndProduseCheltuieliNotite.Models.Objects.Masina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("An")
                        .HasColumnType("TEXT");

                    b.Property<string>("Combustibil")
                        .HasColumnType("TEXT");

                    b.Property<string>("Culoare")
                        .HasColumnType("TEXT");

                    b.Property<string>("Marca")
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumarInmatriculare")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Masinas");
                });

            modelBuilder.Entity("BackEndProduseCheltuieliNotite.Models.Objects.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("BackEndProduseCheltuieliNotite.Models.Objects.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Price")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Quantity")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
