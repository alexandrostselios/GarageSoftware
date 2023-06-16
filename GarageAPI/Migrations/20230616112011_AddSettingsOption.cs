using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddSettingsOption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GarageID = table.Column<long>(type: "bigint", nullable: false),
                    InsertUserID = table.Column<long>(type: "bigint", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Settings_Users_InsertUserID",
                        column: x => x.InsertUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Settings_InsertUserID",
                table: "Settings",
                column: "InsertUserID");

            migrationBuilder.Sql("INSERT INTO Settings(Description,  Value,  GarageID,  InsertUserID,  InsertDate,  ModifyDate)VALUES('Language', 'el-GR',  1,  1,  GETDATE(),  NULL)");

            migrationBuilder.Sql("UPDATE USERS SET GarageID = 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
