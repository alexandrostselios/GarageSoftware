using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class MajorChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var GetCarServiceHistory = @"ALTER PROCEDURE [dbo].[GetCarServiceHistory]
                -- Add the parameters for the stored procedure here
                @UserModelsID BIGINT
                AS
                    BEGIN
                        SET NOCOUNT ON;
                        SELECT SH.ID, 
                                SH.Description, 
                                CAST(SH.ServiceDate AS DATE) AS ServiceDate, 
                                CAST(SH.StartingDate AS DATE) AS StartingDate, 
                                CAST(SH.FinishingDate AS DATE) AS FinishingDate, 
                                SH.ServiceKilometer, 
                                SH.StartPrice, 
                                SH.FinalPrice, 
                                UE.Surname, 
                                UE.Name, 
                                CMAN.ManufacturerName, 
                                CM.ModelName, 
                                CMY.Description AS ModelYear, 
                                UM.ID AS UserModelsID, 
                                UM.LicencePlate, 
                                UM.VIN, 
                                UM.Color, 
                                UM.Kilometer, 
                                UM.CarImage,
                                SH.EngineerID
                        FROM UserModels UM
                                INNER JOIN CarModelManufacturerYear CMMY ON CMMY.ID = um.ModelManufacturerYearID
                                INNER JOIN CarModels CM ON CM.ID = CMMY.CarModelID
                                INNER JOIN CarManufacturer CMAN ON CMAN.ID = CMMY.CarManufacturerID
                                INNER JOIN CarModelYear CMY ON CMY.ID = CMMY.CarModelYearID
                                LEFT OUTER JOIN ServiceHistory SH ON UM.ID = SH.UserModelsID
                                LEFT OUTER JOIN Users UE ON UE.ID = EngineerID
                        WHERE SH.UserModelsID = @UserModelsID
                        ORDER BY SH.ServiceDate DESC;
                    END;
                GO";

            migrationBuilder.Sql(GetCarServiceHistory);

            var GetCustomerCars = @"CREATE PROCEDURE GetCarServiceHistoryByServiceHistoryID
                -- Add the parameters for the stored procedure here
                @ServiceHistoryID BIGINT
                AS
                BEGIN
	                SET NOCOUNT ON;
	                SELECT SH.ID, 
                       SH.Description, 
                        SH.GarageID,
                       CAST(SH.ServiceDate AS DATE) AS ServiceDate, 
                       CAST(SH.StartingDate AS DATE) AS StartingDate, 
                       CAST(SH.FinishingDate AS DATE) AS FinishingDate, 
                       SH.ServiceKilometer, 
                       SH.StartPrice, 
                       SH.FinalPrice, 
                       UE.Surname, 
                       UE.Name, 
                       CMAN.ManufacturerName, 
                       CM.ModelName, 
                       CMY.Description AS ModelYear, 
                       CET.EngineType,
                       UM.ID AS UserModelsID, 
                       UM.LicencePlate, 
                       UM.VIN, 
                       UM.Color, 
                       UM.Kilometer, 
                       UM.CarImage, 
                       SH.EngineerID,
                       SI.ID AS ServiceItemID, 
                       SI.Description AS ServiceItemDescription,
                       SI.Price AS ServiceItemPrice
                FROM UserModels UM
                     INNER JOIN CarModelManufacturerYear CMMY ON CMMY.ID = um.ModelManufacturerYearID
                     INNER JOIN CarModels CM ON CM.ID = CMMY.CarModelID
                     INNER JOIN CarManufacturer CMAN ON CMAN.ID = CMMY.CarManufacturerID
                     INNER JOIN CarModelYear CMY ON CMY.ID = CMMY.CarModelYearID
                     LEFT OUTER JOIN ServiceHistory SH ON UM.ID = SH.UserModelsID
                     LEFT OUTER JOIN ServiceHistoryItems SHI ON SHI.SHID = SH.ID
                     LEFT OUTER JOIN ServiceItems SI ON SI.ID = SHI.SIID
                     LEFT OUTER JOIN Users UE ON UE.ID = EngineerID
                     LEFT OUTER JOIN CarEngineType CET ON CET.ID = UM.EngineTypeID
                WHERE SH.ID = @ServiceHistoryID
                ORDER BY SH.ServiceDate DESC;
                END";

            migrationBuilder.Sql(GetCustomerCars);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
