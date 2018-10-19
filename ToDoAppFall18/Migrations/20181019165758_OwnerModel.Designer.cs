﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoAppFall18.Models;

namespace ToDoAppFall18.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20181019165758_OwnerModel")]
    partial class OwnerModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ToDoAppFall18.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new { Id = 1, Name = "Home" },
                        new { Id = 2, Name = "Business" }
                    );
                });

            modelBuilder.Entity("ToDoAppFall18.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Owners");

                    b.HasData(
                        new { Id = 1, Name = "Jen" },
                        new { Id = 2, Name = "Delaney" }
                    );
                });

            modelBuilder.Entity("ToDoAppFall18.Models.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime>("DueDate");

                    b.Property<int>("OwnerId");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("ToDos");

                    b.HasData(
                        new { Id = 1, Description = "Learn to use this todo app", DueDate = new DateTime(2018, 10, 19, 12, 57, 57, 796, DateTimeKind.Local), OwnerId = 2 }
                    );
                });

            modelBuilder.Entity("ToDoAppFall18.Models.ToDoCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<int>("ToDoId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ToDoId");

                    b.ToTable("ToDoCategories");
                });

            modelBuilder.Entity("ToDoAppFall18.Models.ToDo", b =>
                {
                    b.HasOne("ToDoAppFall18.Models.Owner")
                        .WithMany("ToDos")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ToDoAppFall18.Models.ToDoCategory", b =>
                {
                    b.HasOne("ToDoAppFall18.Models.Category", "Category")
                        .WithMany("ToDoCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ToDoAppFall18.Models.ToDo", "ToDo")
                        .WithMany("ToDoCategories")
                        .HasForeignKey("ToDoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}