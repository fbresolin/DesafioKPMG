using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioKPMG.DataService.Migrations
{
    public partial class RemovedUnusedIdEntriesFromGameResultsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "GameResults");

            migrationBuilder.DropColumn(
                name: "duplicateId",
                table: "GameResults");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "GameResults",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "duplicateId",
                table: "GameResults",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
