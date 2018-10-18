﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoAppFall18.Models;

namespace ToDoAppFall18.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("ToDoAppFall18.Models.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime>("DueDate");

                    b.HasKey("Id");

                    b.ToTable("ToDos");

                    b.HasData(
                        new { Id = 1, Description = "Learn to use this todo app", DueDate = new DateTime(2018, 10, 18, 15, 11, 52, 697, DateTimeKind.Local) }
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
