using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenameCarEngineTypeToCarFuelType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "CarEngineType",
                newName: "CarFuelType"
            );

            migrationBuilder.RenameColumn(
                name: "EngineType",
                table: "CarFuelType",
                newName: "FuelType"
            );

            var updateGetCustomerCars = @"
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
                               CFT.FuelType
                        FROM CustomerCars CC
                             INNER JOIN CarModelManufacturerYear CMMY ON CMMY.ID = CC.ModelManufacturerYearID
                             INNER JOIN CarModels CM ON CM.ID = CMMY.CarModelID
                             INNER JOIN CarManufacturer CMAN ON CMAN.ID = CMMY.CarManufacturerID
                             INNER JOIN CarModelYear CMY ON CMY.ID = CMMY.CarModelYearID
                             INNER JOIN CarFuelType CFT ON CFT.ID = CC.EngineTypeID
                        WHERE CC.CustomerID = @CustomerID;
                    END;";

            migrationBuilder.Sql(updateGetCustomerCars);

            var updateGetCustomerCar = @"
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
                               CFT.FuelType
                        FROM CustomerCars CC
                             INNER JOIN CarModelManufacturerYear CMMY ON CMMY.ID = CC.ModelManufacturerYearID
                             INNER JOIN CarModels CM ON CM.ID = CMMY.CarModelID
                             INNER JOIN CarManufacturer CMAN ON CMAN.ID = CMMY.CarManufacturerID
                             INNER JOIN CarModelYear CMY ON CMY.ID = CMMY.CarModelYearID
                             INNER JOIN CarFuelType CFT ON CFT.ID = CC.EngineTypeID
                        WHERE CC.ID = @CustomerCarID;
                    END;";

            migrationBuilder.Sql(updateGetCustomerCar);

            var updateGetCarServiceHistoryByServiceHistoryID = @"
               ALTER PROCEDURE [dbo].[GetCarServiceHistoryByServiceHistoryID]
                -- Add the parameters for the stored procedure here
                @ServiceHistoryID BIGINT
                AS
                    BEGIN
                        SET NOCOUNT ON;
                        SELECT SH.ID, 
                               CC.ID AS CustomerCarID, 
                               CC.LicencePlate, 
                               CC.VIN, 
                               CC.Color, 
                               CC.Kilometer, 
                               CC.CarImage, 
                               SH.Description, 
                               SH.GarageID, 
                               CAST(SH.ServiceDate AS DATE) AS ServiceDate, 
                               CAST(SH.StartingDate AS DATE) AS StartingDate, 
                               CAST(SH.FinishingDate AS DATE) AS FinishingDate, 
                               SH.ServiceKilometer, 
                               E.EngineerID, 
                               E.EngineerSurname, 
                               E.EngineerName, 
                               CMAN.ManufacturerName, 
                               CM.ModelName, 
                               CMY.Description AS ModelYear, 
                               CFT.FuelType, 
                               SI.ID AS ServiceItemID, 
                               SI.Description AS ServiceItemDescription, 
                               SHI.Price AS ServiceItemPrice, 
                               SH.StartPrice, 
                               SH.FinalPrice, 
                               SH.DiscountPrice, 
                               SH.DiscountPercentage, 
                               SH.isDiscountPercentage
                        FROM CustomerCars CC
                             INNER JOIN CarModelManufacturerYear CMMY ON CMMY.ID = CC.ID
                             INNER JOIN CarModels CM ON CM.ID = CMMY.CarModelID
                             INNER JOIN CarManufacturer CMAN ON CMAN.ID = CMMY.CarManufacturerID
                             INNER JOIN CarModelYear CMY ON CMY.ID = CMMY.CarModelYearID
                             LEFT OUTER JOIN ServiceHistory SH ON SH.CustomerCarID = CC.ID
                             LEFT OUTER JOIN ServiceHistoryItems SHI ON SHI.SHID = SH.ID
                             LEFT OUTER JOIN ServiceItems SI ON SI.ID = SHI.SIID
                             LEFT OUTER JOIN Engineer E ON E.EngineerID = SH.EngineerID
                             LEFT OUTER JOIN CarFuelType CFT ON CFT.ID = CC.EngineTypeID
                        WHERE SH.ID = @ServiceHistoryID
                        ORDER BY SH.ServiceDate DESC;
                    END;";

            migrationBuilder.Sql(updateGetCarServiceHistoryByServiceHistoryID);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "CarFuelType",
                newName: "CarEngineType"
            );

            migrationBuilder.RenameColumn(
                name: "FuelType",
                table: "CarFuelType",
                newName: "EngineType"
            );
        }

    }
}
