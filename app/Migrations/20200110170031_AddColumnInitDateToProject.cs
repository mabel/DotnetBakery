using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Baloon_AB.Migrations
{
    public partial class AddColumnInitDateToProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InitDate",
                table: "Projects",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InitDate",
                table: "Projects");
        }
    }
}
