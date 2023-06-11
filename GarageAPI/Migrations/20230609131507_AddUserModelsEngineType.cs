using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUserModelsEngineType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EngineTypeID",
                table: "UserModels",
                type: "bigint",
                nullable: false,
                defaultValue: 1L);

            migrationBuilder.CreateIndex(
                name: "IX_UserModels_EngineTypeID",
                table: "UserModels",
                column: "EngineTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserModels_CarEngineType_EngineTypeID",
                table: "UserModels",
                column: "EngineTypeID",
                principalTable: "CarEngineType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);


            migrationBuilder.Sql("Update UserModels Set EngineTypeID = 3 where ID = 1");
            migrationBuilder.Sql("Update UserModels Set EngineTypeID = 2 where ID = 3");

            migrationBuilder.Sql("ALTER PROCEDURE [dbo].[GetCustomerCar]\r\n-- Add the parameters for the stored procedure here\r\n@UserModelID BIGINT\r\nAS\r\n    BEGIN\r\n        SET NOCOUNT ON;\r\n        SELECT UM.ID, \r\n               UM.UserID, \r\n               CMAN.ManufacturerName, \r\n               CM.ModelName, \r\n               CMY.Description AS ModelYear, \r\n               UM.LicencePlate, \r\n               UM.VIN, \r\n               UM.Color, \r\n               UM.Kilometer, \r\n               UM.CarImage, \r\n               CET.EngineType\r\n        FROM UserModels UM\r\n             INNER JOIN CarModelManufacturerYear CMMY ON CMMY.ID = um.ModelManufacturerYearID\r\n             INNER JOIN CarModels CM ON CM.ID = CMMY.CarModelID\r\n             INNER JOIN CarManufacturer CMAN ON CMAN.ID = CMMY.CarManufacturerID\r\n             INNER JOIN CarModelYear CMY ON CMY.ID = CMMY.CarModelYearID\r\n             INNER JOIN CarEngineType CET ON CET.ID = UM.EngineTypeID\r\n        WHERE UM.ID = @UserModelID;\r\n    END;");
            migrationBuilder.Sql("ALTER PROCEDURE [dbo].[GetCustomerCars]\r\n-- Add the parameters for the stored procedure here\r\n@UserID BIGINT\r\nAS\r\n    BEGIN\r\n        SET NOCOUNT ON;\r\n        SELECT UM.ID, \r\n               UM.UserID, \r\n               CMAN.ManufacturerName, \r\n               CM.ModelName, \r\n               CMY.Description AS ModelYear, \r\n               UM.LicencePlate, \r\n               UM.VIN, \r\n               UM.Color, \r\n               UM.Kilometer, \r\n               UM.CarImage, \r\n               CET.EngineType\r\n        FROM UserModels UM\r\n             INNER JOIN CarModelManufacturerYear CMMY ON CMMY.ID = um.ModelManufacturerYearID\r\n             INNER JOIN CarModels CM ON CM.ID = CMMY.CarModelID\r\n             INNER JOIN CarManufacturer CMAN ON CMAN.ID = CMMY.CarManufacturerID\r\n             INNER JOIN CarModelYear CMY ON CMY.ID = CMMY.CarModelYearID\r\n             INNER JOIN CarEngineType CET ON CET.ID = UM.EngineTypeID\r\n        WHERE UserId = @UserID;\r\n    END;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserModels_CarEngineType_EngineTypeID",
                table: "UserModels");

            migrationBuilder.DropIndex(
                name: "IX_UserModels_EngineTypeID",
                table: "UserModels");

            migrationBuilder.DropColumn(
                name: "EngineTypeID",
                table: "UserModels");
        }
    }
}
