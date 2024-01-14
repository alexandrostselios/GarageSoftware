using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangesInServiceHistoryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDiscountPercentage",
                table: "ServiceHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            var GetCarServiceHistory = @"
            ALTER PROCEDURE [dbo].[GetCarServiceHistory]
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
                           SH.EngineerID, 
                           SH.DiscountPrice, 
                           SH.DiscountPercentage, 
                           SH.isDiscountPercentage
                    FROM UserModels UM
                         INNER JOIN CarModelManufacturerYear CMMY ON CMMY.ID = um.ModelManufacturerYearID
                         INNER JOIN CarModels CM ON CM.ID = CMMY.CarModelID
                         INNER JOIN CarManufacturer CMAN ON CMAN.ID = CMMY.CarManufacturerID
                         INNER JOIN CarModelYear CMY ON CMY.ID = CMMY.CarModelYearID
                         LEFT OUTER JOIN ServiceHistory SH ON UM.ID = SH.UserModelsID
                         LEFT OUTER JOIN Users UE ON UE.ID = EngineerID
                    WHERE SH.UserModelsID = @UserModelsID
                    ORDER BY SH.ServiceDate DESC;
                END;";

            migrationBuilder.Sql(GetCarServiceHistory);

            var GetCarServiceHistoryByServiceHistoryID = @"
            ALTER PROCEDURE [dbo].[GetCarServiceHistoryByServiceHistoryID]
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
                           UE.Surname, 
                           UE.Name, 
                           SH.FinalPrice, 
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
                           SI.Price AS ServiceItemPrice,
			               SH.DiscountPrice,
			               SH.DiscountPercentage,
			               SH.isDiscountPercentage
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
                END;";

            migrationBuilder.Sql(GetCarServiceHistoryByServiceHistoryID);

            var UpdateServiceHistoryEntity = @"
            UPDATE SH
                SET SH.DiscountPrice = 0,
                SH.DiscountPercentage = 25,
                SH.isDiscountPercentage = 1
                FROM ServiceHistory SH
            WHERE ID = 1;";

            migrationBuilder.Sql(UpdateServiceHistoryEntity);

            var UpdateServiceHistoryEntity2 = @"
            UPDATE SH
                SET 
                    SH.DiscountPrice = 10
            FROM ServiceHistory SH
            WHERE ID = 2;";

            migrationBuilder.Sql(UpdateServiceHistoryEntity2);

            var GetCarsServiceHistoryToList = @"
            CREATE PROCEDURE [dbo].[GetCarsServiceHistoryToList]
            -- Add the parameters for the stored procedure here
            @GarageID BIGINT
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
                           SH.EngineerID, 
                           SH.DiscountPrice, 
                           SH.DiscountPercentage, 
                           SH.isDiscountPercentage
                    FROM UserModels UM
                         INNER JOIN CarModelManufacturerYear CMMY ON CMMY.ID = UM.ModelManufacturerYearID
                                                                     AND CMMY.GarageID = UM.GarageID
                         INNER JOIN CarModels CM ON CM.ID = CMMY.CarModelID
                                                    AND CM.GarageID = CMMY.GarageID
                         INNER JOIN CarManufacturer CMAN ON CMAN.ID = CMMY.CarManufacturerID
                                                            AND CMAN.GarageID = CMMY.GarageID
                         INNER JOIN CarModelYear CMY ON CMY.ID = CMMY.CarModelYearID
                                                        AND CMY.GarageID = CMMY.GarageID
                         LEFT OUTER JOIN ServiceHistory SH ON UM.ID = SH.UserModelsID
                                                              AND UM.GarageID = SH.GarageID
                         LEFT OUTER JOIN Users UE ON UE.ID = EngineerID
                                                     AND UE.GarageID = SH.GarageID
                    WHERE UM.GarageID = @GarageID
                          AND SH.ID IS NOT NULL
                    ORDER BY SH.ServiceDate DESC;
                END;
            GO";

            migrationBuilder.Sql(GetCarsServiceHistoryToList);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDiscountPercentage",
                table: "ServiceHistory");
        }
    }
}