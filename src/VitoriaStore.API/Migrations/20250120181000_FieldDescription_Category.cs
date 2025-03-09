using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitoriaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class FieldDescription_Category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyColumn",
                table: "Category",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Category",
                newName: "MyColumn");
        }
    }
}
