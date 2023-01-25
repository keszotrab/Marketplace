﻿// <auto-generated />
using Marketplace.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Marketplace.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Marketplace.Models.UserAccount", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ConfirmPassword")
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
                            ConfirmPassword = "test",
                            Email = "testEmail",
                            FirstName = "testName",
                            LastName = "test",
                            Password = "test",
                            PhoneNumber = "45678",
                            Userame = "test"
                        },
                        new
                        {
                            UserID = 2,
                            Address = "TestAdress2",
                            ConfirmPassword = "test2",
                            Email = "testEmail2",
                            FirstName = "testName2",
                            LastName = "test2",
                            Password = "test2",
                            PhoneNumber = "456782",
                            Userame = "test2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
