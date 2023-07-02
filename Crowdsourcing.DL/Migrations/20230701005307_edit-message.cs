using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crowdsourcing.DL.Migrations
{
    public partial class editmessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Freelancers_FreelancerId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Proposals_ProposalId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ProposalId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ProposalId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Messages");

            migrationBuilder.AlterColumn<int>(
                name: "FreelancerId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ClientId",
                table: "Messages",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Clients_ClientId",
                table: "Messages",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Freelancers_FreelancerId",
                table: "Messages",
                column: "FreelancerId",
                principalTable: "Freelancers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Clients_ClientId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Freelancers_FreelancerId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ClientId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Messages");

            migrationBuilder.AlterColumn<int>(
                name: "FreelancerId",
                table: "Messages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProposalId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverId",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderId",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ProposalId",
                table: "Messages",
                column: "ProposalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Freelancers_FreelancerId",
                table: "Messages",
                column: "FreelancerId",
                principalTable: "Freelancers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Proposals_ProposalId",
                table: "Messages",
                column: "ProposalId",
                principalTable: "Proposals",
                principalColumn: "Id");
        }
    }
}
