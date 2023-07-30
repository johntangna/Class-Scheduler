using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassScheduler.API.Migrations
{
    /// <inheritdoc />
    public partial class schedulardb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "CourseSelected",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseSelected",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
