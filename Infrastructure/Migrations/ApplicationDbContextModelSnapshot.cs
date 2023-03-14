﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Product.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdateDm")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Products", "product");
                });

            modelBuilder.Entity("Entities.Product.ProductAdditive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdateDm")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("ProductAdditives", "product");
                });

            modelBuilder.Entity("Entities.Product.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdateDm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories", "product");
                });

            modelBuilder.Entity("Entities.Product.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdateDm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages", "product");
                });

            modelBuilder.Entity("Entities.Product.ProductPriceHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDm")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("DiscountPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("DiscountPriceExpireAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Inventory")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastUpdateDm")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPriceHistories", "product");
                });

            modelBuilder.Entity("Entities.Product.ProductPriceHistoryToOptionValues", b =>
                {
                    b.Property<int>("ProductPriceOptionValueId")
                        .HasColumnType("int");

                    b.Property<int>("ProductPriceHistoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductPriceOptionValueId", "ProductPriceHistoryId");

                    b.HasIndex("ProductPriceHistoryId");

                    b.ToTable("ProductPriceHistoryToOptionValues", "product");
                });

            modelBuilder.Entity("Entities.Product.ProductPriceOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdateDm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("ProductCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("ProductPriceOptions", "product");
                });

            modelBuilder.Entity("Entities.Product.ProductPriceOptionValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdateDm")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductPriceOptionId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductPriceOptionId");

                    b.ToTable("ProductPriceOptionValues", "product");
                });

            modelBuilder.Entity("Entities.Product.ProductToProductAdditive", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductAdditiveId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "ProductAdditiveId");

                    b.HasIndex("ProductAdditiveId");

                    b.ToTable("ProductToProductAdditives", "product");
                });

            modelBuilder.Entity("Entities.Product.Product", b =>
                {
                    b.HasOne("Entities.Product.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("Entities.Product.ProductAdditive", b =>
                {
                    b.HasOne("Entities.Product.ProductCategory", "ProductCategory")
                        .WithMany("ProductAdditives")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("Entities.Product.ProductImage", b =>
                {
                    b.HasOne("Entities.Product.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Entities.Product.ProductPriceHistory", b =>
                {
                    b.HasOne("Entities.Product.Product", "Product")
                        .WithMany("ProductPriceHistories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Entities.Product.ProductPriceHistoryToOptionValues", b =>
                {
                    b.HasOne("Entities.Product.ProductPriceHistory", "ProductPriceHistory")
                        .WithMany("ProductPriceHistoryToOptionValues")
                        .HasForeignKey("ProductPriceHistoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Product.ProductPriceOptionValue", "ProductPriceOptionValue")
                        .WithMany("ProductPriceHistoryToOptionValues")
                        .HasForeignKey("ProductPriceOptionValueId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProductPriceHistory");

                    b.Navigation("ProductPriceOptionValue");
                });

            modelBuilder.Entity("Entities.Product.ProductPriceOption", b =>
                {
                    b.HasOne("Entities.Product.ProductCategory", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("ProductCategoryId");

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("Entities.Product.ProductPriceOptionValue", b =>
                {
                    b.HasOne("Entities.Product.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("Entities.Product.ProductPriceOption", "ProductPriceOption")
                        .WithMany("OptionValues")
                        .HasForeignKey("ProductPriceOptionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductPriceOption");
                });

            modelBuilder.Entity("Entities.Product.ProductToProductAdditive", b =>
                {
                    b.HasOne("Entities.Product.ProductAdditive", "ProductAdditive")
                        .WithMany("ProductToProductAdditive")
                        .HasForeignKey("ProductAdditiveId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Product.Product", "Product")
                        .WithMany("ProductToProductAdditive")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductAdditive");
                });

            modelBuilder.Entity("Entities.Product.Product", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("ProductPriceHistories");

                    b.Navigation("ProductToProductAdditive");
                });

            modelBuilder.Entity("Entities.Product.ProductAdditive", b =>
                {
                    b.Navigation("ProductToProductAdditive");
                });

            modelBuilder.Entity("Entities.Product.ProductCategory", b =>
                {
                    b.Navigation("ProductAdditives");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Product.ProductPriceHistory", b =>
                {
                    b.Navigation("ProductPriceHistoryToOptionValues");
                });

            modelBuilder.Entity("Entities.Product.ProductPriceOption", b =>
                {
                    b.Navigation("OptionValues");
                });

            modelBuilder.Entity("Entities.Product.ProductPriceOptionValue", b =>
                {
                    b.Navigation("ProductPriceHistoryToOptionValues");
                });
#pragma warning restore 612, 618
        }
    }
}
