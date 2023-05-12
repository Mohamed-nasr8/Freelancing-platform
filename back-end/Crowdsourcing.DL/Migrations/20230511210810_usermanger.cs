using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crowdsourcing.DL.Migrations
{
    public partial class usermanger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_ApplicationUserId1",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ApplicationUserId1",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "verifacationState",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "Freelancers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CVName",
                table: "Freelancers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Freelancers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Clients",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Freelancers_UserId",
                table: "Freelancers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_UserId",
                table: "Clients",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Freelancers_AspNetUsers_UserId",
                table: "Freelancers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_UserId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Freelancers_AspNetUsers_UserId",
                table: "Freelancers");

            migrationBuilder.DropIndex(
                name: "IX_Freelancers_UserId",
                table: "Freelancers");

            migrationBuilder.DropIndex(
                name: "IX_Clients_UserId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "Freelancers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CVName",
                table: "Freelancers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Clients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "verifacationState",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ApplicationUserId1",
                table: "Clients",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_ApplicationUserId1",
                table: "Clients",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
