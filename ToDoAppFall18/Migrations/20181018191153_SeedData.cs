using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoAppFall18.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Home" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Business" });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "Description", "DueDate" },
                values: new object[] { 1, "Learn to use this todo app", new DateTime(2018, 10, 18, 15, 11, 52, 697, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
