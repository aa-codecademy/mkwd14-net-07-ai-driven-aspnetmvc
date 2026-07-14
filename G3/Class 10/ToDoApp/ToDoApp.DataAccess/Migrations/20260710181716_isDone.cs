using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class isDone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "ToDos",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DueDate", "IsDone" },
                values: new object[] { new DateTime(2026, 7, 11, 20, 17, 15, 540, DateTimeKind.Local).AddTicks(2131), null });

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DueDate", "IsDone" },
                values: new object[] { new DateTime(2026, 7, 12, 20, 17, 15, 540, DateTimeKind.Local).AddTicks(2259), null });

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DueDate", "IsDone" },
                values: new object[] { new DateTime(2026, 7, 10, 20, 17, 15, 540, DateTimeKind.Local).AddTicks(2266), null });

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DueDate", "IsDone" },
                values: new object[] { new DateTime(2026, 7, 7, 20, 17, 15, 540, DateTimeKind.Local).AddTicks(2272), null });

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DueDate", "IsDone" },
                values: new object[] { new DateTime(2026, 7, 10, 20, 17, 15, 540, DateTimeKind.Local).AddTicks(2277), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "ToDos");

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2026, 7, 11, 20, 10, 17, 70, DateTimeKind.Local).AddTicks(6999));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2026, 7, 12, 20, 10, 17, 70, DateTimeKind.Local).AddTicks(7105));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 3,
                column: "DueDate",
                value: new DateTime(2026, 7, 10, 20, 10, 17, 70, DateTimeKind.Local).AddTicks(7110));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 4,
                column: "DueDate",
                value: new DateTime(2026, 7, 7, 20, 10, 17, 70, DateTimeKind.Local).AddTicks(7113));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 5,
                column: "DueDate",
                value: new DateTime(2026, 7, 10, 20, 10, 17, 70, DateTimeKind.Local).AddTicks(7117));
        }
    }
}
