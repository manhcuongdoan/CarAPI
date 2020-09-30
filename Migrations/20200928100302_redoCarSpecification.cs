using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarAPI.Migrations
{
    public partial class redoCarSpecification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreateAt",
                table: "CarSpecifications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreateAt",
                table: "CarSpecifications");
        }
    }
}
