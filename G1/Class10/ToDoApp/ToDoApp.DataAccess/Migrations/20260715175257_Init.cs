using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDo_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDo_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Work" },
                    { 2, "Home" },
                    { 3, "Exercise" },
                    { 4, "Shopping" },
                    { 5, "Hoby" },
                    { 6, "FreeTime" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "Closed" }
                });

            migrationBuilder.InsertData(
                table: "ToDo",
                columns: new[] { "Id", "CategoryId", "Description", "DueDate", "StatusId" },
                values: new object[,]
                {
                    { 1, 1, "Finish project presentation", new DateTime(2026, 7, 17, 19, 52, 55, 643, DateTimeKind.Local).AddTicks(5082), 1 },
                    { 2, 2, "Clean the house", new DateTime(2026, 7, 16, 19, 52, 55, 643, DateTimeKind.Local).AddTicks(5125), 1 },
                    { 3, 3, "Morning exercise", new DateTime(2026, 7, 15, 19, 52, 55, 643, DateTimeKind.Local).AddTicks(5128), 2 },
                    { 4, 4, "Buy groceries", new DateTime(2026, 7, 18, 19, 52, 55, 643, DateTimeKind.Local).AddTicks(5130), 1 },
                    { 5, 6, "Watch a movie", new DateTime(2026, 7, 15, 19, 52, 55, 643, DateTimeKind.Local).AddTicks(5132), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_CategoryId",
                table: "ToDo",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_StatusId",
                table: "ToDo",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDo");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
