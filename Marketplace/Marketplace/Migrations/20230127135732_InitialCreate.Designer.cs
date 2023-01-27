﻿// <auto-generated />
using Marketplace.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Marketplace.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230127135732_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Marketplace.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Food"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Drinks"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Clothes"
                        });
                });

            modelBuilder.Entity("Marketplace.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descryption")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Img")
                        .HasColumnType("BLOB");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("sellerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Descryption = "Tasty military rations that are handy during camping!",
                            Name = "Military Rations",
                            Price = 15.5,
                            sellerId = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Descryption = "Tea, but in a can!",
                            Name = "Tea in a can!",
                            Price = 5.5,
                            sellerId = 1
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Descryption = "Makes you run faster! Only one boot in the pack!",
                            Name = "Boot of speed +5",
                            Price = 35.5,
                            sellerId = 1
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Descryption = "Orange, but made of sugar!",
                            Name = "Candy Orange",
                            Price = 15.5,
                            sellerId = 1
                        });
                });

            modelBuilder.Entity("Marketplace.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("buyerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("count")
                        .HasColumnType("INTEGER");

                    b.Property<double>("price")
                        .HasColumnType("REAL");

                    b.Property<int>("productId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("transaction");
                });

            modelBuilder.Entity("Marketplace.Models.UserAccount", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Rank")
                        .HasColumnType("TEXT");

                    b.Property<string>("Userame")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserID");

                    b.ToTable("userAccount");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Address = "TestAdress",
                            Email = "testEmail",
                            FirstName = "testName",
                            LastName = "test",
                            Password = "test",
                            PhoneNumber = "45678",
                            Rank = "Admin",
                            Userame = "test"
                        },
                        new
                        {
                            UserID = 2,
                            Address = "TestAdress2",
                            Email = "testEmail2",
                            FirstName = "testName2",
                            LastName = "test2",
                            Password = "test2",
                            PhoneNumber = "456782",
                            Rank = "user",
                            Userame = "test2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}