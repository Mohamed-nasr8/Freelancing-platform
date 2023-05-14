using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crowdsourcing.DL.Migrations
{
    public partial class editsrviceentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Services",
                newName: "RequiredTimeInDays");

            migrationBuilder.RenameColumn(
                name: "N_of_people",
                table: "Services",
                newName: "Level");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Services",
                newName: "Postedtime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequiredTimeInDays",
                table: "Services",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Postedtime",
                table: "Services",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Services",
                newName: "N_of_people");
        }
    }
}
