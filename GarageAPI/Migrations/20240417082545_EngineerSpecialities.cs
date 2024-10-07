using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class EngineerSpecialities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "EngineerSpecialities",
            //    columns: table => new
            //    {
            //        ID = table.Column<long>(type: "bigint", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
            //        EngineerID = table.Column<long>(type: "bigint", nullable: false),
            //        SpecialityID = table.Column<long>(type: "bigint", nullable: false),
            //        GarageID = table.Column<long>(type: "bigint", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_EngineerSpecialities", x => new {x.EngineerID, x.SpecialityID });
            //        table.UniqueConstraint("AK_EngineerSpecialities_ID", x => x.ID); // Add unique constraint on ID column
            //        table.ForeignKey(
            //            name: "FK_EngineerSpecialities_Engineer_EngineerID",
            //            column: x => x.EngineerID,
            //            principalTable: "Engineer",
            //            principalColumn: "EngineerID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_EngineerSpecialities_EngineerSpeciality_SpecialityID",
            //            column: x => x.SpecialityID,
            //            principalTable: "EngineerSpeciality",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_EngineerSpecialities_GarageDetails_GarageID",
            //            column: x => x.GarageID,
            //            principalTable: "GarageDetails",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Cascade);
            //    });
            migrationBuilder.CreateTable(
                name: "EngineerSpecialities",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EngineerID = table.Column<long>(type: "bigint", nullable: false),
                    SpecialityID = table.Column<long>(type: "bigint", nullable: false),
                    GarageID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineerSpecialities", x => x.ID); // Set ID as primary key
                    table.UniqueConstraint("AK_EngineerSpecialities_EngineerID_SpecialityID", x => new { x.EngineerID, x.SpecialityID }); // Add unique constraint on EngineerID and SpecialityID
                    table.ForeignKey(
                        name: "FK_EngineerSpecialities_Engineer_EngineerID",
                        column: x => x.EngineerID,
                        principalTable: "Engineer",
                        principalColumn: "EngineerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EngineerSpecialities_EngineerSpeciality_SpecialityID",
                        column: x => x.SpecialityID,
                        principalTable: "EngineerSpeciality",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EngineerSpecialities_GarageDetails_GarageID",
                        column: x => x.GarageID,
                        principalTable: "GarageDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.InsertData(
                table: "EngineerSpecialities",
                columns: new[] { "ID", "EngineerID", "SpecialityID", "GarageID"}, // Specify column names here
                values: new object[,]
                {
                    { 1L, 1L, 1L, 1L},
                    { 2L, 1L, 2L, 1L},
                    { 3L, 1L, 3L, 1L },
                    { 4L, 2L, 1L, 1L },
                    { 5L, 2L, 3L, 1L},
                    { 6L, 3L, 4L, 1L }
                });

            migrationBuilder.InsertData(
                table: "CustomerCars",
                columns: new[] { "ID", "CustomerID", "ModelManufacturerYearID", "LicencePlate", "VIN", "Color", "Kilometer", "CarImage", "EngineTypeID", "GarageID" }, // Specify column names here
                values: new object[,]
                {
                    { 1L, 1, 56L, "KBB1234", "AFG94025607385960", 101, 156125, null, 3L, 1L },
                    { 2L, 1L, 81L, "EYX2536", "VNKKG3D253B048254", 142, 27450, null, 2L, 1L },
                    { 3L, 1L, 3L, "NIZ1234", "NLHBA51BABZ063524", 4, 88956, null, 2L, 1L },
                    { 4L, 2L, 5L, "XEZ6532", "KHX94000007259841", 5, 220653, null, 4L, 1L },
                    { 5L, 2L, 6L, "KBH1452", "JNKCV61E09M303716", 6, 65402, null, 3L, 1L },
                    { 6L, 3L, 6L, "AHZ1495", "JH4DA9460MS032070", 6, 9563, null, 8L, 1L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
