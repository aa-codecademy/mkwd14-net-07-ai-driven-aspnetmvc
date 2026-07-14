using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avenga.ASP.NET.CORE.MVC.Database.Migrations
{
    /// <inheritdoc />
    public partial class Alter_Course_Add_IsActiveCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActiveCourse",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActiveCourse",
                table: "Courses");
        }
    }
}
