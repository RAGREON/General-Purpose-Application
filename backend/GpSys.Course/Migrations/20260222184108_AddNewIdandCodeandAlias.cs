using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GpSys.Course.Migrations
{
    /// <inheritdoc />
    public partial class AddNewIdandCodeandAlias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NewId",
                table: "Courses",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Courses",
                nullable: true
            );

            migrationBuilder.Sql("UPDATE \"Courses\" SET \"Code\" = \"Id\";");

            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "Courses",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alias",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "NewId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Courses");
        }
    }
}
