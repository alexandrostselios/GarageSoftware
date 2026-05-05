using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddNewGarageDetailsFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "LegalName",
                table: "GarageDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VATNumber",
                table: "GarageDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VATOffice",
                table: "GarageDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "GarageDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "GarageDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "GarageDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "GarageDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "GarageDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "GarageDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "GarageDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "GarageDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "GarageDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.Sql("UPDATE GD SET GD.LegalName = GD.Description+' A.E.', GD.Domain = 'garagewebportal.eu',GD.VATNumber = 0123456789, GD.VATOffice = N'ΚΑΒΑΛΑΣ', GD.Address = 'Omonoias 34',GD.City = 'Kavala',GD.Country = 'Greece',GD.Region = 'East Macedonia and Thrace',GD.ZipCode = '65403', GD.Email = 'admin.garage@garage.com', GD.PhoneNumber = '2510000000', GD.Website = 'https://garagewebportal.eu' FROM GarageDetails GD;\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "GarageDetails");

            migrationBuilder.DropColumn(
                name: "City",
                table: "GarageDetails");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "GarageDetails");

            migrationBuilder.DropColumn(
                name: "LegalName",
                table: "GarageDetails");

            migrationBuilder.DropColumn(
                name: "VATNumber",
                table: "GarageDetails");

            migrationBuilder.DropColumn(
                name: "VATOffice",
                table: "GarageDetails");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "GarageDetails");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "GarageDetails");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "GarageDetails");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "GarageDetails");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "GarageDetails");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "GarageDetails");
        }
    }
}
