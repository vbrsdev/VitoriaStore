using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitoriaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class FieldMyColumn_Category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MyColumn",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyColumn",
                table: "Category");
        }
    }
}
