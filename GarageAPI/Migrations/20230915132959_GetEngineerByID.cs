using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class GetEngineerByID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var GetCustomerCars = @"CREATE PROCEDURE GetEngineerByID
                -- Add the parameters for the stored procedure here
                @EngineerID BIGINT
                AS
                    BEGIN
                        SET NOCOUNT ON;
                        SELECT U.*, 
                               ES.Speciality AS EngineerSpeciality
                        FROM Users U
                             LEFT OUTER JOIN EngineerSpeciality ES ON ES.ID = U.Speciality
                        WHERE U.UserType = 3
                              AND U.ID = @EngineerID;
                    END;";

            migrationBuilder.Sql(GetCustomerCars);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
