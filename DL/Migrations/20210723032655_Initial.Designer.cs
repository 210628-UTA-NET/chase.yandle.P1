﻿// <auto-generated />
using System;
using DL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DL.Migrations
{
    [DbContext(typeof(StDbContext))]
    [Migration("20210723032655_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Models.Customer", b =>
                {
                    b.Property<int>("cID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("cCity")
                        .HasColumnType("text");

                    b.Property<string>("cEmail")
                        .HasColumnType("text");

                    b.Property<string>("cName")
                        .HasColumnType("text");

                    b.Property<string>("cPhone")
                        .HasColumnType("text");

                    b.Property<string>("cState")
                        .HasColumnType("text");

                    b.Property<string>("cStreet")
                        .HasColumnType("text");

                    b.HasKey("cID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Models.Inventory", b =>
                {
                    b.Property<int>("iStore")
                        .HasColumnType("integer");

                    b.Property<int>("iProduct")
                        .HasColumnType("integer");

                    b.Property<int?>("ProductpID")
                        .HasColumnType("integer");

                    b.Property<int?>("StorestID")
                        .HasColumnType("integer");

                    b.Property<int>("iQuantity")
                        .HasColumnType("integer");

                    b.HasKey("iStore", "iProduct");

                    b.HasIndex("ProductpID");

                    b.HasIndex("StorestID");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("Models.LineItem", b =>
                {
                    b.Property<int>("liID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("liLinePrice")
                        .HasColumnType("numeric");

                    b.Property<int?>("liOrderoID")
                        .HasColumnType("integer");

                    b.Property<int?>("liProductpID")
                        .HasColumnType("integer");

                    b.Property<int>("liQuantity")
                        .HasColumnType("integer");

                    b.HasKey("liID");

                    b.HasIndex("liOrderoID");

                    b.HasIndex("liProductpID");

                    b.ToTable("LineItems");
                });

            modelBuilder.Entity("Models.Order", b =>
                {
                    b.Property<int>("oID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("oCustomercID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("oDateAndTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("oDestinationstID")
                        .HasColumnType("integer");

                    b.Property<decimal>("oPrice")
                        .HasColumnType("numeric");

                    b.Property<int?>("oSourcestID")
                        .HasColumnType("integer");

                    b.HasKey("oID");

                    b.HasIndex("oCustomercID");

                    b.HasIndex("oDestinationstID");

                    b.HasIndex("oSourcestID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Models.Product", b =>
                {
                    b.Property<int>("pID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("pName")
                        .HasColumnType("text");

                    b.Property<decimal>("pPrice")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("pReleaseDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("pID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Models.Store", b =>
                {
                    b.Property<int>("stID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("stCity")
                        .HasColumnType("text");

                    b.Property<string>("stEmail")
                        .HasColumnType("text");

                    b.Property<string>("stPhone")
                        .HasColumnType("text");

                    b.Property<string>("stState")
                        .HasColumnType("text");

                    b.Property<string>("stStreet")
                        .HasColumnType("text");

                    b.HasKey("stID");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Models.Inventory", b =>
                {
                    b.HasOne("Models.Product", null)
                        .WithMany("pInventory")
                        .HasForeignKey("ProductpID");

                    b.HasOne("Models.Store", null)
                        .WithMany("stInventory")
                        .HasForeignKey("StorestID");
                });

            modelBuilder.Entity("Models.LineItem", b =>
                {
                    b.HasOne("Models.Order", "liOrder")
                        .WithMany("oLineItems")
                        .HasForeignKey("liOrderoID");

                    b.HasOne("Models.Product", "liProduct")
                        .WithMany()
                        .HasForeignKey("liProductpID");

                    b.Navigation("liOrder");

                    b.Navigation("liProduct");
                });

            modelBuilder.Entity("Models.Order", b =>
                {
                    b.HasOne("Models.Customer", "oCustomer")
                        .WithMany("cOrders")
                        .HasForeignKey("oCustomercID");

                    b.HasOne("Models.Store", "oDestination")
                        .WithMany("stOrders")
                        .HasForeignKey("oDestinationstID");

                    b.HasOne("Models.Store", "oSource")
                        .WithMany()
                        .HasForeignKey("oSourcestID");

                    b.Navigation("oCustomer");

                    b.Navigation("oDestination");

                    b.Navigation("oSource");
                });

            modelBuilder.Entity("Models.Customer", b =>
                {
                    b.Navigation("cOrders");
                });

            modelBuilder.Entity("Models.Order", b =>
                {
                    b.Navigation("oLineItems");
                });

            modelBuilder.Entity("Models.Product", b =>
                {
                    b.Navigation("pInventory");
                });

            modelBuilder.Entity("Models.Store", b =>
                {
                    b.Navigation("stInventory");

                    b.Navigation("stOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
