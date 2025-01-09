using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class MinorChangesInModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserModelsID",
                table: "ServiceHistory",
                newName: "CustomerCarID");

            migrationBuilder.Sql("ALTER PROCEDURE [dbo].[GetCarServiceHistory]\r\n-- Add the parameters for the stored procedure here\r\n@CustomerCarID BIGINT\r\nAS\r\n    BEGIN\r\n        SET NOCOUNT ON;\r\n        SELECT SH.ID, \r\n                SH.Description, \r\n                CAST(SH.ServiceDate AS DATE) AS ServiceDate, \r\n                CAST(SH.StartingDate AS DATE) AS StartingDate, \r\n                CAST(SH.FinishingDate AS DATE) AS FinishingDate, \r\n                SH.ServiceKilometer, \r\n                SH.StartPrice, \r\n                SH.FinalPrice, \r\n                E.EngineerSurname, \r\n                E.Engineername, \r\n                CMAN.ManufacturerName, \r\n                CM.ModelName, \r\n                CMY.Description AS ModelYear, \r\n                CC.ID AS CustomerCarID, \r\n                CC.LicencePlate, \r\n                CC.VIN, \r\n                CC.Color, \r\n                CC.Kilometer, \r\n                CC.CarImage, \r\n                SH.EngineerID, \r\n                SH.DiscountPrice, \r\n                SH.DiscountPercentage, \r\n                SH.isDiscountPercentage\r\n        FROM CustomerCars CC\r\n                INNER JOIN CarModelManufacturerYear CMMY ON CMMY.ID = CC.ModelManufacturerYearID\r\n                INNER JOIN CarModels CM ON CM.ID = CMMY.CarModelID\r\n                INNER JOIN CarManufacturer CMAN ON CMAN.ID = CMMY.CarManufacturerID\r\n                INNER JOIN CarModelYear CMY ON CMY.ID = CMMY.CarModelYearID\r\n                LEFT OUTER JOIN ServiceHistory SH ON CC.ID = SH.CustomerCarID\r\n                LEFT OUTER JOIN Engineer E ON E.EngineerID = SH.EngineerID\r\n        WHERE SH.CustomerCarID = @CustomerCarID\r\n        ORDER BY SH.ServiceDate DESC;\r\n    END;");
            migrationBuilder.Sql("ALTER PROCEDURE [dbo].[GetCarServiceHistoryByServiceHistoryID]\r\n-- Add the parameters for the stored procedure here\r\n@ServiceHistoryID BIGINT\r\nAS\r\n    BEGIN\r\n        SET NOCOUNT ON;\r\n        SELECT SH.ID, \r\n               CC.ID AS CustomerCarID, \r\n               CC.LicencePlate, \r\n               CC.VIN, \r\n               CC.Color, \r\n               CC.Kilometer, \r\n               CC.CarImage, \r\n               SH.Description, \r\n               SH.GarageID, \r\n               CAST(SH.ServiceDate AS DATE) AS ServiceDate, \r\n               CAST(SH.StartingDate AS DATE) AS StartingDate, \r\n               CAST(SH.FinishingDate AS DATE) AS FinishingDate, \r\n               SH.ServiceKilometer, \r\n               E.EngineerID, \r\n               E.EngineerSurname, \r\n               E.EngineerName, \r\n               CMAN.ManufacturerName, \r\n               CM.ModelName, \r\n               CMY.Description AS ModelYear, \r\n               CET.EngineType, \r\n               SI.ID AS ServiceItemID, \r\n               SI.Description AS ServiceItemDescription, \r\n               SHI.Price AS ServiceItemPrice, \r\n               SH.StartPrice, \r\n               SH.FinalPrice, \r\n               SH.DiscountPrice, \r\n               SH.DiscountPercentage, \r\n               SH.isDiscountPercentage\r\n        FROM CustomerCars CC\r\n             INNER JOIN CarModelManufacturerYear CMMY ON CMMY.ID = CC.ID\r\n             INNER JOIN CarModels CM ON CM.ID = CMMY.CarModelID\r\n             INNER JOIN CarManufacturer CMAN ON CMAN.ID = CMMY.CarManufacturerID\r\n             INNER JOIN CarModelYear CMY ON CMY.ID = CMMY.CarModelYearID\r\n             LEFT OUTER JOIN ServiceHistory SH ON SH.CustomerCarID = CC.ID\r\n             LEFT OUTER JOIN ServiceHistoryItems SHI ON SHI.SHID = SH.ID\r\n             LEFT OUTER JOIN ServiceItems SI ON SI.ID = SHI.SIID\r\n             LEFT OUTER JOIN Engineer E ON E.EngineerID = SH.EngineerID\r\n             LEFT OUTER JOIN CarEngineType CET ON CET.ID = CC.EngineTypeID\r\n        WHERE SH.ID = @ServiceHistoryID\r\n        ORDER BY SH.ServiceDate DESC;\r\n    END;");
            migrationBuilder.Sql("CREATE PROCEDURE [dbo].[GetCarServiceHistories]\r\n-- Add the parameters for the stored procedure here\r\n@GarageID         BIGINT, \r\n@NotificationDate DATETIME\r\nAS\r\n    BEGIN\r\n        SET NOCOUNT ON;\r\n        SELECT SH.ID, \r\n               SH.ServiceDate, \r\n               SH.ServiceKilometer, \r\n               CC.LicencePlate, \r\n               CM.ManufacturerName, \r\n               CMO.ModelName, \r\n               C.CustomerSurname, \r\n               C.CustomerName, \r\n               C.CustomerEmail\r\n        FROM ServiceHistory SH\r\n             INNER JOIN CustomerCars CC ON CC.ID = SH.CustomerCarID\r\n                                           AND CC.GarageID = SH.GarageID\r\n             INNER JOIN CarModelManufacturerYear CMMY ON CMMY.ID = CC.ModelManufacturerYearID\r\n                                                         AND CMMY.GarageID = CC.GarageID\r\n             INNER JOIN CarManufacturer CM ON CM.ID = CMMY.CarManufacturerID\r\n                                              AND CM.GarageID = CMMY.GarageID\r\n             INNER JOIN CarModels CMO ON CMO.ID = CMMY.CarModelID\r\n                                         AND CMO.GarageID = CMMY.GarageID\r\n             INNER JOIN Customer C ON C.CustomerID = CC.CustomerID\r\n                                      AND C.GarageID = CC.GarageID\r\n        WHERE SH.GarageID = @GarageID\r\n              AND CAST(SH.ServiceDate AS DATE) <= CAST(@NotificationDate AS DATE);\r\n    END;\r\nGO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerCarID",
                table: "ServiceHistory",
                newName: "UserModelsID");
        }
    }
}
