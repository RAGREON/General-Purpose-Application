using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GpSys.Course.Migrations
{
    /// <inheritdoc />
    public partial class SwitchCoursesPrimaryKeyToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");
            
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "NewId",
                table: "Courses",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "NewId",
                table: "Courses");
        }
    }
}
