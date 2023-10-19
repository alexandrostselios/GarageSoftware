using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class ModifyProcedureToIncludeGarageID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            var GetEngineers = @"
            ALTER PROCEDURE[dbo].[GetEngineers]
                @GarageID BIGINT
            AS
                BEGIN
                    SET NOCOUNT ON;
                        SELECT U.*, 
                            ES.Speciality AS EngineerSpeciality
                    FROM Users U
                            LEFT OUTER JOIN EngineerSpeciality ES ON ES.ID = U.Speciality
                    WHERE U.UserType = 3
                            AND U.GarageID = @GarageID;
                END;
            GO";

            migrationBuilder.Sql(GetEngineers);

            var GetEngineersByID = @"
            ALTER PROCEDURE [dbo].[GetEngineerByID]
            -- Add the parameters for the stored procedure here
            @EngineerID BIGINT, 
            @GarageID   BIGINT
            AS
                BEGIN
                    SET NOCOUNT ON;
                    SELECT U.*, 
                           ES.Speciality AS EngineerSpeciality
                    FROM Users U
                         LEFT OUTER JOIN EngineerSpeciality ES ON ES.ID = U.Speciality
                    WHERE U.UserType = 3
                          AND U.ID = @EngineerID
                          AND U.GarageID = @GarageID;
                END;
            GO";

            migrationBuilder.Sql(GetEngineersByID);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
