using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioKPMG.DataService.Migrations
{
    public partial class AddBalanceAndLastUpdateToPlayersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Balance",
                table: "Players",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "lastUpdateDate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "lastUpdateDate",
                table: "Players");
        }
    }
}
