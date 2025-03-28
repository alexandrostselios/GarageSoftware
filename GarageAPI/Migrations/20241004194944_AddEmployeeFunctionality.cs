using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeFunctionality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    GarageID = table.Column<long>(type: "bigint", nullable: false),
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    EmployeePhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EmployeeHomePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeMobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeComment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employee_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Email", "Password", "UserType", "CreationDate", "ModifiedDate", "LastLoginDate", "EnableAccess" }, // Specify column names here
                values: new object[,]
                {
                    { 30L, "admin@garage.com", "a1", 1, new DateTime(2020, 1, 6, 14, 5, 14, 258, DateTimeKind.Unspecified), null, null, (int)Enum.EnableAccess.Enable },
                    { 31L, "testEmployee1@temp.com", "e1", 4, new DateTime(2021, 1, 7, 14, 5, 14, 258, DateTimeKind.Unspecified).AddDays(1), null, null, (int)Enum.EnableAccess.Enable}
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeID", "EmployeeSurname", "EmployeeName", "EmployeeEmail", "CreationDate", "ModifiedDate", "GarageID", "UserID", "EmployeePhoto", "EmployeeHomePhone", "EmployeeMobilePhone" },
                values: new object[,]
                {
                    { 1L, "Admin", "Garage", "admin@garage.com", new DateTime(2021, 1, 6, 14, 5, 14, 258, DateTimeKind.Unspecified).AddDays(1), null, 1L, 30L, null, "2510123456", "6945012343" },
                    { 2L, "Test2", "Employee2", "testEmployee1@temp.com", new DateTime(2024, 1, 7, 14, 5, 14, 258, DateTimeKind.Unspecified).AddDays(19), null, 1L, 31L, null, null, "6943012569" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
