﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitoriaStore.API.Migrations
{
    /// <inheritdoc />
    public partial class FieldIsDeleted_Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Product");
        }
    }
}
