using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Avenga.ASP.NET.CORE.MVC.Database.Migrations
{
    /// <inheritdoc />
    public partial class Add_Init_Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "IsActiveCourse", "Name", "NumberOfClasses" },
                values: new object[,]
                {
                    { 1, false, "C# basic", 40 },
                    { 2, false, "C# Advanced", 60 },
                    { 3, false, "Database development and design", 28 },
                    { 4, false, "ASP.NET Mvc", 40 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ActiveCourseId", "DateOfBirth", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(1999, 7, 13, 19, 54, 46, 800, DateTimeKind.Local).AddTicks(2071), "Bob", "Bobski" },
                    { 2, 4, new DateTime(1989, 7, 13, 19, 54, 46, 800, DateTimeKind.Local).AddTicks(2122), "Jill", "Jilski" },
                    { 3, 4, new DateTime(1981, 7, 13, 19, 54, 46, 800, DateTimeKind.Local).AddTicks(2124), "John", "Doe" },
                    { 4, 4, new DateTime(2009, 7, 13, 19, 54, 46, 800, DateTimeKind.Local).AddTicks(2126), "Jane", "Doe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
