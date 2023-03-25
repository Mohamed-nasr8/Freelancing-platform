using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crowdsourcing.DL.Migrations
{
    public partial class removeUserAccountEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_user_account_UserAccountId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Freelancers_user_account_UserAccountId",
                table: "Freelancers");

            migrationBuilder.DropTable(
                name: "user_account");

            migrationBuilder.DropIndex(
                name: "IX_Freelancers_UserAccountId",
                table: "Freelancers");

            migrationBuilder.DropIndex(
                name: "IX_Clients_UserAccountId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "Clients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserAccountId",
                table: "Freelancers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserAccountId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "user_account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    FName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_account", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Freelancers_UserAccountId",
                table: "Freelancers",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserAccountId",
                table: "Clients",
                column: "UserAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_user_account_UserAccountId",
                table: "Clients",
                column: "UserAccountId",
                principalTable: "user_account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Freelancers_user_account_UserAccountId",
                table: "Freelancers",
                column: "UserAccountId",
                principalTable: "user_account",
                principalColumn: "Id");
        }
    }
}
