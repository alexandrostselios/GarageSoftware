using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddGarageIDToAllModelsAndMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "GarageID",
                table: "UserModels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "GarageID",
                table: "ServiceHistory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "GarageID",
                table: "EngineerSpeciality",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "GarageID",
                table: "Email",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "GarageID",
                table: "CarModelYear",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "GarageID",
                table: "CarModels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "GarageID",
                table: "CarModelManufacturerYear",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "GarageID",
                table: "CarManufacturer",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "GarageID",
                table: "CarEngineType",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.Sql("UPDATE UserModels SET GarageID = 1");
            migrationBuilder.Sql("UPDATE ServiceHistory SET GarageID = 1");
            migrationBuilder.Sql("UPDATE EngineerSpeciality SET GarageID = 1");
            migrationBuilder.Sql("UPDATE Email SET GarageID = 1");
            migrationBuilder.Sql("UPDATE CarModelYear SET GarageID = 1");
            migrationBuilder.Sql("UPDATE CarModels SET GarageID = 1");
            migrationBuilder.Sql("UPDATE CarManufacturer SET GarageID = 1");
            migrationBuilder.Sql("UPDATE CarEngineType SET GarageID = 1");
            migrationBuilder.Sql("UPDATE CarModelManufacturerYear SET GarageID = 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GarageID",
                table: "UserModels");

            migrationBuilder.DropColumn(
                name: "GarageID",
                table: "ServiceHistory");

            migrationBuilder.DropColumn(
                name: "GarageID",
                table: "EngineerSpeciality");

            migrationBuilder.DropColumn(
                name: "GarageID",
                table: "Email");

            migrationBuilder.DropColumn(
                name: "GarageID",
                table: "CarModelYear");

            migrationBuilder.DropColumn(
                name: "GarageID",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "GarageID",
                table: "CarModelManufacturerYear");

            migrationBuilder.DropColumn(
                name: "GarageID",
                table: "CarManufacturer");

            migrationBuilder.DropColumn(
                name: "GarageID",
                table: "CarEngineType");
        }
    }
}
