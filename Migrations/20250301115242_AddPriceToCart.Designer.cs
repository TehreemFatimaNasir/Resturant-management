﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication4.Models;

#nullable disable

namespace WebApplication4.Migrations
{
    [DbContext(typeof(ResturantDbContext))]
    [Migration("20250301115242_AddPriceToCart")]
    partial class AddPriceToCart
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication4.Models.Cart", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("foodname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<int>("subtotal")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("WebApplication4.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("foodname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("WebApplication4.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("customername")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("items")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("totalprice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("WebApplication4.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("booked")
                        .HasColumnType("int");

                    b.Property<string>("customername")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("reservationdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("tablenumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Reserve");
                });

            modelBuilder.Entity("WebApplication4.Models.Review", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customername")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("rating")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
