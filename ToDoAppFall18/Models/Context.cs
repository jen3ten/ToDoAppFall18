using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAppFall18.Models
{
    public class Context : DbContext
    {
        public DbSet<ToDo> ToDos { get; set; } //This allows the model to be stored in the database
        public DbSet<Category> Categories { get; set; }
        public DbSet<ToDoCategory> ToDoCategories { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Whenever this database is created, the Category table will have these records
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Home"},
                new Category() { Id = 2, Name = "Business"}
                );

            modelBuilder.Entity<ToDo>().HasData(
                new ToDo() {  Id = 1, Description = "Learn to use this todo app", DueDate = DateTime.Now, OwnerId = 2}
                );

            modelBuilder.Entity<Owner>().HasData(
                new Owner() { Id = 1, Name = "Jen" },
                new Owner() { Id = 2, Name = "Delaney" }
                );

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=DbToDos;Trusted_Connection=True;";

            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }
    }
}
