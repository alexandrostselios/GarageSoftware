using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceFieldToServiceHistoryItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ServiceHistoryItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Domain",
                table: "GarageDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            var updateServiceHistoryItems = @"
                UPDATE ServiceHistoryItems
                  SET 
                      Price = 40
                WHERE SHID = 1
                      AND SIID = 1;

                UPDATE ServiceHistoryItems
                  SET 
                      Price = 45
                WHERE SHID = 1
                      AND SIID = 2;

                UPDATE ServiceHistoryItems
                  SET 
                      Price = 155
                WHERE SHID = 1
                      AND SIID = 4;

                UPDATE ServiceHistoryItems
                  SET 
                      Price = 2.55
                WHERE SHID = 1
                      AND SIID = 13;";

            migrationBuilder.Sql(updateServiceHistoryItems);


            var udpateGetCarServiceHistoryByServiceHistoryID = @"
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
                                           SHI.Price AS ServiceItemPrice,
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

            migrationBuilder.Sql(udpateGetCarServiceHistoryByServiceHistoryID);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ServiceHistoryItems");

            migrationBuilder.DropColumn(
                name: "Domain",
                table: "GarageDetails");
        }
    }
}