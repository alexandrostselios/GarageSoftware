using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class ModifyReportTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "TaxOffices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<long>(
                name: "ID",
                table: "TaxOffices",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "ReportDefinition",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemplateType = table.Column<long>(type: "bigint", nullable: false),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InUse = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDefinition", x => x.ID);
                });

            migrationBuilder.Sql("insert into ReportDefinition (ReportName, TemplateType,[Definition],InsertDate, InUse)\r\nvalues('Customers',1,N'@using System.Collections.Generic\r\n@model IEnumerable<ReportAPI.Models.Customer>\r\n\r\n<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta charset=\"utf-8\" />\r\n    <title>Customers</title>\r\n    <style>\r\n        table {\r\n            border-collapse: collapse;\r\n            width: 100%;\r\n        }\r\n        th, td {\r\n            border: 1px solid #ccc;\r\n            padding: 8px;\r\n            text-align: center;\r\n        }\r\n        th {\r\n            background-color: lightgreen;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <table>\r\n        <thead>\r\n            <tr>\r\n                <th>ID</th>\r\n                <th>Name</th>\r\n                <th>Surname</th>\r\n                <th>Mobile</th>\r\n                <th>Email</th>\r\n                <th>Comments</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n            @foreach (var customer in Model)\r\n            {\r\n                <tr>\r\n                    <td>@customer.CustomerID</td>\r\n                    <td>@customer.CustomerName</td>\r\n                    <td>@customer.CustomerSurname</td>\r\n                    <td>@customer.CustomerMobilePhone</td>\r\n                    <td>@customer.CustomerEmail</td>\r\n                    <td>@customer.CustomerComment</td>\r\n                </tr>\r\n            }\r\n        </tbody>\r\n    </table>\r\n</body>\r\n</html>\r\n\r\n',GETDATE(), 1)");
            migrationBuilder.Sql("insert into ReportDefinition (ReportName, TemplateType,[Definition],InsertDate, InUse)\r\nvalues('Employees',2,N'@using System.Collections.Generic\r\n@model IEnumerable<ReportAPI.Models.Employee>\r\n\r\n<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta charset=\"utf-8\" />\r\n    <title>Employees</title>\r\n    <style>\r\n        table {\r\n            border-collapse: collapse;\r\n            width: 100%;\r\n        }\r\n        th, td {\r\n            border: 1px solid #ccc;\r\n            padding: 8px;\r\n            text-align: center;\r\n        }\r\n        th {\r\n            background-color: yellow;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <table>\r\n        <thead>\r\n            <tr>\r\n                <th>ID</th>\r\n                <th>Name</th>\r\n                <th>Surname</th>\r\n                <th>Mobile</th>\r\n                <th>Email</th>\r\n                <th>Comment</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n            @foreach (var employee in Model)\r\n            {\r\n                <tr>\r\n                    <td>@employee.EmployeeID</td>\r\n                    <td>@employee.EmployeeName</td>\r\n                    <td>@employee.EmployeeSurname</td>\r\n                    <td>@employee.EmployeeMobilePhone</td>\r\n                    <td>@employee.EmployeeEmail</td>\r\n                    <td>@employee.EmployeeComment</td>\r\n                </tr>\r\n            }\r\n        </tbody>\r\n    </table>\r\n</body>\r\n</html>\r\n',GETDATE(), 1)");
            migrationBuilder.Sql("insert into ReportDefinition (ReportName, TemplateType,[Definition],InsertDate, InUse)\r\nvalues('Engineers',3,N'@using System.Collections.Generic\r\n@using System.Linq\r\n@model IEnumerable<ReportAPI.Models.Engineer>\r\n\r\n<!DOCTYPE html>\r\n<html>\r\n    <head>\r\n        <meta charset=\"utf-8\" />\r\n        <title>Engineers</title>\r\n        <style>\r\n            table {\r\n                border-collapse: collapse;\r\n                width: 100%;\r\n            }\r\n            th, td {\r\n                border: 1px solid #ccc;\r\n                padding: 8px;\r\n                text-align: center;\r\n            }\r\n            th {\r\n                background-color: yellow;\r\n            }\r\n        </style>\r\n    </head>\r\n\r\n    <body>\r\n        <table>\r\n            <thead>\r\n                <tr>\r\n                    <th>ID</th>\r\n                    <th>Name</th>\r\n                    <th>Surname</th>\r\n                    <th>Home Phone</th>\r\n                    <th>Mobile Phone</th>\r\n                    <th>Email</th>\r\n                    <th>Comments</th>\r\n                    <th>Specialities</th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n                @foreach (var engineer in Model)\r\n                {\r\n                    <tr>\r\n                        <td>@engineer.EngineerID</td>\r\n                        <td>@engineer.EngineerName</td>\r\n                        <td>@engineer.EngineerSurname</td>\r\n                        <td>@engineer.EngineerHomePhone</td>\r\n                        <td>@engineer.EngineerMobilePhone</td>\r\n                        <td>@engineer.EngineerEmail</td>\r\n                        <td>@engineer.EngineerComment</td>\r\n                        <td>\r\n                            @foreach (var speciality in engineer.EngineerSpecialities)\r\n                            {\r\n                                <span>@speciality.Speciality</span>\r\n                                @if (!speciality.Equals(engineer.EngineerSpecialities.Last()))\r\n                                {\r\n                                        <span>, </span>\r\n                                }\r\n                            }\r\n                            @(engineer.EngineerSpecialities.Count == 0 ? \"-\" : \"\")\r\n                        </td>\r\n                    </tr>\r\n                }\r\n            </tbody>\r\n        </table>\r\n    </body>\r\n</html>',GETDATE(), 1)");
            migrationBuilder.Sql("insert into ReportDefinition (ReportName, TemplateType,[Definition],InsertDate, InUse)\r\nvalues('ServiceAppointments',4,N'@model IEnumerable<ReportAPI.Models.ServiceAppointment>\r\n\r\n<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta charset=\"utf-8\" />\r\n    <title>Customers</title>\r\n    <style>\r\n        table {\r\n            border-collapse: collapse;\r\n            width: 100%;\r\n        }\r\n        th, td {\r\n            border: 1px solid #ccc;\r\n            padding: 8px;\r\n            text-align: center;\r\n        }\r\n        th {\r\n            background-color: lightgreen;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <table>\r\n        <thead>\r\n            <tr>\r\n                <th>ID</th>\r\n                <th>Customer</th>\r\n                <th>Manufacturer Name</th>\r\n                <th>Model Name</th>\r\n                <th>Licence Plate</th>\r\n                <th>Kilometer</th>\r\n                <th>Date</th>\r\n                <th>Comments</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n            @foreach (var serviceAppointment in Model)\r\n            {\r\n                <tr>\r\n                    <td>@serviceAppointment.ID</td>\r\n                    <td>@serviceAppointment.Customer</td>\r\n                    <td>@serviceAppointment.ManufacturerName</td>\r\n                    <td>@serviceAppointment.ModelName</td>\r\n                    <td>@serviceAppointment.LicencePlate</td>\r\n                    <td>@serviceAppointment.Kilometer</td>\r\n                    <td>@serviceAppointment.ServiceAppointmentDate</td>\r\n                    <td>@serviceAppointment.ServiceAppointmentComments</td>\r\n                </tr>\r\n            }\r\n        </tbody>\r\n    </table>\r\n</body>\r\n</html>\r\n',GETDATE(), 1)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportDefinition");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "TaxOffices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "TaxOffices",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.ID);
                });
        }
    }
}
