using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAppInformationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                table: "GarageDetails",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "AppInformation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GarageID = table.Column<long>(type: "bigint", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MajorIncrementalNumber = table.Column<long>(type: "bigint", nullable: false),
                    MinorIncrementalNumber = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppInformation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AppInformation_GarageDetails_GarageID",
                        column: x => x.GarageID,
                        principalTable: "GarageDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppInformation_GarageID",
                table: "AppInformation",
                column: "GarageID");

            migrationBuilder.Sql("INSERT INTO AppInformation (GarageID, PublishDate, MajorIncrementalNumber,MinorIncrementalNumber) VALUES (1,GETDATE(),1,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppInformation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                table: "GarageDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1753, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
