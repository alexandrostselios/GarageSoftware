using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangesINEmailController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Receiver",
                table: "Email");

            migrationBuilder.AddColumn<long>(
                name: "SenderID",
                table: "Email",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "SenderID",
            //    table: "Email");

            //migrationBuilder.AddColumn<string>(
            //    name: "Receiver",
            //    table: "Email",
            //    type: "nvarchar(max)",
            //    nullable: true);
        }
    }
}
