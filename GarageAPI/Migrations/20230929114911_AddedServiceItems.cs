using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedServiceItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceItems",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GarageID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceItems", x => x.ID);
                });

            migrationBuilder.Sql("INSERT INTO ServiceItems(Description,  Price,  GarageID )VALUES (N'Γενικός Έλεγχος',17,1)");
            migrationBuilder.Sql("INSERT INTO ServiceItems(Description,  Price,  GarageID )VALUES (N'Αλλαγή Δίσκων Μπροστά',12,1)");
            migrationBuilder.Sql("INSERT INTO ServiceItems(Description,  Price,  GarageID )VALUES (N'Αλλαγή Δίσκων Πίσω',10,1)");
            migrationBuilder.Sql("INSERT INTO ServiceItems(Description,  Price,  GarageID )VALUES (N'Αλλαγή Ελαστικών',NULL,1)");
            migrationBuilder.Sql("INSERT INTO ServiceItems(Description,  Price,  GarageID )VALUES (N'Αλλαγή Ιμάντα Χρονισμού',15.50,1)");
            migrationBuilder.Sql("INSERT INTO ServiceItems(Description,  Price,  GarageID )VALUES (N'Αλλαγή Λαδιών',10.50,1)");
            migrationBuilder.Sql("INSERT INTO ServiceItems(Description,  Price,  GarageID )VALUES (N'Αλλαγή Μπαταρίας',NULL,1)");
            migrationBuilder.Sql("INSERT INTO ServiceItems(Description,  Price,  GarageID )VALUES (N'Αλλαγή Μπουζί',NULL,1)");
            migrationBuilder.Sql("INSERT INTO ServiceItems(Description,  Price,  GarageID )VALUES (N'Αλλαγή Τακάκια Μπροστά',NULL,1)");
            migrationBuilder.Sql("INSERT INTO ServiceItems(Description,  Price,  GarageID )VALUES (N'Αλλαγή Τακάκια Πίσω',NULL,1)");
            migrationBuilder.Sql("INSERT INTO ServiceItems(Description,  Price,  GarageID )VALUES (N'Αλλαγή Υγρών Φρένων',NULL,1)");
            migrationBuilder.Sql("INSERT INTO ServiceItems(Description,  Price,  GarageID )VALUES (N'Αλλαγή Φίλτρου Αέρα',NULL,1)");
            migrationBuilder.Sql("INSERT INTO ServiceItems(Description,  Price,  GarageID )VALUES (N'Αλλαγή Φίλτρου Βενζίνης',NULL,1)");
            migrationBuilder.Sql("INSERT INTO ServiceItems(Description,  Price,  GarageID )VALUES (N'Αλλαγή Φίλτρου Καμπίνας',22.15,1)");
            migrationBuilder.Sql("INSERT INTO ServiceItems(Description,  Price,  GarageID )VALUES (N'Αλλαγή Φίλτρου Λαδιού',8.50,1)");
            migrationBuilder.Sql("INSERT INTO ServiceItems(Description,  Price,  GarageID )VALUES (N'Αλλαγή Φίλτρου Πετρελαίου',NULL,1)");
            migrationBuilder.Sql("INSERT INTO ServiceItems(Description,  Price,  GarageID )VALUES (N'Εξαέρωση Φρένων',NULL,1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceItems");
        }
    }
}
