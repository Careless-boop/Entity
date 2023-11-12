﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test.Data;

#nullable disable

namespace Test.Migrations
{
    [DbContext(typeof(ShoeContext))]
    partial class ShoeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Test.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Test.Models.Shoes.Shoe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Shoes");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Test.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Test.Unifiers.OrderShoe", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ShoeId")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ShoeId");

                    b.HasIndex("ShoeId");

                    b.ToTable("OrderedShoes");
                });

            modelBuilder.Entity("Test.Unifiers.UserCart", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ShoeCId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ShoeCId");

                    b.HasIndex("ShoeCId");

                    b.ToTable("UserCarts");
                });

            modelBuilder.Entity("Test.Models.Shoes.HikingShoes", b =>
                {
                    b.HasBaseType("Test.Models.Shoes.Shoe");

                    b.Property<bool>("IsReal")
                        .HasColumnType("bit");

                    b.ToTable("HikingShoes", (string)null);
                });

            modelBuilder.Entity("Test.Models.Shoes.Sandals", b =>
                {
                    b.HasBaseType("Test.Models.Shoes.Shoe");

                    b.Property<float>("Traction")
                        .HasColumnType("real");

                    b.ToTable("Sandals", (string)null);
                });

            modelBuilder.Entity("Test.Models.Shoes.SportShoes", b =>
                {
                    b.HasBaseType("Test.Models.Shoes.Shoe");

                    b.Property<string>("Height")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("SportShoes", (string)null);
                });

            modelBuilder.Entity("Test.Unifiers.OrderShoe", b =>
                {
                    b.HasOne("Test.Models.Order", "Order")
                        .WithMany("OrderShoe")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test.Models.Shoes.Shoe", "Shoe")
                        .WithMany("OrderShoe")
                        .HasForeignKey("ShoeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Shoe");
                });

            modelBuilder.Entity("Test.Unifiers.UserCart", b =>
                {
                    b.HasOne("Test.Models.Shoes.Shoe", "ShoeC")
                        .WithMany("UserCarts")
                        .HasForeignKey("ShoeCId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test.Models.User", "User")
                        .WithMany("UserCarts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShoeC");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Test.Models.Shoes.HikingShoes", b =>
                {
                    b.HasOne("Test.Models.Shoes.Shoe", null)
                        .WithOne()
                        .HasForeignKey("Test.Models.Shoes.HikingShoes", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Test.Models.Shoes.Sandals", b =>
                {
                    b.HasOne("Test.Models.Shoes.Shoe", null)
                        .WithOne()
                        .HasForeignKey("Test.Models.Shoes.Sandals", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Test.Models.Shoes.SportShoes", b =>
                {
                    b.HasOne("Test.Models.Shoes.Shoe", null)
                        .WithOne()
                        .HasForeignKey("Test.Models.Shoes.SportShoes", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Test.Models.Order", b =>
                {
                    b.Navigation("OrderShoe");
                });

            modelBuilder.Entity("Test.Models.Shoes.Shoe", b =>
                {
                    b.Navigation("OrderShoe");

                    b.Navigation("UserCarts");
                });

            modelBuilder.Entity("Test.Models.User", b =>
                {
                    b.Navigation("UserCarts");
                });
#pragma warning restore 612, 618
        }
    }
}
