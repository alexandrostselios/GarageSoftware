using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceHistoryNotificationFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "NotifyDays",
                table: "ServiceHistory",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NotifyNextService",
                table: "ServiceHistory",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsDate",
                table: "Email",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            var update1 = @"
            UPDATE ServiceHistory
              SET 
                  NotifyNextService = 1
            WHERE ID = 1;";

            migrationBuilder.Sql(update1);

            var update2 = @"
            UPDATE ServiceHistory
              SET 
                  NotifyNextService = 1
            WHERE ID = 4;";

            migrationBuilder.Sql(update2);

            var updateStoreProcedure = @"
            ALTER PROCEDURE [dbo].[GetCarServiceHistories]
            -- Add the parameters for the stored procedure here
            @GarageID         BIGINT, 
            @NotificationDate DATETIME
            AS
                BEGIN
                    SET NOCOUNT ON;
                    SELECT SH.ID, 
                           SH.ServiceDate, 
                           SH.ServiceKilometer, 
                           CC.LicencePlate, 
                           CM.ManufacturerName, 
                           CMO.ModelName, 
                           C.CustomerID,
                           C.CustomerSurname, 
                           C.CustomerName, 
                           C.CustomerEmail,
                           SH.NotifyNextService
                    FROM ServiceHistory SH
                         INNER JOIN CustomerCars CC ON CC.ID = SH.CustomerCarID
                                                       AND CC.GarageID = SH.GarageID
                         INNER JOIN CarModelManufacturerYear CMMY ON CMMY.ID = CC.ModelManufacturerYearID
                                                                     AND CMMY.GarageID = CC.GarageID
                         INNER JOIN CarManufacturer CM ON CM.ID = CMMY.CarManufacturerID
                                                          AND CM.GarageID = CMMY.GarageID
                         INNER JOIN CarModels CMO ON CMO.ID = CMMY.CarModelID
                                                     AND CMO.GarageID = CMMY.GarageID
                         INNER JOIN Customer C ON C.CustomerID = CC.CustomerID
                                                  AND C.GarageID = CC.GarageID
                    WHERE SH.GarageID = @GarageID
                          AND CAST(SH.ServiceDate AS DATE) <= CAST(@NotificationDate AS DATE)
                          AND SH.NotifyNextService = 1;
                END;
            GO";

            migrationBuilder.Sql(updateStoreProcedure);

            var updateStoreProcedureGetCustomerCar = @"
            ALTER PROCEDURE [dbo].[GetCustomerCar]
            -- Add the parameters for the stored procedure here
            @CustomerCarID BIGINT
            AS
                BEGIN
                    SET NOCOUNT ON;
                    SELECT CC.ID, 
                           CC.CustomerID, 
                           CMAN.ManufacturerName, 
                           CM.ModelName, 
                           CMY.Description AS ModelYear, 
                           CC.LicencePlate, 
                           CC.VIN, 
                           CC.Color, 
                           ISNULL(
                    (
                        SELECT MAX(ServiceKilometer)
                        FROM ServiceHistory
                        WHERE CustomerCarID = CC.ID
                              AND GarageID = CC.GarageID
                    ), CC.Kilometer) AS Kilometer, 
                           CC.CarImage, 
                           CET.EngineType
                    FROM CustomerCars CC
                         INNER JOIN CarModelManufacturerYear CMMY ON CMMY.ID = CC.ModelManufacturerYearID
                         INNER JOIN CarModels CM ON CM.ID = CMMY.CarModelID
                         INNER JOIN CarManufacturer CMAN ON CMAN.ID = CMMY.CarManufacturerID
                         INNER JOIN CarModelYear CMY ON CMY.ID = CMMY.CarModelYearID
                         INNER JOIN CarEngineType CET ON CET.ID = CC.EngineTypeID
                    WHERE CC.ID = @CustomerCarID;
                END;";

            migrationBuilder.Sql(updateStoreProcedureGetCustomerCar);

            var updateStoreProcedureGetCustomerCars = @"
            ALTER PROCEDURE [dbo].[GetCustomerCars]
            -- Add the parameters for the stored procedure here
            @CustomerID BIGINT
            AS
                BEGIN
                    SET NOCOUNT ON;
                    SELECT CC.ID, 
                           CC.CustomerID, 
                           CMAN.ManufacturerName, 
                           CM.ModelName, 
                           CMY.Description AS ModelYear, 
                           CC.LicencePlate, 
                           CC.VIN, 
                           CC.Color, 
                           ISNULL(
                    (
                        SELECT MAX(ServiceKilometer)
                        FROM ServiceHistory
                        WHERE CustomerCarID = CC.ID
                              AND GarageID = CC.GarageID
                    ), CC.Kilometer) AS Kilometer, 
                           CC.CarImage, 
                           CET.EngineType
                    FROM CustomerCars CC
                         INNER JOIN CarModelManufacturerYear CMMY ON CMMY.ID = CC.ModelManufacturerYearID
                         INNER JOIN CarModels CM ON CM.ID = CMMY.CarModelID
                         INNER JOIN CarManufacturer CMAN ON CMAN.ID = CMMY.CarManufacturerID
                         INNER JOIN CarModelYear CMY ON CMY.ID = CMMY.CarModelYearID
                         INNER JOIN CarEngineType CET ON CET.ID = CC.EngineTypeID
                    WHERE CC.CustomerID = @CustomerID;
                END;";

            migrationBuilder.Sql(updateStoreProcedureGetCustomerCars);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotifyDays",
                table: "ServiceHistory");

            migrationBuilder.DropColumn(
                name: "NotifyNextService",
                table: "ServiceHistory");

            migrationBuilder.AlterColumn<DateTime>(
               name: "InsDate",
               table: "Email",
               type: "datetime2",
               nullable: false,
               oldClrType: typeof(DateTime),
               oldType: "datetime");
        }

    }
}
