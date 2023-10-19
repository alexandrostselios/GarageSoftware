using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddGarageDetailsTableAndMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GarageDetails",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarageDetails", x => x.ID);
                });

            migrationBuilder.Sql("INSERT INTO GarageDetails(Description, isActive ) VALUES (N'Alex Garage',1)");

            migrationBuilder.AddForeignKey(
                name: "FK_Email_GarageDetails_GarageID",
                table: "Email",
                column: "GarageID",
                principalTable: "GarageDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CarEngineType_GarageDetails_GarageID",
                table: "CarEngineType",
                column: "GarageID",
                principalTable: "GarageDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CarManufacturer_GarageDetails_GarageID",
                table: "CarManufacturer",
                column: "GarageID",
                principalTable: "GarageDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_GarageDetails_GarageID",
                table: "CarModels",
                column: "GarageID",
                principalTable: "GarageDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CarModelYear_GarageDetails_GarageID",
                table: "CarModelYear",
                column: "GarageID",
                principalTable: "GarageDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerSpeciality_GarageDetails_GarageID",
                table: "EngineerSpeciality",
                column: "GarageID",
                principalTable: "GarageDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceHistory_GarageDetails_GarageID",
                table: "ServiceHistory",
                column: "GarageID",
                principalTable: "GarageDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceItems_GarageDetails_GarageID",
                table: "ServiceItems",
                column: "GarageID",
                principalTable: "GarageDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_GarageDetails_GarageID",
                table: "Users",
                column: "GarageID",
                principalTable: "GarageDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CarModelManufacturerYear_GarageDetails_GarageID",
                table: "CarModelManufacturerYear",
                column: "GarageID",
                principalTable: "GarageDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_GarageDetails_GarageID",
                table: "Settings",
                column: "GarageID",
                principalTable: "GarageDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GarageDetails");
        }
    }
}
