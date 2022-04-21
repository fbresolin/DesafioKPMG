using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioKPMG.DataService.Migrations
{
    public partial class CorrectLastUpdateDateColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lastUpdateDate",
                table: "Players",
                newName: "LastUpdateDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastUpdateDate",
                table: "Players",
                newName: "lastUpdateDate");
        }
    }
}
