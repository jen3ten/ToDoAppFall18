using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoAppFall18.Migrations
{
    public partial class ToDoCategoryMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDoCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ToDoId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDoCategories_ToDos_ToDoId",
                        column: x => x.ToDoId,
                        principalTable: "ToDos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoCategories_CategoryId",
                table: "ToDoCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoCategories_ToDoId",
                table: "ToDoCategories",
                column: "ToDoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoCategories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
