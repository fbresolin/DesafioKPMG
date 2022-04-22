using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioKPMG.DataService.Migrations
{
    public partial class PopulateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Players (username, balance) VALUES ('user', 123)");
            migrationBuilder.Sql("INSERT INTO Players (username, balance) VALUES ('anotherUser', -123)");
            migrationBuilder.Sql("INSERT INTO GameResults (PlayerId, Win) VALUES (1, 123)");
            migrationBuilder.Sql("INSERT INTO GameResults (PlayerId, Win) VALUES (1, -123)");
            migrationBuilder.Sql("INSERT INTO GameResults (PlayerId, Win) VALUES (1, 123)");
            migrationBuilder.Sql("INSERT INTO GameResults (PlayerId, Win) VALUES (2, -123)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Players WHERE Id BETWEEN 1 AND 2");
        }
    }
}
