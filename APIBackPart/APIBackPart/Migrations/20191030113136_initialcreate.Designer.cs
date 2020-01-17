﻿// <auto-generated />
using APIBackPart.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIBackPart.Migrations
{
    [DbContext(typeof(BackPartContext))]
    [Migration("20191030113136_initialcreate")]
    partial class initialcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APIBackPart.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new { Id = 1, Name = "Dress" },
                        new { Id = 2, Name = "Shoes" },
                        new { Id = 3, Name = "Electronics" },
                        new { Id = 4, Name = "Furniture" }
                    );
                });

            modelBuilder.Entity("APIBackPart.Model.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new { Id = 1, CategoryId = 1, Name = "Adidas T-shirt", Price = 100m },
                        new { Id = 2, CategoryId = 1, Name = "Nike T-shirt", Price = 89m },
                        new { Id = 3, CategoryId = 1, Name = "Skirt Long", Price = 70m },
                        new { Id = 4, CategoryId = 2, Name = "Adidas shoes", Price = 60m },
                        new { Id = 5, CategoryId = 2, Name = "Nike shoes", Price = 77m },
                        new { Id = 6, CategoryId = 3, Name = "Iphone 10", Price = 1000m },
                        new { Id = 7, CategoryId = 4, Name = "Sofa", Price = 5000m },
                        new { Id = 8, CategoryId = 4, Name = "Chair", Price = 300m }
                    );
                });

            modelBuilder.Entity("APIBackPart.Model.Product", b =>
                {
                    b.HasOne("APIBackPart.Model.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
