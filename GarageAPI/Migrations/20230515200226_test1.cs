using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2023, 5, 15, 23, 2, 25, 636, DateTimeKind.Local).AddTicks(7113));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2023, 5, 15, 23, 1, 46, 118, DateTimeKind.Local).AddTicks(4341));
        }
    }
}
