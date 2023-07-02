using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crowdsourcing.DL.Migrations
{
    public partial class addmessageentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Clients_ClientId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Proposals_ProposalId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ClientId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "MessageTime",
                table: "Messages",
                newName: "SentAt");

            migrationBuilder.RenameColumn(
                name: "MessageText",
                table: "Messages",
                newName: "SenderId");

            migrationBuilder.AlterColumn<int>(
                name: "ProposalId",
                table: "Messages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverId",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Proposals_ProposalId",
                table: "Messages",
                column: "ProposalId",
                principalTable: "Proposals",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Proposals_ProposalId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "SentAt",
                table: "Messages",
                newName: "MessageTime");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Messages",
                newName: "MessageText");

            migrationBuilder.AlterColumn<int>(
                name: "ProposalId",
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
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ClientId",
                table: "Messages",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Clients_ClientId",
                table: "Messages",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Proposals_ProposalId",
                table: "Messages",
                column: "ProposalId",
                principalTable: "Proposals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
