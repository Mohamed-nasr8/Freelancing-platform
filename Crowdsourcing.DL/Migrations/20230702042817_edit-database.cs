using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crowdsourcing.DL.Migrations
{
    public partial class editdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_PaymentTypes_PaymentTypeId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Proposals_PaymentTypes_PaymentTypeId",
                table: "Proposals");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_PaymentTypes_PaymentTypeId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Withdraws_PaymentTypes_PaymentTypeId",
                table: "Withdraws");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropIndex(
                name: "IX_Withdraws_PaymentTypeId",
                table: "Withdraws");

            migrationBuilder.DropIndex(
                name: "IX_Services_PaymentTypeId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Proposals_PaymentTypeId",
                table: "Proposals");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_PaymentTypeId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "Withdraws");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "Point",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "Contracts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "Withdraws",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "Proposals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Point",
                table: "Freelancers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    AttachmentLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Withdraws_PaymentTypeId",
                table: "Withdraws",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_PaymentTypeId",
                table: "Services",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_PaymentTypeId",
                table: "Proposals",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_PaymentTypeId",
                table: "Contracts",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_MessageId",
                table: "Attachments",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_PaymentTypes_PaymentTypeId",
                table: "Contracts",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Proposals_PaymentTypes_PaymentTypeId",
                table: "Proposals",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_PaymentTypes_PaymentTypeId",
                table: "Services",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Withdraws_PaymentTypes_PaymentTypeId",
                table: "Withdraws",
                column: "PaymentTypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
