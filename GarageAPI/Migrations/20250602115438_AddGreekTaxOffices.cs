using GarageAPI.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Emit;

#nullable disable

namespace GarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddGreekTaxOffices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxOffices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GarageID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxOffices", x => x.ID);
                });

            migrationBuilder.Sql("INSERT INTO TaxOffices(Description, Address, ZipCode, PhoneNumber, Email, GarageID) VALUES\r\n(N'ΔΟΥ Α'' Αθηνών', N'Αναξαγόρα 6-8, Αθήνα', '10552', '2131604160', 'doy.a-athinon@aade.gr', 1),\r\n(N'ΔΟΥ Δ'' Αθηνών', N'Κωλέττη 14Α, Αθήνα', '10410', '2131604301', 'doy.d-athinon@aade.gr', 1),\r\n(N'ΔΟΥ ΙΓ'' Αθηνών', N'Λεωφ. Βείκου 139, Γαλάτσι', '11146', '2131607313', 'doy.ig-athinon@aade.gr', 1),\r\n(N'ΔΟΥ Ηλιούπολης', N'Λεωφ. Βουλιαγμένης 387, Ηλιούπολη', '16346', '2109751095', 'doy.ilioupolis@aade.gr', 1),\r\n(N'ΔΟΥ Κατοίκων Εξωτερικού', N'Μετσόβου 4, Αθήνα', '10682', '2108204631', 'doy.katoikon-exoterikou@aade.gr', 1),\r\n(N'ΔΟΥ Πειραιά Α''', N'Ακτή Μιαούλη 85, Πειραιάς', '18538', '2131603901', 'doy.a-peiraia@aade.gr', 1),\r\n(N'ΔΟΥ Θεσσαλονίκης Α''', N'Στρατηγού Μακρυγιάννη 5, Θεσσαλονίκη', '54638', '2313335100', 'doy.a-thessalonikis@aade.gr', 1),\r\n(N'ΔΟΥ Πατρών Α', N'Κανάρη 44, Πάτρα', '26221', '2613613300', 'doy.a-patras@aade.gr', 1),\r\n(N'ΔΟΥ Λάρισας', N'Ηρώων Πολυτεχνείου 211, Λάρισα', '41222', '2410680000', 'doy.larisas@aade.gr', 1),\r\n(N'ΔΟΥ Ηρακλείου Κρήτης', N'Λεωφ. Κνωσού 181, Ηράκλειο', '71409', '2813403300', 'doy.irakleiou@aade.gr', 1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxOffices");
        }
    }
}