using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceAppointmentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceAppointment",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<long>(type: "bigint", nullable: false),
                    CustomerCarID = table.Column<long>(type: "bigint", nullable: false),
                    ServiceAppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceAppointmentComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kilometer = table.Column<long>(type: "bigint", nullable: false),
                    GarageID = table.Column<long>(type: "bigint", nullable: false),
                    ServiceAppointmentStatus = table.Column<int>(type: "int", nullable: false, defaultValue: 1L) // Updated column definition

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceAppointment", x => x.ID);
                    table.ForeignKey(
                       name: "FK_ServiceAppointment_Customer_CustomerID",
                       column: x => x.CustomerID,
                       principalTable: "Customer",
                       principalColumn: "CustomerID",
                       onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                       name: "FK_ServiceAppointment_CustomerCars_CustomerCarID",
                       column: x => x.CustomerCarID,
                       principalTable: "CustomerCars",
                       principalColumn: "ID",
                       onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                       name: "FK_ServiceAppointment_GarageDetails_GarageID",
                       column: x => x.GarageID,
                       principalTable: "GarageDetails",
                       principalColumn: "ID",
                       onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCars_CarFuelType_EngineTypeID",
                table: "CustomerCars",
                column: "EngineTypeID",
                principalTable: "CarFuelType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.Sql("INSERT INTO [dbo].[ServiceAppointment]([CustomerID],  [CustomerCarID],  [ServiceAppointmentDate],  [ServiceAppointmentComments], [ServiceAppointmentStatus], [Kilometer], [GarageID]) VALUES (1,  1, GETDATE(),  'General check', 1, 165708 ,1);");
            migrationBuilder.Sql("INSERT INTO [dbo].[ServiceAppointment]([CustomerID],  [CustomerCarID],  [ServiceAppointmentDate],  [ServiceAppointmentComments], [ServiceAppointmentStatus], [Kilometer], [GarageID]) VALUES (1,  2, GETDATE(),  'Check Engine light come up', 2, 35652 ,1);");
            migrationBuilder.Sql("INSERT INTO [dbo].[ServiceAppointment]([CustomerID],  [CustomerCarID],  [ServiceAppointmentDate],  [ServiceAppointmentComments], [ServiceAppointmentStatus], [Kilometer], [GarageID]) VALUES (1,  2, GETDATE()+1,  'Yearly Service', 1, 47230 ,1);");
            migrationBuilder.Sql("INSERT INTO [dbo].[ServiceAppointment]([CustomerID],  [CustomerCarID],  [ServiceAppointmentDate],  [ServiceAppointmentComments], [ServiceAppointmentStatus], [Kilometer], [GarageID]) VALUES (2,  5, GETDATE()+2,  'Yearly Service and break change', 3, 70253 ,1);");

            var addGetServiceAppointmentsToListLiteral = @"
                CREATE PROCEDURE [dbo].[GetServiceAppointmentsToListLiteral]
                -- Add the parameters for the stored procedure here
                @GarageID BIGINT
                AS
                    BEGIN
                        SET NOCOUNT ON;
                        SELECT SA.ID, 
                               SA.ServiceAppointmentDate, 
                               SA.ServiceAppointmentComments, 
                               SA.ServiceAppointmentStatus,
                               SA.Kilometer,
                               C.CustomerID, 
                               C.CustomerSurname, 
                               C.CustomerName, 
                               C.CustomerEmail, 
                               CM.ManufacturerName, 
                               CMO.ModelName, 
                               CC.ID as CustomerCarID,
                               CC.LicencePlate, 
                               CC.VIN, 
                               CC.Color
                        FROM ServiceAppointment SA
                             INNER JOIN CustomerCars CC ON CC.ID = SA.CustomerCarID
                                                           AND CC.CustomerID = SA.CustomerID
                                                           AND CC.GarageID = SA.GarageID
                             INNER JOIN Customer C ON C.CustomerID = CC.CustomerID
                                                      AND C.GarageID = CC.GarageID
                             INNER JOIN CarModelManufacturerYear CMMY ON CMMY.ID = CC.ModelManufacturerYearID
                                                                         AND CMMY.GarageID = CC.GarageID
                             INNER JOIN CarManufacturer CM ON CM.ID = CMMY.CarManufacturerID
                                                              AND CM.GarageID = CMMY.GarageID
                             INNER JOIN CarModels CMO ON CMO.ID = CMMY.CarModelID
                                                         AND CMO.GarageID = CMMY.GarageID
                        WHERE SA.GarageID = @GarageID;
                    END;
                GO";

            migrationBuilder.Sql(addGetServiceAppointmentsToListLiteral);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.AddForeignKey(
                name: "FK_CustomerCars_CarEngineType_EngineTypeID",
                table: "CustomerCars",
                column: "EngineTypeID",
                principalTable: "CarEngineType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}