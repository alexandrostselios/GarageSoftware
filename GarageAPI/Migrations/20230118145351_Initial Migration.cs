using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    ID = table.Column<int>(type: "int", nullable: false)
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
                    UsersID = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_UserModels_Users_UsersID",
                        column: x => x.UsersID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
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
                name: "IX_UserModels_UsersID",
                table: "UserModels",
                column: "UsersID");
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
