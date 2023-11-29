using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceHistoryItemsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceHistoryItems",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SHID = table.Column<long>(type: "bigint", nullable: false),
                    SIID = table.Column<long>(type: "bigint", nullable: false),
                    GarageID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceHistoryItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ServiceHistoryItems_GarageDetails_GarageID",
                        column: x => x.GarageID,
                        principalTable: "GarageDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceHistoryItems_ServiceHistory_SHID",
                        column: x => x.SHID,
                        principalTable: "ServiceHistory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceHistoryItems_ServiceItems_SIID",
                        column: x => x.SIID,
                        principalTable: "ServiceItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistoryItems_GarageID",
                table: "ServiceHistoryItems",
                column: "GarageID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistoryItems_SHID",
                table: "ServiceHistoryItems",
                column: "SHID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistoryItems_SIID",
                table: "ServiceHistoryItems",
                column: "SIID");

            migrationBuilder.InsertData(
                table: "ServiceHistoryItems",
                columns: new[] { "ID", "SHID","SIID","GarageID"},
                values: new object[,]
                {
                    { 1L,1L, 1L, 1L},
                    { 2L,1L, 2L, 1L},
                    { 3L,1L, 4L, 1L},
                    { 4L,1L, 13L, 1L},
                    { 5L,1L, 8L, 1L},
                    { 6L,1L, 9L, 1L}
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceHistoryItems");
        }
    }
}
