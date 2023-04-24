using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crowdsourcing.DL.Migrations
{
    public partial class removeverification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Freelancers_AspNetUsers_ApplicationUserId1",
                table: "Freelancers");

            migrationBuilder.DropIndex(
                name: "IX_Freelancers_ApplicationUserId1",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "VerficationState",
                table: "Freelancers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Freelancers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Freelancers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "VerficationState",
                table: "Freelancers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Freelancers_ApplicationUserId1",
                table: "Freelancers",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Freelancers_AspNetUsers_ApplicationUserId1",
                table: "Freelancers",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
