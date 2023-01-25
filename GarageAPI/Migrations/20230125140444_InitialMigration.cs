using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarManufacturer",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarManufacturer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CarModelYear",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModelYear", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<long>(type: "bigint", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: true),
                    LastLoginDate = table.Column<DateTime>(type: "date", nullable: true),
                    EnableAccess = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CarModelManufacturerYear",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarManufacturerID = table.Column<long>(type: "bigint", nullable: false),
                    CarModelID = table.Column<long>(type: "bigint", nullable: false),
                    CarModelYearID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModelManufacturerYear", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CarModelManufacturerYear_CarManufacturer_CarManufacturerID",
                        column: x => x.CarManufacturerID,
                        principalTable: "CarManufacturer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarModelManufacturerYear_CarModelYear_CarModelYearID",
                        column: x => x.CarModelYearID,
                        principalTable: "CarModelYear",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarModelManufacturerYear_CarModels_CarModelID",
                        column: x => x.CarModelID,
                        principalTable: "CarModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserModels",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    ModelManufacturerYearID = table.Column<long>(type: "bigint", nullable: false),
                    ModelYearID = table.Column<long>(type: "bigint", nullable: false),
                    LicencePlate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<long>(type: "bigint", nullable: true),
                    Kilometer = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserModels_CarModelManufacturerYear_ModelManufacturerYearID",
                        column: x => x.ModelManufacturerYearID,
                        principalTable: "CarModelManufacturerYear",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserModels_CarModelYear_ModelYearID",
                        column: x => x.ModelYearID,
                        principalTable: "CarModelYear",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserModels_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CarManufacturer",
                columns: new[] { "ID", "ManufacturerName" },
                values: new object[,]
                {
                    { 1L, "Abarth" },
                    { 2L, "Alfa Romeo" },
                    { 3L, "Aston Martin" },
                    { 4L, "Audi" },
                    { 5L, "Bentley" },
                    { 6L, "BMW" },
                    { 7L, "Bugatti" },
                    { 8L, "Cadillac" },
                    { 9L, "Chevrolet" },
                    { 10L, "Chrysler" },
                    { 11L, "Citroën" },
                    { 12L, "Dacia" },
                    { 13L, "Daewoo" },
                    { 14L, "Daihatsu" },
                    { 15L, "Dodge" },
                    { 16L, "Donkervoort" },
                    { 17L, "DS" },
                    { 18L, "Ferrari" },
                    { 19L, "Fiat" },
                    { 20L, "Fisker" },
                    { 21L, "Ford" },
                    { 22L, "Honda" },
                    { 23L, "Hummer" },
                    { 24L, "Hyundai" },
                    { 25L, "Infiniti" },
                    { 26L, "Iveco" },
                    { 27L, "Jaguar" },
                    { 28L, "Jeep" },
                    { 29L, "Kia" },
                    { 30L, "KTM" },
                    { 31L, "Lada" },
                    { 32L, "Lamborghini" },
                    { 33L, "Lancia" },
                    { 34L, "Land Rover" },
                    { 35L, "Landwind" },
                    { 36L, "Lexus" },
                    { 37L, "Lotus" },
                    { 38L, "Maserati" },
                    { 39L, "Maybach" },
                    { 40L, "Mazda" },
                    { 41L, "McLaren" },
                    { 42L, "Mercedes-Benz" },
                    { 43L, "MG" },
                    { 44L, "Mini" },
                    { 45L, "Mitsubishi" },
                    { 46L, "Morgan" },
                    { 47L, "Nissan" },
                    { 48L, "Opel" },
                    { 49L, "Peugeot" },
                    { 50L, "Porsche" },
                    { 51L, "Renault" },
                    { 52L, "Rolls-Royce" },
                    { 53L, "Rover" },
                    { 54L, "Saab" },
                    { 55L, "Seat" },
                    { 56L, "Skoda" },
                    { 57L, "Smart" },
                    { 58L, "SsangYong" },
                    { 59L, "Subaru" },
                    { 60L, "Suzuki" },
                    { 61L, "Tesla" },
                    { 62L, "Toyota" },
                    { 63L, "Volkswagen" },
                    { 64L, "Volvo" }
                });

            migrationBuilder.InsertData(
                table: "CarModelYear",
                columns: new[] { "ID", "Description" },
                values: new object[,]
                {
                    { 1L, "1950" },
                    { 2L, "1951" },
                    { 3L, "1952" },
                    { 4L, "1953" },
                    { 5L, "1954" },
                    { 6L, "1955" },
                    { 7L, "1956" },
                    { 8L, "1957" },
                    { 9L, "1958" },
                    { 10L, "1959" },
                    { 11L, "1960" },
                    { 12L, "1961" },
                    { 13L, "1962" },
                    { 14L, "1963" },
                    { 15L, "1964" },
                    { 16L, "1965" },
                    { 17L, "1966" },
                    { 18L, "1967" },
                    { 19L, "1968" },
                    { 20L, "1969" },
                    { 21L, "1970" },
                    { 22L, "1971" },
                    { 23L, "1972" },
                    { 24L, "1973" },
                    { 25L, "1974" },
                    { 26L, "1975" },
                    { 27L, "1976" },
                    { 28L, "1977" },
                    { 29L, "1978" },
                    { 30L, "1979" },
                    { 31L, "1980" },
                    { 32L, "1981" },
                    { 33L, "1982" },
                    { 34L, "1983" },
                    { 35L, "1984" },
                    { 36L, "1985" },
                    { 37L, "1986" },
                    { 38L, "1987" },
                    { 39L, "1988" },
                    { 40L, "1989" },
                    { 41L, "1990" },
                    { 42L, "1991" },
                    { 43L, "1992" },
                    { 44L, "1993" },
                    { 45L, "1994" },
                    { 46L, "1995" },
                    { 47L, "1996" },
                    { 48L, "1997" },
                    { 49L, "1998" },
                    { 50L, "1999" },
                    { 51L, "2000" },
                    { 52L, "2001" },
                    { 53L, "2002" },
                    { 54L, "2003" },
                    { 55L, "2004" },
                    { 56L, "2005" },
                    { 57L, "2006" },
                    { 58L, "2007" },
                    { 59L, "2008" },
                    { 60L, "2009" },
                    { 61L, "2010" },
                    { 62L, "2011" },
                    { 63L, "2012" },
                    { 64L, "2013" },
                    { 65L, "2014" },
                    { 66L, "2015" },
                    { 67L, "2016" },
                    { 68L, "2017" },
                    { 69L, "2018" },
                    { 70L, "2019" },
                    { 71L, "2020" },
                    { 72L, "2021" },
                    { 73L, "2022" },
                    { 74L, "2023" }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "ID", "ModelName" },
                values: new object[,]
                {
                    { 1L, "Accent" },
                    { 2L, "Atos" },
                    { 3L, "Prime" },
                    { 4L, "Coupé" },
                    { 5L, "Elantra" },
                    { 6L, "Galloper" },
                    { 7L, "Genesis" },
                    { 8L, "Getz" },
                    { 9L, "Grandeur" },
                    { 10L, "H350" },
                    { 11L, "H1" },
                    { 12L, "H1Bus" },
                    { 13L, "H1Van" },
                    { 14L, "H200" },
                    { 15L, "i10" },
                    { 16L, "i20" },
                    { 17L, "i30" },
                    { 18L, "i30 CW" },
                    { 19L, "i40" },
                    { 20L, "i40 CW" },
                    { 21L, "ix20" },
                    { 22L, "ix35" },
                    { 23L, "ix55" },
                    { 24L, "Lantra" },
                    { 25L, "Matrix" },
                    { 26L, "SantaFe" },
                    { 27L, "Sonata" },
                    { 28L, "Terracan" },
                    { 29L, "Trajet" },
                    { 30L, "Tucson" },
                    { 31L, "Veloster" },
                    { 32L, "Kona" },
                    { 33L, "Tucson" },
                    { 34L, "Bayon" },
                    { 35L, "145" },
                    { 36L, "146" },
                    { 37L, "147" },
                    { 38L, "155" },
                    { 39L, "156" },
                    { 40L, "156 Sportwagon" },
                    { 41L, "159" },
                    { 42L, "159 Sportwagon" },
                    { 43L, "164" },
                    { 44L, "166" },
                    { 45L, "4C" },
                    { 46L, "Brera" },
                    { 47L, "GTV" },
                    { 48L, "MiTo" },
                    { 49L, "Crosswagon" },
                    { 50L, "Spider" },
                    { 51L, "GT" },
                    { 52L, "Giulietta" },
                    { 53L, "Giulia" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "CreationDate", "Email", "EnableAccess", "LastLoginDate", "ModifiedDate", "Name", "Password", "Surname", "UserType" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 1, 25, 16, 4, 44, 577, DateTimeKind.Local).AddTicks(5182), "atselios@classter.com", 1, null, null, "Alexandros", "1", "Tselios", 1L },
                    { 2L, new DateTime(2023, 1, 25, 16, 4, 44, 577, DateTimeKind.Local).AddTicks(5199), "efi.vanni@gmail.com", 1, null, null, "Efthumia", "f1234!", "Varvagianni", 1L },
                    { 3L, new DateTime(2023, 1, 25, 16, 4, 44, 577, DateTimeKind.Local).AddTicks(5211), "kkitsikou@hotmail.com", 1, null, null, "Kostas", "gafa#$#", "Kitsikou", 1L },
                    { 4L, new DateTime(2023, 1, 25, 16, 4, 44, 577, DateTimeKind.Local).AddTicks(5223), "mpapadopoulos@yahoo.gr", 1, null, null, "Marios", "DfG34#$%^", "Papadopoulos", 1L }
                });

            migrationBuilder.InsertData(
                table: "CarModelManufacturerYear",
                columns: new[] { "ID", "CarManufacturerID", "CarModelID", "CarModelYearID" },
                values: new object[,]
                {
                    { 1L, 24L, 2L, 61L },
                    { 2L, 24L, 2L, 62L },
                    { 3L, 24L, 2L, 63L },
                    { 4L, 24L, 15L, 61L },
                    { 5L, 24L, 16L, 62L },
                    { 6L, 24L, 17L, 63L }
                });

            migrationBuilder.InsertData(
                table: "UserModels",
                columns: new[] { "ID", "UserID", "ModelManufacturerYearID", "ModelYearID", "LicencePlate", "VIN", "Color", "Kilometer" },
                values: new object[,]
                {
                    {1L, 1L, 2L, 66L, "KBT5670", "ZAR94000007368150", 101, 156125},
                    {2L, 1L, 3L, 67L, "EYB7174", "VNKKG3D330A048555", 142, 27450},
                    {3L, 1L, 4L, 67L, "NIZ2654", "NLHBA51BABZ014926", 4, 88956},
                    {4L, 2L, 5L, 68L, "XEZ6532", "KHX94000007259841", 5, 220653},
                    {5L, 2L, 6L, 72L, "KBH1452", null, 6, 65402},
                    {6L, 3L, 6L, 73L, "AHZ1495", null, 6, 9563}
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarModelManufacturerYear_CarManufacturerID",
                table: "CarModelManufacturerYear",
                column: "CarManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_CarModelManufacturerYear_CarModelID",
                table: "CarModelManufacturerYear",
                column: "CarModelID");

            migrationBuilder.CreateIndex(
                name: "IX_CarModelManufacturerYear_CarModelYearID",
                table: "CarModelManufacturerYear",
                column: "CarModelYearID");

            migrationBuilder.CreateIndex(
                name: "IX_UserModels_ModelManufacturerYearID",
                table: "UserModels",
                column: "ModelManufacturerYearID");

            migrationBuilder.CreateIndex(
                name: "IX_UserModels_ModelYearID",
                table: "UserModels",
                column: "ModelYearID");

            migrationBuilder.CreateIndex(
                name: "IX_UserModels_UserID",
                table: "UserModels",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserModels");

            migrationBuilder.DropTable(
                name: "CarModelManufacturerYear");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CarManufacturer");

            migrationBuilder.DropTable(
                name: "CarModelYear");

            migrationBuilder.DropTable(
                name: "CarModels");
        }
    }
}
