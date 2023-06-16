using GarageAPI.Models.EngineerSpeciality;
using GarageAPI.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

#nullable disable

namespace GarageAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddStoredProcedureForEngineers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            var GetEngineers = @"CREATE PROCEDURE GetEngineers
            AS
                BEGIN
                    SET NOCOUNT ON;
                    SELECT U.*, 
                           ES.Speciality AS EngineerSpeciality
                    FROM Users U
                         LEFT OUTER JOIN EngineerSpeciality ES ON ES.ID = U.Speciality
                    WHERE U.UserType = 3;
                END;
            GO";

            migrationBuilder.Sql(GetEngineers);           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
